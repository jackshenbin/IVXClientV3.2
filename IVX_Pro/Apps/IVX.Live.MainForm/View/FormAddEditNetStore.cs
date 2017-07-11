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
    public partial class FormAddEditNetStore : IVX.Live.MainForm.UILogics.FormBase
    {
        SettingViewModel m_viewModel;
        public FormAddEditNetStore()
        {

            InitializeComponent();
            SetWindowSizeable(false);
        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {            
            labelX4.ResetText();
            try
            {
                bool ret = m_viewModel.AddVideoSupplier((E_VDA_NET_STORE_DEV_PROTOCOL_TYPE)comboBoxNetStoreType.SelectedValue, textBoxNetStoreName.Text, ipAddressInputNetStoreIp.Value, (uint)integerInputNetStorePort.Value, textBoxNetStoreUsername.Text, textBoxNetStorePassword.Text);
                DialogResult =System.Windows.Forms.DialogResult.OK;
            }
            catch(SDKCallException ex)
            {
                labelX4.Text = "平台设备添加失败 ["+ex.ErrorCode+"] "+ ex.Message;
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
            comboBoxNetStoreType.ValueMember = "Type";
            comboBoxNetStoreType.DisplayMember = "Name";
            comboBoxNetStoreType.DataSource = Constant.AccessProtocolTypeInfos.Where(item=>item.Type!= E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_FTP_FILE && item.Type!= E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_HTTP_FILE).ToArray();

        }

        private void comboBoxNetStoreType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((E_VDA_NET_STORE_DEV_PROTOCOL_TYPE)comboBoxNetStoreType.SelectedValue)
            {
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_NONE:
                    break;
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_ONVIF_PROTOCOL:
                    ipAddressInputNetStoreIp.Value = "192.168.88.114";
                    integerInputNetStorePort.Value = 80;
                    textBoxNetStoreUsername.Text = "admin";
                    textBoxNetStorePassword.Text = "admin";
                    break;
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_GB28181_PROTOCOL:
                    ipAddressInputNetStoreIp.Value = "192.168.137.134";
                    integerInputNetStorePort.Value = 13300;
                    textBoxNetStoreUsername.Text = "admin";
                    textBoxNetStorePassword.Text = "admin";
                    break;
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_BCSYS_PLAT:
                    break;
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_H3C_PLAT:
                    break;
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_HK_PLAT:
                    break;
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_NETPOSA_PLAT:
                    break;
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_IMOS_PLAT:
                    break;
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_DHPLAT_DEV:
                    break;
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_ISOC_PLAT:
                    break;
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_VISS_PLAT:
                    break;
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_WB_PLAT:
                    break;
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_HK_DEV:
                    ipAddressInputNetStoreIp.Value = "192.168.88.252";
                    integerInputNetStorePort.Value = 8000;
                    textBoxNetStoreUsername.Text = "admin";
                    textBoxNetStorePassword.Text = "12345";
                    break;
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_DH_DEV:
                    ipAddressInputNetStoreIp.Value = "192.168.88.250";
                    integerInputNetStorePort.Value = 37777;
                    textBoxNetStoreUsername.Text = "admin";
                    textBoxNetStorePassword.Text = "admin";
                    break;
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_SANYO_IPC_DEV:
                    break;
                case E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_MSS_SHARE_FILE:
                    ipAddressInputNetStoreIp.Value = "192.168.88.180";
                    integerInputNetStorePort.Value = 9101;
                    textBoxNetStoreUsername.Text = "admin";
                    textBoxNetStorePassword.Text = "admin";
                    break;
                    
                default:
                    break;
            }
        }
    }
}