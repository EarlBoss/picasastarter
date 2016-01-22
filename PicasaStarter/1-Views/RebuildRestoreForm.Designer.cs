namespace PicasaStarter
{
    partial class RebuildRestoreForm
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
            this.OkButton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.RestoreButton = new System.Windows.Forms.Button();
            this.RebuildMinButton = new System.Windows.Forms.Button();
            this.RebuildTotalButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(296, 220);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(69, 32);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelbutton.Location = new System.Drawing.Point(371, 220);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(69, 32);
            this.Cancelbutton.TabIndex = 1;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // RestoreButton
            // 
            this.RestoreButton.Location = new System.Drawing.Point(20, 26);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(98, 36);
            this.RestoreButton.TabIndex = 2;
            this.RestoreButton.Text = "Restore From Backup";
            this.RestoreButton.UseVisualStyleBackColor = true;
            this.RestoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
            // 
            // RebuildMinButton
            // 
            this.RebuildMinButton.Location = new System.Drawing.Point(20, 81);
            this.RebuildMinButton.Name = "RebuildMinButton";
            this.RebuildMinButton.Size = new System.Drawing.Size(98, 36);
            this.RebuildMinButton.TabIndex = 3;
            this.RebuildMinButton.Text = "Minimum \r\nRebuild";
            this.RebuildMinButton.UseVisualStyleBackColor = true;
            this.RebuildMinButton.Click += new System.EventHandler(this.RebuildMinButton_Click);
            // 
            // RebuildTotalButton
            // 
            this.RebuildTotalButton.Location = new System.Drawing.Point(20, 133);
            this.RebuildTotalButton.Name = "RebuildTotalButton";
            this.RebuildTotalButton.Size = new System.Drawing.Size(98, 36);
            this.RebuildTotalButton.TabIndex = 4;
            this.RebuildTotalButton.Text = "Total\r\nRebuild";
            this.RebuildTotalButton.UseVisualStyleBackColor = true;
            this.RebuildTotalButton.Click += new System.EventHandler(this.RebuildTotalButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Remove Existing Database and replace it with a Database\r\nselected from backups.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Set up Picasa to Rebuild the Database while retaining \r\nthe Watched Folders List " +
                "and the Contacts List.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Delete all records in the database so Picasa\r\nWill do a complete rebuild.";
            // 
            // RebuildRestoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancelbutton;
            this.ClientSize = new System.Drawing.Size(476, 269);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RebuildTotalButton);
            this.Controls.Add(this.RebuildMinButton);
            this.Controls.Add(this.RestoreButton);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.OkButton);
            this.Name = "RebuildRestoreForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rebuild / Restore Selected Database";
            this.Load += new System.EventHandler(this.RebuildRestoreForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.Button RestoreButton;
        private System.Windows.Forms.Button RebuildMinButton;
        private System.Windows.Forms.Button RebuildTotalButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}