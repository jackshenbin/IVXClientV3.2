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
    public partial class FormLogin : IVX.Live.MainForm.UILogics.FormBase
    {
        LoginViewModel m_viewModel;
        public FormLogin()
        {
            Trace.WriteLine("Form1 1");

            InitializeComponent();
            Trace.WriteLine("Form1 2");
            SetWindowSizeable(false);
            ShowStatusBar = false;
            ipAddressInput1.Value = Framework.Environment.ServerIP;
            UserName_DropDown.Text = Framework.Environment.CurUserInfo.UserName;
            pwd_textBox.Text = Framework.Environment.CurUserInfo.UserPwd;
            checkBoxSaveUser.Checked = Framework.Environment.SavePassword;
            labelVersion.Text = Framework.Environment.Version;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            labelX4.ResetText();
            string msg = "";
            bool ret = m_viewModel.Login(ipAddressInput1.Text, Framework.Environment.LocalCommIP,UserName_DropDown.Text,pwd_textBox.Text, out msg);
            if (ret)
            {
				SaveCurUserInfo(UserName_DropDown.Text);
                Framework.Environment.ServerIP = ipAddressInput1.Text;
                Framework.Environment.SaveConfig();
				
            }
            labelX4.Text = msg;
            DialogResult = ret?  System.Windows.Forms.DialogResult.OK: System.Windows.Forms.DialogResult.None;
        }


        private void buttonX1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }



        public override void UpdateUI()
        {
            throw new NotImplementedException();
        }

        public override void Clear()
        {
            
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            m_viewModel = new LoginViewModel();
        }

		private void SaveCurUserInfo(string userName) 
		{
			UserViewModel m_viewModel = new UserViewModel();
			Framework.Environment.CurUserInfo = m_viewModel.GetUserInfo(userName);
		}

        private void checkBoxSaveUser_CheckedChanged(object sender, EventArgs e)
        {
            Framework.Environment.SavePassword = checkBoxSaveUser.Checked;
        }
    }
}