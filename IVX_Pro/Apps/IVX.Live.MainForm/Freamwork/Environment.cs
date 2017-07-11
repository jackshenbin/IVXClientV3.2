using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using IVX.DataModel;
//using BOCOM.IVX.Views;

namespace IVX.Live.MainForm.Framework
{
    public class Environment
    {
        #region Fields

        [Flags]
        public enum E_PRODUCT_TYPE
        {
            RELEASE = 0,
            NO_LOGO = 0x01,
            ONLY_BRIEF = 0x02,
            WITH_BIG_DATA = 0x04,
            TianJin_PRODUCT = 0x08,
            NO_CHECK_VERTION = 0x10,
            PuDong_PRODUCT = 0x20,
        }

        public enum E_VIDEOCLOSE_TYPE
        {
            WITH_OS = 0,
            CLOSE=1,
            NOCLOSE=2,
        }
        public static readonly string PROGRAM_NAME = "博康视频侦查系统 V3.2";
        public static readonly SystemMenu DefaultViewPage = new SystemMenu { URL = "FormTaskManagementMA", Title = "历史任务列表", Discription = "离线分析任务列表", };
        public static readonly SystemMenu DefaultLoginPage = new SystemMenu { URL = "FormLogin", Title = "系统登录", Discription = "系统登录",  };
        //public static readonly E_PRODUCT_TYPE PRODUCT_TYPE = E_PRODUCT_TYPE.RELEASE;
        public static long MAX_VIRTUAL_SIZE = (long)1600 * 1024 * 1024;
        public static long MAX_PRIVATE_SIZE = (long)700 * 1024 * 1024;
        public static readonly int MAX_TASKUNIT_UPLOAD_COUNT = 100;


        private static string s_Version = "";
        private static string s_SDKVersion = "";
        private static bool s_RememberPassword = false;

        private static bool s_Loggedin;

        private static bool s_IsBeingLogout;

        private static Control s_MainControl;


        #endregion

        #region Properties
        public static string ConnString
        {
            get { return "Server={0};Database={1};Uid=root;Pwd=bocom;pooling=false;charset=gbk"; }
        } //= "Server={0};Database=;Uid=root;Pwd=bocom;pooling=false;charset=gbk";

        //public static string LocalIP { get; set; }
        //public static uint LocalPort { get; set; }
        public static string LocalCommIP { get; set; }
        public static string GisMapPath { get; set; }
        public static string RTRISServerIP { get; set; }
        public static uint RTRISPort { get; set; }
        public static uint UploadAbility { get; set; }
		public static uint BehaviourDataReceivePort { get; set; }
		public static uint TrafficEventDataReceivePort { get; set; }
        //public static Encoding FTPEncoding { get; set; }
		public static uint AlarmReceivePort { get; set; }

        public static string ServerIP { get; set; }
		public static UserInfo CurUserInfo { get; set; }

        public static bool BvgShareSimulateType { get; set; }

        public static bool ShareSimulate { get; set; }

        public static string BvgShareSimuPath { get; set; }

        public static string AcepedVideoFile { get; set; }

        public static bool isNeedSearchPlay { get; set; }

        public static int FileUploadSize { get; set; }

        public static bool CaseType { get; set; }

        public static E_VIDEOCLOSE_TYPE VideoCloseType { get; set; }

        public static Dictionary<int, string> DTGroupId2Name { get; set; }

        //public static TUSER_INFO CurrentUser
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(s_User.szUserName))
        //        {
        //            ICASProtocol.Vda_GetCurUserInfo(out s_User);
        //        }
        //        return s_User;
        //    }
        //}

        public static bool IsLoggedIn
        {
            get
            {
                return s_Loggedin;
            }
        }

        public static string VideoSavePath { get; set; }

        public static bool SavePassword
        {
            get
            {
                return s_RememberPassword;
            }
            set
            {
                if (s_RememberPassword != value)
                {
                    s_RememberPassword = value;
                    if (!s_RememberPassword)
                    {
                        CurUserInfo.UserPwd = string.Empty;
                    }
                }
            }
        }

