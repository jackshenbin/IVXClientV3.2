using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace IVX.Live.MainForm.View
{
    public partial class FormCrowdReatime : UILogics.FormBase
    {
        public FormCrowdReatime()
        {
            InitializeComponent();
            UseMdiDefaultWindow(true);
        }

        private void FormCrowdReatime_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        public override  void UpdateUI()
        {

        }

        public override void DoAction(object action)
        {            
            if (action is DataModel.TaskInfoV3_1)
            {
                ucCrowdRealTime1.StartWithTaskAction((action as DataModel.TaskInfoV3_1).ToSearchItem());
            }
        }


        public override  void Clear()
        {
            this.ucCrowdRealTime1.Clear();
        }

		private void FormCrowdReatime_Activated(object sender, EventArgs e)
		{
			ucCrowdRealTime1.RefreshTaskRoot();
		}
    }
}
