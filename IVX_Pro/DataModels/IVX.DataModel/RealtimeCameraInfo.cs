using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using DataModel;

namespace IVX.DataModel
{
    /// <summary>
    /// 全数据监控点位信息，crowd用 
    /// </summary>
    [Serializable]
    public class RealtimeCameraInfo 
    {
        /// <summary>
        /// 所属组ID
        /// </summary>
        public uint GroupID { get; set; }

        /// <summary>
        /// 监控点名
        /// </summary>
        public string CameraName { get; set; }

        /// <summary>
        /// 监控点Code
        /// </summary>
        public string CameraID { get; set; }



        /// <summary>
        /// 存储设备点位标示
        /// </summary>
        public string CameraChannelID { get; set; }

        /// <summary>
        /// 地理位置坐标	X
        /// </summary>
        public float PosCoordX { get; set; }

        /// <summary>
        /// 地理位置坐标	Y
        /// </summary>
        public float PosCoordY { get; set; }

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


        public override string ToString()
        {
            return CameraID;
        }
    };
}
