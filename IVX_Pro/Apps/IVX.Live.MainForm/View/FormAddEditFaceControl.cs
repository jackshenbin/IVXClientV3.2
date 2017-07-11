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
    public partial class FormAddEditFaceControl : IVX.Live.MainForm.UILogics.FormBase
    {
        FaceAlarmControlViewModel m_viewModel;


        public FormAddEditFaceControl()
        {
            InitializeComponent();
            SetWindowSizeable(false);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                m_viewModel.AddFaceAlarmControl(comboTreeCamera.SelectedValue.ToString(), (uint)integerInputControlThreshold.Value, Convert.ToUInt32(comboTreeBlackListHandle.SelectedValue.ToString()), Convert.ToUInt32(comboBoxExControlNation.SelectedValue), Convert.ToUInt32(comboBoxExControlSex.SelectedValue), Convert.ToUInt32(comboBoxExBeginAge.Value), Convert.ToUInt32(comboBoxExEndAge.Value));
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private bool ValidateData()
        {
            if (string.IsNullOrEmpty(comboTreeCamera.SelectedValue.ToString()))
            {
                labelX9.Text = "请选择摄像机";
                return false;
            }
            return true;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }



        public override void UpdateUI()
        {
        }

        public override void Clear()
        {
            
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            m_viewModel = new FaceAlarmControlViewModel();
            comboTreeCamera.DataSource = new SettingViewModel().CameraInfoList;
			comboTreeBlackListHandle.DataSource = BlackListViewModel.Instance.BLackInfoList;
            comboBoxExControlNation.ValueMember = "Type";
            comboBoxExControlNation.DisplayMember = "Name";

            comboBoxExControlNation.DataSource = DataModel.Constant.PeopleNationTypeInfos;
            comboBoxExControlSex.ValueMember = "Type";
            comboBoxExControlSex.DisplayMember = "Name";


        }
    }
}