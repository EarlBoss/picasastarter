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
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonGeneralSettings = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonViewBackups = new System.Windows.Forms.Button();
            this.buttonBackupPics = new System.Windows.Forms.Button();
            this.buttonEditDB = new System.Windows.Forms.Button();
            this.buttonRunPicasa = new System.Windows.Forms.Button();
            this.buttonAddDB = new System.Windows.Forms.Button();
            this.buttonRemoveDB = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxPicasaDBs = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPicasaButtonDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRemovePicasaButton = new System.Windows.Forms.Button();
            this.buttonEditPicasaButton = new System.Windows.Forms.Button();
            this.listBoxPicasaButtons = new System.Windows.Forms.ListBox();
            this.buttonAddPicasaButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(484, 333);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(90, 23);
            this.buttonClose.TabIndex = 28;
            this.buttonClose.Text = "Close";
            this.toolTip.SetToolTip(this.buttonClose, "Save the settings and close PicasaStarter");
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonGeneralSettings
            // 
            this.buttonGeneralSettings.Location = new System.Drawing.Point(12, 333);
            this.buttonGeneralSettings.Name = "buttonGeneralSettings";
            this.buttonGeneralSettings.Size = new System.Drawing.Size(90, 23);
            this.buttonGeneralSettings.TabIndex = 29;
            this.buttonGeneralSettings.Text = "Options...";
            this.toolTip.SetToolTip(this.buttonGeneralSettings, "Set some general settings");
            this.buttonGeneralSettings.UseVisualStyleBackColor = true;
            this.buttonGeneralSettings.Click += new System.EventHandler(this.buttonGeneralSettings_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(108, 333);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(90, 23);
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
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            // 
            // buttonViewBackups
            // 
            this.buttonViewBackups.Location = new System.Drawing.Point(334, 165);
            this.buttonViewBackups.Name = "buttonViewBackups";
            this.buttonViewBackups.Size = new System.Drawing.Size(175, 35);
            this.buttonViewBackups.TabIndex = 49;
            this.buttonViewBackups.Text = "View Backups...";
            this.toolTip.SetToolTip(this.buttonViewBackups, "Run Picasa using this database");
            this.buttonViewBackups.UseVisualStyleBackColor = true;
            this.buttonViewBackups.Click += new System.EventHandler(this.buttonViewBackups_Click);
            // 
            // buttonBackupPics
            // 
            this.buttonBackupPics.Location = new System.Drawing.Point(334, 107);
            this.buttonBackupPics.Name = "buttonBackupPics";
            this.buttonBackupPics.Size = new System.Drawing.Size(175, 35);
            this.buttonBackupPics.TabIndex = 48;
            this.buttonBackupPics.Text = "Backup!";
            this.toolTip.SetToolTip(this.buttonBackupPics, "Run Picasa using this database");
            this.buttonBackupPics.UseVisualStyleBackColor = true;
            this.buttonBackupPics.Click += new System.EventHandler(this.buttonBackupPics_Click);
            // 
            // buttonEditDB
            // 
            this.buttonEditDB.Location = new System.Drawing.Point(123, 215);
            this.buttonEditDB.Name = "buttonEditDB";
            this.buttonEditDB.Size = new System.Drawing.Size(65, 23);
            this.buttonEditDB.TabIndex = 47;
            this.buttonEditDB.Text = "Edit";
            this.toolTip.SetToolTip(this.buttonEditDB, "Remove the selected database from the list");
            this.buttonEditDB.UseVisualStyleBackColor = true;
            this.buttonEditDB.Click += new System.EventHandler(this.buttonEditDB_Click);
            // 
            // buttonRunPicasa
            // 
            this.buttonRunPicasa.BackColor = System.Drawing.Color.Transparent;
            this.buttonRunPicasa.Location = new System.Drawing.Point(334, 53);
            this.buttonRunPicasa.Name = "buttonRunPicasa";
            this.buttonRunPicasa.Size = new System.Drawing.Size(175, 35);
            this.buttonRunPicasa.TabIndex = 44;
            this.buttonRunPicasa.Text = "Run Picasa!";
            this.toolTip.SetToolTip(this.buttonRunPicasa, "Run Picasa using this database");
            this.buttonRunPicasa.UseVisualStyleBackColor = false;
            this.buttonRunPicasa.Click += new System.EventHandler(this.buttonRunPicasa_Click);
            // 
            // buttonAddDB
            // 
            this.buttonAddDB.BackColor = System.Drawing.Color.Transparent;
            this.buttonAddDB.Location = new System.Drawing.Point(37, 215);
            this.buttonAddDB.Name = "buttonAddDB";
            this.buttonAddDB.Size = new System.Drawing.Size(65, 23);
            this.buttonAddDB.TabIndex = 45;
            this.buttonAddDB.Text = "Add";
            this.toolTip.SetToolTip(this.buttonAddDB, "Add a new database to the list");
            this.buttonAddDB.UseVisualStyleBackColor = false;
            this.buttonAddDB.Click += new System.EventHandler(this.buttonAddDB_Click);
            // 
            // buttonRemoveDB
            // 
            this.buttonRemoveDB.Location = new System.Drawing.Point(207, 215);
            this.buttonRemoveDB.Name = "buttonRemoveDB";
            this.buttonRemoveDB.Size = new System.Drawing.Size(65, 23);
            this.buttonRemoveDB.TabIndex = 46;
            this.buttonRemoveDB.Text = "Remove";
            this.toolTip.SetToolTip(this.buttonRemoveDB, "Remove the selected database from the list");
            this.buttonRemoveDB.UseVisualStyleBackColor = true;
            this.buttonRemoveDB.Click += new System.EventHandler(this.buttonRemoveDB_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(566, 308);
            this.tabControl1.TabIndex = 43;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.buttonViewBackups);
            this.tabPage1.Controls.Add(this.listBoxPicasaDBs);
            this.tabPage1.Controls.Add(this.buttonBackupPics);
            this.tabPage1.Controls.Add(this.buttonEditDB);
            this.tabPage1.Controls.Add(this.buttonRunPicasa);
            this.tabPage1.Controls.Add(this.buttonAddDB);
            this.tabPage1.Controls.Add(this.buttonRemoveDB);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(558, 282);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Picasa databases";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Picasa databases:";
            // 
            // listBoxPicasaDBs
            // 
            this.listBoxPicasaDBs.FormattingEnabled = true;
            this.listBoxPicasaDBs.Location = new System.Drawing.Point(37, 53);
            this.listBoxPicasaDBs.Name = "listBoxPicasaDBs";
            this.listBoxPicasaDBs.Size = new System.Drawing.Size(235, 147);
            this.listBoxPicasaDBs.TabIndex = 43;
            this.listBoxPicasaDBs.SelectedIndexChanged += new System.EventHandler(this.listBoxPicasaDBs_SelectedIndexChanged);
            this.listBoxPicasaDBs.DoubleClick += new System.EventHandler(this.listBoxPicasaDBs_DoubleClick);
            this.listBoxPicasaDBs.MouseLeave += new System.EventHandler(this.listBoxPicasaDBs_MouseLeave);
            this.listBoxPicasaDBs.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnListBoxMouseMove);
            // 
            // tabPage2
            // 
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.textBoxPicasaButtonDesc);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.buttonRemovePicasaButton);
            this.tabPage2.Controls.Add(this.buttonEditPicasaButton);
            this.tabPage2.Controls.Add(this.listBoxPicasaButtons);
            this.tabPage2.Controls.Add(this.buttonAddPicasaButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(558, 282);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Picasa buttons";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Picasa buttons:";
            // 
            // textBoxPicasaButtonDesc
            // 
            this.textBoxPicasaButtonDesc.Enabled = false;
            this.textBoxPicasaButtonDesc.Location = new System.Drawing.Point(320, 53);
            this.textBoxPicasaButtonDesc.Multiline = true;
            this.textBoxPicasaButtonDesc.Name = "textBoxPicasaButtonDesc";
            this.textBoxPicasaButtonDesc.Size = new System.Drawing.Size(200, 147);
            this.textBoxPicasaButtonDesc.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Description:";
            // 
            // buttonRemovePicasaButton
            // 
            this.buttonRemovePicasaButton.Location = new System.Drawing.Point(206, 215);
            this.buttonRemovePicasaButton.Name = "buttonRemovePicasaButton";
            this.buttonRemovePicasaButton.Size = new System.Drawing.Size(65, 23);
            this.buttonRemovePicasaButton.TabIndex = 28;
            this.buttonRemovePicasaButton.Text = "Remove";
            this.buttonRemovePicasaButton.UseVisualStyleBackColor = true;
            this.buttonRemovePicasaButton.Click += new System.EventHandler(this.buttonRemovePicasaButton_Click);
            // 
            // buttonEditPicasaButton
            // 
            this.buttonEditPicasaButton.Location = new System.Drawing.Point(121, 215);
            this.buttonEditPicasaButton.Name = "buttonEditPicasaButton";
            this.buttonEditPicasaButton.Size = new System.Drawing.Size(65, 23);
            this.buttonEditPicasaButton.TabIndex = 27;
            this.buttonEditPicasaButton.Text = "Edit";
            this.buttonEditPicasaButton.UseVisualStyleBackColor = true;
            this.buttonEditPicasaButton.Click += new System.EventHandler(this.buttonEditPicasaButton_Click);
            // 
            // listBoxPicasaButtons
            // 
            this.listBoxPicasaButtons.FormattingEnabled = true;
            this.listBoxPicasaButtons.Location = new System.Drawing.Point(35, 53);
            this.listBoxPicasaButtons.Name = "listBoxPicasaButtons";
            this.listBoxPicasaButtons.Size = new System.Drawing.Size(236, 147);
            this.listBoxPicasaButtons.TabIndex = 25;
            this.listBoxPicasaButtons.SelectedIndexChanged += new System.EventHandler(this.listBoxPicasaButtons_SelectedIndexChanged);
            this.listBoxPicasaButtons.DoubleClick += new System.EventHandler(this.listBoxPicasaButtons_DoubleClick);
            // 
            // buttonAddPicasaButton
            // 
            this.buttonAddPicasaButton.Location = new System.Drawing.Point(35, 215);
            this.buttonAddPicasaButton.Name = "buttonAddPicasaButton";
            this.buttonAddPicasaButton.Size = new System.Drawing.Size(65, 23);
            this.buttonAddPicasaButton.TabIndex = 26;
            this.buttonAddPicasaButton.Text = "Add";
            this.buttonAddPicasaButton.UseVisualStyleBackColor = true;
            this.buttonAddPicasaButton.Click += new System.EventHandler(this.buttonAddPicasaButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 368);
            this.Controls.Add(this.buttonGeneralSettings);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PicasaStarter Version 2.0 (Build: ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonGeneralSettings;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonViewBackups;
        private System.Windows.Forms.ListBox listBoxPicasaDBs;
        private System.Windows.Forms.Button buttonBackupPics;
        private System.Windows.Forms.Button buttonEditDB;
        private System.Windows.Forms.Button buttonRunPicasa;
        private System.Windows.Forms.Button buttonAddDB;
        private System.Windows.Forms.Button buttonRemoveDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPicasaButtonDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRemovePicasaButton;
        private System.Windows.Forms.Button buttonEditPicasaButton;
        private System.Windows.Forms.ListBox listBoxPicasaButtons;
        private System.Windows.Forms.Button buttonAddPicasaButton;
    }
}

