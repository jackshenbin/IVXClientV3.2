using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    public class SearchItemV3_1
    {
        public uint TaskId { get; set; }

        //public uint CameraId { get; set; }

        /// <summary>
        /// 底层检索标示
        /// </summary>
        public uint SearchHandle { get; set; }

        /// <summary>
        /// 实时检索时相机唯一编号
        /// </summary>
        public string CameraID{ get; set; }

        public string CameraName { get; set; }
        public string TaskName { get; set; }

        public DateTime AdjustTime { get; set; }
        
        public override string ToString()
        {
            return "[" + TaskId + "]" + (CameraID.StartsWith(Common.VIRTUAL_CAMERA_ID) ? TaskName : CameraName);
        }

        public bool IsHistoryTask { get { return CameraID.StartsWith(Common.VIRTUAL_CAMERA_ID); } }


    }
}
