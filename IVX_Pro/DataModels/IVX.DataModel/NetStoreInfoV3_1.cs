using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{

    [Serializable]
    public class NetStoreInfoV3_1
    {
        public UInt32 NetHandle { get; set; }
        public E_VDA_NET_STORE_DEV_PROTOCOL_TYPE ConnectType { get; set; }
        public string NetName { get; set; }
        public string NetStoreIP { get; set; }
        public UInt32 NetStorePort { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Rest { get; set; }


        public override string ToString()
        {
            return NetName;
        }
    };
}
