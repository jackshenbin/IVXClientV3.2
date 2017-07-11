using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using DevComponents.DotNetBar;
using IVX.DataModel;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class FormFaceAlarmControl : IVX.Live.MainForm.UILogics.FormBase
    {
        uint ReceivedCount { get; set; }
        FaceAlarmControlViewModel m_viewModel;
        public FormFaceAlarmControl()
        {
            InitializeComponent();
            UseMdiDefaultWindow(true);
            ShowStatusBar = false;
        }


        public override void UpdateUI()
        {
        }

        public override void Clear()
        {
            
        }
        public override void DoAction(object action)
        {
            if (action is DataModel.CameraInfoV3_1)
            {


            }

        }

        private void advTree1_DataSourceChanged(object sender, EventArgs e)
        {
            foreach (DevComponents.AdvTree.Node item in advTree1.Nodes)
            {
                item.Cells[7].Text = "<a href=\"del\">取消布控</a>";
            }

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            m_viewModel = new FaceAlarmControlViewModel();
            advTree1.DataSource = m_viewModel.FaceControlList;
        }

        private void advTree1_MarkupLinkClick(object sender, DevComponents.AdvTree.MarkupLinkClickEventArgs e)
        {
            if (e.HRef == "del")
            {
                m_viewModel.DelFaceControlByID(advTree1.SelectedNode.Cells[1].Text,Convert.ToUInt32(advTree1.SelectedNode.Cells[0].Text));
                advTree1.DataSource = m_viewModel.FaceControlList;

            }

        }

        private void buttonFaceControl_Click(object sender, EventArgs e)
        {
            FormAddEditFaceControl f = new FormAddEditFaceControl();
            f.ShowDialog();
            advTree1.DataSource = m_viewModel.FaceControlList;
        }


    }
}