using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    public class TrafficFluxHistoryInfo
    {
    public string CameraID{ get; set; }
    // 统计时间
    public UInt32 StatiIctisTime { get; set;}
    public UInt32 RoadWayNum { get; set; }
    public UInt32 TrafficFluxBig { get; set; }
    public UInt32 TrafficFluxMiddle { get; set; }
    public UInt32 TrafficFluxSmall { get; set; }
    public UInt32 TrafficFlux { get; set; }
    // 平均车速
    public UInt32 AvgVehiSpeed { get; set; }
    // 平均车道占用率
    public UInt32 AvgOccupyRatio { get; set; }
    // 队列长度
    public UInt32 QueueLen { get; set; }
    public UInt32 AvgVehiDistance { get; set; }

    }
}
