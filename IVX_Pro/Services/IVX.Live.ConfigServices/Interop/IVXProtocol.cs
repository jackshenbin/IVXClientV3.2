using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.Serialization;
using MyLog4Net;
using IVX.DataModel;


namespace IVX.Live.ConfigServices.Interop
{
    #region 委托定义
    /// <summary>
    /// 网络连接断开回调函数
    /// </summary>
    /// <param name="userData">用户参数</param>
    public delegate void DelegateDisConnectd(UInt32 dwLoginID, UInt64 qwContext);

    public delegate void DelegateAnalyseStateChanged(UInt32 dwLoginID, UInt32 dwAnalysisID, E_IASSDK_REAL_ANALYZE_STATUS_TYPE eStatusType, UInt64 qwContext);

    public delegate void DelegatePlayStateChanged(UInt64 ubiStrmID, Int32 dwPlayState);
    #endregion

    public partial class IVXRealtimeProtocol
    {
        #region 事件
        /// <summary>
        /// 网络连接端口消息
        /// </summary>
        public event DelegateDisConnectd EventDisConnectd;

        public event DelegateAnalyseStateChanged EventAnalyseStateChanged;
        public event DelegatePlayStateChanged EventPlayStateChanged;
        #endregion

        #region 字段


        //private TFuncPDOMouseOptNtfCB m_pfuncMouseEventCb;


        //private TIasSdk_DisConnectNtfCB m_pFuncDisConnectNtf;

        //private TIasSdk_RTAnalysisStatusNtfCB m_pFuncRTAnalysisStatusNtf;
        //private TAdpsSdk_DisConnectNtfCB m_TAdpsSdk_DisConnectNtfCB;

        //private LPSTRMCALLBACK m_LPSTRMCALLBACK;

        //private TfuncPlayPosCB pfuncPlayPos ;

        private STATENOTECALLBACK m_STATENOTECALLBACK;

        #endregion

        public IVXRealtimeProtocol()
        {
            string oldCurrDir = Environment.CurrentDirectory;
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Environment.CurrentDirectory = System.IO.Directory.GetParent(assembly.Location).FullName;
            //if(IasSdk_Init())
            //{
            //    IasSdk_RegisterCallBack();
            //}
            //if(AdpsSdk_Init())
            //{
            //    AdpsSdk_RegisterCallBack();
            //}

            DIOInit();
            //RvodSdk_Init();
            Environment.CurrentDirectory = oldCurrDir;

        }

