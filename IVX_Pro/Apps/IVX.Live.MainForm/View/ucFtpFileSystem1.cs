using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormAppUtil.Common;

namespace IVX.Live.MainForm.View
{
    public partial class ucFtpFileSystem1 : UserControl
    {
        public event EventHandler FilesDoubleClicked;
        const string NullValue = "无数据...";
        #region Fields

        private Dictionary<string, DevComponents.AdvTree.Node> m_DTDriver2Node = new Dictionary<string, DevComponents.AdvTree.Node>();

        private System.Drawing.Point startPoint = new System.Drawing.Point();

        private List<object> m_SelectedFiles = new List<object>();

        private string m_fileFilter = "";

        private bool isDoDrag = false;
        private string[] dragFileList = null;

        private string m_ftproot = "";
        #endregion

        #region Properties

        public List<object> SelectedFiles
        {
            get { return m_SelectedFiles; }
        }



        public string FileFilter
        {
            get { return m_fileFilter; }
            set { m_fileFilter = value; }
        }

        #endregion

        #region Constructors

        public ucFtpFileSystem1()
        {
            InitializeComponent();
            treeListFtpFile.Nodes.Clear();
            this.treeListFtpFile.BeforeExpand += new DevComponents.AdvTree.AdvTreeNodeCancelEventHandler(treeListFtpFile_BeforeExpand);
            this.treeListFtpFile.BeforeCollapse += new DevComponents.AdvTree.AdvTreeNodeCancelEventHandler(treeListFtpFile_BeforeCollapse);


        }


        #endregion

        #region Private helper functions

        public void InitHttpRoot(string urlroot)
        {

            m_ftproot = urlroot.TrimEnd(new char[] { '/' });
            DevComponents.AdvTree.Node snode = new DevComponents.AdvTree.Node();
            snode.Expanded = false;
            snode.Name = "root";
            snode.ImageIndex = 3;
            snode.Text = m_ftproot;
            snode.Cells.Add(new DevComponents.AdvTree.Cell(@"/"));
            snode.Cells.Add(new DevComponents.AdvTree.Cell("0"));
            snode.Cells.Add(new DevComponents.AdvTree.Cell("Root"));
            snode.Nodes.Add(new DevComponents.AdvTree.Node(NullValue));
            snode.NodeDoubleClick += new EventHandler(snode_NodeDoubleClick);
            
            treeListFtpFile.Nodes.Add(snode);
        }



        private void InitFolders(DevComponents.AdvTree.Node pNode)
        {
            if (pNode.Cells[3].Text != "Folder" && pNode.Cells[3].Text != "Root")
                return;

            string path = pNode.Cells[1].Text;

            treeListFtpFile.SuspendLayout();

            List<string> remoteFolderList = null;
            try
            {
                remoteFolderList = Framework.Container.Instance.FtpService.GetDirectoryList(path);

            }
            catch (FtpException)
            {
                Framework.Container.Instance.InteractionService.ShowMessageBox("无法连接FTP服务器，或获取HTTP文件列表失败。", Framework.Environment.PROGRAM_NAME);
                return;
            }
            //ws.GetFloders("");
            if (remoteFolderList != null && remoteFolderList.Count > 0)
                pNode.Nodes.Clear();

            foreach (string f in remoteFolderList)
            {
                string p = path + f + "/";
                DevComponents.AdvTree.Node snode = new DevComponents.AdvTree.Node();
                snode.Expanded = false;
                snode.Name = "folder";
                snode.ImageIndex = 1;
                snode.Text = f;
                snode.Cells.Add(new DevComponents.AdvTree.Cell(p));
                snode.Cells.Add(new DevComponents.AdvTree.Cell("0"));
                snode.Cells.Add(new DevComponents.AdvTree.Cell("Folder"));
                snode.Nodes.Add(new DevComponents.AdvTree.Node(NullValue));
                snode.NodeDoubleClick += new EventHandler(snode_NodeDoubleClick);
                pNode.Nodes.Add(snode);
            }


            InitFiles(path, pNode);
            treeListFtpFile.ResumeLayout();
        }

