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
    public partial class FormPlayBrief : IVX.Live.MainForm.UILogics.FormBase
    {
        private ViewModel.PlayBriefViewModel m_viewModel;
        public FormPlayBrief()
        {
            InitializeComponent();
            UseMdiDefaultWindow(true);
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
            if (DesignMode)
                return;

            m_viewModel = new ViewModel.PlayBriefViewModel();
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<BriefObjectPlayBackEvent>().Subscribe(OnBriefObjectPlayBackEvent, Microsoft.Practices.Prism.Events.ThreadOption.WinFormUIThread);

        }


        private void expandableSplitter2_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (e.NewExpandedValue)
            {
                panel4.Width = panel2.Width / 2;
            }
        }
    }
}
