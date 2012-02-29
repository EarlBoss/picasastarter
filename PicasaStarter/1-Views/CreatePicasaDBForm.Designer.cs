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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatePicasaDBForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.messageBoxDB = new System.Windows.Forms.TextBox();
            this.buttonConvert38 = new System.Windows.Forms.Button();
            this.buttonCreateNewDB = new System.Windows.Forms.Button();
            this.buttonCopyDB = new System.Windows.Forms.Button();
            this.textBoxDBName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxDBBaseDir = new System.Windows.Forms.TextBox();
            this.buttonBrowseDBBaseDir = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxDBDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EnablecheckBox = new System.Windows.Forms.CheckBox();
            this.PicDrivecomboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCreateShortcut = new System.Windows.Forms.Button();
            this.buttonBackupDir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBackupDir = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.backupgroupBox = new System.Windows.Forms.GroupBox();
            this.textLastBackupDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BackupFrequencyBox = new System.Windows.Forms.ComboBox();
            this.buttonNoBackupDir = new System.Windows.Forms.Button();
            this.VDgroupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxVDSource = new System.Windows.Forms.TextBox();
            this.buttonDoVDNow = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.backupgroupBox.SuspendLayout();
            this.VDgroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.messageBoxDB);
            this.groupBox2.Controls.Add(this.buttonConvert38);
            this.groupBox2.Controls.Add(this.buttonCreateNewDB);
            this.groupBox2.Controls.Add(this.buttonCopyDB);
            this.groupBox2.Controls.Add(this.textBoxDBName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBoxDBBaseDir);
            this.groupBox2.Controls.Add(this.buttonBrowseDBBaseDir);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBoxDBDescription);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 227);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database details";
            // 
            // messageBoxDB
            // 
            this.messageBoxDB.BackColor = System.Drawing.SystemColors.Control;
            this.messageBoxDB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageBoxDB.ForeColor = System.Drawing.Color.Blue;
            this.messageBoxDB.Location = new System.Drawing.Point(10, 167);
            this.messageBoxDB.Multiline = true;
            this.messageBoxDB.Name = "messageBoxDB";
            this.messageBoxDB.Size = new System.Drawing.Size(103, 54);
            this.messageBoxDB.TabIndex = 46;
            this.messageBoxDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonConvert38
            // 
            this.buttonConvert38.Location = new System.Drawing.Point(426, 172);
            this.buttonConvert38.Name = "buttonConvert38";
            this.buttonConvert38.Size = new System.Drawing.Size(61, 34);
            this.buttonConvert38.TabIndex = 44;
            this.buttonConvert38.Text = "Convert From 3.8";
            this.buttonConvert38.UseVisualStyleBackColor = true;
            this.buttonConvert38.Click += new System.EventHandler(this.buttonConvert38_Click);
            // 
            // buttonCreateNewDB
            // 
            this.buttonCreateNewDB.Location = new System.Drawing.Point(138, 172);
            this.buttonCreateNewDB.Name = "buttonCreateNewDB";
            this.buttonCreateNewDB.Size = new System.Drawing.Size(127, 34);
            this.buttonCreateNewDB.TabIndex = 43;
            this.buttonCreateNewDB.Text = "Create\r\nEmpty Database";
            this.buttonCreateNewDB.UseVisualStyleBackColor = true;
            this.buttonCreateNewDB.Click += new System.EventHandler(this.buttonCreateNewDB_Click);
            // 
            // buttonCopyDB
            // 
            this.buttonCopyDB.Location = new System.Drawing.Point(271, 172);
            this.buttonCopyDB.Name = "buttonCopyDB";
            this.buttonCopyDB.Size = new System.Drawing.Size(127, 34);
            this.buttonCopyDB.TabIndex = 42;
            this.buttonCopyDB.Text = "Copy an Existing Database";
            this.buttonCopyDB.UseVisualStyleBackColor = true;
            this.buttonCopyDB.Click += new System.EventHandler(this.buttonCopyDB_Click);
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
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Database Path:";
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
            // buttonBrowseDBBaseDir
            // 
            this.buttonBrowseDBBaseDir.Location = new System.Drawing.Point(493, 140);
            this.buttonBrowseDBBaseDir.Name = "buttonBrowseDBBaseDir";
            this.buttonBrowseDBBaseDir.Size = new System.Drawing.Size(61, 23);
            this.buttonBrowseDBBaseDir.TabIndex = 5;
            this.buttonBrowseDBBaseDir.Text = "Browse...";
            this.buttonBrowseDBBaseDir.UseVisualStyleBackColor = true;
            this.buttonBrowseDBBaseDir.Click += new System.EventHandler(this.buttonBrowseDBBaseDir_Click);
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
            // textBoxDBDescription
            // 
            this.textBoxDBDescription.Location = new System.Drawing.Point(116, 52);
            this.textBoxDBDescription.Multiline = true;
            this.textBoxDBDescription.Name = "textBoxDBDescription";
            this.textBoxDBDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDBDescription.Size = new System.Drawing.Size(438, 72);
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
            // EnablecheckBox
            // 
            this.EnablecheckBox.AutoSize = true;
            this.EnablecheckBox.Location = new System.Drawing.Point(187, 23);
            this.EnablecheckBox.Name = "EnablecheckBox";
            this.EnablecheckBox.Size = new System.Drawing.Size(275, 30);
            this.EnablecheckBox.TabIndex = 47;
            this.EnablecheckBox.Text = "If This Drive Is Missing, Allow PicasaStarter to Map\r\nthe Virtual Drive Source Di" +
    "rectory to this Drive Letter.\r\n";
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
            this.PicDrivecomboBox.Location = new System.Drawing.Point(128, 28);
            this.PicDrivecomboBox.Name = "PicDrivecomboBox";
            this.PicDrivecomboBox.Size = new System.Drawing.Size(39, 21);
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
            this.buttonCreateShortcut.Location = new System.Drawing.Point(21, 458);
            this.buttonCreateShortcut.Name = "buttonCreateShortcut";
            this.buttonCreateShortcut.Size = new System.Drawing.Size(133, 23);
            this.buttonCreateShortcut.TabIndex = 43;
            this.buttonCreateShortcut.Text = "Create shortcut";
            this.buttonCreateShortcut.UseVisualStyleBackColor = true;
            this.buttonCreateShortcut.Click += new System.EventHandler(this.buttonCreateShortcut_Click);
            // 
            // buttonBackupDir
            // 
            this.buttonBackupDir.Location = new System.Drawing.Point(493, 19);
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
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Backup directory:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxBackupDir
            // 
            this.textBoxBackupDir.Location = new System.Drawing.Point(116, 20);
            this.textBoxBackupDir.Name = "textBoxBackupDir";
            this.textBoxBackupDir.ReadOnly = true;
            this.textBoxBackupDir.Size = new System.Drawing.Size(371, 20);
            this.textBoxBackupDir.TabIndex = 40;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(491, 472);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 46;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(410, 472);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 47;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // backupgroupBox
            // 
            this.backupgroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.backupgroupBox.Controls.Add(this.textLastBackupDate);
            this.backupgroupBox.Controls.Add(this.label6);
            this.backupgroupBox.Controls.Add(this.label5);
            this.backupgroupBox.Controls.Add(this.BackupFrequencyBox);
            this.backupgroupBox.Controls.Add(this.buttonNoBackupDir);
            this.backupgroupBox.Controls.Add(this.textBoxBackupDir);
            this.backupgroupBox.Controls.Add(this.buttonBackupDir);
            this.backupgroupBox.Controls.Add(this.label1);
            this.backupgroupBox.Location = new System.Drawing.Point(13, 245);
            this.backupgroupBox.Name = "backupgroupBox";
            this.backupgroupBox.Size = new System.Drawing.Size(559, 106);
            this.backupgroupBox.TabIndex = 48;
            this.backupgroupBox.TabStop = false;
            this.backupgroupBox.Text = "Backup Settings";
            // 
            // textLastBackupDate
            // 
            this.textLastBackupDate.BackColor = System.Drawing.SystemColors.Control;
            this.textLastBackupDate.Location = new System.Drawing.Point(278, 45);
            this.textLastBackupDate.Name = "textLastBackupDate";
            this.textLastBackupDate.ReadOnly = true;
            this.textLastBackupDate.Size = new System.Drawing.Size(154, 20);
            this.textLastBackupDate.TabIndex = 47;
            this.textLastBackupDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(172, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Last Backed up on:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Backup Reminder:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BackupFrequencyBox
            // 
            this.BackupFrequencyBox.FormattingEnabled = true;
            this.BackupFrequencyBox.Items.AddRange(new object[] {
            "Always Remind",
            "Remind if Older Than One Day",
            "Remind if Older Than One Week",
            "Remind if Older Than One Month",
            "Never Remind"});
            this.BackupFrequencyBox.Location = new System.Drawing.Point(116, 77);
            this.BackupFrequencyBox.Name = "BackupFrequencyBox";
            this.BackupFrequencyBox.Size = new System.Drawing.Size(192, 21);
            this.BackupFrequencyBox.TabIndex = 44;
            this.BackupFrequencyBox.Text = "Backup Reminder Interval";
            // 
            // buttonNoBackupDir
            // 
            this.buttonNoBackupDir.Location = new System.Drawing.Point(493, 48);
            this.buttonNoBackupDir.Name = "buttonNoBackupDir";
            this.buttonNoBackupDir.Size = new System.Drawing.Size(61, 23);
            this.buttonNoBackupDir.TabIndex = 43;
            this.buttonNoBackupDir.Text = "None";
            this.buttonNoBackupDir.UseVisualStyleBackColor = true;
            this.buttonNoBackupDir.Click += new System.EventHandler(this.buttonNoBackupDir_Click);
            // 
            // VDgroupBox1
            // 
            this.VDgroupBox1.Controls.Add(this.label3);
            this.VDgroupBox1.Controls.Add(this.textBoxVDSource);
            this.VDgroupBox1.Controls.Add(this.buttonDoVDNow);
            this.VDgroupBox1.Controls.Add(this.label4);
            this.VDgroupBox1.Controls.Add(this.PicDrivecomboBox);
            this.VDgroupBox1.Controls.Add(this.EnablecheckBox);
            this.VDgroupBox1.Location = new System.Drawing.Point(13, 357);
            this.VDgroupBox1.Name = "VDgroupBox1";
            this.VDgroupBox1.Size = new System.Drawing.Size(560, 95);
            this.VDgroupBox1.TabIndex = 49;
            this.VDgroupBox1.TabStop = false;
            this.VDgroupBox1.Text = "Map Virtual Picture Drive";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Virtual Drive Source:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxVDSource
            // 
            this.textBoxVDSource.Location = new System.Drawing.Point(118, 65);
            this.textBoxVDSource.Name = "textBoxVDSource";
            this.textBoxVDSource.ReadOnly = true;
            this.textBoxVDSource.Size = new System.Drawing.Size(435, 20);
            this.textBoxVDSource.TabIndex = 49;
            // 
            // buttonDoVDNow
            // 
            this.buttonDoVDNow.Location = new System.Drawing.Point(479, 19);
            this.buttonDoVDNow.Name = "buttonDoVDNow";
            this.buttonDoVDNow.Size = new System.Drawing.Size(75, 36);
            this.buttonDoVDNow.TabIndex = 48;
            this.buttonDoVDNow.Text = "Map Drive Now!";
            this.buttonDoVDNow.UseVisualStyleBackColor = true;
            this.buttonDoVDNow.Click += new System.EventHandler(this.buttonDoVDNow_Click);
            // 
            // CreatePicasaDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(584, 503);
            this.Controls.Add(this.VDgroupBox1);
            this.Controls.Add(this.backupgroupBox);
            this.Controls.Add(this.buttonCreateShortcut);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreatePicasaDBForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Picasa Database Configuration";
            this.Load += new System.EventHandler(this.CreatePicasaDBForm_Load);
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonBrowseDBBaseDir;
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
        private System.Windows.Forms.Button buttonDoVDNow;
        private System.Windows.Forms.TextBox messageBoxDB;
        private System.Windows.Forms.Button buttonConvert38;
        private System.Windows.Forms.Button buttonCreateNewDB;
        private System.Windows.Forms.Button buttonCopyDB;
        private System.Windows.Forms.Button buttonNoBackupDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxVDSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox BackupFrequencyBox;
        private System.Windows.Forms.TextBox textLastBackupDate;
        private System.Windows.Forms.Label label6;
    }
}