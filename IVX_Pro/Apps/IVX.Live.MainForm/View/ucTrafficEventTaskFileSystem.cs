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
using IVX.Live.ViewModel;
using DevComponents.AdvTree;
using IVX.DataModel;

namespace IVX.Live.MainForm.View
{
    public partial class ucTrafficEventTaskFileSystem : UserControl
    {

        public event Action<SearchItemV3_1> SelectedTask;
        TaskManagementMAViewModel m_viewModel;

        #region Constructors

        public ucTrafficEventTaskFileSystem()
        {
            InitializeComponent();
            m_viewModel = new TaskManagementMAViewModel();
        }


        #endregion

        #region Private helper functions

        public void InitTaskRoot()
        {
            var list = m_viewModel.GetAllTrafficEventTaskItems();
            InitTree(advTreeUnSel, list);

        }

        public void SetSelectedTask(SearchItemV3_1 item)
        {
            Node node = advTreeUnSel.FindNodeByName(advTreeUnSel.Name + "_" + item.CameraID);
            if (node != null)
            {
                SelectedNode(node);
            }

        }

        private void InitTree(AdvTree tree, List<SearchItemV3_1> list)
        {
            advTreeUnSel.Nodes.Clear();
            foreach (SearchItemV3_1 si in list)
            {
                Node node = tree.FindNodeByName(tree.Name + "_" + si.CameraID);
                if (node == null)
                {
                    Node newnode = new Node(si.CameraName);
                    newnode.Name = tree.Name + "_" + si.CameraID;
                    newnode.Tag = si;
                    tree.Nodes.Add(newnode);
                }
            }
        }


        #endregion

        private void advTreeUnSel_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            SelectedNode(e.Node);
        }

        private void SelectedNode(Node e)
        {
            bool isselected = e.ImageIndex == 4;
            foreach (Node n in advTreeUnSel.Nodes)
            {
                n.ImageIndex = -1;
            }
            if (!isselected)
            {
                e.ImageIndex = 4;
                if (SelectedTask != null)
                {
                    SearchItemV3_1 si = e.Tag as SearchItemV3_1;
                    SelectedTask(si);
                }
            }
            else
            {
                if (SelectedTask != null)
                {
                    SelectedTask(null);
                }
            }
        }


    }
}
