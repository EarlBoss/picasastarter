namespace PicasaStarter
{
    partial class CreateShortcutDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateShortcutDialog));
            this.checkDesktopShortcut = new System.Windows.Forms.CheckBox();
            this.checkShortutAppsDir = new System.Windows.Forms.CheckBox();
            this.textShortcutName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCreateShortcut = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkDBMenu1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkDesktopShortcut
            // 
            this.checkDesktopShortcut.AutoSize = true;
            this.checkDesktopShortcut.Checked = true;
            this.checkDesktopShortcut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDesktopShortcut.Location = new System.Drawing.Point(15, 75);
            this.checkDesktopShortcut.Name = "checkDesktopShortcut";
            this.checkDesktopShortcut.Size = new System.Drawing.Size(152, 17);
            this.checkDesktopShortcut.TabIndex = 0;
            this.checkDesktopShortcut.Text = "Place shortcut on Desktop";
            this.checkDesktopShortcut.UseVisualStyleBackColor = true;
            // 
            // checkShortutAppsDir
            // 
            this.checkShortutAppsDir.AutoSize = true;
            this.checkShortutAppsDir.Checked = true;
            this.checkShortutAppsDir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShortutAppsDir.Location = new System.Drawing.Point(15, 98);
            this.checkShortutAppsDir.Name = "checkShortutAppsDir";
            this.checkShortutAppsDir.Size = new System.Drawing.Size(381, 17);
            this.checkShortutAppsDir.TabIndex = 1;
            this.checkShortutAppsDir.Text = "Place shortcut in PicasaStarter application directory (or AppData if it is R/O)";
            this.checkShortutAppsDir.UseVisualStyleBackColor = true;
            // 
            // textShortcutName
            // 
            this.textShortcutName.Location = new System.Drawing.Point(162, 12);
            this.textShortcutName.MaxLength = 64;
            this.textShortcutName.Name = "textShortcutName";
            this.textShortcutName.Size = new System.Drawing.Size(243, 20);
            this.textShortcutName.TabIndex = 2;
            this.textShortcutName.Text = "Picasa Shared Database";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please type a shortcut name:";
            // 
            // buttonCreateShortcut
            // 
            this.buttonCreateShortcut.Location = new System.Drawing.Point(199, 136);
            this.buttonCreateShortcut.Name = "buttonCreateShortcut";
            this.buttonCreateShortcut.Size = new System.Drawing.Size(100, 21);
            this.buttonCreateShortcut.TabIndex = 4;
            this.buttonCreateShortcut.Text = "Create Shortcut(s)";
            this.toolTip1.SetToolTip(this.buttonCreateShortcut, "Create the shortcuts as choosen above...");
            this.buttonCreateShortcut.UseVisualStyleBackColor = true;
            this.buttonCreateShortcut.Click += new System.EventHandler(this.buttonCreateShortcut_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(305, 136);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 21);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.toolTip1.SetToolTip(this.buttonCancel, "Cancel without creating the shortcuts");
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkDBMenu1
            // 
            this.checkDBMenu1.AutoSize = true;
            this.checkDBMenu1.Location = new System.Drawing.Point(49, 38);
            this.checkDBMenu1.Name = "checkDBMenu1";
            this.checkDBMenu1.Size = new System.Drawing.Size(324, 17);
            this.checkDBMenu1.TabIndex = 6;
            this.checkDBMenu1.Text = "Shortcut will open the \"Select Picasa Database To Run\" Menu";
            this.checkDBMenu1.UseVisualStyleBackColor = true;
            this.checkDBMenu1.CheckedChanged += new System.EventHandler(this.checkDBMenu1_CheckedChanged);
            // 
            // CreateShortcutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 166);
            this.Controls.Add(this.checkDBMenu1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCreateShortcut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textShortcutName);
            this.Controls.Add(this.checkShortutAppsDir);
            this.Controls.Add(this.checkDesktopShortcut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateShortcutDialog";
            this.Text = "Create Shortcut";
            this.Load += new System.EventHandler(this.CreateShortcutDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkDesktopShortcut;
        private System.Windows.Forms.CheckBox checkShortutAppsDir;
        private System.Windows.Forms.TextBox textShortcutName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCreateShortcut;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkDBMenu1;
    }
}