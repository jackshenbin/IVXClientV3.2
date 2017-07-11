using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Practices.Prism.Events;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using MyLog4Net;
using IVX.DataModel;
using DevComponents.DotNetBar;
using IVX.Live.MainForm.Service;

namespace IVX.Live.VOD.OCX
{
    [Guid("B2CBE0DC-75CA-4458-9E5C-6584C2FE9552"),
    ProgId("VODOCX"),
    ClassInterface(ClassInterfaceType.None),
    ComDefaultInterface(typeof(IVODOCX)),
    ComSourceInterfaces(typeof(IVODOCXEvents)),
    ComVisible(true)]
    public partial class VODOCX : UserControl, IVODOCX, IObjectSafety// , IEventAggregatorSubscriber
    {

        #region Fields

        bool m_isLogin = false;
        private VideoExport m_videoExport;


        #endregion

        #region Private helper functions

        private string MakeRetMsg(LVErrorType errCode, string errDiscription, string retInfo = "")
        {
            string ret = string.Format("<Ret>"
                + "<RetMsg><ErrorCode>{0}</ErrorCode><Description>{1}</Description></RetMsg>"
                + "<RetInfo>{2}</RetInfo>"
                + "</Ret>"
                , (int)errCode
                , errDiscription
                , retInfo);
            return ret;
        }
        bool ocx_VodSdk_Init()
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_Init ");
            string oldCurrDir = Environment.CurrentDirectory;
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Environment.CurrentDirectory = System.IO.Directory.GetParent(assembly.Location).FullName;

