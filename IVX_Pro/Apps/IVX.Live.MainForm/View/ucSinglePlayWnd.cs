using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;
using IVX.Live.ViewModel;
using System.Diagnostics;

namespace IVX.Live.MainForm.View
{
    public partial class ucSinglePlayWnd : UserControl,INotifyPropertyChanged
    {
        #region 事件
        
        public event MouseEventHandler MouseClickEx;
        public event MouseEventHandler MouseDoubleClickEx;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region 私有变量
        private bool m_selected = false;
        private int m_playHandle = 0;
        private E_VDA_PLAY_STATUS m_currentStat = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO;
        private E_VDA_PLAY_SPEED m_currentSpeed = E_VDA_PLAY_SPEED.E_PLAYSPEED_NORMALSPEED;
        private int m_currentTime = 0;
        private bool m_isBackword = false;
        #endregion

        #region 属性
        public string MSS_IP { get; set; }
        public uint MSS_Port { get; set; }
        public string MSS_Path { get; set; }
        public int PlayStartTime { get; set; }
        public int PlayEndTime { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public E_VDA_PLAY_STATUS VideoStatus
        {
            get { return m_currentStat; }
            private set
            {
                if (m_currentStat != value)
                {
                    m_currentStat = value;
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("VideoStatus"));
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("VideoStatusString"));
                }
                    switch (m_currentStat)
                    {
                        case E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO:
                            UpdateTrackBar(false);
                            break;
                        case E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL:
                            UpdateTrackBar(true);
                            break;
                        case E_VDA_PLAY_STATUS.E_PLAY_STATUS_FINISH:
                            UpdateTrackBar(false);
                            break;
                        case E_VDA_PLAY_STATUS.E_PLAY_STATUS_FAILED:
                            UpdateTrackBar(false);
                            break;
                        case E_VDA_PLAY_STATUS.E_PLAY_STATUS_STARTPLAY_READY:
                            break;
                        case E_VDA_PLAY_STATUS.E_PLAY_STATUS_SYNTH_ERROR:
                            break;
                        case E_VDA_PLAY_STATUS.E_PLAY_STATUS_SEEK_ERROR:
                            break;
                        case E_VDA_PLAY_STATUS.E_PLAY_STATUS_PAUSE:
                            UpdateTrackBar(true);
                            break;
                        case E_VDA_PLAY_STATUS.E_PLAY_STATUS_SPEED:
                            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("VideoStatusString"));
                            break;
                        default:
                            break;
                    }
                
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string VideoStatusString
        {
            get
            {
                string str = "";
                switch (VideoStatus)
                {
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO:
                        str = "";
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL:
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_SPEED:
                        switch (m_currentSpeed)
	                    {
                            case E_VDA_PLAY_SPEED.E_PLAYSPEED_SLOW16:
                                str = "1/16X";
                                break;
                            case E_VDA_PLAY_SPEED.E_PLAYSPEED_SLOW8:
                                str = "1/8X";
                                break;
                            case E_VDA_PLAY_SPEED.E_PLAYSPEED_SLOW4:
                                str = "1/4X";
                                break;
                            case E_VDA_PLAY_SPEED.E_PLAYSPEED_SLOW2:
                                str = "1/2X";
                                break;
                            case E_VDA_PLAY_SPEED.E_PLAYSPEED_NORMALSPEED:
                                str = "";
                                break;
                            case E_VDA_PLAY_SPEED.E_PLAYSPEED_FAST2:
                                str = "2X";
                                break;
                            case E_VDA_PLAY_SPEED.E_PLAYSPEED_FAST4:
                                str = "4X";
                                break;
                            case E_VDA_PLAY_SPEED.E_PLAYSPEED_FAST8:
                                str = "8X";
                                break;
                            case E_VDA_PLAY_SPEED.E_PLAYSPEED_FAST16:
                                str = "16X";
                                break;
                            default:
                                break;
	                    }
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_FINISH:
                        str = "播放完成";
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_FAILED:
                        str = "播放出错";
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_STARTPLAY_READY:
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_SYNTH_ERROR:
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_SEEK_ERROR:
                        str = "定位失败";
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_PAUSE:
                        str = "暂停";
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_BACKWORD:
                        str = "倒放";
                        break;
                    default:
                        break;
                }
                return str;
            }
        }



        public bool Selected
        {
            get { return m_selected; }
            set
            {
                m_selected = value;
                SetSelected(value);
            }
        }

