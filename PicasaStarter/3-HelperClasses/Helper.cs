using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Management;       // To be able to use ManagementObject
using System.Runtime.InteropServices;
using System.ComponentModel;   // Added to use kernel32.dll for creating symbolic links

namespace PicasaStarter
{
    class IOHelper
    {
        [DllImport("kernel32.dll", EntryPoint = "CreateSymbolicLinkW", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern Boolean CreateSymbolicLink([In] string lpFileName, [In] string lpExistingFileName, int dwFlags);

        public static void CreateSymbolicLink(string SymLinkFileName, string SymLinkDestination, bool CreateDirectorySymLink)
        {
            int dwFlags = 0;    // Default, create a file symbolic link;

            if (CreateDirectorySymLink == true)
                dwFlags = 1;

            // Create the symbolic link
            Boolean created;
            created = CreateSymbolicLink(SymLinkFileName, SymLinkDestination, dwFlags);

            if(created == true)
            {
                // In Windows 7, CreateSymbolicLink doesn't return false if a directory symlink couldn't be created...
                // so I just check if the symbolic link actually exists to be sure...
                if (CreateDirectorySymLink == true && Directory.Exists(SymLinkFileName) == false)
                    created = false;
            }

            if (created == false)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        public static void ClearAttributes(string currentDir)
        {
            if (Directory.Exists(currentDir))
            {
                string[] subDirs = Directory.GetDirectories(currentDir);
                foreach (string dir in subDirs)
                    ClearAttributes(dir);
                string[] files = files = Directory.GetFiles(currentDir);
                foreach (string file in files)
                    File.SetAttributes(file, FileAttributes.Normal);
            }
        }
        public static void DeleteRecursive(string currentDir)
        {
            string dirName = @currentDir;
            string objPath = string.Format("Win32_Directory.Name='{0}'",dirName );
            using (ManagementObject dir = new ManagementObject(objPath))
            {
                ManagementBaseObject outParams = dir.InvokeMethod("Delete", null, null);
                uint ret = (uint)(outParams.Properties["ReturnValue"].Value);
                if (ret != 0)
                    throw new IOException("DeleteRecursive failed with error code " + ret);
            }
        }
    }
}