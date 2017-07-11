using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using DataModel;

namespace IVX.DataModel
{
    /// <summary>
    /// 监控点位信息 
    /// </summary>
    [Serializable]
    public class SystemMenu
    {
        public string Title { get; set; }
        public bool IsDialog { get; set; }
        public string Discription { get; set; }
        public string URL { get; set; }
        public string ParentURL { get; set; }
    }
}
