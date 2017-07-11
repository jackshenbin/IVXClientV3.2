using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IVX.Live.MainForm.View {
	public partial class FormReBootSer : IVX.Live.MainForm.UILogics.FormBase {

		public FormReBootSer() 
		{
			InitializeComponent();
			SetWindowSizeable(false);
		}

		public override void UpdateUI() 
		{

		}

		public override void Clear() 
		{

		
		}

		private void FormReBootSer_FormClosed(object sender, FormClosedEventArgs e) 
		{
			this.m_ucRebootSer.Clear();
		}
	}
}
