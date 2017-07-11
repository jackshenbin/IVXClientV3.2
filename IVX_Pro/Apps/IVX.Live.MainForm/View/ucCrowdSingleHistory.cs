using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;

namespace IVX.Live.MainForm.View
{
    public partial class ucCrowdSingleHistory : UserControl
    {
        private List<CrowdInfo> m_ListInfo;
        private bool isRunThread;
        System.Threading.Thread curThread;
        object lockObj;
        string cameraName;

        public ucCrowdSingleHistory()
        {
            InitializeComponent();
        }

        public int Count    { get; set; }
        public int CurIndex { get; set; }
        public uint ThreadTime { get; set; }
        public string CameraId 
        {
            get { return m_ListInfo[CurIndex].CameraID;}
        }

        private void m_singleCrowdInfo_Load(object sender, EventArgs e)
        {
            curThread = null;
            cameraName = null;
            isRunThread = false;
            lockObj = new object();
            ThreadTime = 10;
        }

        public void RefreshInfo(List<CrowdInfo> crowdInfoList)
        {
            SetBtnEnble(true);
            playBtn.Enabled = true;
            playBtn.Image = IVX.Live.MainForm.Properties.Resources.播放1;
            m_ListInfo = crowdInfoList;
            Count = crowdInfoList.Count;
            CurIndex = 1;
            trackBarEx1.MaxValue = Count - 1;
            trackBarEx1.Value = CurIndex;
            SetPlayIndex(CurIndex,Count);
            CrowdInfo curInfo = m_ListInfo[CurIndex - 1];
            cameraName = curInfo.CameraID;
            if (m_singleCrowdInfo != null)
            {
                LabelTime.Text = DataModel.Common.ConvertLinuxTime(curInfo.TimeSec).ToString();
                m_singleCrowdInfo.RefreshInfo(curInfo);
            }
        }

        public void SetPlayIndex(int index,int count)
        {
            playIndex.Text = index.ToString() + "/" + count.ToString();
            trackBarEx1.Value = index - 1;
        }

        private void RefreshInfo(int index)
        {
            if (this.IsHandleCreated)
            {
                SetPlayIndex(index, Count);
                CrowdInfo curInfo = m_ListInfo[index - 1];
                curInfo.CameraID = cameraName;
                if (m_singleCrowdInfo != null)
                {
                    m_singleCrowdInfo.RefreshInfo(curInfo);
                }
                LabelTime.Text = DataModel.Common.ConvertLinuxTime(curInfo.TimeSec).ToString();
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void PlayThread()
        {
            while (isRunThread)
            {
                // publish Event
                for (int i = 0; i < ThreadTime; i++)
                {
                    if (isRunThread)
                        System.Threading.Thread.Sleep(100);
                    else
                        break;
                } 
                lock (lockObj)
                {
                    CurIndex++;
                    if (CurIndex > Count)
                    {
                        CurIndex = 1;
                    }
                }
                RefreshInfoByThread(CurIndex);
            }
            isRunThread = false;
            curThread = null;
        }

        private void RefreshInfoByThread(int i)
        {
            if (this != null)
            {
                if (this.IsHandleCreated && isRunThread)
                {
                    this.Invoke(new Action<int>(RefreshInfo), i);
                }
            }
        }

        private void SetBtnEnble(bool status)
        {
            stepDownBtn.Enabled = status;
            stepUpBtn.Enabled   = status;
        }

        private void splitContainer5_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Stop()
        {
            //stop Thread
            if (curThread != null)
            {
                isRunThread = false;
                SetBtnEnble(true);
            }
        }

        private void trackBarEx1_Load(object sender, EventArgs e)
        {

        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            //通过curThread == null 来保证当前线程是不是结束
            if (curThread == null)
            {
                SetBtnEnble(false);
                playBtn.Image = IVX.Live.MainForm.Properties.Resources.暂停1;
                //start Thread
                isRunThread = true;
                curThread = new System.Threading.Thread(PlayThread);
                curThread.Start();
            }
            else
            {
                //stop Thread
                Stop();
                playBtn.Image = IVX.Live.MainForm.Properties.Resources.播放1;
            }
        }

        private void stepUpBtn_Click_1(object sender, EventArgs e)
        {
            lock (lockObj)
            {
                int nextindex = CurIndex + 1;
                if (nextindex > Count)
                {
                    nextindex = nextindex % Count;
                }
                CurIndex = nextindex;
            }
            //Update info
            SetPlayIndex(CurIndex, Count);
            CrowdInfo curInfo = m_ListInfo[CurIndex - 1];
            curInfo.CameraID = cameraName;
            m_singleCrowdInfo.RefreshInfo(curInfo);
            LabelTime.Text = DataModel.Common.ConvertLinuxTime(curInfo.TimeSec).ToString();
        }

        private void stepDownBtn_Click_1(object sender, EventArgs e)
        {
            lock (lockObj)
            {
                int nextindex = CurIndex - 1;
                if (nextindex == 0)
                {
                    nextindex = Count;
                }

                CurIndex = nextindex;
            }
            //Update info
            SetPlayIndex(CurIndex, Count);
            CrowdInfo curInfo = m_ListInfo[CurIndex - 1];
            curInfo.CameraID = cameraName;
            m_singleCrowdInfo.RefreshInfo(curInfo);
            LabelTime.Text = DataModel.Common.ConvertLinuxTime(curInfo.TimeSec).ToString();
        }

        private void trackBarEx1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void trackBarEx1_ValueChangedByMouse(object sender, EventArgs e)
        {
            lock (lockObj)
            {
                CurIndex = (int)trackBarEx1.Value + 1;
            }
            //Update info
            playIndex.Text = CurIndex.ToString() + "/" + Count.ToString();
            CrowdInfo curInfo = m_ListInfo[CurIndex - 1];
            curInfo.CameraID = cameraName;
            m_singleCrowdInfo.RefreshInfo(curInfo);
            LabelTime.Text = DataModel.Common.ConvertLinuxTime(curInfo.TimeSec).ToString();
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSlow.Checked)
            {
                ThreadTime = 40;
            }
            else if (radioFast.Checked)
            {
                ThreadTime = 1;
            }
            else 
            {
                ThreadTime = 10;
            }
        }
    }
}
