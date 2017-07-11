using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    public class TrafficFluxStatisticInfo
    {
        public string CameraID { get; set; }
        // 统计时间
        public string TimeTag { get; set; }
        public UInt32 TrafficFlux { get; set; }
    }
}
