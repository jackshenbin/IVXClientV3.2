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

namespace IVX.Live.MainForm.View
{
    public partial class FormPlayHistory : IVX.Live.MainForm.UILogics.FormBase
    {

        public FormPlayHistory()
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
            ucPlayHistory1.Clear();
        }



        private void FormPlayHistory_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            
        }


    }
}