        public static string PictureSavePath { get; set; }

        public static string Version
        {
            get
            {
                if (String.IsNullOrEmpty(s_Version))
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Version v = assembly.GetName().Version;
                    string fileVersion = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
                    string dateTime = (new DateTime(2000, 1, 1)).AddDays(v.Build).AddSeconds(v.Revision * 2).ToString("yyyyMMddHHmmss");
                    //dllimport加载dll非常耗时，启动时显示sdk版本，触发加载dll
                    //s_SDKVersion = IVXRealtimeProtocol.IasSdk_GetSdkVersion();
                    s_Version = string.Format("Ver:{0} ({1})", fileVersion, dateTime);
                }
                return s_Version;
            }
        }
        public static string SDKVersion
        {
            get
            {
                if (String.IsNullOrEmpty(s_SDKVersion))
                {
                    //s_SDKVersion = IVXRealtimeProtocol.IasSdk_GetSdkVersion();
                }
                return s_SDKVersion;

            }
        }

        public static string AssemblyDirectory
        {
            get;
            set;
        }

        public static string RecentLoadVideoFolder { get; set; }

        /// <summary>
        /// 表示是否正在登出 （注销）
        /// </summary>
        public static bool IsBeingLogout
        {
            get
            {
                return s_IsBeingLogout;
            }
            set
            {
                s_IsBeingLogout = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool IsCloseMainForm { get; set; }

        public static int DefaultPageIndex
        {
            get
            {
                return 0;
            }
        }

        //public static int DefaultCountPerPage
        //{
        //    get
        //    {
        //        int count = 25;

        //        if (SearchResultDisplayMode == DataModel.SearchResultDisplayMode.GridViewOneSearchItem)
        //        {
        //            count = 50;
        //        }
        //        else if (SearchResultDisplayMode == DataModel.SearchResultDisplayMode.ThumbNailAllSearchItem)
        //        {
        //            count = 10;
        //        }
        //        return count;
        //    }
        //}
        
        public static SortType SortType
        {
            get;
            set;
        }


        public static AxvodocxLib.Axvodocx VODPlayControler { get; set; }
        public static AxbriefocxLib.Axbriefocx BriefPlayControler { get; set; }
        //public static SearchResultDisplayMode SearchResultDisplayMode
        //{
        //    get
        //    {
        //        return s_SearchResultDisplayMode;
        //    }
        //    set
        //    {
        //        s_SearchResultDisplayMode = value;
        //    }
        //}

        //public static SearchResultDisplayMode GetDisplayMode(SearchType searchType)
        //{
        //    return s_DTSearchType2DisplayMode[searchType];
        //}

        //public static void SetDisplayMode(SearchType searchType, SearchResultDisplayMode mode)
        //{
        //    s_DTSearchType2DisplayMode[searchType] = mode;
        //}

        //public static string GetWebFileService { set; get; }

        //public static string GetFtpFileService { set; get; }

        #endregion

        #region Constructors

        public static void Init()
        {
        }

        static Environment()
        {
            //s_DTSearchType2DisplayMode.Add(SearchType.Normal, DataModel.SearchResultDisplayMode.ThumbNailAllSearchItem);
            //s_DTSearchType2DisplayMode.Add(SearchType.Face, DataModel.SearchResultDisplayMode.ThumbNailAllSearchItem);
            //s_DTSearchType2DisplayMode.Add(SearchType.Vehicle, DataModel.SearchResultDisplayMode.GridViewOneSearchItem);
            //s_DTSearchType2DisplayMode.Add(SearchType.Compare, DataModel.SearchResultDisplayMode.ThumbNailAllSearchItem);
            //s_DTSearchType2DisplayMode.Add(SearchType.VideoPlayNormal, DataModel.SearchResultDisplayMode.ThumbNailAllSearchItem);

            Trace.WriteLine("Entering Envionment static constructor ...");
            //try
            //{
            //    Assembly asm = Assembly.GetExecutingAssembly();
                
            //    string logpath = asm.Location + ".config";
            //    Trace.WriteLine("ReadConfig:" + logpath);
            //    if (!File.Exists(logpath))
            //    {
            //        File.WriteAllText(logpath, Properties.Resources.IVX_exe);
            //    }

            //    string path = asm.Location;
            //    path = Path.GetDirectoryName(path);
            //    AssemblyDirectory = path;
            //    Trace.WriteLine("set AssemblyDirectory:" + path);

            //    s_Config = ConfigurationManager.OpenExeConfiguration(asm.Location);

            //}
            //catch (Exception ex)
            //{
            //    Trace.WriteLine(ex.ToString());
            //    MyLog4Net.Container.Instance.Log.Error("OpenExeConfiguration error in Environment: ", ex);
            //}

            //s_Token = new LoginToken(string.Empty, string.Empty, string.Empty);

            if ((Program.PRODUCT_TYPE & Framework.Environment.E_PRODUCT_TYPE.NO_LOGO) > 0)
            {
                Assembly asm = Assembly.GetExecutingAssembly();

                string customization = Path.Combine(Directory.GetParent(asm.Location).FullName, "custom.txt");
                if(System.IO.File.Exists(customization))
                PROGRAM_NAME = System.IO.File.ReadAllText("custom.txt",Encoding.Default);
                else
                PROGRAM_NAME = "视频侦查系统";
                
            }
            Framework.Environment.ReadConfig();

            Trace.WriteLine("begin Vda_Initialize");

            //Framework.Container.Instance.EvtAggregator.GetEvent<UserLoginEvent>().Subscribe(OnUserLoggedIn);
            //Framework.Container.Instance.EvtAggregator.GetEvent<UserLogOutEvent>().Subscribe(OnUserLogout);
            Trace.WriteLine("end Environment");

        }
        #endregion

        #region Public helper functions
        public static bool CheckMemeryUse()
        {
            long VirtualMemorySize64 = Process.GetCurrentProcess().VirtualMemorySize64 ;
            long PrivateMemorySize64 = Process.GetCurrentProcess().PrivateMemorySize64 ;

            bool ret = false;
            if ((VirtualMemorySize64> Framework.Environment.MAX_VIRTUAL_SIZE
                && PrivateMemorySize64 > Framework.Environment.MAX_PRIVATE_SIZE)
                || VirtualMemorySize64> 2900L * 1024 * 1024)
            { ret = false; }
            else
            { ret = true; }

            MyLog4Net.Container.Instance.Log.DebugFormat("CheckMemeryUse ret={2},VirtualMemorySize64:{0},PrivateMemorySize64:{1}", VirtualMemorySize64, PrivateMemorySize64, ret);
            return ret;
        }
        public static int GetDefaultCountPerPage(bool multiSearchItem, SearchResultDisplayMode displayMode)
        {
            int count = 25;

            if (displayMode == DataModel.SearchResultDisplayMode.GridViewOneSearchItem)
            {
                count = 50;
            }
            else if (displayMode == DataModel.SearchResultDisplayMode.ThumbNailAllSearchItem)
            {
                //if (multiSearchItem)
                //{
                //    count = 10;
                //}
            }
            return count;
        }

        public static Dictionary<string, List<SystemMenu>> GetSystemMenu()
        {
            Dictionary<string, List<SystemMenu>> Menu = new Dictionary<string, List<SystemMenu>>();
            XmlDocument xDoc = new XmlDocument();
            Assembly asm = Assembly.GetExecutingAssembly();
            string fileName = System.IO.Path.GetDirectoryName(asm.Location) + "\\ui.xml";
            xDoc.Load(fileName);
            XmlNode xNode = xDoc.SelectSingleNode("//configuration");
            foreach (XmlNode item in xNode.SelectNodes("menu"))
            {
                List<SystemMenu> m = new List<SystemMenu>();
                string name = item.Attributes["name"].InnerText;
                foreach (XmlNode sitem in item.SelectNodes("sub"))
                {
                    SystemMenu sm = new SystemMenu();
                    sm.Title = sitem.InnerText;
                    sm.Discription = sitem.Attributes["des"].InnerText;
                    sm.URL = sitem.Attributes["url"].InnerText;
                    //sm.IsDialog = Convert.ToBoolean( sitem.Attributes["isdialog"].InnerText);
                    //sm.ParentURL = sitem.Attributes["parent"].InnerText;
					if ((Convert.ToUInt32(sitem.Attributes["role"].InnerText) & Convert.ToUInt32(CurUserInfo.UserRoleType)) != 0)
					{
						m.Add(sm);
					}
                }
                Menu.Add(name ,m);
            }
            return Menu;
        }

        public static bool SaveConfig()
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                Assembly asm = Assembly.GetExecutingAssembly();
                //string fileName = asm.Location.ToLower().Replace(".dll", ".app.exe.config");
                string fileName = asm.Location.ToLower() + ".config";
                xDoc.Load(fileName);
                XmlNode xNode = xDoc.SelectSingleNode("//userSettings");
                XmlElement xElemServerIP = (XmlElement)xNode.SelectSingleNode("//setting[@name='ServerIP']");
                xElemServerIP.SelectSingleNode("value").InnerText = Framework.Environment.ServerIP;
                XmlElement xElemSavePassword = (XmlElement)xNode.SelectSingleNode("//setting[@name='SavePassword']");
                xElemSavePassword.SelectSingleNode("value").InnerText = Framework.Environment.SavePassword.ToString();
                XmlElement xElemUserName = (XmlElement)xNode.SelectSingleNode("//setting[@name='UserName']");
                xElemUserName.SelectSingleNode("value").InnerText = Framework.Environment.CurUserInfo.UserName;
                XmlElement xElemPassword = (XmlElement)xNode.SelectSingleNode("//setting[@name='Password']");
                if (!Framework.Environment.SavePassword)
                    xElemPassword.SelectSingleNode("value").InnerText = "";
                else
                    xElemPassword.SelectSingleNode("value").InnerText = DesKey.Encrypt(Framework.Environment.CurUserInfo.UserPwd);

                xDoc.Save(fileName);

                //try
                //{
                //    s_Config = ConfigurationManager.OpenExeConfiguration(asm.Location);
                //}
                //catch (Exception ex)
                //{
                //    MyLog4Net.Container.Instance.Log.Error("OpenExeConfiguration error in Environment: ", ex);
                //}

                return true;
            }
            catch
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("配置文件损坏，系统参数可能无法保存。", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
        
        public static void ReadConfig()
        {
            XmlDocument xDoc = new XmlDocument();
            Assembly asm = Assembly.GetExecutingAssembly();
            //string fileName = asm.Location.ToLower().Replace(".dll", ".app.exe.config");
            string fileName = asm.Location.ToLower()+".config";

            xDoc.Load(fileName);

            Framework.Environment.ServerIP = xDoc.SelectSingleNode("//userSettings//setting[@name='ServerIP']//value").InnerText;

            Framework.Environment.LocalCommIP = xDoc.SelectSingleNode("//userSettings//setting[@name='LocalCommIP']//value").InnerText;

            Framework.Environment.GisMapPath = xDoc.SelectSingleNode("//userSettings//setting[@name='GisMapPath']//value").InnerText;
            if (Framework.Environment.LocalCommIP == "127.0.0.1")
            {
                string hostname = System.Net.Dns.GetHostName();
                System.Net.IPAddress[] ips = System.Net.Dns.GetHostAddresses(hostname);
                foreach (var item in ips)
                {
                    if (item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        Framework.Environment.LocalCommIP = item.ToString();
                        break;
                    }
                }
            }

            Framework.Environment.UploadAbility = Convert.ToUInt32(xDoc.SelectSingleNode("//userSettings//setting[@name='UploadAbility']//value").InnerText);
			Framework.Environment.BehaviourDataReceivePort = Convert.ToUInt32(xDoc.SelectSingleNode("//userSettings//setting[@name='behaviourDataReceivePort']//value").InnerText);
			Framework.Environment.TrafficEventDataReceivePort = Convert.ToUInt32(xDoc.SelectSingleNode("//userSettings//setting[@name='trafficEventDataReceivePort']//value").InnerText);
            Framework.Environment.AlarmReceivePort = Convert.ToUInt32(xDoc.SelectSingleNode("//userSettings//setting[@name='AlarmReceivePort']//value").InnerText);
			
			
            Framework.Environment.SavePassword = Convert.ToBoolean(xDoc.SelectSingleNode("//userSettings//setting[@name='SavePassword']//value").InnerText);
            if (Framework.Environment.CurUserInfo == null)
                Framework.Environment.CurUserInfo = new UserInfo();
            Framework.Environment.CurUserInfo.UserName = xDoc.SelectSingleNode("//userSettings//setting[@name='UserName']//value").InnerText;
            Framework.Environment.CurUserInfo.UserPwd = DesKey.Decrypt(xDoc.SelectSingleNode("//userSettings//setting[@name='Password']//value").InnerText);


            Framework.Environment.VideoSavePath = Path.Combine( Path.GetDirectoryName(asm.Location),"Video");
            if (!Directory.Exists(Framework.Environment.VideoSavePath))
                Directory.CreateDirectory(Framework.Environment.VideoSavePath);
            Framework.Environment.PictureSavePath = Path.Combine(Path.GetDirectoryName(asm.Location), "Picture");
            if (!Directory.Exists(Framework.Environment.PictureSavePath))
                Directory.CreateDirectory(Framework.Environment.PictureSavePath);
        }

        public static Control GetMainControl(bool showNavigationBar)
        {
            //if (s_MainControl == null)
            //{
            //    s_MainControl = new ucMain(showNavigationBar);
            //}
            return s_MainControl;
        }

        public static void Reset()
        {
            if(s_MainControl!=null)
                s_MainControl.Dispose();
            s_MainControl = null;
            s_Loggedin = false;
        }

        public static FtpInfo FtpInfo
        {
            get
            {
                try
                {
                    Assembly asm = Assembly.GetExecutingAssembly();
                    string fileName = Path.Combine(Directory.GetParent(asm.Location).FullName, "ftp.config");
                    string xml = System.IO.File.ReadAllText(fileName);
                    return DataModel.Common.DeserilizeObject<FtpInfo>(xml);
                }
                catch (FileNotFoundException)
                {
                    return new FtpInfo() { IP = "127.0.0.1",Password = "anonymous", UserName = "anonymous", Port = 21, IsAnonymous = true, };
                }
                catch(Exception ex)
                {
                    MyLog4Net.Container.Instance.Log.Error("Environment FtpInfo get error : ", ex);
                    return new FtpInfo() {  IP = "127.0.0.1", Password = "anonymous", UserName = "anonymous", Port = 21, IsAnonymous = true, };
                }
            }
            set 
            {
                try
                {
                    string xml = DataModel.Common.SerilizeObject<FtpInfo>(value);
                    Assembly asm = Assembly.GetExecutingAssembly();
                    string fileName = Path.Combine(Directory.GetParent(asm.Location).FullName, "ftp.config");
                    System.IO.File.WriteAllText(fileName, xml);
                }
                catch(Exception ex)
                { MyLog4Net.Container.Instance.Log.Error("Environment FtpInfo set error: ", ex); }
            }
        }

        #endregion

        #region Private helper functions

       private static void OnUserLoggedIn(LoginToken token)
        {
            //s_Token = token;
            s_Loggedin = true;
            SaveConfig();

        }

        private static void OnUserLogout(object o)
        {
            s_Loggedin = false;
        }

        #endregion


    }
}
