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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralSettingsDialog));
            this.label2 = new System.Windows.Forms.Label();
            this.buttonBrowsePicasaExePath = new System.Windows.Forms.Button();
            this.textBoxPicasaExePath = new System.Windows.Forms.TextBox();
            this.generalSettingsDialogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSettingsXMLPath = new System.Windows.Forms.TextBox();
            this.SetXMLToDef = new System.Windows.Forms.Button();
            this.SelXMLPath = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonExploreLogging = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.generalSettingsDialogBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(162, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Path to picasa executable (.exe):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonBrowsePicasaExePath
            // 
            this.buttonBrowsePicasaExePath.Location = new System.Drawing.Point(503, 36);
            this.buttonBrowsePicasaExePath.Name = "buttonBrowsePicasaExePath";
            this.buttonBrowsePicasaExePath.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowsePicasaExePath.TabIndex = 6;
            this.buttonBrowsePicasaExePath.Text = "Browse...";
            this.toolTip1.SetToolTip(this.buttonBrowsePicasaExePath, "Choose the location where the Picasa executable can be found on the computer");
            this.buttonBrowsePicasaExePath.UseVisualStyleBackColor = true;
            this.buttonBrowsePicasaExePath.Click += new System.EventHandler(this.buttonBrowsePicasaExePath_Click);
            // 
            // textBoxPicasaExePath
            // 
            this.textBoxPicasaExePath.AccessibleDescription = "";
            this.textBoxPicasaExePath.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generalSettingsDialogBindingSource, "PicasaExePath", true));
            this.textBoxPicasaExePath.Enabled = false;
            this.textBoxPicasaExePath.Location = new System.Drawing.Point(12, 36);
            this.textBoxPicasaExePath.Name = "textBoxPicasaExePath";
            this.textBoxPicasaExePath.Size = new System.Drawing.Size(485, 20);
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
            this.buttonCancel.Location = new System.Drawing.Point(503, 167);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(422, 167);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Path to picasa starter database settings (.xml):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxSettingsXMLPath
            // 
            this.textBoxSettingsXMLPath.AccessibleDescription = "";
            this.textBoxSettingsXMLPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generalSettingsDialogBindingSource, "PicasaExePath", true));
            this.textBoxSettingsXMLPath.Enabled = false;
            this.textBoxSettingsXMLPath.Location = new System.Drawing.Point(12, 84);
            this.textBoxSettingsXMLPath.Name = "textBoxSettingsXMLPath";
            this.textBoxSettingsXMLPath.Size = new System.Drawing.Size(485, 20);
            this.textBoxSettingsXMLPath.TabIndex = 14;
            this.textBoxSettingsXMLPath.Tag = "";
            // 
            // SetXMLToDef
            // 
            this.SetXMLToDef.Location = new System.Drawing.Point(503, 117);
            this.SetXMLToDef.Name = "SetXMLToDef";
            this.SetXMLToDef.Size = new System.Drawing.Size(75, 22);
            this.SetXMLToDef.TabIndex = 15;
            this.SetXMLToDef.Text = "Default";
            this.toolTip1.SetToolTip(this.SetXMLToDef, "Revert the place to store the PicasaStarter database settings to the default plac" +
        "e");
            this.SetXMLToDef.UseVisualStyleBackColor = true;
            this.SetXMLToDef.Click += new System.EventHandler(this.SetXMLToDef_Click);
            // 
            // SelXMLPath
            // 
            this.SelXMLPath.Location = new System.Drawing.Point(503, 82);
            this.SelXMLPath.Name = "SelXMLPath";
            this.SelXMLPath.Size = new System.Drawing.Size(75, 23);
            this.SelXMLPath.TabIndex = 16;
            this.SelXMLPath.Text = "Browse...";
            this.toolTip1.SetToolTip(this.SelXMLPath, "Choose the location where the Picasastarter settings  (the databases) will be sto" +
        "red");
            this.SelXMLPath.UseVisualStyleBackColor = true;
            this.SelXMLPath.Click += new System.EventHandler(this.SelXMLPath_Click);
            // 
            // buttonExploreLogging
            // 
            this.buttonExploreLogging.Location = new System.Drawing.Point(133, 151);
            this.buttonExploreLogging.Name = "buttonExploreLogging";
            this.buttonExploreLogging.Size = new System.Drawing.Size(75, 23);
            this.buttonExploreLogging.TabIndex = 18;
            this.buttonExploreLogging.Text = "Explore...";
            this.toolTip1.SetToolTip(this.buttonExploreLogging, "Export the PicasaStarter database settings to an xml file");
            this.buttonExploreLogging.UseVisualStyleBackColor = true;
            this.buttonExploreLogging.Click += new System.EventHandler(this.buttonExploreLogging_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Picasa Starter Logging:";
            // 
            // GeneralSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(590, 203);
            this.Controls.Add(this.buttonExploreLogging);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SelXMLPath);
            this.Controls.Add(this.SetXMLToDef);
            this.Controls.Add(this.textBoxSettingsXMLPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonBrowsePicasaExePath);
            this.Controls.Add(this.textBoxPicasaExePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeneralSettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
        private System.Windows.Forms.BindingSource generalSettingsDialogBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSettingsXMLPath;
        private System.Windows.Forms.Button SetXMLToDef;
        private System.Windows.Forms.Button SelXMLPath;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonExploreLogging;
    }
}