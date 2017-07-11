using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{


    [Serializable]
    public class FaceAlarmInfoV3_1
    {

        public string OriFacePicPath { get; set; }
        public System.Drawing.Rectangle FacePosition { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CameraID { get; set; }
        public uint BlackListHandle { get; set; }
        public Dictionary<BlackItem,uint> BlackListPicInfo { get; set; }

    };
}
