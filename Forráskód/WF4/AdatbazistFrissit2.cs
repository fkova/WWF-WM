using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Data.OleDb;

namespace WF4
{

    public sealed class AdatbazistFrissit2 : CodeActivity
    {
        public InArgument<OleDbConnection> Con { get; set; }
        public InArgument<String> RendeltTermék { get; set; }
        public InArgument<Int32> Készleten { get; set; }
        public InArgument<Int32> RendeltMennyiség { get; set; }
        public InArgument<Int32> Központiraktárban { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                Con.Get(context).Open();
                string updateString1 =
                    @"UPDATE készlet SET mennyiség = 0 
                    WHERE terméknév = '" + RendeltTermék.Get(context) + "'";

                OleDbCommand cmd = new OleDbCommand(updateString1);
                cmd.Connection = Con.Get(context);
                cmd.ExecuteNonQuery();

                string updateString2 =
                    @"UPDATE központiraktár SET mennyiség = "
                    + (Központiraktárban.Get(context) - (RendeltMennyiség.Get(context) - Készleten.Get(context)))
                    + " WHERE terméknév = '" + RendeltTermék.Get(context) + "'";

                cmd = new OleDbCommand(updateString2);
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
