using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data.OleDb;

namespace WF4
{

    public sealed class initDB : CodeActivity
    {
        public InArgument<OleDbConnection> Con { get; set; }
        public InArgument<String> RendeltTermék { get; set; }
        public OutArgument<Int32> Készleten { get; set; }
        public OutArgument<Int32> Központban { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            #region valós készletet inicializál
            OleDbDataReader rdr = null;
            try
            {
                Con.Get(context).Open();
                string query = @"SELECT mennyiség FROM készlet 
                                WHERE terméknév = '" + RendeltTermék.Get(context) + "'";

                OleDbCommand cmd = new OleDbCommand(query, Con.Get(context));

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    context.SetValue(Készleten,(int)rdr[0]);
                }
            }
            finally
            {
                if (rdr != null) rdr.Close();
                if (Con.Get(context) != null) Con.Get(context).Close();
            }
            #endregion

            #region valós központi raktárkészletet inicializál
            try
            {
                Con.Get(context).Open();
                string query = @"SELECT mennyiség FROM központiraktár 
                                WHERE terméknév = '" + RendeltTermék.Get(context) + "'";

                OleDbCommand cmd = new OleDbCommand(query, Con.Get(context));

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    context.SetValue(Központban, (int)rdr[0]);
                }
            }
            finally
            {
                if (rdr != null) rdr.Close();
                if (Con.Get(context) != null) Con.Get(context).Close();
            }
            #endregion
        }
    }
}
