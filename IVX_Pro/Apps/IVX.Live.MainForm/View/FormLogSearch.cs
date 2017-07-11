using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IVX.Live.MainForm.View {
	public partial class FormLogSearch : IVX.Live.MainForm.UILogics.FormBase {
		public FormLogSearch()
		{
			InitializeComponent();
			UseMdiDefaultWindow(true);
		}

		public override void UpdateUI() 
		{

		}

		public override void Clear() 
		{
			this.m_logSearch.Clear();
		}
	}
}