            int retVal = axvodocx1.ocx_VodSdk_Init();
            Environment.CurrentDirectory = oldCurrDir;

            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_Init retVal:" + retVal);
            return retVal == 0;
        }
        int ocx_VodSdk_UnInit()
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_UnInit ");
            int retVal = axvodocx1.ocx_VodSdk_UnInit();
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_UnInit retVal:" + retVal);
            return retVal;
        }

        private void ThemeChanged(string param)
        {        
            switch (param)
            {
                case "Metro":
                    StyleManager.MetroColorGeneratorParameters = DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters.DarkBlue;
                    StyleManager.Style = eStyle.Metro; // BOOM
                    break;
                case "Office2007Blue":
                case "Office2007Silver":
                case "Office2007Black":
                case "Office2007VistaGlass":
                case "Office2010Silver":
                case "Office2010Blue":
                case "Office2010Black":
                case "Windows7Blue":
                case "VisualStudio2010Blue":
                    eStyle style = (eStyle)Enum.Parse(typeof(eStyle), param);
                    StyleManager.ChangeStyle(style, Color.Empty);
                    break;

                default:
                    if(param.StartsWith("#"))
                    {
                        string colorstr = param.TrimStart('#');
                        System.Drawing.Color color = System.Drawing.Color.FromArgb(Convert.ToInt32(colorstr,16));
                        if (StyleManager.Style == eStyle.Metro)
                            StyleManager.MetroColorGeneratorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White, color);
                        else
                            StyleManager.ColorTint = color;

                    }
                    break;
            }
        }
        private static string GetErrMsg(LVErrorType type)
        {
            string msg = "";
            switch (type)
            {
                case LVErrorType.No_Error:
                    msg = "";
                    break;
                case LVErrorType.Err_UnLogined:
                    msg = "未登录";
                    break;
                case LVErrorType.Err_HaveLogined:
                    msg = "已经登录";
                    break;
                case LVErrorType.Err_login:
                    msg = "登录失败";
                    break;
                case LVErrorType.Err_DelTask:
                    msg = "删除任务失败";
                    break;
                case LVErrorType.Err_EmptyTaskList:
                    msg = "任务列表为空";
                    break;
                case LVErrorType.Err_NoSuchTask:
                    msg = "无此任务";
                    break;
                case LVErrorType.Err_GetTaskList:
                    msg = "获取任务列表失败";
                    break;
                default:
                    msg = "未知错误";
                    break;
            }
            return msg;
        }

        private static string GetErrMsg(LVErrorType type, Exception ex)
        {
            string msg = GetErrMsg(type);
            msg = string.Format("{0}, exception: type '{1}', description: '{2}'", msg, ex, ex.Message);
            return msg;
        }

        #endregion

        #region ILVACrowd implementations

        public VODOCX()
        {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("VODOCX");

            InitializeComponent();
            StyleManager.Style = eStyle.Metro;
            //StyleManager.ColorTint = Color.Transparent;

        }
       
        public string GetVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string fileVersion = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
            return MakeRetMsg(LVErrorType.No_Error, "", fileVersion);
        }

        public string ChangeTheme(string param)
        {
            ThemeChanged(param);
            return MakeRetMsg(LVErrorType.No_Error, "");
        }


        public string CreateVOD(string hostIP, uint hostPort, string videoPath, int startSecond, int endSecond)
        {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("VODOCX CreateVOD hostIP:{0},hostPort:{1},videoPath:{2},startSecond:{3},endSecond:{4}", hostIP, hostPort, videoPath, startSecond, endSecond));

            ocx_VodSdk_Init();
            IVX.Live.MainForm.Framework.Environment.VODPlayControler = this.axvodocx1;

            IVX.Live.MainForm.View.ucPlayHistory vod = new MainForm.View.ucPlayHistory();
            vod.IsPlay4OCX = true;
            vod.OCX_VideoPath = videoPath;
            vod.OCX_MssHostIp = hostIP;
            vod.OCX_MssHostPort = hostPort;
            vod.OCX_TaskName = " ";
            vod.OCX_StartSecond = startSecond;
            vod.OCX_EndSecond = endSecond;
            vod.ShowGotoCompare = false;

            vod.PictureSaved4OCX += brief_PictureSaved4OCX;
            vod.VideoStartSave4OCX += vod_VideoStartSave4OCX;
            this.panelEx1.Controls.Add(vod);
            vod.Dock = DockStyle.Fill;

            m_videoExport = new VideoExport();
            m_videoExport.Init();
            m_videoExport.VideoDownloadProgressUpdate += m_videoExport_VideoDownloadProgressUpdate;
            m_videoExport.VideoDownloadStatusUpdate += m_videoExport_VideoDownloadStatusUpdate;

            //brief.Task = new TaskInfoV3_1() { TaskId = 100, TaskName = "xxxxxx.mp4", StartTime = new DateTime(), EndTime = new DateTime().AddSeconds(100), };
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("VODOCX Clear No_Error");
            return MakeRetMsg(LVErrorType.No_Error, "");

        }

        public string StopVideoSave(int handle)
        {
            m_videoExport.DelExport(handle);
            return MakeRetMsg(LVErrorType.No_Error, "");
        }


        public string VdaSetSavePictureAndVideoDefaultPath(string path)
        {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("VODOCX  VdaSetSavePictureAndVideoDefaultPath path:" + path);

            try
            {
                IVX.Live.MainForm.Framework.Environment.PictureSavePath = path;
                IVX.Live.MainForm.Framework.Environment.VideoSavePath = path;
                MyLog4Net.Container.Instance.Log.DebugWithDebugView("VODOCX VdaSetSavePictureAndVideoDefaultPath No_Error");
                return MakeRetMsg(0, "");


            }
            catch (SDKCallException ex)
            {
                MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "VODOCX  VdaSetSavePictureAndVideoDefaultPath error :ret=[" + ex.ErrorCode + "]" + ex.Message);
                return MakeRetMsg(LVErrorType.Err_UnLogined, ex.Message);
            }

        }


        public string Clear()
        {
            try
            {
                
                MyLog4Net.Container.Instance.Log.DebugWithDebugView("VODOCX Clear");

                //IVX.Live.Crowd.Framework.Container.Instance.LogOut();
                if (panelEx1.Controls.Count > 0)
                {
                    IVX.Live.MainForm.View.ucPlayHistory vod = panelEx1.Controls[0] as IVX.Live.MainForm.View.ucPlayHistory;
                    if (vod != null)
                    {
                        vod.Clear();
                        this.panelEx1.Controls.Clear();
                    }
                    m_videoExport.UnInit();
                }
                IVX.Live.MainForm.Framework.Environment.VODPlayControler = null;
                ocx_VodSdk_UnInit();
            }
            catch (SDKCallException ex)
            {
                MyLog4Net.Container.Instance.Log.DebugWithDebugView("VODOCX Clear error:" + ex.ToString());

                m_isLogin = false;
                return MakeRetMsg(LVErrorType.Err_Clear, "清理出错");
            }
            exit = false;
            new System.Threading.Thread(sleep).Start();
            while (!exit)
            { System.Threading.Thread.Sleep(20); }
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("VODOCX Clear No_Error");
            return MakeRetMsg(LVErrorType.No_Error, "");
        }
       static bool exit = false;
        void sleep()
        { 
            System.Threading.Thread.Sleep(5000);
            exit = true;
        }
        void brief_PictureSaved4OCX(string obj)
        {
            if (IsHandleCreated && OnPictureSaved != null)
                OnPictureSaved(obj, 0);
        }
        void vod_VideoStartSave4OCX(object sender, EventArgs e)
        {            
            IVX.Live.MainForm.View.ucPlayHistory vod = sender as MainForm.View.ucPlayHistory;
            string fileName = string.Format("视频导出_{0}_{1}.mp4",vod.OCX_StartSecond,vod.OCX_EndSecond);
            bool needSave = true;

            fileName = IVX.Live.MainForm.Framework.Environment.VideoSavePath.TrimEnd('\\') + "\\" + fileName;
            System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
            sfd.RestoreDirectory = true;

            sfd.Filter = "*.mp4|*.mp4|全部文件|*.*";
            sfd.FileName = System.IO.Path.GetFileName(fileName);

            sfd.InitialDirectory = IVX.Live.MainForm.Framework.Environment.VideoSavePath;
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
                try
                {
                    int handle = m_videoExport.AddExport(vod.OCX_MssHostIp, vod.OCX_MssHostPort, vod.OCX_VideoPath, (uint)vod.OCX_StartSecond, (uint)vod.OCX_EndSecond, fileName);
                    if (handle > 0 && IsHandleCreated && OnVideoSaveStarted!=null)
                        OnVideoSaveStarted(handle, fileName);
                }
                catch (SDKCallException ex)
                {
                    MessageBoxEx.Show("视频【" + fileName + "】导出失败，[" + ex.ErrorCode + "]" + ex.Message, IVX.Live.MainForm.Framework.Environment.PROGRAM_NAME);
                }
            }
        }


        void m_videoExport_VideoDownloadStatusUpdate(DownloadInfo obj)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<DownloadInfo>(m_videoExport_VideoDownloadStatusUpdate), obj);
            }
            else
            {


                bool isfinished = false;
                int finishcode = 0;
                switch (obj.Status)
                {
                    case VideoDownloadStatus.NOUSE:
                        break;
                    case VideoDownloadStatus.Trans_Wait:
                        break;
                    case VideoDownloadStatus.Trans_Normal:
                        break;
                    case VideoDownloadStatus.Trans_Finish:
                        break;
                    case VideoDownloadStatus.Download_Wait:
                        break;
                    case VideoDownloadStatus.Download_Normal:
                        break;
                    case VideoDownloadStatus.Download_Finish:
                        isfinished = true;
                        finishcode = 0;
                        break;
                    case VideoDownloadStatus.Trans_Failed:
                        isfinished = true;
                        finishcode = (int)obj.ErrorCode;
                        if (finishcode == 0)
                            finishcode = int.MaxValue;
                        break;
                    case VideoDownloadStatus.Download_Failed:
                        isfinished = true;
                        finishcode = (int)obj.ErrorCode;
                        if (finishcode == 0)
                            finishcode = int.MaxValue;
                        break;
                    default:
                        break;
                }
                if (IsHandleCreated && isfinished && OnVideoSaveFinished != null)
                    OnVideoSaveFinished(obj.SessionId, obj.LocalSaveFilePath, finishcode);
                if(isfinished )
                {
                    if (finishcode == 0)
                        MessageBoxEx.Show("视频【" + obj.LocalSaveFilePath + "】导出完成。",IVX.Live.MainForm.Framework.Environment.PROGRAM_NAME);
                    else
                        MessageBoxEx.Show("视频【" + obj.LocalSaveFilePath + "】导出失败[" + finishcode + "]。",IVX.Live.MainForm.Framework.Environment.PROGRAM_NAME);
                }
            }
        }

        void m_videoExport_VideoDownloadProgressUpdate(DownloadInfo obj)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<DownloadInfo>(m_videoExport_VideoDownloadProgressUpdate), obj);
            }
            else
            {
                if (IsHandleCreated && OnVideoSaveProgress != null)
                    OnVideoSaveProgress(obj.SessionId, obj.LocalSaveFilePath, (int)obj.ComposeProgress);
            }
        }

        #endregion
        
        #region IObjectSafety implementations

        private const string _IID_IDispatch = "{00020400-0000-0000-C000-000000000046}";
        private const string _IID_IDispatchEx = "{a6ef9860-c720-11d0-9337-00a0c90dcaa9}";
        private const string _IID_IPersistStorage = "{0000010A-0000-0000-C000-000000000046}";
        private const string _IID_IPersistStream = "{00000109-0000-0000-C000-000000000046}";
        private const string _IID_IPersistPropertyBag = "{37D84F60-42CB-11CE-8135-00AA004BB851}";

        private const int INTERFACESAFE_FOR_UNTRUSTED_CALLER = 0x00000001;
        private const int INTERFACESAFE_FOR_UNTRUSTED_DATA = 0x00000002;
        private const int S_OK = 0;
        private const int E_FAIL = unchecked((int)0x80004005);
        private const int E_NOINTERFACE = unchecked((int)0x80004002);

        private bool _fSafeForScripting = true;
        private bool _fSafeForInitializing = true;

        //void IObjectSafety.GetInterfaceSafetyOptions(int riid, out int supportedOptions, out int enabledOptions)
        //{
        //    supportedOptions = 1;
        //    enabledOptions = 2;
        //}

        //void IObjectSafety.SetInterfaceSafetyOptions(int riid, int optionsSetMask, int enabledOptions)
        //{
        //    //throw new NotImplementedException();
        //}
        
        int IObjectSafety.GetInterfaceSafetyOptions(ref Guid riid, ref int pdwSupportedOptions, ref int pdwEnabledOptions)
        {
            int Rslt = E_FAIL;

            string strGUID = riid.ToString("B");
            pdwSupportedOptions = INTERFACESAFE_FOR_UNTRUSTED_CALLER | INTERFACESAFE_FOR_UNTRUSTED_DATA;
            switch (strGUID)
            {
                case _IID_IDispatch:
                case _IID_IDispatchEx:
                    Rslt = S_OK;
                    pdwEnabledOptions = 0;
                    if (_fSafeForScripting == true)
                        pdwEnabledOptions = INTERFACESAFE_FOR_UNTRUSTED_CALLER;
                    break;
                case _IID_IPersistStorage:
                case _IID_IPersistStream:
                case _IID_IPersistPropertyBag:
                    Rslt = S_OK;
                    pdwEnabledOptions = 0;
                    if (_fSafeForInitializing == true)
                        pdwEnabledOptions = INTERFACESAFE_FOR_UNTRUSTED_DATA;
                    break;
                default:
                    Rslt = E_NOINTERFACE;
                    break;
            }
            Rslt = S_OK;

            return Rslt;
        }

        int IObjectSafety.SetInterfaceSafetyOptions(ref Guid riid, int dwOptionSetMask, int dwEnabledOptions)
        {
            int Rslt = E_FAIL;
            string strGUID = riid.ToString("B");
            switch (strGUID)
            {
                case _IID_IDispatch:
                case _IID_IDispatchEx:
                    if (((dwEnabledOptions & dwOptionSetMask) == INTERFACESAFE_FOR_UNTRUSTED_CALLER) && (_fSafeForScripting == true))
                        Rslt = S_OK;
                    break;
                case _IID_IPersistStorage:
                case _IID_IPersistStream:
                case _IID_IPersistPropertyBag:
                    if (((dwEnabledOptions & dwOptionSetMask) == INTERFACESAFE_FOR_UNTRUSTED_DATA) && (_fSafeForInitializing == true))
                        Rslt = S_OK;
                    break;
                default:
                    Rslt = E_NOINTERFACE;

                    break;
            }
            Rslt = S_OK;
            return Rslt;
        }
        
        #endregion



        #region Event handlers
        public delegate void OnPictureSavedDelegate(string fileSavePath, int formType);
        public delegate void OnVideoSaveStartedDelegate(int handel, string fileSavePath);
        public delegate void OnVideoSaveProgressDelegate(int handel, string fileSavePath, int progress);
        public delegate void OnVideoSaveFinishedDelegate(int handel, string fileSavePath, int finishType);

        public event OnPictureSavedDelegate OnPictureSaved;
        public event OnVideoSaveStartedDelegate OnVideoSaveStarted;
        public event OnVideoSaveProgressDelegate OnVideoSaveProgress;
        public event OnVideoSaveFinishedDelegate OnVideoSaveFinished;

        #endregion

    }

    #region Other classes

    public enum LVErrorType
    {
        No_Error=0,
        Err_UnLogined = 1,
        Err_HaveLogined,
        Err_login,
        Err_DelTask,
        Err_EmptyTaskList,
        Err_NoSuchTask,
        Err_GetTaskList,
        Err_AddTask,
        Err_Clear,
    }


    #endregion
}
