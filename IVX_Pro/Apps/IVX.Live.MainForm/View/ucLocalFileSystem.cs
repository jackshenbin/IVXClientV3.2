using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormAppUtil.Common;
using System.IO;

namespace IVX.Live.MainForm.View
{
    public partial class ucLocalFileSystem : ucFileSystemBase
    {


        #region Constructors

        public ucLocalFileSystem()
        {
            InitializeComponent();
            PathSplit = "\\";
        }


        #endregion

        #region Private helper functions

        public void InitLocalRoot()
        {
            GetDirectoryList = GetLocalDirectoryList;
            GetFileList = GetLocalFileList;
            string pathDesktop = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop).TrimEnd('\\')+"\\";
            InitRoot(pathDesktop, "桌面");
            string[] root = Directory.GetLogicalDrives();
            foreach (var item in root)
            {
                InitRoot(item.TrimEnd('\\') + "\\", item.TrimEnd('\\') + "\\");

            }

        }

        List<string> GetLocalDirectoryList(string path)
        {
            string[] root = System.IO.Directory.GetDirectories(path);
            List<string> list = new List<string>();
            foreach (string s in root)
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(s);
                if ((di.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden
                    && (di.Attributes & FileAttributes.System) != FileAttributes.System
                    && (di.Attributes & FileAttributes.Temporary) != FileAttributes.Temporary)
                {
                    list.Add(di.Name);
                }
            }
            return list;
        }

        List<FileInfo> GetLocalFileList(string path)
        {

            List<FileInfo> list = new List<FileInfo>();
            string[] root = Directory.GetFiles(path);
            foreach (string s in root)
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(s);
                if ((fi.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden
                    && (fi.Attributes & FileAttributes.System) != FileAttributes.System
                    && (fi.Attributes & FileAttributes.Temporary) != FileAttributes.Temporary)
                {
                    list.Add(new FileInfo() { FileSize = (ulong)fi.Length, IsDir = false, Name = fi.Name });
                }
            }

            return list;
        }

        #endregion


    }
}
