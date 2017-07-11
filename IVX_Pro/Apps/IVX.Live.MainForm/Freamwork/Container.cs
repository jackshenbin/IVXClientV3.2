using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Prism.Events;
using log4net;

using System.Reflection;

using System.IO;
using System.Windows.Forms;
using IVX.DataModel;

using System.Data;
using WinFormAppUtil.Common;
using WinFormAppUtil;
using IVX.Live.ConfigServices.Interop;
using IVX.Live.ConfigServices;


namespace IVX.Live.MainForm.Framework
{
    public class Container 
    {
        

        #region Fields

        private static Container s_Instance = null;
        private CommServices.CommServices m_CommService = null;
        //private FtpWeb m_ftpService = null;
        private InteractionService m_InteractionService = null;
        private IVXRealtimeProtocol m_IVXProtocol = null;
        //private DIOService m_DIOService = null;

        #endregion

        #region Properties




        public CommServices.CommServices CommService
        {
            get
            {
                if (m_CommService == null)
                {
                    m_CommService = new CommServices.CommServices("http://{0}:{1}/?matchservice.wsdl");
                }
                return m_CommService;
            }
        }

        //public FtpWeb FtpService
        //{
        //    get
        //    {
        //        if (m_ftpService == null)
        //        {
        //            string ftproot = @"ftp://public:public123$@192.168.42.6/"; //Framework.Container.Instance.VDAConfigService.GetFtpFileServiceURL();
        //            string ip, port, user, pass, path;
        //            FtpWeb.GetFtpUrlInfo(ftproot, out ip, out port, out user, out pass, out path);

        //            m_ftpService = new FtpWeb(ip + ":" + port, path, user, pass);
        //            //m_ftpService = new Common.FtpWeb("192.168.42.6", "素材库/3.0测试视频", "public", "public123$");
        //        }
        //        return m_ftpService;
        //    }

        //}

        public InteractionService InteractionService
        {
            get
            {
                if (m_InteractionService == null)
                {
                    m_InteractionService = new InteractionService();
                }
                return m_InteractionService;
            }
        }
        //public DIOService DIOService
        //{
        //    get
        //    {
        //        if (m_DIOService == null)
        //        {
        //            m_DIOService = new DIOService(IVXProtocol);

        //        }
        //        return m_DIOService;
        //    }
        //}

        public IVXRealtimeProtocol IVXProtocol
        {
            get
            {
                if (m_IVXProtocol == null)
                {
                    m_IVXProtocol = new IVXRealtimeProtocol();
                }
                return m_IVXProtocol;
            }
        }



        #endregion

        #region Constructors

        private Container()
        {
        }

        public static Container Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = new Container();
                }
                return s_Instance;
            }
        }

        #endregion

        #region Private helper functions
        

        #endregion

        #region Public helper functions


        public void Cleanup()
        {
            m_CommService = null;
            MyLog4Net.Container.Instance.Log.Info("Container.Cleanup ...");
        }

        
        #endregion

    }
}
