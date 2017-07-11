using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    /// <summary>
    /// 按任务单元下载信息
    /// </summary>
    [Serializable]
    public class DownloadInfo : ICloneable
    {
        /// <summary>
        /// 任务单元ID
        /// </summary>
        public UInt32 VideoTaskUnitID { get; set; }

        public int SessionId { get; set; }

        public uint ConversionProgress{get;set;}
        
        public uint ExportProgress {get;set;}

        public uint ComposeProgress { get; set; }

        //public uint TotalProgress { get; set;}

        public VideoDownloadStatus Status
        {
            get;
            set;
        }

        public uint ErrorCode { get; set; }

        /// <summary>
        /// 是否下载整个文件，如果整个文件，后续的时间段信息无效
        /// </summary>
        public bool IsDownloadAllFile { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 本地保存文件路径
        /// </summary>
        public string LocalSaveFilePath { get; set; }

        public object Clone()
        {
            DownloadInfo newinfo = new DownloadInfo()
            {
                ComposeProgress = this.ComposeProgress,
                ConversionProgress = this.ConversionProgress,
                ExportProgress = this.ExportProgress,
                Status = this.Status,
                SessionId = this.SessionId,
                VideoTaskUnitID = this.VideoTaskUnitID,
                LocalSaveFilePath = this.LocalSaveFilePath,
                EndTime = this.EndTime,
                ErrorCode = this.ErrorCode,
                IsDownloadAllFile = this.IsDownloadAllFile,
                StartTime = this.StartTime,
            };
            return newinfo;
        }

        public override string ToString()
        {
            string stat = DataModel.Constant.DownloadStatusInfos.Single(item => item.DownloadStatus == Status).Name;
            string file = System.IO.Path.GetFileName(LocalSaveFilePath);
            if (file.Length > 20) { file = file.Remove(15, file.Length - 19); file = file.Insert(15, "..."); }
            string str = string.Format("导出文件：{0}，进度：{1}%，状态{2}",file,ComposeProgress/10,stat);
            return str;
        }
    };
}
