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
    public class CrowdInfo
    {
        /// <summary>
        /// 所属组ID
        /// </summary>
        public ulong ID { get; set; }

        /// <summary>
        /// 监控点Code
        /// </summary>
        public string CameraID { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public UInt32 TimeSec { get; set; }

        /// <summary>
        /// 人群数量
        /// </summary>
        public UInt32 PeopleCount { get; set; }

        /// <summary>
        /// Area
        /// </summary>
        public UInt32 RegionArea { get; set; }

        public List<System.Drawing.Point> RegionPoints = new List<System.Drawing.Point>();

        public string HotImageURL { get; set; }

        public string DirectionImageURL { get; set; }

        public string OriginaloImageURL { get; set; }

    };
}
