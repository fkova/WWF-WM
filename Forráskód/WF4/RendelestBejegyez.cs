using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Data.OleDb;

namespace WF4
{

    public sealed class RendelestBejegyez : CodeActivity
    {
        public InArgument<OleDbConnection> Con { get; set; }
        public InArgument<String> RendeltTermék { get; set; }
        public InArgument<Int32> RendeltMennyiség { get; set; }
        public InArgument<string[]> History { get; set; }

             
        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                Con.Get(context).Open();
                string[] i = History.Get(context);

                string insertString = @"
                 INSERT INTO rendelések
                 (terméknév, mennyiség, megkapva, Feldolgozási_idő, WF_befejezve)
                 values ('" + RendeltTermék.Get(context) + "', '" + RendeltMennyiség.Get(context) + "','"
                            + i[0] + "','" + i[1] + "','" + DateTime.Now.ToLongTimeString() + "')";

                OleDbCommand cmd = new OleDbCommand(insertString);
                cmd.Connection = Con.Get(context);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Con.Get(context) != null) { Con.Get(context).Close(); }
            }
        }
    }
}
