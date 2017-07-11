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
    public class SubscribeInfo
    {
        public uint SubscribeHandle { get; set; }
        public string UserName { get; set; }
        public string ClientIP { get; set; }
        public uint ClientPort { get; set; }
        public string CameraID { get; set; }
        public uint DataType { get; set; }
        public uint BlackListHandle { get; set; }
    }

}
