using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{

    /// <summary>
    /// 任务详细信息
    /// </summary>
    [Serializable]
    public class UploadTaskInfoV3_1
    {
        /// <summary>
        /// 任务ID
        /// </summary>
        public UInt32 TaskId { get; set; }
        public string OriFilePath { get; set; }
        public string MssServerIp { get; set; }
        public UInt32 MssServerPort { get; set; }
        public UInt64 SendSize { get; set; }
    };
}