        public string VideoName { get { return axVdaPlayer1.Text; } set { axVdaPlayer1.Text = value; } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public uint Progress
        {
            get { return (uint)trackBarEx1.Value; }
            private set { trackBarEx1.Value = value; }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public string VideoTimeStr { get;private set; }
        public uint VideoTime { get;private set; }
        #endregion

        #region 构造
        public ucSinglePlayWnd()
        {
            InitializeComponent();
            VideoTimeStr = "";
            VideoTime = 0;
            UpdateTrackBar(false);
            //new System.Threading.Thread(thCheckHandle).Start();
        }
        #endregion

        #region 公共函数
        public bool Init()
        {
                if (null != Framework.Environment.VODPlayControler)
                {
                    Framework.Environment.VODPlayControler.TfuncPlayPosCB
                        += new AxvodocxLib._DvodocxEvents_TfuncPlayPosCBEventHandler(axvodocx1_TfuncPlayPosCB);
                }

                return  true;
        }

        public void UnInit()
        {
                MSS_IP = "";
                MSS_Path = "";
                MSS_Port = 0;
                if (null != Framework.Environment.VODPlayControler)
                {
                    Framework.Environment.VODPlayControler.TfuncPlayPosCB
                        -= new AxvodocxLib._DvodocxEvents_TfuncPlayPosCBEventHandler(axvodocx1_TfuncPlayPosCB);
                }
        }


        //public bool StartPlayBack(string mssip,uint mssport,string mssfilepath)
        //{
        //    ocx_VodSdk_StopPlayBack();
        //    int ret = ocx_VodSdk_PlayBackVideo(mssip, (ushort)mssport, mssfilepath);

        //    if (ret > 0)
        //    {
        //        MSS_IP = mssip;
        //        MSS_Path = mssfilepath;
        //        MSS_Port = mssport;

        //        m_currentSpeed = E_VDA_PLAY_SPEED.E_PLAYSPEED_NORMALSPEED;
        //        VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO;
        //        ResizeWnd(1920, 1080);

        //        trackBarEx1.MaxValue = 1000;
        //    }

        //    return ret > 0;
        //}
        public bool StartPlayBack(string mssip, uint mssport, string mssfilepath, int st, int et)
        {
            PlayStartTime = st;
            PlayEndTime = et;
            ocx_VodSdk_StopPlayBack();
            int ret = ocx_VodSdk_PlayBackVideo(mssip, (ushort)mssport, mssfilepath);
            if (ret > 0)
            {
                MSS_IP = mssip;
                MSS_Path = mssfilepath;
                MSS_Port = mssport;

                m_currentSpeed = E_VDA_PLAY_SPEED.E_PLAYSPEED_NORMALSPEED;
                VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO;
                ResizeWnd(1920, 1080);

                trackBarEx1.MaxValue = 1000;
            }
            else
                DevComponents.DotNetBar.MessageBoxEx.Show("播放失败", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            return ret > 0;
        }
        public void StopPlayBack()
        {
            m_isBackword = false;
            int ret = ocx_VodSdk_StopPlayBack();
            VideoTimeStr = "00:00:00/00:00:00";
            VideoTime = 0;
        }
        public bool PlayOrPauseOrResume()
        {
            try
            {
                m_isBackword = false;
                if (!IsPlayStarted())
                {
                    if (string.IsNullOrEmpty(MSS_Path) || string.IsNullOrEmpty(MSS_IP))
                        return false ;
                    else
                        return StartPlayBack(MSS_IP, MSS_Port, MSS_Path, PlayStartTime, PlayEndTime);
                }
                else
                {
                    int outval = 0;
                    if (VideoStatus == E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL || VideoStatus == E_VDA_PLAY_STATUS.E_PLAY_STATUS_SPEED)
                    {
                        ocx_VodSdk_PlayBackControl(E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_PAUSE, 0, out outval);
                        VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_PAUSE;
                    }
                    else if (VideoStatus == E_VDA_PLAY_STATUS.E_PLAY_STATUS_PAUSE || VideoStatus == E_VDA_PLAY_STATUS.E_PLAY_STATUS_BACKWORD)
                    {
                        ocx_VodSdk_PlayBackControl(E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_RESUME, 0, out outval);
                        if (m_currentSpeed == E_VDA_PLAY_SPEED.E_PLAYSPEED_NORMALSPEED)
                            VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL;
                        else
                            VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_SPEED;
                    }
                    return true;
                }
            }
            catch (SDKCallException ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("点播失败，[" + ex.ErrorCode + "]" + ex.Message, Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

        }
        public void SpeedUp()
        {
            if (m_isBackword)
                return;
            if (!IsPlayStarted())
                return;

            try
            {
                int outval = 0;
                int newspeed = (int)m_currentSpeed + 1;
                if (newspeed > (int)E_VDA_PLAY_SPEED.E_PLAYSPEED_FAST4)
                    newspeed = (int)E_VDA_PLAY_SPEED.E_PLAYSPEED_FAST4;
                ocx_VodSdk_PlayBackControl(E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_SETSPEED, newspeed, out outval);
                m_currentSpeed = (E_VDA_PLAY_SPEED)newspeed;
                if (m_currentSpeed == E_VDA_PLAY_SPEED.E_PLAYSPEED_NORMALSPEED)
                    VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL;
                else
                    VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_SPEED;
            }
            catch (SDKCallException ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("该视频不支持4倍及以上速度播放，[" + ex.ErrorCode + "]" + ex.Message, Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
        }
        public void SpeedDown()
        {
            if (m_isBackword)
                return;

            m_isBackword = false;
            if (!IsPlayStarted())
                return;


            try
            {
                int outval = 0;

                int newspeed = (int)m_currentSpeed - 1;
                if (newspeed < (int)E_VDA_PLAY_SPEED.E_PLAYSPEED_SLOW2)
                    newspeed = (int)E_VDA_PLAY_SPEED.E_PLAYSPEED_SLOW2;
                ocx_VodSdk_PlayBackControl(E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_SETSPEED, newspeed, out outval);
                m_currentSpeed = (E_VDA_PLAY_SPEED)newspeed;
                if (m_currentSpeed == E_VDA_PLAY_SPEED.E_PLAYSPEED_NORMALSPEED)
                    VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL;
                else
                    VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_SPEED;
            }
            catch (SDKCallException ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("该视频不支持1/4倍及以下速度播放，[" + ex.ErrorCode + "]" + ex.Message, Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
        }
        public void SetPosition(uint newpos)
        {
            if (m_isBackword)
                return;
            
            if (!IsPlayStarted())
                return;


            int outval = 0;
            ocx_VodSdk_PlayBackControl(E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_SETPOS, (int)newpos, out outval);

        }
        public Image GrabPictureData(bool needSave =true)
        {
            if (!IsPlayStarted())
                return null;

            try
            {
                Image img = ocx_VodSdk_GrabPictureData();

                if (img == null)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("抓图失败", Framework.Environment.PROGRAM_NAME);
                    return null;
                }
                if (needSave)
                {
                    string time = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    string type = "视频截图";
                    string fileName = VideoName.Replace(".", "_").Replace(":", "_") + type + time + ".jpg";
                    //fileName = Framework.Environment.PictureSavePath.TrimEnd('\\') + "\\" + fileName;

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

                        img.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                    }
                }
                return img;
            }
            catch (SDKCallException ex)
            {
                MyLog4Net.Container.Instance.Log.DebugFormat("GrabPictureData error:" + ex);
                return null;
            }
        }
        public string GrabPictureData(string saveFileName, bool needSave = true)
        {
            if (!IsPlayStarted())
                return "";

            try
            {
                Image img = ocx_VodSdk_GrabPictureData();

                if (img == null)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("抓图失败", Framework.Environment.PROGRAM_NAME);
                    return "";
                }
                string time = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string type = "视频截图";
                string fileName = VideoName.Replace(".", "_").Replace(":", "_") + type + time + ".jpg";

                //fileName = Framework.Environment.PictureSavePath.TrimEnd('\\') + "\\" + fileName;
                if (!string.IsNullOrEmpty(saveFileName))
                {
                    fileName = saveFileName;
                }
                else
                {
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

                }
                if (needSave)
                {

                    img.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    img.Dispose();
                    return fileName;
                }
                return "";
            }
            catch (SDKCallException ex)
            {
                MyLog4Net.Container.Instance.Log.DebugFormat("GrabPictureData error:" + ex);
                return "";
            }
        }
        public void BackwordPlay()
        {
            if (!IsPlayStarted())
                return;

            int outval = 0;
            ocx_VodSdk_PlayBackControl(E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_PAUSE, 0, out outval);
            VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_BACKWORD;
            m_isBackword = true;
            new System.Threading.Thread(thBackwordPlay).Start(trackBarEx1.Value);
        }
        void thBackwordPlay(object obj)
        {

            int pos = Convert.ToInt32( obj);
            int interval = Convert.ToInt32(trackBarEx1.MaxValue * 2 / GetVideoTotleTime());
            while (pos > interval && m_isBackword)
            {
                pos -= interval;
                InvokePlayBackControl(E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_SETPOS, pos);
                System.Threading.Thread.Sleep(1 * 1000);
            }
            if(m_isBackword)
                InvokePlayBackControl(E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_RESUME, 0);
            m_isBackword = false;
        }
        void InvokePlayBackControl(E_VDA_PLAYCTRL_TYPE type,int inval)
        {
            if(InvokeRequired)
            {
                Invoke(new Action<E_VDA_PLAYCTRL_TYPE, int>(InvokePlayBackControl), type, inval);
            }
            else
            {
                int outval = 0;

                ocx_VodSdk_PlayBackControl(type, inval, out outval);

            }
        }
        public int GetVideoTotleTime()
        {
            if (!IsPlayStarted())
                return 0;

            int outval = 0;
            ocx_VodSdk_PlayBackControl(E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_GETTIME_RANGE, 0, out outval);

            return outval;
        }
        public int GetVideoTime()
        {
            if (!IsPlayStarted())
                return 0;

            int outval = m_currentTime;

            return outval;
        }

        #endregion

        #region VODOCX

        string ocx_VodSdk_GetErrorMsg(uint uErrorCode)
        {
            return Framework.Environment.VODPlayControler.ocx_VodSdk_GetErrorMsg(uErrorCode);
        }
        uint ocx_VodSdk_GetLastError()
        {
            return Framework.Environment.VODPlayControler.ocx_VodSdk_GetLastError();
        }
        bool ocx_VodSdk_GetPlayResolution(out int width,out int height)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_GetPlayResolution ");
            string xml = Framework.Environment.VODPlayControler.ocx_VodSdk_GetPlayResolution(m_playHandle);
           /* <?xml version="1.0"?>
            <result>
	            <retcode>0</retcode>
	            <width>1600</width>
	            <height>1216</height>
            </result>
            */
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(xml);
            int retVal = Convert.ToInt32(doc.SelectSingleNode("//result/retcode").InnerText);
            if (retVal != 0)
                GetError();
            width = 1920; height = 1080;

            width = Convert.ToInt32(doc.SelectSingleNode("//result/width").InnerText);
                height = Convert.ToInt32(doc.SelectSingleNode("//result/height").InnerText);

            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_GetPlayResolution retVal:{0},width:{1},height:{2}", retVal, width, height);
            return retVal==0;
        }
        string ocx_VodSdk_GetSdkVersion()
        {
            return Framework.Environment.VODPlayControler.ocx_VodSdk_GetSdkVersion();
        }
        string ocx_VodSdk_GetVideoFileInfoByTaskUnit(string pchServerIP, ushort wServerPort, uint uTaskID)
        {
            return Framework.Environment.VODPlayControler.ocx_VodSdk_GetVideoFileInfoByTaskUnit(pchServerIP, wServerPort, uTaskID);
        }
        Image ocx_VodSdk_GrabPictureData()
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_GrabPictureData ");
            uint dwPicType = 1;
            string xml = Framework.Environment.VODPlayControler.ocx_VodSdk_GrabPictureData(m_playHandle, dwPicType);

            /*
            <?xml version="1.0"?>
            <result>
	            <retcode>0</retcode>
	            <picsize>8388608</picsize>
	            <picdata></picdata>
            </result>

                */
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(xml);
            int retVal = Convert.ToInt32(doc.SelectSingleNode("//result/retcode").InnerText);
            if (retVal != 0)
                GetError();

            int picsize = Convert.ToInt32(doc.SelectSingleNode("//result/picsize").InnerText);
            string picdata = doc.SelectSingleNode("//result/picdata").InnerText;
            //System.IO.File.WriteAllText(@"c:\a.txt", picdata);
            byte[] byteimg = Convert.FromBase64String(picdata);
            System.IO.MemoryStream streamimg = new System.IO.MemoryStream(byteimg);
            Image img = Image.FromStream(streamimg);
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_GrabPictureData retVal:{0},width:{1},height:{2}", retVal, img.Width, img.Height);
            return img;
        }
        bool ocx_VodSdk_PlayBackControl(E_VDA_PLAYCTRL_TYPE lCtrlCode, int lCtrlValue,out int outVal)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_PlayBackControl lCtrlCode:{0},lCtrlValue:{1}" , lCtrlCode, lCtrlValue);
            string xml = Framework.Environment.VODPlayControler.ocx_VodSdk_PlayBackControl(m_playHandle, (int)lCtrlCode, lCtrlValue);

            /*
             * <?xml version="1.0"?>
                <result>
	                <retcode>1</retcode>
	                <outvalue>0</outvalue>
                </result>
                */

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(xml);
            int retVal = Convert.ToInt32(doc.SelectSingleNode("//result/retcode").InnerText);
            if (retVal != 0)
                GetError();

            outVal = Convert.ToInt32(doc.SelectSingleNode("//result/outvalue").InnerText);
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_PlayBackControl retVal:" + retVal + ",outVal:" + outVal);
            return retVal==0;
        }
        int ocx_VodSdk_PlayBackVideo(string pchServerIP, ushort wServerPort, string pchFilePath)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_PlayBackVideo pchServerIP:{0},wServerPort:{1},pchFilePath:{2}", pchServerIP, wServerPort, pchFilePath);
            uint playWnd = Convert.ToUInt32(this.axVdaPlayer1.Handle.ToString());
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_PlayBackVideo playWnd:{0}", playWnd);
            m_playHandle = Framework.Environment.VODPlayControler.ocx_VodSdk_PlayBackVideo(pchServerIP, wServerPort, pchFilePath, playWnd, 0);
            if (m_playHandle == 0)
                GetError();

            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_PlayBackVideo retVal m_playHandle:{0}", m_playHandle);
            return m_playHandle;
        }
        int ocx_VodSdk_StopPlayBack()
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_StopPlayBack m_playHandle:"+m_playHandle);
            int retVal = 0;
            if (m_playHandle > 0)
            {
                retVal = Framework.Environment.VODPlayControler.ocx_VodSdk_StopPlayBack(m_playHandle);
                VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_FINISH;
            }
            m_playHandle=0;
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_StopPlayBack retVal:{0}", retVal);
            return 0;
        }


        void axvodocx1_TfuncPlayPosCB(object sender, AxvodocxLib._DvodocxEvents_TfuncPlayPosCBEvent e)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("axvodocx1_TfuncPlayPosCB dwCurPlayTime:{0},dwPlayProgress:{1},dwPlayState:{2},dwUserData:{3},lVodHandle:{4}", e.dwCurPlayTime, e.dwPlayProgress, (E_VDA_PLAY_STATUS)e.dwPlayState, e.dwUserData, e.lVodHandle);
            DoOnPlayPosCB(e.lVodHandle,e.dwPlayProgress,e.dwCurPlayTime,e.dwPlayState);
        }


