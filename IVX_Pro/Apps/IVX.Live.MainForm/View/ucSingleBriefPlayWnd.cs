using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;
using System.Diagnostics;

namespace IVX.Live.MainForm.View
{
    public partial class ucSingleBriefPlayWnd : UserControl, INotifyPropertyChanged
    {
        #region 事件
        public event MouseEventHandler MouseClickEx;
        public event MouseEventHandler MouseDoubleClickEx;
        public event PropertyChangedEventHandler PropertyChanged;
        public event Action<ucSingleBriefPlayWnd, BriefMoveobjInfo> MoveObjectClick;
        #endregion

        #region 私有变量
        private uint m_playHandle = 0;
        private E_VDA_PLAY_STATUS m_currentStat = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO;
        private E_VDA_PLAY_STATUS m_statusBeforePause = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO;
        private E_VDA_PLAY_SPEED m_currentSpeed = E_VDA_PLAY_SPEED.E_PLAYSPEED_NORMALSPEED;
        private E_VDA_BRIEF_DENSITY m_density = E_VDA_BRIEF_DENSITY.E_BRIEF_DENSITY_04;
        private E_VDA_MOVEOBJ_TYPE m_objtype = E_VDA_MOVEOBJ_TYPE.E_VDA_MOVEOBJ_TYPE_ALL;
        private E_MOVEOBJ_COLOR m_color = E_MOVEOBJ_COLOR.E_MOVEOBJ_COLOR_NOUSE;

        private bool m_lastEnableShowObjectRect = true;
        private bool m_lastEnableShowObjectTime = true;
        private bool m_lastEnableDraw = false;
        private bool m_lastEnableShowActionFilter = true;
        private bool m_lastEnableShowAreaFilter = true;

        #endregion

