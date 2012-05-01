namespace PicasaStarter
{
    partial class CreatePicasaButtonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatePicasaButtonForm));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxTooltip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLabel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxExeDirRegKey = new System.Windows.Forms.TextBox();
            this.buttonBrowseExe = new System.Windows.Forms.Button();
            this.buttonChangeIcon = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxIconLayer = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonRemoveIcon = new System.Windows.Forms.Button();
            this.buttonEditScript = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.textBoxExeDir = new System.Windows.Forms.TextBox();
            this.textBoxExeFileName = new System.Windows.Forms.TextBox();
            this.textBoxExeFileRegKey = new System.Windows.Forms.TextBox();
            this.radioButtonExe = new System.Windows.Forms.RadioButton();
            this.radioButtonScript = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxExportFirst = new System.Windows.Forms.CheckBox();
            this.checkBoxExecuteForeach = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(497, 527);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(416, 527);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBoxTooltip
            // 
            this.textBoxTooltip.Location = new System.Drawing.Point(84, 135);
            this.textBoxTooltip.Name = "textBoxTooltip";
            this.textBoxTooltip.Size = new System.Drawing.Size(468, 20);
            this.textBoxTooltip.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tooltip:";
            // 
            // textBoxLabel
            // 
            this.textBoxLabel.Location = new System.Drawing.Point(84, 29);
            this.textBoxLabel.Name = "textBoxLabel";
            this.textBoxLabel.Size = new System.Drawing.Size(230, 20);
            this.textBoxLabel.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Label:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Registry key with directory:";
            // 
            // textBoxExeDirRegKey
            // 
            this.textBoxExeDirRegKey.Location = new System.Drawing.Point(167, 71);
            this.textBoxExeDirRegKey.Name = "textBoxExeDirRegKey";
            this.textBoxExeDirRegKey.Size = new System.Drawing.Size(391, 20);
            this.textBoxExeDirRegKey.TabIndex = 11;
            this.toolTip.SetToolTip(this.textBoxExeDirRegKey, resources.GetString("textBoxExeDirRegKey.ToolTip"));
            // 
            // buttonBrowseExe
            // 
            this.buttonBrowseExe.Location = new System.Drawing.Point(489, 121);
            this.buttonBrowseExe.Name = "buttonBrowseExe";
            this.buttonBrowseExe.Size = new System.Drawing.Size(69, 23);
            this.buttonBrowseExe.TabIndex = 1;
            this.buttonBrowseExe.Text = "Browse...";
            this.buttonBrowseExe.UseVisualStyleBackColor = true;
            this.buttonBrowseExe.Click += new System.EventHandler(this.buttonBrowseExe_Click);
            // 
            // buttonChangeIcon
            // 
            this.buttonChangeIcon.Location = new System.Drawing.Point(84, 159);
            this.buttonChangeIcon.Name = "buttonChangeIcon";
            this.buttonChangeIcon.Size = new System.Drawing.Size(71, 23);
            this.buttonChangeIcon.TabIndex = 3;
            this.buttonChangeIcon.Text = "Change...";
            this.toolTip.SetToolTip(this.buttonChangeIcon, "Press browse to add/change the icon for the Picasa Button. Mind: only .psd (Photo" +
                    "shop) files are supported.");
            this.buttonChangeIcon.UseVisualStyleBackColor = true;
            this.buttonChangeIcon.Click += new System.EventHandler(this.buttonChangeIcon_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Icon:";
            // 
            // textBoxIconLayer
            // 
            this.textBoxIconLayer.Location = new System.Drawing.Point(361, 161);
            this.textBoxIconLayer.Name = "textBoxIconLayer";
            this.textBoxIconLayer.Size = new System.Drawing.Size(191, 20);
            this.textBoxIconLayer.TabIndex = 5;
            this.toolTip.SetToolTip(this.textBoxIconLayer, "The layer in the .psd file that contains the icon.");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(270, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Icon layer name:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(84, 55);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(468, 74);
            this.textBoxDescription.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Description:";
            // 
            // buttonRemoveIcon
            // 
            this.buttonRemoveIcon.Location = new System.Drawing.Point(161, 159);
            this.buttonRemoveIcon.Name = "buttonRemoveIcon";
            this.buttonRemoveIcon.Size = new System.Drawing.Size(62, 23);
            this.buttonRemoveIcon.TabIndex = 4;
            this.buttonRemoveIcon.Text = "Remove";
            this.toolTip.SetToolTip(this.buttonRemoveIcon, "Press browse to add/change the icon for the Picasa Button. Mind: only .psd (Photo" +
                    "shop) files are supported.");
            this.buttonRemoveIcon.UseVisualStyleBackColor = true;
            this.buttonRemoveIcon.Click += new System.EventHandler(this.buttonRemoveIcon_Click);
            // 
            // buttonEditScript
            // 
            this.buttonEditScript.Location = new System.Drawing.Point(37, 182);
            this.buttonEditScript.Name = "buttonEditScript";
            this.buttonEditScript.Size = new System.Drawing.Size(75, 23);
            this.buttonEditScript.TabIndex = 4;
            this.buttonEditScript.Text = "Edit script...";
            this.toolTip.SetToolTip(this.buttonEditScript, "Press browse to add/change the icon for the Picasa Button. Mind: only .psd (Photo" +
                    "shop) files are supported.");
            this.buttonEditScript.UseVisualStyleBackColor = true;
            this.buttonEditScript.Click += new System.EventHandler(this.buttonEditScript_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(8, 527);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(135, 23);
            this.buttonExport.TabIndex = 29;
            this.buttonExport.Text = "Export portable version...";
            this.toolTip.SetToolTip(this.buttonExport, "Export a version of the button that will work in anyone\'s standard Picasa databas" +
                    "e (= without using PicasaStarter)...");
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // textBoxExeDir
            // 
            this.textBoxExeDir.Location = new System.Drawing.Point(100, 97);
            this.textBoxExeDir.Name = "textBoxExeDir";
            this.textBoxExeDir.Size = new System.Drawing.Size(383, 20);
            this.textBoxExeDir.TabIndex = 14;
            this.toolTip.SetToolTip(this.textBoxExeDir, "Directory where the executable can be found. If a registry key is specified for t" +
                    "he directory as well, this should be a relative path.");
            // 
            // textBoxExeFileName
            // 
            this.textBoxExeFileName.Location = new System.Drawing.Point(100, 123);
            this.textBoxExeFileName.Name = "textBoxExeFileName";
            this.textBoxExeFileName.Size = new System.Drawing.Size(383, 20);
            this.textBoxExeFileName.TabIndex = 12;
            this.toolTip.SetToolTip(this.textBoxExeFileName, "Filename of the executable (without directory!). If only this field is filled out" +
                    ", and no directory field(s), the executable must be fount in the directories in " +
                    "the PATH environment variable.");
            // 
            // textBoxExeFileRegKey
            // 
            this.textBoxExeFileRegKey.Location = new System.Drawing.Point(167, 45);
            this.textBoxExeFileRegKey.Name = "textBoxExeFileRegKey";
            this.textBoxExeFileRegKey.Size = new System.Drawing.Size(391, 20);
            this.textBoxExeFileRegKey.TabIndex = 17;
            this.toolTip.SetToolTip(this.textBoxExeFileRegKey, "Registry key containing the entire path + filename of the exe.");
            this.textBoxExeFileRegKey.TextChanged += new System.EventHandler(this.textBoxExeFileRegKey_TextChanged);
            // 
            // radioButtonExe
            // 
            this.radioButtonExe.AutoSize = true;
            this.radioButtonExe.Location = new System.Drawing.Point(9, 22);
            this.radioButtonExe.Name = "radioButtonExe";
            this.radioButtonExe.Size = new System.Drawing.Size(267, 17);
            this.radioButtonExe.TabIndex = 0;
            this.radioButtonExe.TabStop = true;
            this.radioButtonExe.Text = "The button needs to execute an application directly";
            this.radioButtonExe.UseVisualStyleBackColor = true;
            this.radioButtonExe.CheckedChanged += new System.EventHandler(this.radioButtonExe_CheckedChanged);
            // 
            // radioButtonScript
            // 
            this.radioButtonScript.AutoSize = true;
            this.radioButtonScript.Location = new System.Drawing.Point(10, 159);
            this.radioButtonScript.Name = "radioButtonScript";
            this.radioButtonScript.Size = new System.Drawing.Size(399, 17);
            this.radioButtonScript.TabIndex = 3;
            this.radioButtonScript.TabStop = true;
            this.radioButtonScript.Text = "The button needs to start a batch script (.bat or .cmd) that does the actual work" +
                "";
            this.radioButtonScript.UseVisualStyleBackColor = true;
            this.radioButtonScript.CheckedChanged += new System.EventHandler(this.radioButtonScript_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxExeFileRegKey);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxExeDir);
            this.groupBox1.Controls.Add(this.textBoxExeFileName);
            this.groupBox1.Controls.Add(this.radioButtonExe);
            this.groupBox1.Controls.Add(this.buttonEditScript);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.radioButtonScript);
            this.groupBox1.Controls.Add(this.textBoxExeDirRegKey);
            this.groupBox1.Controls.Add(this.buttonBrowseExe);
            this.groupBox1.Location = new System.Drawing.Point(8, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 219);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action of the button";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Registry key with exe file:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Directory:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "File name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxDescription);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.buttonRemoveIcon);
            this.groupBox2.Controls.Add(this.textBoxLabel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBoxTooltip);
            this.groupBox2.Controls.Add(this.textBoxIconLayer);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.buttonChangeIcon);
            this.groupBox2.Location = new System.Drawing.Point(8, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(564, 189);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General information about the button";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxExportFirst);
            this.groupBox3.Controls.Add(this.checkBoxExecuteForeach);
            this.groupBox3.Location = new System.Drawing.Point(8, 432);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(564, 78);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Additional settings";
            // 
            // checkBoxExportFirst
            // 
            this.checkBoxExportFirst.AutoSize = true;
            this.checkBoxExportFirst.Location = new System.Drawing.Point(6, 47);
            this.checkBoxExportFirst.Name = "checkBoxExportFirst";
            this.checkBoxExportFirst.Size = new System.Drawing.Size(449, 17);
            this.checkBoxExportFirst.TabIndex = 1;
            this.checkBoxExportFirst.Text = "Execute the action on a copy of the images that includes the unsaved changes in P" +
                "icasa.";
            this.checkBoxExportFirst.UseVisualStyleBackColor = true;
            // 
            // checkBoxExecuteForeach
            // 
            this.checkBoxExecuteForeach.AutoSize = true;
            this.checkBoxExecuteForeach.Location = new System.Drawing.Point(6, 24);
            this.checkBoxExecuteForeach.Name = "checkBoxExecuteForeach";
            this.checkBoxExecuteForeach.Size = new System.Drawing.Size(531, 17);
            this.checkBoxExecuteForeach.TabIndex = 0;
            this.checkBoxExecuteForeach.Text = "Execute the action for every selected image seperately (versus pass all images in" +
                " one time to the command)";
            this.checkBoxExecuteForeach.UseVisualStyleBackColor = true;
            // 
            // CreatePicasaButtonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CreatePicasaButtonForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create/Edit Picasa Button";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxTooltip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxExeDirRegKey;
        private System.Windows.Forms.Button buttonBrowseExe;
        private System.Windows.Forms.Button buttonChangeIcon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxIconLayer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonRemoveIcon;
        private System.Windows.Forms.RadioButton radioButtonExe;
        private System.Windows.Forms.RadioButton radioButtonScript;
        private System.Windows.Forms.Button buttonEditScript;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxExportFirst;
        private System.Windows.Forms.CheckBox checkBoxExecuteForeach;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxExeDir;
        private System.Windows.Forms.TextBox textBoxExeFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxExeFileRegKey;
    }
}