using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{

    [Serializable]
    public class TaskProgressInfoV3_1
    {
        public UInt32 TaskId { get; set; }
        public List<StatusInfoV3_1> StatusList { get; set; }
    };

    public class StatusInfoV3_1
    {
        public E_VIDEO_ANALYZE_TYPE AlgthmType { get; set; }
        public E_VDA_TASK_STATUS Status { get; set; }
        public UInt32 Progress { get; set; }
        public string AnalyseParam { get; set; }
        public UInt32 LeftTime { get; set; }

        public override bool Equals(object obj)
        {
            StatusInfoV3_1 temp = obj as StatusInfoV3_1;
            if (temp == null)
                return false;

            return temp.AlgthmType == this.AlgthmType 
                && temp.AnalyseParam == this.AnalyseParam 
                && temp.Progress == this.Progress
                && temp.LeftTime == this.LeftTime 
                && temp.Status == this.Status;
        }
    }
}
