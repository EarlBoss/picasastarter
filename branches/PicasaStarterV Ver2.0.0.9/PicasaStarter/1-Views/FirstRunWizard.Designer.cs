namespace PicasaStarter
{
    partial class FirstRunWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstRunWizard));
            this.SelXMLPath = new System.Windows.Forms.Button();
            this.SetXMLToDef = new System.Windows.Forms.Button();
            this.textBoxSettingsXMLPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPicasaExePath = new System.Windows.Forms.TextBox();
            this.buttonBrowsePicasaExePath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelXMLPath
            // 
            this.SelXMLPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelXMLPath.Location = new System.Drawing.Point(467, 230);
            this.SelXMLPath.Name = "SelXMLPath";
            this.SelXMLPath.Size = new System.Drawing.Size(75, 23);
            this.SelXMLPath.TabIndex = 20;
            this.SelXMLPath.Text = "Browse...";
            this.SelXMLPath.UseVisualStyleBackColor = true;
            this.SelXMLPath.Click += new System.EventHandler(this.SelXMLPath_Click);
            // 
            // SetXMLToDef
            // 
            this.SetXMLToDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetXMLToDef.Location = new System.Drawing.Point(467, 259);
            this.SetXMLToDef.Name = "SetXMLToDef";
            this.SetXMLToDef.Size = new System.Drawing.Size(75, 22);
            this.SetXMLToDef.TabIndex = 19;
            this.SetXMLToDef.Text = "Default";
            this.SetXMLToDef.UseVisualStyleBackColor = true;
            this.SetXMLToDef.Click += new System.EventHandler(this.SetXMLToDef_Click);
            // 
            // textBoxSettingsXMLPath
            // 
            this.textBoxSettingsXMLPath.AccessibleDescription = "";
            this.textBoxSettingsXMLPath.Enabled = false;
            this.textBoxSettingsXMLPath.Location = new System.Drawing.Point(142, 232);
            this.textBoxSettingsXMLPath.Name = "textBoxSettingsXMLPath";
            this.textBoxSettingsXMLPath.Size = new System.Drawing.Size(319, 20);
            this.textBoxSettingsXMLPath.TabIndex = 18;
            this.textBoxSettingsXMLPath.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 26);
            this.label3.TabIndex = 17;
            this.label3.Text = "Path to picasa starter\r\n database settings (.xml):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(478, 477);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 21;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 32);
            this.label1.TabIndex = 22;
            this.label1.Text = "This  Picasa Starter instance is running for the first time, \r\nor has no saved se" +
                "ttings,so we need to initialize these settings.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(493, 169);
            this.label6.TabIndex = 25;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(299, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Browse to location of the desired settings file or select Default:";
            // 
            // textBoxPicasaExePath
            // 
            this.textBoxPicasaExePath.AccessibleDescription = "";
            this.textBoxPicasaExePath.Enabled = false;
            this.textBoxPicasaExePath.Location = new System.Drawing.Point(107, 107);
            this.textBoxPicasaExePath.Name = "textBoxPicasaExePath";
            this.textBoxPicasaExePath.Size = new System.Drawing.Size(354, 20);
            this.textBoxPicasaExePath.TabIndex = 8;
            this.textBoxPicasaExePath.Tag = "";
            // 
            // buttonBrowsePicasaExePath
            // 
            this.buttonBrowsePicasaExePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowsePicasaExePath.Location = new System.Drawing.Point(467, 104);
            this.buttonBrowsePicasaExePath.Name = "buttonBrowsePicasaExePath";
            this.buttonBrowsePicasaExePath.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowsePicasaExePath.TabIndex = 9;
            this.buttonBrowsePicasaExePath.Text = "Browse...";
            this.buttonBrowsePicasaExePath.UseVisualStyleBackColor = true;
            this.buttonBrowsePicasaExePath.Click += new System.EventHandler(this.buttonBrowsePicasaExePath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 26);
            this.label2.TabIndex = 10;
            this.label2.Text = "Path to picasa \r\nexecutable (.exe):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(418, 52);
            this.label4.TabIndex = 23;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(348, 26);
            this.label5.TabIndex = 24;
            this.label5.Text = "If Picasa is not in the default path as shown below, Please browse to the\r\nPicasa" +
                " installation path and select the Picasa3.exe file.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonBrowsePicasaExePath);
            this.groupBox1.Controls.Add(this.textBoxPicasaExePath);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 134);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Picasa3.exe Path";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.SelXMLPath);
            this.groupBox2.Controls.Add(this.SetXMLToDef);
            this.groupBox2.Controls.Add(this.textBoxSettingsXMLPath);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(552, 291);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PicasaStarterSettings.xml File Path";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 482);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(415, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Note: These settings can be changed later by clicking on the  General Settings bu" +
                "tton.";
            // 
            // FirstRunWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 506);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FirstRunWizard";
            this.ShowInTaskbar = false;
            this.Text = "First Run Settings";
            this.Load += new System.EventHandler(this.FirstRunWizard_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelXMLPath;
        private System.Windows.Forms.Button SetXMLToDef;
        private System.Windows.Forms.TextBox textBoxSettingsXMLPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPicasaExePath;
        private System.Windows.Forms.Button buttonBrowsePicasaExePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
    }
}