        void DoOnPlayPosCB(int lVodHandle, uint dwPlayProgress,uint dwCurPlayTime, uint dwPlayState)
        {
            if (!IsHandleCreated || IsDisposed)
                return;


            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<int, uint, uint, uint>(DoOnPlayPosCB), lVodHandle, dwPlayProgress,dwCurPlayTime, dwPlayState);
            }
            else
            {
                if (lVodHandle != m_playHandle)
                    return;
                if (Framework.Environment.VODPlayControler == null)
                    return;

                m_currentTime = (int)dwCurPlayTime;
                if (dwPlayState == (uint)E_VDA_PLAY_STATUS.E_PLAY_STATUS_STARTPLAY_READY)
                {
                    int outval = 0;
                    if (PlayStartTime == 0)
                        ocx_VodSdk_PlayBackControl(E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_START, 0, out outval);
                    else
                    {
                        ocx_VodSdk_PlayBackControl(E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_GETTIME_RANGE, 0, out outval);
                        uint TotlePlayTime = (uint)outval;
                        uint StartPlayTime = 0;
                        //if (PlayStartTime > DataModel.Common.ZEROTIME)
                        //{
                        //    StartPlayTime = (uint)Math.Max(PlayStartTime.Subtract(taskunitinfo.StartTime).TotalSeconds, 0);
                        //}
                        //else
                        StartPlayTime = (uint)Math.Max(PlayStartTime, 0);


                        if (TotlePlayTime != 0)
                        {
                            int startpos = (int)(1000 * StartPlayTime / TotlePlayTime);
                            ocx_VodSdk_PlayBackControl(E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_PLAY_BY_SEEK, startpos, out outval);
                        }


                    }
                    SetWndResolution();
                    VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL;
                }
                if (dwPlayState == (uint)E_VDA_PLAY_STATUS.E_PLAY_STATUS_FINISH)
                {
                    VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_FINISH;
                    VideoTimeStr = "00:00:00/00:00:00";
                    VideoTime = 0;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("VideoTime"));
                    }
                }
                if (dwPlayState == (uint)E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL)
                {
                    Progress = dwPlayProgress;
                    int outval = 0;
                    ocx_VodSdk_PlayBackControl(E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_GETTIME_RANGE, 0, out outval);


                    VideoTimeStr = new DateTime().AddSeconds(dwCurPlayTime).ToString("HH:mm:ss") + "/" + new DateTime().AddSeconds(outval).ToString("HH:mm:ss");
                    VideoTime = dwCurPlayTime;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("VideoTime"));
                    }

                    if (PlayEndTime > 0)
                    {
                        if (PlayEndTime <= dwCurPlayTime)
                        {
                            StopPlayBack();
                        }
                    }
                }
            }
        }

        private void GetError()
        {
            uint errorCode = Framework.Environment.VODPlayControler.ocx_VodSdk_GetLastError();
            string error = Framework.Environment.VODPlayControler.ocx_VodSdk_GetErrorMsg(errorCode);
            if (errorCode > 0)
            {
                MyLog4Net.Container.Instance.Log.Error(string.Format("SDKCallException errorCode:{0},errorString:{1}", errorCode, error));
                if (string.IsNullOrEmpty(error))
                {
                    Debug.Assert(false, "Failed but cannot get error message!");
                }
                throw new SDKCallException(errorCode, error);
            }
            else
            {
                Debug.Assert(false, "No valid error code!");
            }
        }

        #endregion

        #region 私有函数
        private void SetSelected(bool val)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(SetSelected), val);
            }
            else
            {
                axVdaPlayer1.BackgroundStyle.BorderColor = val ? Color.Yellow : Color.DarkGray;
                axVdaPlayer1.Refresh();
            }
        }

        private void UpdateTrackBar(bool enable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(UpdateTrackBar), enable);
            }
            else
            {if(trackBarEx1.Enabled != enable)
                trackBarEx1.Enabled = enable;
            }
        }
        private  void SetWndResolution()
        { 
            int h=1080;int w=1920;
            ocx_VodSdk_GetPlayResolution(out w, out h);
            ResizeWnd((uint)w,(uint)h);
        }
        private void ResizeWnd(uint m_width, uint m_height)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<uint, uint>(ResizeWnd), m_width, m_height);
            }
            else
            {
                //panel2.BorderStyle = System.Windows.Forms.BorderStyle.None;
                //axVdaPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
                float a = (float)panelEx1.Width / m_width;
                float b = (float)panelEx1.Height / m_height;

                if (a <= b)
                {
                    axVdaPlayer1.Width = panelEx1.Width;
                    axVdaPlayer1.Height = (int)Math.Round(m_height * a);
                }
                else
                {
                    axVdaPlayer1.Width = (int)Math.Round(m_width * b);
                    axVdaPlayer1.Height = panelEx1.Height;
                }
                axVdaPlayer1.Left = (panelEx1.Width - axVdaPlayer1.Width) / 2;
                axVdaPlayer1.Top = (panelEx1.Height - axVdaPlayer1.Height) / 2;
            }
        }

        private bool IsPlayStarted()
        {
            return (VideoStatus == E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL 
                || VideoStatus == E_VDA_PLAY_STATUS.E_PLAY_STATUS_PAUSE 
                || VideoStatus == E_VDA_PLAY_STATUS.E_PLAY_STATUS_BACKWORD 
                || VideoStatus == E_VDA_PLAY_STATUS.E_PLAY_STATUS_SPEED);

        }

        #endregion

        #region 事件响应
        private void labelX1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MouseDoubleClickEx != null)
                MouseDoubleClickEx(this, e);
        }

        private void labelX1_MouseClick(object sender, MouseEventArgs e)
        {
            if (MouseClickEx != null)
                MouseClickEx(this, e);
        }

        private void trackBarEx1_ValueChangedByMouse(object sender, EventArgs e)
        {
            SetPosition((uint)trackBarEx1.Value);
        }
                

        private void ucSinglePlayWnd_Load(object sender, EventArgs e)
        {

        }

        private void ucSinglePlayWnd_SizeChanged(object sender, EventArgs e)
        {
            if (IsPlayStarted())
            {
                SetWndResolution();
            }
        }
        #endregion

    }


}
