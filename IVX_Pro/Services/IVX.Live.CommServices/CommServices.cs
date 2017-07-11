using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;
using MyLog4Net;

namespace IVX.Live.CommServices {
	public class CommServices {
		public event Action<DataModel.TaskInfoV3_1> TaskDeleted;
		public event Action<DataModel.TaskInfoV3_1> TaskAdded;
		public event Action<DataModel.TaskInfoV3_1> TaskMonified;
		public event Action<DataModel.UploadTaskInfoV3_1> UpLoadLocalFile;
		//public event Action<string> DisConnected;
		//public event Action<string> Connected;
		public event Action<string> FireMessage;
		public event Action<string> UserDisConnected;
		#region Fields
		public bool IsConnected { get; set; }
		private CommWebserviceClientProtocol CommProtocol = null;
		public string WebserviceUrl { get; set; }
		private string ServerIP { get; set; }

		private List<TaskInfoV3_1> m_taskList = new List<TaskInfoV3_1>();
		private bool isTaskListInited = false;
		private bool isExit = false;

		private System.Threading.Thread thGetTask;
        private ulong Context = 0;
        #endregion

		#region Constructors

		public CommServices(string url) {
			IsConnected = false;
			WebserviceUrl = url;
			CommProtocol = new CommWebserviceClientProtocol();
		}

		#endregion

		#region Public Functions
		public bool Init(string serverip, uint serverport) {
			Constant.getVehicleBrandFunc += new GetVehicleBrandFunc(GET_VEHICLE_BRAND_LIST);
			isExit = false;
			isTaskListInited = false;
			m_taskList = new List<TaskInfoV3_1>();
			thGetTask = new System.Threading.Thread(tReflashTaskList);
			CommProtocol.Init(string.Format(WebserviceUrl, serverip, serverport));
			bool ret = TestConn();
			if (ret) {
				IsConnected = true;
				ServerIP = serverip;
				if (FireMessage != null)
					FireMessage("服务器：【" + ServerIP + "】连接成功");
				m_taskList = new List<TaskInfoV3_1>();
			}
			else {
				IsConnected = false;
				if (FireMessage != null)
					FireMessage("正在连接服务器...");
			}
			return ret;
		}

		public void UnInit() {
			Constant.getVehicleBrandFunc -= new GetVehicleBrandFunc(GET_VEHICLE_BRAND_LIST);
			isExit = true;
			isTaskListInited = false;
			m_taskList = new List<TaskInfoV3_1>();
			IsConnected = false;
			CommProtocol.UnInit();
		}

		public bool TestConn() {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("TestConn");

			string message = CommProtocol.BuildProtocolBody<VDM_MSG_GET_SVERVER_REQ>(0,MessageCmd.VDM_MSG_GET_SVERVER_REQ, new VDM_MSG_GET_SVERVER_REQ { ServerId = uint.MaxValue, });
			try {
				string rsp = Send(message, true);
				if (string.IsNullOrEmpty(rsp))
					return false;

				return true;
			}
			catch (SDKCallException sdkex) {
				return (sdkex.ErrorCode == (uint)SDKCallExceptionCode.UserNotLogin || 66240 == sdkex.ErrorCode);
			}
			finally {
				MyLog4Net.Container.Instance.Log.DebugWithDebugView("TestConn ret");
			}
		}

		public uint LOGIN(string username, string password, string localip, uint localport) {

			//return 1;
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices LOGIN username:{0},password:{1},localip:{2},localport:{3}", username, password, localip, localport));

			string message = CommProtocol.BuildProtocolBody<VDM_MSG_LOGIN_REQ>(0,MessageCmd.VDM_MSG_LOGIN_REQ, new VDM_MSG_LOGIN_REQ { PassWord = password, UserName = username, UserSerIp = localip, UserSerPort = localport, });
			string rsp = Send(message);
			uint id = 0;
			if (string.IsNullOrEmpty(rsp))
				return 0;

			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);

			id = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/LoginHandle").InnerText);
			Context = id;
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices LOGIN retVal:{0}", id));
			return id;
		}

