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

namespace IVX.Live.MainForm.Service
{
    public class VideoExport
    {
        #region 事件
        public event Action<DownloadInfo> VideoDownloadProgressUpdate;

        public event Action<DownloadInfo> VideoDownloadStatusUpdate;
        #endregion

        #region 私有变量
        private Dictionary<int, string> m_downloadFileList = new Dictionary<int, string>();
        #endregion

        #region 属性

        #endregion

        #region 构造
        public VideoExport()
        {
        }
        #endregion

        #region 公共函数
        public bool Init()
        {
            if (null != Framework.Environment.VODPlayControler)
            {
                Framework.Environment.VODPlayControler.EventDwonloadVedioStatus
                    += VODPlayControler_EventDwonloadVedioStatus;
                Framework.Environment.VODPlayControler.TfuncDownLoadVideoPosCB
                    += VODPlayControler_TfuncDownLoadVideoPosCB;
                Framework.Environment.VODPlayControler.TfuncDownLoadVideoStatusCB
                    += VODPlayControler_TfuncDownLoadVideoStatusCB;
            }
            return true;
        }


        public void UnInit()
        {
            if (null != Framework.Environment.VODPlayControler)
            {
                Framework.Environment.VODPlayControler.EventDwonloadVedioStatus
                    -= VODPlayControler_EventDwonloadVedioStatus;
                Framework.Environment.VODPlayControler.TfuncDownLoadVideoPosCB
                    -= VODPlayControler_TfuncDownLoadVideoPosCB;
                Framework.Environment.VODPlayControler.TfuncDownLoadVideoStatusCB
                    -= VODPlayControler_TfuncDownLoadVideoStatusCB;
            }

        }

        public int AddExport(string mssIP, uint mssPort, string mssPath, uint startTime, uint endTime,string savefilepath)
        {
            int isallfile = 0;
            if (startTime == 0 && endTime == 0)
                isallfile = 1;
            return ocx_VodSdk_DwonloadVideoFile(mssIP, (ushort)mssPort, isallfile, startTime, endTime, mssPath, savefilepath);
        }

        public int DelExport(int downloadHandle)
        {                 
               return ocx_VodSdk_StopDownloadVideo(downloadHandle);
        }

        #endregion

        #region EXPORTOCX

        string ocx_VodSdk_GetErrorMsg(uint uErrorCode)
        {
            return Framework.Environment.VODPlayControler.ocx_VodSdk_GetErrorMsg(uErrorCode);
        }
        uint ocx_VodSdk_GetLastError()
        {
            return Framework.Environment.VODPlayControler.ocx_VodSdk_GetLastError();
        }

        int ocx_VodSdk_DwonloadVideoFile(string pchServerIP, ushort wServerPort, int bIsDownloadAllFile, uint dwStartTime, uint dwEndTime, string szFilePath, string szLocalSaveFilePath)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_DwonloadVideoFile pchServerIP:{0}"
                + ",wServerPort:{1}"
                + ",bIsDownloadAllFile:{2}"
                + ",dwStartTime:{3}"
                + ",dwEndTime:{4}"
                + ",szFilePath:{5}"
                + ",szLocalSaveFilePath:{6}"
                , pchServerIP
                , wServerPort
                , bIsDownloadAllFile
                , dwStartTime
                , dwEndTime
                , szFilePath
                , szLocalSaveFilePath);

