using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace IVX.Live.WSDataReceiveServices
{
    /// <summary>
    /// 统一包头
    /// </summary>
    [Serializable]
    public class Head
    {
        public string Version { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public UInt32 MsgCmd { get; set; }
        public string Context { get; set; }
        /// <summary>
        /// 工作流号，由发起方生成，接收方按原值返回
        /// </summary>
        public string Sequence { get; set; }
    }
}
