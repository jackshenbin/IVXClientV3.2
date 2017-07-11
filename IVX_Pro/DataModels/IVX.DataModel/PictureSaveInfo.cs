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
    public class PictureSaveInfo
    {
        /// <summary>
        /// 任务单元ID
        /// </summary>
        public UInt32 VideoTaskUnitID { get; set; }

        public int SessionId { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 对应的分析结果记录
        /// </summary>
        public SearchResultRecord ResultRecord{ get; set; }

        /// <summary>
        /// 本地保存文件路径
        /// </summary>
        public string LocalSaveFilePath { get; set; }


        public E_PICTURE_FORM_TYPE FormType { get; set; }
    };
}
