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

namespace IVX.Live.MainForm.View {
	public partial class ucFaceSearchResultPanel : UserControl {

		int m_showColumnCount = 5;
		ucSingleSearchResult m_currentResult;
		private ucSingleSearchResult[,] ControlList = new ucSingleSearchResult[6, 6];


		private int PAGE_COUNT { get; set; }
		private int m_pageIndex;

		List<FaceAlarmInfoV3_1>    m_faceInfoList;
		List<SearchResultFace>     m_faceHistoryList;

		[DefaultValue(5)]
		public int LayoutColumnCount {
			get { return m_showColumnCount; }
			set {
				if (m_showColumnCount != value) {
					float percent = 100f / value;
					tableLayoutPanel1.SuspendLayout();
					this.tableLayoutPanel1.ColumnStyles.Clear();
					this.tableLayoutPanel1.RowStyles.Clear();
					for (int i = 0; i < value; i++) {
						this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, percent));
						this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, percent));
					}

					for (int i = 0; i < 6 - value; i++) {
						this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0));
						this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0));
					}

					tableLayoutPanel1.ResumeLayout();
					m_showColumnCount = value;
				}
			}
		}

		public ucFaceSearchResultPanel() {
			InitializeComponent();
			tableLayoutPanel1.Controls.Clear();
			PAGE_COUNT = 25;
			for (int i = 0; i < 36; i++) {
				ucSingleSearchResult uc = new ucSingleSearchResult();
				uc.Group = 1;
				uc.Click += uc_Click;
				uc.DoubleClick += uc_DoubleClick;
				uc.Visible = false;
				uc.Dock = DockStyle.Fill;
				int row = i % 6;
				int col = i / 6;
				this.tableLayoutPanel1.Controls.Add(uc, row, col);
				ControlList[row, col] = uc;
			}
		}

		void uc_DoubleClick(object sender, EventArgs e) {
			FormSingleFaceAlarmInfo faceSearchInfo = new FormSingleFaceAlarmInfo();
			faceSearchInfo.Init((FaceAlarmInfoV3_1)((ucSingleSearchResult)sender).Tag);
			faceSearchInfo.ShowDialog();
		}

		void uc_Click(object sender, EventArgs e) {
			ucSingleSearchResult uc = sender as ucSingleSearchResult;
			if (uc != null && uc.Checked) { m_currentResult = uc; }
		}

        private void ucSearchResultPanel_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
			StopWait();
        }

        private void DoShowFirstResults()
        {
            ShowResults(GetFirstPage());
        }

        public void m_viewModel_SearchFinished(object faceInfoList, EventArgs e)
        {
            if (InvokeRequired)
            {
				this.Invoke(new EventHandler(m_viewModel_SearchFinished), faceInfoList, e);
            }
            else
            {
				GetFaceResultList((List<FaceAlarmInfoV3_1>)faceInfoList);
				panelEx1.Visible = false;
				pageNavigatorEx1.MaxCount = m_faceInfoList.Count/PAGE_COUNT + 1;
				pageNavigatorEx1.Index = 1;
				labelRecordCountInfo.Text = string.Format("总记录数 {0} 条，共分 {1} 页", m_faceInfoList.Count, m_faceInfoList.Count / PAGE_COUNT + 1);
				new System.Threading.Thread(DoShowFirstResults).Start();
            }
        }

		private void GetFaceResultList(List<FaceAlarmInfoV3_1> faceInfoList)
		{
			m_faceInfoList = faceInfoList;
		}

		private void ShowResults(List<FaceAlarmInfoV3_1> list)
        {
            if (InvokeRequired)
            {
				Invoke(new Action<List<FaceAlarmInfoV3_1>>(ShowResults), list);
            }
            else
            {
                for (int i = 0; i < 36; i++)
                {
                    int row = i % 6;
                    int col = i / 6;
                    ucSingleSearchResult c = ControlList[row,col] as ucSingleSearchResult;
                    if (c != null)
                    {
                        c.Visible = false;
                    }
                }

                for (int i = 0; i < Math.Min( list.Count,m_showColumnCount*m_showColumnCount); i++)
                {
                    int row = i % m_showColumnCount;
                    int col = i / m_showColumnCount;
                    ucSingleSearchResult c = ControlList[row,col] as ucSingleSearchResult;
                    if (c != null)
                    {
                        c.ShowResult(list[i]);
						c.Tag = list[i];
                        c.Visible = true;
						c.Update();
                    }
                }
            }
        }

        private void buttonLayout4_Click(object sender, EventArgs e)
        {
            if (LayoutColumnCount != 4)
            {
                LayoutColumnCount = 4;
                PAGE_COUNT = 16;
				pageNavigatorEx1.MaxCount = m_faceInfoList.Count / PAGE_COUNT + 1;
                pageNavigatorEx1.Index = 1;
				labelRecordCountInfo.Text = string.Format("总记录数 {0} 条，共分 {1} 页", m_faceInfoList.Count, m_faceInfoList.Count / PAGE_COUNT + 1);
				ShowResults(GetFirstPage());
            }
        }

        private void buttonLayout5_Click(object sender, EventArgs e)
        {
            if (LayoutColumnCount != 5)
            {
                LayoutColumnCount = 5;
                PAGE_COUNT = 25;
				pageNavigatorEx1.MaxCount = m_faceInfoList.Count / PAGE_COUNT + 1;
                pageNavigatorEx1.Index = 1;
				labelRecordCountInfo.Text = string.Format("总记录数 {0} 条，共分 {1} 页", m_faceInfoList.Count, m_faceInfoList.Count / PAGE_COUNT + 1);
				ShowResults(GetFirstPage());
            }
        }

        private void buttonLayout6_Click(object sender, EventArgs e)
        {
            if (LayoutColumnCount != 6)
            {
                LayoutColumnCount = 6;
                PAGE_COUNT = 36;
				pageNavigatorEx1.MaxCount = m_faceInfoList.Count / PAGE_COUNT + 1;
                pageNavigatorEx1.Index = 1;
				labelRecordCountInfo.Text = string.Format("总记录数 {0} 条，共分 {1} 页", m_faceInfoList.Count, m_faceInfoList.Count / PAGE_COUNT + 1);
                ShowResults(GetFirstPage());
            }
        }

        internal void Clear()
        {
            tableLayoutPanel1.Controls.Clear();
            foreach (ucSingleSearchResult c in ControlList)
            {
                if (c != null)
                {
                    c.Clear();
                    c.Dispose();
                }
            }
        }

		private void pageNavigatorEx1_FirstClick(object sender, EventArgs e) {
			ShowResults(GetFirstPage());
		}

		private void pageNavigatorEx1_LastClick(object sender, EventArgs e) {
			ShowResults(GetLastPage());
		}

		private void pageNavigatorEx1_NextClick(object sender, EventArgs e) {
			ShowResults(GetNextPage());
		}

		private void pageNavigatorEx1_PrivClick(object sender, EventArgs e) {
			ShowResults(GetPrivPage());
		}

		private List<FaceAlarmInfoV3_1> GetFaceDataList() {
			List<FaceAlarmInfoV3_1> retList = new List<FaceAlarmInfoV3_1> { };
			int startIndex = m_pageIndex * PAGE_COUNT;
			for (int i = startIndex, j = 0; i < m_faceInfoList.Count && j < PAGE_COUNT; i++, j++) {
				retList.Add(m_faceInfoList[i]);
			}
			return retList;
		}

		private List<FaceAlarmInfoV3_1> GetFirstPage() {
			m_pageIndex = 0;
			return GetFaceDataList();
		}

		private List<FaceAlarmInfoV3_1> GetLastPage() {
			m_pageIndex = m_faceInfoList.Count / PAGE_COUNT;
			return GetFaceDataList();
		}

		private List<FaceAlarmInfoV3_1> GetNextPage() {
			m_pageIndex++;
			if (m_pageIndex > m_faceInfoList.Count / PAGE_COUNT) {
				m_pageIndex = m_faceInfoList.Count / PAGE_COUNT;
			}
			return GetFaceDataList();
		}

		private List<FaceAlarmInfoV3_1> GetPrivPage() {
			m_pageIndex--;
			if (m_pageIndex == -1) {
				m_pageIndex = 0;
			}
			return GetFaceDataList();
		}

		public void StartWait() {
			panelEx1.Visible = true;
			waitProgress.IsRunning = true;
			waitProgress.Visible = true;
		}

		public void StopWait() {
			panelEx1.Visible = false;
			waitProgress.IsRunning = false;
			waitProgress.Visible = false;
		}
	}
}
