using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{

    public class TransEvnetInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public UInt32 EventID { get; set; }
        /// <summary>
        /// 任务ID
        /// </summary>
        public UInt32 TaskID { get; set; }

        /// <summary>
        /// 合图方式
        /// </summary>
        public UInt32 MergeStyle { get; set; }
        /// <summary>
        /// 存储方式
        /// </summary>
        public E_TRANCE_STORE_TYPE StoreStyle { get; set; }
        /// <summary>
        /// 事件接收IP
        /// </summary>
        public string ReceiveIp { get; set; }
        /// <summary>
        /// 事件接收端口
        /// </summary>
        public UInt32 ReceivePort { get; set; }
        /// <summary>
        /// 转发协议
        /// </summary>
        public E_TRANS_PROTOCOL_TYPE ProtocolType { get; set; }
        public E_VIDEO_ANALYZE_TYPE AnalyseType { get; set; }
    }

}
