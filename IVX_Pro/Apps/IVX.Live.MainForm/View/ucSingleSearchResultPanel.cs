using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class ucSingleSearchResultPanel : UserControl
    {

        public event EventHandler ClearSearch;
        SingleSearchResultPanelViewModel m_viewModel;
        int m_showColumnCount = 5;
        ucSingleSearchResult m_currentResult;
        private ucSingleSearchResult[,] ControlList = new ucSingleSearchResult[6,6];

        private DateTime StartSearchTime { get; set; }
        private DateTime FinishSearchTime { get; set; }

        [DefaultValue(5)]
        public int LayoutColumnCount 
        {
            get { return m_showColumnCount; }
            set
            {
                if (m_showColumnCount != value)
                {
                    float percent = 100f / value;
                    tableLayoutPanel1.SuspendLayout();
                    this.tableLayoutPanel1.ColumnStyles.Clear();
                    this.tableLayoutPanel1.RowStyles.Clear();
                    for (int i = 0; i < value; i++)
                    {
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, percent));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, percent));
                    }
                    for (int i = 0; i < 6 - value; i++)
                    {
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0));
                    }
                    tableLayoutPanel1.ResumeLayout();
                    m_showColumnCount = value;
                }
            }
        }
        uint m_searchHandle;
        uint m_taskId;
        public ucSingleSearchResultPanel()
        {
            InitializeComponent();
            tableLayoutPanel1.Controls.Clear();
            for (int i = 0; i < 36; i++)
			{
			     ucSingleSearchResult uc = new ucSingleSearchResult();
                 uc.Group = 1;
                 uc.Click += uc_Click;
                 uc.DoubleClick += uc_DoubleClick;
                 uc.Visible = false;
                uc.Dock = DockStyle.Fill;
                int row = i % 6;
                int col = i / 6;
                this.tableLayoutPanel1.Controls.Add(uc, row, col);
                    ControlList[row,col] = uc;
			}

        }

        void uc_DoubleClick(object sender, EventArgs e)
        {
            ucSingleSearchResult uc = sender as ucSingleSearchResult;
            if (uc != null && uc.Checked)
            {
                m_currentResult = uc;
                FormSingleSearchDitailResult r = new FormSingleSearchDitailResult();
                r.Init(m_viewModel, m_taskId);
                r.ShowResult(uc.Record);
                r.ShowDialog();
                r.Clear();
                r.Dispose();
                r = null;
            }
        }

        void uc_Click(object sender, EventArgs e)
        {
			ucSingleSearchResult uc = sender as ucSingleSearchResult;
            if (uc != null && uc.Checked)
            { m_currentResult = uc; }
        }
        public ucSingleSearchResultPanel(uint searchHandle, uint taskId)
            : this()
        {
            m_searchHandle = searchHandle;
            m_taskId = taskId;
            m_viewModel = new SingleSearchResultPanelViewModel();
            m_viewModel.SearchFinished += m_viewModel_SearchFinished;
            m_viewModel.SearchHandle = m_searchHandle;
            StartSearchTime = new DateTime();
            FinishSearchTime = new DateTime();

        }

        public void SearchBegin()
        {
            circularProgress1.IsRunning = true;
            circularProgress1.Visible = true ;
            panelEx1.Visible = true;
            StartSearchTime = DateTime.Now;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
        }

        private void buttonClearSearch_Click(object sender, EventArgs e)
        {
            circularProgress1.IsRunning = false;
            circularProgress1.Visible = false;
            panelEx1.Visible = false;
            if (ClearSearch != null)
                ClearSearch(this,e);
        }
        //private void CloseLastSearch()
        //{
        //   if(m_viewModel!=null) 
        //       m_viewModel.Clear();
        //}
        private void ucSearchResultPanel_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

        }
        private void DoShowFirstResults()
        {
            ShowResults(m_viewModel.FirstPage());

        }
        void m_viewModel_SearchFinished(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EventHandler(m_viewModel_SearchFinished), sender, e);
            }
            else
            {
                FinishSearchTime = DateTime.Now;
                ShowSearchTime();
                if (m_viewModel.SearchStatus == DataModel.E_VDA_SEARCH_STATUS.E_VDA_SEARCH_STATUS_FINISH)
                {
                    circularProgress1.IsRunning = false;
                    panelEx1.Visible = false;

                    pageNavigatorEx1.MaxCount = m_viewModel.TotalPageCount + 1;
                    pageNavigatorEx1.Index = 1;
                    labelRecordCountInfo.Text = string.Format("总记录数 {0} 条，共分 {1} 页", m_viewModel.TotalCount, m_viewModel.TotalPageCount + 1);
                    new System.Threading.Thread(DoShowFirstResults).Start();
                }
                else
                {
                    pageNavigatorEx1.MaxCount = 0;
                    pageNavigatorEx1.Index = 0;
                    labelRecordCountInfo.Text = "";

                    string msg = "";
                    switch (m_viewModel.SearchStatus)
                    {
                        case IVX.DataModel.E_VDA_SEARCH_STATUS.E_VDA_SEARCH_STATUS_ERROR:
                            msg = "检索失败";
                            break;
                        case IVX.DataModel.E_VDA_SEARCH_STATUS.E_VDA_SEARCH_STATUS_RUNING:
                            break;
                        case IVX.DataModel.E_VDA_SEARCH_STATUS.E_VDA_SEARCH_STATUS_FINISH:
                            break;
                        case IVX.DataModel.E_VDA_SEARCH_STATUS.E_VDA_SEARCH_STATUS_ERROR_STARTFAILED:
                            msg = "检索失败，无法连接检索服务器";
                            break;
                        case IVX.DataModel.E_VDA_SEARCH_STATUS.E_VDA_SEARCH_STATUS_ERROR_NOSUCHITEM:
                            msg = "检索失败，无此视频";
                            break;
                        default:
                            break;
                    }
                    circularProgress1.IsRunning = false;
                    circularProgress1.Visible = false;
                    panelEx1.Text = msg;
                }
                m_viewModel.SearchFinished -= m_viewModel_SearchFinished;
            }
        }

        private void ShowSearchTime()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ShowSearchTime));

            }
            else
            {
                labelItemTime.Text = "耗时：" + FinishSearchTime.Subtract(StartSearchTime).TotalMilliseconds.ToString("0") + "ms";
            }
        }
        private void ShowResults(List<DataModel.SearchResultRecordV3_1> list)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<List<DataModel.SearchResultRecordV3_1>>(ShowResults), list);
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
                        c.Visible = true;
                    }
                }
            }
        }

        private void buttonLayout4_Click(object sender, EventArgs e)
        {
            if (LayoutColumnCount != 4)
            {
                LayoutColumnCount = 4;
                m_viewModel.PAGE_COUNT = 16;
                pageNavigatorEx1.MaxCount = m_viewModel.TotalPageCount + 1;
                pageNavigatorEx1.Index = 1;
                labelRecordCountInfo.Text = string.Format("总记录数 {0} 条，共分 {1} 页", m_viewModel.TotalCount, m_viewModel.TotalPageCount + 1);

                ShowResults(m_viewModel.FirstPage());
            }
        }

        private void buttonLayout5_Click(object sender, EventArgs e)
        {
            if (LayoutColumnCount != 5)
            {
                LayoutColumnCount = 5;
                m_viewModel.PAGE_COUNT = 25;
                pageNavigatorEx1.MaxCount = m_viewModel.TotalPageCount + 1;
                pageNavigatorEx1.Index = 1;
                labelRecordCountInfo.Text = string.Format("总记录数 {0} 条，共分 {1} 页", m_viewModel.TotalCount, m_viewModel.TotalPageCount + 1);

                ShowResults(m_viewModel.FirstPage());
            }
        }

        private void buttonLayout6_Click(object sender, EventArgs e)
        {
            if (LayoutColumnCount != 6)
            {
                LayoutColumnCount = 6;
                m_viewModel.PAGE_COUNT = 36;
                pageNavigatorEx1.MaxCount = m_viewModel.TotalPageCount + 1;
                pageNavigatorEx1.Index = 1;
                labelRecordCountInfo.Text = string.Format("总记录数 {0} 条，共分 {1} 页", m_viewModel.TotalCount, m_viewModel.TotalPageCount + 1);
                
                ShowResults(m_viewModel.FirstPage());
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
            
            if (m_viewModel != null)
                m_viewModel.Clear();

            StartSearchTime = new DateTime();
            FinishSearchTime = new DateTime();
        }



        private void pageNavigatorEx1_FirstClick(object sender, EventArgs e)
        {
            ShowResults(m_viewModel.FirstPage());

        }

        private void pageNavigatorEx1_ItemClick(int obj)
        {
        }

        private void pageNavigatorEx1_LastClick(object sender, EventArgs e)
        {
            ShowResults(m_viewModel.LastPage());
        }

        private void pageNavigatorEx1_NextClick(object sender, EventArgs e)
        {
            ShowResults(m_viewModel.NextPage());
        }

        private void pageNavigatorEx1_PrivClick(object sender, EventArgs e)
        {
            ShowResults(m_viewModel.PrivPage());
        }

    }
}
