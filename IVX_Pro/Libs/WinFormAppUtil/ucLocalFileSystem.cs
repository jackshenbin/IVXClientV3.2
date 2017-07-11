using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using System.Diagnostics;
using System.IO;
using DevExpress.XtraTreeList;
// using BOCOM.IVX.Framework;

namespace WinFormAppUtil
{
    public partial class ucLocalFileSystem : UserControl
    {
        public event EventHandler FilesDoubleClicked;

        #region Fields

        private Dictionary<string, TreeListNode> m_DTDriver2Node = new Dictionary<string, TreeListNode>();

        private System.Drawing.Point startPoint = new System.Drawing.Point();

        private List<string> m_SelectedFiles = new List<string>();

        private string m_fileFilter = "";

        private bool isDoDrag = false;
        private string[] dragFileList = null;

        #endregion

        #region Properties

        public List<string> SelectedFiles
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

        public ucLocalFileSystem()
        {
            InitializeComponent();

            this.treeListLocalFile.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.treeList1_GetStateImage);
            this.treeListLocalFile.GetSelectImage += new DevExpress.XtraTreeList.GetSelectImageEventHandler(this.treeList1_GetSelectImage);
            this.treeListLocalFile.GetPreviewText += new DevExpress.XtraTreeList.GetPreviewTextEventHandler(this.treeList1_GetPreviewText);
            this.treeListLocalFile.BeforeExpand += new DevExpress.XtraTreeList.BeforeExpandEventHandler(this.treeList1_BeforeExpand);
            this.treeListLocalFile.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            
            InitDrives();
        }
        
        #endregion

        #region Private helper functions

        private bool HasFiles(string path)
        {
            string[] root = Directory.GetFiles(path);
            if (root.Length > 0) return true;
            root = Directory.GetDirectories(path);
            if (root.Length > 0) return true;
            return false;
        }

