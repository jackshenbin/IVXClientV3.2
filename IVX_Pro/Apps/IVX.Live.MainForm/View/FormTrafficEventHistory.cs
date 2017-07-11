using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IVX.Live.MainForm.View
{
    public partial class FormTrafficEventHistory : IVX.Live.MainForm.UILogics.FormBase
    {


        public FormTrafficEventHistory()
        {
            InitializeComponent();
            UseMdiDefaultWindow(true);

        }

        private void expandableSplitter1_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {

        }

        public override void UpdateUI()
        {
        }

        public override void Clear()
        {
            ucSearchTrafficEventSetting1.Clear();
            ucSearchResultPanel1.Clear();

        }


        void uc_OnCancel(object sender, EventArgs e)
        {
        }

        void uc_OnOk(object sender, EventArgs e)
        {
        }

        private void FormMoveObjectSearch_Load(object sender, EventArgs e)
        {
            ucSearchResultPanel1.InitPanel(DataModel.SearchType.AllMoveObj);
        }
    }
}
