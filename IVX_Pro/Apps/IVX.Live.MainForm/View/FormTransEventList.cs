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
    public partial class FormTransEventList : UILogics.FormBase
    {
        SettingViewModel m_viewModel;

        public uint TaskId { get; set; }
        public FormTransEventList()
        {
            InitializeComponent();
        }

        public override void UpdateUI()
        {
        }

        public override void Clear()
        {
        }

        private void FormExportList_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            m_viewModel = new SettingViewModel();
            advTreeTransEvent.DataSource = m_viewModel.GetTransEventListByID(TaskId);
        }


        private void FormExportList_FormClosing(object sender, FormClosingEventArgs e)
        {
        }


        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            FormAddEditTransEvent f = new FormAddEditTransEvent();
            f.TaskId = this.TaskId;
            f.ShowDialog();
            advTreeTransEvent.DataSource = m_viewModel.GetTransEventListByID(TaskId);

        }

        private void advTreeTransEvent_DataSourceChanged(object sender, EventArgs e)
        {
            foreach (DevComponents.AdvTree.Node item in advTreeTransEvent.Nodes)
            {
                item.Cells[8].Text = "<a href=\"del\">删除</a>";
            }

        }

        private void advTreeTransEvent_MarkupLinkClick(object sender, MarkupLinkClickEventArgs e)
        {
            if (e.HRef == "del")
            {
                m_viewModel.DelTransEventByID(Convert.ToUInt32(advTreeTransEvent.SelectedNode.Cells[0].Text));
                advTreeTransEvent.DataSource = m_viewModel.GetTransEventListByID(TaskId);
            }

        }

    }
}
