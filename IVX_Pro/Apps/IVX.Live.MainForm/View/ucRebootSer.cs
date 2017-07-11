using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.AdvTree;
using IVX.Live.ViewModel;
using IVX.DataModel;

namespace IVX.Live.MainForm.View {
	public partial class ucRebootSer : UserControl {

		private ReBootSerViewModel m_viewModel;
		NotifyReBootForm m_notifyFunc;

		public ucRebootSer() {
			InitializeComponent();
			m_viewModel = new ReBootSerViewModel();
			m_viewModel.notifyForm += new NotifyReBootForm(NotifyForm);
			m_notifyFunc += new NotifyReBootForm(NotifyFunc);
		}

		private void NotifyForm(string ip,string status) 
		{
			while(!this.IsHandleCreated);
			Invoke(m_notifyFunc, ip, status);
		}

		private void NotifyFunc(string ip, string status) 
		{
			foreach (DevComponents.AdvTree.Node item in advTreeServer.Nodes)
			{
				if (item.Cells[0].Text == ip) {
					item.Cells[1].Text = status;
				}
			}
			m_viewModel.DeleteSocket(ip);
		}

		private void advTreeServer_Click(object sender, EventArgs e)
		{

		}

		private void ucRebootSer_Load(object sender, EventArgs e) 
		{
			var serInfo = m_viewModel.GetSerInfo();
			this.advTreeServer.DataSource = m_viewModel.ServerList;
			foreach (DevComponents.AdvTree.Node item in advTreeServer.Nodes) 
			{
				item.Cells[2].Text = "<a href=\"del\">重启</a>";
			}
		}

		private void advTreeServer_MarkupLinkClick(object sender, MarkupLinkClickEventArgs e) 
		{
			advTreeServer.SelectedNode.Cells[1].Text = "正在重启...";
			string ip = advTreeServer.SelectedNode.Cells[0].Text;
			m_viewModel.ReBootSingle(ip);
		}

		private void buttonItem1_Click(object sender, EventArgs e)
		{
			foreach (DevComponents.AdvTree.Node item in advTreeServer.Nodes)
			{
				item.Cells[1].Text = "正在重启...";
			}
			m_viewModel.ReBootAll();
		}

		public void Clear() 
		{
			m_viewModel.Clear();
		}
	}
}
