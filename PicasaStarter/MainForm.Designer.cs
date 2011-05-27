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
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxDBBaseDir = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonBrowseDBBaseDir = new System.Windows.Forms.Button();
            this.textBoxDBName = new System.Windows.Forms.TextBox();
            this.listBoxPicasaDBs = new System.Windows.Forms.ListBox();
            this.buttonRunPicasa = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonGeneralSettings = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAddDB = new System.Windows.Forms.Button();
            this.buttonRemoveDB = new System.Windows.Forms.Button();
            this.textBoxDBDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDBFullDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonDBOpenFullDir = new System.Windows.Forms.Button();
            this.ButtonCreateShortcut = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Base directory:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxDBBaseDir
            // 
            this.textBoxDBBaseDir.Location = new System.Drawing.Point(89, 140);
            this.textBoxDBBaseDir.Name = "textBoxDBBaseDir";
            this.textBoxDBBaseDir.ReadOnly = true;
            this.textBoxDBBaseDir.Size = new System.Drawing.Size(250, 20);
            this.textBoxDBBaseDir.TabIndex = 23;
            this.textBoxDBBaseDir.TextChanged += new System.EventHandler(this.textBoxDBBaseDir_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Name:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonBrowseDBBaseDir
            // 
            this.buttonBrowseDBBaseDir.Location = new System.Drawing.Point(345, 137);
            this.buttonBrowseDBBaseDir.Name = "buttonBrowseDBBaseDir";
            this.buttonBrowseDBBaseDir.Size = new System.Drawing.Size(61, 23);
            this.buttonBrowseDBBaseDir.TabIndex = 5;
            this.buttonBrowseDBBaseDir.Text = "Browse...";
            this.toolTip1.SetToolTip(this.buttonBrowseDBBaseDir, "Browse to a folder where you would like to put the database");
            this.buttonBrowseDBBaseDir.UseVisualStyleBackColor = true;
            this.buttonBrowseDBBaseDir.Click += new System.EventHandler(this.buttonBrowseDBBaseDir_Click);
            // 
            // textBoxDBName
            // 
            this.textBoxDBName.Location = new System.Drawing.Point(89, 26);
            this.textBoxDBName.Name = "textBoxDBName";
            this.textBoxDBName.Size = new System.Drawing.Size(317, 20);
            this.textBoxDBName.TabIndex = 26;
            this.textBoxDBName.TextChanged += new System.EventHandler(this.textBoxDBName_TextChanged);
            this.textBoxDBName.Leave += new System.EventHandler(this.textBoxDBName_Leave);
            // 
            // listBoxPicasaDBs
            // 
            this.listBoxPicasaDBs.FormattingEnabled = true;
            this.listBoxPicasaDBs.Location = new System.Drawing.Point(23, 37);
            this.listBoxPicasaDBs.Name = "listBoxPicasaDBs";
            this.listBoxPicasaDBs.Size = new System.Drawing.Size(253, 199);
            this.listBoxPicasaDBs.TabIndex = 22;
            this.listBoxPicasaDBs.SelectedIndexChanged += new System.EventHandler(this.listBoxPicasaDBs_SelectedIndexChanged);
            // 
            // buttonRunPicasa
            // 
            this.buttonRunPicasa.Location = new System.Drawing.Point(112, 19);
            this.buttonRunPicasa.Name = "buttonRunPicasa";
            this.buttonRunPicasa.Size = new System.Drawing.Size(100, 23);
            this.buttonRunPicasa.TabIndex = 27;
            this.buttonRunPicasa.Text = "Run Picasa";
            this.toolTip1.SetToolTip(this.buttonRunPicasa, "Run Picasa using this database");
            this.buttonRunPicasa.UseVisualStyleBackColor = true;
            this.buttonRunPicasa.Click += new System.EventHandler(this.buttonRunPicasa_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(624, 321);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(101, 23);
            this.buttonClose.TabIndex = 28;
            this.buttonClose.Text = "Close";
            this.toolTip1.SetToolTip(this.buttonClose, "Save the settings and close PicasaStarter");
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonGeneralSettings
            // 
            this.buttonGeneralSettings.Location = new System.Drawing.Point(113, 320);
            this.buttonGeneralSettings.Name = "buttonGeneralSettings";
            this.buttonGeneralSettings.Size = new System.Drawing.Size(96, 23);
            this.buttonGeneralSettings.TabIndex = 29;
            this.buttonGeneralSettings.Text = "General settings";
            this.toolTip1.SetToolTip(this.buttonGeneralSettings, "Set some general settings");
            this.buttonGeneralSettings.UseVisualStyleBackColor = true;
            this.buttonGeneralSettings.Click += new System.EventHandler(this.buttonGeneralSettings_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(11, 318);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(96, 23);
            this.buttonHelp.TabIndex = 31;
            this.buttonHelp.Text = "Help";
            this.toolTip1.SetToolTip(this.buttonHelp, "Help... says it all I suppose...");
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(17, 301);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(703, 1);
            this.panel1.TabIndex = 32;
            // 
            // buttonAddDB
            // 
            this.buttonAddDB.Location = new System.Drawing.Point(22, 246);
            this.buttonAddDB.Name = "buttonAddDB";
            this.buttonAddDB.Size = new System.Drawing.Size(108, 23);
            this.buttonAddDB.TabIndex = 33;
            this.buttonAddDB.Text = "Add database";
            this.toolTip1.SetToolTip(this.buttonAddDB, "Add a new database to the list");
            this.buttonAddDB.UseVisualStyleBackColor = true;
            this.buttonAddDB.Click += new System.EventHandler(this.buttonAddDB_Click);
            // 
            // buttonRemoveDB
            // 
            this.buttonRemoveDB.Location = new System.Drawing.Point(139, 246);
            this.buttonRemoveDB.Name = "buttonRemoveDB";
            this.buttonRemoveDB.Size = new System.Drawing.Size(104, 23);
            this.buttonRemoveDB.TabIndex = 34;
            this.buttonRemoveDB.Text = "Remove database";
            this.toolTip1.SetToolTip(this.buttonRemoveDB, "Remove the selected database from the list");
            this.buttonRemoveDB.UseVisualStyleBackColor = true;
            this.buttonRemoveDB.Click += new System.EventHandler(this.buttonRemoveDB_Click);
            // 
            // textBoxDBDescription
            // 
            this.textBoxDBDescription.Location = new System.Drawing.Point(89, 52);
            this.textBoxDBDescription.Multiline = true;
            this.textBoxDBDescription.Name = "textBoxDBDescription";
            this.textBoxDBDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDBDescription.Size = new System.Drawing.Size(317, 82);
            this.textBoxDBDescription.TabIndex = 35;
            this.textBoxDBDescription.TextChanged += new System.EventHandler(this.textBoxDBDescription_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Description:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxDBFullDir
            // 
            this.textBoxDBFullDir.Location = new System.Drawing.Point(89, 166);
            this.textBoxDBFullDir.Name = "textBoxDBFullDir";
            this.textBoxDBFullDir.ReadOnly = true;
            this.textBoxDBFullDir.Size = new System.Drawing.Size(250, 20);
            this.textBoxDBFullDir.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Full directory:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonDBOpenFullDir
            // 
            this.buttonDBOpenFullDir.Location = new System.Drawing.Point(345, 164);
            this.buttonDBOpenFullDir.Name = "buttonDBOpenFullDir";
            this.buttonDBOpenFullDir.Size = new System.Drawing.Size(61, 23);
            this.buttonDBOpenFullDir.TabIndex = 39;
            this.buttonDBOpenFullDir.Text = "Explore...";
            this.toolTip1.SetToolTip(this.buttonDBOpenFullDir, "Open an explorer window on this path");
            this.buttonDBOpenFullDir.UseVisualStyleBackColor = true;
            this.buttonDBOpenFullDir.Click += new System.EventHandler(this.buttonDBOpenFullDir_Click);
            // 
            // ButtonCreateShortcut
            // 
            this.ButtonCreateShortcut.Location = new System.Drawing.Point(6, 19);
            this.ButtonCreateShortcut.Name = "ButtonCreateShortcut";
            this.ButtonCreateShortcut.Size = new System.Drawing.Size(100, 23);
            this.ButtonCreateShortcut.TabIndex = 40;
            this.ButtonCreateShortcut.Tag = "";
            this.ButtonCreateShortcut.Text = "Create Shortcut";
            this.toolTip1.SetToolTip(this.ButtonCreateShortcut, "Create a shortcut to start Picasa immediately using this database");
            this.ButtonCreateShortcut.UseVisualStyleBackColor = true;
            this.ButtonCreateShortcut.Click += new System.EventHandler(this.ButtonCreateShortcut_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 272);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Picasa Databases";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxDBName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBoxDBBaseDir);
            this.groupBox2.Controls.Add(this.buttonDBOpenFullDir);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.buttonBrowseDBBaseDir);
            this.groupBox2.Controls.Add(this.textBoxDBFullDir);
            this.groupBox2.Controls.Add(this.textBoxDBDescription);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(299, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 214);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database details";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonRunPicasa);
            this.groupBox3.Controls.Add(this.ButtonCreateShortcut);
            this.groupBox3.Location = new System.Drawing.Point(299, 231);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(420, 51);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Database actions";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 355);
            this.Controls.Add(this.listBoxPicasaDBs);
            this.Controls.Add(this.buttonRemoveDB);
            this.Controls.Add(this.buttonAddDB);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonGeneralSettings);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "PicasaStarter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxDBBaseDir;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonBrowseDBBaseDir;
        private System.Windows.Forms.TextBox textBoxDBName;
        private System.Windows.Forms.ListBox listBoxPicasaDBs;
        private System.Windows.Forms.Button buttonRunPicasa;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonGeneralSettings;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAddDB;
        private System.Windows.Forms.Button buttonRemoveDB;
        private System.Windows.Forms.TextBox textBoxDBDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDBFullDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonDBOpenFullDir;
        private System.Windows.Forms.Button ButtonCreateShortcut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

