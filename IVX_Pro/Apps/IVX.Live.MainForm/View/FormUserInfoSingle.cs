using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View {
	public partial class FormUserInfoSingle : IVX.Live.MainForm.UILogics.FormBase 
	{
		private UserInfo m_curUser;
		UserViewModel m_vm;
		public FormUserInfoSingle()
		{
			InitializeComponent();
			SetWindowSizeable(false);
		}

		private void yesBtn_Click(object sender, EventArgs e) {
			/*
			int checkNum = infoIsValid();
			if (checkNum == -1) 
			{
				errorLabel.Text = "输入信息为空!";
				return;
			}
			else if (checkNum == 2) {
				errorLabel.Text = "用户名只能由数字和字母组成!";
				return;
			}
			*/
			ModUSer();
		}

		private int infoIsValid() {
			string pattern = @"^[a-zA-Z0-9]*$";
			if (!System.Text.RegularExpressions.Regex.IsMatch(Txt_userName.Text, pattern)) {
				return 2;
			}
			// 有效信息是否为空
			if (Txt_pwd.Text.Length == 0)
				return -1;
			return 0;
		}

		private void ModUSer()
		{
			//这里仅仅 修改了 个人备注说明
			m_curUser.other = Txt_userOther.Text;
			// 如果添加成功
			if (m_vm.ModUser(m_curUser)) {
				Framework.Environment.CurUserInfo.other = m_curUser.other;
				errorLabel.Text = "修改成功";
			}
			else {
				errorLabel.Text = "修改失败" + ":" + m_curUser.other;
			}
		}

		private void FormUserInfoSingle_Load(object sender, EventArgs e)
		{
			m_vm = new UserViewModel();
		}

		public void InitFormInfo(UserInfo curUser) 
		{
			Txt_userName.Text = curUser.UserName;
			Txt_pwd.Text = curUser.UserPwd;
			userRoleCom.SelectedIndex = Convert.ToInt32(curUser.UserRoleType - 1);
			Txt_userOther.Text = curUser.other;
			// 重新创建一份 当前用户的数据
			m_curUser = curUser.Clone();
		}

		private void cancelBtn_Click(object sender, EventArgs e) 
		{
			this.Close();
		}

		private void Txt_userOther_TextChanged(object sender, EventArgs e) 
		{
			errorLabel.Text = "";
		}

		private void mdfPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) 
		{
			this.Close();
			new System.Threading.Thread(MfyPwdTh).Start();
		}

		private void MfyPwdTh() 
		{
			FormMdfPwd m_pwdForm = new FormMdfPwd();
			m_pwdForm.ShowDialog();
		}
	}
}
