using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace IVX.DataModel
{
    /// <summary>
    /// 中心服务器单元基本信息
    /// </summary>
    [Serializable]
    public class ServerInfoV3_1 : ICloneable
    {
        /// <summary>
        /// 服务器ID
        /// </summary>
        public UInt32 ServerId { get; set; }
        /// <summary>
        /// 服务器类型，见vdacomm.h中E_VDA_SERVER_TYPE定义
        /// </summary>
        public E_VDA_SERVER_TYPE ServerType { get; set; }
        /// <summary>
        /// 服务器IP地址
        /// </summary>
        public string ServerIP { get; set; }
        /// <summary>
        /// 服务器端口号
        /// </summary>
        public UInt32 ServerPort { get; set; }
        /// <summary>
        /// 服务器状态（0停用，1启用，2删除）
        /// </summary>
        public E_VDA_SERVER_STATUS Status { get; set; }

        public string Description { get; set; }


        public object Clone()
        {
            return this;
        }
    };
}
