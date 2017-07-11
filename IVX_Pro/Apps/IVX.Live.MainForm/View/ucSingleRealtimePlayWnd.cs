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
    public partial class ucSingleRealtimePlayWnd : UserControl,INotifyPropertyChanged
    {
        #region 事件
        public event MouseEventHandler MouseClickEx;
        public event MouseEventHandler MouseDoubleClickEx;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region 私有变量
        private int m_playHandle = 0;
        private E_VDA_PLAY_STATUS m_currentStat = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO;
        private SingleRealtimePlayWndViewModel m_viewModel;
        #endregion

        #region 属性

        public E_VDA_PLAY_STATUS VideoStatus
        {
            get { return m_currentStat; }
            private set
            {
                if (m_currentStat != value)
                {
                    m_currentStat = value;
                    if (PropertyChanged!=null) PropertyChanged(this, new PropertyChangedEventArgs("VideoStatus"));
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("VideoStatusString"));
                }
            }
        }
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
                    default:
                        break;
                }
                return str;
            }
        }

        public DataModel.E_VDA_NET_STORE_DEV_PROTOCOL_TYPE Protocol { get; set; }
        public string IP { get; set; }
        public uint Port { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string Channel { get; set; }

        public string VideoName { get { return axVdaPlayer1.Text; } set { axVdaPlayer1.Text = value; } }

        #endregion

        #region 构造
        public ucSingleRealtimePlayWnd()
        {
            InitializeComponent();
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

            return true;
        }

        public void UnInit()
        {        
            Protocol = E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_NONE;
            IP ="";
            Port =0;
            User  = "";
            Pass ="";
            Channel = "";


            m_viewModel.DIOLogout();

            if (null != Framework.Environment.VODPlayControler)
            {
                Framework.Environment.VODPlayControler.TfuncPlayPosCB
                    -= new AxvodocxLib._DvodocxEvents_TfuncPlayPosCBEventHandler(axvodocx1_TfuncPlayPosCB);
            }

        }

        public void StartPlayReal()
        {
            try
            {
                if (Protocol == E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_MSS_SHARE_FILE)
                {
                    ocx_VodSdk_StopPlayBack();
                    int ret = ocx_VodSdk_PlayBackVideo(IP, (ushort)Port, Channel);
                    if (ret > 0)
                    {
                        VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO;
                        ResizeWnd(1920, 1080);

                    }
                    else
                        DevComponents.DotNetBar.MessageBoxEx.Show("播放失败", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    int ret = m_viewModel.DIOLogin(Protocol, IP, (ushort)Port, User, Pass);
                    if (ret >= 0)
                    {
                        m_viewModel.DIOStartRealPlay(axVdaPlayer1.Handle, Channel, ret.ToString());
                        VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL;
                    }
                    else
                        DevComponents.DotNetBar.MessageBoxEx.Show("播放失败", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (SDKCallException ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("播放失败 [" + ex.ErrorCode + "]" + ex.Message, Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        public void StopPlayReal()
        {
            if (Protocol == E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_MSS_SHARE_FILE)
            {
                int ret = ocx_VodSdk_StopPlayBack();
            }
            else
            {
                m_viewModel.DIOStopRealPlay(axVdaPlayer1.Handle);
                VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO;
            }
        }

        public Image GrabPictureData(bool needsave=true)
        {
            if (!IsPlayStarted())
                return null;

            try
            {
                Image img = null;
                if (Protocol == E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_MSS_SHARE_FILE)
                {
                    img = ocx_VodSdk_GrabPictureData();
                }
                else
                {
                    img = m_viewModel.DIOSnapPicture(axVdaPlayer1.Handle);
                }
                if (img == null)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("抓图失败", Framework.Environment.PROGRAM_NAME);
                    return null;
                }
                string time = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string type = "视频截图";
                string fileName = VideoName.Replace(".", "_").Replace(":", "_") + type + time + ".jpg";
                //fileName = Framework.Environment.PictureSavePath.TrimEnd('\\') + "\\" + fileName;
                if (needsave)
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
                        needsave = false;
                    }
                }

                if (needsave)
                {

                    img.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);

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
                Image img = null;
                if (Protocol == E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_MSS_SHARE_FILE)
                {
                    img = ocx_VodSdk_GrabPictureData();
                }
                else
                {
                    img = m_viewModel.DIOSnapPicture(axVdaPlayer1.Handle);
                }

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
        bool ocx_VodSdk_GetPlayResolution(out uint width, out uint height)
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

            width = Convert.ToUInt32(doc.SelectSingleNode("//result/width").InnerText);
                height = Convert.ToUInt32(doc.SelectSingleNode("//result/height").InnerText);

            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_GetPlayResolution retVal:{0},width:{1},height:{2}", retVal, width, height);
            return retVal==0;
        }
        string ocx_VodSdk_GetSdkVersion()
        {
            return Framework.Environment.VODPlayControler.ocx_VodSdk_GetSdkVersion();
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
        bool ocx_VodSdk_PlayBackControl(E_VDA_PLAYCTRL_TYPE lCtrlCode, int lCtrlValue, out int outVal)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_PlayBackControl lCtrlCode:{0},lCtrlValue:{1}", lCtrlCode, lCtrlValue);
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
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_StopPlayBack m_playHandle:" + m_playHandle);
            int retVal = 0;
            if (m_playHandle > 0)
            {
                retVal = Framework.Environment.VODPlayControler.ocx_VodSdk_StopPlayBack(m_playHandle);
                VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_FINISH;
            }
            m_playHandle = 0;
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_StopPlayBack retVal:{0}", retVal);
            return 0;
        }


        void axvodocx1_TfuncPlayPosCB(object sender, AxvodocxLib._DvodocxEvents_TfuncPlayPosCBEvent e)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("axvodocx1_TfuncPlayPosCB dwCurPlayTime:{0},dwPlayProgress:{1},dwPlayState:{2},dwUserData:{3},lVodHandle:{4}", e.dwCurPlayTime, e.dwPlayProgress, (E_VDA_PLAY_STATUS)e.dwPlayState, e.dwUserData, e.lVodHandle);
            DoOnPlayPosCB(e.lVodHandle, e.dwPlayProgress, e.dwCurPlayTime, e.dwPlayState);
        }


        void DoOnPlayPosCB(int lVodHandle, uint dwPlayProgress, uint dwCurPlayTime, uint dwPlayState)
        {
            if(!IsHandleCreated || IsDisposed)
            return;

            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<int, uint, uint, uint>(DoOnPlayPosCB), lVodHandle, dwPlayProgress, dwCurPlayTime, dwPlayState);
            }
            else
            {
                if (lVodHandle != m_playHandle)
                    return;
                if (dwPlayState == (uint)E_VDA_PLAY_STATUS.E_PLAY_STATUS_STARTPLAY_READY)
                {
                    int outval = 0;
                    ocx_VodSdk_PlayBackControl(E_VDA_PLAYCTRL_TYPE.E_PLAYCTRL_START, 0, out outval);
                    SetWndResolution();
                    VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL;
                }
                if (dwPlayState == (uint)E_VDA_PLAY_STATUS.E_PLAY_STATUS_FINISH)
                {
                    VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_FINISH;
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

        private  void SetWndResolution()
        { 
            uint h=1080;uint w=1920;
            if(Protocol == E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_MSS_SHARE_FILE)
                ocx_VodSdk_GetPlayResolution(out w, out h);
            else
                m_viewModel.DIOGetPlayResolution(axVdaPlayer1.Handle,out w, out h);
            ResizeWnd(w,h);
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
            return (VideoStatus == E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL );

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

        private void ucSinglePlayWnd_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            m_viewModel = new SingleRealtimePlayWndViewModel();
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
