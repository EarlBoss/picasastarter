using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PicasaStarter
{
    public partial class SelectDBForm : Form
    {
        public string ReturnDBName = null;
        public uint ReturnDBIndex = 0;
        private string returnDBName = null;
        private Settings _settings;
        public SelectDBForm(Settings settings)
        {
            InitializeComponent();
            _settings = settings;
        }

        private void SelectDBForm_Load(object sender, EventArgs e)
        {
            // Initialise all controls on the screen with the proper data
            ReFillPicasaDBList(false);

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
            textBoxDBBaseDir.Text = _settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].BaseDir;
            textBoxDBDescription.Text = _settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].Description;
        }



        private void buttonRunPicasa_Click(object sender, EventArgs e)
        {
            ReturnDBName = returnDBName;
            Close();
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
    }
}

