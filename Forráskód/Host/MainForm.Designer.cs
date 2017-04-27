namespace Host
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        [System.Diagnostics.DebuggerStepThrough()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.itemsList = new System.Windows.Forms.ComboBox();
            this.itemsQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnOrder = new System.Windows.Forms.Button();
            this.tbState = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kilépToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.szerkesztőToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korábbiRendelésekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.névjegyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sugóToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kilépésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.itemsQuantity)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Termék";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mennyiség";
            // 
            // itemsList
            // 
            this.itemsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemsList.FormattingEnabled = true;
            this.itemsList.Location = new System.Drawing.Point(12, 52);
            this.itemsList.Name = "itemsList";
            this.itemsList.Size = new System.Drawing.Size(121, 21);
            this.itemsList.TabIndex = 2;
            // 
            // itemsQuantity
            // 
            this.itemsQuantity.Location = new System.Drawing.Point(75, 86);
            this.itemsQuantity.Name = "itemsQuantity";
            this.itemsQuantity.Size = new System.Drawing.Size(58, 20);
            this.itemsQuantity.TabIndex = 3;
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(153, 129);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(98, 32);
            this.btnOrder.TabIndex = 5;
            this.btnOrder.Text = "Rendel";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // tbState
            // 
            this.tbState.Location = new System.Drawing.Point(12, 167);
            this.tbState.Multiline = true;
            this.tbState.Name = "tbState";
            this.tbState.ReadOnly = true;
            this.tbState.Size = new System.Drawing.Size(239, 96);
            this.tbState.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rendelés Státusza";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kilépToolStripMenuItem,
            this.névjegyToolStripMenuItem,
            this.sugóToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(263, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kilépToolStripMenuItem
            // 
            this.kilépToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.szerkesztőToolStripMenuItem,
            this.korábbiRendelésekToolStripMenuItem,
            this.toolStripSeparator1,
            this.kilépésToolStripMenuItem});
            this.kilépToolStripMenuItem.Name = "kilépToolStripMenuItem";
            this.kilépToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.kilépToolStripMenuItem.Text = "Fájl";
            // 
            // szerkesztőToolStripMenuItem
            // 
            this.szerkesztőToolStripMenuItem.Name = "szerkesztőToolStripMenuItem";
            this.szerkesztőToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.szerkesztőToolStripMenuItem.Text = "Adatbázis Szerkesztő";
            this.szerkesztőToolStripMenuItem.Click += new System.EventHandler(this.szerkesztőToolStripMenuItem_Click);
            // 
            // korábbiRendelésekToolStripMenuItem
            // 
            this.korábbiRendelésekToolStripMenuItem.Name = "korábbiRendelésekToolStripMenuItem";
            this.korábbiRendelésekToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.korábbiRendelésekToolStripMenuItem.Text = "Korábbi rendelések";
            this.korábbiRendelésekToolStripMenuItem.Click += new System.EventHandler(this.korábbiRendelésekToolStripMenuItem_Click);
            // 
            // névjegyToolStripMenuItem
            // 
            this.névjegyToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.névjegyToolStripMenuItem.Name = "névjegyToolStripMenuItem";
            this.névjegyToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.névjegyToolStripMenuItem.Text = "Névjegy";
            this.névjegyToolStripMenuItem.Click += new System.EventHandler(this.névjegyToolStripMenuItem_Click);
            // 
            // sugóToolStripMenuItem
            // 
            this.sugóToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sugóToolStripMenuItem.Name = "sugóToolStripMenuItem";
            this.sugóToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.sugóToolStripMenuItem.Text = "Sugó";
            this.sugóToolStripMenuItem.Click += new System.EventHandler(this.sugóToolStripMenuItem_Click);
            // 
            // kilépésToolStripMenuItem
            // 
            this.kilépésToolStripMenuItem.Name = "kilépésToolStripMenuItem";
            this.kilépésToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.kilépésToolStripMenuItem.Text = "Kilépés";
            this.kilépésToolStripMenuItem.Click += new System.EventHandler(this.kilépésToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(153, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(98, 79);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "WF Select";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(68, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = ".NET 3.5";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(7, 44);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(68, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = ".NET 4.0";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 275);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbState);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.itemsQuantity);
            this.Controls.Add(this.itemsList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.itemsQuantity)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox itemsList;
        private System.Windows.Forms.NumericUpDown itemsQuantity;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.TextBox tbState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kilépToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem névjegyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sugóToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem szerkesztőToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem korábbiRendelésekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kilépésToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

