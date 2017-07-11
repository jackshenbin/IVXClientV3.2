using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.Live.ViewModel;
using IVX.DataModel;
using IVX.Live.MainForm.View;

namespace IVX.Live.MainForm {
	public partial class ucUserManager : UserControl {

		UserViewModel m_vm;
		SearchFinshInvoke m_searFinshFunc;

		public ucUserManager() {
			InitializeComponent();
		}

		private void AddFinsh(object logInfoListObj, EventArgs e) {
			UserInfo userInfo = (UserInfo)logInfoListObj;
			userDataList.Rows.Add(userInfo.UserName,
				userInfo.UserRoleType == 1 ? "管理员" : "普通用户",
									 userInfo.other);
			userDataList.Rows[userDataList.Rows.Count - 1].Tag = userInfo;
		}

		private void ModFinsh(object logInfoListObj, EventArgs e) 
		{
			UserInfo userInfo = (UserInfo)logInfoListObj;
			userDataList.Rows[userDataList.CurrentRow.Index].Cells[0].Value = userInfo.UserName;
			userDataList.Rows[userDataList.CurrentRow.Index].Cells[1].Value = userInfo.UserRoleType == 1 ? "管理员" : "普通用户";
			userDataList.Rows[userDataList.CurrentRow.Index].Cells[2].Value = userInfo.other;
			userDataList.Rows[userDataList.CurrentRow.Index].Tag = userInfo;
		}

		private void addBtn_Click(object sender, EventArgs e) {
			FormAddUser newAddForm = new FormAddUser();
			newAddForm.AddFinished += AddFinsh;
			newAddForm.ShowDialog();
		}

		private void delBtn_Click(object sender, EventArgs e) {
			if (MessageBox.Show(string.Format("确认删除用户 {0} ?", ((UserInfo)userDataList.SelectedRows[0].Tag).UserName), Framework.Environment.PROGRAM_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != System.Windows.Forms.DialogResult.Yes)
				return;
			if (userDataList.Rows.Count <= 0)
				return;
			if (m_vm.DelUser(((UserInfo)userDataList.SelectedRows[0].Tag).UserHandle)) {
				userDataList.Rows.RemoveAt(userDataList.CurrentRow.Index);
			}
		}

		private void modBtn_Click(object sender, EventArgs e) {
			if (userDataList.Rows.Count <= 0)
					return;
			FormAddUser newAddForm = new FormAddUser();
			newAddForm.ModFinished += ModFinsh;
			newAddForm.InitFormInfo((UserInfo)userDataList.SelectedRows[0].Tag);
			newAddForm.ShowDialog();
		}

		public void RefreshUserInfo() 
		{
			// clear last Data
			userDataList.Rows.Clear();
			m_vm.GetUserList();
		}

		private void SearchFinsh(object userInfoListObj, EventArgs e) {
			Invoke(m_searFinshFunc, userInfoListObj);
		}

		private void ucUserManager_Load(object sender, EventArgs e) 
		{
			m_vm = new UserViewModel();
			m_vm.SearchFinished += SearchFinsh;
			m_searFinshFunc += new SearchFinshInvoke(SearchFinshInvokeFun);
		}

		private void SearchFinshInvokeFun(object userInfoListObj)
		{
			int id = 0;
			List<UserInfo> userInfoList = (List<UserInfo>)userInfoListObj;
			if (userInfoList == null) {
				MyLog4Net.Container.Instance.Log.Debug("ucUserManager RefreshUserInfo" + " not have any Data");
				MessageBox.Show("用户管理-查询[无结果数据]:", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else if (userInfoList.Count == 1 && userInfoList[0].UserName == "SDKError") {
				MyLog4Net.Container.Instance.Log.Debug("ucUserManager RefreshUserInfo" + "SDKError" + userInfoList[0].other);
				MessageBox.Show(string.Format("用户管理-查询[{0}]:", userInfoList[0].other), Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			// normal
			else {
				foreach (var item in userInfoList) {
					userDataList.Rows.Add(item.UserName,
										 item.UserRoleType == 1 ? "管理员" : "普通用户",
										 item.other);
					userDataList.Rows[id++].Tag = item;
				}
			}
		}

		private void userDataList_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
			if (userDataList.Rows.Count <= 0)
				return;
			FormAddUser newAddForm = new FormAddUser();
			newAddForm.ModFinished += ModFinsh;
			newAddForm.InitFormInfo((UserInfo)userDataList.SelectedRows[0].Tag);
			newAddForm.ShowDialog();
		}
		
	}
}
