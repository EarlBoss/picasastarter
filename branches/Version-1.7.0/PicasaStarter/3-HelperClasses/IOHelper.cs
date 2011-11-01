using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Management;               // To be able to use ManagementObject
using System.Runtime.InteropServices;
using System.ComponentModel;           // Added to use kernel32.dll for creating symbolic links
using Logger;                          // To be able to log error messages;

namespace HelperClasses
{
    class IOHelper
    {
        public static void CreateSymbolicLink(string SymLinkFileName, string SymLinkDestination, bool CreateDirectorySymLink)
        {
            int dwFlags = 0;    // Default, create a file symbolic link;

            if (CreateDirectorySymLink == true)
                dwFlags = 1;

            // Create the symbolic link
            Boolean created;
            created = CreateSymbolicLink(SymLinkFileName, SymLinkDestination, dwFlags);

            if (created == true)
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

        [DllImport("kernel32.dll", EntryPoint = "CreateSymbolicLinkW", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern Boolean CreateSymbolicLink([In] string lpFileName, [In] string lpExistingFileName, int dwFlags);

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
            string objPath = string.Format("Win32_Directory.Name='{0}'", dirName);
            using (ManagementObject dir = new ManagementObject(objPath))
            {
                ManagementBaseObject outParams = dir.InvokeMethod("Delete", null, null);
                uint ret = (uint)(outParams.Properties["ReturnValue"].Value);
                if (ret != 0)
                    throw new IOException("DeleteRecursive failed with error code " + ret);
            }
        }

        /// <summary>
        /// Create a hardlink from "newHardlink" to "existingFile"
        /// </summary>
        /// <param name="newHardLink">The file to link from.</param>
        /// <param name="existingFile">The file to link to.</param>
        /// <returns></returns>
        public static void CreateHardLink(FileInfo newHardLink, FileInfo existingFile)
        {
            int tryCount = 1;

            while (true)
            {
                if (!CreateHardLink(newHardLink.FullName, existingFile.FullName,
                  IntPtr.Zero))
                {
                    Win32Exception ex = new Win32Exception(Marshal.GetLastWin32Error());
                    throw new IOException(ex.Message, ex);
                }

                // Check the hardlink's file size... as I got cases where a bad hardlink was created...
                long hardLinkFileSize = newHardLink.Length;
                if (hardLinkFileSize != 0)
                    break;
                else
                {
                    if (existingFile.Length == 0)
                        break;
                    else
                        newHardLink.Delete();
                }

                if (tryCount > 1)
                    Log.Debug("CreateLink, second try");

                if (tryCount == 3)
                {
                    throw new IOException("Error Creating Hardlink. Source file " + existingFile.FullName +
                        ",Destination file: " + newHardLink.FullName);
                }

                tryCount++;
            }
        }

        /// <summary>
        /// Create a hardlink from "lpFileName" to "lpExistingFileName"
        /// </summary>
        /// <param name="newHardLink">The file path to link from.</param>
        /// <param name="existingFile">The file path to link to.</param>
        /// <param name="lpSecurityAttributes">Security attributes you want to specify, or IntPtr.Zero for default behaviour</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool CreateHardLink(string lpFileName, string lpExistingFileName, IntPtr lpSecurityAttributes);

        /// <summary>
        ///   Sets the Normal attribute on any particular file.
        /// </summary>
        /// <param name="file"></param>
        public void SetNormalFileAttribute(string file)
        {
            FileAttributes attr = FileAttributes.Normal;
            File.SetAttributes(file, attr);
        }

        /// <summary>
        ///   This function compares like this
        ///       - Same filename = identical files
        ///       - Different file size = not identical
        ///       - Different modify date = not identical
        /// </summary>
        /// <param name="file1"></param>
        /// <param name="file2"></param>
        /// <param name="compareBinary"> Should the files be binary compared to be sure they are the same? </param>
        /// <returns></returns>
        /// <remarks>
        ///   This function can throw exceptions is a file isn't found or something like that...
        /// </remarks>
        public static bool Compare(FileInfo file1, FileInfo file2, bool compareBinary)
        {
            // If user has selected the same file as file one and file two....
            if ((file1 == file2))
            {
                return true;
            }

            // If the files are the same length and the difference in modify time equals 0 seconds... 
            // they are probably the same...
            // Remark: equals 0 seconds to eliminate differences in milliseconds, as my NAS apparently rounds to seconds
            if ((file1.Length == file2.Length)
                    && (DateTimeHelper.RoundToSecondPrecision(file1.LastWriteTime) == DateTimeHelper.RoundToSecondPrecision(file2.LastWriteTime)))
            {
                if (compareBinary == false)
                    return true;
                else
                    return CompareBinary(file1, file2);
            }
            else
                return false;
        }

        /// <summary>
        ///   This function compares like this
        ///       - Same filename = identical files
        ///       - Different file size = not identical
        ///       - Complete binary comparison of data
        /// </summary>
        /// <param name="file1"></param>
        /// <param name="file2"></param>
        /// <returns></returns>
        /// <remarks>
        ///   This function can throw exceptions is a file isn't foud or something like that...
        /// </remarks>
        public static bool CompareBinary(FileInfo file1, FileInfo file2)
        {
            // If user has selected the same file as file one and file two....
            if ((file1 == file2))
            {
                return true;
            }
            const int ReadBufferSize = 65536;   // 64 kB, blijkbaar een of andere buffergrootte van NTFS

            // Open a FileStream for each file.
            FileStream fileStream1 = default(FileStream);
            FileStream fileStream2 = default(FileStream);

            fileStream1 = new FileStream(file1.FullName, FileMode.Open, FileAccess.Read, FileShare.Read, ReadBufferSize, FileOptions.SequentialScan);
            fileStream2 = new FileStream(file2.FullName, FileMode.Open, FileAccess.Read, FileShare.Read, ReadBufferSize, FileOptions.SequentialScan);

            // If the files are not the same length...
            if ((fileStream1.Length != fileStream2.Length))
            {
                fileStream1.Close();
                fileStream2.Close();

                // File's are not equal.
                return false;
            }

            // Loop through data in the files until
            //  data in file 1 <> data in file 2 OR end of one of the files is reached.
            int count1 = ReadBufferSize;
            int count2 = ReadBufferSize;
            byte[] buffer1 = new byte[count1];
            byte[] buffer2 = new byte[count2];
            bool areFilesEqual = true;

            while (areFilesEqual == true)
            {
                count1 = fileStream1.Read(buffer1, 0, count1);
                count2 = fileStream2.Read(buffer2, 0, count2);

                // If one of the files are at his end... stop the loop
                if (count1 == 0 | count2 == 0)
                {
                    break;
                }

                // Check if the data read is identical
                for (int i = 0; i <= (count1 - 1); i++)
                {
                    if (buffer1[i] != buffer2[i])
                    {
                        areFilesEqual = false;
                        break;
                    }
                }
            }

            // Close the FileStreams.
            fileStream1.Close();
            fileStream2.Close();

            return areFilesEqual;
        }
    }
}