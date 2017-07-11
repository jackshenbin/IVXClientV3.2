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
    public partial class FormPeopleSearch : IVX.Live.MainForm.UILogics.FormBase
    {


        public FormPeopleSearch()
        {
            InitializeComponent();
            UseMdiDefaultWindow(true);
        }

        private void expandableSplitter1_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {

        }

        public override void UpdateUI()
        {
        }

        public override void Clear()
        {
            ucPeopleSearchSetting1.Clear();
            ucSearchResultPanel1.Clear();

        }

        public override void DoAction(object action)
        {
            if (action is DataModel.TaskInfoV3_1)
            {
                DataModel.BeginSearchInfo bi = new DataModel.BeginSearchInfo();
                bi.SearchItem = (action as DataModel.TaskInfoV3_1).ToSearchItem();
                bi.Image = null;
                bi.IsRealtimeTask = (action as DataModel.TaskInfoV3_1).TaskType == DataModel.TaskType.Realtime;
                ucPeopleSearchSetting1.SetBegionSearchInfo(bi);

            }
            else if( action is DataModel.CameraInfoV3_1)
            {
                DataModel.BeginSearchInfo bi = new DataModel.BeginSearchInfo();
                bi.SearchItem = (action as DataModel.CameraInfoV3_1).ToSearchItem();
                bi.Image = null;
                bi.IsRealtimeTask = true;
                ucPeopleSearchSetting1.SetBegionSearchInfo(bi);

            }
            else if (action is DataModel.BeginSearchInfo)
            {
                ucPeopleSearchSetting1.SetBegionSearchInfo(action as DataModel.BeginSearchInfo );
            }
        }

        void uc_OnCancel(object sender, EventArgs e)
        {
        }

        void uc_OnOk(object sender, EventArgs e)
        {
        }

        private void FormMoveObjectSearch_Load(object sender, EventArgs e)
        {
            ucSearchResultPanel1.InitPanel(DataModel.SearchType.Person);
        }
    }
}
