using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;

namespace IVX.Live.ViewModel
{
    public class RealPlayViewModel
    {
        private IVX.Live.ConfigServices.DIOService server;

        IVX.Live.ConfigServices.DIOService DIOServer
        {
            get
            {
                if (server == null)
                    server = new ConfigServices.DIOService(Framework.Container.Instance.IVXProtocol);
                return server;
            }
        }


        public void PlayRealTime(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE Protocol, string IP, ushort p, string User, string Pass, IntPtr handle, string Channel)
        {
            int ret = DIOServer.Login(Protocol, IP, p, User, Pass);
            DIOServer.StartRealPlay(handle, Channel, ret.ToString());
        }
    }
}
