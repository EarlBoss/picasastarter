using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PicasaStarter
{
    public partial class ListPicasaButtonForm : Form
    {
        private Settings _settings;
        private string _appSettingsDir;

        public ListPicasaButtonForm(Settings settings, string appSettingsDir)
        {
            InitializeComponent();

            _settings = settings;
            _appSettingsDir = appSettingsDir;
            ReFillPicasaButtonList();
        }

        #region Private event handlers for buttons,...

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            CreatePicasaButtonForm createPicasaButtonForm = new CreatePicasaButtonForm(_appSettingsDir);

            createPicasaButtonForm.ShowDialog();

            if (createPicasaButtonForm.DialogResult == DialogResult.OK)
            {
                _settings.picasaButtons.ButtonList.Add(createPicasaButtonForm.PicasaButton);
                this.ReFillPicasaButtonList();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listBoxPicasaButtons.SelectedIndex == -1
                    || listBoxPicasaButtons.SelectedIndex >= _settings.picasaButtons.ButtonList.Count)
            {
                MessageBox.Show("Please choose a picasa button from the list first");
                return;
            }

            PicasaButton curButton = _settings.picasaButtons.ButtonList[listBoxPicasaButtons.SelectedIndex];
            CreatePicasaButtonForm createPicasaButtonForm = new CreatePicasaButtonForm(curButton, _appSettingsDir);

            createPicasaButtonForm.ShowDialog();

            if (createPicasaButtonForm.DialogResult == DialogResult.OK)
            {
                _settings.picasaButtons.ButtonList[listBoxPicasaButtons.SelectedIndex] = createPicasaButtonForm.PicasaButton;
                this.ReFillPicasaButtonList();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxPicasaButtons.SelectedIndex == -1
                    || listBoxPicasaButtons.SelectedIndex >= _settings.picasaButtons.ButtonList.Count)
            {
                MessageBox.Show("Please choose a picasa button from the list first");
                return;
            }

            _settings.picasaButtons.ButtonList.RemoveAt(listBoxPicasaButtons.SelectedIndex);
            this.ReFillPicasaButtonList();
        }

        #endregion

        #region Private helper functions

        private void ReFillPicasaButtonList()
        {
            listBoxPicasaButtons.BeginUpdate();
            listBoxPicasaButtons.SelectedIndex = -1;
            listBoxPicasaButtons.Items.Clear();

            for (int i = 0; i < _settings.picasaButtons.ButtonList.Count; i++)
            {
                listBoxPicasaButtons.Items.Add(_settings.picasaButtons.ButtonList[i].Label);
            }

            if (listBoxPicasaButtons.Items.Count > 0)
                listBoxPicasaButtons.SelectedIndex = 0;

            listBoxPicasaButtons.EndUpdate();
        }

        #endregion

        private void listBoxPicasaButtons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPicasaButtons.SelectedIndex < 0)
            {
                textBoxDescription.Text = "";
                return;
            }

            if (listBoxPicasaButtons.SelectedIndex >= _settings.picasaButtons.ButtonList.Count)
            {
                MessageBox.Show("Invalid item choosen from the list");
                return;
            }

            textBoxDescription.Text = _settings.picasaButtons.ButtonList[listBoxPicasaButtons.SelectedIndex].Description;
        }
    }
}