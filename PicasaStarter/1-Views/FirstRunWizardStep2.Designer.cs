namespace PicasaStarter
{
    partial class FirstRunWizardStep2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstRunWizardStep2));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ButtonSelXMLPath = new System.Windows.Forms.Button();
            this.ButtonSetXMLToDef = new System.Windows.Forms.Button();
            this.textBoxSettingsXMLPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.ButtonSelXMLPath);
            this.groupBox2.Controls.Add(this.ButtonSetXMLToDef);
            this.groupBox2.Controls.Add(this.textBoxSettingsXMLPath);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(552, 303);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PicasaStarterSettings.xml File Path";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(305, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Browse to location of the desired settings file or select Default...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(493, 169);
            this.label6.TabIndex = 25;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // ButtonSelXMLPath
            // 
            this.ButtonSelXMLPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonSelXMLPath.Location = new System.Drawing.Point(390, 272);
            this.ButtonSelXMLPath.Name = "ButtonSelXMLPath";
            this.ButtonSelXMLPath.Size = new System.Drawing.Size(75, 23);
            this.ButtonSelXMLPath.TabIndex = 20;
            this.ButtonSelXMLPath.Text = "Browse...";
            this.ButtonSelXMLPath.UseVisualStyleBackColor = true;
            this.ButtonSelXMLPath.Click += new System.EventHandler(this.ButtonSelXMLPath_Click);
            // 
            // ButtonSetXMLToDef
            // 
            this.ButtonSetXMLToDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonSetXMLToDef.Location = new System.Drawing.Point(471, 273);
            this.ButtonSetXMLToDef.Name = "ButtonSetXMLToDef";
            this.ButtonSetXMLToDef.Size = new System.Drawing.Size(75, 22);
            this.ButtonSetXMLToDef.TabIndex = 19;
            this.ButtonSetXMLToDef.Text = "Default";
            this.ButtonSetXMLToDef.UseVisualStyleBackColor = true;
            this.ButtonSetXMLToDef.Click += new System.EventHandler(this.ButtonSetXMLToDef_Click);
            // 
            // textBoxSettingsXMLPath
            // 
            this.textBoxSettingsXMLPath.AccessibleDescription = "";
            this.textBoxSettingsXMLPath.Enabled = false;
            this.textBoxSettingsXMLPath.Location = new System.Drawing.Point(15, 274);
            this.textBoxSettingsXMLPath.Name = "textBoxSettingsXMLPath";
            this.textBoxSettingsXMLPath.Size = new System.Drawing.Size(369, 20);
            this.textBoxSettingsXMLPath.TabIndex = 18;
            this.textBoxSettingsXMLPath.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Path to picasa starter database settings (.xml):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(416, 327);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 30;
            this.buttonOK.Text = "Finish";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(497, 327);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 31;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FirstRunWizardStep2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox2);
            this.Name = "FirstRunWizardStep2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "First Run Settings";
            this.Load += new System.EventHandler(this.FirstRunWizardStep2_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ButtonSelXMLPath;
        private System.Windows.Forms.Button ButtonSetXMLToDef;
        private System.Windows.Forms.TextBox textBoxSettingsXMLPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}