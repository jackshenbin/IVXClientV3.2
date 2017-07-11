using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.Live.ViewModel;
using IVX.DataModel;

namespace IVX.Live.MainForm.View
{
    public partial class ucSearchTrafficEventSetting : UserControl
    {
        public  SearchMoveObjectViewModel m_viewModel;
        public event EventHandler OnOk;
        public event EventHandler Reset;
        public event EventHandler OnCancel;
        public SearchType SearchType { get; set; }
        public string Title { get { return label1.Text; } set { label1.Text = value; } }

        [DefaultValue(true)]
        public bool ShowCompareSearch { get { return expandablePanel1.Visible; } set { expandablePanel1.Visible = value; } }
        public ucSearchTrafficEventSetting()
        {
            InitializeComponent();
            m_viewModel = new SearchMoveObjectViewModel();
            SearchType = DataModel.SearchType.Person;
        }
        public void Clear()
        {
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            m_viewModel.SearchItems = new DataModel.SearchItemGroup()
            {
                SearchItems = new List<DataModel.SearchItemV3_1>(),
                SearchType = this.SearchType,
            };
            List<DataModel.SearchItemV3_1> list= buttonSelectSearchItem.Tag as List<DataModel.SearchItemV3_1>;
            if (list != null && list.Count > 0)
            {
            m_viewModel.SearchItems.SearchItems.AddRange(list);
            }


            //m_viewModel.SearchItems.SearchItems.Add(new DataModel.SearchItemV3_1() { CameraID = "1", TaskId = 1, TaskName = "task1", CameraName = "cam1", SearchHandle = 0 });
            //m_viewModel.SearchItems.SearchItems.Add(new DataModel.SearchItemV3_1() { CameraID = "2", TaskId = 1, TaskName = "task2", CameraName = "cam2", SearchHandle = 0 });
            //m_viewModel.SearchItems.SearchItems.Add(new DataModel.SearchItemV3_1() { CameraID = IVX.DataModel.Common.VIRTUAL_CAMERA_ID+"2",TaskId = 1, TaskName = "task3", CameraName = "cam3", SearchHandle = 0 });
            m_viewModel.StartTime = dateTimeStart.Value;
            m_viewModel.StopTime = dateTimeEnd.Value;
            string msg = "";
            if (m_viewModel.Commit(out msg))
            {

                if (OnOk != null)
                    OnOk(this, e);
            }
            else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(msg, Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        public virtual void ClearSetting()
        {
            checkBoxST.Checked = false;
            checkBoxET.Checked = false;
            dateTimeStart.Enabled = false;
            dateTimeEnd.Enabled = false;
            dateTimeEnd.Value = DataModel.Common.MAXTIME;
            dateTimeStart.Value = DataModel.Common.ZEROTIME;


            buttonSelectSearchItem.Text = "设置...";
            buttonSelectSearchItem.Tag = null;

            m_viewModel.FeatureType = E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_STRUCTURED;
            expandablePanel5.Expanded = false;
            expandablePanel1.Expanded = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (OnCancel != null)
                OnCancel(this, e);

        }



        private void ucMoveObjSearchSetting_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            dateTimeEnd.Value = DataModel.Common.MAXTIME;
            dateTimeStart.Value = DataModel.Common.ZEROTIME;
        }

        private void expandablePanel4_Click(object sender, EventArgs e)
        {

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            if(Reset!=null)
                Reset(this, e);
        }

        private void buttonSelectSearchItem_Click(object sender, EventArgs e)
        {
            FormSelectSearchItem f = new FormSelectSearchItem();
            f.InitSelectedList(buttonSelectSearchItem.Tag as List<DataModel.SearchItemV3_1>);
            if (f.ShowDialog() == DialogResult.OK)
            {
                buttonSelectSearchItem.Tag = f.SearchItemList;
                if (f.SearchItemList.Count > 1)
                {
                    buttonSelectSearchItem.Text = "【"+f.SearchItemList[0].CameraName +"】等"+f.SearchItemList.Count+"个";
                }
                else if (f.SearchItemList.Count == 1)
                {
                    buttonSelectSearchItem.Text = f.SearchItemList[0].CameraName;
                }
                else
                {
                    buttonSelectSearchItem.Text = "设置...";
                }
            }

        }

        private void checkBoxST_CheckedChanged(object sender, EventArgs e)
        {
            dateTimeStart.Enabled = checkBoxST.Checked;
            if (!checkBoxST.Checked)
            {
                dateTimeStart.Value = DataModel.Common.ZEROTIME;
            }
            else
            {
                dateTimeStart.Value = DateTime.Now.AddDays(-1);
            }
        }

        private void checkBoxET_CheckedChanged(object sender, EventArgs e)
        {
            dateTimeEnd.Enabled = checkBoxET.Checked;
            if (!checkBoxET.Checked)
            {
                dateTimeEnd.Value = DataModel.Common.MAXTIME;
            }
            else
            {
                dateTimeEnd.Value = DateTime.Now;
            }

        }


    }
}
