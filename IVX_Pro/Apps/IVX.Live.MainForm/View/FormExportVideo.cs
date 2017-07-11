using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using IVX.DataModel;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class FormExportVideo : IVX.Live.MainForm.UILogics.FormBase
    {
        public FormExportVideo(DataModel.TaskInfoV3_1 task)
        {
            InitializeComponent();
            ucExportVideo1.Task = task;
            ucExportVideo1.OnOK += ucExportVideo1_OnOK;
        }

        void ucExportVideo1_OnOK(object sender, EventArgs e)
        {
            this.Close();
        }


        private void FormExportVideo_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

        }

        private void FormExportVideo_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucExportVideo1.Clear();
        }



       

    }
}
