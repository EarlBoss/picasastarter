using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PicasaStarter
{
    static class DialogHelper
    {
        public static string AskDirectoryPath(string InitialDirectory = "", string DirMessage = "")
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowNewFolderButton = true;

            if (InitialDirectory != "")
                fd.SelectedPath = InitialDirectory;

            if (DirMessage != "")
                fd.Description = DirMessage;

            if (fd.ShowDialog() == DialogResult.OK)
                return fd.SelectedPath;
            else
                return InitialDirectory;
        }
        public static string AskExistingDBPath(string InitialDirectory = "")
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowNewFolderButton = false;

            if (InitialDirectory != "")
                fd.SelectedPath = InitialDirectory;

            if (fd.ShowDialog() == DialogResult.OK)
                return fd.SelectedPath;
            else
                return InitialDirectory;
        }
    }
}
