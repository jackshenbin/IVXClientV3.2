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
    public partial class FormPlayRealtime : IVX.Live.MainForm.UILogics.FormBase
    {
        public FormPlayRealtime(DataModel.TaskInfoV3_1 task)
        {
            InitializeComponent();
            ucPlayHistory1.Task = task;

        }


        private void FormSingleTask_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

        }

        private void FormSingleTask_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucPlayHistory1.Clear();
        }


        void ucPlayHistory1_CloseThis(object sender, System.EventArgs e)
        {
            this.Close();
        }

       

    }
}
