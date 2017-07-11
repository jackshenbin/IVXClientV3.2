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

namespace IVX.Live.Brief.OCX
{
    [Guid("A9D034E4-6D6C-4819-B9F9-E0070D36D192"),
    ProgId("BriefOCX"),
    ClassInterface(ClassInterfaceType.None),
    ComDefaultInterface(typeof(IBriefOCX)),
    ComSourceInterfaces(typeof(IBriefOCXEvents)),
    ComVisible(true)]
    public partial class BriefOCX : UserControl, IBriefOCX, IObjectSafety// , IEventAggregatorSubscriber
    {

        #region Fields

        bool m_isLogin = false;
        

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
        bool ocx_BriefSdk_Init()
        {
            string initparam = "<root><PlayBufPoolSizeK>204800</PlayBufPoolSizeK></root>";
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefSdk_Init initparam:" + initparam);
            string oldCurrDir = Environment.CurrentDirectory;
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Environment.CurrentDirectory = System.IO.Directory.GetParent(assembly.Location).FullName;
            uint retVal = axbriefocx1.ocx_BriefVoddcInit(initparam);
            string msg = "";
            if(retVal !=0)
             msg =  axbriefocx1.ocx_GetErrorDiscription(retVal);
            Environment.CurrentDirectory = oldCurrDir;
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefSdk_Init retVal:" + retVal + ",msg:" + msg);
            return retVal == 0;
        }
        int ocx_BriefSdk_UnInit()
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefSdk_UnInit ");
            axbriefocx1.ocx_BriefVoddcUnInit();
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefSdk_UnInit retVal:" + 0);
            return 0;
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

        public BriefOCX()
        {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("BriefOCX");

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


        public string CreateBrief(string hostIP, uint hostPort, string briefIndexPath, string briefDatePath,int videoLenth,int adjusttime)
        {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("BriefOCX CreateBrief hostIP:{0},hostPort:{1},briefIndexPath:{2},briefDatePath:{3},videoLenth:{4}",hostIP,hostPort,briefIndexPath,briefDatePath,videoLenth));

            ocx_BriefSdk_Init();
            IVX.Live.MainForm.Framework.Environment.BriefPlayControler = this.axbriefocx1;

            IVX.Live.MainForm.View.ucPlayBrief brief = new MainForm.View.ucPlayBrief();
            brief.IsPlay4OCX = true;
            brief.OCX_BriefDataPath = briefDatePath;
            brief.OCX_BriefIndexPath = briefIndexPath;
            brief.OCX_MssHostIp = hostIP;
            brief.OCX_MssHostPort = hostPort;
            brief.OCX_TaskName = " ";
            if (videoLenth > 0)
                brief.OCX_SrcVideoTotleTime = videoLenth;
            if (adjusttime>0)
                brief.OCX_AdjustTime = DataModel.Common.ConvertLinuxTime((uint)adjusttime);

            brief.MoveObjectDClick4OCX += brief_MoveObjectDClick4OCX;
            brief.PictureSaved4OCX += brief_PictureSaved4OCX;
            this.panelEx1.Controls.Add(brief);
            brief.Dock = DockStyle.Fill;
            //brief.Task = new TaskInfoV3_1() { TaskId = 100, TaskName = "xxxxxx.mp4", StartTime = new DateTime(), EndTime = new DateTime().AddSeconds(100), };
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("BriefOCX Clear No_Error");
            return MakeRetMsg(LVErrorType.No_Error, "");

        }


        public string VdaSetSavePictureAndVideoDefaultPath(string path)
        {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("BriefOCX  VdaSetSavePictureAndVideoDefaultPath path:" + path);

            try
            {
                IVX.Live.MainForm.Framework.Environment.PictureSavePath = path;
                IVX.Live.MainForm.Framework.Environment.VideoSavePath = path;
                MyLog4Net.Container.Instance.Log.DebugWithDebugView("BriefOCX VdaSetSavePictureAndVideoDefaultPath No_Error");
                return MakeRetMsg(0, "");


            }
            catch (SDKCallException ex)
            {
                MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "BriefOCX  VdaSetSavePictureAndVideoDefaultPath error :ret=[" + ex.ErrorCode + "]" + ex.Message);
                return MakeRetMsg(LVErrorType.Err_UnLogined, ex.Message);
            }

        }


        public string Clear()
        {
            try
            {
                
                MyLog4Net.Container.Instance.Log.DebugWithDebugView("BriefOCX Clear");

                //IVX.Live.Crowd.Framework.Container.Instance.LogOut();
                if (panelEx1.Controls.Count > 0) 
                {
                    IVX.Live.MainForm.View.ucPlayBrief brief = panelEx1.Controls[0] as MainForm.View.ucPlayBrief;
                    if (brief != null)
                    {
                        brief.Clear();
                        this.panelEx1.Controls.Clear();
                    }
                }
                IVX.Live.MainForm.Framework.Environment.BriefPlayControler = null;
                ocx_BriefSdk_UnInit();
            }
            catch (SDKCallException ex)
            {
                MyLog4Net.Container.Instance.Log.DebugWithDebugView("BriefOCX Clear error:" + ex.ToString());

                m_isLogin = false;
                return MakeRetMsg(LVErrorType.Err_Clear, "清理出错");
            }

            MyLog4Net.Container.Instance.Log.DebugWithDebugView("BriefOCX Clear No_Error");
            return MakeRetMsg(LVErrorType.No_Error, "");
        }


        void brief_MoveObjectDClick4OCX(BriefMoveobjInfo obj)
        {
            if (IsHandleCreated && OnBriefObjectPlayBackNote != null)
                OnBriefObjectPlayBackNote(obj.MoveObjID, Convert.ToInt32(obj.MoveObjType), Convert.ToInt32(obj.MoveObjColor), Convert.ToInt32(obj.BeginTimeS.Subtract(new DateTime()).TotalSeconds), Convert.ToInt32(obj.EndTimeS.Subtract(new DateTime()).TotalSeconds));
        }
        void brief_PictureSaved4OCX(string obj)
        {
            if (IsHandleCreated && OnPictureSaved != null)
                OnPictureSaved(obj, 0);
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
        public delegate void OnBriefObjectPlayBackNoteDelegate(uint MoveObjID, int MoveObjType, int MoveObjColor, int BeginTimeS, int EndTimeS);
        public delegate void OnPictureSavedDelegate(string fileSavePath, int formType);

        public event OnBriefObjectPlayBackNoteDelegate OnBriefObjectPlayBackNote;
        public event OnPictureSavedDelegate OnPictureSaved;

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
