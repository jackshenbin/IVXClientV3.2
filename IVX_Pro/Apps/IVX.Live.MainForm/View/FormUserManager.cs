using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IVX.Live.MainForm.View {
	public partial class FormUserManager : IVX.Live.MainForm.UILogics.FormBase 
	{
		public FormUserManager() {
			InitializeComponent();
			UseMdiDefaultWindow(true);
		}

		public override void UpdateUI() {
		}

		public override void Clear() {

		}

		private void labelX1_Click(object sender, EventArgs e) {

		}

		private void FormUserManager_Load(object sender, EventArgs e) {
			m_ucUserManager.RefreshUserInfo();
		}

		private void m_ucUserManager_Load(object sender, EventArgs e) {

		}
	}
}
