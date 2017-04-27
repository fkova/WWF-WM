using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Data.OleDb;

namespace WF4
{

    public sealed class AdatbazistFrissit1 : CodeActivity
    {
        public InArgument<OleDbConnection> Con { get; set; }
        public InArgument<String> RendeltTermék { get; set; }
        public InArgument<Int32> Készleten { get; set; }
        public InArgument<Int32> RendeltMennyiség { get; set; }

        protected override void Execute(CodeActivityContext context)
        {

            Con.Get(context).Open();
            string updateString =
            @"UPDATE készlet SET mennyiség = "
            + (Készleten.Get(context) - RendeltMennyiség.Get(context))
            + " WHERE terméknév = '" + RendeltTermék.Get(context) + "'";

            OleDbCommand cmd = new OleDbCommand(updateString);
            cmd.Connection = Con.Get(context);
            cmd.ExecuteNonQuery();
            if (Con.Get(context) != null) { Con.Get(context).Close(); }
        }
    }
}
