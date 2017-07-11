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
	public partial class FormBlackListAdd : IVX.Live.MainForm.UILogics.FormBase {
		public event EventHandler AddFinished;
		public FormBlackListAdd() {
			InitializeComponent();
		}

		private void labelX3_Click(object sender, EventArgs e) {

		}

		private void AddBtn_Click(object sender, EventArgs e) {
			errorLabel.Text = "";
			if (name.Text == ""|| code.Text == "") {
				MessageBox.Show("有效信息不能为空", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			BlackListLib t_BlackListLib = new BlackListLib();
			t_BlackListLib.Name = name.Text;
			t_BlackListLib.Code = code.Text;
			t_BlackListLib.OtherInfo = otherInfo.Text;
			// 添加成功
			if (BlackListViewModel.Instance.AddBlackListLib(t_BlackListLib)) {
				if (AddFinished != null) {
					AddFinished((object)t_BlackListLib, null);
				}
				this.Close();
			}
			// 添加失败
			else {
				errorLabel.Text = "添加失败";
			}
		}

		private void calcelBtn_Click(object sender, EventArgs e) {

		}

		private void FormBlackListAdd_Load(object sender, EventArgs e) {
			errorLabel.Text = "";
		}
	}
}