        #region 属性
        public string VideoTime { get; private set; }
        public string MSS_IP { get; set; }
        public uint MSS_Port { get; set; }
        public string MSS_Data_Path { get; set; }
        public string MSS_Index_Path { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SrcVideoTotleTime { get; set; }


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
                    if (PropertyChanged!=null) PropertyChanged(this, new PropertyChangedEventArgs("VideoStatus"));
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
                        str = "合成失败";
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
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public uint Progress
        {
            get { return (uint)trackBarEx1.Value; }
            private set { trackBarEx1.Value = value; }
        }

        public string VideoName { get { return axVdaPlayer1.Text; } set { axVdaPlayer1.Text = value; } }
        #endregion

        #region 构造
        public ucSingleBriefPlayWnd()
        {
            try
            {
                InitializeComponent();

                VideoTime = "";
                UpdateTrackBar(false);
                m_statusBeforePause = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region 公共函数

        public void Init()
        {
            if (Framework.Environment.BriefPlayControler != null)
            {
                Framework.Environment.BriefPlayControler.funcBriefVoddcAddDispathRspCB += new AxbriefocxLib._DbriefocxEvents_funcBriefVoddcAddDispathRspCBEventHandler(axbriefocx1_funcBriefVoddcAddDispathRspCB);
                Framework.Environment.BriefPlayControler.funcBriefVoddcPlayProgressCB += new AxbriefocxLib._DbriefocxEvents_funcBriefVoddcPlayProgressCBEventHandler(axbriefocx1_funcBriefVoddcPlayProgressCB);
                Framework.Environment.BriefPlayControler.funcBriefVoddcReady += new AxbriefocxLib._DbriefocxEvents_funcBriefVoddcReadyEventHandler(axbriefocx1_funcBriefVoddcReady);
                Framework.Environment.BriefPlayControler.funcBriefVoddcReadyCB += new AxbriefocxLib._DbriefocxEvents_funcBriefVoddcReadyCBEventHandler(axbriefocx1_funcBriefVoddcReadyCB);
                Framework.Environment.BriefPlayControler.funcBriefVoddcSynthExceptCB += new AxbriefocxLib._DbriefocxEvents_funcBriefVoddcSynthExceptCBEventHandler(axbriefocx1_funcBriefVoddcSynthExceptCB);
                Framework.Environment.BriefPlayControler.funcBriefVoddcWndMouseOptNtfCB += new AxbriefocxLib._DbriefocxEvents_funcBriefVoddcWndMouseOptNtfCBEventHandler(axbriefocx1_funcBriefVoddcWndMouseOptNtfCB);
                Framework.Environment.BriefPlayControler.funcBriefVoddfuncBriefVoddcExceptCBcPlayProgressCB += new AxbriefocxLib._DbriefocxEvents_funcBriefVoddfuncBriefVoddcExceptCBcPlayProgressCBEventHandler(axbriefocx1_funcBriefVoddfuncBriefVoddcExceptCBcPlayProgressCB);
            }
        }

        public void UnInit()
        {
            MSS_IP = "";
            MSS_Data_Path = "";
            MSS_Index_Path = "";
            MSS_Port = 0;

            ocx_BriefVoddcDeleteDispatch();
            if (Framework.Environment.BriefPlayControler != null)
            {
                Framework.Environment.BriefPlayControler.funcBriefVoddcAddDispathRspCB -= new AxbriefocxLib._DbriefocxEvents_funcBriefVoddcAddDispathRspCBEventHandler(axbriefocx1_funcBriefVoddcAddDispathRspCB);
                Framework.Environment.BriefPlayControler.funcBriefVoddcPlayProgressCB -= new AxbriefocxLib._DbriefocxEvents_funcBriefVoddcPlayProgressCBEventHandler(axbriefocx1_funcBriefVoddcPlayProgressCB);
                Framework.Environment.BriefPlayControler.funcBriefVoddcReady -= new AxbriefocxLib._DbriefocxEvents_funcBriefVoddcReadyEventHandler(axbriefocx1_funcBriefVoddcReady);
                Framework.Environment.BriefPlayControler.funcBriefVoddcReadyCB -= new AxbriefocxLib._DbriefocxEvents_funcBriefVoddcReadyCBEventHandler(axbriefocx1_funcBriefVoddcReadyCB);
                Framework.Environment.BriefPlayControler.funcBriefVoddcSynthExceptCB -= new AxbriefocxLib._DbriefocxEvents_funcBriefVoddcSynthExceptCBEventHandler(axbriefocx1_funcBriefVoddcSynthExceptCB);
                Framework.Environment.BriefPlayControler.funcBriefVoddcWndMouseOptNtfCB -= new AxbriefocxLib._DbriefocxEvents_funcBriefVoddcWndMouseOptNtfCBEventHandler(axbriefocx1_funcBriefVoddcWndMouseOptNtfCB);
                Framework.Environment.BriefPlayControler.funcBriefVoddfuncBriefVoddcExceptCBcPlayProgressCB -= new AxbriefocxLib._DbriefocxEvents_funcBriefVoddfuncBriefVoddcExceptCBcPlayProgressCBEventHandler(axbriefocx1_funcBriefVoddfuncBriefVoddcExceptCBcPlayProgressCB);
            }
        }

        public bool StartPlayBrief(string mssip, uint mssport, string datafilepath,string brieffilepath)
        {
            bool ret = false;
            if (VideoStatus == E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO)
            {
                ocx_BriefVoddcDeleteDispatch();
                ret = ocx_BriefVoddcAddDispatch(mssip, mssport, datafilepath, brieffilepath);
                if (ret)
                {
                    m_currentSpeed = E_VDA_PLAY_SPEED.E_PLAYSPEED_NORMALSPEED;
                    VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO;
                    m_statusBeforePause = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO;
                }
            }
            else
            {
                ocx_BriefVoddcStop();
                ret = ocx_BriefVoddcStart();
                if (ret)
                {
                    VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL;
                    m_statusBeforePause = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO;
                    m_currentSpeed = E_VDA_PLAY_SPEED.E_PLAYSPEED_NORMALSPEED;
                }
            }
            if (ret)
            {
                MSS_IP = mssip;
                MSS_Data_Path = datafilepath;
                MSS_Index_Path = brieffilepath;
                MSS_Port = mssport;
                //ResizeWnd(1920, 1080);

                trackBarEx1.MaxValue = 1000;

                EnableShowObjectRect = m_lastEnableShowObjectRect;
                EnableShowObjectTime = m_lastEnableShowObjectTime;
                EnableDraw = m_lastEnableDraw;
                EnableShowActionFilter = m_lastEnableShowActionFilter;
                EnableShowAreaFilter = m_lastEnableShowAreaFilter;
                ocx_BriefVoddcSetCommonFilter(m_density, m_objtype, m_color);

            }
            else
                DevComponents.DotNetBar.MessageBoxEx.Show("播放摘要失败", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return ret;
        }
        public void StopPlayBrief()
        {
            ocx_BriefVoddcStop();
            VideoTime = "00:00:00/00:00:00"+ ((SrcVideoTotleTime<=0)?"":"(0.0%)");
        }
        public bool PlayOrPauseOrResume()
        {
            try
            {
                if (!IsPlayStarted())
                {
                    if (string.IsNullOrEmpty(MSS_Index_Path) || string.IsNullOrEmpty(MSS_Data_Path) || string.IsNullOrEmpty(MSS_IP))
                        return false;
                    else
                        return StartPlayBrief(MSS_IP, MSS_Port, MSS_Data_Path, MSS_Index_Path);
                }
                else
                {
                    if (VideoStatus == E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL || VideoStatus == E_VDA_PLAY_STATUS.E_PLAY_STATUS_SPEED)
                    {
                        ocx_BriefVoddcPause();
                        //VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_PAUSE;
                    }
                    else if (VideoStatus == E_VDA_PLAY_STATUS.E_PLAY_STATUS_PAUSE)
                    {
                        ocx_BriefVoddcResume();
                        //VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL;
                    }
                    return true;
                }
            }
            catch (SDKCallException ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("摘要播放失败，["+ex.ErrorCode+"]"+ex.Message, Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
        }

        public void SpeedUp()
        {
            if (!IsPlayStarted())
                return;

            int newspeed = (int)m_currentSpeed + 1;
            if (newspeed > (int)E_VDA_PLAY_SPEED.E_PLAYSPEED_FAST4)
                newspeed = (int)E_VDA_PLAY_SPEED.E_PLAYSPEED_FAST4;
            m_currentSpeed = (E_VDA_PLAY_SPEED)newspeed;
            ocx_BriefVoddcSetSpeed(m_currentSpeed);
            if (m_currentSpeed == E_VDA_PLAY_SPEED.E_PLAYSPEED_NORMALSPEED)
                VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL;
            else
                VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_SPEED;

        }
        public void SpeedDown()
        {
            if (!IsPlayStarted())
                return;

            int newspeed = (int)m_currentSpeed - 1;
            if (newspeed < (int)E_VDA_PLAY_SPEED.E_PLAYSPEED_SLOW2)
                newspeed = (int)E_VDA_PLAY_SPEED.E_PLAYSPEED_SLOW2;
            m_currentSpeed = (E_VDA_PLAY_SPEED)newspeed;
            ocx_BriefVoddcSetSpeed(m_currentSpeed);
            if (m_currentSpeed == E_VDA_PLAY_SPEED.E_PLAYSPEED_NORMALSPEED)
                VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL;
            else
                VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_SPEED;

        }
        public void SetPosition(uint newpos)
        {
            if (!IsPlayStarted())
                return;

            bool ret = ocx_BriefVoddcSeek(newpos);

        }
        public string GrabPictureData(string saveFileName,bool needSave = true)
        {
            if (!IsPlayStarted())
                return "";
            if (!ocx_BriefVoddcIsSelectObject())
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("请先选中目标", Framework.Environment.PROGRAM_NAME);
                return "";
            }
            try
            {
                Image img;
                    img = ocx_BriefVoddcGetSelectedObjectImage();

                if (img == null)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("抓图失败", Framework.Environment.PROGRAM_NAME);
                    return "";
                }
                string time = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string type = "视频截图";
                string fileName = VideoName.Replace(".", "_").Replace(":", "_") + type + time + ".jpg";
                
                if (!string.IsNullOrEmpty(saveFileName))
                {
                    fileName = saveFileName;
                }
                else
                {
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

        public int GetVideoTotleTime()
        {
            if (!IsPlayStarted())
                return 0;

            int outval = ocx_BriefVoddcGetTotalTimeS();

            return outval;
        }

        public void SetDrawType(E_VDA_BRIEF_DRAW_FILTER_TYPE type)
        {
            ocx_BriefVoddcSetDrawType((uint)type);
        }

        public bool EnableDraw
        {
            set { ocx_BriefVoddcSetDrawMode((uint)(value ? 1 : 0)); m_lastEnableDraw = value; }
        }

        public bool EnableShowObjectRect
        {
            set
            {
                ocx_BriefVoddcSetShowObjectRect((uint)(value ? 1 : 0));
                m_lastEnableShowObjectRect = value;
            }
        }
        public bool EnableShowObjectTime
        {
            set
            {
                ocx_BriefVoddcSetShowObjectTIme((uint)(value ? 1 : 0));
                m_lastEnableShowObjectTime = value;
            }
        }
        public bool EnableShowActionFilter
        {
            set
            {
                ocx_BriefVoddcSetShowDrawGraph((uint)E_VDA_BRIEF_DRAW_FILTER_TYPE.GRAPH_TYPE_ARROW_FRAME,(uint)(value ? 1 : 0));
                ocx_BriefVoddcSetShowDrawGraph((uint)E_VDA_BRIEF_DRAW_FILTER_TYPE.GRAPH_TYPE_ARROW_LINE,(uint)(value ? 1 : 0));
                m_lastEnableShowActionFilter = value;
            }
        }
        public bool EnableShowAreaFilter
        {
            set
            {
                ocx_BriefVoddcSetShowDrawGraph((uint)E_VDA_BRIEF_DRAW_FILTER_TYPE.GRAPH_TYPE_INTERESTED_AREA,(uint)(value ? 1 : 0));
                ocx_BriefVoddcSetShowDrawGraph((uint)E_VDA_BRIEF_DRAW_FILTER_TYPE.GRAPH_TYPE_UNINTERESTED_AREA,(uint)(value ? 1 : 0));
                m_lastEnableShowAreaFilter = value;
            }
        }
        public BriefMoveobjInfo GetObjectInfo()
        {
            return ocx_BriefVoddcGetSelectedObjectDetailInfo();
        }
        
        public void SetDensity(E_VDA_BRIEF_DENSITY density)
        {
            if(IsPlayStarted())
                ocx_BriefVoddcSetCommonFilter(density, m_objtype, m_color);

            m_density = density;
        }
        public void SetObjectType(E_VDA_MOVEOBJ_TYPE objtype)
        { 
            if(IsPlayStarted())
                ocx_BriefVoddcSetCommonFilter(m_density, objtype, m_color);

            m_objtype = objtype;
        }
        public void SetObjectColor(E_MOVEOBJ_COLOR color)
        { 
            if(IsPlayStarted())
                ocx_BriefVoddcSetCommonFilter(m_density, m_objtype, color);

            m_color = color;
        }

        public void SetAdjustTime(DateTime time)
        {
            ocx_BriefVoddcSetAdjustTime(DataModel.Common.ConvertLinuxTime(time));
        }

        public void ClearDrawGraph()
        {
            Framework.Environment.BriefPlayControler.ocx_BriefVoddcClearDrawGraph(m_playHandle, (uint)(E_VDA_BRIEF_DRAW_FILTER_TYPE.GRAPH_TYPE_ARROW_LINE));
            Framework.Environment.BriefPlayControler.ocx_BriefVoddcClearDrawGraph(m_playHandle, (uint)(E_VDA_BRIEF_DRAW_FILTER_TYPE.GRAPH_TYPE_ARROW_FRAME));
            Framework.Environment.BriefPlayControler.ocx_BriefVoddcClearDrawGraph(m_playHandle, (uint)(E_VDA_BRIEF_DRAW_FILTER_TYPE.GRAPH_TYPE_INTERESTED_AREA));
            Framework.Environment.BriefPlayControler.ocx_BriefVoddcClearDrawGraph(m_playHandle, (uint)(E_VDA_BRIEF_DRAW_FILTER_TYPE.GRAPH_TYPE_UNINTERESTED_AREA));

        }

        #endregion

        #region BRIEFOCX
        private bool ocx_BriefVoddcAddDispatch(string ip,uint port,string datafile,string brieffile)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcAddDispatch ip:{0},port:{1},datafile:{2},brieffile:{3}",ip,port,datafile,brieffile);
            string tParam = string.Format("<root> "+
                                        "<Hwnd>{0}</Hwnd> "+
                                        "<NetIp>{1}</NetIp>" +
                                        "<MsgDispatchPort>{2}</MsgDispatchPort> "+
                                        "<TimeOutMs>120</TimeOutMs> "+
                                        "<BriefDataPath>{3}</BriefDataPath> "+
                                        "<BriefIndexPath>{4}</BriefIndexPath>" +
                                        "<AdjustTime>0</AdjustTime> "+
                                        "</root>"
                                        ,axVdaPlayer1.Handle.ToInt32()
                                        ,ip
                                        ,port
                                        ,datafile
                                        ,brieffile);
            string xml = Framework.Environment.BriefPlayControler.ocx_BriefVoddcAddDispatch(tParam);
            /*<result> 
            <InstKey>1</InstKey> 
            <Ret>0</Ret> 
            </result>*/

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(xml);
            uint ret = Convert.ToUInt32(doc.SelectSingleNode("//result/Ret").InnerText);
            if (ret != 0)
                GetError(ret);

            uint playHandle = Convert.ToUInt32(doc.SelectSingleNode("//result/InstKey").InnerText);
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcAddDispatch retVal:" + ret + ",m_playHandle:" + playHandle);
            m_playHandle = playHandle;

            return ret==0;

        }

        private bool ocx_BriefVoddcDeleteDispatch()
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcDeleteDispatch m_playHandle:" + m_playHandle);
            uint retVal = 0;
            if (m_playHandle > 0)
            {

            retVal= Framework.Environment.BriefPlayControler.ocx_BriefVoddcDeleteDispatch(m_playHandle);
            }
            //if (retVal != 0)
            //    GetError(retVal);

            m_playHandle = 0;
            VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO;
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcDeleteDispatch retVal:" + retVal);
            return retVal==0;
        }

        
        private BriefMoveobjInfo ocx_BriefVoddcGetSelectedObjectDetailInfo()
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcGetSelectedObjectDetailInfo m_playHandle:" + m_playHandle);
            /*
             <?xml version="1.0"?>
            <result>
	            <ColorType>70201</ColorType>
	            <FrameReq>3</FrameReq>
	            <ObjSeq>1</ObjSeq>
	            <ObjType>1</ObjType>
	            <TargetSeq>1</TargetSeq>
	            <TimeStamp>600</TimeStamp>
	            <X>432</X>
	            <Y>414</Y>
	            <Width>690</Width>
	            <Height>468</Height>
	            <BeginTime>600</BeginTime>
	            <EndTime>600</EndTime>
	            <Ret>0</Ret>
            </result>
             */
            string xml = Framework.Environment.BriefPlayControler.ocx_BriefVoddcGetSelectedObjectDetailInfo(m_playHandle);
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(xml);
            uint ret = Convert.ToUInt32(doc.SelectSingleNode("//result/Ret").InnerText);
            if (ret != 0)
                GetError(ret);

            BriefMoveobjInfo obj = new BriefMoveobjInfo();
            int ColorType = Convert.ToInt32(doc.SelectSingleNode("//result/ColorType").InnerText);
            int FrameReq = Convert.ToInt32(doc.SelectSingleNode("//result/FrameReq").InnerText);
            int ObjSeq = Convert.ToInt32(doc.SelectSingleNode("//result/ObjSeq").InnerText);
            int ObjType = Convert.ToInt32(doc.SelectSingleNode("//result/ObjType").InnerText);
            int TargetSeq = Convert.ToInt32(doc.SelectSingleNode("//result/TargetSeq").InnerText);
            int TimeStamp = Convert.ToInt32(doc.SelectSingleNode("//result/TimeStamp").InnerText);
            int X = Convert.ToInt32(doc.SelectSingleNode("//result/X").InnerText);
            int Y = Convert.ToInt32(doc.SelectSingleNode("//result/Y").InnerText);
            int Width = Convert.ToInt32(doc.SelectSingleNode("//result/Width").InnerText);
            int Height = Convert.ToInt32(doc.SelectSingleNode("//result/Height").InnerText);
            int BeginTime = Math.Max(0, Convert.ToInt32(doc.SelectSingleNode("//result/BeginTime").InnerText)-5000);
            int EndTime =  Convert.ToInt32(doc.SelectSingleNode("//result/EndTime").InnerText)+5000;
            obj.MoveObjID = (uint)TargetSeq;
            obj.MoveObjType = (E_VDA_MOVEOBJ_TYPE)ObjType;
            obj.MoveObjColor = (uint)ColorType;
            obj.BeginTimeS = DataModel.Common.ConvertLinuxTime((uint)BeginTime/1000);
            obj.EndTimeS = DataModel.Common.ConvertLinuxTime((uint)EndTime/1000);
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcGetSelectedObjectDetailInfo retVal:" + ret);
            return obj;
        }

        private Image ocx_BriefVoddcGetSelectedObjectImage()
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcGetSelectedObjectImage ");

            string xml = Framework.Environment.BriefPlayControler.ocx_BriefVoddcGetSelectedObjectImage(m_playHandle);
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(xml);
            uint retVal = Convert.ToUInt32(doc.SelectSingleNode("//result/Ret").InnerText) ;
            if (retVal != 0)
                GetError(retVal);

            //int picsize = Convert.ToInt32(doc.SelectSingleNode("//result/picsize").InnerText);
            string picdata = doc.SelectSingleNode("//result/ImageData").InnerText;
            //System.IO.File.WriteAllText(@"c:\a.txt", picdata);
            byte[] byteimg = Convert.FromBase64String(picdata);
            System.IO.MemoryStream streamimg = new System.IO.MemoryStream(byteimg);
            Image img = Image.FromStream(streamimg);
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcGetSelectedObjectImage retVal:{0},width:{1},height:{2}", retVal, img.Width, img.Height);
            return img;

        }

        private string ocx_BriefVoddcGetSelectedObjectInfo()
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcGetSelectedObjectInfo m_playHandle:" + m_playHandle);

            string retVal = Framework.Environment.BriefPlayControler.ocx_BriefVoddcGetSelectedObjectInfo(m_playHandle);
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcGetSelectedObjectInfo retVal:" + retVal);
            return retVal;
        }

        private string ocx_BriefVoddcGetSpeed()
        {
            return Framework.Environment.BriefPlayControler.ocx_BriefVoddcGetSpeed(m_playHandle);
        }

        private int ocx_BriefVoddcGetTotalTimeS()
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcGetTotalTimeS m_playHandle:" + m_playHandle);
            string xml = Framework.Environment.BriefPlayControler.ocx_BriefVoddcGetTotalTimeS(m_playHandle);

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(xml);
            uint retVal = Convert.ToUInt32(doc.SelectSingleNode("//result/Ret").InnerText);
            if (retVal != 0)
                GetError(retVal);

            int TotalTime = Convert.ToInt32(doc.SelectSingleNode("//result/TotalTimeS").InnerText);

            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcGetTotalTimeS retVal:" + retVal);
            return TotalTime;
        }


        private bool ocx_BriefVoddcIsHitGraph(int lPosX, int lPosY)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcIsHitGraph m_playHandle:{0},[{1},{2}]" , m_playHandle,lPosX,lPosY);
            string xml = Framework.Environment.BriefPlayControler.ocx_BriefVoddcIsHitGraph(m_playHandle, lPosX, lPosY);
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(xml);
            uint retVal = Convert.ToUInt32(doc.SelectSingleNode("//result/Ret").InnerText) ;
            if (retVal != 0)
                GetError(retVal);

            bool ishit = Convert.ToInt32(doc.SelectSingleNode("//result/IsHit").InnerText) == 1;

            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcIsHitGraph retVal:" + retVal + ",ishit:" + ishit);

            return retVal==0 && ishit;
        }

