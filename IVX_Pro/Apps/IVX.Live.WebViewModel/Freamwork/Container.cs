using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using log4net;

using System.Reflection;

using System.IO;
using IVX.DataModel;

using System.Data;


namespace IVX.Live.WebViewModel.Framework
{
    public class Container 
    {
        

        #region Fields

        private static Container s_Instance = null;
        private CommServices.CommServicesMutiUser m_CommService = null;
        #endregion

        #region Properties
        public static string ExecutingPath { get;set; }



        public CommServices.CommServicesMutiUser CommService
        {
            get
            {
                if (m_CommService == null)
                {
                    m_CommService = new CommServices.CommServicesMutiUser("http://{0}:{1}/?matchservice.wsdl");
                    //m_CommService = new CommServices.CommServices("http://192.168.88.121:9090/?wsdl");
                }
                return m_CommService;
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
