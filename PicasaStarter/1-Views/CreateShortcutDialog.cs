using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IWshRuntimeLibrary; // Needed to create shortcuts

namespace PicasaStarter
{
    public partial class CreateShortcutDialog : Form
    {
        private string _databasename = "";
        private WshShellClass WshShell;
    
        public CreateShortcutDialog(string dataBaseName)
        {
            InitializeComponent();
            _databasename = dataBaseName;
        }

        private void CreateShortcutDialog_Load(object sender, EventArgs e)
        {
            this.Text = "Create Shortcut to: \" " + _databasename + " \" Database";
            textShortcutName.Text = "Picasa " + _databasename;
        }

        private void buttonCreateShortcut_Click(object sender, EventArgs e)
        {
            string shortcutpath;
            // See if we create a shortcut in the Apps Directory
            if (checkShortutAppsDir.Checked)
            {
                shortcutpath = SettingsHelper.ConfigurationDir + "\\" + textShortcutName.Text + ".lnk";
                DoShortcut(shortcutpath, _databasename, Application.StartupPath);
            }
            if (checkDesktopShortcut.Checked)
            {
                shortcutpath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + textShortcutName.Text + ".lnk";
                DoShortcut(shortcutpath, _databasename, Application.StartupPath);
            }
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DoShortcut(string shortcutpath, string databasename, string target)
        {
            // Create a new instance of WshShellClass
             WshShell = new WshShellClass();
             string _localdatabasename = databasename;

             if (checkDBMenu1.Checked)
                 _localdatabasename = "AskUser";

             // Create the shortcut
             IWshRuntimeLibrary.IWshShortcut MyShortcut;

             // Choose the path for the shortcut
             MyShortcut = (IWshRuntimeLibrary.IWshShortcut)WshShell.CreateShortcut(shortcutpath);

             // Where the shortcut should point to
             MyShortcut.TargetPath = target + "\\" + "picasastarter.exe";
             MyShortcut.WorkingDirectory = target;

             MyShortcut.Arguments = "/autorun \"" + _localdatabasename + "\"";
             // Description for the shortcut
             MyShortcut.Description = "Start Picasa with custom database";

             // Location for the shortcut's icon
             MyShortcut.IconLocation = Application.StartupPath + @"\picasastarter.exe,0";

             // Create the shortcut at the given path
             MyShortcut.Save();
 
        }

        private void checkDBMenu1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
