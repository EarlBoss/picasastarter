using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PicasaStarter
{
    public partial class CopyExistingDBForm : Form
    {
        public string ReturnDBName = null;
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

            // If the saved defaultselectedDB is valid, select it in the list...
            int defaultSelectedDBIndex = listBoxPicasaDBs.FindStringExact(_settings.picasaDefaultSelectedDB);
            if (defaultSelectedDBIndex != ListBox.NoMatches)
                listBoxPicasaDBs.SelectedIndex = defaultSelectedDBIndex;
 
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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            ReturnDBName = null;
            Close();

        }

        private void buttonCopyDB_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copy the database in this");
            return;
        }
    }
}

