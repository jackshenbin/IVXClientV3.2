using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using DataModel;

namespace IVX.DataModel
{
    /// <summary>
    /// 监控点位信息 
    /// </summary>
    [Serializable]
    public class PlatCameraDetailInfo : NotifyPropertyChangedModel
    {
        /// <summary>
        /// 接入厂商协议类型
        /// </summary>
        public E_VDA_NET_STORE_DEV_PROTOCOL_TYPE ProtocolType { get; set; }
        /// <summary>
        /// 连接IP地址
        /// </summary>
        public string PlatIP { get; set; }
        /// <summary>
        /// 连接端口号
        /// </summary>
        public UInt32 PlatPort { get; set; }
        /// <summary>
        /// 登录用户
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 网络存储设备ID
        /// </summary>
        public UInt32 PlatId { get; set; }


        public string ChannelID { get; set; }

        public string CameraName { get; set; }

        public string ReservedDescription { get; set; }

    };
}
