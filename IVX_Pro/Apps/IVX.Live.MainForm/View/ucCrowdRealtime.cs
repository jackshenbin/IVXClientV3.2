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
using DevComponents.DotNetBar;

namespace IVX.Live.MainForm.View
{
    public partial class ucCrowdRealtime : UserControl
    {
        private CrowdRealtimeViewModel m_crowdVM;
        private SearchItemV3_1 curItem;
        bool isPlay;
        CrowdInfo curInfo;
        public ucCrowdRealtime()
        {
            InitializeComponent();
        }

		private void SetTreeArg()
		{
			if (DesignMode) return;
			ucCrowdRealCameraTree1.HasRootNode = false;
			ucCrowdRealCameraTree1.HasCheck = false;
			//实时大客流
			ucCrowdRealCameraTree1.AnalyseFilter = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD;
			ucCrowdRealCameraTree1.HasHistoryTask = false;
			ucCrowdRealCameraTree1.TreeTitle = "实时大客流监测点";
		}

        private void ucCrowdRealtime_Load(object sender, EventArgs e)
        {
            m_crowdVM = new CrowdRealtimeViewModel();
            curInfo = null;
            ucCrowdRealCameraTree1.SelectedTaskChanged += ucCrowdRealCameraTree1_SelectedTask;
            m_crowdVM.RealSearchFinished        += ucCrowdRealSearchFinsh;
			SetTreeArg();
			ucCrowdRealCameraTree1.InitTree();
        }

		public void RefreshTaskRoot() 
		{

		}

        public void StartWithTaskAction(SearchItemV3_1 item)
        {
            curItem = item;
            Start();

        }
        void ucCrowdRealCameraTree1_SelectedTask(SearchItemV3_1 careamId)
        {
            curItem = careamId;// ucCrowdRealCameraTree1.GetSelectedTask();

            Start();
        }

        private void Start()
        {
            if (curItem == null)
            {
                m_crowdVM.Stop();
                Init();
                return;
            }
            try
            {
                //正在请求数据....
                m_crowdVM.Start(curItem);
            }
            catch (SDKCallException ex)
            {
                //请求出错 终止线程 
                m_crowdVM.Stop();
                MessageBoxEx.Show("大客流实时-查询错误[" + ex.ErrorCode + "]:" + ex.Message, Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                MyLog4Net.Container.Instance.Log.Debug("ucCrowdRealtime SelectedTask" + ex.ToString());
            }
        }

        void ucCrowdRealSearchFinsh(object corwdInfoObj, EventArgs e)
        {
            if (corwdInfoObj == null)
            {
                m_crowdVM.Stop();
                Init();
                MyLog4Net.Container.Instance.Log.Debug("ucCrowdRealtime SearchFinsh no Data");
                return;
            }

            curInfo = (CrowdInfo)corwdInfoObj;
            if (curInfo.CameraID == "SDKError")
            {
                MessageBoxEx.Show(curInfo.DirectionImageURL, Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                MyLog4Net.Container.Instance.Log.Debug("ucCrowdRealtime ucCrowdRealSearchFinsh" + curInfo.DirectionImageURL);
                curInfo = null;
                return;
            }
            curInfo.CameraID = curItem.CameraName;
            m_SingleCrowdInfo.RefreshInfo(curInfo);
            LabelTime.Text = DataModel.Common.ConvertLinuxTime(curInfo.TimeSec).ToString();
            playBtn.Enabled = true;
            Savebutton.Enabled = true;
            isPlay = true;
            playBtn.Image = IVX.Live.MainForm.Properties.Resources.暂停1;
            MyLog4Net.Container.Instance.Log.Debug("ucCrowdRealtime SearchFinsh " + curInfo.CameraID);
        }



        private void pictureEdit1_Click(object sender, EventArgs e)
        {

        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            if (isPlay)
            {
                m_crowdVM.Stop();
                playBtn.Image = IVX.Live.MainForm.Properties.Resources.播放1;
                isPlay = false;
            }
            else 
            {
                try
                {
                    m_crowdVM.Start(curItem);
                    playBtn.Image = IVX.Live.MainForm.Properties.Resources.暂停1;
                    isPlay = true;
                }
                catch (SDKCallException ex)
                {
                    m_crowdVM.Stop();
                    MessageBoxEx.Show("大客流实时-查询错误[" + ex.ErrorCode + "]:" + ex.Message, Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    playBtn.Image = IVX.Live.MainForm.Properties.Resources.播放1;
                    isPlay = false;
                    //请求出错 终止线程 
                    MyLog4Net.Container.Instance.Log.Debug("ucCrowdRealtime playBtn_Click" + ex.ToString());
                }
            }
        }

        public void Clear()
        {
            if (m_crowdVM != null)
            {
                m_crowdVM.Stop();
            }
            ucCrowdRealCameraTree1.SelectedTaskChanged -= ucCrowdRealCameraTree1_SelectedTask;
            m_crowdVM.RealSearchFinished -= ucCrowdRealSearchFinsh;
        }

        private void pictureEdit1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

            if (curInfo != null)
            {
                Image imageSave = Common.GetImage(curInfo.OriginaloImageURL);
                string time = DataModel.Common.ConvertLinuxTime(curInfo.TimeSec).ToString();
                string []str = time.Split(' ');
                string[] monthStr = str[0].Split('/');
                string[] hourStr = str[1].Split(':');
                string newTime = monthStr[0] + "-" + monthStr[1] + "-" + monthStr[2] + "-" + hourStr[0] + "-" + hourStr[1] +"-"+ hourStr[2];
                string fileName = curInfo.CameraID + "-" + newTime + ".jpg";
                bool needSave = true;
                System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
                sfd.RestoreDirectory = true;
                sfd.Filter = "图片文件|*.jpg;*.bmp;*.png|全部文件|*.*";
                sfd.FileName = fileName;
                sfd.InitialDirectory = Framework.Environment.PictureSavePath;
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    fileName = sfd.FileName;
                }
                else
                {
                    needSave = false;
                }

                if (needSave)
                {
                    imageSave.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }

            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Init()
        {
            playBtn.Image = IVX.Live.MainForm.Properties.Resources.播放1;
            playBtn.Enabled = false;
            isPlay = false;
            Savebutton.Enabled = false;
            LabelTime.Text = "0000-00-00 00:00:00";
            if (m_SingleCrowdInfo != null)
            {
                m_SingleCrowdInfo.Init();
            }
        }
    }
}