        public uint LOGOUT()
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices LOGOUT "));
			string message = CommProtocol.BuildProtocolBody<VDM_MSG_LOGOUT_REQ>(Context, MessageCmd.VDM_MSG_LOGOUT_REQ, new VDM_MSG_LOGOUT_REQ { LoginHandle = (uint) Context , });
			string rsp = Send(message);
			uint logOutRet = 1;
			if (string.IsNullOrEmpty(rsp))
				return 1;
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			logOutRet = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/Result").InnerText);
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices LOGIN logOutRet:{0}", logOutRet));
			return logOutRet;
		}

        public List<BlackListLib> GET_BLACK_LIST()
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_BLACK_LIST"));
			
			string message = CommProtocol.BuildProtocolBody(Context,MessageCmd.VDM_MSG_GET_BLACK_LIST_DATA_REQ, "");
			string rsp = Send(message);
			List<BlackListLib> list = new List<BlackListLib>();
			if (string.IsNullOrEmpty(rsp))
				return list;
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			System.Xml.XmlNodeList nl = xdoc.SelectNodes("//Root/Response/BlackList/BlackListInfo");
			foreach (System.Xml.XmlNode item in nl) {
				BlackListLib Blicklib = new BlackListLib();
				Blicklib.Handel = Convert.ToUInt32(item.SelectSingleNode("BlackListHandle").InnerText);
				Blicklib.Name = item.SelectSingleNode("BlackListName").InnerText;
				Blicklib.Code = item.SelectSingleNode("BlackListCode").InnerText;
				Blicklib.PicCount = Convert.ToUInt32(item.SelectSingleNode("BlackListPicCount").InnerText);
				Blicklib.OtherInfo = item.SelectSingleNode("Other").InnerText;
				list.Add(Blicklib);
			}

			//List<BlackListLib> list = new List<BlackListLib>();
			//BlackListLib Item1 = new BlackListLib();
			//Item1.Name = "黑名单1";
			//Item1.OtherInfo = "A.级.逃.犯.";
			//Item1.Handel = 1;
			//Item1.PicCount = 2;
			//BlackListLib Item2 = new BlackListLib();
			//Item2.Name = "黑名单2";
			//Item2.OtherInfo = "B.级.逃.犯.";
			//Item2.Handel = 2;
			//Item2.PicCount = 22;
			//BlackListLib Item3 = new BlackListLib();
			//Item3.Name = "黑名单3";
			//Item3.OtherInfo = "C.级.逃.犯.";
			//Item3.Handel = 3;
			//Item3.PicCount =34;

			//list.Add(Item1);
			//list.Add(Item2);
			//list.Add(Item3);
			return list;
		}

		public List<BlackItem> GET_BLACK_FACE_PICTURE(UInt32 BlackListHandel, int pageNum, int perPageCount) {
			StringBuilder sb = new StringBuilder();
			sb.Append("<Request>");
			sb.Append("<BlackListHandle>" + BlackListHandel + "</BlackListHandle>");
			sb.Append("<PagerNum >" + pageNum + "</PagerNum>");
			sb.Append("<EveryPagerCount>" + perPageCount + "</EveryPagerCount>");
			sb.Append("</Request>");
			string message = CommProtocol.BuildProtocolBody(Context,MessageCmd.VDM_MSG_GET_BLACK_FACE_PICTURE_REQ, sb.ToString());
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommServices start GET_BLACK_FACE_PICTURE");
			string rsp = Send(message);
			List<BlackItem> blackItemList = new List<BlackItem> {};
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommServices end GET_BLACK_FACE_PICTURE0");
			if (string.IsNullOrEmpty(rsp)) return blackItemList;
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			System.Xml.XmlNodeList nl = xdoc.SelectNodes("//Root/Response/PictureList/PictureInfo");
			foreach (System.Xml.XmlNode item in nl) {
				BlackItem blickItem = new BlackItem();
				blickItem.PicHandel = Convert.ToUInt32(item.SelectSingleNode("PictureHandle").InnerText);
				blickItem.LibHandel = Convert.ToUInt32(item.SelectSingleNode("BlackListHandle").InnerText);
				blickItem.PicState = Convert.ToUInt32(item.SelectSingleNode("PictureState").InnerText);
				blickItem.PictureUrl = item.SelectSingleNode("PictureUrl").InnerText;
				blickItem.Name = item.SelectSingleNode("PeopleName").InnerText;
				blickItem.PeopleCard = item.SelectSingleNode("PeopleCard").InnerText;
				blickItem.PeopleNation = item.SelectSingleNode("PeopleNation").InnerText;
				blickItem.PeopleAge = Convert.ToUInt32(item.SelectSingleNode("PeopleAge").InnerText);
				blickItem.PeopleSex = Convert.ToUInt32(item.SelectSingleNode("PeopleSex").InnerText);
				blickItem.PeopleHeight = Convert.ToUInt32(item.SelectSingleNode("PeopleHeight").InnerText);
				blickItem.PeopleWeight = Convert.ToUInt32(item.SelectSingleNode("PeopleWeight").InnerText);
				blickItem.BloodType = Convert.ToUInt32(item.SelectSingleNode("BloodType").InnerText);
				blickItem.Address = item.SelectSingleNode("Address").InnerText;
				blackItemList.Add(blickItem);
			}
			return blackItemList;
		}

		public bool ADD_BLACK_FACE_PICTURE(BlackItem newItem) {
			bool ret = false;
			VDM_MSG_ADD_BLACK_FACE_PICTURE_REQ req = new VDM_MSG_ADD_BLACK_FACE_PICTURE_REQ() {
				LibHandel = newItem.LibHandel,
				PicHandel = newItem.PicHandel,
				picData = newItem.picData,	//	图片Url（string)
				Name = newItem.Name,			//	姓名（string）
				PeopleCard = newItem.PeopleCard,	//身份证号
				PeopleNation = newItem.PeopleNation,	//	民族	（UINT32）
				PeopleAge = newItem.PeopleAge,		//	年龄
				PeopleSex = (uint)newItem.PeopleSex, //	性别	性别
				PeopleHeight = newItem.PeopleHeight, //	身高	
				PeopleWeight = newItem.PeopleWeight, //	体重	
				BloodType = newItem.BloodType,		//	血型	
				Address = newItem.Address,			//	地址	
				other = newItem.other,
			};
			string msgBody = "<Request><PictureList><PictureInfo>" + req.ToString() + "</PictureInfo></PictureList></Request>";
			string message = CommProtocol.BuildProtocolBody(Context, MessageCmd.VDM_MSG_ADD_BLACK_FACE_PICTURE_REQ, msgBody);
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol start ADD_BLACK_FACE_PICTURE");
			string rsp = Send(message);
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol End   ADD_BLACK_FACE_PICTURE");
			if (string.IsNullOrEmpty(rsp)) return ret;
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			UInt32 retVal = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/Result").InnerText);
			ret = retVal == 0 ? true : false;
			return ret;
		}

		public bool ADD_BLACK_FACE_PICTURE(List<BlackItem> listItem) {
			bool ret = false;
			string msgBody = "<Request><PictureList>";
			foreach (var item in listItem) {
				msgBody += "<PictureInfo>";
				VDM_MSG_ADD_BLACK_FACE_PICTURE_REQ req = new VDM_MSG_ADD_BLACK_FACE_PICTURE_REQ() {
					LibHandel = item.LibHandel,
					PicHandel = item.PicHandel,
					picData = item.picData,	//	图片Url（string)
					Name = item.Name,			//	姓名（string）
					PeopleCard = item.PeopleCard,	// 身份证号
					PeopleNation = item.PeopleNation,	//	民族	（UINT32）
					PeopleAge = item.PeopleAge,		//	年龄
					PeopleSex = (uint)item.PeopleSex,	//	性别	性别
					PeopleHeight = item.PeopleHeight, //	身高	
					PeopleWeight = item.PeopleWeight, //	体重	
					BloodType = item.BloodType,		//	血型	
					Address = item.Address,			//	地址	
					other = item.other,
				};
				msgBody += req.ToString();
				msgBody += "</PictureInfo>";
			}
			msgBody += "</PictureList></Request>";
			string message = CommProtocol.BuildProtocolBody(Context, MessageCmd.VDM_MSG_ADD_BLACK_FACE_PICTURE_REQ, msgBody);
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol start ADD_BLACK_FACE_PICTURE List");
			string rsp = Send(message);
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol End   ADD_BLACK_FACE_PICTURE List");
			if (string.IsNullOrEmpty(rsp)) return ret;
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			UInt32 retVal = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/Result").InnerText);
			ret = retVal == 0 ? true : false;
			return ret;
		}

		public bool MDF_BLACK_LIST_DATA(BlackItem mdfItem) {
			bool ret = false;
			VDM_MSG_MDF_BLACK_FACE_PICTURE_REQ req = new VDM_MSG_MDF_BLACK_FACE_PICTURE_REQ() {
				LibHandel = mdfItem.LibHandel,
				PicHandel = mdfItem.PicHandel,
				picData = mdfItem.picData,	//	图片Url（string)
				Name = mdfItem.Name,			//	姓名（string）
				PeopleCard = mdfItem.PeopleCard,	//身份证号
				PeopleNation = mdfItem.PeopleNation,	//	民族	（UINT32）
				PeopleAge = mdfItem.PeopleAge,		//	年龄
				PeopleSex = mdfItem.PeopleSex,		//	性别	性别
				PeopleHeight = mdfItem.PeopleHeight, //	身高	
				PeopleWeight = mdfItem.PeopleWeight, //	体重	
				BloodType = mdfItem.BloodType,		//	血型	
				Address = mdfItem.Address,			//	地址	
				other = mdfItem.other,
			};
			string msgBody = "<Request>";
			msgBody += req.ToString();
			msgBody += "</Request>";
			string message = CommProtocol.BuildProtocolBody(Context, MessageCmd.VDM_MSG_MDF_BLACK_FACE_PICTURE_REQ, msgBody.ToString());
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol start MDF_BLACK_LIST_DATA");
			string rsp = Send(message);
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol End   MDF_BLACK_LIST_DATA");
			if (string.IsNullOrEmpty(rsp)) return ret;
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			UInt32 retVal = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/Result").InnerText);
			ret = retVal == 0 ? true : false;
			return ret;
		}

		public bool DEL_BLACK_FACE_PICTURE(UInt32 PictureHandle) {
			bool ret = false;
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices DEL_BLACK_ITEM"));
			StringBuilder sb = new StringBuilder();
			sb.Append("<Request>");
			sb.Append("<PictureHandle>" + PictureHandle + "</PictureHandle>");
			sb.Append("</Request>");
			string message = CommProtocol.BuildProtocolBody(Context, MessageCmd.VDM_MSG_DEL_BLACK_FACE_PICTURE_REQ, sb.ToString());
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return false;
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			UInt32 retVal = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/Result").InnerText);
			ret = retVal == 0 ? true : false;
			return ret;
		}

		public bool ADD_BLACK_LIST(BlackListLib blackListLib) {
			bool ret = true;
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices ADD_BLACK_LIST"));
			StringBuilder sb = new StringBuilder();
			sb.Append("<Request>");
			sb.Append("<BlackListName>" + blackListLib.Name + "</BlackListName>");
			sb.Append("<BlackListCode>" + blackListLib.Code + "</BlackListCode>");
			sb.Append("<Other>" + blackListLib.OtherInfo + "</Other>");
			sb.Append("</Request>");
			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_ADD_BLACK_LIST_DATA_REQ, sb.ToString());
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return false;
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			UInt32 retVal = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/Result").InnerText);
			blackListLib.Handel = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/BlackListHandle").InnerText);
			ret = retVal == 0 ? true : false;
			return ret;
		}

		public bool DEl_BLACK_LIST(UInt32 blackListHandel, out string desStr) {
			bool ret = true;
			desStr = "";
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices DEl_BLACK_LIST"));
			StringBuilder sb = new StringBuilder();
			sb.Append("<Request>");
			sb.Append("<BlackListHandle>" + blackListHandel + "</BlackListHandle>");
			sb.Append("</Request>");
			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_DEL_BLACK_LIST_DATA_REQ, sb.ToString());
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return false;
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			UInt32 retVal = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/Result").InnerText);
			ret = retVal == 0 ? true : false;
			desStr = "111";
			return ret;
		}

        public uint ADD_SVERVER(string ip, uint port, E_VDA_SERVER_TYPE type, string des)
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices ADD_SVERVER type:{0} "
				+ ",ip:{1} "
				+ ",port:{2} "
				+ ",des:{3} "
				, type
				, ip
				, port
				, des
				));
			VDM_MSG_ADD_SVERVER_REQ VDM_MSG_ADD_SVERVER_REQ = new Live.CommServices.VDM_MSG_ADD_SVERVER_REQ() {
				ServerList = new List<ServerInfo>(),
			};
			VDM_MSG_ADD_SVERVER_REQ.ServerList.Add(new ServerInfo() {
				ServerType = (uint)type,
				ServerId = 0,
				ServerIP = ip,
				ServerPort = port,
				Status = (uint)E_VDA_SERVER_STATUS.E_STATUS_INUSE,
			});
			string message = CommProtocol.BuildProtocolBody<VDM_MSG_ADD_SVERVER_REQ>( Context ,MessageCmd.VDM_MSG_ADD_SVERVER_REQ, VDM_MSG_ADD_SVERVER_REQ);
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return 0;

			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			uint NetHandle = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response//ServerIdInfo/ServerId").InnerText);

			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices ADD_SVERVER NetHandle:{0}", NetHandle.ToString()));
			return NetHandle;
		}
        public void DEL_SVERVER(uint serverid)
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices DEL_SVERVER serverid:{0}", serverid));

			string message = CommProtocol.BuildProtocolBody<VDM_MSG_DEL_SVERVER_REQ>( Context ,MessageCmd.VDM_MSG_DEL_SVERVER_REQ, new VDM_MSG_DEL_SVERVER_REQ { ServerId = serverid, });
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return;

			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices DEL_SVERVER retVal:{0}", 0));

		}
        public void MDF_SVERVER( uint serverid, string ip, uint port, E_VDA_SERVER_TYPE type, string des)
        {

		}
        public ServerInfoV3_1 GET_SVERVER( uint serverid)
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_SVERVER serverid:{0}", serverid));

			string message = CommProtocol.BuildProtocolBody<VDM_MSG_GET_SVERVER_REQ>( Context ,MessageCmd.VDM_MSG_GET_SVERVER_REQ, new VDM_MSG_GET_SVERVER_REQ { ServerId = serverid, });
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return new ServerInfoV3_1();

			ServerInfoV3_1 server = new ServerInfoV3_1();

			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			System.Xml.XmlNode item = xdoc.SelectSingleNode("//Root/Response/ServerInfo");
			ServerInfo tui
				= IVX.DataModel.Common.DeserilizeObject<ServerInfo>(item.OuterXml);
			server = new ServerInfoV3_1() {
				Description = tui.Description,
				ServerIP = tui.ServerIP,
				ServerId = tui.ServerId,
				ServerPort = tui.ServerPort,
				ServerType = (E_VDA_SERVER_TYPE)tui.ServerType,
				Status = (E_VDA_SERVER_STATUS)tui.Status,
			};

			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_SVERVER retVal:{0}", 0));
			return server;

		}

		//获取 车标 信息
		public List<VBrandInfo> GET_VEHICLE_BRAND_LIST() {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_VEHICLE_BRAND_LIST"));
			string message = CommProtocol.BuildProtocolBody( 0 ,MessageCmd.VDM_MSG_GET_VEHICLE_BRAND_LIST_REQ, "");
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices start send"));
			string rsp = Send(message);
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices return from send"));
			List<VBrandInfo> list = new List<VBrandInfo> { };
			if (string.IsNullOrEmpty(rsp))
				return list;
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			System.Xml.XmlNodeList nl = xdoc.SelectNodes("//Root/Response/VehicleBrandList/VehicleBrandInfo");
			foreach (System.Xml.XmlNode item in nl) {
				VBrandInfo infoItem = new VBrandInfo();
				infoItem.SubID = Convert.ToUInt32(item.SelectSingleNode("SubID").InnerText);
				infoItem.ParentID = Convert.ToUInt32(item.SelectSingleNode("ParentID").InnerText);
				infoItem.Name = item.SelectSingleNode("Name").InnerText;
				infoItem.LogoPath = item.SelectSingleNode("LogoPath").InnerText;
				infoItem.FrontPath = item.SelectSingleNode("FrontPath").InnerText;
				infoItem.BackPath = item.SelectSingleNode("BackPath").InnerText;
				list.Add(infoItem);
			}
			return list;
		}

		public List<ServerInfoV3_1> GET_SVERVER_LIST() {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_SVERVER_LIST "));

			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_GET_SVERVER_LIST_REQ, "");
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return new List<ServerInfoV3_1>();

			List<ServerInfoV3_1> list = new List<ServerInfoV3_1>();

			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			System.Xml.XmlNodeList nl = xdoc.SelectNodes("//Root/Response/ServerList/ServerInfo");
			foreach (System.Xml.XmlNode item in nl) {
				ServerInfo tui
					= IVX.DataModel.Common.DeserilizeObject<ServerInfo>(item.OuterXml);
				ServerInfoV3_1 t = new ServerInfoV3_1() {
					Description = tui.Description,
					ServerIP = tui.ServerIP,
					ServerId = tui.ServerId,
					ServerPort = tui.ServerPort,
					ServerType = (E_VDA_SERVER_TYPE)tui.ServerType,
					Status = (E_VDA_SERVER_STATUS)tui.Status,
				};
				list.Add(t);
			}

			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_SVERVER_LIST retVal count:{0}", list.Count));
			return list;

		}
        public uint ADD_NET_STORE( E_VDA_NET_STORE_DEV_PROTOCOL_TYPE type, string name, string ip, uint port, string username, string password)
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices ADD_NET_STORE type:{0} "
				+ ",name:{1} "
				+ ",ip:{2} "
				+ ",port:{3} "
				+ ",username:{4} "
				+ ",password:{5} "
				, type
				, name
				, ip
				, port
				, username
				, password
				));
			VDM_MSG_ADD_NET_STORE_REQ VDM_MSG_ADD_NET_STORE_REQ = new Live.CommServices.VDM_MSG_ADD_NET_STORE_REQ() {
				NetStoreList = new List<NetStoreInfo>(),
			};
			VDM_MSG_ADD_NET_STORE_REQ.NetStoreList.Add(new NetStoreInfo() {
				ConnectType = (uint)type,
				NetHandle = 0,
				NetName = name,
				NetStoreIP = ip,
				NetStorePort = port,
				UserName = username,
				PassWord = password,
				Rest = "",
			});
			string message = CommProtocol.BuildProtocolBody<VDM_MSG_ADD_NET_STORE_REQ>( Context ,MessageCmd.VDM_MSG_ADD_NET_STORE_REQ, VDM_MSG_ADD_NET_STORE_REQ);
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return 0;

			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			uint NetHandle = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/NetHandleList/NetHandleInfo/NetHandle").InnerText);

			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices ADD_NET_STORE NetHandle:{0}", NetHandle.ToString()));
			return NetHandle;
		}

        public void DEL_NET_STORE( uint netstoreid)
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices DEL_NET_STORE netstoreid:{0}", netstoreid));
			StringBuilder sb = new StringBuilder();
			sb.Append("<Request><NetHandleList>");
			sb.Append("<NetHandleInfo><NetHandle>" + netstoreid + "</NetHandle></NetHandleInfo>");
			sb.Append("</NetHandleList></Request>");

			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_DEL_NET_STORE_REQ, sb.ToString());
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return;

			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices DEL_NET_STORE retVal:{0}", 0));

		}

		public List<VideoSupplierDeviceInfo> GET_NET_STORE_LIST() {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_NET_STORE_LIST "));

			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_GET_NET_STORE_LIST_REQ, "");
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return new List<VideoSupplierDeviceInfo>();

			List<VideoSupplierDeviceInfo> list = new List<VideoSupplierDeviceInfo>();
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);

			System.Xml.XmlNodeList nl = xdoc.SelectNodes("//Root/Response/NetStoreList/NetStoreInfo");
			foreach (System.Xml.XmlNode item in nl) {
				NetStoreInfo tui
					= IVX.DataModel.Common.DeserilizeObject<NetStoreInfo>(item.OuterXml);
				VideoSupplierDeviceInfo t = new VideoSupplierDeviceInfo() {

					ProtocolType = (E_VDA_NET_STORE_DEV_PROTOCOL_TYPE)tui.ConnectType,
					Id = tui.NetHandle,
					DeviceName = tui.NetName,
					IP = tui.NetStoreIP,
					Port = tui.NetStorePort,
					Password = tui.PassWord,
					UserName = tui.UserName,
					Rest = tui.Rest,
					LoginSessionId = 0,
				};
				list.Add(t);
			}
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_NET_STORE_LIST retVal cout:{0}", list.Count));
			return list;
		}
		public List<CameraInfoV3_1> GET_CAMERA_LIST() {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_CAMERA_LIST "));
			List<VideoSupplierDeviceInfo> devlist = GET_NET_STORE_LIST(  );
			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_GET_CAMERA_LIST_REQ, "");
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return new List<CameraInfoV3_1>();

			List<CameraInfoV3_1> list = new List<CameraInfoV3_1>();
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);

			System.Xml.XmlNodeList nl = xdoc.SelectNodes("//Root/Response/CameraList/CameraInfo");
			foreach (System.Xml.XmlNode item in nl) {
				CameraInfo tui
					= IVX.DataModel.Common.DeserilizeObject<CameraInfo>(item.OuterXml);
				CameraInfoV3_1 t = new CameraInfoV3_1() {
					CameraID = tui.CameraID,
					ID = tui.ID,
					CameraName = tui.Name,
					PosCoordX = tui.Coord_X / 1000000f,
					PosCoordY = tui.Coord_Y / 1000000f,
					VideoSupplierChannelID = tui.NetDevChannel,
					VideoSupplierDeviceID = tui.NetStoreDevId,
				};
				t.VideoSupplier = (VideoSupplierDeviceInfo)devlist.First(dev => dev.Id == tui.NetStoreDevId).Clone();
				list.Add(t);
			}

			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_CAMERA_LIST retVal cout:{0}", list.Count));
			return list;
		}

        public uint ADD_CAMERA( uint netstoreid, string channel, string name, string cameraId, double x, double y)
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices ADD_CAMERA netstoreid:{0} "
				+ ",channel:{1} "
				+ ",name:{2} "
				+ ",cameraId:{3} "
				+ ",x:{4} "
				+ ",y:{5} "
				, netstoreid
				, channel
				, name
				, cameraId
				, x
				, y
				));
			VDM_MSG_ADD_CAMERA_REQ VDM_MSG_ADD_CAMERA_REQ = new Live.CommServices.VDM_MSG_ADD_CAMERA_REQ() {
				CameraList = new List<CameraInfo>(),
			};

			VDM_MSG_ADD_CAMERA_REQ.CameraList.Add(new CameraInfo() {
				ID = 0,
				CameraID = cameraId,
				Coord_X = (uint)(x * 1000000),
				Coord_Y = (uint)(y * 1000000),
				Name = name,
				NetDevChannel = channel,
				NetStoreDevId = netstoreid,
			});
			string message = CommProtocol.BuildProtocolBody<VDM_MSG_ADD_CAMERA_REQ>( Context ,MessageCmd.VDM_MSG_ADD_CAMERA_REQ, VDM_MSG_ADD_CAMERA_REQ);
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return 0;

			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			uint id = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/CameraList/CameraInfo/ID").InnerText);
			string cameraid = xdoc.SelectSingleNode("//Root/Response/CameraList/CameraInfo/CameraID").InnerText;

			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices ADD_CAMERA id:{0},cameraid:{1}", id.ToString(), cameraid));
			return id;
		}
        public Dictionary<uint, string> ADD_CAMERA_LIST( List<CameraInfoV3_1> cams)
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices ADD_CAMERA_LIST count:{0} "
				, cams.Count
				));
			VDM_MSG_ADD_CAMERA_REQ VDM_MSG_ADD_CAMERA_REQ = new Live.CommServices.VDM_MSG_ADD_CAMERA_REQ() {
				CameraList = new List<CameraInfo>(),
			};

			foreach (var item in cams) {
				VDM_MSG_ADD_CAMERA_REQ.CameraList.Add(new CameraInfo() {
					ID = 0,
					CameraID = item.CameraID,
					Coord_X = (uint)(item.PosCoordX * 1000000),
					Coord_Y = (uint)(item.PosCoordY * 1000000),
					Name = item.CameraName,
					NetDevChannel = item.VideoSupplierChannelID,
					NetStoreDevId = item.VideoSupplierDeviceID,
				});

			}
			string message = CommProtocol.BuildProtocolBody<VDM_MSG_ADD_CAMERA_REQ>( Context ,MessageCmd.VDM_MSG_ADD_CAMERA_REQ, VDM_MSG_ADD_CAMERA_REQ);
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return new Dictionary<uint, string>();


			Dictionary<uint, string> ret = new Dictionary<uint, string>();

			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			StringBuilder sb = new StringBuilder();
			foreach (System.Xml.XmlNode item in xdoc.SelectNodes("//Root/Response/CameraList/CameraInfo")) {
				uint id = Convert.ToUInt32(item.SelectSingleNode("ID").InnerText);
				string cameraid = item.SelectSingleNode("CameraID").InnerText;
				sb.AppendLine(string.Format("id:{0},cameraid:{1}", id, cameraid));
				ret.Add(id, cameraid);
			}
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices ADD_CAMERA_LIST sb:{0}", sb.ToString()));
			return ret;
		}

        public void DEL_CAMERA(uint id)
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices DEL_CAMERA id:{0}", id));
			StringBuilder sb = new StringBuilder();
			sb.Append("<Request>");
			sb.Append("<CameraList><CameraInfo><ID>" + id + "</ID></CameraInfo></CameraList>");
			sb.Append("</Request>");

			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_DEL_CAMERA_REQ, sb.ToString());
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return;

			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices DEL_CAMERA retVal:{0}", 0));

		}

        public Dictionary<uint, string> ADD_TASK(List<TaskInfoV3_1> tasklist)
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices ADD_TASK "));
			VDM_MSG_ADD_TASK_REQ req = new VDM_MSG_ADD_TASK_REQ() {
				TaskList = new List<TaskInfo>() {
				}
			};
			foreach (var item in tasklist) {
				uint AlgthmType = 0;
				string AnalyseParam = "";
				if (item.StatusList.Count > 0) {
					AlgthmType = (uint)item.StatusList[0].AlgthmType;
					AnalyseParam = item.StatusList[0].AnalyseParam;
				}
				req.TaskList.Add(new TaskInfo() {
					AlgthmType = AlgthmType,
					AnalyseParam = AnalyseParam,
					CameraID = item.CameraID,
					ChannelID = item.ChannelID,
					DeviceIP = item.DeviceIP,
					DeviceName = item.DeviceName,
					DevicePort = item.DevicePort,
					DeviceType = (uint)item.DeviceType,
					EndTime = IVX.DataModel.Common.ConvertLinuxTime(item.EndTime),
					FileSize = item.FileSize,
					FileType = (uint)item.FileType,
					LoginPwd = item.LoginPwd,
					LoginUser = item.LoginUser,
					OriFilePath = item.OriFilePath,
					ProtocolType = (uint)item.ProtocolType,
					StartTime = IVX.DataModel.Common.ConvertLinuxTime(item.StartTime),
					TaskName = item.TaskName,
					Priority = 10,
					TaskType = (uint)item.TaskType,
				}
				);

			}
			string message = CommProtocol.BuildProtocolBody<VDM_MSG_ADD_TASK_REQ>( Context ,MessageCmd.VDM_MSG_ADD_TASK_REQ, req);
			string rsp = Send(message);

			if (string.IsNullOrEmpty(rsp))
				return new Dictionary<uint, string>();


			Dictionary<uint, string> ret = new Dictionary<uint, string>();

			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			StringBuilder sb = new StringBuilder();
			foreach (System.Xml.XmlNode item in xdoc.SelectNodes("//Root/Response/TaskList/TaskInfo")) {
				uint taskid = Convert.ToUInt32(item.SelectSingleNode("TaskId").InnerText);
				string taskname = item.SelectSingleNode("TaskName").InnerText;
				sb.AppendLine(string.Format("taskid:{0},taskname:{1}", taskid, taskname));
				ret.Add(taskid, taskname);
			}
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices ADD_TASK retVal:{0}", sb.ToString()));
			return ret;

		}
        public void DEL_TASK(List<uint> taskidList)
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices DEL_TASK taskid Count:{0}", taskidList.Count));

			StringBuilder sb = new StringBuilder();
			sb.Append("<Request><TaskList>");
			taskidList.ForEach(item => sb.Append("<TaskInfo><TaskId>" + item + "</TaskId></TaskInfo>"));
			sb.Append("</TaskList></Request>");
			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_DEL_TASK_REQ, sb.ToString());
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return;



			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices DEL_TASK retVal:{0}", 0));

		}
        public void MDF_TASK( uint taskid, uint priority, DateTime startTime, DateTime endTime, uint status, string taskname)
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices MDF_TASK taskid :{0},priority:{1},startTime:{2},endTime:{3},status:{4}"
				, taskid, priority, startTime, endTime, status));

			StringBuilder sb = new StringBuilder();
			sb.Append("<Request><TaskList>");
			sb.Append("<TaskInfo><TaskId>" + taskid + "</TaskId>");
			if (priority != 0)
				sb.Append("<Priority>" + priority + "</Priority>");
			else
				sb.Append("<Priority>0</Priority>");

			if (startTime != new DateTime())
				sb.Append("<StartTime>" + DataModel.Common.ConvertLinuxTime(startTime) + "</StartTime>");
			else
				sb.Append("<StartTime>0</StartTime>");

			if (endTime != new DateTime())
				sb.Append("<EndTime>" + DataModel.Common.ConvertLinuxTime(endTime) + "</EndTime>");
			else
				sb.Append("<EndTime>0</EndTime>");

			if (status != 0)
				sb.Append("<TaskOpt>" + status + "</TaskOpt>");
			else
				sb.Append("<TaskOpt>0</TaskOpt>");

			sb.Append("<TaskName>" + taskname + "</TaskName>");

			sb.Append("</TaskInfo>");
			sb.Append("</TaskList></Request>");
			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_MDF_TASK_REQ, sb.ToString());
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return;


			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices MDF_TASK retVal:{0}", 0));

		}
        public void MDF_TASK( uint taskid, uint priority, DateTime startTime, DateTime endTime, string taskname)
        {
			MDF_TASK( taskid, priority, startTime, endTime, 0, taskname);
		}
        public void PAUSE_REALTIME_TASK( uint taskid)
        {
			MDF_TASK( taskid, 0, new DateTime(), new DateTime(), 1, "");

		}
        public void RESUME_REALTIME_TASK( uint taskid)
        {
			MDF_TASK(taskid, 0, new DateTime(), new DateTime(), 2, "");

		}

		//public TaskInfoV3_1 GET_TASK(uint taskid)
		//{
		//    TaskInfoV3_1 list = new TaskInfoV3_1();
		//    StringBuilder sb = new StringBuilder();
		//    sb.Append("<Request>");
		//    sb.Append("<TaskId>" + taskid + "</TaskId>");
		//    sb.Append("</Request>");

		//    string message = CommProtocol.BuildProtocolBody(MessageCmd.VDM_MSG_GET_TASK_REQ, sb.ToString());
		//    string rsp = Send(message);
		//    if (string.IsNullOrEmpty(rsp))
		//        return new TaskInfoV3_1();

		//    System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
		//    xdoc.LoadXml(rsp);

		//    System.Xml.XmlNode nl = xdoc.SelectSingleNode("//Root/Response/TaskInfo");
		//    TaskInfo tui
		//        = IVX.DataModel.Common.DeserilizeObject<TaskInfo>(nl.OuterXml);
		//    list = new TaskInfoV3_1()
		//    {
		//        AlgthmType = (E_VIDEO_ANALYZE_TYPE)tui.AlgthmType,
		//        AnalyseParam = tui.AnalyseParam,
		//        StartTime = IVX.DataModel.Common.ConvertLinuxTime(tui.StartTime),
		//        CameraID = tui.CameraID,
		//        ChannelID = tui.ChannelID,
		//        DeviceIP = tui.DeviceIP,
		//        DeviceName = tui.DeviceName,
		//        DevicePort = tui.DevicePort,
		//        DeviceType = (E_VDA_NET_STORE_DEV_PROTOCOL_TYPE)tui.DeviceType,
		//        EndTime = IVX.DataModel.Common.ConvertLinuxTime(tui.EndTime),
		//        FileSize = tui.FileSize,
		//        LoginPwd = tui.LoginPwd,
		//        LoginUser = tui.LoginUser,
		//        OriFilePath = tui.OriFilePath,
		//        ProtocolType = (E_VDA_NET_STORE_DEV_PROTOCOL_TYPE)tui.ProtocolType,
		//        Status = (E_VDA_TASK_STATUS)tui.Status,
		//        StoreIP = tui.StoreIP,
		//        StorePort = tui.StorePort,
		//        TaskId = tui.TaskId,
		//        FileType = (TaskFileType)tui.FileType,
		//        Priority = tui.Priority,
		//        TaskName = tui.TaskName,
		//        TaskType = (TaskType)tui.TaskType,
		//         LeftTime = tui.LeftTime,
		//          Order = tui.Order,
		//           UserHandle = tui.UserHandle,
		//    };

		//    MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_TASK retVal taskid:" + taskid));
		//    return list;

		//}
        public TaskInfoV3_1 GET_TASK(uint taskid)
        {
			return m_taskList.ToList().Find(item => item.TaskId == taskid);
		}

		//public List<TaskInfoV3_1> GET_TASK_LIST()
		//{

		//    //List<TaskInfoV3_1> list1 = new List<TaskInfoV3_1>();
		//    //Random r = new Random((int)DateTime.Now.Ticks);
		//    //for (int i = 0; i < 100; i++)
		//    //{
		//    //    int count = r.Next(200);
		//    //    for (int j = 0; j < count; j++)
		//    //    {
		//    //        list1.Add(new TaskInfoV3_1() { TaskId = (uint)(i * 1000 + j), TaskName = "sssss" + (i * 1000 + j), StartTime = DateTime.Today.AddDays(-i) });
		//    //    }
		//    //}

		//    //return list1;
		//    MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_TASK_LIST "));

		//    List<TaskInfoV3_1> list = new List<TaskInfoV3_1>();

		//    string message = CommProtocol.BuildProtocolBody<VDM_MSG_GET_TASK_LIST_REQ>(MessageCmd.VDM_MSG_GET_TASK_LIST_REQ, new VDM_MSG_GET_TASK_LIST_REQ { });
		//    string rsp = Send(message);
		//    if (string.IsNullOrEmpty(rsp))
		//        return new List<TaskInfoV3_1>();

		//    System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
		//    xdoc.LoadXml(rsp);

		//    System.Xml.XmlNodeList nl = xdoc.SelectNodes("//Root/Response/TaskList/TaskInfo");
		//    foreach (System.Xml.XmlNode item in nl)
		//    {
		//        TaskInfo tui
		//            = IVX.DataModel.Common.DeserilizeObject<TaskInfo>(item.OuterXml);
		//        TaskInfoV3_1 t = new TaskInfoV3_1()
		//        {
		//            AlgthmType =  (E_VIDEO_ANALYZE_TYPE )tui.AlgthmType,
		//            AnalyseParam = tui.AnalyseParam,
		//            StartTime = IVX.DataModel.Common.ConvertLinuxTime(tui.StartTime),
		//            CameraID = tui.CameraID,
		//            ChannelID = tui.ChannelID,
		//            DeviceIP = tui.DeviceIP,
		//            DeviceName = tui.DeviceName,
		//            DevicePort = tui.DevicePort,
		//            DeviceType = (E_VDA_NET_STORE_DEV_PROTOCOL_TYPE)tui.DeviceType,
		//            EndTime = IVX.DataModel.Common.ConvertLinuxTime(tui.EndTime),
		//            FileSize = tui.FileSize,
		//            LoginPwd = tui.LoginPwd,
		//            LoginUser = tui.LoginUser,
		//            OriFilePath = tui.OriFilePath,
		//            ProtocolType = (E_VDA_NET_STORE_DEV_PROTOCOL_TYPE)tui.ProtocolType,
		//            Status = (E_VDA_TASK_STATUS)tui.Status,
		//            StoreIP = tui.StoreIP,
		//            StorePort = tui.StorePort,
		//            TaskId = tui.TaskId,
		//            FileType =  ( TaskFileType)tui.FileType,
		//               Priority = tui.Priority,
		//            TaskName = tui.TaskName,
		//            TaskType =   (TaskType)tui.TaskType,
		//            LeftTime = tui.LeftTime,
		//            Order = tui.Order,
		//            UserHandle = tui.UserHandle,

		//        };
		//        list.Add(t);
		//    }

		//    MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_TASK_LIST retVal:count:{0}", list.Count));
		//    return list;

		//}
		public List<TaskInfoV3_1> GET_TASK_LIST( ) {
			if (thGetTask.ThreadState == System.Threading.ThreadState.Unstarted)
				thGetTask.Start(  );

			return isTaskListInited ? m_taskList.ToList() : null;
		}
        private List<TaskInfoV3_1> TASK_PAGING( uint pageIndex, uint percount, out uint totalcount)
        {
			totalcount = 0;
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices TASK_PAGING pageIndex:{0},percount:{1}"
				, pageIndex, percount));

			List<TaskInfoV3_1> list = new List<TaskInfoV3_1>();

			StringBuilder sb = new StringBuilder();
			sb.Append("<Request>");
			sb.Append("<PagerNum>" + pageIndex + "</PagerNum>");
			sb.Append("<EveryPagerCount>" + percount + "</EveryPagerCount>");
			sb.Append("<Order></Order>");
			sb.Append("<TaskTypeList>");
			sb.Append("</TaskTypeList>");
			sb.Append("<AnalyseTypeList>");
			sb.Append("</AnalyseTypeList>");
			sb.Append("<StatusList>");
			sb.Append("</StatusList>");
			sb.Append("</Request>");
			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_TASK_PAGING_REQ, sb.ToString());
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return new List<TaskInfoV3_1>();

			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			try {
				totalcount = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/Total").InnerText);
			}
			catch { }
			StringBuilder outtmp = new StringBuilder();
			System.Xml.XmlNodeList nl = xdoc.SelectNodes("//Root/Response/TaskList/TaskInfo");
			foreach (System.Xml.XmlNode item in nl) {
				TaskInfo tui
					= IVX.DataModel.Common.DeserilizeObject<TaskInfo>(item.OuterXml);
				TaskInfoV3_1 t = new TaskInfoV3_1() {
					StatusList = new List<StatusInfoV3_1>(),
					StartTime = IVX.DataModel.Common.ConvertLinuxTime(tui.StartTime),
					CameraID = tui.CameraID,
					ChannelID = tui.ChannelID,
					DeviceIP = tui.DeviceIP,
					DeviceName = tui.DeviceName,
					DevicePort = tui.DevicePort,
					DeviceType = (E_VDA_NET_STORE_DEV_PROTOCOL_TYPE)tui.DeviceType,
					EndTime = IVX.DataModel.Common.ConvertLinuxTime(tui.EndTime),
					FileSize = tui.FileSize,
					LoginPwd = tui.LoginPwd,
					LoginUser = tui.LoginUser,
					OriFilePath = tui.OriFilePath,
					ProtocolType = (E_VDA_NET_STORE_DEV_PROTOCOL_TYPE)tui.ProtocolType,
					StoreIP = tui.StoreIP,
					StorePort = tui.StorePort,
					TaskId = tui.TaskId,
					FileType = (TaskFileType)tui.FileType,
					Priority = tui.Priority,
					TaskName = tui.TaskName,
					TaskType = (TaskType)tui.TaskType,
					Order = tui.Order,
					UserHandle = tui.UserHandle,


				};
				foreach (StatusInfo it in tui.StatusList) {
					t.StatusList.Add(new StatusInfoV3_1() {
						AlgthmType = (E_VIDEO_ANALYZE_TYPE)it.AlgthmType,
						Progress = it.Progress,
						AnalyseParam = it.AnalyseParam,
						LeftTime = it.LeftTime,
						Status = (E_VDA_TASK_STATUS)it.Status,
					});
				}
				if (tui.StatusList.Count == 0)
					t.StatusList.Add(new StatusInfoV3_1() {
						AlgthmType = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE,
						Progress = 1000,
						AnalyseParam = "",
						LeftTime = 0,
						Status = E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FINISH,
					});
				t.StatusList.Sort((it1, it2) => it1.AlgthmType.CompareTo(it2.AlgthmType));
				outtmp.Append(t.TaskId + "|");
				list.Add(t);
			}
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices TASK_PAGING retVal:count:{0},ids:{1}", list.Count, outtmp.ToString()));
			return list;

		}
        public List<TaskInfoV3_1> TASK_PAGING(uint pageIndex, uint percount, E_TASK_GET_SORT_TYPE order, List<uint> tasktype, List<uint> anatype, List<uint> taskstat, out uint totalcount)
        {
			if (!isTaskListInited) {
				totalcount = 0;
				return null;
			}
			var temp = m_taskList.ToList();
			switch (order) {
				case E_TASK_GET_SORT_TYPE.E_TASK_GET_SORT_TYPE_NOUSE:
					break;
				case E_TASK_GET_SORT_TYPE.E_TASK_GET_SORT_TYPE_TIME_ASC:
					temp.Sort((it1, it2) => { return it1.TaskId.CompareTo(it2.TaskId); });
					break;
				case E_TASK_GET_SORT_TYPE.E_TASK_GET_SORT_TYPE_TIME_DESC:
					temp.Sort((it1, it2) => { return 0 - it1.TaskId.CompareTo(it2.TaskId); });
					break;
				default:
					break;
			}
			temp = temp.FindAll(item => {
				bool isfind = true;

				if (tasktype != null && tasktype.Count > 0)
					isfind = isfind && tasktype.Contains((uint)item.TaskType);

				//if(anatype!=null && anatype.Count>0)
				//   isfind = isfind && anatype.Contains( (uint)item.AlgthmType);

				//if(taskstat!=null && taskstat.Count>0)
				//   isfind = isfind && taskstat.Contains( (uint)item.Status);

				return isfind;
			});
			totalcount = (uint)temp.Count;


			int startindex = (int)((pageIndex - 1) * percount);
			int getcount = (int)percount;
			var start = temp.ElementAtOrDefault(startindex);
			var end = temp.ElementAtOrDefault(startindex + getcount);
			if (start == null) {
				return new List<TaskInfoV3_1>();
			}
			if (end == null)
				getcount = temp.Count - startindex;

			return temp.GetRange(startindex, getcount);

		}
        public List<TaskProgressInfoV3_1> GET_TASK_PROGRESS( List<uint> taskIdList)
        {
			var temp = m_taskList.ToList();

			List<TaskProgressInfoV3_1> list = new List<TaskProgressInfoV3_1>();
			for (int i = 0; i < taskIdList.Count; i++) {
				var task = temp.Find(it => it.TaskId == taskIdList[i]);
				if (task != null) {
					TaskProgressInfoV3_1 p = new TaskProgressInfoV3_1() { TaskId = task.TaskId, StatusList = new List<StatusInfoV3_1>(), };
					p.StatusList.Add(new StatusInfoV3_1() {
						AlgthmType = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE,
						AnalyseParam = "",
						Progress = 0,
						Status = E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE,
					});
					list.Add(p);
				}

			}
			return list;

		}
        private List<TaskProgressInfoV3_1> GET_TASK_PROGRESS_BASE( List<uint> taskIdList)
        {
			if (taskIdList == null || taskIdList.Count <= 0)
				return new List<TaskProgressInfoV3_1>();
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_TASK_PROGRESS taskId count:{0}", taskIdList.Count));

			StringBuilder sb = new StringBuilder();
			sb.Append("<Request><TaskList>");
			taskIdList.ForEach(item => sb.Append("<TaskInfo><TaskId>" + item + "</TaskId></TaskInfo>"));
			sb.Append("</TaskList></Request>");

			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_GET_TASK_PROGRESS_REQ, sb.ToString());
			string rsp = Send(message);

			if (string.IsNullOrEmpty(rsp))
				return new List<TaskProgressInfoV3_1>();

			List<TaskProgressInfoV3_1> list = new List<TaskProgressInfoV3_1>();
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			sb = new StringBuilder();
			foreach (System.Xml.XmlNode item in xdoc.SelectNodes("//Root/Response/TaskList/TaskInfo")) {
				uint taskId = Convert.ToUInt32(item.SelectSingleNode("TaskId").InnerText);
				TaskProgressInfoV3_1 p = new TaskProgressInfoV3_1() { TaskId = taskId, StatusList = new List<StatusInfoV3_1>(), };
				foreach (System.Xml.XmlNode sitem in item.SelectNodes("StatusInfo")) {
					uint stat = Convert.ToUInt32(sitem.SelectSingleNode("Status").InnerText);
					uint progress = Convert.ToUInt32(sitem.SelectSingleNode("Progress").InnerText);
					uint anatype = Convert.ToUInt32(sitem.SelectSingleNode("AlgthmType").InnerText);
					uint leftTime = Convert.ToUInt32(sitem.SelectSingleNode("LeftTime").InnerText);

					p.StatusList.Add(new StatusInfoV3_1() {
						AlgthmType = (E_VIDEO_ANALYZE_TYPE)anatype,
						Status = (E_VDA_TASK_STATUS)stat,
						Progress = progress,
						LeftTime = leftTime,
						AnalyseParam = "",
					});
					list.Add(p);
					sb.AppendFormat(" {0}-{4}|{1}|{2}|{3};", taskId, stat, progress, leftTime, anatype);
				}
			}

			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_TASK_PROGRESS retVal sb:{0}", sb.ToString()));
			return list;
		}
        public bool TASK_REANALYSE( uint taskId, E_VIDEO_ANALYZE_TYPE analyseType, string analyseParam, uint splitTime = 0)
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices TASK_REANALYSE taskId:{0},analyseType:{1}", taskId, analyseType));

			VDM_MSG_TASK_REANALYSE_REQ VDM_MSG_TASK_REANALYSE_REQ = new Live.CommServices.VDM_MSG_TASK_REANALYSE_REQ() {
				AnalyseParam = analyseParam,
				Other = "",
				AnalyseType = (uint)analyseType,
				SplitTime = splitTime,
				TaskId = taskId,
			};
			string message = CommProtocol.BuildProtocolBody<VDM_MSG_TASK_REANALYSE_REQ>( Context ,MessageCmd.VDM_MSG_TASK_REANALYSE_REQ, VDM_MSG_TASK_REANALYSE_REQ);
			string rsp = Send(message);
			bool retVal = true;
			if (string.IsNullOrEmpty(rsp))
				retVal = false;

			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices TASK_REANALYSE retVal:{0}", retVal));
			return true;
		}
        public bool ADD_TASK_ANALYSETYPE( uint taskId, E_VIDEO_ANALYZE_TYPE analyseType, string analyseParam, uint splitTime = 0)
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices ADD_TASK_ANALYSETYPE taskId:{0},analyseType:{1}", taskId, analyseType));

			VDM_MSG_ADD_TASK_ANALYSETYPE_REQ VDM_MSG_ADD_TASK_ANALYSETYPE_REQ = new Live.CommServices.VDM_MSG_ADD_TASK_ANALYSETYPE_REQ() {
				AnalyseParam = analyseParam,
				Other = "",
				AnalyseType = (uint)analyseType,
				SplitTime = splitTime,
				TaskId = taskId,
			};
			string message = CommProtocol.BuildProtocolBody<VDM_MSG_ADD_TASK_ANALYSETYPE_REQ>( Context ,MessageCmd.VDM_MSG_ADD_TASK_ANALYSETYPE_REQ, VDM_MSG_ADD_TASK_ANALYSETYPE_REQ);
			string rsp = Send(message);
			bool retVal = true;
			if (string.IsNullOrEmpty(rsp))
				retVal = false;

			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices ADD_TASK_ANALYSETYPE retVal:{0}", retVal));
			return true;
		}
        public bool DEL_TASK_ANALYSETYPE( uint taskId, E_VIDEO_ANALYZE_TYPE analyseType)
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices DEL_TASK_ANALYSETYPE taskId:{0},analyseType:{1}", taskId, analyseType));

			VDM_MSG_DEL_TASK_ANALYSETYPE_REQ VDM_MSG_DEL_TASK_ANALYSETYPE_REQ = new Live.CommServices.VDM_MSG_DEL_TASK_ANALYSETYPE_REQ() {
				AnalyseType = (uint)analyseType,
				TaskId = taskId,
			};
			string message = CommProtocol.BuildProtocolBody<VDM_MSG_DEL_TASK_ANALYSETYPE_REQ>( Context ,MessageCmd.VDM_MSG_DEL_TASK_ANALYSETYPE_REQ, VDM_MSG_DEL_TASK_ANALYSETYPE_REQ);
			string rsp = Send(message);
			bool retVal = true;
			if (string.IsNullOrEmpty(rsp))
				retVal = false;

			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices DEL_TASK_ANALYSETYPE retVal:{0}", retVal));
			return true;
		}
		public List<UploadTaskInfoV3_1> GET_DOWN_LOAD_LIST( ) {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_DOWN_LOAD_LIST "));

			string message = CommProtocol.BuildProtocolBody<VDM_MSG_GET_DOWN_LOAD_LIST_REQ>( Context ,MessageCmd.VDM_MSG_GET_DOWN_LOAD_LIST_REQ, new VDM_MSG_GET_DOWN_LOAD_LIST_REQ { });
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return new List<UploadTaskInfoV3_1>();

			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);

			System.Xml.XmlNodeList nl = xdoc.SelectNodes("//Root/Response/DownList/DownInfo");
			List<UploadTaskInfoV3_1> list = new List<UploadTaskInfoV3_1>();
			StringBuilder sb = new StringBuilder();
			foreach (System.Xml.XmlNode item in nl) {
				UploadTaskInfoV3_1 tui
					= IVX.DataModel.Common.DeserilizeObject<UploadTaskInfoV3_1>(item.OuterXml.Replace("DownInfo", "UploadTaskInfoV3_1"));

				list.Add(tui); sb.AppendFormat("{0}:{1},", tui.MssServerIp, tui.TaskId);
			}

			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_DOWN_LOAD_LIST retVal:sb:{0}", sb.ToString()));
			return list;
		}
		public void ADD_TEMPLATE() {
		}
		public void DEL_TEMPLATE() {
		}
		public void MDF_TEMPLATE() {
		}
		public void GET_TEMPLATE() {
		}
		public void GET_TEMPLATE_LIST() {
		}
        public uint ADD_TRANS_EVENT( uint taskId, uint templateId, E_TRANCE_STORE_TYPE storeType, string storeServerIP, uint storeServerPort, E_TRANS_PROTOCOL_TYPE transProtocol, E_VIDEO_ANALYZE_TYPE analyseType)
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices ADD_TRANS_EVENT taskId:{0} "
				+ ",templateId:{1} "
				+ ",storeType:{2} "
				+ ",storeServerIP:{3} "
				+ ",storeServerPort:{4} "
				+ ",transProtocol:{5} "
				+ ",analyseType:{6} "
				, taskId
				, templateId
				, storeType
				, storeServerIP
				, storeServerPort
				, transProtocol
				, analyseType
				));
			VDM_MSG_ADD_TRANS_EVENT_REQ VDM_MSG_ADD_TRANS_EVENT_REQ = new Live.CommServices.VDM_MSG_ADD_TRANS_EVENT_REQ() {
				TaskId = taskId,
				StoreType = (uint)storeType,
				TemplateId = templateId,
				StoreServerIP = storeServerIP,
				StoreServerPort = storeServerPort,
				TransProtocol = (uint)transProtocol,
				AnalyseType = (uint)analyseType,
			};

			string message = CommProtocol.BuildProtocolBody<VDM_MSG_ADD_TRANS_EVENT_REQ>( Context ,MessageCmd.VDM_MSG_ADD_TRANS_EVENT_REQ, VDM_MSG_ADD_TRANS_EVENT_REQ);
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return 0;

			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			uint id = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/EventId").InnerText);

			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices ADD_TRANS_EVENT id:{0}", id.ToString()));
			return id;

		}
        public void DEL_TRANS_EVENT( uint id)
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices DEL_TRANS_EVENT id:{0}", id));
			StringBuilder sb = new StringBuilder();
			sb.Append("<Request>");
			sb.Append("<EventId>" + id + "</EventId>");
			sb.Append("</Request>");

			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_DEL_TRANS_EVENT_REQ, sb.ToString());
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return;

			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices DEL_TRANS_EVENT retVal:{0}", 0));

		}
		public void MDF_TRANS_EVENT() {
		}
		public void GET_TRANS_EVENT() {
		}
		public List<TransEvnetInfo> GET_TRANS_EVENT_LIST() {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_TRANS_EVENT_LIST "));


			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_GET_TRANS_EVENT_LIST_REQ, "");
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return new List<TransEvnetInfo>();

			List<TransEvnetInfo> list = new List<TransEvnetInfo>();
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);

			System.Xml.XmlNodeList nl = xdoc.SelectNodes("//Root/Response/TransEventList/TransEvent");
			foreach (System.Xml.XmlNode item in nl) {
				TransEvent tui
					= IVX.DataModel.Common.DeserilizeObject<TransEvent>(item.OuterXml);
				TransEvnetInfo t = new TransEvnetInfo() {
					EventID = tui.EventId,
					TaskID = tui.TaskId,
					MergeStyle = tui.TemplateId,
					ProtocolType = (E_TRANS_PROTOCOL_TYPE)tui.TransProtocol,
					ReceiveIp = tui.StoreServerIP,
					ReceivePort = tui.StoreServerPort,
					StoreStyle = (E_TRANCE_STORE_TYPE)tui.StoreType,
					AnalyseType = (E_VIDEO_ANALYZE_TYPE)tui.AnalyseType,
				};
				list.Add(t);
			}

			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_TRANS_EVENT_LIST retVal cout:{0}", list.Count));
			return list;

		}

        public List<TransEvnetInfo> GET_TASK_EVENT_LIST(uint taskid)
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_TASK_EVENT_LIST taskid:" + taskid));

			StringBuilder sb = new StringBuilder();
			sb.Append("<Request>");
			sb.Append("<TaskId>" + taskid + "</TaskId>");
			sb.Append("</Request>");

			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_GET_TASK_EVENT_LIST_REQ, sb.ToString());
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return new List<TransEvnetInfo>();

			List<TransEvnetInfo> list = new List<TransEvnetInfo>();
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);

			System.Xml.XmlNodeList nl = xdoc.SelectNodes("//Root/Response/TransEventList/TransEvent");
			foreach (System.Xml.XmlNode item in nl) {
				TransEvent tui
					= IVX.DataModel.Common.DeserilizeObject<TransEvent>(item.OuterXml);
				TransEvnetInfo t = new TransEvnetInfo() {
					EventID = tui.EventId,
					TaskID = tui.TaskId,
					MergeStyle = tui.TemplateId,
					ProtocolType = (E_TRANS_PROTOCOL_TYPE)tui.TransProtocol,
					ReceiveIp = tui.StoreServerIP,
					ReceivePort = tui.StoreServerPort,
					StoreStyle = (E_TRANCE_STORE_TYPE)tui.StoreType,
					AnalyseType = (E_VIDEO_ANALYZE_TYPE)tui.AnalyseType,
				};
				list.Add(t);
			}

			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_TASK_EVENT_LIST retVal cout:{0}", list.Count));
			return list;

		}

		public void TASK_PROGRESS_NTF() {
		}
		public void MSS_REQUEST_TASK() {
		}
		public void REQUEST_VIDEO_STREAM() {
		}
		public void SEND_VIDEO_STREAM() {
		}
		public void ADD_MSS_TASK() {
		}
		public void DEL_MSS_TASK() {
		}
        public TaskStroreInfoV3_1 GET_RESULT_STORE_LIST( string cameraCode, E_VIDEO_ANALYZE_TYPE anaType)
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_RESULT_STORE_LIST cameraCode:{0},anaType:{1}", cameraCode, anaType));
			StringBuilder sb = new StringBuilder();
			sb.Append("<Request><RequestList>");
			sb.Append("<RequestInfo><CameraID>" + cameraCode + "</CameraID><AlgthmType>" + (int)anaType + "</AlgthmType ></RequestInfo>");
			sb.Append("</RequestList></Request>");

			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_GET_RESULT_STORE_LIST_REQ, sb.ToString());
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return new TaskStroreInfoV3_1();

			TaskStroreInfoV3_1 info = new TaskStroreInfoV3_1();
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			sb = new StringBuilder();
			System.Xml.XmlNode item = xdoc.SelectSingleNode("//Root/Response/StroretLIst/StroreInfo");

			if (item == null) {
				MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_RESULT_STORE_LIST retVal NULL"));

				return null;
			}
			string CameraID = item.SelectSingleNode("CameraID").InnerText;
			string ip = item.SelectSingleNode("StoreIP").InnerText;
			uint port = Convert.ToUInt32(item.SelectSingleNode("StortPort").InnerText);
			int AlgthmType = Convert.ToInt32(item.SelectSingleNode("AlgthmType").InnerText);

			info = new TaskStroreInfoV3_1() {
				AlgthmType = (E_VIDEO_ANALYZE_TYPE)AlgthmType,
				CameraID = CameraID,
				StoreIP = ip,
				StortPort = port,
			};
			sb.AppendFormat(" CameraID:{0},ip:{1},port:{2},AlgthmType:{3}", CameraID, ip, port, AlgthmType);


			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_RESULT_STORE_LIST retVal sb:{0}", sb.ToString()));
			return info;

		}

        public List<TaskStroreInfoV3_1> GET_RESULT_STORE_LIST(E_VIDEO_ANALYZE_TYPE anaType)
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_RESULT_STORE_LIST cameraCode:{0},anaType:{1}", "", anaType));
			StringBuilder sb = new StringBuilder();
			sb.Append("<Request><RequestList>");
			sb.Append("<RequestInfo><CameraID></CameraID><AlgthmType>" + (int)anaType + "</AlgthmType ></RequestInfo>");
			sb.Append("</RequestList></Request>");

			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_GET_RESULT_STORE_LIST_REQ, sb.ToString());
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return new List<TaskStroreInfoV3_1>();

			List<TaskStroreInfoV3_1> infoList = new List<TaskStroreInfoV3_1>() { };
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			sb = new StringBuilder();
			System.Xml.XmlNodeList itemList = xdoc.SelectNodes("//Root/Response/StroretLIst/StroreInfo");

			if (itemList == null) {
				MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_RESULT_STORE_LIST retVal NULL"));
				return null;
			}

			foreach (System.Xml.XmlNode item in itemList) {
				string CameraID = item.SelectSingleNode("CameraID").InnerText;
				string ip = item.SelectSingleNode("StoreIP").InnerText;
				uint port = Convert.ToUInt32(item.SelectSingleNode("StortPort").InnerText);
				int AlgthmType = Convert.ToInt32(item.SelectSingleNode("AlgthmType").InnerText);

				TaskStroreInfoV3_1 info = new TaskStroreInfoV3_1() {
					AlgthmType = (E_VIDEO_ANALYZE_TYPE)AlgthmType,
					CameraID = CameraID,
					StoreIP = ip,
					StortPort = port,
				};
				infoList.Add(info);
				sb.AppendFormat(" CameraID:{0},ip:{1},port:{2},AlgthmType:{3}", CameraID, ip, port, AlgthmType);
			}

			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GET_RESULT_STORE_LIST retVal sb:{0}", sb.ToString()));
			return infoList;

		}

        public List<TaskMSSInfoV3_1> QUERY_TASK_MSS(List<uint> taskIdList)
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices QUERY_TASK_MSS taskId count:{0}", taskIdList.Count));
			StringBuilder sb = new StringBuilder();
			sb.Append("<Request><TaskList>");
			taskIdList.ForEach(item => sb.Append("<TaskInfo><TaskId>" + item + "</TaskId></TaskInfo>"));
			sb.Append("</TaskList></Request>");

			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_QUERY_TASK_MSS_REQ, sb.ToString());
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return new List<TaskMSSInfoV3_1>();

			List<TaskMSSInfoV3_1> list = new List<TaskMSSInfoV3_1>();
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			sb = new StringBuilder();
			foreach (System.Xml.XmlNode item in xdoc.SelectNodes("//Root/Response/TaskList/TaskInfo")) {
				uint taskId = Convert.ToUInt32(item.SelectSingleNode("TaskId").InnerText);
				string ip = item.SelectSingleNode("MssHostIp").InnerText;
				uint port = Convert.ToUInt32(item.SelectSingleNode("MssHostPort").InnerText);
				string videopath = item.SelectSingleNode("VideoPath").InnerText;

				list.Add(new TaskMSSInfoV3_1() { TaskId = taskId, MssHostIp = ip, MssHostPort = port, VideoPath = videopath, });
				sb.AppendFormat(" taskid:{0},ip:{1},port:{2},videopath:{3}", taskId, ip, port, videopath);
			}

			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices QUERY_TASK_MSS retVal sb:{0}", sb.ToString()));
			return list;

		}

        public List<TaskBriefMSSInfoV3_1> QUERY_BRIEF_TASK(List<uint> taskIdList)
        {
			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices QUERY_BRIEF_TASK taskId count:{0}", taskIdList.Count));
			StringBuilder sb = new StringBuilder();
			sb.Append("<Request><TaskList>");
			taskIdList.ForEach(item => sb.Append("<TaskInfo><TaskId>" + item + "</TaskId></TaskInfo>"));
			sb.Append("</TaskList></Request>");

			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_QUERY_BRIEF_TASK_REQ, sb.ToString());
			string rsp = Send(message);
			if (string.IsNullOrEmpty(rsp))
				return new List<TaskBriefMSSInfoV3_1>();

			List<TaskBriefMSSInfoV3_1> list = new List<TaskBriefMSSInfoV3_1>();
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			sb = new StringBuilder();
			foreach (System.Xml.XmlNode item in xdoc.SelectNodes("//Root/Response/TaskList/TaskInfo")) {
				uint taskId = Convert.ToUInt32(item.SelectSingleNode("TaskId").InnerText);
				string ip = item.SelectSingleNode("HostIp").InnerText;
				uint port = Convert.ToUInt32(item.SelectSingleNode("HostPort").InnerText);
				string videopath = item.SelectSingleNode("BriefDataPath").InnerText;
				string indexpath = item.SelectSingleNode("BriefIndexPath").InnerText;

				list.Add(new TaskBriefMSSInfoV3_1() { TaskId = taskId, MssHostIp = ip, MssHostPort = port, BriefDataPath = videopath, BriefIndexPath = indexpath, });
				sb.AppendFormat(" taskid:{0},ip:{1},port:{2},BriefDataPath:{3},BriefIndexPath:{4}", taskId, ip, port, videopath, indexpath);
			}

			MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices QUERY_BRIEF_TASK retVal sb:{0}", sb.ToString()));
			return list;

		}

		// 获取日志信息
        public List<LogSearchResultInfo> GET_LOG_LIST_DATA(LogSearchParam param)
        {

			VDM_MSG_GET_LOG_LIST_REQ req = new VDM_MSG_GET_LOG_LIST_REQ() {
				StartTime = Common.ConvertLinuxTime(param.BeginTime),
				EndTime = Common.ConvertLinuxTime(param.EndTime),
				LogLevel = (UInt32)param.LogLevel,
				OptName = param.OptName,
				LogType = (UInt32)param.LogType,
				SortKind = (UInt32)param.SortKind,
				StartMum = param.StartMum,
				LogCount = param.LogCount,
			};
			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_GET_LOG_LIST_REQ, req.ToString());
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol start GET_LOG_LIST_DATA");
			string rsp = Send(message);
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol End   GET_LOG_LIST_DATA");
			if (string.IsNullOrEmpty(rsp)) return null;
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			List<LogSearchResultInfo> logInfoList = new List<LogSearchResultInfo> { };
			System.Xml.XmlNodeList xmlNodes = xdoc.SelectNodes("//Root/Response/LogList/LogInfo");
			foreach (System.Xml.XmlNode valueNode in xmlNodes) {
				LogSearchResultInfo logInfo = new LogSearchResultInfo();
				logInfo.OptName = valueNode.SelectSingleNode("OptName").InnerText;
				logInfo.LogTime = Common.ConvertLinuxTime(Convert.ToUInt32(valueNode.SelectSingleNode("Time").InnerText)).ToString("yyyy/MM/dd HH:mm:ss");
				logInfo.Description = valueNode.SelectSingleNode("Description").InnerText;
				logInfo.Level = (E_VDA_LOG_LEVEL)Convert.ToInt32(valueNode.SelectSingleNode("LogLevel").InnerText);
				logInfo.LogType = (E_VDA_LOG_TYPE)Convert.ToInt32(valueNode.SelectSingleNode("LogType").InnerText);
				logInfoList.Add(logInfo);
			}

			//List<LogSearchResultInfo> logInfoList = new List<LogSearchResultInfo> { };
			//for (int i = 0; i < 100; i++) 
			//{
			//    LogSearchResultInfo logInfo = new LogSearchResultInfo();
			//    logInfo.OptName = "lp";
			//    logInfo.LogTime = "00:00:00";
			//    logInfo.Level = (E_VDA_LOG_LEVEL)(i%3);
			//    logInfo.LogType = (E_VDA_LOG_TYPE)(i % 3);
			//    logInfo.Description = "登陆";
			//    logInfoList.Add(logInfo);
			//}
			return logInfoList;
		}

		// 获取用户信息
		public List<UserInfo> GET_USER_LIST_DATA() {
			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_GET_USER_LIST_REQ, "");
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol start GET_USER_LIST_DATA");
			string rsp = Send(message);
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol End   GET_USER_LIST_DATA");
			if (string.IsNullOrEmpty(rsp))
				return null;
			List<UserInfo> userList = new List<UserInfo> { };
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			System.Xml.XmlNodeList xmlNodes = xdoc.SelectNodes("//Root/Response/UserList/UserInfo");
			foreach (System.Xml.XmlNode valueNode in xmlNodes) {
				UserInfo userInfo = new UserInfo();
				userInfo.UserHandle = Convert.ToUInt32(valueNode.SelectSingleNode("UserHandle").InnerText);
				userInfo.UserName = valueNode.SelectSingleNode("UserName").InnerText;
				userInfo.UserPwd = valueNode.SelectSingleNode("Password").InnerText;
				userInfo.RightMask = Convert.ToUInt32(valueNode.SelectSingleNode("RightMask").InnerText);
				userInfo.UserRoleType = Convert.ToUInt32(valueNode.SelectSingleNode("UserRole").InnerText);
				userInfo.other = valueNode.SelectSingleNode("Other").InnerText;
				userList.Add(userInfo);
			}
			return userList;
		}

		// 添加指定用户  0表示添加成功
        public UInt32 ADD_USER_INFO_REQ(UserInfo usrInfo)
        {
			VDM_MSG_ADD_USER_INFO_REQ req = new VDM_MSG_ADD_USER_INFO_REQ() {
				UserName = usrInfo.UserName,
				Password = usrInfo.UserPwd,
				UserRole = usrInfo.UserRoleType,
				RightMask = 777,
				other = usrInfo.other,
			};
			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_ADD_USER_REQ, req.ToString());
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol start ADD_USER_INFO_REQ");
			string rsp = Send(message);
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol End   ADD_USER_INFO_REQ");
			if (string.IsNullOrEmpty(rsp))
				return 1;
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			UInt32 retVal = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/Result").InnerText);
			// 如果添加成功 获得新的 userHandel
			if (retVal == 0) {
				usrInfo.UserHandle = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/UserHandle").InnerText);
			}
			else {
				usrInfo.other = xdoc.SelectSingleNode("//Root/Response/Describe").InnerText;
			}
			return retVal;
		}

		// 删除指定用户  0表示删除成功
        public UInt32 DEL_USER_INFO_REQ( UInt32 userHandle)
        {
			StringBuilder req = new StringBuilder();
			req.AppendLine("<Request>");
			req.AppendLine("<UserHandle>" + userHandle + "</UserHandle>");
			req.AppendLine("</Request>");
			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_DEL_USER_REQ, req.ToString());
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol start DEL_USER_INFO_REQ");
			string rsp = Send(message);
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol End   DEL_USER_INFO_REQ");
			if (string.IsNullOrEmpty(rsp))
				return 1;
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			UInt32 retVal = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/Result").InnerText);
			return retVal;
		}

		// 修改指定用户  0表示修改成功
        public UInt32 MOD_USER_INFO_REQ( UserInfo usrInfo)
        {
			VDM_MSG_MOD_USER_INFO_REQ req = new VDM_MSG_MOD_USER_INFO_REQ() {
				UserHandle = usrInfo.UserHandle,
				UserName = usrInfo.UserName,
				Password = usrInfo.UserPwd,
				UserRole = usrInfo.UserRoleType,
				RightMask = 777,
				other = usrInfo.other,
			};
			string message = CommProtocol.BuildProtocolBody( Context ,MessageCmd.VDM_MSG_MDF_USER_REQ, req.ToString());
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol start MOD_USER_INFO_REQ");
			string rsp = Send(message);
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol End   MOD_USER_INFO_REQ");
			if (string.IsNullOrEmpty(rsp))
				return 1;
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			UInt32 retVal = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/Result").InnerText);
			if (retVal != 0) {
				usrInfo.other = xdoc.SelectSingleNode("//Root/Response/Describe").InnerText;
			}
			return retVal;
		}

		#endregion

		#region Private Functions

		private void tReflashTaskList() {
			while (!isExit) {
				MyLog4Net.Container.Instance.Log.Debug("tReflashTaskList enter");

				uint totalcount = 0;
				List<TaskInfoV3_1> newList = new List<TaskInfoV3_1>();
				uint pageindex = 1;
				bool iserr = false;
				while (true) {
					try {
						var list = TASK_PAGING( pageindex, 1000, out totalcount);
						var progresslist = GET_TASK_PROGRESS_BASE(
							list.Where(it =>
							(it.TaskType == TaskType.History
							&& it.StatusList.Exists(xx => xx.Status != E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FAILED
							&& xx.Status != E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FINISH
							&& xx.Status != E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_FAILED)))
							.Select(it => it.TaskId).ToList());

						for (int i = 0; i < list.Count; i++) {
							var task = progresslist.Find(it => it.TaskId == list[i].TaskId);
							if (task != null) {
								foreach (var item in task.StatusList) {
									var s = list[i].StatusList.Find(xx => xx.AlgthmType == item.AlgthmType);
									if (s != null) {
										s.Progress = item.Progress;
										s.Status = item.Status;
									}
									else {
										list[i].StatusList.Add(new StatusInfoV3_1() {
											AlgthmType = item.AlgthmType,
											AnalyseParam = "",
											Progress = item.Progress,
											Status = item.Status,
										});
									}
								}
							}
						}
						newList.AddRange(list);
						pageindex++;
						if (list.Count < 100)
							break;
					}
					catch (SDKCallException) { totalcount = 0; iserr = true; break; }
				}
				//////////for (int i = 0; i < 20000; i++)
				//////////{
				//////////    newList.Add(new TaskInfoV3_1()
				//////////        {
				//////////            TaskId = (uint)(201 + i),
				//////////            TaskName = "task_" + (10001 + i),
				//////////            TaskType = TaskType.History,
				//////////             StatusList = new List<StatusInfoV3_1>(),
				//////////        });

				//////////}
				if (!iserr) {
					// 计算order的策略
					// 1 任务总状态，完成，失败，导入中，分析中，暂停不计算order
					// 2 优先级，1最高，10最低顺序
					// 3 任务类型，1计划，2历史，3实时顺序
					// 4 任务的编号，标号越小order越小

				}
				if (!iserr) {
					List<TaskInfoV3_1> oldList = m_taskList.ToList();
					m_taskList = newList;

					foreach (var oitem in oldList) {
						if (!newList.Exists(item => item.TaskId == oitem.TaskId)) {
							if (TaskDeleted != null && isTaskListInited)
								TaskDeleted((TaskInfoV3_1)oitem.Clone());
						}
					}
					foreach (var nitem in newList) {
						if (!oldList.Exists(item => item.TaskId == nitem.TaskId)) {
							if (TaskAdded != null && isTaskListInited)
								TaskAdded((TaskInfoV3_1)nitem.Clone());
						}
					}
					foreach (var oitem in oldList) {
						var nitem = newList.Find(item => item.TaskId == oitem.TaskId);
						if (nitem != null && !nitem.Equals(oitem)) {
							if (TaskMonified != null && isTaskListInited)
								TaskMonified((TaskInfoV3_1)nitem.Clone());
						}
					}
					isTaskListInited = true;
				}
				if (newList.Exists(it => it.StatusList.Exists(xx => (int)xx.Status < (int)E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_EXECUTING))) {
					foreach (IVX.DataModel.UploadTaskInfoV3_1 item in GET_DOWN_LOAD_LIST()) {
						if (UpLoadLocalFile != null)
							UpLoadLocalFile(item);
					}
				}
				MyLog4Net.Container.Instance.Log.Debug("tReflashTaskList leave");

				for (int i = 0; i < 100; i++) {
					System.Threading.Thread.Sleep(100);
					if (isExit)
						break;
				}
			}
		}
		private ErrorMsg GetErrorMsg(string rsp) {
			if (string.IsNullOrEmpty(rsp))
				return new ErrorMsg() { Result = 1, ResultDescription = "无此消息", };

			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			ErrorMsg err = new ErrorMsg() {
				Result = Convert.ToUInt32(xdoc.SelectSingleNode("//Root/Response/Result").InnerText),
				ResultDescription = xdoc.SelectSingleNode("//Root/Response/Describe").InnerText,
			};
			return err;
		}

		private string Send(string msg, bool isConnTest = false) {
			string rsp;
			try {
				rsp = CommProtocol.SendProtocol(msg);
				if (FireMessage != null)
					FireMessage("服务器：【" + ServerIP + "】连接成功");

			}
			catch (SDKCallException ex) {
				MyLog4Net.Container.Instance.Log.ErrorWithDebugView(ex.ToString());

				if (ex.ErrorCode == (uint)SDKCallExceptionCode.EndpointNotFound) {
					if (FireMessage != null)
						FireMessage("连接服务器异常");
				}
				else if (ex.ErrorCode == (uint)SDKCallExceptionCode.NetDispatcherFault) {
					if (FireMessage != null)
						FireMessage("数据解析异常，请重试");
				}
				else if (ex.ErrorCode == (uint)SDKCallExceptionCode.Other) {
					if (FireMessage != null)
						FireMessage("连接服务器异常，未知原因");
				}
				return "";
			}
			ErrorMsg err = GetErrorMsg(rsp);
			if (err.Result == (int)SDKCallExceptionCode.UserNotLogin && !isConnTest) {
				if (UserDisConnected != null)
					UserDisConnected("");

			}
			else if (err.Result != 0) {
				throw new SDKCallException(err.Result, err.ResultDescription);
			}
			return rsp;
		}



		#endregion




	}
}
