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
	public partial class FormMdfPwd : IVX.Live.MainForm.UILogics.FormBase
	{
		private UserInfo m_curUser;
		UserViewModel m_vm;

		public FormMdfPwd()
		{
			InitializeComponent();
			SetWindowSizeable(false);
		}

		public void InitFormInfo()
		{
			m_curUser = Framework.Environment.CurUserInfo.Clone();
		}

		private void FormMdfPwd_Load(object sender, EventArgs e)
		{
			InitFormInfo();
			m_vm = new UserViewModel();
		}

		private void yesBtn_Click(object sender, EventArgs e)
		{
			int isCanMfy = infoIsValid();
			if (isCanMfy == 1)
			{
				errorLabel.Text = "修改失败:输入信息为空!";
			}
			else if(isCanMfy == 2)
			{
				errorLabel.Text = "修改失败:两次密码不一致!";
			}
			else if (isCanMfy == 3)
			{
				errorLabel.Text = "修改失败:原始密码不正确!";
			}
			else
			{
				m_curUser.UserPwd = newPwd.Text;
				// 如果添加成功
				if (m_vm.ModUser(m_curUser)) {
					Framework.Environment.CurUserInfo.UserPwd = m_curUser.UserPwd;
					errorLabel.Text = "修改成功";
				}
				else {
					errorLabel.Text = "修改失败" + ":" + m_curUser.other;
				}
			}

		}

		private void cancelBtn_Click(object sender, EventArgs e) 
		{
			this.Close();
		}

		private int infoIsValid() {
			// 信息不能为空
			if (oldPwd.Text.Length == 0
				|| newPwd.Text.Length == 0
				|| cfmPwd.Text.Length == 0)
				return 1;

			// 新旧密码不一致
			if (cfmPwd.Text != newPwd.Text)
				return 2;

			// 旧密码不对
			if (oldPwd.Text != Framework.Environment.CurUserInfo.UserPwd)
				return 3;

			return 0;
		}

	}
}
