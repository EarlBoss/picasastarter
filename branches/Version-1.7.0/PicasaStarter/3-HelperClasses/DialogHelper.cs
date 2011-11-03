using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PicasaStarter
{
    static class DialogHelper
    {
        public static string AskDirectoryPath(string InitialDirectory)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowNewFolderButton = true;
            fd.SelectedPath = InitialDirectory;

            if (fd.ShowDialog() == DialogResult.OK)
                return fd.SelectedPath;
            else
                return InitialDirectory;
        }
    }
}