            int downloadHandle = Framework.Environment.VODPlayControler.ocx_VodSdk_DwonloadVideoFile(pchServerIP, wServerPort, bIsDownloadAllFile, dwStartTime, dwEndTime, szFilePath, szLocalSaveFilePath);
            if (downloadHandle <= 0)
                GetError();
            m_downloadFileList.Add(downloadHandle, szLocalSaveFilePath);
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_DwonloadVideoFile retVal m_downloadHandle:{0}", downloadHandle);
            return downloadHandle;
        }
        int ocx_VodSdk_GetDownloadVideoProc(int lDldHandle)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_GetDownloadVideoProc lDldHandle:{0}", lDldHandle);
            string xml = Framework.Environment.VODPlayControler.ocx_VodSdk_GetDownloadVideoProc(lDldHandle);
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(xml);
            int retVal = Convert.ToInt32(doc.SelectSingleNode("//result/retcode").InnerText);
            int progress = Convert.ToInt32(doc.SelectSingleNode("//result/progress").InnerText);

            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_GetDownloadVideoProc retVal :{0},progress:{1}", retVal, progress);
            return progress;

        }
        int ocx_VodSdk_StopDownloadVideo(int lDldHandle)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_StopDownloadVideo lDldHandle:{0}", lDldHandle);
            int retVal = Framework.Environment.VODPlayControler.ocx_VodSdk_StopDownloadVideo(lDldHandle);

            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_StopDownloadVideo retVal :{0}", retVal);
            return retVal;
        }





        void VODPlayControler_TfuncDownLoadVideoStatusCB(object sender, AxvodocxLib._DvodocxEvents_TfuncDownLoadVideoStatusCBEvent e)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_TfuncDownLoadVideoStatusCB dwResult:{0},dwDownLoadStatus:{1},dwUserData:{2},lDlHandle:{3}", e.dwResult, e.dwDownLoadStatus, e.dwUserData, e.lDlHandle);
            DoDownLoadVideoStatusCB(e.lDlHandle, e.dwDownLoadStatus,e.dwResult);
        }
        void DoDownLoadVideoStatusCB(int lDlHandle, uint dwDownLoadStatus,uint errorcode)
        {
            if (VideoDownloadStatusUpdate != null)
            {
                if ((VideoDownloadStatus)dwDownLoadStatus == VideoDownloadStatus.Trans_Failed
                    || (VideoDownloadStatus)dwDownLoadStatus == VideoDownloadStatus.Download_Failed
                    || (VideoDownloadStatus)dwDownLoadStatus == VideoDownloadStatus.Download_Finish)
                    ocx_VodSdk_StopDownloadVideo(lDlHandle);
                 string filename = m_downloadFileList.ContainsKey(lDlHandle) ? m_downloadFileList[lDlHandle] : "";
                 DownloadInfo info = new DownloadInfo() { SessionId = lDlHandle, Status = (VideoDownloadStatus)dwDownLoadStatus, LocalSaveFilePath = filename ,};
                VideoDownloadStatusUpdate(info);
            }
        }

        void VODPlayControler_TfuncDownLoadVideoPosCB(object sender, AxvodocxLib._DvodocxEvents_TfuncDownLoadVideoPosCBEvent e)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_TfuncDownLoadVideoPosCB lDlHandle:{0},dwTransProgress:{1},dwExportProgress:{2},dwCombineProgress:{3},dwUserData:{4}", e.lDlHandle, e.dwTransProgress, e.dwExportProgress, e.dwCombineProgress, e.dwUserData);
            DoDownLoadVideoPosCB(e.lDlHandle, e.dwTransProgress, e.dwExportProgress, e.dwCombineProgress);
        }
        void DoDownLoadVideoPosCB(int lDlHandle, uint dwTransProgress, uint dwExportProgress, uint dwCombineProgress)
        {         

            if (VideoDownloadProgressUpdate != null)
            {
                string filename = m_downloadFileList.ContainsKey(lDlHandle) ? m_downloadFileList[lDlHandle] : "";

                DownloadInfo info = new DownloadInfo() { SessionId = lDlHandle, ExportProgress = dwExportProgress, ConversionProgress = dwTransProgress, ComposeProgress = dwCombineProgress, LocalSaveFilePath = filename, };
                VideoDownloadProgressUpdate(info);
            }

        }


        void VODPlayControler_EventDwonloadVedioStatus(object sender, AxvodocxLib._DvodocxEvents_EventDwonloadVedioStatusEvent e)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_EventDwonloadVedioStatus dwResult:{0},dwDownLoadStatus:{1},dwUserData:{2},lDlHandle:{3}", e.dwResult, e.dwDownLoadStatus, e.dwUserData, e.lDlHandle);
            DoDownLoadVideoStatusCB(e.lDlHandle, e.dwDownLoadStatus,e.dwResult);
        }
        private void GetError()
        {
            uint errorCode = Framework.Environment.VODPlayControler.ocx_VodSdk_GetLastError();
            string error = Framework.Environment.VODPlayControler.ocx_VodSdk_GetErrorMsg(errorCode);
            if (errorCode > 0 )
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

        #endregion

        #region 事件响应

        #endregion

    }


}