        private void InitFiles(string path, DevComponents.AdvTree.Node pNode)
        {

            List<FtpFileInfo> remoteFileList = null;
            try
            {
                remoteFileList = Framework.Container.Instance.FtpService.GetFilesDetailList(path);

            }
            catch (FtpException)
            {
                Framework.Container.Instance.InteractionService.ShowMessageBox("无法连接FTP服务器，或获取HTTP文件列表失败。", Framework.Environment.PROGRAM_NAME);

                return;
            }
            //ws.GetFloders("");

            foreach (FtpFileInfo f in remoteFileList)
            {
                if (!f.IsDir)
                {
                    string p = m_ftproot + path + f.Name;
                    DevComponents.AdvTree.Node snode = new DevComponents.AdvTree.Node();
                    snode.Expanded = false ;
                    snode.Name = "node";
                    snode.ImageIndex = 0;
                    snode.Text = f.Name;
                    snode.Cells.Add(new DevComponents.AdvTree.Cell(p));
                    snode.Cells.Add(new DevComponents.AdvTree.Cell(f.FileSize.ToString()));
                    snode.Cells.Add(new DevComponents.AdvTree.Cell("File"));
                    snode.NodeDoubleClick += new EventHandler(snode_NodeDoubleClick);
                    pNode.Nodes.Add(snode);

                }
            }

        }


        #endregion

        #region Event handlers

        void treeListFtpFile_BeforeExpand(object sender, DevComponents.AdvTree.AdvTreeNodeCancelEventArgs e)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            InitFolders(e.Node);

            if (e.Node.Cells[3].Text == "Folder")
                e.Node.ImageIndex = 2;

            Cursor.Current = currentCursor;
        }
        void treeListFtpFile_BeforeCollapse(object sender, DevComponents.AdvTree.AdvTreeNodeCancelEventArgs e)
        {
            if (e.Node.Cells[3].Text == "Folder")
                e.Node.ImageIndex = 1;
        }


        //private void treeListHttpFile_MouseDown(object sender, MouseEventArgs e)
        //{
        //    treeListFtpFile.ContextMenuStrip = null;
        //    DevExpress.XtraTreeList.TreeListHitInfo info = treeListFtpFile.CalcHitInfo(e.Location);
        //    if (info.Node != null)
        //    {
        //        if (info.Node.GetDisplayText("Type") == "File")
        //        {
        //            startPoint = e.Location;
        //            dragFileList = new string[1];
        //            dragFileList[0] = (string)info.Node.GetValue(0); ;
        //            isDoDrag = true;
        //        }
        //    }

        //}

        //private void treeListHttpFile_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == System.Windows.Forms.MouseButtons.Left && isDoDrag)
        //    {
        //        if (Math.Abs(startPoint.X - e.Location.X) > 5 || Math.Abs(startPoint.Y - e.Location.Y) > 5)
        //        {
        //            treeListFtpFile.DoDragDrop(dragFileList, DragDropEffects.Link);
        //        }
        //    }

        //}

        //private void treeListHttpFile_MouseUp(object sender, MouseEventArgs e)
        //{
        //    dragFileList = null;
        //    startPoint = new System.Drawing.Point();
        //    isDoDrag = false;

        //}

        //private void treeListHttpFile_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    m_SelectedFiles = null;
        //    DevExpress.XtraTreeList.TreeListHitInfo info = treeListFtpFile.CalcHitInfo(e.Location);
        //    if (info.Node != null)
        //    {
        //        m_SelectedFiles = new List<object>();
        //        foreach (TreeListNode node in treeListFtpFile.Selection)
        //        {
        //            if (!node.HasChildren)
        //            {
        //                if (node.GetDisplayText("Type") == "File")
        //                {
        //                    string filefullname = node.GetValue(0).ToString();
        //                    string filename = node.GetValue(1).ToString();
        //                    string filesize = node.GetValue(3).ToString();
        //                    m_SelectedFiles.Add(new object[] { filefullname, filename, filesize });
        //                }
        //            }
        //        }

        //        if (m_SelectedFiles.Count > 0 && FilesDoubleClicked != null)
        //        {
        //            FilesDoubleClicked(this, EventArgs.Empty);
        //        }
        //        m_SelectedFiles = null;
        //    }
        //}

        void snode_NodeDoubleClick(object sender, EventArgs e)
        {
            m_SelectedFiles = null;
            DevComponents.AdvTree.Node snode = sender as DevComponents.AdvTree.Node;
            //DevExpress.XtraTreeList.TreeListHitInfo info = treeListFtpFile.CalcHitInfo(e.Location);
            if (snode != null)
            {
                m_SelectedFiles = new List<object>();
                foreach (DevComponents.AdvTree.Node node in treeListFtpFile.SelectedNodes)
                {
                    if (!(node.HasChildNodes || node.Text == NullValue))
                    {
                        if (node.Cells[3].Text == "File")
                        {
                            string filefullname = node.Cells[1].Text;
                            string filename = node.Cells[0].Text;
                            string filesize = node.Cells[2].Text;
                            m_SelectedFiles.Add(new object[] { filefullname, filename, filesize });
                        }
                    }
                }

                if (m_SelectedFiles.Count > 0 && FilesDoubleClicked != null)
                {
                    FilesDoubleClicked(m_SelectedFiles, EventArgs.Empty);
                }
            }
        }

        #endregion

    }
}
