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
    public partial class FormAddEditFaceBlacklist : IVX.Live.MainForm.UILogics.FormBase
    {
        SettingViewModel m_viewModel;
        public uint VideoSupplierId { get; set; }
        public string VideoSupplierNmae { get; set; }

        public FormAddEditFaceBlacklist()
        {
            InitializeComponent();
            SetWindowSizeable(false);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
                DialogResult =System.Windows.Forms.DialogResult.OK;
        }


        private void buttonX1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
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