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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelDir = new System.Windows.Forms.Label();
            this.labelNumberFiles = new System.Windows.Forms.Label();
            this.labelNumberChanged = new System.Windows.Forms.Label();
            this.labelNumberUnchanged = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 12);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(237, 23);
            this.progressBar.TabIndex = 0;
            // 
            // labelDir
            // 
            this.labelDir.AutoSize = true;
            this.labelDir.Location = new System.Drawing.Point(150, 61);
            this.labelDir.Name = "labelDir";
            this.labelDir.Size = new System.Drawing.Size(42, 13);
            this.labelDir.TabIndex = 1;
            this.labelDir.Text = "labelDir";
            // 
            // labelNumberFiles
            // 
            this.labelNumberFiles.AutoSize = true;
            this.labelNumberFiles.Location = new System.Drawing.Point(150, 83);
            this.labelNumberFiles.Name = "labelNumberFiles";
            this.labelNumberFiles.Size = new System.Drawing.Size(13, 13);
            this.labelNumberFiles.TabIndex = 2;
            this.labelNumberFiles.Text = "0";
            // 
            // labelNumberChanged
            // 
            this.labelNumberChanged.AutoSize = true;
            this.labelNumberChanged.Location = new System.Drawing.Point(150, 105);
            this.labelNumberChanged.Name = "labelNumberChanged";
            this.labelNumberChanged.Size = new System.Drawing.Size(13, 13);
            this.labelNumberChanged.TabIndex = 3;
            this.labelNumberChanged.Text = "0";
            // 
            // labelNumberUnchanged
            // 
            this.labelNumberUnchanged.AutoSize = true;
            this.labelNumberUnchanged.Location = new System.Drawing.Point(150, 128);
            this.labelNumberUnchanged.Name = "labelNumberUnchanged";
            this.labelNumberUnchanged.Size = new System.Drawing.Size(13, 13);
            this.labelNumberUnchanged.TabIndex = 4;
            this.labelNumberUnchanged.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Directory:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Number of files:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Number of files changed:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Number of files unchanged:";
            // 
            // BackupProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 156);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelNumberUnchanged);
            this.Controls.Add(this.labelNumberChanged);
            this.Controls.Add(this.labelNumberFiles);
            this.Controls.Add(this.labelDir);
            this.Controls.Add(this.progressBar);
            this.Name = "BackupProgressForm";
            this.Text = "BackupProgressForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelDir;
        private System.Windows.Forms.Label labelNumberFiles;
        private System.Windows.Forms.Label labelNumberChanged;
        private System.Windows.Forms.Label labelNumberUnchanged;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}