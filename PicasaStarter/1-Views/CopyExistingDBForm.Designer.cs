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
            this.buttonClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonDBExplore = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDestDir = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonDestExplore = new System.Windows.Forms.Button();
            this.groupBoxInstructions = new System.Windows.Forms.GroupBox();
            this.groupBoxInstructions.SuspendLayout();
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
            this.textBoxDBDescription.Enabled = false;
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
            this.textBoxDBBaseDir.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxDBBaseDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDBBaseDir.Location = new System.Drawing.Point(80, 332);
            this.textBoxDBBaseDir.Name = "textBoxDBBaseDir";
            this.textBoxDBBaseDir.ReadOnly = true;
            this.textBoxDBBaseDir.Size = new System.Drawing.Size(418, 20);
            this.textBoxDBBaseDir.TabIndex = 42;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(498, 397);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(80, 23);
            this.buttonClose.TabIndex = 44;
            this.buttonClose.Text = "Done";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-3, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(575, 104);
            this.label4.TabIndex = 45;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // buttonDBExplore
            // 
            this.buttonDBExplore.Location = new System.Drawing.Point(504, 332);
            this.buttonDBExplore.Name = "buttonDBExplore";
            this.buttonDBExplore.Size = new System.Drawing.Size(74, 21);
            this.buttonDBExplore.TabIndex = 46;
            this.buttonDBExplore.Text = "Explore";
            this.buttonDBExplore.UseVisualStyleBackColor = true;
            this.buttonDBExplore.Click += new System.EventHandler(this.buttonDBExplore_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(337, 39);
            this.label2.TabIndex = 47;
            this.label2.Text = "The Destination directory can be on a Virtual Drive, but the\r\n            selecte" +
                "d source database must be a physical or mapped drive,\r\n            or the same V" +
                "irtual Drive.";
            // 
            // textBoxDestDir
            // 
            this.textBoxDestDir.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxDestDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDestDir.Location = new System.Drawing.Point(80, 358);
            this.textBoxDestDir.Name = "textBoxDestDir";
            this.textBoxDestDir.ReadOnly = true;
            this.textBoxDestDir.Size = new System.Drawing.Size(418, 20);
            this.textBoxDestDir.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 26);
            this.label5.TabIndex = 49;
            this.label5.Text = "Selected\r\nSource:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 361);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Destination:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonDestExplore
            // 
            this.buttonDestExplore.Location = new System.Drawing.Point(504, 358);
            this.buttonDestExplore.Name = "buttonDestExplore";
            this.buttonDestExplore.Size = new System.Drawing.Size(74, 21);
            this.buttonDestExplore.TabIndex = 51;
            this.buttonDestExplore.Text = "Explore";
            this.buttonDestExplore.UseVisualStyleBackColor = true;
            this.buttonDestExplore.Click += new System.EventHandler(this.buttonDestExplore_Click);
            // 
            // groupBoxInstructions
            // 
            this.groupBoxInstructions.Controls.Add(this.label4);
            this.groupBoxInstructions.Location = new System.Drawing.Point(12, 180);
            this.groupBoxInstructions.Name = "groupBoxInstructions";
            this.groupBoxInstructions.Size = new System.Drawing.Size(581, 133);
            this.groupBoxInstructions.TabIndex = 52;
            this.groupBoxInstructions.TabStop = false;
            this.groupBoxInstructions.Text = "INSTRUCTIONS";
            // 
            // CopyExistingDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 434);
            this.Controls.Add(this.buttonDestExplore);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxDestDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonDBExplore);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.textBoxDBBaseDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDBDescription);
            this.Controls.Add(this.listBoxPicasaDBs);
            this.Controls.Add(this.groupBoxInstructions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CopyExistingDBForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Copy Picasa Database To: ";
            this.Load += new System.EventHandler(this.CopyExistingDBForm_Load);
            this.groupBoxInstructions.ResumeLayout(false);
            this.groupBoxInstructions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPicasaDBs;
        private System.Windows.Forms.TextBox textBoxDBDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDBBaseDir;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonDBExplore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDestDir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonDestExplore;
        private System.Windows.Forms.GroupBox groupBoxInstructions;
    }
}