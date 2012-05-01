using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace PicasaStarter
{
    public partial class CopyExistingDBForm : Form
    {
        public string ReturnMessage = "Copy Existing Database Task: Nothing Done";
        public Color ReturnColor = Color.Red;
        public uint ReturnDBIndex = 0;
        private string returnDBName = null;
        public Settings _settings;
        private PicasaDB Db;

        public CopyExistingDBForm( PicasaDB database, Settings settings)
        {
            InitializeComponent();
            _settings = settings;
            Db = database;
        }

        private void CopyExistingDBForm_Load(object sender, EventArgs e)
        {
            // Initialise all controls on the screen with the proper data
            ReFillPicasaDBList(false);
            this.Text = "Copy Picasa Database to: " + Db.Name;
            textBoxDestDir.Text = Db.BaseDir + "\\Google"; 
            // If the saved defaultselectedDB is valid, select it in the list...
            int defaultSelectedDBIndex = listBoxPicasaDBs.FindStringExact(_settings.picasaDefaultSelectedDB);
            if (defaultSelectedDBIndex != ListBox.NoMatches)
                listBoxPicasaDBs.SelectedIndex = defaultSelectedDBIndex;
            ReturnMessage = "Copy Existing Database Task: Nothing Done"; 
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            //ReturnMessage = null;
            //ReturnMessage = "Copy Database Complete";
            Close();

        }

        private void listBoxPicasaDBs_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (listBoxPicasaDBs.SelectedIndex < 0)
                return;
            if (listBoxPicasaDBs.SelectedIndex >= _settings.picasaDBs.Count)
            {
                MessageBox.Show("Invalid item choosen from the database list");
                return;
            }

            returnDBName = _settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].Name;
            if (listBoxPicasaDBs.SelectedIndex == 0)
            {
                textBoxDBBaseDir.Text = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Google";
            }
            else
            {
                textBoxDBBaseDir.Text = _settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].BaseDir + "\\Google";

            }

            textBoxDBDescription.Text = _settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].Description;
        }

        private void ReFillPicasaDBList(bool selectLastItem)
        {
            listBoxPicasaDBs.BeginUpdate();
            listBoxPicasaDBs.SelectedIndex = -1;
            listBoxPicasaDBs.Items.Clear();
            // Set the tooltip for the DBList to the settings path
            for (int i = 0; i < _settings.picasaDBs.Count; i++)
            {
                listBoxPicasaDBs.Items.Add(_settings.picasaDBs[i].Name);
            }

            if (listBoxPicasaDBs.Items.Count > 0)
            {
                if (selectLastItem == true)
                    listBoxPicasaDBs.SelectedIndex = listBoxPicasaDBs.Items.Count - 1;
                else
                    listBoxPicasaDBs.SelectedIndex = 0;
            }
            listBoxPicasaDBs.EndUpdate();
        }

        private void textBoxDBDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonDBExplore_Click(object sender, EventArgs e)
        {
            //textBoxDBBaseDir.Text = SettingsHelper.GetFullDBDirectory(Db);

            try
            {
                Directory.CreateDirectory(textBoxDBBaseDir.Text);
                System.Diagnostics.Process.Start(textBoxDBBaseDir.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + ", when trying to open directory: " + textBoxDBBaseDir.Text);
            }
            //textBoxDBBaseDir.Text = DialogHelper.AskDirectoryPath(Db.BaseDir);
            //Db.BaseDir = textBoxDBBaseDir.Text;

        }

        private void buttonDestExplore_Click(object sender, EventArgs e)
        {
            //textBoxDestDir.Text = SettingsHelper.GetFullDBDirectory(Db);

            try
            {
                Directory.CreateDirectory(textBoxDestDir.Text);
                System.Diagnostics.Process.Start(textBoxDestDir.Text);
                ReturnColor = Color.Blue;
                ReturnMessage = "Copy Existing Database Task Complete";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + ", when trying to open directory: " + textBoxDestDir.Text);
            }
            //textBoxDBBaseDir.Text = DialogHelper.AskDirectoryPath(Db.BaseDir);
            //Db.BaseDir = textBoxDBBaseDir.Text;


        }
    }
}

