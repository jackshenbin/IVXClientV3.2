﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.Live.CommServices
{
    public class CommWebserviceClientProtocol
    {
        private ulong Sequence = 0;

        //private ulong Context = 0;

        private IVXWebService.matchservicePortTypeClient m_server = null;

        public IVXWebService.matchservicePortTypeClient Server
        {
            get {
                if (m_server == null)
                    throw new NullReferenceException();
                return m_server; }
            set { m_server = value; }
        }

        public void Init(string url)
        {
            try
            {
                //url = "http://192.168.42.31:10001/?matchService.wsdl";
                m_server = new IVXWebService.matchservicePortTypeClient("matchservice", url);//webservice设置回档，使用配置文件方式，代码配置方式存在问题，在有的机器上接收8k以上数据
                
                //m_server = new IVXWebReference.matchservice();
                //m_server.Url = url;
            }
            catch (Exception ex)
            {
                throw new IVX.DataModel.SDKCallException(1, ex.ToString());
            }

        }

		public void UnInit() 
		{
			m_server = null;
			Sequence = 0;
			//Context  = 0;
		}


        public string BuildProtocolHead(ulong Context ,MessageCmd cmdtype)
        {
            Head hd = new Head()
            {
                Context = Context.ToString(),
                MsgCmd = (ulong)cmdtype,
                Sequence = Sequence++,
                Version = "3.1.1.0",
            };

            return IVX.DataModel.Common.SerilizeObject<Head>(hd);
        }
        public string BuildProtocolBody<T>(ulong Context ,MessageCmd cmdtype, T args)
        {
            string h = "<?xml version=\"1.0\" ?><Root>";// encoding=\"gbk\"
            string t = "</Root>";

            string head = BuildProtocolHead( Context ,cmdtype);
            string body = IVX.DataModel.Common.SerilizeObject<T>(args);
            body = body.Replace(typeof(T).Name, "Request");

            return string.Format("{0}{1}{2}{3}", h, head, body, t);
        }

        public string BuildProtocolBody(ulong Context ,MessageCmd cmdtype, string body)
        {
            string h = "<?xml version=\"1.0\" ?><Root>";// encoding=\"gbk\"
            string t = "</Root>";

            string head = BuildProtocolHead( Context, cmdtype);

            return string.Format("{0}{1}{2}{3}", h, head, body, t);
        }

        public void SetContext(ulong id)
        {
            //Context = id;
        }

        //public ulong GetContext() {
        //    return Context ;
        //}

        public string SendProtocol(string request)
        {
            try
            {
                string retVal = Server.MatchServiceReq("IAX3-1", request);

                return retVal;

            }
            catch (System.ServiceModel.EndpointNotFoundException epnfe)
            {
                throw new IVX.DataModel.SDKCallException((uint)SDKCallExceptionCode.EndpointNotFound, epnfe.ToString());
            }
            catch (Exception ex)
            {
                if (ex.GetType().Name == "NetDispatcherFaultException")
                    throw new IVX.DataModel.SDKCallException((uint)SDKCallExceptionCode.NetDispatcherFault, ex.ToString());
                else
                    throw new IVX.DataModel.SDKCallException((uint)SDKCallExceptionCode.Other, ex.ToString());
            }


        }
    }
}
