using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;

namespace IVX.Live.MainForm.View
{
    public partial class FormPlayBriefNew : IVX.Live.MainForm.UILogics.FormBase
    {
        public FormPlayBriefNew(TaskInfoV3_1 task)
        {
            InitializeComponent();
            ShowStatusBar = true;
            ucPlayBrief1.Task = task;
            ucPlayHistory1.ShowGotoCompare = task.StatusList.Exists(xx => xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ_PLATFORM);
        }

        public override void UpdateUI()
        {
        }

        public override void Clear()
        {
            ucPlayHistory1.Clear();
            ucPlayBrief1.Clear();
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<BriefObjectPlayBackEvent>().Unsubscribe(OnBriefObjectPlayBackEvent);
        }

        private void OnBriefObjectPlayBackEvent(VodInfo info)
        {
            expandableSplitter2.Expanded = true;
        }


        private void FormPlayHistory_Load(object sender, EventArgs e)
        {
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<BriefObjectPlayBackEvent>().Subscribe(OnBriefObjectPlayBackEvent, Microsoft.Practices.Prism.Events.ThreadOption.WinFormUIThread);

        }


        private void expandableSplitter2_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (e.NewExpandedValue)
            {
                panel4.Width = panel2.Width / 2;
            }
        }

        private void FormPlayBriefNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            Clear();
        }

        private void ucPlayHistory1_CloseThis(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
