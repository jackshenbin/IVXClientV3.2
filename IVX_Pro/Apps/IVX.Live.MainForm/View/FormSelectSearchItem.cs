using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.AdvTree;
using IVX.DataModel;
using IVX.Live.MainForm.Service;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class FormSelectSearchItem : UILogics.FormBase
    {
        public List<SearchItemV3_1> SearchItemList
        {
            get
            {
                if (m_viewModel != null)
                {
                    return m_viewModel.SelectedItems;
                }
                else
                    return new List<SearchItemV3_1>();
            }
        }

        SelectSearchItemViewModel m_viewModel;
        public FormSelectSearchItem()
        {
            InitializeComponent();
            m_viewModel = new SelectSearchItemViewModel();
        }

        public override void UpdateUI()
        {
        }

        public override void Clear()
        {
        }

        private void FormExportList_Load(object sender, EventArgs e)
        {

        }

        public void InitSelectedList(List<SearchItemV3_1> list)
        {
            m_viewModel.ClearSelection();

            if (list!=null && list.Count>0)
                list.ForEach(item => m_viewModel.AddSelectedItem(item));

            InitTree(advTreeUnSel, m_viewModel.UnSelectedItems);
            InitTree(advTreeSel, m_viewModel.SelectedItems);
            labelSelectedCount.Text = "已经选择" + m_viewModel.SelectedItems.Count + "项";
        }

        private void InitTree(AdvTree tree, List<SearchItemV3_1> list)
        {
            foreach (Node n in tree.Nodes)
            {
                n.Visible = false;
            }
            foreach (SearchItemV3_1 si in list)
            {
                Node node = tree.FindNodeByName(tree.Name + "_" + si.CameraID);
                if (node == null)
                {
                    Node newnode = new Node("["+si.TaskId+"]"+si.CameraName);
                    newnode.Name = tree.Name + "_" + si.CameraID;
                    newnode.Tag = si;
                    tree.Nodes.Add(newnode);
                }
                else
                    node.Visible = true;
            }
        }


        private void FormExportList_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            foreach (Node item in advTreeUnSel.SelectedNodes)
	        {
                SearchItemV3_1 si = item.Tag as SearchItemV3_1;
                if(si!=null)
                    m_viewModel.AddSelectedItem(si);
	        }
            InitTree(advTreeUnSel, m_viewModel.UnSelectedItems);
            InitTree(advTreeSel, m_viewModel.SelectedItems);
            labelSelectedCount.Text = "已经选择" + m_viewModel.SelectedItems.Count + "项";

        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            foreach (Node item in advTreeSel.SelectedNodes)
            {
                SearchItemV3_1 si = item.Tag as SearchItemV3_1;
                if (si != null)
                    m_viewModel.RemoveSelectedItem(si);
            }
            InitTree(advTreeUnSel, m_viewModel.UnSelectedItems);
            InitTree(advTreeSel, m_viewModel.SelectedItems); 
            labelSelectedCount.Text = "已经选择" + m_viewModel.SelectedItems.Count + "项";

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            m_viewModel.ClearSelection();
            InitTree(advTreeUnSel, m_viewModel.UnSelectedItems);
            InitTree(advTreeSel, m_viewModel.SelectedItems);
            labelSelectedCount.Text = "已经选择" + m_viewModel.SelectedItems.Count + "项";

        }

        private void advTreeUnSel_AfterNodeDrop(object sender, TreeDragDropEventArgs e)
        {
            foreach (Node item in e.Nodes)
            {
                SearchItemV3_1 si = item.Tag as SearchItemV3_1;
                if (si != null)
                    m_viewModel.RemoveSelectedItem(si);
            }
            InitTree(advTreeUnSel, m_viewModel.UnSelectedItems);
            InitTree(advTreeSel, m_viewModel.SelectedItems);
            labelSelectedCount.Text = "已经选择" + m_viewModel.SelectedItems.Count + "项";
        }

        private void advTreeSel_AfterNodeDrop(object sender, TreeDragDropEventArgs e)
        {
            foreach (Node item in e.Nodes)
            {
                SearchItemV3_1 si = item.Tag as SearchItemV3_1;
                if (si != null)
                    m_viewModel.AddSelectedItem(si);
            }
            InitTree(advTreeUnSel, m_viewModel.UnSelectedItems);
            InitTree(advTreeSel, m_viewModel.SelectedItems);
            labelSelectedCount.Text = "已经选择" + m_viewModel.SelectedItems.Count + "项";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void advTreeUnSel_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            foreach (Node item in advTreeUnSel.SelectedNodes)
            {
                SearchItemV3_1 si = item.Tag as SearchItemV3_1;
                if (si != null)
                    m_viewModel.AddSelectedItem(si);
            }
            InitTree(advTreeUnSel, m_viewModel.UnSelectedItems);
            InitTree(advTreeSel, m_viewModel.SelectedItems);
            labelSelectedCount.Text = "已经选择" + m_viewModel.SelectedItems.Count + "项";

        }

        private void advTreeSel_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            foreach (Node item in advTreeSel.SelectedNodes)
            {
                SearchItemV3_1 si = item.Tag as SearchItemV3_1;
                if (si != null)
                    m_viewModel.RemoveSelectedItem(si);
            }
            InitTree(advTreeUnSel, m_viewModel.UnSelectedItems);
            InitTree(advTreeSel, m_viewModel.SelectedItems);
            labelSelectedCount.Text = "已经选择" + m_viewModel.SelectedItems.Count + "项";

        }


    }
}
