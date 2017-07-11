using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using IVX.DataModel;
// using BOCOM.RealtimeProtocol.Model;
using DataModel;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MyLog4Net;

namespace IVX.Live.WSDataReceiveServices.Interop
{
    #region 基本结构体
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct TWebSrvCommuInitParam
    {
        internal ushort wListenPort;	//侦听端口
        internal ulong qwContext;

    };
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct TWebServiceParam
    {
        internal IntPtr pData;
        internal uint dwDataLen;
    };
    //通道信息
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct TWebSrvCommuInstParam
    {
        internal FuncWebSrvCommuRcvDataCB pfuncRcvDataCB;
        internal FuncWebSrvCommuRcvDataExCB pfuncRcvDataCBEx; 
        internal ulong qwContext;

    };
    internal enum EmWebsrvErrorCode
    {
        WEBSRV_COMMU_OK,
        WEBSRV_COMMU_FIND_INST_ERROR,
        WEBSRV_COMMU_BIND_ERROR,
        WEBSRV_COMMU_CREATE_THREAD_ERROR,
        WEBSRV_COMMU_INVALID_MSG_SEQ,
    };

    #endregion

    #region 回调定义
    [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
    internal unsafe delegate  void FuncWebSrvCommuRcvDataCB(int dwInstId, string strReqType, string strReqMsg, string strAttackData, uint qwContext);
    [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
    internal unsafe delegate void FuncWebSrvCommuRcvDataExCB(int dwInstId, IntPtr strReqType, IntPtr strReqMsg, IntPtr strAttackData, uint qwContext);

    #endregion

    internal partial class IVXWSSDKProtocol
    {


        /*=================================================================
        *功    能:	websrvice服务端初始化
        *参数说明:	[in]  tServerInitParam:      初始化参数

        *返回值:	成功返回WEBSRV_COMMU_OK，失败返回错误码
        =================================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 WebServiceCommuInit(TWebSrvCommuInitParam tServerInitParam);

        /*=================================================================
        *功    能:	websrvice服务端反初始化
        *参数说明:	[in]  

        *返回值:	成功返回MSGTC_OK，失败返回错误码
        =================================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 WebServiceCommuUnInit();//没有返回值

        /*=================================================================
        *功    能:	websrvice创建服务实例
        *参数说明:	[in]  tInstParam: 实例参数
                    [out] pdwInstId:  实例号

        *返回值:	成功返回WEBSRV_COMMU_OK，失败返回错误码
        =================================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 WebServiceCommuInstCreate(TWebSrvCommuInstParam tInstParam, out int pdwInstId);


        /*=================================================================
        *功    能:	websrvice发送回复消息
        *参数说明:	[in]  dwInstId: 收到请求时对应的实例号
                    [in]  pBuf:     发送的消息buf
                    [in]  dwBufLen: 发送的消息长度

        *返回值:	成功返回WEBSRV_COMMU_OK，失败返回错误码
        =================================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 WebServiceCommuSendData(int dwInstId, string pBuf, uint dwBufLen);

        /*=================================================================
        *功    能:	websrvice销毁服务实例
        *参数说明:	[in]  dwInstId: 实例号

        *返回值:	成功返回WEBSRV_COMMU_OK，失败返回错误码
        =================================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 WebServiceCommuInstDestory(int nInstId);
    }

    public delegate void DelegateDataReceived(string strReqType, byte[] strReqMsg);

    public partial class IVXWSProtocol
    {
        public event DelegateDataReceived EventDataReceived;

        FuncWebSrvCommuRcvDataExCB m_FuncWebSrvCommuRcvDataExCB;
        FuncWebSrvCommuRcvDataCB m_FuncWebSrvCommuRcvDataCB;

        void OnFuncWebSrvCommuRcvDataExCB(int dwInstId, IntPtr strReqType, IntPtr strReqMsg, IntPtr strAttackData, uint qwContext)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, 
                string.Format("IVXWSSDKProtocol OnFuncWebSrvCommuRcvDataCB dwInstId:{0},strReqType:{1},strReqMsg:{2},strAttackData:{3},qwContext:{4}"
                ,dwInstId,strReqType,strReqMsg,strAttackData,qwContext));
            TWebServiceParam type = (TWebServiceParam)Marshal.PtrToStructure(strReqType, typeof(TWebServiceParam));

            string reqtype = Marshal.PtrToStringAnsi(type.pData, (int)type.dwDataLen);
            TWebServiceParam msg = (TWebServiceParam)Marshal.PtrToStructure(strReqMsg, typeof(TWebServiceParam));
            byte[] b = new byte[msg.dwDataLen];
            Marshal.Copy(msg.pData, b, 0, (int)msg.dwDataLen);
            
            //string reqmsg = Marshal.PtrToStringAnsi(msg.pData, (int)msg.dwDataLen);
            if (EventDataReceived != null)
                EventDataReceived(reqtype, b);
            IVXWSSDKProtocol.WebServiceCommuSendData(dwInstId, "", 0);
        }
        void OnFuncWebSrvCommuRcvDataCB(int dwInstId, string strReqType, string strReqMsg, string strAttackData, uint qwContext)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, 
                string.Format("IVXWSSDKProtocol OnFuncWebSrvCommuRcvDataCB dwInstId:{0},strReqType:{1},strReqMsg:{2},strAttackData:{3},qwContext:{4}"
                ,dwInstId,strReqType,strReqMsg,strAttackData,qwContext));

            IVXWSSDKProtocol.WebServiceCommuSendData(dwInstId, "", 0);
        }

        int m_pdwInstId = -1;
        public bool Init(uint port)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXWSSDKProtocol WebServiceCommuInit port:" + port);
            Int32 retVal = IVXWSSDKProtocol.WebServiceCommuInit(new TWebSrvCommuInitParam() { qwContext = 0, wListenPort = (ushort)port });
            if (retVal > 0)
            {
                GetError((uint)retVal);
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXWSSDKProtocol WebServiceCommuInit ret:" + 0);

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXWSSDKProtocol WebServiceCommuInstCreate ");
            m_FuncWebSrvCommuRcvDataExCB = OnFuncWebSrvCommuRcvDataExCB;
            m_FuncWebSrvCommuRcvDataCB = OnFuncWebSrvCommuRcvDataCB;
            TWebSrvCommuInstParam tInstParam = new TWebSrvCommuInstParam()
            {
                pfuncRcvDataCB = null,//m_FuncWebSrvCommuRcvDataCB,
                 pfuncRcvDataCBEx = m_FuncWebSrvCommuRcvDataExCB,
                qwContext = 0,
            };
            m_pdwInstId = -1;
            retVal = IVXWSSDKProtocol.WebServiceCommuInstCreate(tInstParam, out m_pdwInstId);
            if (retVal == 0)
            {
                GetError((uint)EmWebsrvErrorCode.WEBSRV_COMMU_BIND_ERROR);
            }


            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXWSSDKProtocol WebServiceCommuInstCreate ret:" + 0 + " ,pdwInstId:" + m_pdwInstId);

            return retVal == 0;

        }

        public bool Uninit()
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXWSSDKProtocol WebServiceCommuInstDestory pdwInstId:" + m_pdwInstId);
            Int32 retVal = IVXWSSDKProtocol.WebServiceCommuInstDestory(m_pdwInstId);
            if (retVal > 0)
            {
                GetError((uint)retVal);
            }

            m_pdwInstId = -1;
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXWSSDKProtocol WebServiceCommuInstDestory ret:" + 0);
            
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXWSSDKProtocol WebServiceCommuUnInit ");
            retVal = IVXWSSDKProtocol.WebServiceCommuUnInit();
            if (retVal > 0)
            {
                GetError((uint)retVal);
            }


            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXWSSDKProtocol WebServiceCommuUnInit ret:" + 0);
            return retVal == 0;

        }
        public bool SendData(string data)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXWSSDKProtocol WebServiceCommuSendData data:" + data);
            Int32 retVal = IVXWSSDKProtocol.WebServiceCommuSendData(m_pdwInstId,data,(uint)data.Length);
            if (retVal > 0)
            {
                GetError((uint)retVal);
            }


            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXWSSDKProtocol WebServiceCommuSendData ret:" + 0 + " ,pdwInstId:" + m_pdwInstId);
            return retVal == 0;

        }
        private void GetError(uint errorCode)
        {
            string error = ((EmWebsrvErrorCode)errorCode).ToString();
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
    }
}
