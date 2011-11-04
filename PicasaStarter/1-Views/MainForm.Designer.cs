namespace PicasaStarter
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listBoxPicasaDBs = new System.Windows.Forms.ListBox();
            this.buttonRunPicasa = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonGeneralSettings = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAddDB = new System.Windows.Forms.Button();
            this.buttonRemoveDB = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonBackupPics = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonPicasaButtons = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxPicasaDBs
            // 
            this.listBoxPicasaDBs.FormattingEnabled = true;
            this.listBoxPicasaDBs.Location = new System.Drawing.Point(43, 34);
            this.listBoxPicasaDBs.Name = "listBoxPicasaDBs";
            this.listBoxPicasaDBs.Size = new System.Drawing.Size(200, 147);
            this.listBoxPicasaDBs.TabIndex = 22;
            this.listBoxPicasaDBs.SelectedIndexChanged += new System.EventHandler(this.listBoxPicasaDBs_SelectedIndexChanged);
            this.listBoxPicasaDBs.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnListBoxMouseMove);
            // 
            // buttonRunPicasa
            // 
            this.buttonRunPicasa.Location = new System.Drawing.Point(321, 32);
            this.buttonRunPicasa.Name = "buttonRunPicasa";
            this.buttonRunPicasa.Size = new System.Drawing.Size(200, 40);
            this.buttonRunPicasa.TabIndex = 27;
            this.buttonRunPicasa.Text = "Run Picasa!";
            this.toolTip.SetToolTip(this.buttonRunPicasa, "Run Picasa using this database");
            this.buttonRunPicasa.UseVisualStyleBackColor = true;
            this.buttonRunPicasa.Click += new System.EventHandler(this.buttonRunPicasa_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(436, 333);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(96, 23);
            this.buttonClose.TabIndex = 28;
            this.buttonClose.Text = "Close";
            this.toolTip.SetToolTip(this.buttonClose, "Save the settings and close PicasaStarter");
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonGeneralSettings
            // 
            this.buttonGeneralSettings.Location = new System.Drawing.Point(54, 263);
            this.buttonGeneralSettings.Name = "buttonGeneralSettings";
            this.buttonGeneralSettings.Size = new System.Drawing.Size(200, 37);
            this.buttonGeneralSettings.TabIndex = 29;
            this.buttonGeneralSettings.Text = "General preferences...";
            this.toolTip.SetToolTip(this.buttonGeneralSettings, "Set some general settings");
            this.buttonGeneralSettings.UseVisualStyleBackColor = true;
            this.buttonGeneralSettings.Click += new System.EventHandler(this.buttonGeneralSettings_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(332, 333);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(98, 23);
            this.buttonHelp.TabIndex = 31;
            this.buttonHelp.Text = "Help";
            this.toolTip.SetToolTip(this.buttonHelp, "Help... says it all I suppose...");
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(17, 326);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 0);
            this.panel1.TabIndex = 32;
            // 
            // buttonAddDB
            // 
            this.buttonAddDB.Location = new System.Drawing.Point(42, 191);
            this.buttonAddDB.Name = "buttonAddDB";
            this.buttonAddDB.Size = new System.Drawing.Size(60, 23);
            this.buttonAddDB.TabIndex = 33;
            this.buttonAddDB.Text = "Add";
            this.toolTip.SetToolTip(this.buttonAddDB, "Add a new database to the list");
            this.buttonAddDB.UseVisualStyleBackColor = true;
            this.buttonAddDB.Click += new System.EventHandler(this.buttonAddDB_Click);
            // 
            // buttonRemoveDB
            // 
            this.buttonRemoveDB.Location = new System.Drawing.Point(183, 191);
            this.buttonRemoveDB.Name = "buttonRemoveDB";
            this.buttonRemoveDB.Size = new System.Drawing.Size(60, 23);
            this.buttonRemoveDB.TabIndex = 34;
            this.buttonRemoveDB.Text = "Remove";
            this.toolTip.SetToolTip(this.buttonRemoveDB, "Remove the selected database from the list");
            this.buttonRemoveDB.UseVisualStyleBackColor = true;
            this.buttonRemoveDB.Click += new System.EventHandler(this.buttonRemoveDB_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.listBoxPicasaDBs);
            this.groupBox1.Controls.Add(this.buttonBackupPics);
            this.groupBox1.Controls.Add(this.buttonEdit);
            this.groupBox1.Controls.Add(this.buttonRunPicasa);
            this.groupBox1.Controls.Add(this.buttonAddDB);
            this.groupBox1.Controls.Add(this.buttonRemoveDB);
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 234);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Picasa Databases";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(321, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 40);
            this.button1.TabIndex = 42;
            this.button1.Text = "View Backups...";
            this.toolTip.SetToolTip(this.button1, "Run Picasa using this database");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonViewBackups_Click);
            // 
            // buttonBackupPics
            // 
            this.buttonBackupPics.Location = new System.Drawing.Point(321, 104);
            this.buttonBackupPics.Name = "buttonBackupPics";
            this.buttonBackupPics.Size = new System.Drawing.Size(200, 40);
            this.buttonBackupPics.TabIndex = 41;
            this.buttonBackupPics.Text = "Backup!";
            this.toolTip.SetToolTip(this.buttonBackupPics, "Run Picasa using this database");
            this.buttonBackupPics.UseVisualStyleBackColor = true;
            this.buttonBackupPics.Click += new System.EventHandler(this.buttonBackupPics_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(111, 191);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(60, 23);
            this.buttonEdit.TabIndex = 35;
            this.buttonEdit.Text = "Edit";
            this.toolTip.SetToolTip(this.buttonEdit, "Remove the selected database from the list");
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            // 
            // buttonPicasaButtons
            // 
            this.buttonPicasaButtons.Location = new System.Drawing.Point(332, 263);
            this.buttonPicasaButtons.Name = "buttonPicasaButtons";
            this.buttonPicasaButtons.Size = new System.Drawing.Size(200, 37);
            this.buttonPicasaButtons.TabIndex = 46;
            this.buttonPicasaButtons.Text = "Manage Picasa buttons...";
            this.toolTip.SetToolTip(this.buttonPicasaButtons, "Set some general settings");
            this.buttonPicasaButtons.UseVisualStyleBackColor = true;
            this.buttonPicasaButtons.Click += new System.EventHandler(this.buttonPicasaButtons_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(12, 321);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(566, 2);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 368);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonPicasaButtons);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonGeneralSettings);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "PicasaStarter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPicasaDBs;
        private System.Windows.Forms.Button buttonRunPicasa;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonGeneralSettings;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAddDB;
        private System.Windows.Forms.Button buttonRemoveDB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonBackupPics;
        private System.Windows.Forms.Button buttonPicasaButtons;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

