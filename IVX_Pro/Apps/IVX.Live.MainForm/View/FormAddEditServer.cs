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
    public partial class FormAddEditServer : IVX.Live.MainForm.UILogics.FormBase
    {
        SettingViewModel m_viewModel;
        public FormAddEditServer()
        {
            InitializeComponent();
            SetWindowSizeable(false);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            labelX4.ResetText();
            try
            {
                bool ret = m_viewModel.AddServer(ipAddressInputServerIp.Value, (uint)integerInputServerPort.Value, (E_VDA_SERVER_TYPE)comboBoxServerType.SelectedValue, textBoxDes.Text);
                DialogResult =System.Windows.Forms.DialogResult.OK;
            }
            catch(SDKCallException ex)
            {
                labelX4.Text = "服务器添加失败 ["+ex.ErrorCode+"] "+ ex.Message;
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
            comboBoxServerType.ValueMember = "Type";
            comboBoxServerType.DisplayMember = "Name";
            comboBoxServerType.DataSource = Constant.ServerTypeInfos;
        }
    }
}