using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;

using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

using System.Data.OleDb;

namespace OPWorkflow
{
    public sealed partial class OrderProcessingWorkflow : SequentialWorkflowActivity
    {
        private OleDbConnection connection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;data source=db.mdb");
        
        // WF 3.5 bemeneti paraméterei
        private string rendeltTermek = "";
        private int rendeltMennyiseg = 0;

        // Adatbázisból inicializálódó változók
        private int keszleten = 0;
        private int kozpontiRaktarban = 0;

        // Státuszok tárolására használt tömb amit majd a WF végén írunk be az adatbázisba
        private string[] history = new string[3];

        // WF kimeneti paramétere
        private string result = "";

        // segéd változó idő tárolására
        private double timer = 0;

        public OrderProcessingWorkflow()
        {
            InitializeComponent();
            history[0] = DateTime.Now.ToLongTimeString();

            // Kezdő viszonyítási pont megadása
            timer = DateTime.Now.Minute * 60000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
        }

        public string Termék
        {
            set
            {
                this.rendeltTermek = value;
            }
        }
        public int Mennyiség
        {
            set
            {
                this.rendeltMennyiseg = value;
            }
        }
        public string Result
        {
            get
            {
                return this.result;
            }
        }

        private void KeszletInicializal_ExecuteCode(object sender, EventArgs e)
        {
            #region valós készletet inicializál
            OleDbDataReader rdr = null;
            try
            {
                connection.Open();
                string query = @"SELECT mennyiség FROM készlet 
                                WHERE terméknév = '" + this.rendeltTermek + "'";

                OleDbCommand cmd = new OleDbCommand(query, connection);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    this.keszleten = (int)rdr[0];
                }
            }
            finally
            {
                if (rdr != null) rdr.Close();
                if (connection != null) connection.Close();
            }
            #endregion
            #region valós központi raktárkészletet inicializál
            try
            {
                connection.Open();
                string query = @"SELECT mennyiség FROM központiraktár 
                                WHERE terméknév = '" + this.rendeltTermek + "'";

                OleDbCommand cmd = new OleDbCommand(query, connection);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    this.kozpontiRaktarban = (int)rdr[0];
                }
            }
            finally
            {
                if (rdr != null) rdr.Close();
                if (connection != null) connection.Close();
            }
            #endregion
        }

        private void AdatBazistFrissit1_ExecuteCode(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string updateString =
                    @"UPDATE készlet SET mennyiség = "
                    + (this.keszleten - this.rendeltMennyiseg)
                    + " WHERE terméknév = '" + this.rendeltTermek + "'";

                OleDbCommand cmd = new OleDbCommand(updateString);
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        private void AdatBazistFrissit2_ExecuteCode(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string updateString1 =
                    @"UPDATE készlet SET mennyiség = 0 
                    WHERE terméknév = '" + this.rendeltTermek + "'";

                OleDbCommand cmd = new OleDbCommand(updateString1);
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();

                string updateString2 =
                    @"UPDATE központiraktár SET mennyiség = "
                    + (this.kozpontiRaktarban - (this.rendeltMennyiseg - this.keszleten))
                    + " WHERE terméknév = '" + this.rendeltTermek + "'";

                cmd = new OleDbCommand(updateString2);
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        private void RendelestBejegyez_ExecuteCode(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                string insertString = @"
                 INSERT INTO rendelések
                 (terméknév, mennyiség, megkapva, Feldolgozási_idő, WF_befejezve)
                 values ('" + this.rendeltTermek + "', '" + this.rendeltMennyiseg + "','"
                            + history[0] + "','" + history[1] + "','" + DateTime.Now.ToLongTimeString() + "')";

                OleDbCommand cmd = new OleDbCommand(insertString);
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        private void UpdateHistory_ExecuteCode(object sender, EventArgs e)
        {
            double i = (DateTime.Now.Minute * 60000 + DateTime.Now.Second * 1000
                    + DateTime.Now.Millisecond - timer) / 1000;
            if (this.rendeltMennyiseg <= this.keszleten)
            {
                // WF inicializálás-tól (timer) eltelt időt adja vissza másodpercben
                history[1] = i.ToString() + " s készletről";
            }
            else if (this.keszleten + this.kozpontiRaktarban >= this.rendeltMennyiseg)
            {
                history[1] = i.ToString() + " s központból";
            }
            else
            {
                history[1] = "készlethiány";
                this.result = "Maximum " + (keszleten + kozpontiRaktarban) + " db rendelhető!";
            }
        }
    }
}
