namespace PicasaStarter
{
    partial class BackupProgressForm_CL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupProgressForm_CL));
            this.labelMBDoneUnchanged = new System.Windows.Forms.Label();
            this.labelMBDoneChanged = new System.Windows.Forms.Label();
            this.labelTimeElapsed = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNumberUnchanged = new System.Windows.Forms.Label();
            this.labelNumberChanged = new System.Windows.Forms.Label();
            this.labelNumberFiles = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelMBDoneUnchanged
            // 
            this.labelMBDoneUnchanged.AutoSize = true;
            this.labelMBDoneUnchanged.Location = new System.Drawing.Point(241, 160);
            this.labelMBDoneUnchanged.Name = "labelMBDoneUnchanged";
            this.labelMBDoneUnchanged.Size = new System.Drawing.Size(38, 13);
            this.labelMBDoneUnchanged.TabIndex = 27;
            this.labelMBDoneUnchanged.Text = "(0 MB)";
            // 
            // labelMBDoneChanged
            // 
            this.labelMBDoneChanged.AutoSize = true;
            this.labelMBDoneChanged.Location = new System.Drawing.Point(241, 137);
            this.labelMBDoneChanged.Name = "labelMBDoneChanged";
            this.labelMBDoneChanged.Size = new System.Drawing.Size(38, 13);
            this.labelMBDoneChanged.TabIndex = 26;
            this.labelMBDoneChanged.Text = "(0 MB)";
            // 
            // labelTimeElapsed
            // 
            this.labelTimeElapsed.AutoSize = true;
            this.labelTimeElapsed.Location = new System.Drawing.Point(160, 93);
            this.labelTimeElapsed.Name = "labelTimeElapsed";
            this.labelTimeElapsed.Size = new System.Drawing.Size(13, 13);
            this.labelTimeElapsed.TabIndex = 25;
            this.labelTimeElapsed.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Time elapsed:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(505, 153);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 23;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Number of files unchanged:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Number of files changed:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Number of files:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Status:";
            // 
            // labelNumberUnchanged
            // 
            this.labelNumberUnchanged.AutoSize = true;
            this.labelNumberUnchanged.Location = new System.Drawing.Point(160, 160);
            this.labelNumberUnchanged.Name = "labelNumberUnchanged";
            this.labelNumberUnchanged.Size = new System.Drawing.Size(13, 13);
            this.labelNumberUnchanged.TabIndex = 18;
            this.labelNumberUnchanged.Text = "0";
            // 
            // labelNumberChanged
            // 
            this.labelNumberChanged.AutoSize = true;
            this.labelNumberChanged.Location = new System.Drawing.Point(160, 137);
            this.labelNumberChanged.Name = "labelNumberChanged";
            this.labelNumberChanged.Size = new System.Drawing.Size(13, 13);
            this.labelNumberChanged.TabIndex = 17;
            this.labelNumberChanged.Text = "0";
            // 
            // labelNumberFiles
            // 
            this.labelNumberFiles.AutoSize = true;
            this.labelNumberFiles.Location = new System.Drawing.Point(160, 115);
            this.labelNumberFiles.Name = "labelNumberFiles";
            this.labelNumberFiles.Size = new System.Drawing.Size(13, 13);
            this.labelNumberFiles.TabIndex = 16;
            this.labelNumberFiles.Text = "0";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(160, 71);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(61, 13);
            this.labelStatus.TabIndex = 15;
            this.labelStatus.Text = "Initialising...";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(21, 25);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(559, 23);
            this.progressBar.TabIndex = 14;
            // 
            // BackupProgressForm_CL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 201);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BackupProgressForm_CL";
            this.Text = "Backup Picasa  - Progress";
            this.Load += new System.EventHandler(this.BackupProgressForm_CL_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMBDoneUnchanged;
        private System.Windows.Forms.Label labelMBDoneChanged;
        private System.Windows.Forms.Label labelTimeElapsed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNumberUnchanged;
        private System.Windows.Forms.Label labelNumberChanged;
        private System.Windows.Forms.Label labelNumberFiles;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer timer;
    }
}