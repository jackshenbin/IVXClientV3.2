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
    public partial class FormSettingServer : UILogics.FormBase
    {
        private SettingViewModel m_viewModel;
        public FormSettingServer()
        {
            InitializeComponent();
            UseMdiDefaultWindow(true);
            ShowStatusBar = false;
        }

        public override void UpdateUI()
        {
            if (m_viewModel!=null)
            {
                advTreeServer.DataSource = m_viewModel.ServerList;

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
            advTreeServer.DataSource = m_viewModel.ServerList;
        }




        private void advTree1_DataSourceChanged(object sender, EventArgs e)
        {
            foreach (DevComponents.AdvTree.Node item in advTreeServer.Nodes)
            {
                item.Cells[6].Text = "<a href=\"del\">删除</a>";
            }

        }

        private void advTree1_MarkupLinkClick(object sender, DevComponents.AdvTree.MarkupLinkClickEventArgs e)
        {
            if (e.HRef == "del")
            {
                m_viewModel.DelServerByID(Convert.ToUInt32(advTreeServer.SelectedNode.Cells[0].Text));
                advTreeServer.DataSource = m_viewModel.ServerList;

            }

        }

        private void buttonAddServer_Click(object sender, EventArgs e)
        {
            FormAddEditServer f = new FormAddEditServer();
            f.ShowDialog();
                advTreeServer.DataSource = m_viewModel.ServerList;
        }




		private void reBootBtn_Click(object sender, EventArgs e)
		{
			FormReBootSer m_reBoot = new FormReBootSer();
			m_reBoot.ShowDialog();
		}

		private void FormSetting_FormClosed(object sender, FormClosedEventArgs e) 
		{

		}


    }
}
