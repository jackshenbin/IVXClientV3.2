using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.Service
{
    public class VideoExportService
    {
        private List<DownloadInfo> m_downloadList;

        private ExportListViewModel m_viewModel;
        private VideoExport m_videoExport;
        private int index = 0;
        private static VideoExportService m_instence;


        public List<DownloadInfo> DownloadList
        {
            get { return m_downloadList; }
            set { m_downloadList = value; }
        }

        private VideoExportService()
        {
            m_viewModel = new ExportListViewModel();
            m_videoExport = new VideoExport();
            m_videoExport.Init();
            m_downloadList = new List<DownloadInfo>();
            m_videoExport.VideoDownloadProgressUpdate += m_videoExport_VideoDownloadProgressUpdate;
            m_videoExport.VideoDownloadStatusUpdate += m_videoExport_VideoDownloadStatusUpdate;
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<AddVideoDownloadEvent>().Subscribe(OnAddVideoDownload, Microsoft.Practices.Prism.Events.ThreadOption.WinFormUIThread);
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<DelVideoDownloadEvent>().Subscribe(OnDelVideoDownload, Microsoft.Practices.Prism.Events.ThreadOption.WinFormUIThread);

        }
        public static VideoExportService Instence
        {
            get
            {
                if (m_instence == null)
                    m_instence = new VideoExportService();
                return m_instence;
            }
        }

        public void Clear()
        { 
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<AddVideoDownloadEvent>().Unsubscribe(OnAddVideoDownload);
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<DelVideoDownloadEvent>().Unsubscribe(OnDelVideoDownload);

        }

        public string GetNextInfo()
        {
            if(m_downloadList==null || m_downloadList.Count<=0)
                return "";
            if(m_downloadList.Count<=index)
                index =0;
            return  m_downloadList[index++].ToString();
        }

        private void OnAddVideoDownload(DownloadInfo info)
        {
            try
            {
                var mssinfo = m_viewModel.GetMssTaskInfo(info.VideoTaskUnitID);
                var taskinfo = m_viewModel.GetTaskInfo(info.VideoTaskUnitID);
                uint st = Convert.ToUInt32(info.StartTime.Subtract(taskinfo.StartTime).TotalSeconds);
                uint et = Convert.ToUInt32(info.EndTime.Subtract(taskinfo.StartTime).TotalSeconds);

                int handle = m_videoExport.AddExport(mssinfo.MssHostIp, mssinfo.MssHostPort, mssinfo.VideoPath, st, et, info.LocalSaveFilePath);

                info.SessionId = handle;

                m_downloadList.Add((DownloadInfo)info.Clone());
            }
            catch (SDKCallException ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("导出文件失败["+ex.ErrorCode+"]:"+ ex.Message);
            }
        }

        private void OnDelVideoDownload(DownloadInfo info)
        {
            int index = m_downloadList.FindIndex(item=>item.SessionId == info.SessionId);
            if(index>=0)
            {
                m_videoExport.DelExport(info.SessionId);
                m_downloadList.RemoveAt(index);
            }
        }

        void m_videoExport_VideoDownloadStatusUpdate(DownloadInfo obj)
        {
            int index = m_downloadList.FindIndex(item => item.SessionId == obj.SessionId);
            if (index >= 0)
            {
                m_downloadList[index].Status = obj.Status;
                m_downloadList[index].ErrorCode = obj.ErrorCode;

                WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<VideoDownloadProgressUpdateEvent>().Publish(m_downloadList[index]);

                //if (obj.Status == VideoDownloadStatus.Download_Finish)
                //    DevComponents.DotNetBar.MessageBoxEx.Show("下载完成：" + obj.LocalSaveFilePath);


            }
        }

        void m_videoExport_VideoDownloadProgressUpdate(DownloadInfo obj)
        {
            int index = m_downloadList.FindIndex(item => item.SessionId == obj.SessionId);
            if (index >= 0)
            {
                m_downloadList[index].ComposeProgress = obj.ComposeProgress;
                m_downloadList[index].ConversionProgress = obj.ConversionProgress;
                m_downloadList[index].ExportProgress = obj.ExportProgress;

                WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<VideoDownloadStatusUpdateEvent>().Publish(m_downloadList[index]);

            }
        }

    }
}
