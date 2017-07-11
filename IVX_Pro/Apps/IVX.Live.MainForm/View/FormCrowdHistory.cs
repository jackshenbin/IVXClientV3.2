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
    public partial class FormCrowdHistory : UILogics.FormBase
    {
        public FormCrowdHistory()
        {
            InitializeComponent();
            UseMdiDefaultWindow(true);
        }

        private void FormCrowdHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        public override  void UpdateUI()
        {

        }

        public override void DoAction(object action)
        {
            if (action is DataModel.TaskInfoV3_1)
            {

                ucCrowdHistory1.StartWithTaskAction((action as DataModel.TaskInfoV3_1).ToSearchItem());

            }


        }
        public override  void Clear()
        {
            this.ucCrowdHistory1.Clear();
        }

    }
}
