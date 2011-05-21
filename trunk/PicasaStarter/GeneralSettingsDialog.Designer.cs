namespace PicasaStarter
{
    partial class GeneralSettingsDialog
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
            this.label2 = new System.Windows.Forms.Label();
            this.buttonBrowsePicasaExePath = new System.Windows.Forms.Button();
            this.textBoxPicasaExePath = new System.Windows.Forms.TextBox();
            this.generalSettingsDialogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExportSettings = new System.Windows.Forms.Button();
            this.buttonImportSettings = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSettingsXMLPath = new System.Windows.Forms.TextBox();
            this.SetXMLToDef = new System.Windows.Forms.Button();
            this.SelXMLPath = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.generalSettingsDialogBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "Path to picasa \r\nexecutable (.exe):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonBrowsePicasaExePath
            // 
            this.buttonBrowsePicasaExePath.Location = new System.Drawing.Point(474, 20);
            this.buttonBrowsePicasaExePath.Name = "buttonBrowsePicasaExePath";
            this.buttonBrowsePicasaExePath.Size = new System.Drawing.Size(75, 27);
            this.buttonBrowsePicasaExePath.TabIndex = 6;
            this.buttonBrowsePicasaExePath.Text = "Browse...";
            this.buttonBrowsePicasaExePath.UseVisualStyleBackColor = true;
            this.buttonBrowsePicasaExePath.Click += new System.EventHandler(this.buttonBrowsePicasaExePath_Click);
            // 
            // textBoxPicasaExePath
            // 
            this.textBoxPicasaExePath.AccessibleDescription = "";
            this.textBoxPicasaExePath.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generalSettingsDialogBindingSource, "PicasaExePath", true));
            this.textBoxPicasaExePath.Enabled = false;
            this.textBoxPicasaExePath.Location = new System.Drawing.Point(128, 24);
            this.textBoxPicasaExePath.Name = "textBoxPicasaExePath";
            this.textBoxPicasaExePath.Size = new System.Drawing.Size(340, 20);
            this.textBoxPicasaExePath.TabIndex = 5;
            this.textBoxPicasaExePath.Tag = "";
            this.textBoxPicasaExePath.TextChanged += new System.EventHandler(this.textBoxPicasaExePath_TextChanged);
            // 
            // generalSettingsDialogBindingSource
            // 
            this.generalSettingsDialogBindingSource.DataSource = typeof(PicasaStarter.GeneralSettingsDialog);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(478, 170);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(397, 170);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Picasa Starter Settings:";
            // 
            // buttonExportSettings
            // 
            this.buttonExportSettings.Location = new System.Drawing.Point(128, 144);
            this.buttonExportSettings.Name = "buttonExportSettings";
            this.buttonExportSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonExportSettings.TabIndex = 11;
            this.buttonExportSettings.Text = "Export...";
            this.buttonExportSettings.UseVisualStyleBackColor = true;
            this.buttonExportSettings.Click += new System.EventHandler(this.buttonExportSettings_Click);
            // 
            // buttonImportSettings
            // 
            this.buttonImportSettings.Location = new System.Drawing.Point(209, 144);
            this.buttonImportSettings.Name = "buttonImportSettings";
            this.buttonImportSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonImportSettings.TabIndex = 12;
            this.buttonImportSettings.Text = "Import...";
            this.buttonImportSettings.UseVisualStyleBackColor = true;
            this.buttonImportSettings.Click += new System.EventHandler(this.buttonImportSettings_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 26);
            this.label3.TabIndex = 13;
            this.label3.Text = "Path to picasa starter\r\n database settings (.xml):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxSettingsXMLPath
            // 
            this.textBoxSettingsXMLPath.AccessibleDescription = "";
            this.textBoxSettingsXMLPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generalSettingsDialogBindingSource, "PicasaExePath", true));
            this.textBoxSettingsXMLPath.Enabled = false;
            this.textBoxSettingsXMLPath.Location = new System.Drawing.Point(128, 72);
            this.textBoxSettingsXMLPath.Name = "textBoxSettingsXMLPath";
            this.textBoxSettingsXMLPath.Size = new System.Drawing.Size(340, 20);
            this.textBoxSettingsXMLPath.TabIndex = 14;
            this.textBoxSettingsXMLPath.Tag = "";
            this.textBoxSettingsXMLPath.TextChanged += new System.EventHandler(this.textBoxSettingsXMLPath_TextChanged);
            // 
            // SetXMLToDef
            // 
            this.SetXMLToDef.Location = new System.Drawing.Point(128, 98);
            this.SetXMLToDef.Name = "SetXMLToDef";
            this.SetXMLToDef.Size = new System.Drawing.Size(339, 22);
            this.SetXMLToDef.TabIndex = 15;
            this.SetXMLToDef.Text = "Use Default Settings File (.xml) Location";
            this.SetXMLToDef.UseVisualStyleBackColor = true;
            this.SetXMLToDef.Click += new System.EventHandler(this.SetXMLToDef_Click);
            // 
            // SelXMLPath
            // 
            this.SelXMLPath.Location = new System.Drawing.Point(474, 68);
            this.SelXMLPath.Name = "SelXMLPath";
            this.SelXMLPath.Size = new System.Drawing.Size(75, 27);
            this.SelXMLPath.TabIndex = 16;
            this.SelXMLPath.Text = "Browse...";
            this.SelXMLPath.UseVisualStyleBackColor = true;
            this.SelXMLPath.Click += new System.EventHandler(this.SelXMLPath_Click);
            // 
            // GeneralSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 205);
            this.Controls.Add(this.SelXMLPath);
            this.Controls.Add(this.SetXMLToDef);
            this.Controls.Add(this.textBoxSettingsXMLPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonImportSettings);
            this.Controls.Add(this.buttonExportSettings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonBrowsePicasaExePath);
            this.Controls.Add(this.textBoxPicasaExePath);
            this.Name = "GeneralSettingsDialog";
            this.Text = "General settings";
            this.Load += new System.EventHandler(this.GeneralSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.generalSettingsDialogBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonBrowsePicasaExePath;
        private System.Windows.Forms.TextBox textBoxPicasaExePath;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonExportSettings;
        private System.Windows.Forms.Button buttonImportSettings;
        private System.Windows.Forms.BindingSource generalSettingsDialogBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSettingsXMLPath;
        private System.Windows.Forms.Button SetXMLToDef;
        private System.Windows.Forms.Button SelXMLPath;
    }
}