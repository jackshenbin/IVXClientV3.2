using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View {
	public partial class ucBlackList : UserControl {
		public ucBlackList() {
			InitializeComponent();
		}

		private void userDataList_CellContentClick(object sender, DataGridViewCellEventArgs e) {

		}

		private void ucBlackList_Load(object sender, EventArgs e) {
			RefreshTable(null,null);
		}

		private void RefreshTable(object sender, EventArgs e) {
			userDataList.Rows.Clear();
			List<BlackListLib> t_BlackListLib = BlackListViewModel.Instance.GetBlackList();
			if (t_BlackListLib == null)
				return;
			foreach (var item in t_BlackListLib) {
				userDataList.Rows.Add("", item.Name, item.PicCount, item.OtherInfo);
				userDataList.Rows[userDataList.Rows.Count - 1].Tag = item;
			}
		}

		private void buttonX1_Click(object sender, EventArgs e) {
			FormBlackListAdd t_form = new FormBlackListAdd();
			t_form.AddFinished += AddFinsh;
			t_form.ShowDialog();
		}

		private void buttonX2_Click(object sender, EventArgs e) {
			FormBalckItemAdd blackItemAdd = new FormBalckItemAdd();
			blackItemAdd.RefreshTableFunc += RefreshTable;
			blackItemAdd.LibHandel = ((BlackListLib)userDataList.Rows[userDataList.CurrentCell.RowIndex].Tag).Handel;
			blackItemAdd.CurBlackListLib = (BlackListLib)userDataList.Rows[userDataList.CurrentCell.RowIndex].Tag;
			blackItemAdd.ShowDialog();
		}

		private void AddFinsh(object blackListLib, EventArgs e) {
			BlackListLib t_BlackListLib = (BlackListLib)blackListLib;
			userDataList.Rows.Add("", t_BlackListLib.Name, t_BlackListLib.picList.Count, t_BlackListLib.OtherInfo);
			userDataList.Rows[userDataList.Rows.Count - 1].Tag = blackListLib;
		}

		private void delBtn_Click(object sender, EventArgs e) {
			BlackListLib t_BlackListLib = (BlackListLib)userDataList.SelectedRows[0].Tag;
			if (userDataList.Rows.Count <= 0)
				return;
			if (MessageBox.Show(string.Format("确认删除该黑名单库 {0} ?", t_BlackListLib.Name), Framework.Environment.PROGRAM_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != System.Windows.Forms.DialogResult.Yes)
				return;
			string retStr;
			if (BlackListViewModel.Instance.DelBlackListLib(t_BlackListLib.Handel, out retStr)) {
				userDataList.Rows.RemoveAt(userDataList.CurrentRow.Index);
			}
		}

		private void userDataList_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
			FormBalckItemAdd blackItemAdd = new FormBalckItemAdd();
			blackItemAdd.RefreshTableFunc += RefreshTable;
			blackItemAdd.LibHandel = ((BlackListLib)userDataList.Rows[userDataList.CurrentCell.RowIndex].Tag).Handel;
			blackItemAdd.CurBlackListLib = (BlackListLib)userDataList.Rows[userDataList.CurrentCell.RowIndex].Tag;
			blackItemAdd.ShowDialog();
		}
	}
}