        private bool ocx_BriefVoddcIsSelectObject()
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcIsSelectObject m_playHandle:" + m_playHandle);

            uint retVal = Framework.Environment.BriefPlayControler.ocx_BriefVoddcIsSelectObject(m_playHandle);
            //if (retVal != 0)
            //    GetError(retVal);
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcIsSelectObject retVal:" + retVal);
            return retVal == 0;

        }

        private bool ocx_BriefVoddcPause()
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcPause m_playHandle:" + m_playHandle);

            uint retVal = Framework.Environment.BriefPlayControler.ocx_BriefVoddcPause(m_playHandle);
            if (retVal != 0)
                GetError(retVal);
            if (VideoStatus!= E_VDA_PLAY_STATUS.E_PLAY_STATUS_PAUSE)
                m_statusBeforePause = VideoStatus;

            VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_PAUSE;

            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcPause retVal:" + retVal);
            return retVal == 0;
        }

        private bool ocx_BriefVoddcSeek(uint uProgress)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcSeek m_playHandle:" + m_playHandle + ",uProgress:" + uProgress);

            uint retVal = Framework.Environment.BriefPlayControler.ocx_BriefVoddcSeek(m_playHandle, uProgress);
            if (retVal != 0)
                GetError(retVal);
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcSeek retVal:" + retVal);
            return retVal == 0;
        }

        private bool ocx_BriefVoddcSetAdjustTime(uint uTime)
        {
            ulong temptime = uTime * 1000ul;
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcSetAdjustTime uTime:{0}", temptime);
            uint ret = Framework.Environment.BriefPlayControler.ocx_BriefVoddcSetAdjustTime(m_playHandle, temptime);
            if (ret != 0)
                GetError(ret);

            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcSetAdjustTime ret:{0}", ret);
            return ret==0;
        }

        private uint ocx_BriefVoddcSetCommonFilter(E_VDA_BRIEF_DENSITY density,E_VDA_MOVEOBJ_TYPE objtype,E_MOVEOBJ_COLOR color)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcSetCommonFilter density:{0},objtype:{1},color:{2}", density, objtype, color);

            StringBuilder strParam = new StringBuilder();
            /*<root> 
            <Density></Density> <!--密度--> 
            <ObjType></ObjType> <!--目标类型--> 
            <ObjColorArray> <!--目标颜色--> 
            <ObjColor>0</ObjColor> 
            </ObjColorArray> 
            </root>*/
            int obj = 0;
            switch (objtype)
            {
                case E_VDA_MOVEOBJ_TYPE.E_VDA_MOVEOBJ_TYPE_ALL:
                    obj = 3;
                    break;
                case E_VDA_MOVEOBJ_TYPE.E_VDA_MOVEOBJ_TYPE_PEOPLE:
                    obj = 1;
                    break;
                case E_VDA_MOVEOBJ_TYPE.E_VDA_MOVEOBJ_TYPE_CAR:
                    obj = 2;
                    break;
                case E_VDA_MOVEOBJ_TYPE.E_VDA_MOVEOBJ_TYPE_UNKNOWN:
                    obj = 0;
                    break;
                default:
                    break;
            }
            strParam.AppendFormat("<root>");
            strParam.AppendFormat("<handle>{0}</handle>", m_playHandle);
            strParam.AppendFormat("<Density>{0}</Density>", ((int)density/10f).ToString("0.0"));// <!--密度--> 
            strParam.AppendFormat("<ObjType>{0}</ObjType>",obj); //<!--目标类型--> 
            strParam.AppendFormat("<ObjColorArray>");// <!--目标颜色--> 
            strParam.AppendFormat("<ObjColor>{0}</ObjColor>",(int)color); 
            strParam.AppendFormat("</ObjColorArray>");
            strParam.AppendFormat("<ValidTimeSectionArray/>");
            strParam.AppendFormat("<InvalidTimeSectionArray/>");
            strParam.AppendFormat("</root>");


            uint ret = Framework.Environment.BriefPlayControler.ocx_BriefVoddcSetCommonFilter(strParam.ToString());
            if (ret != 0)
                GetError(ret);
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcSetCommonFilter ret:" + ret);
            return ret;
        }

        private uint ocx_BriefVoddcSetDrawMode(uint bEnable)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcSetDrawMode bEnable:{0}", bEnable);
            uint ret= Framework.Environment.BriefPlayControler.ocx_BriefVoddcSetDrawMode(m_playHandle, bEnable);
            //if (ret != 0)
            //    GetError(ret);
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcSetDrawMode ret:" + ret);
            return ret;
        }

        private uint ocx_BriefVoddcSetDrawType(uint uDrawType)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcSetDrawType uDrawType:{0}", uDrawType);
            uint ret= Framework.Environment.BriefPlayControler.ocx_BriefVoddcSetDrawType(m_playHandle, uDrawType);
            //if (ret != 0)
            //    GetError(ret);
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcSetDrawType ret:" + ret);
            return ret;
        }

        private uint ocx_BriefVoddcSetShowDrawGraph(uint uGraphType, uint bShow)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcSetShowDrawGraph uGraphType:{0},bShow:{1}", uGraphType, bShow);
            uint ret = Framework.Environment.BriefPlayControler.ocx_BriefVoddcSetShowDrawGraph(m_playHandle, uGraphType, bShow);
            //if (ret != 0)
            //    GetError(ret);
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcSetShowDrawGraph ret:" + ret);
            return ret;
        }

        private uint ocx_BriefVoddcSetShowObjectRect(uint bShow)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcSetShowObjectRect bShow:{0}",  bShow);
            uint ret= Framework.Environment.BriefPlayControler.ocx_BriefVoddcSetShowObjectRect(m_playHandle, bShow);
            //if (ret != 0)
            //    GetError(ret);
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcSetShowObjectRect ret:" + ret);
            return ret;
        }

        private uint ocx_BriefVoddcSetShowObjectTIme(uint bShow)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcSetShowObjectTIme bShow:{0}", bShow);
            uint ret= Framework.Environment.BriefPlayControler.ocx_BriefVoddcSetShowObjectTIme(m_playHandle, bShow);
            //if (ret != 0)
            //    GetError(ret);
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcSetShowObjectTIme ret:" + ret);
            return ret;
        }

        private bool ocx_BriefVoddcSetSpeed(E_VDA_PLAY_SPEED fSpeed)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcSetSpeed m_playHandle:" + m_playHandle + ",fSpeed:" + fSpeed);
            float s = 1.0f;
            switch (fSpeed)
            {
                case E_VDA_PLAY_SPEED.E_PLAYSPEED_SLOW16:
                    s = 0.0725f;
                    break;
                case E_VDA_PLAY_SPEED.E_PLAYSPEED_SLOW8:
                    s = 0.125f;
                    break;
                case E_VDA_PLAY_SPEED.E_PLAYSPEED_SLOW4:
                    s = 0.25f;
                    break;
                case E_VDA_PLAY_SPEED.E_PLAYSPEED_SLOW2:
                    s = 0.5f;
                    break;
                case E_VDA_PLAY_SPEED.E_PLAYSPEED_NORMALSPEED:
                    s = 1.0f;
                    break;
                case E_VDA_PLAY_SPEED.E_PLAYSPEED_FAST2:
                    s = 2f;
                    break;
                case E_VDA_PLAY_SPEED.E_PLAYSPEED_FAST4:
                    s = 4f;
                    break;
                case E_VDA_PLAY_SPEED.E_PLAYSPEED_FAST8:
                    s = 8f;
                    break;
                case E_VDA_PLAY_SPEED.E_PLAYSPEED_FAST16:
                    s = 16f;
                    break;
                default:
                    break;
            }
            uint retVal = Framework.Environment.BriefPlayControler.ocx_BriefVoddcSetSpeed(m_playHandle, s);
            if (retVal != 0)
                GetError(retVal);
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcSetSpeed retVal:" + retVal);
            return retVal == 0;
        }

        private bool ocx_BriefVoddcStart()
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcStart m_playHandle:" + m_playHandle);

            uint retVal = Framework.Environment.BriefPlayControler.ocx_BriefVoddcStart(m_playHandle);
            if (retVal != 0)
                GetError(retVal);
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcStart retVal:" + retVal);
            return retVal==0;

        }

        private bool ocx_BriefVoddcStop()
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcStop m_playHandle:" + m_playHandle);
            uint retVal = 0;
                retVal = Framework.Environment.BriefPlayControler.ocx_BriefVoddcStop(m_playHandle);
                //if (retVal != 0)
                //    GetError(retVal);
            if (VideoStatus!= E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO)
                VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_FINISH;
            m_statusBeforePause = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO;

            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcStop retVal:" + retVal);
            return retVal==0;
        }

        private bool ocx_BriefVoddcResume()
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcResume m_playHandle:" + m_playHandle);

            uint retVal = Framework.Environment.BriefPlayControler.oxc_BriefVoddcResume(m_playHandle);
            if (retVal != 0)
                GetError(retVal);

            VideoStatus = (m_statusBeforePause == E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO) ? E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL : m_statusBeforePause;

            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcResume retVal:" + retVal);
            return retVal == 0;
        }


        void axbriefocx1_funcBriefVoddfuncBriefVoddcExceptCBcPlayProgressCB(object sender, AxbriefocxLib._DbriefocxEvents_funcBriefVoddfuncBriefVoddcExceptCBcPlayProgressCBEvent e)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("axbriefocx1_funcBriefVoddfuncBriefVoddcExceptCBcPlayProgressCB uHandle:{0},dwResult:{1}", e.uHandle, e.dwResult);
        }

        void axbriefocx1_funcBriefVoddcWndMouseOptNtfCB(object sender, AxbriefocxLib._DbriefocxEvents_funcBriefVoddcWndMouseOptNtfCBEvent e)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("axbriefocx1_funcBriefVoddcWndMouseOptNtfCB uHandle:{0},dwOptType:{1},X:{2},Y:{3}", e.uHandle, e.dwOptType, e.x, e.y);
            DoOnBriefVoddcWndMouseOptNtfCB((E_VDA_BRIEF_WND_MOUSE_OPT_TYPE)e.dwOptType);
        }
        void DoOnBriefVoddcWndMouseOptNtfCB(E_VDA_BRIEF_WND_MOUSE_OPT_TYPE type)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<E_VDA_BRIEF_WND_MOUSE_OPT_TYPE>(DoOnBriefVoddcWndMouseOptNtfCB), type);
            }
            else
            {
                if (Framework.Environment.BriefPlayControler == null)
                    return;

                if (ocx_BriefVoddcIsSelectObject())
                {
                    if (type == E_VDA_BRIEF_WND_MOUSE_OPT_TYPE.E_BRIEF_WND_MOUSE_LUp)
                        ocx_BriefVoddcPause();
                    else if (type == E_VDA_BRIEF_WND_MOUSE_OPT_TYPE.E_BRIEF_WND_MOUSE_LDCLICK)
                    {
                        Point p = axVdaPlayer1.PointToClient( MousePosition);
                        if (!ocx_BriefVoddcIsHitGraph(p.X, p.Y) && MoveObjectClick != null)
                            MoveObjectClick(this, GetObjectInfo());
                    }
                }
                else
                {
                    ocx_BriefVoddcResume();

                    if (type == E_VDA_BRIEF_WND_MOUSE_OPT_TYPE.E_BRIEF_WND_MOUSE_LDCLICK)
                    {
                        Point p = axVdaPlayer1.PointToClient(MousePosition);

                        if (!ocx_BriefVoddcIsHitGraph(p.X, p.Y) && MouseDoubleClickEx != null)
                            MouseDoubleClickEx(this, null);
                    }
                }
            }
        }

        void axbriefocx1_funcBriefVoddcSynthExceptCB(object sender, AxbriefocxLib._DbriefocxEvents_funcBriefVoddcSynthExceptCBEvent e)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("axbriefocx1_funcBriefVoddcSynthExceptCB uHandle:{0},eBfsState:{1}", e.uHandle, e.eBfsState);
            DoOnBriefVoddcSynthExceptCB(e.eBfsState);
        }
        void DoOnBriefVoddcSynthExceptCB(uint e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<uint>(DoOnBriefVoddcSynthExceptCB),e);
            }
            else
            {
                if (Framework.Environment.BriefPlayControler == null)
                    return;

                ClearDrawGraph();
                VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_SYNTH_ERROR;
                var msg = Constant.BriefStateTypeInfos.FirstOrDefault(item=>item.NType == e);
                if(msg!=null)
                    DevComponents.DotNetBar.MessageBoxEx.Show("摘要播放失败，[" + e + "]" +msg.Name, Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        void axbriefocx1_funcBriefVoddcReadyCB(object sender, AxbriefocxLib._DbriefocxEvents_funcBriefVoddcReadyCBEvent e)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("axbriefocx1_funcBriefVoddcReadyCB uHandle:{0},dwResult:{1}", e.uHandle, e.dwResult);
        }

        void axbriefocx1_funcBriefVoddcReady(object sender, AxbriefocxLib._DbriefocxEvents_funcBriefVoddcReadyEvent e)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("axbriefocx1_funcBriefVoddcReady uHandle:{0},uRet:{1}", e.uHandle, e.uRet);
        }

        void axbriefocx1_funcBriefVoddcPlayProgressCB(object sender, AxbriefocxLib._DbriefocxEvents_funcBriefVoddcPlayProgressCBEvent e)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("axbriefocx1_funcBriefVoddcPlayProgressCB uHandle:{0},dwPlayProgress:{1},dwTimeS:{2},dwResult:{3}"
                , e.uHandle, e.dwPlayProgress,e.dwTimeS,e.dwResult);
            if(e.dwPlayProgress>0)
                DoOnBriefVoddcPlayProgressCB(e.dwPlayProgress, e.dwTimeS);
        }
        void DoOnBriefVoddcPlayProgressCB(uint progress,uint time)
        {
            if (!IsHandleCreated || IsDisposed)
                return;

            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<uint,uint>(DoOnBriefVoddcPlayProgressCB), progress,time);
            }
            else
            {
                if (Framework.Environment.BriefPlayControler == null)
                    return;
                if (!IsHandleCreated || IsDisposed)
                    return;

                Progress = progress;
                int outval = ocx_BriefVoddcGetTotalTimeS();

                
                VideoTime = new DateTime().AddSeconds(time).ToString("HH:mm:ss") + "/" + new DateTime().AddSeconds(outval).ToString("HH:mm:ss")
                    +((SrcVideoTotleTime<=0)?"": "(" + (outval*100/SrcVideoTotleTime).ToString("0.0") + "%)");
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("VideoTime"));
                }
                if (progress == 1000)
                {
                    VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_FINISH;
                }
            }
        }

        void axbriefocx1_funcBriefVoddcAddDispathRspCB(object sender, AxbriefocxLib._DbriefocxEvents_funcBriefVoddcAddDispathRspCBEvent e)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("axbriefocx1_funcBriefVoddcAddDispathRspCB uHandle:{0},uResult:{1}", e.uHandle, e.uResult);
            //ocx_BriefVoddcStart();
            //VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL;
            DoOnBriefVoddcAddDispathRspCB(e.uResult);
        }
        void DoOnBriefVoddcAddDispathRspCB(uint uResult)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<uint>(DoOnBriefVoddcAddDispathRspCB),uResult);
            }
            else
            {
                if (Framework.Environment.BriefPlayControler == null)
                    return;

                try
                {
                    GetError(uResult);
                    ocx_BriefVoddcStart();
                    VideoStatus = E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL;
                }
                catch (SDKCallException ex)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("摘要播放失败，[" + ex.ErrorCode + "]" + ex.Message, Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
            }
        }
        private void GetError(uint errorCode)
        {
            string error = Framework.Environment.BriefPlayControler.ocx_GetErrorDiscription(errorCode);
            if (errorCode > 0 && errorCode != 12)
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
        private void UpdateTrackBar(bool enable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(UpdateTrackBar), enable);
            }
            else
            {
                if (trackBarEx1.Enabled != enable)
                    trackBarEx1.Enabled = enable;
            }
        }

        //private void SetWndResolution()
        //{
        //    int h = 1080; int w = 1920;
        //    //ocx_VodSdk_GetPlayResolution(out w, out h);
        //    ResizeWnd((uint)w, (uint)h);
        //}
        //private void ResizeWnd(uint m_width, uint m_height)
        //{
        //    if (InvokeRequired)
        //    {
        //        this.Invoke(new Action<uint, uint>(ResizeWnd), m_width, m_height);
        //    }
        //    else
        //    {
        //        //panel2.BorderStyle = System.Windows.Forms.BorderStyle.None;
        //        //axVdaPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
        //        float a = (float)panelEx1.Width / m_width;
        //        float b = (float)panelEx1.Height / m_height;

        //        if (a <= b)
        //        {
        //            axVdaPlayer1.Width = panelEx1.Width;
        //            axVdaPlayer1.Height = (int)Math.Round(m_height * a);
        //        }
        //        else
        //        {
        //            axVdaPlayer1.Width = (int)Math.Round(m_width * b);
        //            axVdaPlayer1.Height = panelEx1.Height;
        //        }
        //        axVdaPlayer1.Left = (panelEx1.Width - axVdaPlayer1.Width) / 2;
        //        axVdaPlayer1.Top = (panelEx1.Height - axVdaPlayer1.Height) / 2;
        //    }
        //}

        private bool IsPlayStarted()
        {
            return (VideoStatus == E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL || VideoStatus == E_VDA_PLAY_STATUS.E_PLAY_STATUS_PAUSE || VideoStatus == E_VDA_PLAY_STATUS.E_PLAY_STATUS_SPEED);

        }
        #endregion

        #region 事件响应


        private void labelX1_MouseClick(object sender, MouseEventArgs e)
        {
            if (MouseClickEx != null)
                MouseClickEx(this, e);
        }

        private void trackBarEx1_ValueChangedByMouse(object sender, EventArgs e)
        {
            SetPosition((uint)trackBarEx1.Value);
        }


        #endregion

    }
}
