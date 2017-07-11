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
    public partial class ucSearchSettingBase : UserControl
    {
        public  SearchMoveObjectViewModel m_viewModel;
        public event EventHandler OnOk;
        public event EventHandler Reset;
        public event EventHandler OnCancel;
        public SearchType SearchType { get; set; }
        public string Title { get { return label1.Text; } set { label1.Text = value; } }

        [DefaultValue(true)]
        public bool ShowCompareSearch { get { return expandablePanel1.Visible; } set { expandablePanel1.Visible = value; } }
        public ucSearchSettingBase()
        {
            InitializeComponent();
            m_viewModel = new SearchMoveObjectViewModel();
            SearchType = DataModel.SearchType.Person;
			m_viewModel.SearchFinished += m_viewModel_SearchFinished;
        }
		void m_viewModel_SearchFinished(object sender, EventArgs e) {
			if (InvokeRequired) {
				this.Invoke(new EventHandler(m_viewModel_SearchFinished), sender, e);
			}
			else {
				buttonOk.Enabled = true;
			}
		}
        public void Clear()
        {
        }

        public void SetBegionSearchInfo(DataModel.BeginSearchInfo begininfo)
        {
			m_treeList.SetSingleCheckNode(begininfo.SearchItem);
            if (begininfo.Image != null)
            {
                pictureBox1.Image = begininfo.Image;
                pictureBox1.Tag = begininfo.PictureParam;
                if (begininfo.PictureParam.IsBreakRegion || begininfo.PictureParam.IsPassLine)
                    m_viewModel.FeatureType |= E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_PASSLINE;
                else
                    m_viewModel.FeatureType &= ~E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_PASSLINE;

                if (begininfo.PictureParam.IsGlobalRegion)
                    m_viewModel.FeatureType |= E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_GLOBAL;
                else
                    m_viewModel.FeatureType &= ~E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_GLOBAL;

                if (begininfo.PictureParam.IsParticalRegion)
                    m_viewModel.FeatureType |= E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_PARTICAL;
                else
                    m_viewModel.FeatureType &= ~E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_PARTICAL;

                expandablePanel1.Expanded = true;
            }
            else
            {
                pictureBox1.Tag = null;
                pictureBox1.Image = Properties.Resources.bkpng;
                m_viewModel.FeatureType = E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_STRUCTURED;
                expandablePanel1.Expanded = false;
            }

            if (begininfo.IsRealtimeTask)
            {
                checkBoxST.Checked = true;
                checkBoxET.Checked = true;
                dateTimeStart.Enabled = true;
                dateTimeEnd.Enabled = true;
                dateTimeEnd.Value = DateTime.Now;
                dateTimeStart.Value = DateTime.Now.AddHours(-12);
                expandablePanel5.Expanded = true;
            }
            else
            {
                checkBoxST.Checked = false;
                checkBoxET.Checked = false;
                dateTimeStart.Enabled = false;
                dateTimeEnd.Enabled = false;
                dateTimeEnd.Value = DataModel.Common.MAXTIME;
                dateTimeStart.Value = DataModel.Common.ZEROTIME;
                expandablePanel5.Expanded = false;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

			CheckTime ret = DataModel.Common.CheckDataTime(checkBoxST.Checked ? dateTimeStart.Value : new DateTime(2050), checkBoxET.Checked ? dateTimeEnd.Value : new DateTime(2050));
			if ((ret == CheckTime.START_INVALID)&&checkBoxST.Checked) {
				MessageBox.Show("开始时间不正常!");
				return;
			}
			else if ((ret == CheckTime.END_INVALID) && checkBoxET.Checked) {
				MessageBox.Show("结束时间不正常!");
				return;
			}

			//添加资源树
			List<DataModel.SearchItemV3_1> list = null;//带选择的资源树列表 //= buttonSelectSearchItem.Tag as List<DataModel.SearchItemV3_1>;
			if (m_treeList.IsHasChecked) {
				list = m_treeList.GetCheckTSearchList();
			}
			m_viewModel.SearchItems = new DataModel.SearchItemGroup() {
				SearchItems = new List<DataModel.SearchItemV3_1>(),
				SearchType = this.SearchType,
			};
			if (list != null && list.Count > 0)
            {
			   m_viewModel.SearchItems.SearchItems.AddRange(list);
            }
            if (pictureBox1.Tag != null && pictureBox1.Tag is SelectedPictureParam)
            {
                SelectedPictureParam param = pictureBox1.Tag as SelectedPictureParam;
                if (param.GlobalRegion.Count >= 4)
                {

                    int x = Math.Min(Math.Min(param.GlobalRegion[0].X, param.GlobalRegion[1].X), Math.Min(param.GlobalRegion[2].X, param.GlobalRegion[3].X));
                    int y = Math.Min(Math.Min(param.GlobalRegion[0].Y, param.GlobalRegion[1].Y), Math.Min(param.GlobalRegion[2].Y, param.GlobalRegion[3].Y));
                    int maxx = Math.Max(Math.Max(param.GlobalRegion[0].X, param.GlobalRegion[1].X), Math.Max(param.GlobalRegion[2].X, param.GlobalRegion[3].X));
                    int maxy = Math.Max(Math.Max(param.GlobalRegion[0].Y, param.GlobalRegion[1].Y), Math.Max(param.GlobalRegion[2].Y, param.GlobalRegion[3].Y));
                    int w = maxx - x;
                    int h = maxy - y;
                    m_viewModel.ObjRect = new Rectangle(x, y, w, h);
                }
                else
                {
                    m_viewModel.ObjRect = new Rectangle();
                }

                if (param.ParticalRegion.Count >= 4)
                {

                    int x = Math.Min(Math.Min(param.ParticalRegion[0].X, param.ParticalRegion[1].X), Math.Min(param.ParticalRegion[2].X, param.ParticalRegion[3].X));
                    int y = Math.Min(Math.Min(param.ParticalRegion[0].Y, param.ParticalRegion[1].Y), Math.Min(param.ParticalRegion[2].Y, param.ParticalRegion[3].Y));
                    int maxx = Math.Max(Math.Max(param.ParticalRegion[0].X, param.ParticalRegion[1].X), Math.Max(param.ParticalRegion[2].X, param.ParticalRegion[3].X));
                    int maxy = Math.Max(Math.Max(param.ParticalRegion[0].Y, param.ParticalRegion[1].Y), Math.Max(param.ParticalRegion[2].Y, param.ParticalRegion[3].Y));
                    int w = maxx - x;
                    int h = maxy - y;
                    m_viewModel.ObjDetailRect = new Rectangle(x, y, w, h);
                }
                else
                {
                    m_viewModel.ObjDetailRect = new Rectangle();
                }


                m_viewModel.PassLineSet = param.PassLineList;
                m_viewModel.RegionSet = param.BreakRegionList;
                m_viewModel.PictureData = param.BasePicture;
            }
            else
            { 
                m_viewModel.PassLineSet = new List<PassLine>();
                m_viewModel.RegionSet = new List<BreakRegion>();
                m_viewModel.PictureData = new System.Drawing.Bitmap(1, 1);
            }
            //m_viewModel.SearchItems.SearchItems.Add(new DataModel.SearchItemV3_1() { CameraID = "1", TaskId = 1, TaskName = "task1", CameraName = "cam1", SearchHandle = 0 });
            //m_viewModel.SearchItems.SearchItems.Add(new DataModel.SearchItemV3_1() { CameraID = "2", TaskId = 1, TaskName = "task2", CameraName = "cam2", SearchHandle = 0 });
            //m_viewModel.SearchItems.SearchItems.Add(new DataModel.SearchItemV3_1() { CameraID = IVX.DataModel.Common.VIRTUAL_CAMERA_ID+"2",TaskId = 1, TaskName = "task3", CameraName = "cam3", SearchHandle = 0 });
            m_viewModel.StartTime = dateTimeStart.Value;
            m_viewModel.StopTime = dateTimeEnd.Value;
			buttonOk.Enabled = false;
            string msg = "";
            if (m_viewModel.Commit(out msg))
            {

                if (OnOk != null)
                    OnOk(this, e);
            }
            else
            {
				buttonOk.Enabled = true;
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

            pictureBox1.Tag = null;
            pictureBox1.Image = Properties.Resources.bkpng;
            m_viewModel.FeatureType = E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_STRUCTURED;
            expandablePanel5.Expanded = false;
            expandablePanel1.Expanded = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (OnCancel != null)
                OnCancel(this, e);

        }

		private void SetTreeArg() {
			m_treeList.HasRootNode = false;
			m_treeList.HasCheck = true;
			m_treeList.MuliteCheck = true;
			// moveObj
			m_treeList.AnalyseFilter = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ_PLATFORM;
			m_treeList.HasHistoryTask = true;
			m_treeList.TreeTitle = label1.Text+"列表";
		}

        private void ucMoveObjSearchSetting_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            dateTimeEnd.Value = DataModel.Common.MAXTIME;
            dateTimeStart.Value = DataModel.Common.ZEROTIME;
            pictureBox1.Tag = null;
			SetTreeArg();
			m_treeList.InitTree();
        }


        private void expandablePanel4_Click(object sender, EventArgs e)
        {

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            if(Reset!=null)
                Reset(this, e);
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
                dateTimeStart.Value = DateTime.Now.AddHours(-12);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormSelectCompareParam f = new FormSelectCompareParam();
            SelectedPictureParam pic = pictureBox1.Tag as SelectedPictureParam;
            if (pic != null)
            {
                f.InitPicture(pic.BasePicture, pic);
            }
            if (f.ShowDialog() == DialogResult.OK)
            {
                if (f.SelectedPicture != null)
                {
                    var param = f.PictureParam;
                    pictureBox1.Image = param.DemoPicture;
                    pictureBox1.Tag = param;
                    if (param.IsBreakRegion || param.IsPassLine)
                        m_viewModel.FeatureType |= E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_PASSLINE;
                    else
                        m_viewModel.FeatureType &= ~E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_PASSLINE;

                    if (param.IsGlobalRegion)
                        m_viewModel.FeatureType |= E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_GLOBAL;
                    else
                        m_viewModel.FeatureType &= ~E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_GLOBAL;

                    if (param.IsParticalRegion)
                        m_viewModel.FeatureType |= E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_PARTICAL;
                    else
                        m_viewModel.FeatureType &= ~E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_PARTICAL;
                }
                else
                {
                    pictureBox1.Tag = null;
                    pictureBox1.Image = Properties.Resources.bkpng;
                    m_viewModel.FeatureType = E_SEARCH_FEATURE_TYPE.E_SEARCH_FEATURE_TYPE_STRUCTURED;

                }
            }
        }

    }
}
