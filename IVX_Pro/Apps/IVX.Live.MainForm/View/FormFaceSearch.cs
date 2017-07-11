using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using DevComponents.DotNetBar;
using IVX.DataModel;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class FormFaceSearch : IVX.Live.MainForm.UILogics.FormBase
    {

        public FormFaceSearch()
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

        private void FormLogin_Load(object sender, EventArgs e)
        {
        }
    }
}