        private TreeListNode InitFolders(TreeListNode pNode, CheckState check, string selectFolderName)
        {
            DirectoryInfo di;
            TreeListNode selectedNode = null;
            TreeListNode node;

            string path = pNode.GetDisplayText("FullName");

            treeListLocalFile.BeginUnboundLoad();

            try
            {
                string[] root = Directory.GetDirectories(path);
                foreach (string s in root)
                {
                    try
                    {
                        di = new DirectoryInfo(s);
                        if ((di.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden
                            && (di.Attributes & FileAttributes.System) != FileAttributes.System
                            && (di.Attributes & FileAttributes.Temporary) != FileAttributes.Temporary)
                        {
                            node = treeListLocalFile.AppendNode(new object[] { s, di.Name, "Folder", null, di.Attributes, check }, pNode);
                            node.HasChildren = HasFiles(s);
                            if (node.HasChildren)
                            {
                                node.Tag = true;
                            }

                            if (string.Compare(di.Name, selectFolderName, true) == 0)
                            {
                                selectedNode = node;
                            }
                        }
                    }
                    catch { }
                }
            }
            catch { }
            InitFiles(path, pNode, check);
            treeListLocalFile.EndUnboundLoad();
            return selectedNode;
        }

        private void InitFiles(string path, TreeListNode pNode, CheckState check)
        {
            TreeListNode node;
            FileInfo fi;
            try
            {
                string[] root = Directory.GetFiles(path);
                foreach (string s in root)
                {
                    fi = new FileInfo(s);
                    if (string.IsNullOrEmpty( m_fileFilter ) || m_fileFilter.ToUpper().Contains(fi.Extension.ToUpper()))
                    {
                        if ((fi.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden
                            && (fi.Attributes & FileAttributes.System) != FileAttributes.System
                            && (fi.Attributes & FileAttributes.Temporary) != FileAttributes.Temporary)
                        {
                            node = treeListLocalFile.AppendNode(new object[] { s, fi.Name, "File", fi.Length, fi.Attributes, check }, pNode);
                            node.HasChildren = false;
                        }
                    }
                }
            }
            catch { }
        }

        private void InitDrives()
        {
            treeListLocalFile.BeginUnboundLoad();
            TreeListNode node;
            try
            {
                string pathDesktop = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
                node = treeListLocalFile.AppendNode(new object[] { pathDesktop, "桌面", "Logical Driver", null, null, CheckState.Unchecked }, null);
                node.HasChildren = true;
                node.Tag = true;
                m_DTDriver2Node.Add(pathDesktop.ToLower(), node);

                string[] root = Directory.GetLogicalDrives();

                foreach (string s in root)
                {
                    node = treeListLocalFile.AppendNode(new object[] { s, s, "Logical Driver", null, null, CheckState.Unchecked }, null);
                    node.HasChildren = true;
                    node.Tag = true;
                    m_DTDriver2Node.Add(s.ToLower(), node);
                }
            }
            catch { }

            // Select last accessed folder
            string recentFolder = WinFormAppUtil.AppContainer.Instance.RecentLoadVideoFolder;
            if (!string.IsNullOrEmpty(recentFolder) && Directory.Exists(recentFolder))
            {
                string driver = Directory.GetDirectoryRoot(recentFolder);
                TreeListNode rootNode = m_DTDriver2Node[driver.ToLower()];

                if (rootNode != null)
                {
                    string[] segs = recentFolder.Substring(driver.Length).Split('\\');
                    if (segs.Length > 0)
                    {
                        TreeListNode parentNode = rootNode;
                        for (int i = 0; i < segs.Length; i++)
                        {
                            parentNode.Expanded = true;
                            if (string.IsNullOrEmpty(segs[i]))
                            {
                                // 碰到根目录时， 会segs[0] 为空， 需要跳出
                                break;
                            }
                            else
                            {
                                parentNode = GetChildNode(parentNode, segs[i]);
                                if (parentNode == null)
                                {
                                    Debug.Assert(false);
                                    break;
                                }
                            }
                        }

                        if (parentNode != null)
                        {
                            parentNode.Expanded = true;
                            treeListLocalFile.Selection.Clear();
                            treeListLocalFile.SetFocusedNode(parentNode);
                            treeListLocalFile.Selection.Add(parentNode);
                        }
                    } // endof if (segs.Length > 0)
                }
            }

            treeListLocalFile.EndUnboundLoad();
        }

        private TreeListNode GetChildNode(TreeListNode parentNode, string fileName)
        {
            TreeListNode nodeRet = null;
            foreach (TreeListNode child in parentNode.Nodes)
            {
                if (string.Compare(child[1].ToString(), fileName, true) == 0)
                {
                    nodeRet = child;
                    break;
                }
            }

            return nodeRet;
        }

        private void SetCheckedNode(TreeListNode node)
        {
            CheckState check = (CheckState)node.GetValue("Check");
            if (check == CheckState.Indeterminate || check == CheckState.Unchecked) check = CheckState.Checked;
            else check = CheckState.Unchecked;
            treeListLocalFile.FocusedNode = node;
            treeListLocalFile.BeginUpdate();
            node["Check"] = check;

            SetCheckedChildNodes(node, check);
            SetCheckedParentNodes(node, check);
            treeListLocalFile.EndUpdate();
        }

        private void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i]["Check"] = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }

