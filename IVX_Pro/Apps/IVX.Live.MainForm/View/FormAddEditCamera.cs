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
    public partial class FormAddEditCamera : IVX.Live.MainForm.UILogics.FormBase
    {
        SettingViewModel m_viewModel;
        public uint VideoSupplierId { get; set; }
        public string VideoSupplierNmae { get; set; }

        public FormAddEditCamera()
        {
            InitializeComponent();
            SetWindowSizeable(false);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            labelX4.ResetText();
            try
            {
                string msg = "";
                if (!Validata(out msg))
                { 
                labelX4.Text = msg;

                }
                else
                {
                    bool ret = m_viewModel.AddCamera(VideoSupplierId, textBoxChannel.Text, textBoxCameraName.Text, textBoxCameraID.Text, doubleInputX.Value, doubleInputY.Value);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch(SDKCallException ex)
            {
                labelX4.Text = "相机添加失败 ["+ex.ErrorCode+"] "+ ex.Message;
            }
        }

        private bool Validata(out string msg)
        {
            if (VideoSupplierId <= 0)
            {
                msg = "关联平台不能为空";
                return false;
            }
            if (string.IsNullOrEmpty( textBoxCameraID.Text))
            {
                msg = "相机编号不能为空";
                return false;
            }
            if (string.IsNullOrEmpty(textBoxChannel.Text))
            {
                msg = "在所属平台上的编号不能为空";
                return false;
            }
            msg = "";
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
            m_viewModel = new SettingViewModel();
            labelNmae.Text = VideoSupplierNmae;
        }
    }
}