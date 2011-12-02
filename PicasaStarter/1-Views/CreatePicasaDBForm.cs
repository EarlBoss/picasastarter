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
        //public string VirtualDrive = "";
        //public bool VirtualDriveRemapped = false;


        public CreatePicasaDBForm(string appSettingsDir)
        {
            InitializeComponent();


            AppSettingsDir = appSettingsDir;
            appSettingsBaseDir = Path.GetDirectoryName(AppSettingsDir);
            PicasaDB = new PicasaDB();
            PicDrivecomboBox.Text = "";
        }
        
        public CreatePicasaDBForm(PicasaDB picasaDB, string appSettingsDir, bool standardDatabase = false)
        {
            InitializeComponent();

            AppSettingsDir = appSettingsDir;
            appSettingsBaseDir = Path.GetDirectoryName(AppSettingsDir);
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
            if (EnablecheckBox.Checked == true && PicDrivecomboBox.Text != "")
            {
                string xyz = "";
                xyz = IOHelper.MapFolderToDrive(PicDrivecomboBox.Text, appSettingsBaseDir);
                if (xyz != PicDrivecomboBox.Text)
                {
                    MessageBox.Show("Virtual Drive not mapped Successfully \nDrive letter " + PicDrivecomboBox.Text + " Not Available");
                }
            }
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

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
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
            if (EnablecheckBox.Checked == true && PicDrivecomboBox.Text != "")
            {
                string xyz = "";
                xyz = IOHelper.MapFolderToDrive(PicDrivecomboBox.Text, appSettingsBaseDir);
                if (xyz != PicDrivecomboBox.Text)
                {
                    MessageBox.Show ("Virtual Drive not mapped Successfully \nDrive letter "+ PicDrivecomboBox.Text + " Not Available");
                }
            }
                

        }

        private void CreatePicasaDBForm_Load(object sender, EventArgs e)
        {

        }
    }
}
