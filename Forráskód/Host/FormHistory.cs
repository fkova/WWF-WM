using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Host
{
    public partial class FormHistory : Form
    {
        public FormHistory()
        {
            InitializeComponent();
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;data source=db.mdb");
            con.Open();
            //létrehozza a data adaptert
            OleDbDataAdapter dAdapter = new OleDbDataAdapter("SELECT * FROM rendelések", con);
            //létrehozza az adattáblát a lekérdezési eredmények tárolására
            DataTable dTable = new DataTable();
            //feltölti az adattáblát
            dAdapter.Fill(dTable);
            //Kapcsolatotot hoz létre az adattábla és a DataGritView szinkronizálásához
            BindingSource bSource = new BindingSource();
            //szinkronizálás
            bSource.DataSource = dTable;
            //hozzárendelés a megjelenítő táblához           
            dataGridView1.DataSource = bSource;
        }
    }
}
