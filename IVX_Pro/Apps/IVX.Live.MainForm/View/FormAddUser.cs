using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.Live.ViewModel;
using IVX.DataModel;

namespace IVX.Live.MainForm.View {
	public partial class FormAddUser : IVX.Live.MainForm.UILogics.FormBase {

		public event EventHandler AddFinished;
		public event EventHandler DelFinished;
		public event EventHandler ModFinished;

		UserViewModel m_vm;
		public bool isAddMode { get;set;}
		private UserInfo m_curUser;

		public FormAddUser() {
			isAddMode = true;
			InitializeComponent();
			SetWindowSizeable(false);
		}

		private void cancelBtn_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void yesBtn_Click(object sender, EventArgs e) {
			int checkNum = infoIsValid();
			if (checkNum == -1)
			{
				errorLabel.Text = "输入信息为空!";
				return;
			}
			else if (checkNum == 1) 
			{
				errorLabel.Text = "两次密码不一致!";
				return;
			}
			else if (checkNum == 2) {
				errorLabel.Text = "用户名只能由数字和字母组成!";
				return;
			}

			if (isAddMode) 
			{
				AddUser();
			}
			else 
			{
				ModUSer();
			}
		}

		public void InitFormInfo(UserInfo curUser) 
		{
			this.Text = "修改用户信息";
			Txt_userName.Text = curUser.UserName;
			Txt_userName.Enabled = false;
			Txt_userName.ReadOnly = true;
			Txt_pwd.Text = curUser.UserPwd;
			Txt_pwdCfm.Text = curUser.UserPwd;
			userRoleCom.SelectedIndex = Convert.ToInt32(curUser.UserRoleType - 1);
			Txt_userOther.Text = curUser.other;
			isAddMode = false;
			m_curUser = curUser;
		}

		private void ModUSer()
		{
			m_curUser.UserName = Txt_userName.Text;
			m_curUser.UserPwd = Txt_pwd.Text;
			m_curUser.UserRoleType = Convert.ToUInt32(userRoleCom.SelectedIndex + 1);
			m_curUser.RightMask = 777;
			m_curUser.other = Txt_userOther.Text;
			// 如果添加成功
			if (m_vm.ModUser(m_curUser)) {
				if (ModFinished != null) {
					ModFinished((object)m_curUser, null);
				}
				this.Close();
			}
			else {
				errorLabel.Text = "修改失败" + ":" + m_curUser.other;
			}
		}

		private void AddUser() 
		{
			UserInfo newUser = new UserInfo();
			newUser.UserName = Txt_userName.Text;
			newUser.UserPwd = Txt_pwd.Text;
			newUser.UserRoleType = Convert.ToUInt32(userRoleCom.SelectedIndex + 1);
			newUser.RightMask = 777;
			newUser.other = Txt_userOther.Text;
			// 如果添加成功  新用户的句柄 会在 service层获得并写到 对象里
			if (m_vm.AddUser(newUser)) {
				if (AddFinished != null) {
					AddFinished((object)newUser, null);
				}
				this.Close();
			}
			else 
			{
				errorLabel.Text = "添加失败" + ":" + newUser.other;
			}
		}

		private void FormAddUser_Load(object sender, EventArgs e) {
			m_vm = new UserViewModel();
			//添加默认为普通用户 
			if (isAddMode) {
				userRoleCom.SelectedIndex = 1;
			}
		}

		private int  infoIsValid() 
		{
			string pattern = @"^[a-zA-Z0-9]*$";
			if(!System.Text.RegularExpressions.Regex.IsMatch(Txt_userName.Text,pattern))
			{
				return 2;
			}
			// 有效信息是否为空
			if (Txt_userName.Text.Length == 0
				|| Txt_pwd.Text.Length == 0
				|| Txt_pwdCfm.Text.Length == 0)
				return -1;
			// 两次密码不一致
			if (Txt_pwd.Text != Txt_pwdCfm.Text) 
				return 1;
			return 0;
		}
	}
}
