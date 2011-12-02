using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Management;               // To be able to use ManagementObject
using System.Runtime.InteropServices;
using System.ComponentModel;           // Added to use kernel32.dll for creating symbolic links
using HelperClasses.Logger;            // Static logging class

namespace HelperClasses
{
    class IOHelper
    {

        internal static string VirtualDrive = "";
        internal static string VirtualDriveSource = "";
        internal static bool VirtualDriveMapped = false;

  
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
        public static void CreateHardLink(string newHardLinkPath, string existingFilePath)
        {
            if (!CreateHardLink(newHardLinkPath, existingFilePath, IntPtr.Zero))
            {
                Win32Exception ex = new Win32Exception(Marshal.GetLastWin32Error());
                throw new IOException("Error in CreateHardLink: " + ex.Message, ex);
            }
             
            int tryCount = 1;

            while(true)
            {
                // Check the hardlink's file size... as I got cases where a bad hardlink was created...
                FileInfo hardLink = new FileInfo(newHardLinkPath);
                long hardLinkFileSize = 0;

                if (hardLink.Exists)
                    hardLinkFileSize = hardLink.Length;
                if (hardLinkFileSize != 0)
                    return;
                else
                {
                    FileInfo existingFile = new FileInfo(existingFilePath);
                
                    if(existingFile.Exists && existingFile.Length == 0)
                        return;
                }

                if (tryCount > 1)
                    Log.Debug("CreateLink, second try");

                if (tryCount == 3)
                {
                    throw new IOException("Error Creating Hardlink. Source file " + existingFilePath +
                        ", Destination file: " + newHardLinkPath);
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

        /// <summary>
        /// Copies all files in a directory to another directory. This function never throws exceptions...
        /// 
        /// Remark: doesn't work recursive!
        /// </summary>
        /// <param name="directorySource"></param>
        /// <param name="directoryDest"></param>
        /// <returns></returns>
        public static bool TryCopyDirectory(string directorySource, string directoryDest)
        {
            // Copy PicasaButtons if there are that need to be visible in Picasa...
            try
            {
                DirectoryInfo dirSource = new DirectoryInfo(directorySource);
                FileInfo[] files = dirSource.GetFiles();
                DirectoryInfo dirDest = new DirectoryInfo(directoryDest);
                if (!dirDest.Exists)
                    dirDest.Create();

                foreach (FileInfo file in files)
                {
                    file.CopyTo(directoryDest + '\\' + file.Name, true); 
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return false;
            }

            return true;
        }

        public static bool TryDeleteFiles(string directory, string pattern)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(directory);
                FileInfo[] files = dir.GetFiles(pattern);

                foreach (FileInfo file in files)
                {
                    file.Delete();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return false;
            }

            return true;
        }


        [DllImport("kernel32.dll")]
        internal static extern bool DefineDosDevice(uint dwFlags, string lpDeviceName,
           string lpTargetPath);

        [DllImport("Kernel32.dll")]
        internal static extern uint QueryDosDevice(string lpDeviceName,
            StringBuilder lpTargetPath, uint ucchMax);

        internal const uint DDD_RAW_TARGET_PATH = 0x00000001;
        internal const uint DDD_REMOVE_DEFINITION = 0x00000002;
        internal const uint DDD_EXACT_MATCH_ON_REMOVE = 0x00000004;
        internal const uint DDD_NO_BROADCAST_SYSTEM = 0x00000008;
        internal const uint NO_ERROR = 0;


        const string MAPPED_FOLDER_INDICATOR = @"\??\";

        public static string GetMappedDriveName(string driveLetter)
        {
            // Make a WMI objectsearcher to find the info
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_LogicalDisk");

            foreach (ManagementObject queryObj in searcher.Get())
            {
                string curDriveLetter = (string)queryObj["Name"];
                if (curDriveLetter == driveLetter)
                {
                    string providerName = (string)queryObj["ProviderName"];

                    if (providerName != null)
                        return providerName;
                    else
                        return "";
                }
            }

            return "";
        }

        // ----------------------------------------------------------------------------------------
        // Class Name:		IOHelper
        // Procedure Name:	MapFolderToDrive
        // Purpose:			Map the folder to a drive letter unless it already exists
        // Parameters:
        //		- driveLetter (string)  : Drive letter in the format "C:" without a back slash
        //		- folderName (string)  : Folder to map without a back slash
        // ----------------------------------------------------------------------------------------
        internal static string MapFolderToDrive(string driveLetter, string folderName)
        {
            // Is this drive already mapped? If so, we don't remap it!

            //Leave it mapped if it is the same as before
            if (VirtualDrive == driveLetter &&
                VirtualDriveSource == folderName &&
                VirtualDriveMapped == true)
                return driveLetter;
            //Unmap previous driveLetter if different before remapping new
            if (VirtualDriveMapped == true)
            {
                bool xyz = false;
                xyz = UnmapVDrive();
            }

            if (Directory.Exists(driveLetter + "\\"))
                return "";
            string UNCPath = "";

            // Map the folder to the drive
            //Get UNC Path if the source is a network drive
            UNCPath = IOHelper.GetUNCPath(folderName);
            if ((UNCPath == folderName) && (!folderName.StartsWith( "\\\\")))
            {
                // Local Drive mapping
                //This works only for local drives
                bool xyz = false;
                xyz = DefineDosDevice(0, driveLetter, folderName);
                if (xyz)
                {
                    VirtualDrive = driveLetter;
                    VirtualDriveSource = folderName;
                    VirtualDriveMapped = true;
                    return driveLetter;
                }
                VirtualDriveMapped = false;
                return "";
            }
            else
            {
                //Map the network drive
                string xyz = "";
                xyz = MapUNCToDrive(driveLetter, UNCPath);
                if (xyz != "")
                {
                    VirtualDrive = driveLetter;
                    VirtualDriveSource = folderName;
                    VirtualDriveMapped = true;
                    return driveLetter;
                }
                VirtualDriveMapped = false;
                return "";
            }

        }

        // ----------------------------------------------------------------------------------------
        // Class Name:		IOHelper
        // Procedure Name:	UnmapFolderFromDrive
        // Purpose:			Unmap a drive letter. We only unmp the drive, if the
        //                  folder name matches.
        // Parameters:
        //		- driveLetter (string)  :   Drive letter to be released, the format "C:"
        //		- folderName (string)  :    Folder name that the drive is mapped to.
        // ----------------------------------------------------------------------------------------
        internal static string UnmapFolderFromDrive(string driveLetter, string folderName)
        {
            // Don't unmap if we didn't map it!

            if ((driveLetter == "") || (!Directory.Exists(driveLetter + "\\")))
                return "";
            if (VirtualDrive != driveLetter || 
                VirtualDriveSource != folderName ||
                VirtualDriveMapped != true)
                return "";
            bool xyz = false;
            xyz = UnmapVDrive();
            if (xyz == true)
                return driveLetter;
            return "";
  
        }

        // ----------------------------------------------------------------------------------------
        // Class Name:		IOHelper
        // Procedure Name:	bool UnmapVDrive
        // Purpose:			Unmap a virtual drive letter if we previously mapped it
        // Parameters:
        //		- driveLetter (string)  :   Drive letter to be released, the format "C:"
        //		- folderName (string)  :    Folder name that the drive is mapped to.
        // Returns true if drive was successfully unmapped
        // ----------------------------------------------------------------------------------------
        internal static bool UnmapVDrive()
        {
            // Don't unmap if we didn't map it!
            bool result = false;

            if (VirtualDriveMapped == true)
            {

                string UNCPath = "";

                //Get UNC Path if the source is a network drive
                UNCPath = IOHelper.GetUNCPath(VirtualDrive + "\\");
                if ((UNCPath == VirtualDrive + "\\") && (!VirtualDriveSource.StartsWith("\\\\")))
                {
                    // UnMap Local Drive
                    //This works only for local drives
                    bool xyz = false;
                    xyz = DefineDosDevice(DDD_REMOVE_DEFINITION, VirtualDrive, VirtualDriveSource);
                    if (xyz == false)
                        result = true;
                }
                else
                {
                    if ((UNCPath.StartsWith("\\\\")))
                    {
                        //UnMap the network drive
                        string xyz = "";
                        xyz = UnmapUNCFromDrive(VirtualDrive);
                        result = true;
                    }
                }

                VirtualDriveMapped = false;

            }
            VirtualDrive = "";
            VirtualDriveSource = "";
            return result;
        }

        /// <summary>
        /// Given a path, returns the UNC path or the original. (No exceptions
        /// are raised by this function directly). For example, "P:\2008-02-29"
        /// might return: "\\networkserver\Shares\Photos\2008-02-09"
        /// </summary>
        /// <param name="originalPath">The path to convert to a UNC Path</param>
        /// <returns>A UNC path. If a network drive letter is specified, the
        /// drive letter is converted to a UNC or network path. If the
        /// originalPath cannot be converted, it is returned unchanged.</returns>
        public static string GetUNCPath(string originalPath)
        {
            StringBuilder sb = new StringBuilder(512);
            int size = sb.Capacity;

            // look for the {LETTER}: combination ...
            if (originalPath.Length > 2 && originalPath[1] == ':')
            {
                // don't use char.IsLetter here - as that can be misleading
                // the only valid drive letters are a-z && A-Z.
                char c = originalPath[0];
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {
                    int error = WNetGetConnection(originalPath.Substring(0, 2),
                        sb, ref size);
                    if (error == 0)
                    {
                        DirectoryInfo dir = new DirectoryInfo(originalPath);

                        string path = Path.GetFullPath(originalPath)
                            .Substring(Path.GetPathRoot(originalPath).Length);
                        return Path.Combine(sb.ToString().TrimEnd(), path);
                    }
                }
            }

            return originalPath;
        }

        [DllImport("mpr.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int WNetGetConnection(
            [MarshalAs(UnmanagedType.LPTStr)] string localName,
            [MarshalAs(UnmanagedType.LPTStr)] StringBuilder remoteName,
            ref int length);

        [StructLayout(LayoutKind.Sequential)]

        public struct NETRESOURCE
        {
            public uint dwScope;
            public uint dwType;
            public uint dwDisplayType;
            public uint dwUsage;
            public string lpLocalName;
            public string lpRemoteName;
            public string lpComment;
            public string lpProvider;
        }

        //Connection Flags
        const uint CONNECT_UPDATE_PROFILE = 0x1;
        const uint CONNECT_INTERACTIVE = 0x8;
        const uint CONNECT_PROMPT = 0x10;
        const uint CONNECT_REDIRECT = 0x80;
        const uint CONNECT_COMMANDLINE = 0x800;
        const uint CONNECT_CMD_SAVECRED = 0x1000;

        //Resource types
        const uint RESOURCETYPE_DISK = 1;


       // ----------------------------------------------------------------------------------------
        // Class Name:		IOHelper
        // Procedure Name:	MapUNCToDrive, UnmapUNCFromDrive
        // Purpose:			Map the folder to a drive letter
        // Parameters:
        //		- driveLetter (string)  : Drive letter in the format "C:" without a back slash
        //		- folderName (string)  : Folder to map without a back slash
        //
        //Returns drive letter on success, null string on failure
        // ----------------------------------------------------------------------------------------

        [DllImport("mpr.dll")]
        static extern UInt32 WNetAddConnection2(ref NETRESOURCE lpNetResource, string lpPassword, string lpUsername, uint dwFlags);

        [DllImport("mpr.dll")]
        static extern uint WNetCancelConnection2(string lpName, uint dwFlags, bool bForce);
        
        // Map UNC to drive Letter if drive wasn't mapped previously
        internal static string MapUNCToDrive(string driveLetter, string UNCPath)
        {
            // This drive was not already mapped?
            bool mapped = DriveIsMapped(driveLetter);
            if (mapped)
                return ("");

            NETRESOURCE networkResource = new NETRESOURCE();
            networkResource.dwType = RESOURCETYPE_DISK;
            networkResource.lpLocalName = driveLetter;
            networkResource.lpRemoteName = UNCPath;
            networkResource.lpProvider = null;

            uint result = WNetAddConnection2(ref networkResource, null, null, 0);
            if (result != 0)
                return("");
            return driveLetter;
        }

        //Unmap drive: driveletter if it was mapped to UNCPath
        internal static string UnmapUNCFromDrive(string driveLetter)
        {
            uint result = WNetCancelConnection2(driveLetter, 0, true);
            if (result != NO_ERROR)
                return ("");
            return driveLetter;
        }


        // ----------------------------------------------------------------------------------------
        // Class Name:		IOHelper
        // Procedure Name:	DriveIsMappedTo
        // Purpose:			Returns the folder that a drive is mapped to. If not mapped, we return a blank.
        // Parameters:
        //		- driveLetter (string)  : Drive letter in the format "C:"
        // ----------------------------------------------------------------------------------------
        internal static string DriveIsMappedTo(string driveLetter)
        {
            StringBuilder volumeMap = new StringBuilder(512);
            string mappedVolumeName = "";

            // If it's not a mapped drive, just remove it from the list
            uint mapped = QueryDosDevice(driveLetter, volumeMap, (uint)512);
            if (mapped != 0)
                if (volumeMap.ToString().StartsWith(MAPPED_FOLDER_INDICATOR) == true)
                {
                    // It's a mapped drive, so return the mapped folder name
                    mappedVolumeName = volumeMap.ToString().Substring(4);
                }

            return mappedVolumeName;
        }

        // ----------------------------------------------------------------------------------------
        // Class Name:		IOHelper
        // Procedure Name:	DriveIsMapped
        // Purpose:			Returns true if a drive is mapped. If not mapped, we return false.
        // Parameters:
        //		- driveLetter (string)  : Drive letter in the format "C:"
        // ----------------------------------------------------------------------------------------

        internal static bool DriveIsMapped(string driveLetter)
        {
            StringBuilder volumeMap = new StringBuilder(512);
            //string mappedVolumeName = "";

            // If it's not a mapped drive, mapped will be 0
            uint mapped = QueryDosDevice(driveLetter, volumeMap, (uint)512);
            if (mapped != 0)
                return true;
            else
                return false;
        }

    }
}