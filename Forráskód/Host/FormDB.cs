using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;

namespace Host
{
    public partial class FormDB : Form
    {
        private OleDbCommandBuilder cb;
        private OleDbDataAdapter da;
        private OleDbDataAdapter da2;
        private OleDbDataAdapter da3;
        private OleDbCommand SqlCommand;


        public FormDB()
        {
            InitializeComponent();           
        }
      
        private void FormDB_Load(object sender, EventArgs e)
        {            
            OleDbConnection thisConnection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;data source=db.mdb");

            //Adatbázis táblák tartalmának megjelenítése a dataGrid vezérlőkön
             string sql = "SELECT * FROM rendelések";
             SqlCommand = new OleDbCommand(sql, thisConnection);            
             da = new OleDbDataAdapter();
             da.SelectCommand = SqlCommand;         
             cb = new OleDbCommandBuilder(da);            
             da.Fill(dataSet1, "rendelések");            
             dataGrid1.SetDataBinding(dataSet1, "rendelések");

             sql = "SELECT * FROM készlet";
             SqlCommand = new OleDbCommand(sql, thisConnection);
             da2 = new OleDbDataAdapter();
             da2.SelectCommand = SqlCommand;
             cb = new OleDbCommandBuilder(da2);
             da2.Fill(dataSet2, "készlet");
             dataGrid2.SetDataBinding(dataSet2, "készlet");
             
             sql = "SELECT * FROM központiraktár";
             SqlCommand = new OleDbCommand(sql, thisConnection);
             da3 = new OleDbDataAdapter();
             da3.SelectCommand = SqlCommand;
             cb = new OleDbCommandBuilder(da3);
             da3.Fill(dataSet3, "központiraktár");
             dataGrid3.SetDataBinding(dataSet3, "központiraktár");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // változtatások elmentése az adatbázisba
            da.Update(dataSet1, "rendelések");
            da2.Update(dataSet2, "készlet");
            da3.Update(dataSet3, "központiraktár");
        }

        public void UpdateTables()
        {
            OleDbConnection thisConnection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;data source=db.mdb");

            dataSet1.Clear();
            string sql = "SELECT * FROM rendelések";
            SqlCommand = new OleDbCommand(sql, thisConnection);
            da = new OleDbDataAdapter();
            da.SelectCommand = SqlCommand;
            cb = new OleDbCommandBuilder(da);
            da.Fill(dataSet1, "rendelések");
            dataGrid1.SetDataBinding(dataSet1, "rendelések");

            dataSet2.Clear();
            sql = "SELECT * FROM készlet";
            SqlCommand = new OleDbCommand(sql, thisConnection);
            da2 = new OleDbDataAdapter();
            da2.SelectCommand = SqlCommand;
            cb = new OleDbCommandBuilder(da2);
            da2.Fill(dataSet2, "készlet");
            dataGrid2.SetDataBinding(dataSet2, "készlet");

            dataSet3.Clear();
            sql = "SELECT * FROM központiraktár";
            SqlCommand = new OleDbCommand(sql, thisConnection);
            da3 = new OleDbDataAdapter();
            da3.SelectCommand = SqlCommand;
            cb = new OleDbCommandBuilder(da3);
            da3.Fill(dataSet3, "központiraktár");
            dataGrid3.SetDataBinding(dataSet3, "központiraktár");
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
