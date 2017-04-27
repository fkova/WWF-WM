using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

// Szerelvények a workflow 3.5-höz
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Activities;
using OPWorkflow;

// Szerelvény az adatbázishoz
using System.Data.OleDb;

// Szerelvények a workflow 4-hez
using WF4;
using System.Activities;
using System.Activities.Statements;
using System.Threading;

namespace Host
{
    public partial class MainForm : Form, IOrderingService
    {
        // Adatbázis kapcsolati sztring
        public OleDbConnection connection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;data source=db.mdb");

        FormDB NewWindow = new FormDB();

        // A Workflow futtatókörnyezet, példány és az külső adatcsere objektum létrehozása
        private WorkflowRuntime workflowRuntime = null;
        private WorkflowInstance workflowInstance = null;
        private ExternalDataExchangeService exchangeService = null;

        // Delegált a kívülről érkező üzenetek továbbítására a WorkflowToHost függvényhez
        private delegate void WorkflowToHostDelegate(string message);

        public MainForm()
        {
            InitializeComponent();
            #region Inicializálja a terméklistát az adatbázisból

            try
            {
                connection.Open();              
                OleDbCommand cmd = new OleDbCommand("SELECT terméknév FROM készlet", connection);
                OleDbDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    this.itemsList.Items.Add(rdr[0].ToString());
                }
                this.itemsList.SelectedIndex = 0;
                if (rdr != null) rdr.Close();
            }
            catch
            {
                MessageBox.Show("error");
            }
            finally
            {
                if (connection != null) connection.Close();
            }

            #endregion

            #region WF 3.5 Runtime inicializálása

            // A WF Runtime létrehozása és az ExternalDataExchangeService hozzárendelése
            this.workflowRuntime = new WorkflowRuntime();
            this.exchangeService = new ExternalDataExchangeService();
            this.workflowRuntime.AddService(this.exchangeService);
            this.exchangeService.AddService(this);
            this.workflowRuntime.StartRuntime();

            // Esemény létrehozása a Workflow befejezéséhez
            workflowRuntime.WorkflowCompleted +=
            new EventHandler<WorkflowCompletedEventArgs>
            (workflowRuntime_WorkflowCompleted);
            #endregion

            NewWindow.Show();
            NewWindow.Visible = false;
        }

        // Workflow 3.5 felől érkező státuszüzenetek kiírása
        public void WorkflowToHost(string message)
        {
            if (this.tbState.InvokeRequired)
            {
                this.tbState.Invoke(new WorkflowToHostDelegate(this.WorkflowToHost), message);
            }
            else
            {
                this.tbState.Text += message + "\r\n";
            }
        }

        // A Workflow 3.5 befejezésekor hívódik meg
        void workflowRuntime_WorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            if (this.tbState.InvokeRequired)
            {
                this.tbState.Invoke(new EventHandler<WorkflowCompletedEventArgs>
                (this.workflowRuntime_WorkflowCompleted), sender, e);
            }
            else
            {
                if (e.OutputParameters["Result"].ToString().Length != 0)
                {
                    this.tbState.Text += e.OutputParameters["Result"].ToString();
                }
                this.tbState.Text += "\r\nMunkafolyamat befejezve";

                NewWindow.UpdateTables();
                btnOrder.Enabled = true;
                this.szerkesztőToolStripMenuItem.Enabled = true;
                this.korábbiRendelésekToolStripMenuItem.Enabled = true;
            }
        }

        #region Gombok

        private void btnOrder_Click(object sender, EventArgs e)
        {
            
            if (this.itemsQuantity.Value != 0)
            {      
                btnOrder.Enabled = false;
                this.szerkesztőToolStripMenuItem.Enabled = false;
                this.korábbiRendelésekToolStripMenuItem.Enabled = false;
                this.kilépésToolStripMenuItem.Enabled = false;
                this.tbState.Clear();

                // A WF mindkét verziójához felhasznált Dictionary a rendelt termék és mennyiség átadására
                Dictionary<string, object> properties = new Dictionary<string, object>();
                properties.Add("Termék", itemsList.SelectedItem.ToString());
                properties.Add("Mennyiség", (int)itemsQuantity.Value);

                if (this.radioButton1.Checked == true)
                {
                    #region Start Workflow .NET 3.5

                    Type type = typeof(OPWorkflow.OrderProcessingWorkflow);
                    workflowInstance = workflowRuntime.CreateWorkflow(type, properties);
                    workflowInstance.Start();

                    #endregion
                }
                else
                {
                    #region Start Workflow .NET 4.0

                    this.tbState.Text += "Workflow Start";

                    var workflow = new workflow2();
                    var app = new WorkflowApplication(workflow, properties);
                    app.SynchronizationContext = SynchronizationContext.Current;

                    // WF4 befejezésekor hívódik meg
                    app.Completed = delegate(WorkflowApplicationCompletedEventArgs e2)
                    {
                        tbState.Text += Convert.ToString(e2.Outputs["Eredmény"]);
                        Thread.Sleep(500);
                        this.tbState.Text += "\r\n\nWorkflow Befejezve";

                        NewWindow.UpdateTables();
                        btnOrder.Enabled = true;
                        this.szerkesztőToolStripMenuItem.Enabled = true;
                        this.korábbiRendelésekToolStripMenuItem.Enabled = true;
                        this.kilépésToolStripMenuItem.Enabled = true;
                    };

                    // WF4 futása alatti megszakításokat jelzi (adatbázis műveletek)
                    app.Idle = delegate(WorkflowApplicationIdleEventArgs e2)
                    {
                        tbState.Text += "\r\n . . .";
                    };

                    // WF4 Start!
                    app.Run();

                    #endregion
                }
                
            }
            else
            {
                this.tbState.Text = "Jelöld ki mennyit szeretnél rendelni!";
            }
        }
      
        private void szerkesztőToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewWindow.Visible = true;
        }
        private void korábbiRendelésekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHistory ujablak = new FormHistory();
            ujablak.ShowDialog();
        }
        private void névjegyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Verziószám: v0.7 \nKészítette: Kovács Ferenc\nk.ferenc.attila@gmail.com");
        }
        private void sugóToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Kiválasztod a Workflow Verziót amit használni akarsz"
                           + "\n2 - Kiválasztod miből és mennyit szeretnél rendelni"
                           + "\n3 - Rámész a 'Rendelés' gombra");
        }
        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}
    
