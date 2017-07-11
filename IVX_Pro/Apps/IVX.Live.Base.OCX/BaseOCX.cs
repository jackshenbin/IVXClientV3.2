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

namespace IVX.Live.Base.OCX
{
    [Guid("5D2611E1-E7F9-4BC0-B5D0-98703059B9AD"),
    ProgId("BaseOCX"),
    ClassInterface(ClassInterfaceType.None),
    ComDefaultInterface(typeof(IBaseOCX)),
    ComSourceInterfaces(typeof(IBaseOCXEvents)),
    ComVisible(true)]
    public partial class BaseOCX : UserControl, IBaseOCX, IObjectSafety// , IEventAggregatorSubscriber
    {

        #region Fields

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

        public BaseOCX()
        {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("BaseOCX");

            InitializeComponent();
            //StyleManager.ColorTint = Color.Transparent;

        }
       
        public string GetVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string fileVersion = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
            return MakeRetMsg(LVErrorType.No_Error, "", fileVersion);
        }


        public string Init()
        {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("BaseOCX Init");

            ocx_VodSdk_Init();
            IVX.Live.MainForm.Framework.Environment.VODPlayControler = this.axvodocx1;

            m_videoExport = new VideoExport();
            m_videoExport.Init();
            m_videoExport.VideoDownloadProgressUpdate += m_videoExport_VideoDownloadProgressUpdate;
            m_videoExport.VideoDownloadStatusUpdate += m_videoExport_VideoDownloadStatusUpdate;

            MyLog4Net.Container.Instance.Log.DebugWithDebugView("BaseOCX Init No_Error");
            return MakeRetMsg(LVErrorType.No_Error, "");

        }
        public string StartVideoSave(string hostIP, uint hostPort, string videoPath, int startSecond, int endSecond, string savefilepath)
        {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("BaseOCX  StartVideoSave hostIP:{0},hostPort:{1},videoPath:{2},startSecond:{3},endSecond:{4},savefilepath:{5}" 
                ,hostIP,hostPort,videoPath,startSecond,endSecond,savefilepath));

            try
            {
                int handle = m_videoExport.AddExport(hostIP, hostPort, videoPath, (uint)startSecond, (uint)endSecond, savefilepath);
                if (handle > 0)
                {
                    MyLog4Net.Container.Instance.Log.DebugWithDebugView("BaseOCX  StartVideoSave error handle:" + handle);

                    return MakeRetMsg(LVErrorType.No_Error, "", handle.ToString());
                }
                else
                {
                    MyLog4Net.Container.Instance.Log.DebugWithDebugView("BaseOCX  StartVideoSave error handle=0" );

                    return MakeRetMsg(LVErrorType.Err_ExportVideo, "导出失败,handle=0");

                }
            }
            catch (SDKCallException ex)
            {
                MyLog4Net.Container.Instance.Log.DebugWithDebugView("BaseOCX  StartVideoSave error :"+ex);

                return MakeRetMsg(LVErrorType.Err_ExportVideo, "导出失败，[" + ex.ErrorCode + "]" + ex.Message);

                //MessageBoxEx.Show("视频【" + fileName + "】导出失败，[" + ex.ErrorCode + "]" + ex.Message, IVX.Live.MainForm.Framework.Environment.PROGRAM_NAME);
            }
        }

        public string StopVideoSave(int handle)
        {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("BaseOCX  StopVideoSave handle:" + handle);

            m_videoExport.DelExport(handle);
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("BaseOCX  StopVideoSave ret");
            return MakeRetMsg(LVErrorType.No_Error, "");
        }


        public string VdaSetSavePictureAndVideoDefaultPath(string path)
        {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("BaseOCX  VdaSetSavePictureAndVideoDefaultPath path:" + path);

            try
            {
                IVX.Live.MainForm.Framework.Environment.PictureSavePath = path;
                IVX.Live.MainForm.Framework.Environment.VideoSavePath = path;
                MyLog4Net.Container.Instance.Log.DebugWithDebugView("BaseOCX VdaSetSavePictureAndVideoDefaultPath No_Error");
                return MakeRetMsg(0, "");


            }
            catch (SDKCallException ex)
            {
                MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "BaseOCX  VdaSetSavePictureAndVideoDefaultPath error :ret=[" + ex.ErrorCode + "]" + ex.Message);
                return MakeRetMsg(LVErrorType.Err_UnLogined, ex.Message);
            }

        }


        public string Clear()
        {
            try
            {

                MyLog4Net.Container.Instance.Log.DebugWithDebugView("BaseOCX Clear");
                if(m_videoExport!=null)
                    m_videoExport.UnInit();
                IVX.Live.MainForm.Framework.Environment.VODPlayControler = null;
                ocx_VodSdk_UnInit();
            }
            catch (SDKCallException ex)
            {
                MyLog4Net.Container.Instance.Log.DebugWithDebugView("BaseOCX Clear error:" + ex.ToString());

                return MakeRetMsg(LVErrorType.Err_Clear, "清理出错");
            }
            exit = false;
            new System.Threading.Thread(sleep).Start();
            while (!exit)
            { System.Threading.Thread.Sleep(20); }
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("BaseOCX Clear No_Error");
            return MakeRetMsg(LVErrorType.No_Error, "");
        }
       static bool exit = false;
        void sleep()
        { 
            System.Threading.Thread.Sleep(5000);
            exit = true;
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
                //if(isfinished )
                //{
                //    if (finishcode == 0)
                //        MessageBoxEx.Show("视频【" + obj.LocalSaveFilePath + "】导出完成。",IVX.Live.MainForm.Framework.Environment.PROGRAM_NAME);
                //    else
                //        MessageBoxEx.Show("视频【" + obj.LocalSaveFilePath + "】导出失败[" + finishcode + "]。",IVX.Live.MainForm.Framework.Environment.PROGRAM_NAME);
                //}
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
        public delegate void OnVideoSaveProgressDelegate(int handel, string fileSavePath, int progress);
        public delegate void OnVideoSaveFinishedDelegate(int handel, string fileSavePath, int finishType);

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
        Err_ExportVideo,
    }


    #endregion
}
