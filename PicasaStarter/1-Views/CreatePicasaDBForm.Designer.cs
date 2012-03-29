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
            this.btnTakeoverBackup = new System.Windows.Forms.Button();
            this.textBoxBackupName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textLastBackupDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BackupFrequencyBox = new System.Windows.Forms.ComboBox();
            this.buttonNoBackupDir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxVDSource = new System.Windows.Forms.TextBox();
            this.buttonDoVDNow = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.CheckBackupDBOnly = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // messageBoxDB
            // 
            this.messageBoxDB.BackColor = System.Drawing.SystemColors.Window;
            this.messageBoxDB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageBoxDB.ForeColor = System.Drawing.Color.Blue;
            this.messageBoxDB.Location = new System.Drawing.Point(12, 173);
            this.messageBoxDB.Multiline = true;
            this.messageBoxDB.Name = "messageBoxDB";
            this.messageBoxDB.Size = new System.Drawing.Size(116, 68);
            this.messageBoxDB.TabIndex = 46;
            this.messageBoxDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonConvert38
            // 
            this.buttonConvert38.Location = new System.Drawing.Point(437, 182);
            this.buttonConvert38.Name = "buttonConvert38";
            this.buttonConvert38.Size = new System.Drawing.Size(104, 34);
            this.buttonConvert38.TabIndex = 44;
            this.buttonConvert38.Text = "Convert 3.8 Database";
            this.buttonConvert38.UseVisualStyleBackColor = true;
            this.buttonConvert38.Click += new System.EventHandler(this.buttonConvert38_Click);
            // 
            // buttonCreateNewDB
            // 
            this.buttonCreateNewDB.Location = new System.Drawing.Point(134, 182);
            this.buttonCreateNewDB.Name = "buttonCreateNewDB";
            this.buttonCreateNewDB.Size = new System.Drawing.Size(128, 34);
            this.buttonCreateNewDB.TabIndex = 43;
            this.buttonCreateNewDB.Text = "Create\r\nEmpty Database";
            this.buttonCreateNewDB.UseVisualStyleBackColor = true;
            this.buttonCreateNewDB.Click += new System.EventHandler(this.buttonCreateNewDB_Click);
            // 
            // buttonCopyDB
            // 
            this.buttonCopyDB.Location = new System.Drawing.Point(287, 182);
            this.buttonCopyDB.Name = "buttonCopyDB";
            this.buttonCopyDB.Size = new System.Drawing.Size(128, 34);
            this.buttonCopyDB.TabIndex = 42;
            this.buttonCopyDB.Text = "Copy an Existing Database";
            this.buttonCopyDB.UseVisualStyleBackColor = true;
            this.buttonCopyDB.Click += new System.EventHandler(this.buttonCopyDB_Click);
            // 
            // textBoxDBName
            // 
            this.textBoxDBName.Location = new System.Drawing.Point(99, 10);
            this.textBoxDBName.Name = "textBoxDBName";
            this.textBoxDBName.Size = new System.Drawing.Size(248, 20);
            this.textBoxDBName.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Database Path:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxDBBaseDir
            // 
            this.textBoxDBBaseDir.Location = new System.Drawing.Point(99, 121);
            this.textBoxDBBaseDir.Name = "textBoxDBBaseDir";
            this.textBoxDBBaseDir.ReadOnly = true;
            this.textBoxDBBaseDir.Size = new System.Drawing.Size(375, 20);
            this.textBoxDBBaseDir.TabIndex = 23;
            this.textBoxDBBaseDir.TextChanged += new System.EventHandler(this.textBoxDBBaseDir_TextChanged);
            // 
            // buttonBrowseDBBaseDir
            // 
            this.buttonBrowseDBBaseDir.Location = new System.Drawing.Point(480, 119);
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
            this.label8.Location = new System.Drawing.Point(6, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Name:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxDBDescription
            // 
            this.textBoxDBDescription.Location = new System.Drawing.Point(99, 36);
            this.textBoxDBDescription.Multiline = true;
            this.textBoxDBDescription.Name = "textBoxDBDescription";
            this.textBoxDBDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDBDescription.Size = new System.Drawing.Size(442, 72);
            this.textBoxDBDescription.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Description:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // EnablecheckBox
            // 
            this.EnablecheckBox.AutoSize = true;
            this.EnablecheckBox.Location = new System.Drawing.Point(37, 95);
            this.EnablecheckBox.Name = "EnablecheckBox";
            this.EnablecheckBox.Size = new System.Drawing.Size(397, 17);
            this.EnablecheckBox.TabIndex = 47;
            this.EnablecheckBox.Text = "If this drive is missing, allow PicasaStarter to map the virtual drive automatica" +
                "lly.\r\n";
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
            this.PicDrivecomboBox.Location = new System.Drawing.Point(241, 66);
            this.PicDrivecomboBox.Name = "PicDrivecomboBox";
            this.PicDrivecomboBox.Size = new System.Drawing.Size(39, 21);
            this.PicDrivecomboBox.TabIndex = 46;
            this.PicDrivecomboBox.SelectedIndexChanged += new System.EventHandler(this.PicDrivecomboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Map virtual drive source to this drive letter:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonCreateShortcut
            // 
            this.buttonCreateShortcut.Location = new System.Drawing.Point(12, 333);
            this.buttonCreateShortcut.Name = "buttonCreateShortcut";
            this.buttonCreateShortcut.Size = new System.Drawing.Size(122, 23);
            this.buttonCreateShortcut.TabIndex = 43;
            this.buttonCreateShortcut.Text = "Create shortcut";
            this.buttonCreateShortcut.UseVisualStyleBackColor = true;
            this.buttonCreateShortcut.Click += new System.EventHandler(this.buttonCreateShortcut_Click);
            // 
            // buttonBackupDir
            // 
            this.buttonBackupDir.Location = new System.Drawing.Point(402, 163);
            this.buttonBackupDir.Name = "buttonBackupDir";
            this.buttonBackupDir.Size = new System.Drawing.Size(68, 24);
            this.buttonBackupDir.TabIndex = 42;
            this.buttonBackupDir.Text = "Browse...";
            this.buttonBackupDir.UseVisualStyleBackColor = true;
            this.buttonBackupDir.Click += new System.EventHandler(this.buttonBackupDir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Backup Directory";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxBackupDir
            // 
            this.textBoxBackupDir.Location = new System.Drawing.Point(9, 166);
            this.textBoxBackupDir.Name = "textBoxBackupDir";
            this.textBoxBackupDir.ReadOnly = true;
            this.textBoxBackupDir.Size = new System.Drawing.Size(387, 20);
            this.textBoxBackupDir.TabIndex = 40;
            this.textBoxBackupDir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(503, 333);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 46;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(422, 333);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 47;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // btnTakeoverBackup
            // 
            this.btnTakeoverBackup.Location = new System.Drawing.Point(9, 91);
            this.btnTakeoverBackup.Name = "btnTakeoverBackup";
            this.btnTakeoverBackup.Size = new System.Drawing.Size(135, 22);
            this.btnTakeoverBackup.TabIndex = 50;
            this.btnTakeoverBackup.Text = "Take Over Backup Task";
            this.btnTakeoverBackup.UseVisualStyleBackColor = true;
            this.btnTakeoverBackup.Click += new System.EventHandler(this.btnTakeoverBackup_Click);
            // 
            // textBoxBackupName
            // 
            this.textBoxBackupName.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxBackupName.Location = new System.Drawing.Point(118, 15);
            this.textBoxBackupName.Name = "textBoxBackupName";
            this.textBoxBackupName.ReadOnly = true;
            this.textBoxBackupName.Size = new System.Drawing.Size(155, 20);
            this.textBoxBackupName.TabIndex = 49;
            this.textBoxBackupName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "Backup Computer:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textLastBackupDate
            // 
            this.textLastBackupDate.BackColor = System.Drawing.SystemColors.Control;
            this.textLastBackupDate.Location = new System.Drawing.Point(118, 43);
            this.textLastBackupDate.Name = "textLastBackupDate";
            this.textLastBackupDate.ReadOnly = true;
            this.textLastBackupDate.Size = new System.Drawing.Size(155, 20);
            this.textLastBackupDate.TabIndex = 47;
            this.textLastBackupDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Last Backup Date:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Backup reminder:";
            // 
            // BackupFrequencyBox
            // 
            this.BackupFrequencyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BackupFrequencyBox.FormattingEnabled = true;
            this.BackupFrequencyBox.Items.AddRange(new object[] {
            "Always Remind",
            "Remind Every Day",
            "Remind if Older Than One Week",
            "Remind if Older Than One Month",
            "Never Remind"});
            this.BackupFrequencyBox.Location = new System.Drawing.Point(118, 69);
            this.BackupFrequencyBox.Name = "BackupFrequencyBox";
            this.BackupFrequencyBox.Size = new System.Drawing.Size(155, 21);
            this.BackupFrequencyBox.TabIndex = 44;
            // 
            // buttonNoBackupDir
            // 
            this.buttonNoBackupDir.Location = new System.Drawing.Point(476, 163);
            this.buttonNoBackupDir.Name = "buttonNoBackupDir";
            this.buttonNoBackupDir.Size = new System.Drawing.Size(68, 24);
            this.buttonNoBackupDir.TabIndex = 43;
            this.buttonNoBackupDir.Text = "None";
            this.buttonNoBackupDir.UseVisualStyleBackColor = true;
            this.buttonNoBackupDir.Click += new System.EventHandler(this.buttonNoBackupDir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Virtual Drive Source:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxVDSource
            // 
            this.textBoxVDSource.Location = new System.Drawing.Point(13, 36);
            this.textBoxVDSource.Name = "textBoxVDSource";
            this.textBoxVDSource.ReadOnly = true;
            this.textBoxVDSource.Size = new System.Drawing.Size(531, 20);
            this.textBoxVDSource.TabIndex = 49;
            // 
            // buttonDoVDNow
            // 
            this.buttonDoVDNow.Location = new System.Drawing.Point(16, 127);
            this.buttonDoVDNow.Name = "buttonDoVDNow";
            this.buttonDoVDNow.Size = new System.Drawing.Size(114, 23);
            this.buttonDoVDNow.TabIndex = 48;
            this.buttonDoVDNow.Text = "Map Drive Now!";
            this.buttonDoVDNow.UseVisualStyleBackColor = true;
            this.buttonDoVDNow.Click += new System.EventHandler(this.buttonDoVDNow_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(20, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(565, 306);
            this.tabControl1.TabIndex = 50;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.messageBoxDB);
            this.tabPage1.Controls.Add(this.textBoxDBDescription);
            this.tabPage1.Controls.Add(this.buttonConvert38);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.buttonCreateNewDB);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.buttonCopyDB);
            this.tabPage1.Controls.Add(this.textBoxDBName);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.textBoxDBBaseDir);
            this.tabPage1.Controls.Add(this.buttonBrowseDBBaseDir);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(557, 280);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Database ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(117, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(321, 26);
            this.label10.TabIndex = 47;
            this.label10.Text = "NOTE: If Database Path will be on a Virtual Drive, please go to the\r\n            " +
                "Virtual Drive tab and configure the Virtual Drive first.";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.EnablecheckBox);
            this.tabPage3.Controls.Add(this.textBoxVDSource);
            this.tabPage3.Controls.Add(this.PicDrivecomboBox);
            this.tabPage3.Controls.Add(this.buttonDoVDNow);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(557, 280);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Virtual Drive";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 213);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(263, 52);
            this.label11.TabIndex = 51;
            this.label11.Text = "NOTE:\r\nThe Virtual Drive Source is the folder containing\r\nthe PicasaStarter setti" +
                "ngs folder and the Picture folder.\r\n\r\n";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.CheckBackupDBOnly);
            this.tabPage2.Controls.Add(this.textLastBackupDate);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.textBoxBackupDir);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.textBoxBackupName);
            this.tabPage2.Controls.Add(this.BackupFrequencyBox);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.buttonBackupDir);
            this.tabPage2.Controls.Add(this.buttonNoBackupDir);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(557, 280);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Backup";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.btnTakeoverBackup);
            this.groupBox1.Location = new System.Drawing.Point(288, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 128);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change Backup Task Owner:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(248, 65);
            this.label12.TabIndex = 51;
            this.label12.Text = resources.GetString("label12.Text");
            // 
            // CheckBackupDBOnly
            // 
            this.CheckBackupDBOnly.AutoSize = true;
            this.CheckBackupDBOnly.Location = new System.Drawing.Point(9, 192);
            this.CheckBackupDBOnly.Name = "CheckBackupDBOnly";
            this.CheckBackupDBOnly.Size = new System.Drawing.Size(141, 17);
            this.CheckBackupDBOnly.TabIndex = 51;
            this.CheckBackupDBOnly.Text = "Back Up Database Only";
            this.CheckBackupDBOnly.UseVisualStyleBackColor = true;
            // 
            // CreatePicasaDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(590, 368);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonCreateShortcut);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreatePicasaDBForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Picasa Database Configuration";
            this.Load += new System.EventHandler(this.CreatePicasaDBForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.Button buttonDoVDNow;
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
        private System.Windows.Forms.TextBox messageBoxDB;
        private System.Windows.Forms.Button btnTakeoverBackup;
        private System.Windows.Forms.TextBox textBoxBackupName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox CheckBackupDBOnly;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
    }
}