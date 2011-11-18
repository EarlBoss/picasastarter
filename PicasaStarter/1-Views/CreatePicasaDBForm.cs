using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HelperClasses;
using System.IO;

namespace PicasaStarter
{
    public partial class CreatePicasaDBForm : Form
    {
        public PicasaDB PicasaDB { get; private set; }
        private string AppSettingsDir = "";
        private string appSettingsBaseDir = "";
        private string driveToUnmap = "";


        public CreatePicasaDBForm()
        {
            InitializeComponent();


            PicasaDB = new PicasaDB();
        }
        
        public CreatePicasaDBForm(PicasaDB picasaDB, string appSettingsDir, bool standardDatabase = false)
        {
            InitializeComponent();

            AppSettingsDir = appSettingsDir;
            PicasaDB = new PicasaDB(picasaDB);

            textBoxBackupDir.Text = PicasaDB.BackupDir;
            textBoxDBBaseDir.Text = PicasaDB.BaseDir;
            textBoxDBDescription.Text = PicasaDB.Description;
            textBoxDBName.Text = PicasaDB.Name;
            PicDrivecomboBox.Text = PicasaDB.PictureVirtualDrive;
            EnablecheckBox.Checked = PicasaDB.EnableVirtualDrive;
            if (standardDatabase == true)
            {
                textBoxDBName.Enabled = false;
                textBoxDBDescription.Enabled = false;
                buttonBrowseDBBaseDir.Enabled = false;
                PicDrivecomboBox.Text = "C:";
                PicDrivecomboBox.Enabled = false;
                EnablecheckBox.Checked = false;
                EnablecheckBox.Enabled = false;
            }
        }

        private void buttonBrowseDBBaseDir_Click(object sender, EventArgs e)
        {
            textBoxDBBaseDir.Text = DialogHelper.AskDirectoryPath(PicasaDB.BaseDir);
        }

        private void buttonDBOpenFullDir_Click(object sender, EventArgs e)
        {
            string DBFullDir = SettingsHelper.GetFullDBDirectory(PicasaDB);

            try
            {
                Directory.CreateDirectory(DBFullDir);
                System.Diagnostics.Process.Start(DBFullDir);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + ", when trying to open directory: " + DBFullDir);
            }
        }

        private void buttonBackupDir_Click(object sender, EventArgs e)
        {
            textBoxBackupDir.Text = DialogHelper.AskDirectoryPath(PicasaDB.BackupDir);
        }

        private void textBoxDBBaseDir_TextChanged(object sender, EventArgs e)
        {
            PicasaDB.BaseDir = textBoxDBBaseDir.Text;
            textBoxDBFullDir.Text = SettingsHelper.GetFullDBDirectory(PicasaDB);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            PicasaDB.BackupDir = textBoxBackupDir.Text;
            PicasaDB.BaseDir = textBoxDBBaseDir.Text;
            PicasaDB.Description = textBoxDBDescription.Text;
            PicasaDB.Name = textBoxDBName.Text;
            PicasaDB.PictureVirtualDrive = PicDrivecomboBox.Text;
            PicasaDB.EnableVirtualDrive = EnablecheckBox.Checked;
            if (driveToUnmap != "")
            {
                string xyz;
                xyz = IOHelper.UnmapFolderFromDrive(driveToUnmap, appSettingsBaseDir);
                driveToUnmap = "";
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (driveToUnmap != "")
            {
                string xyz;
                xyz = IOHelper.UnmapFolderFromDrive(driveToUnmap, appSettingsBaseDir);
                driveToUnmap = "";
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonCreateShortcut_Click(object sender, EventArgs e)
        {
            CreateShortcutDialog createShortcutDialog = new CreateShortcutDialog(PicasaDB.Name);
            DialogResult result = createShortcutDialog.ShowDialog();
        }


        private void PicDrivecomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EnablecheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonDoVDNow_Click(object sender, EventArgs e)
        {
            //Map folder or Path to drive letter if not already mapped

            if (driveToUnmap != "")
            {
                string xyz;
                xyz = IOHelper.UnmapFolderFromDrive(driveToUnmap, appSettingsBaseDir);
                driveToUnmap = "";
            }

            appSettingsBaseDir = Path.GetDirectoryName(AppSettingsDir);
            driveToUnmap = IOHelper.MapFolderToDrive(PicDrivecomboBox.Text, appSettingsBaseDir);

        }
    }
}
