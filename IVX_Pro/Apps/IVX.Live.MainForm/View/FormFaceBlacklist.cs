using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class FormFaceBlacklist : UILogics.FormBase
    {
        public FormFaceBlacklist()
        {
            InitializeComponent();
            UseMdiDefaultWindow(true);
            ShowStatusBar = false;
        }

        public override void UpdateUI()
        {
        }

        public override void Clear()
        {
        }




        private void buttonAddServer_Click(object sender, EventArgs e)
        {
            FormAddEditFaceBlacklist f = new FormAddEditFaceBlacklist();
            f.ShowDialog();
        }


    }
}