        private void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    if (!check.Equals(node.ParentNode.Nodes[i]["Check"]))
                    {
                        b = !b;
                        break;
                    }
                }
                node.ParentNode["Check"] = b ? CheckState.Indeterminate : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }

        bool isAcepedVideoFile(string file)
        {
            return true;//不做文件类型检查
            //FileInfo fi = new FileInfo(file);
            //return (Framework.Environment.AcepedVideoFile.IndexOf(fi.Extension) >= 0);
        }

        #endregion

        public void SelectFolder(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                string dir = Path.GetDirectoryName(path);
                if (Directory.Exists(dir))
                {
                    char[] slashes = "\\".ToCharArray();
                    string[] segs = dir.Split(slashes);

                    this.treeListLocalFile.SuspendLayout();

                    TreeListNodes treeNodes = this.treeListLocalFile.Nodes;
                    bool matched = false;
                    TreeListNode leafNode = null;
                    for (int i = 0; i < segs.Length; i++)
                    {
                        matched = false;
                        foreach (TreeListNode node in treeNodes)
                        {
                            if (string.Compare(segs[i], node.GetDisplayText(1).Trim(slashes), false) == 0)
                            {
                                matched = true;
                                node.Expanded = true;
                                leafNode = node;
                                treeNodes = node.Nodes;
                                break;
                            }
                        }

                        if (!matched)
                        {
                            break;
                        }
                    }

                    this.treeListLocalFile.ResumeLayout();

                    if (matched && leafNode != null)
                    {
                        treeListLocalFile.FocusedNode = null;

                        leafNode.Expanded = true;
                        leafNode.Selected = true;
                        treeListLocalFile.FocusedNode = leafNode;
                    }
                }
            }
        }

        #region Event handlers

        private void treeList1_BeforeExpand(object sender, DevExpress.XtraTreeList.BeforeExpandEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                InitFolders(e.Node, (CheckState)e.Node.GetValue("Check"), string.Empty);
                e.Node.Tag = null;
                Cursor.Current = currentCursor;
            }
        }

        private void treeList1_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            if (e.Node.GetDisplayText("Type") == "Folder")
                e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
            else if (e.Node.GetDisplayText("Type") == "File") e.NodeImageIndex = 2;
            else e.NodeImageIndex = 3;
        }

        private void treeList1_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            CheckState check = (CheckState)e.Node.GetValue("Check");
            if (check == CheckState.Unchecked)
                e.NodeImageIndex = 0;
            else if (check == CheckState.Checked)
                e.NodeImageIndex = 1;
            else e.NodeImageIndex = 2;
        }

        private void treeList1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
                SetCheckedNode(treeListLocalFile.FocusedNode);
            if (e.KeyData == Keys.Enter)
            {
                if (treeListLocalFile.FocusedNode.GetDisplayText("Type") == "File")
                {
                    try
                    {
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo.FileName = treeListLocalFile.FocusedNode.GetDisplayText("FullName");
                        process.StartInfo.Verb = "Open";
                        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                        process.Start();
                    }
                    catch { }
                }
                else
                    if (treeListLocalFile.FocusedNode.HasChildren) treeListLocalFile.FocusedNode.Expanded = !treeListLocalFile.FocusedNode.Expanded;
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }

        private void treeList1_GetPreviewText(object sender, DevExpress.XtraTreeList.GetPreviewTextEventArgs e)
        {
            e.PreviewText = e.Node.GetDisplayText("FullName");
        }

        private void treeList1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TreeListHitInfo hInfo = treeListLocalFile.CalcHitInfo(e.Location);
                if (hInfo.HitInfoType == HitInfoType.StateImage)
                    SetCheckedNode(hInfo.Node);
            }
        }

        private void treeListLocalFile_MouseDown(object sender, MouseEventArgs e)
        {
            treeListLocalFile.ContextMenuStrip = null;
            DevExpress.XtraTreeList.TreeListHitInfo info = treeListLocalFile.CalcHitInfo(e.Location);
            if (info.Node != null)
            {
                if (info.Node.GetDisplayText("Type") == "File")
                {
                    startPoint = e.Location;
                    dragFileList = new string[1];
                    dragFileList[0] = (string)info.Node.GetValue(0); ;
                    isDoDrag = true;
                }
            }

        }

        private void treeListLocalFile_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && isDoDrag)
            {
                if (Math.Abs(startPoint.X - e.Location.X) > 5 || Math.Abs(startPoint.Y - e.Location.Y) > 5)
                {
                    treeListLocalFile.DoDragDrop(dragFileList, DragDropEffects.Link);
                }
            }

        }

        private void treeListLocalFile_MouseUp(object sender, MouseEventArgs e)
        {
            dragFileList = null;
            startPoint = new System.Drawing.Point();
            isDoDrag = false;

        }

        private void treeListLocalFile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            m_SelectedFiles = null;
            DevExpress.XtraTreeList.TreeListHitInfo info = treeListLocalFile.CalcHitInfo(e.Location);
            if (info.Node != null)
            {
                m_SelectedFiles = new List<string>();
                foreach (TreeListNode node in treeListLocalFile.Selection)
                {
                    if (!node.HasChildren)
                    {
                        string file = node.GetValue(0).ToString();
                        if (File.Exists(file))
                        {
                            m_SelectedFiles.Add(file);
                        }
                    }
                }

                if (m_SelectedFiles.Count > 0 && FilesDoubleClicked != null)
                {
                    FilesDoubleClicked(this, EventArgs.Empty);
                }
                m_SelectedFiles = null;
            }
        }
        #endregion
    }
}
