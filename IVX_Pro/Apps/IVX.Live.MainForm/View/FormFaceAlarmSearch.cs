using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IVX.Live.MainForm.View {
	public partial class FormFaceAlarmSearch : IVX.Live.MainForm.UILogics.FormBase {

		public FormFaceAlarmSearch() {
			InitializeComponent();
			UseMdiDefaultWindow(true);
			ShowStatusBar = false;
		}

		public override void UpdateUI() {
		}

		public override void Clear() {
		}
	}
}
