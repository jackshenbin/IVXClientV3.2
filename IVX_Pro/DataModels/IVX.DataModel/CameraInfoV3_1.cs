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
    public class CameraInfoV3_1 : ICloneable
    {

        /// <summary>
        /// 监控点ID
        /// </summary>
        public uint ID { get; set; }

        /// <summary>
        /// 监控点名
        /// </summary>
        public string CameraName { get; set; }

        /// <summary>
        /// 监控点Code
        /// </summary>
        public string CameraID { get; set; }

        /// <summary>
        /// 关联的网络设备ID
        /// </summary>
        public uint VideoSupplierDeviceID { get; set; }

        /// <summary>
        /// 存储设备点位标示
        /// </summary>
        public string VideoSupplierChannelID { get; set; }

        /// <summary>
        /// 地理位置坐标	X
        /// </summary>
        public float PosCoordX { get; set; }

        /// <summary>
        /// 地理位置坐标	Y
        /// </summary>
        public float PosCoordY { get; set; }

        public VideoSupplierDeviceInfo VideoSupplier { get; set; }
        public object Clone()
        {
            CameraInfoV3_1 newCamera = new CameraInfoV3_1()
            {
                ID = this.ID,
                CameraName = this.CameraName,
                VideoSupplierChannelID = this.VideoSupplierChannelID,
                VideoSupplierDeviceID = this.VideoSupplierDeviceID,
                PosCoordX = this.PosCoordX,
                PosCoordY = this.PosCoordY,
                CameraID = this.CameraID,
                VideoSupplier = new VideoSupplierDeviceInfo(),
            };
            newCamera.VideoSupplier = (VideoSupplierDeviceInfo)this.VideoSupplier.Clone();
            return newCamera;
        }

        public SearchItemV3_1 ToSearchItem()
        {

            return new SearchItemV3_1() 
            {
                CameraID = this.CameraID,
                CameraName = this.CameraName+"["+this.CameraID+"]",
                TaskId = 0,
                TaskName = this.CameraName, 
                SearchHandle = 0, 
                AdjustTime = new DateTime(), 
            };
        }
    };
}
