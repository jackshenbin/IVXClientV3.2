using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace IVX.Live.DataReceiveServices.Interop
{
    /// <summary>
    /// 统一包头
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct HEAD
    {
        /// <summary>
        /// 包头标志 协议头，固定为0x3C3C3C3C
        /// </summary>
        public byte flag1;
        /// <summary>
        /// <summary>
        /// 包头标志
        /// </summary>
        public byte flag2;
        /// <summary>
        /// 包头标志
        /// </summary>
        public byte flag3;
        /// <summary>
        /// <summary>
        /// 包头标志
        /// </summary>
        public byte flag4;
        /// 协议版本 如:0x01000001
        /// </summary>
        public UInt32 Version;
        /// <summary>
        /// 消息类型
        /// </summary>
        public UInt32 CommandId;
        /// <summary>
        /// 消息长度，2字节组成 
        /// </summary>
        public UInt32 MsgLength;
        /// <summary>
        /// 工作流号，由发起方生成，接收方按原值返回
        /// </summary>
        public UInt32 WorkflowId;
        /// <summary>
        /// 保留
        /// </summary>
        public UInt32 Reserve;
        /// <summary>
        /// crc校验 校验为全部数据累计和
        /// </summary>
        public UInt32 CheckCode;
    }
}
