using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{

    [Serializable]
    public class TaskBriefMSSInfoV3_1
    {
        public UInt32 TaskId { get; set; }
        public string MssHostIp { get; set; }
        public UInt32 MssHostPort { get; set; }
        public string BriefDataPath { get; set; }
        public string BriefIndexPath { get; set; }


    };
}
