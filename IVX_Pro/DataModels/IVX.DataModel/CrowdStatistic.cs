using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    public class CrowdStatistic
    {
        /// <summary>
        /// 监控点Code
        /// </summary>
        public string CameraID { get; set; }

        // 时间标签
        public string TimeTag { get; set;}

        // 人群密度均值
        public UInt32 PeopleCountArg { get; set;}
    }
}
