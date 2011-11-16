namespace PicasaStarter
{
    partial class CreatePicasaDBForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EnablecheckBox = new System.Windows.Forms.CheckBox();
            this.PicDrivecomboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCreateShortcut = new System.Windows.Forms.Button();
            this.buttonBackupDir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBackupDir = new System.Windows.Forms.TextBox();
            this.textBoxDBName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxDBBaseDir = new System.Windows.Forms.TextBox();
            this.buttonDBOpenFullDir = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonBrowseDBBaseDir = new System.Windows.Forms.Button();
            this.textBoxDBFullDir = new System.Windows.Forms.TextBox();
            this.textBoxDBDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.backupgroupBox = new System.Windows.Forms.GroupBox();
            this.VDgroupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.backupgroupBox.SuspendLayout();
            this.VDgroupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 205);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database details";
            // 
            // EnablecheckBox
            // 
            this.EnablecheckBox.AutoSize = true;
            this.EnablecheckBox.Location = new System.Drawing.Point(205, 23);
            this.EnablecheckBox.Name = "EnablecheckBox";
            this.EnablecheckBox.Size = new System.Drawing.Size(319, 30);
            this.EnablecheckBox.TabIndex = 47;
            this.EnablecheckBox.Text = "If This Drive Is Missing, Allow PicasaStarter to Map the Picture\r\nFolder Storage " +
                "Path to This Drive as a Virtual Drive.\r\n";
            this.EnablecheckBox.UseVisualStyleBackColor = true;
            this.EnablecheckBox.CheckedChanged += new System.EventHandler(this.EnablecheckBox_CheckedChanged);
            // 
            // PicDrivecomboBox
            // 
            this.PicDrivecomboBox.FormattingEnabled = true;
            this.PicDrivecomboBox.Items.AddRange(new object[] {
            "D:",
            "E:",
            "F:",
            "G:",
            "H:",
            "I:",
            "J:",
            "K:",
            "L:",
            "M:",
            "N:",
            "O:",
            "P:",
            "Q:",
            "R:",
            "S:",
            "T:",
            "U:",
            "V:",
            "W:",
            "X:",
            "Y:",
            "Z:"});
            this.PicDrivecomboBox.Location = new System.Drawing.Point(137, 28);
            this.PicDrivecomboBox.Name = "PicDrivecomboBox";
            this.PicDrivecomboBox.Size = new System.Drawing.Size(50, 21);
            this.PicDrivecomboBox.TabIndex = 46;
            this.PicDrivecomboBox.SelectedIndexChanged += new System.EventHandler(this.PicDrivecomboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 26);
            this.label4.TabIndex = 45;
            this.label4.Text = "Database Will Expect\r\nPictures On This Drive:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonCreateShortcut
            // 
            this.buttonCreateShortcut.Location = new System.Drawing.Point(21, 415);
            this.buttonCreateShortcut.Name = "buttonCreateShortcut";
            this.buttonCreateShortcut.Size = new System.Drawing.Size(133, 23);
            this.buttonCreateShortcut.TabIndex = 43;
            this.buttonCreateShortcut.Text = "Create shortcut";
            this.buttonCreateShortcut.UseVisualStyleBackColor = true;
            this.buttonCreateShortcut.Click += new System.EventHandler(this.buttonCreateShortcut_Click);
            // 
            // buttonBackupDir
            // 
            this.buttonBackupDir.Location = new System.Drawing.Point(493, 28);
            this.buttonBackupDir.Name = "buttonBackupDir";
            this.buttonBackupDir.Size = new System.Drawing.Size(61, 23);
            this.buttonBackupDir.TabIndex = 42;
            this.buttonBackupDir.Text = "Browse...";
            this.buttonBackupDir.UseVisualStyleBackColor = true;
            this.buttonBackupDir.Click += new System.EventHandler(this.buttonBackupDir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Backup directory:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxBackupDir
            // 
            this.textBoxBackupDir.Location = new System.Drawing.Point(116, 29);
            this.textBoxBackupDir.Name = "textBoxBackupDir";
            this.textBoxBackupDir.ReadOnly = true;
            this.textBoxBackupDir.Size = new System.Drawing.Size(371, 20);
            this.textBoxBackupDir.TabIndex = 40;
            // 
            // textBoxDBName
            // 
            this.textBoxDBName.Location = new System.Drawing.Point(116, 26);
            this.textBoxDBName.Name = "textBoxDBName";
            this.textBoxDBName.Size = new System.Drawing.Size(248, 20);
            this.textBoxDBName.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Base directory:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxDBBaseDir
            // 
            this.textBoxDBBaseDir.Location = new System.Drawing.Point(116, 140);
            this.textBoxDBBaseDir.Name = "textBoxDBBaseDir";
            this.textBoxDBBaseDir.ReadOnly = true;
            this.textBoxDBBaseDir.Size = new System.Drawing.Size(371, 20);
            this.textBoxDBBaseDir.TabIndex = 23;
            this.textBoxDBBaseDir.TextChanged += new System.EventHandler(this.textBoxDBBaseDir_TextChanged);
            // 
            // buttonDBOpenFullDir
            // 
            this.buttonDBOpenFullDir.Location = new System.Drawing.Point(493, 165);
            this.buttonDBOpenFullDir.Name = "buttonDBOpenFullDir";
            this.buttonDBOpenFullDir.Size = new System.Drawing.Size(61, 23);
            this.buttonDBOpenFullDir.TabIndex = 39;
            this.buttonDBOpenFullDir.Text = "Explore...";
            this.buttonDBOpenFullDir.UseVisualStyleBackColor = true;
            this.buttonDBOpenFullDir.Click += new System.EventHandler(this.buttonDBOpenFullDir_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Name:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // buttonBrowseDBBaseDir
            // 
            this.buttonBrowseDBBaseDir.Location = new System.Drawing.Point(493, 137);
            this.buttonBrowseDBBaseDir.Name = "buttonBrowseDBBaseDir";
            this.buttonBrowseDBBaseDir.Size = new System.Drawing.Size(61, 23);
            this.buttonBrowseDBBaseDir.TabIndex = 5;
            this.buttonBrowseDBBaseDir.Text = "Browse...";
            this.buttonBrowseDBBaseDir.UseVisualStyleBackColor = true;
            this.buttonBrowseDBBaseDir.Click += new System.EventHandler(this.buttonBrowseDBBaseDir_Click);
            // 
            // textBoxDBFullDir
            // 
            this.textBoxDBFullDir.Location = new System.Drawing.Point(116, 166);
            this.textBoxDBFullDir.Name = "textBoxDBFullDir";
            this.textBoxDBFullDir.ReadOnly = true;
            this.textBoxDBFullDir.Size = new System.Drawing.Size(371, 20);
            this.textBoxDBFullDir.TabIndex = 37;
            // 
            // textBoxDBDescription
            // 
            this.textBoxDBDescription.Location = new System.Drawing.Point(116, 52);
            this.textBoxDBDescription.Multiline = true;
            this.textBoxDBDescription.Name = "textBoxDBDescription";
            this.textBoxDBDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDBDescription.Size = new System.Drawing.Size(438, 82);
            this.textBoxDBDescription.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Description:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(491, 429);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 46;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(410, 429);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 47;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // backupgroupBox
            // 
            this.backupgroupBox.Controls.Add(this.textBoxBackupDir);
            this.backupgroupBox.Controls.Add(this.buttonBackupDir);
            this.backupgroupBox.Controls.Add(this.label1);
            this.backupgroupBox.Location = new System.Drawing.Point(12, 226);
            this.backupgroupBox.Name = "backupgroupBox";
            this.backupgroupBox.Size = new System.Drawing.Size(559, 104);
            this.backupgroupBox.TabIndex = 48;
            this.backupgroupBox.TabStop = false;
            this.backupgroupBox.Text = "Backup && Restore";
            // 
            // VDgroupBox1
            // 
            this.VDgroupBox1.Controls.Add(this.label4);
            this.VDgroupBox1.Controls.Add(this.PicDrivecomboBox);
            this.VDgroupBox1.Controls.Add(this.EnablecheckBox);
            this.VDgroupBox1.Location = new System.Drawing.Point(12, 336);
            this.VDgroupBox1.Name = "VDgroupBox1";
            this.VDgroupBox1.Size = new System.Drawing.Size(554, 64);
            this.VDgroupBox1.TabIndex = 49;
            this.VDgroupBox1.TabStop = false;
            this.VDgroupBox1.Text = "Map Virtual Picture Drive";
            // 
            // CreatePicasaDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 459);
            this.Controls.Add(this.VDgroupBox1);
            this.Controls.Add(this.backupgroupBox);
            this.Controls.Add(this.buttonCreateShortcut);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox2);
            this.Name = "CreatePicasaDBForm";
            this.Text = "CreatePicasaDatabase";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.backupgroupBox.ResumeLayout(false);
            this.backupgroupBox.PerformLayout();
            this.VDgroupBox1.ResumeLayout(false);
            this.VDgroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonBackupDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBackupDir;
        private System.Windows.Forms.TextBox textBoxDBName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxDBBaseDir;
        private System.Windows.Forms.Button buttonDBOpenFullDir;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonBrowseDBBaseDir;
        private System.Windows.Forms.TextBox textBoxDBFullDir;
        private System.Windows.Forms.TextBox textBoxDBDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCreateShortcut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox PicDrivecomboBox;
        private System.Windows.Forms.CheckBox EnablecheckBox;
        private System.Windows.Forms.GroupBox backupgroupBox;
        private System.Windows.Forms.GroupBox VDgroupBox1;
    }
}