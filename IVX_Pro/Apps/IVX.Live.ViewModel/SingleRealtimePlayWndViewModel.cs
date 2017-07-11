using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;

namespace IVX.Live.ViewModel
{
    public class SingleRealtimePlayWndViewModel
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

        public void DIOLogout()
        {
            DIOServer.Logout();
        }


        public int DIOLogin(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE Protocol, string IP, ushort p, string User, string Pass)
        {
            try
            {
                return DIOServer.Login(Protocol, IP, p, User, Pass);
            }
            catch (SDKCallException)
            {
                return -1;
            }
        }

        public bool DIOStartRealPlay(IntPtr intPtr, string Channel, string p)
        {
            return DIOServer.StartRealPlay(intPtr, Channel, p);
        }

        public void DIOStopRealPlay(IntPtr intPtr)
        {
            DIOServer.StopRealPlay(intPtr);
        }

        public System.Drawing.Image DIOSnapPicture(IntPtr intPtr)
        {
            return DIOServer.SnapPicture(intPtr);
        }

        public void DIOGetPlayResolution(IntPtr intPtr,out uint w,out uint h)
        {
            DIOServer.GetPlayResolution(intPtr, out w, out h);
        }
    }
}
