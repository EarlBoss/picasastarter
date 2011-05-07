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
            this.checkDesktopShortcut = new System.Windows.Forms.CheckBox();
            this.checkShortutAppsDir = new System.Windows.Forms.CheckBox();
            this.textShortcutName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCreateShortcut = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkDesktopShortcut
            // 
            this.checkDesktopShortcut.AutoSize = true;
            this.checkDesktopShortcut.Checked = true;
            this.checkDesktopShortcut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDesktopShortcut.Location = new System.Drawing.Point(12, 54);
            this.checkDesktopShortcut.Name = "checkDesktopShortcut";
            this.checkDesktopShortcut.Size = new System.Drawing.Size(154, 17);
            this.checkDesktopShortcut.TabIndex = 0;
            this.checkDesktopShortcut.Text = "Place Shortcut on Desktop";
            this.checkDesktopShortcut.UseVisualStyleBackColor = true;
            this.checkDesktopShortcut.CheckedChanged += new System.EventHandler(this.checkDesktopShortcut_CheckedChanged);
            // 
            // checkShortutAppsDir
            // 
            this.checkShortutAppsDir.AutoSize = true;
            this.checkShortutAppsDir.Checked = true;
            this.checkShortutAppsDir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShortutAppsDir.Location = new System.Drawing.Point(12, 77);
            this.checkShortutAppsDir.Name = "checkShortutAppsDir";
            this.checkShortutAppsDir.Size = new System.Drawing.Size(176, 43);
            this.checkShortutAppsDir.TabIndex = 1;
            this.checkShortutAppsDir.Text = "Place Shortcut in PicasaStarter \r\nApplication Directory or\r\nAppsData if Applicati" +
                "on is R/O";
            this.checkShortutAppsDir.UseVisualStyleBackColor = true;
            this.checkShortutAppsDir.CheckedChanged += new System.EventHandler(this.checkShortutAppsDir_CheckedChanged);
            // 
            // textShortcutName
            // 
            this.textShortcutName.Location = new System.Drawing.Point(177, 12);
            this.textShortcutName.MaxLength = 64;
            this.textShortcutName.Name = "textShortcutName";
            this.textShortcutName.Size = new System.Drawing.Size(228, 20);
            this.textShortcutName.TabIndex = 2;
            this.textShortcutName.Text = "Picasa Shared Database";
            this.textShortcutName.TextChanged += new System.EventHandler(this.textShortcutName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please Type a Shortcut Name";
            // 
            // buttonCreateShortcut
            // 
            this.buttonCreateShortcut.Location = new System.Drawing.Point(209, 81);
            this.buttonCreateShortcut.Name = "buttonCreateShortcut";
            this.buttonCreateShortcut.Size = new System.Drawing.Size(107, 21);
            this.buttonCreateShortcut.TabIndex = 4;
            this.buttonCreateShortcut.Text = "Create Shortcut(s)";
            this.buttonCreateShortcut.UseVisualStyleBackColor = true;
            this.buttonCreateShortcut.Click += new System.EventHandler(this.buttonCreateShortcut_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(338, 82);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(67, 19);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // CreateShortcutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 121);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCreateShortcut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textShortcutName);
            this.Controls.Add(this.checkShortutAppsDir);
            this.Controls.Add(this.checkDesktopShortcut);
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
    }
}