        //private void IAS_CheckError(uint errorCode)
        //{
        //    string error = IasSdk_GetErrorMsg(errorCode);
        //    if (errorCode > 0)
        //    {
        //        MyLog4Net.Container.Instance.Log.ErrorWithDebugView(string.Format("SDKCallException errorCode:{0},errorString:{1}", errorCode, error));
        //        if (string.IsNullOrEmpty(error))
        //        {
        //            Debug.Assert(false, "Failed but cannot get error message!");
        //        }
        //        throw new SDKCallException(errorCode, error);
        //    }
        //    else
        //    {
        //        Debug.Assert(false, "No valid error code!");
        //    }
        //}
        //private void Adps_GetError(uint errorCode)
        //{
        //    string error = AdpsSdk_GetErrorMsg(errorCode);
        //    if (errorCode > 0)
        //    {
        //        MyLog4Net.Container.Instance.Log.ErrorWithDebugView(string.Format("SDKCallException errorCode:{0},errorString:{1}", errorCode, error));
        //        if (string.IsNullOrEmpty(error))
        //        {
        //            Debug.Assert(false, "Failed but cannot get error message!");
        //        }
        //        throw new SDKCallException(errorCode, error);
        //    }
        //    else
        //    {
        //        Debug.Assert(false, "No valid error code!");
        //    }
        //}
        private void DIO_GetError(uint errorCode)
        {
            string error = ((IVXStreamIOSDKProtocol.eStreamIOErrorCode)errorCode).ToString();
            if (errorCode > 0)
            {
                MyLog4Net.Container.Instance.Log.ErrorWithDebugView(string.Format("SDKCallException errorCode:{0},errorString:{1}", errorCode, error));
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

        //private void RVOD_GetError()
        //{
        //    uint errorCode = RvodSdk_GetLastError();
        //    string error = RvodSdk_GetErrorMsg(errorCode);
        //    if (errorCode > 0)
        //    {
        //        MyLog4Net.Container.Instance.Log.ErrorWithDebugView(string.Format("SDKCallException errorCode:{0},errorString:{1}", errorCode, error));
        //        if (string.IsNullOrEmpty(error))
        //        {
        //            Debug.Assert(false, "Failed but cannot get error message!");
        //        }
        //        throw new SDKCallException(errorCode, error);
        //    }
        //    else
        //    {
        //        Debug.Assert(false, "No valid error code!");
        //    }
        //}

     
 

        #region 回调响应

        //private void OnPDOMouseOptNtfCB(Int32 hPdoHandle, E_PDO_MOUSE_EVENT eMouseEvent,
        //                                       UInt32 dwX, UInt32 dwY, UInt32 dwUserData)
        //{
        //    MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log,"OnPDOMouseOptNtfCB ");

        //}


        //private void OnTIasSdk_DisConnectNtfCB(UInt32 dwLoginID, UInt64 qwContext)
        //{
        //    MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "OnTIasSdk_DisConnectNtfCB dwLoginID: " + dwLoginID);
        //    if(EventDisConnectd!=null)
        //        EventDisConnectd(dwLoginID,qwContext);
        //}

        //private void OnTAdpsSdk_DisConnectNtfCB(UInt32 dwLoginID, UInt64 qwContext)
        //{
        //    MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "OnTAdpsSdk_DisConnectNtfCB dwLoginID:" + dwLoginID);
        //    if(EventDisConnectd!=null)
        //        EventDisConnectd(dwLoginID,qwContext);
        //}

        //private void OnTIasSdk_RTAnalysisStatusNtfCB(UInt32 dwLoginID, UInt32 dwAnalysisID, E_IASSDK_REAL_ANALYZE_STATUS_TYPE eStatusType, UInt64 qwContext)
        //{
        //    MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "OnTIasSdk_RTAnalysisStatusNtfCB dwLoginID:" + dwLoginID + ",dwAnalysisID:" + dwAnalysisID + ",eStatusType:" + eStatusType);
        //    if(EventAnalyseStateChanged!=null)
        //        EventAnalyseStateChanged(dwLoginID,dwAnalysisID,eStatusType,qwContext);
        //    MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "OnTIasSdk_RTAnalysisStatusNtfCB finsih");
        //}
        //private int OnLPSTRMCALLBACK(uint dwStrmId, uint dwDataType, IntPtr pData, int nDataLen, IntPtr pUserContext)
        //{
        //    Trace.WriteLine(string.Format("OnLPSTRMCALLBACK strmid:{0},datetype:{1},pdata:{2},datalen:{3}", dwStrmId, dwDataType, pData.ToInt32(), nDataLen));
        //    return 0; 
        //}

        //private void OnTfuncPlayPosCB(uint lVodHandle, uint dwPlayState, uint dwPlayProgress, uint dwCurPlayTime, uint dwUserData)
        //{
        //    Trace.WriteLine(string.Format("OnTfuncPlayPosCB strmid:{0},iEvent:{1}", lVodHandle, dwPlayProgress));
        //    if (EventPlayStateChanged != null && dwPlayProgress>0)
        //        EventPlayStateChanged(lVodHandle, 1);

        //}

        private int OnSTATENOTECALLBACK(int iEvent, UInt64 ubiStrm, int wParam, int lParam, IntPtr pParam)
        {
            Trace.WriteLine(string.Format("OnSTATENOTECALLBACK strmid:{0},iEvent:{1}", ubiStrm, iEvent));
            if (EventPlayStateChanged != null)
                EventPlayStateChanged(ubiStrm, iEvent);
            return 0;
        }


        #endregion
    }

}