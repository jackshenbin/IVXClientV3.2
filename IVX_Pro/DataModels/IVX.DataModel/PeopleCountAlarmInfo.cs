using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using DataModel;

namespace IVX.DataModel
{
    /// <summary>
    /// behaviorInfo 
    /// </summary>
    [Serializable]
    public class PeopleCountAlarmInfo
    {

        public string CameraID { get; set; }
        public uint DetectRegionID { get; set; }
        public uint BehaviorType { get; set; }
        public uint ObjectTotalNum { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}
