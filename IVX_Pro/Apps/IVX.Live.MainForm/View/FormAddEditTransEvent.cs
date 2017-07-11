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
using System.Linq;

namespace IVX.Live.MainForm.View
{
    public partial class FormAddEditTransEvent : IVX.Live.MainForm.UILogics.FormBase
    {
        SettingViewModel m_viewModel;
        public uint TaskId { get; set; }
        public FormAddEditTransEvent()
        {
            InitializeComponent();
            SetWindowSizeable(false);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            labelX4.ResetText();
            if ((E_VIDEO_ANALYZE_TYPE)comboBoxAnalyseType.SelectedValue == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE)
            {
                labelX4.Text = "请选择需要转发的算法类型";
                return;
            }
            try
            {
                bool ret = m_viewModel.AddTransEvent(
                    TaskId,
                    0,
                    (E_TRANCE_STORE_TYPE)comboBoxStoreType.SelectedValue, 
                    ipAddressInputServerIp.Value, 
                    (uint)integerInputServerPort.Value,
                    (E_TRANS_PROTOCOL_TYPE)comboBoxProtocolType.SelectedValue,
                    (E_VIDEO_ANALYZE_TYPE)comboBoxAnalyseType.SelectedValue);
                DialogResult =System.Windows.Forms.DialogResult.OK;
            }
            catch(SDKCallException ex)
            {
                labelX4.Text = "转发参数添加失败 ["+ex.ErrorCode+"] "+ ex.Message;
            }
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
            m_viewModel = new SettingViewModel();

            comboBoxProtocolType.ValueMember = "Type";
            comboBoxProtocolType.DisplayMember = "Name";
            comboBoxProtocolType.DataSource = Constant.TransProtocolTypeInfos;
            comboBoxProtocolType.SelectedIndex = 0;

            comboBoxStoreType.ValueMember = "Type";
            comboBoxStoreType.DisplayMember = "Name";
            comboBoxStoreType.DataSource = Constant.TransStoreTypeInfos;
            comboBoxStoreType.SelectedIndex = 0;

            comboBoxAnalyseType.ValueMember = "Type";
            comboBoxAnalyseType.DisplayMember = "Name";
            comboBoxAnalyseType.DataSource = Constant.VideoAnalyzeTypeInfo.Where
                (
                item => item.Type != E_VIDEO_ANALYZE_TYPE.E_ANALYZE_IMAGE_SEARCH
                    && item.Type != E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ
                    && item.Type != E_VIDEO_ANALYZE_TYPE.E_ANALYZE_SPECIAL_EFFECT_WIPEOFF_FOG
                    && item.Type != E_VIDEO_ANALYZE_TYPE.E_ANALYZE_VEHICLE
                    && item.Type != E_VIDEO_ANALYZE_TYPE.E_ANALYZE_ACCIDENT_ALARM
                ).ToArray(); ;
            comboBoxAnalyseType.SelectedIndex = 0;

        }
    }
}