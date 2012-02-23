namespace PicasaStarter
{
    partial class BackupProgressForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupProgressForm));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelNumberFiles = new System.Windows.Forms.Label();
            this.labelNumberChanged = new System.Windows.Forms.Label();
            this.labelNumberUnchanged = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.labelTimeElapsed = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.labelMBDoneUnchanged = new System.Windows.Forms.Label();
            this.labelMBDoneChanged = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 24);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(559, 23);
            this.progressBar.TabIndex = 0;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(151, 70);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(61, 13);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "Initialising...";
            // 
            // labelNumberFiles
            // 
            this.labelNumberFiles.AutoSize = true;
            this.labelNumberFiles.Location = new System.Drawing.Point(151, 114);
            this.labelNumberFiles.Name = "labelNumberFiles";
            this.labelNumberFiles.Size = new System.Drawing.Size(13, 13);
            this.labelNumberFiles.TabIndex = 2;
            this.labelNumberFiles.Text = "0";
            // 
            // labelNumberChanged
            // 
            this.labelNumberChanged.AutoSize = true;
            this.labelNumberChanged.Location = new System.Drawing.Point(151, 136);
            this.labelNumberChanged.Name = "labelNumberChanged";
            this.labelNumberChanged.Size = new System.Drawing.Size(13, 13);
            this.labelNumberChanged.TabIndex = 3;
            this.labelNumberChanged.Text = "0";
            // 
            // labelNumberUnchanged
            // 
            this.labelNumberUnchanged.AutoSize = true;
            this.labelNumberUnchanged.Location = new System.Drawing.Point(151, 159);
            this.labelNumberUnchanged.Name = "labelNumberUnchanged";
            this.labelNumberUnchanged.Size = new System.Drawing.Size(13, 13);
            this.labelNumberUnchanged.TabIndex = 4;
            this.labelNumberUnchanged.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Status:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Number of files:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Number of files changed:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Number of files unchanged:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(496, 152);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Time elapsed:";
            // 
            // labelTimeElapsed
            // 
            this.labelTimeElapsed.AutoSize = true;
            this.labelTimeElapsed.Location = new System.Drawing.Point(151, 92);
            this.labelTimeElapsed.Name = "labelTimeElapsed";
            this.labelTimeElapsed.Size = new System.Drawing.Size(13, 13);
            this.labelTimeElapsed.TabIndex = 11;
            this.labelTimeElapsed.Text = "0";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // labelMBDoneUnchanged
            // 
            this.labelMBDoneUnchanged.AutoSize = true;
            this.labelMBDoneUnchanged.Location = new System.Drawing.Point(232, 159);
            this.labelMBDoneUnchanged.Name = "labelMBDoneUnchanged";
            this.labelMBDoneUnchanged.Size = new System.Drawing.Size(38, 13);
            this.labelMBDoneUnchanged.TabIndex = 13;
            this.labelMBDoneUnchanged.Text = "(0 MB)";
            // 
            // labelMBDoneChanged
            // 
            this.labelMBDoneChanged.AutoSize = true;
            this.labelMBDoneChanged.Location = new System.Drawing.Point(232, 136);
            this.labelMBDoneChanged.Name = "labelMBDoneChanged";
            this.labelMBDoneChanged.Size = new System.Drawing.Size(38, 13);
            this.labelMBDoneChanged.TabIndex = 12;
            this.labelMBDoneChanged.Text = "(0 MB)";
            // 
            // BackupProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 187);
            this.Controls.Add(this.labelMBDoneUnchanged);
            this.Controls.Add(this.labelMBDoneChanged);
            this.Controls.Add(this.labelTimeElapsed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelNumberUnchanged);
            this.Controls.Add(this.labelNumberChanged);
            this.Controls.Add(this.labelNumberFiles);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.progressBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BackupProgressForm";
            this.Text = "Backup Picasa - Progress";
            this.Load += new System.EventHandler(this.BackupProgressForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelNumberFiles;
        private System.Windows.Forms.Label labelNumberChanged;
        private System.Windows.Forms.Label labelNumberUnchanged;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelTimeElapsed;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label labelMBDoneUnchanged;
        private System.Windows.Forms.Label labelMBDoneChanged;
    }
}