using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;
using System.Reflection;
using System.IO;

namespace IVX.Live.MainForm.View
{
    public partial class FormBehaviourEventAlarm : IVX.Live.MainForm.UILogics.FormBase
    {

        public FormBehaviourEventAlarm()
        {
            InitializeComponent();
            UseMdiDefaultWindow(true);
        }

        public override void UpdateUI()
        {
        }

        public override void Clear()
        {
            ucBehaviourEventAlarm1.Clear();
        }

        public override void DoAction(object action)
        {
            if (action is DataModel.TaskInfoV3_1)
            {

                ucBehaviourEventAlarm1.StartWithTaskAction((action as DataModel.TaskInfoV3_1).ToSearchItem());

            }

        }




        private void FormGisMap_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
        }

        private void FormGisMap_Shown(object sender, EventArgs e)
        {
        }
    }
}
