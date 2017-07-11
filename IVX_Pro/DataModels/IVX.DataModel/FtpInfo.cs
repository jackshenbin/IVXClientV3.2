using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace IVX.DataModel
{

    /// <summary>
    /// 案件信息
    /// </summary>
    [Serializable]
    public class FtpInfo
    {
        public string IP { get; set; }
       public uint Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAnonymous { get; set; }
    };
    
}
