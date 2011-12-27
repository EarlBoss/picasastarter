namespace PicasaStarter
{
    partial class CopyExistingDBForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopyExistingDBForm));
            this.listBoxPicasaDBs = new System.Windows.Forms.ListBox();
            this.textBoxDBDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDBBaseDir = new System.Windows.Forms.TextBox();
            this.buttonCopyDB = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonDBExplore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxPicasaDBs
            // 
            this.listBoxPicasaDBs.FormattingEnabled = true;
            this.listBoxPicasaDBs.Location = new System.Drawing.Point(12, 27);
            this.listBoxPicasaDBs.Name = "listBoxPicasaDBs";
            this.listBoxPicasaDBs.Size = new System.Drawing.Size(253, 147);
            this.listBoxPicasaDBs.TabIndex = 23;
            this.listBoxPicasaDBs.SelectedIndexChanged += new System.EventHandler(this.listBoxPicasaDBs_SelectedIndexChanged_1);
            // 
            // textBoxDBDescription
            // 
            this.textBoxDBDescription.Location = new System.Drawing.Point(274, 27);
            this.textBoxDBDescription.Multiline = true;
            this.textBoxDBDescription.Name = "textBoxDBDescription";
            this.textBoxDBDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDBDescription.Size = new System.Drawing.Size(304, 121);
            this.textBoxDBDescription.TabIndex = 36;
            this.textBoxDBDescription.Text = "Database Description";
            this.textBoxDBDescription.TextChanged += new System.EventHandler(this.textBoxDBDescription_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Description:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Select Database to Copy:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxDBBaseDir
            // 
            this.textBoxDBBaseDir.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxDBBaseDir.Location = new System.Drawing.Point(12, 195);
            this.textBoxDBBaseDir.Name = "textBoxDBBaseDir";
            this.textBoxDBBaseDir.ReadOnly = true;
            this.textBoxDBBaseDir.Size = new System.Drawing.Size(480, 20);
            this.textBoxDBBaseDir.TabIndex = 42;
            // 
            // buttonCopyDB
            // 
            this.buttonCopyDB.Location = new System.Drawing.Point(392, 233);
            this.buttonCopyDB.Name = "buttonCopyDB";
            this.buttonCopyDB.Size = new System.Drawing.Size(100, 23);
            this.buttonCopyDB.TabIndex = 43;
            this.buttonCopyDB.Text = "Copy Database";
            this.buttonCopyDB.UseVisualStyleBackColor = true;
            this.buttonCopyDB.Click += new System.EventHandler(this.buttonCopyDB_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(498, 233);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(80, 23);
            this.buttonClose.TabIndex = 44;
            this.buttonClose.Text = "Quit";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(386, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "If Database is not listed above, Explore to Google directory of Database to Copy:" +
                "";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonDBExplore
            // 
            this.buttonDBExplore.Location = new System.Drawing.Point(508, 193);
            this.buttonDBExplore.Name = "buttonDBExplore";
            this.buttonDBExplore.Size = new System.Drawing.Size(58, 21);
            this.buttonDBExplore.TabIndex = 46;
            this.buttonDBExplore.Text = "Explore";
            this.buttonDBExplore.UseVisualStyleBackColor = true;
            // 
            // CopyExistingDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 268);
            this.Controls.Add(this.buttonDBExplore);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonCopyDB);
            this.Controls.Add(this.textBoxDBBaseDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDBDescription);
            this.Controls.Add(this.listBoxPicasaDBs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CopyExistingDBForm";
            this.ShowInTaskbar = false;
            this.Text = "Copy Picasa Database To: ";
            this.Load += new System.EventHandler(this.CopyExistingDBForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPicasaDBs;
        private System.Windows.Forms.TextBox textBoxDBDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDBBaseDir;
        private System.Windows.Forms.Button buttonCopyDB;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonDBExplore;
    }
}