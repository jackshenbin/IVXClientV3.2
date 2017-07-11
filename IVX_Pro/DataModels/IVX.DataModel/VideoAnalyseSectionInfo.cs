using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    /// <summary>
    /// 视频分析信息
    /// </summary>
    public class VideoAnalyseSectionInfo
    {
        /// <summary>
        /// 像机编号
        /// </summary>
        public UInt32 CameraID { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 算法类型
        /// </summary>
        public E_VIDEO_ANALYZE_TYPE AnalyseType { get; set; }
    };
}
