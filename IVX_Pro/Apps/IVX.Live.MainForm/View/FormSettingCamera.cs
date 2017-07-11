using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class FormSettingCamera : UILogics.FormBase
    {
        private SettingViewModel m_viewModel;
        public FormSettingCamera()
        {
            InitializeComponent();
            UseMdiDefaultWindow(true);
            ShowStatusBar = false;
        }

        public override void UpdateUI()
        {
            if (m_viewModel!=null)
            {
                advTreeVideoSupplier.DataSource = m_viewModel.VideoSupplierList;

            }
        }

        public override void Clear()
        {
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            m_viewModel = new SettingViewModel();
            advTreeVideoSupplier.DataSource = m_viewModel.VideoSupplierList;
        }

        private void advTree4_BeforeNodeSelect(object sender, DevComponents.AdvTree.AdvTreeNodeCancelEventArgs e)
        {
            if (e.Node == null)
            {
                advTreeCamera.DataSource = null; 
                return;
            }

            advTreeCamera.DataSource = m_viewModel.GetCameraListByVideoSupplierID(Convert.ToUInt32( e.Node.Cells[0].Text));
        }

        private void advTree4_DataSourceChanged(object sender, EventArgs e)
        {
            foreach (DevComponents.AdvTree.Node item in advTreeVideoSupplier.Nodes)
            {
                item.Cells[7].Text = "<a href=\"del\">删除</a>";
            }
        }

        private void advTree4_MarkupLinkClick(object sender, DevComponents.AdvTree.MarkupLinkClickEventArgs e)
        {
            if (e.HRef == "del")
            {
                m_viewModel.DelVideoSupplierByID(Convert.ToUInt32(advTreeVideoSupplier.SelectedNode.Cells[0].Text));
                advTreeVideoSupplier.DataSource = m_viewModel.VideoSupplierList;
                if (advTreeVideoSupplier.SelectedNode != null)
                {
                    uint videoSupplierId = Convert.ToUInt32(advTreeVideoSupplier.SelectedNode.Cells[0].Text);
                    advTreeCamera.DataSource = m_viewModel.GetCameraListByVideoSupplierID(videoSupplierId);
                }
            }
        }

        private void buttonAddNetStore_Click(object sender, EventArgs e)
        {
            FormAddEditNetStore f = new FormAddEditNetStore();
            f.ShowDialog();
                advTreeVideoSupplier.DataSource = m_viewModel.VideoSupplierList;

        }

        private void buttonAddCamera_Click(object sender, EventArgs e)
        {
            if (advTreeVideoSupplier.SelectedNode != null)
            {
                FormAddEditCamera f = new FormAddEditCamera();
                f.VideoSupplierId = Convert.ToUInt32(advTreeVideoSupplier.SelectedNode.Cells[0].Text);
                f.VideoSupplierNmae = advTreeVideoSupplier.SelectedNode.Cells[1].Text;
                f.ShowDialog();
                m_viewModel.FlushCameraList();
                advTreeCamera.DataSource = m_viewModel.GetCameraListByVideoSupplierID(f.VideoSupplierId);
            }
        }

        private void advTreeCamera_DataSourceChanged(object sender, EventArgs e)
        {
            foreach (DevComponents.AdvTree.Node item in advTreeCamera.Nodes)
            {
                item.Cells[6].Text = "<a href=\"del\">删除</a>";
            }

        }

        private void advTreeCamera_MarkupLinkClick(object sender, DevComponents.AdvTree.MarkupLinkClickEventArgs e)
        {
            if (e.HRef == "del")
            {
                m_viewModel.DelCameraByID(Convert.ToUInt32(advTreeCamera.SelectedNode.Cells[0].Text));
                m_viewModel.FlushCameraList();
                if (advTreeVideoSupplier.SelectedNode != null)
                {
                    uint videoSupplierId = Convert.ToUInt32(advTreeVideoSupplier.SelectedNode.Cells[0].Text);
                    advTreeCamera.DataSource = m_viewModel.GetCameraListByVideoSupplierID(videoSupplierId);
                }
            }

        }

		private void FormSetting_FormClosed(object sender, FormClosedEventArgs e) 
		{

		}

        private void buttonMutiAdd_Click(object sender, EventArgs e)
        {
            if (advTreeVideoSupplier.SelectedNode != null)
            {
                uint VideoSupplierId = Convert.ToUInt32(advTreeVideoSupplier.SelectedNode.Cells[0].Text);
                m_viewModel.AddCameraListByVideoSupplier(VideoSupplierId);
                m_viewModel.FlushCameraList();
                advTreeCamera.DataSource = m_viewModel.GetCameraListByVideoSupplierID(VideoSupplierId);
            }

        }

    }
}
