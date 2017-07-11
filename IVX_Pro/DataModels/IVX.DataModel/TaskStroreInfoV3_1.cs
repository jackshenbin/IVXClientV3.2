using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{

    [Serializable]
    public class TaskStroreInfoV3_1
    {
        public string CameraID { get; set; }
        public E_VIDEO_ANALYZE_TYPE AlgthmType { get; set; }
        public string StoreIP { get; set; }
        public UInt32 StortPort { get; set; }


    };
}
