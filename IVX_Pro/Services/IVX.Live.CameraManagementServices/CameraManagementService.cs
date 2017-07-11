using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using MyLog4Net;


namespace IVX.Live.CameraManagementServices
{
    public class DBManagementService
    {
        private static int PAGE_PER_COUNT = 50;

        private uint m_loginID = 0;
        private string m_serverIP;
        private int m_page = 0;
        
        public string RTRISServerIP { get; set; }

        public string ServerIP
        {
            get { return m_serverIP; }
            set { m_serverIP = value; }
        }
        private string m_connString;

        public bool IsLogin 
        {
            get { return m_loginID > 0; }
        }
        #region Constructors
        public DBManagementService(string connString,string serverIP)
        {
            m_connString = connString;
            m_serverIP = serverIP;
        }


        #endregion

        #region Public helper functions
        public bool Login(out string adpisip, out uint adpisport, out string ridsip, out uint ridsport, out string rtrisip,out uint rtrisport)
        {
            adpisip = "";
            adpisport = 0;
            ridsip = "";
            ridsport = 0;
            rtrisip = "";
            rtrisport = 0;

            using (MySql.Data.MySqlClient.MySqlConnection conn
                = new MySql.Data.MySqlClient.MySqlConnection(string.Format(m_connString, m_serverIP, "vdm_server_db")))
            {
                try
                {
                    string sql = "SELECT * from vda_server_info;";
                    MyLog4Net.Container.Instance.Log.Debug("Login sql:" + sql);

                    conn.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    conn.Close();
                    foreach (DataRow item in table.Rows)
                    {
                        if (Convert.ToInt32(item["SERVER_TYPE"].ToString())
                            == (uint)E_VDA_SERVER_TYPE.E_SERVER_TYPE_ADPIS)
                        {
                            adpisip = item["SERVER_IP"].ToString();
                            adpisport = Convert.ToUInt32(item["SERVER_PORT"].ToString());
                        }
                        if (Convert.ToInt32(item["SERVER_TYPE"].ToString())
                            == (uint)E_VDA_SERVER_TYPE.E_SERVER_TYPE_RIDS)
                        {
                            ridsip = item["SERVER_IP"].ToString();
                            ridsport = Convert.ToUInt32(item["SERVER_PORT"].ToString());
                        }
                        if (Convert.ToInt32(item["SERVER_TYPE"].ToString())
                            == (uint)E_VDA_SERVER_TYPE.E_SERVER_TYPE_RTTIS)
                        {
                            rtrisip = item["SERVER_IP"].ToString();
                            rtrisport = Convert.ToUInt32(item["SERVER_PORT"].ToString());
                        }

                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MyLog4Net.Container.Instance.Log.DebugWithDebugView("Login sql error:" + ex.ToString());

                    return false;
                }

            }

        }

        public List<CameraGroupInfo> GetAllCameraGroup()
        {
            using (MySql.Data.MySqlClient.MySqlConnection conn
                = new MySql.Data.MySqlClient.MySqlConnection(string.Format(m_connString, m_serverIP, "vdm_server_db")))
            {
                try
                {
                    List<CameraGroupInfo> list = new List<CameraGroupInfo>();

                    string sql = "SELECT * FROM `camera_group_info`";
                    MyLog4Net.Container.Instance.Log.Debug("GetAllCameraGroup sql:" + sql);
                    conn.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    foreach (DataRow item in table.Rows)
                    {
                        CameraGroupInfo cameraGroupInfo = new CameraGroupInfo();
                        cameraGroupInfo.CameraGroupID = Convert.ToUInt32( item["ID"].ToString());
                        cameraGroupInfo.ParentGroupID = Convert.ToUInt32( item["PARENT_GROUP"].ToString());
                        cameraGroupInfo.GroupDescription = item["OTHER"].ToString();
                        cameraGroupInfo.GroupName = item["NAME"].ToString();
                        list.Add(cameraGroupInfo);
                    }
                    conn.Close();
                    return list;
                }
                catch (Exception ex)
                {
                    MyLog4Net.Container.Instance.Log.DebugWithDebugView("GetAllCameraGroup sql error:" + ex.ToString());

                    //Framework.Container.Instance.InteractionService.ShowMessageBox("数据库失败",Framework.Environment.PROGRAM_NAME);
                    return new List<CameraGroupInfo>();
                }
            }
        }
        public List<RealtimeCameraInfo> GetCamerasByGroupID(uint groupId)
        {
            using (MySql.Data.MySqlClient.MySqlConnection conn
                = new MySql.Data.MySqlClient.MySqlConnection(string.Format(m_connString, m_serverIP, "vdm_server_db")))
            {
                try
                {
                    List<RealtimeCameraInfo> list = new List<RealtimeCameraInfo>();
                    //string sql = "SELECT * FROM `camera_info` where GROUP_ID="+groupId;
                    string sql = "SELECT"
                        + " cam.ID AS CameraID,"
                        + " cam.`NAME` AS CameraName,"
                        + " cam.GROUP_ID AS GroupID,"
                        + " cam.`CODE` AS CameraCode,"
                        + " cam.COORD_X AS PosCoordX,"
                        + " cam.COORD_Y AS PosCoordY,"
                        + " cam.NET_STORE_DEV_ID AS PlatId,"
                        + " cam.NET_DEV_CHANNEL AS CameraChannelID,"
                        + " dev.ACCESS_PROTOCOL_TYPE AS ProtocolType,"
                        + " dev.DEVICE_IP AS PlatIP,"
                        + " dev.DEVICE_PORT AS PlatPort,"
                        + " dev.LOGIN_USER AS UserName,"
                        + " dev.LOGIN_PWD AS `Password`"
                        + " FROM"
                        + " camera_info AS cam"
                        + " INNER JOIN net_store_dev_info AS dev ON cam.NET_STORE_DEV_ID = dev.ID";
                    
                    if(groupId>0)
                        sql += " where cam.GROUP_ID=" + groupId;

                    
                    conn.Open();
                    MyLog4Net.Container.Instance.Log.Debug("GetCamerasByGroupID sql:" + sql);
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    foreach (DataRow item in table.Rows)
                    {
                        RealtimeCameraInfo cameraInfo = new RealtimeCameraInfo();

                        cameraInfo.CameraID = Convert.ToUInt32(item["CameraID"].ToString());
                        cameraInfo.GroupID = Convert.ToUInt32(item["GroupID"].ToString());
                        cameraInfo.CameraName = item["CameraName"].ToString();
                        cameraInfo.CameraCode = item["CameraCode"].ToString();
                        
                        cameraInfo.PlatId = Convert.ToUInt32(item["PlatId"].ToString());
                        cameraInfo.CameraChannelID = item["CameraChannelID"].ToString();
                        cameraInfo.PosCoordX = Convert.ToSingle(item["PosCoordX"].ToString());
                        cameraInfo.PosCoordY = Convert.ToSingle(item["PosCoordY"].ToString());
                        cameraInfo.Password = item["Password"].ToString();
                        cameraInfo.UserName = item["UserName"].ToString();
                        cameraInfo.PlatIP = item["PlatIP"].ToString();
                        cameraInfo.PlatPort =  Convert.ToUInt32(item["PlatPort"].ToString());
                        cameraInfo.ProtocolType = (E_VDA_NET_STORE_DEV_PROTOCOL_TYPE)Convert.ToUInt32(item["ProtocolType"].ToString());
                        if (string.IsNullOrEmpty(cameraInfo.CameraCode))
                        { 
                            //192.168.137.177_13300_1_34010000001320000001
                            cameraInfo.CameraCode = cameraInfo.PlatIP + "_" + cameraInfo.PlatPort + "_" + (int)cameraInfo.ProtocolType + "_" + cameraInfo.CameraChannelID;
                        }
                        list.Add(cameraInfo);
                    }

                    conn.Close();
                    list.Sort((it1, it2) => it1.CameraName.CompareTo(it2.CameraName));
                    return list;
                }
                catch (Exception ex)
                {
                    MyLog4Net.Container.Instance.Log.DebugWithDebugView("GetCamerasByGroupID sql error:" + ex.ToString());
                    //Framework.Container.Instance.InteractionService.ShowMessageBox("数据库失败", Framework.Environment.PROGRAM_NAME);
                    return new List<RealtimeCameraInfo>();
                }
            }
        }
        public List<CrowdInfo> QueryCrowdData(DateTime startT, DateTime endT, RealtimeCameraInfo[] SelectedCrowdCameraInfo)
        {        
            List<CrowdInfo> CrowdDatas = new List<CrowdInfo>();

            string cameras = "";
            string startTime = Convert.ToUInt64(startT.Subtract(DataModel.Common.ZEROTIME).TotalSeconds).ToString();
            string endTime = Convert.ToUInt64(endT.Subtract(DataModel.Common.ZEROTIME).TotalSeconds).ToString();
            if (SelectedCrowdCameraInfo != null && SelectedCrowdCameraInfo.Length > 0)
            {
                foreach (var item in SelectedCrowdCameraInfo)
                {
                    cameras += "\"" + item.CameraCode + "\",";
                }
                cameras = cameras.TrimEnd(',');
            }
            using (MySql.Data.MySqlClient.MySqlConnection conn
                = new MySql.Data.MySqlClient.MySqlConnection(string.Format(m_connString, RTRISServerIP, "rtrs_server_db")))
            {
                try
                {
                    string sql = "SELECT"
                        + " info.ID,"
                        + " info.CAMERA_CODE,"
                        + " info.TIME_MILLI_SEC,"
                        + " info.PEOPLE_COUNT,"
                        + " info.REGION_AREA,"
                        + " info.REGION_POINT_NUM,"
                        + " info.REGION_POINT,"
                        + " info.RESERVED"
                        + " FROM"
                        + " rt_crowd_result_info AS info "
                        + " WHERE info.TIME_MILLI_SEC BETWEEN \"" + startTime + "\" AND \"" + endTime + "\"";


                    if (!string.IsNullOrEmpty(cameras))
                        sql += " AND info.CAMERA_CODE in (" + cameras + ")";
                    MyLog4Net.Container.Instance.Log.Debug("QueryData sql:" + sql);
                    conn.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    conn.Close();

                    CrowdDatas = new List<CrowdInfo>();
                    foreach (DataRow item in table.Rows)
                    {
                        CrowdInfo info = new CrowdInfo();
                        info.ID = Convert.ToUInt64(item["ID"].ToString());
                        info.CameraCode = item["CAMERA_CODE"].ToString();
                        info.TimeSec = DataModel.Common.ZEROTIME.AddSeconds(Convert.ToUInt64(item["TIME_MILLI_SEC"].ToString()));
                        info.PeopleCount = Convert.ToUInt32(item["PEOPLE_COUNT"].ToString());
                        info.RegionArea = Convert.ToUInt32(item["REGION_AREA"].ToString());
                        string[] ps = item["REGION_POINT"].ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                        List<Point> listps = new List<Point>();
                        for (int i = 0; i < ps.Length; i += 2)
                        {
                            listps.Add(new Point(Convert.ToInt32(ps[i]), Convert.ToInt32(ps[i + 1])));
                        }
                        info.RegionPoints = listps;//691/84/1852/142/1891/1020/716/1036/
                        //byte[] bytes1 = (byte[])item["HOT_IMAGE_BUFFER"];
                        //int len1 = Convert.ToInt32(item["HOT_IMAGE_LEN"].ToString());
                        //info.HotImage = BOCOM.RealtimeProtocol.Model.ModelParser.GetImage(bytes1, len1);
                        //byte[] bytes2 = (byte[])item["DIRECTION_IMAGE_BUFFER"];
                        //int len2 = Convert.ToInt32(item["DIRECTION_IMAGE_LEN"].ToString());
                        //info.DirectionImage = BOCOM.RealtimeProtocol.Model.ModelParser.GetImage(bytes2, len2);
                        //byte[] bytes3 = (byte[])item["ORIGINAL_IMAGE_BUFFER"];
                        //int len3 = Convert.ToInt32(item["ORIGINAL_IMAGE_LEN"].ToString());
                        //info.OriginaloImage = BOCOM.RealtimeProtocol.Model.ModelParser.GetImage(bytes3, len3);

                        CrowdDatas.Add(info);
                    }
                    return CrowdDatas;
                    //if (FinishQueryData != null)
                    //    FinishQueryData(CrowdDatas, null);

                }
                catch (Exception ex)
                {
                    MyLog4Net.Container.Instance.Log.DebugWithDebugView("QueryCrowdData sql error:" + ex.ToString());

                    //Framework.Container.Instance.InteractionService.ShowMessageBox("数据库失败", Framework.Environment.PROGRAM_NAME);
                    return new List<CrowdInfo>();
                }
            }

        }


        public Image GetCrowdImageByID(ulong id)
        {
            using (MySql.Data.MySqlClient.MySqlConnection conn
                = new MySql.Data.MySqlClient.MySqlConnection(string.Format(m_connString, RTRISServerIP, "rtrs_server_db")))
            {
                try
                {

                    string sql = "select "
                        //+ " img.HOT_IMAGE_LEN,"
                        //+ " img.HOT_IMAGE_BUFFER,"
                        //+ " img.DIRECTION_IMAGE_LEN,"
                        //+ " img.DIRECTION_IMAGE_BUFFER,"
                       + " img.ORIGINAL_IMAGE_LEN,"
                       + " img.ORIGINAL_IMAGE_BUFFER"
                       + " FROM"
                       + " rt_crowd_image_info AS img"
                       + " where id = \"" + id + "\"";

                    MyLog4Net.Container.Instance.Log.Debug("GetCrowdImageByID sql:" + sql);
                    conn.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    conn.Close();
                    Image img = null;
                    if (table.Rows.Count > 0)
                    {
                        byte[] bytes3 = (byte[])table.Rows[0]["ORIGINAL_IMAGE_BUFFER"];
                        int len3 = Convert.ToInt32(table.Rows[0]["ORIGINAL_IMAGE_LEN"].ToString());
                        img = IVX.DataModel.Common.GetImage(bytes3, len3);
                    }
                    else
                        img = null;

                    return img;
                }
                catch (Exception ex)
                {
                    MyLog4Net.Container.Instance.Log.DebugWithDebugView("GetCrowdImageByID sql error:" + ex.ToString());

                    //Framework.Container.Instance.InteractionService.ShowMessageBox("数据库失败", Framework.Environment.PROGRAM_NAME);
                    return null;
                }
            }

        }
        public List<Image> GetCrowdImageAllByID(ulong id)
        {
            using (MySql.Data.MySqlClient.MySqlConnection conn
                = new MySql.Data.MySqlClient.MySqlConnection(string.Format(m_connString, RTRISServerIP, "rtrs_server_db")))
            {
                List<Image> list = new List<Image>();
                try
                {

                    string sql = "select "
                        + " img.HOT_IMAGE_LEN,"
                        + " img.HOT_IMAGE_BUFFER,"
                        + " img.DIRECTION_IMAGE_LEN,"
                        + " img.DIRECTION_IMAGE_BUFFER,"
                       + " img.ORIGINAL_IMAGE_LEN,"
                       + " img.ORIGINAL_IMAGE_BUFFER"
                       + " FROM"
                       + " rt_crowd_image_info AS img"
                       + " where id = \"" + id + "\"";

                    MyLog4Net.Container.Instance.Log.Debug("GetCrowdImageByID sql:" + sql);
                    conn.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    conn.Close();
                    Image img1 = null;
                    Image img2 = null;
                    Image img3 = null;
                    if (table.Rows.Count > 0)
                    {
                        byte[] bytes3 = (byte[])table.Rows[0]["ORIGINAL_IMAGE_BUFFER"];
                        int len3 = Convert.ToInt32(table.Rows[0]["ORIGINAL_IMAGE_LEN"].ToString());
                        img3 = IVX.DataModel.Common.GetImage(bytes3, len3);
                        list.Add(img3);
                        byte[] bytes1 = (byte[])table.Rows[0]["HOT_IMAGE_BUFFER"];
                        int len1 = Convert.ToInt32(table.Rows[0]["HOT_IMAGE_LEN"].ToString());
                        img1 = IVX.DataModel.Common.GetImage(bytes1, len1);
                        list.Add(img1);
                        byte[] bytes2 = (byte[])table.Rows[0]["DIRECTION_IMAGE_BUFFER"];
                        int len2 = Convert.ToInt32(table.Rows[0]["DIRECTION_IMAGE_LEN"].ToString());
                        img2 = IVX.DataModel.Common.GetImage(bytes2, len2);
                        list.Add(img2);
                    }

                    return list;
                }
                catch (Exception ex)
                {
                    MyLog4Net.Container.Instance.Log.DebugWithDebugView("GetCrowdImageByID sql error:" + ex.ToString());

                    //Framework.Container.Instance.InteractionService.ShowMessageBox("数据库失败", Framework.Environment.PROGRAM_NAME);
                    return list;
                }
            }

        }
        public List<PlateInfo> QueryPlateData(DateTime startT, DateTime endT, RealtimeCameraInfo[] SelectedCrowdCameraInfo, string plateNum, uint vehicleColor, uint plateColor, IVX.Controls.DAO.VehicleBrand[] m_CheckedVehicleModels, long m_Brand, int m_NVehicleDetailType, bool isStart = true)
        {
            List<PlateInfo> PlateDatas = new List<PlateInfo>();

            m_page = isStart ? 0 : m_page;
            string cameras = "";
            string startTime = Convert.ToUInt64(startT.Subtract(DataModel.Common.ZEROTIME).TotalSeconds).ToString();
            string endTime = Convert.ToUInt64(endT.Subtract(DataModel.Common.ZEROTIME).TotalSeconds).ToString();
            if (SelectedCrowdCameraInfo != null && SelectedCrowdCameraInfo.Length > 0)
            {
                foreach (var item in SelectedCrowdCameraInfo)
                {
                    cameras += "\"" + item.CameraCode + "\",";
                }
                cameras = cameras.TrimEnd(',');
            }
            string modelids = "";
            if (m_CheckedVehicleModels != null && m_CheckedVehicleModels.Length > 0)
            {
                foreach (var item in m_CheckedVehicleModels)
                {
                    modelids += "\"" + item.Id + "\",";

                }
                modelids = modelids.TrimEnd(',');
            }
            //string m_Brand = "";
            //string plateNum = "";
            //string m_NVehicleDetailType = "";

            using (MySql.Data.MySqlClient.MySqlConnection conn
                = new MySql.Data.MySqlClient.MySqlConnection(string.Format(m_connString, RTRISServerIP, "rtrs_server_db")))
            {
                try
                {
                    string sql = "SELECT "
                        + " info.ID, "
                        + " info.CAMERA_CODE, "
                        + " info.TIME_STAMP_SEC, "
                        + " info.TIME_STAMP_MILLI_SEC, "
                        + " info.OBJECT_TYPE, "
                        + " info.RELIABILITY, "
                        + " info.PLATE_NUM, "
                        + " info.PLATE_NUM_ROW, "
                        + " info.PLATE_COLOR, "
                        + " info.VEHICLE_COLOR, "
                        + " info.VEHICLE_TYPE, "
                        + " info.VEHICLE_TYPE_DETAIL, "
                        + " info.VEHICLE_LABEL, "
                        + " info.VEHICLE_LABEL_DETAIL, "
                        + " info.VEHICLE_SPEED, "
                        + " info.DIRECTION, "
                        + " info.ROAD_WAY_NUM, "
                        + " info.PLATE_COORDX, "
                        + " info.PLATE_COORDY, "
                        + " info.PLATE_COORD_WIDTH, "
                        + " info.PLATE_COORD_HEIGHT, "
                        + " info.PLATE_IMG_SIZE, "
                        + " info.PLAT_IMG_DATA, "
                        + " info.VEHIBODY_COORDX, "
                        + " info.VEHIBODY_COORDY, "
                        + " info.VEHIBODY_COORD_WIDTH, "
                        + " info.VEHIBODY_COORD_HEIGHT, "
                        + " info.FULL_IMG_WIDTH, "
                        + " info.FULL_IMG_HEIGHT, "
                        + " info.COMPOSE_IMG_WIDTH, "
                        + " info.COMPOSE_IMG_HEIGHT "
                        + " FROM rt_vehicle_detect_info as info "
                        + " WHERE info.TIME_STAMP_SEC BETWEEN \"" + startTime + "\" AND \"" + endTime + "\"";

                    if (!string.IsNullOrEmpty(cameras))
                        sql += " AND info.CAMERA_CODE in (" + cameras + ")";

                    if (vehicleColor != 0)
                        sql += " AND info.VEHICLE_COLOR = " + vehicleColor;

                    if (plateColor != 0)
                        sql += " AND info.PLATE_COLOR = " + plateColor;

                    if (m_Brand != -1)
                        sql += " AND info.VEHICLE_LABEL = " + m_Brand;

                    if (m_NVehicleDetailType != 0)
                        sql += " AND info.VEHICLE_TYPE_DETAIL = " + m_NVehicleDetailType;

                    if (!string.IsNullOrEmpty(modelids))
                        sql += " AND info.VEHICLE_LABEL_DETAIL in (" + modelids + ")";

                    if (!string.IsNullOrEmpty(plateNum))
                        sql += " AND info.PLATE_NUM like \"*" + plateNum + "*\"";

                    sql += " LIMIT " + (m_page++) * PAGE_PER_COUNT + "," + PAGE_PER_COUNT;

                    MyLog4Net.Container.Instance.Log.Debug("QueryData sql:" + sql);

                    conn.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    conn.Close();


                    foreach (DataRow item in table.Rows)
                    {
                        PlateInfo info = new PlateInfo();
                        info.ID = Convert.ToUInt64(item["ID"].ToString());
                        info.CameraCode = item["CAMERA_CODE"].ToString();
                        info.TimeStampSec = DataModel.Common.ZEROTIME.AddSeconds(Convert.ToUInt32(item["TIME_STAMP_SEC"].ToString())).AddMilliseconds(Convert.ToUInt64(item["TIME_STAMP_MILLI_SEC"].ToString()));
                        info.ObjectType = Convert.ToUInt32(item["OBJECT_TYPE"].ToString());
                        info.Reliability = Convert.ToUInt32(item["RELIABILITY"].ToString());
                        info.PlateNum = item["PLATE_NUM"].ToString();
                        info.PlateNumRow = Convert.ToUInt32(item["PLATE_NUM_ROW"].ToString());
                        info.PlateColor = Convert.ToUInt32(item["PLATE_COLOR"].ToString());
                        info.VehicleColor = Convert.ToUInt32(item["VEHICLE_COLOR"].ToString());
                        info.VehicleType = Convert.ToUInt32(item["VEHICLE_TYPE"].ToString());
                        info.VehicleTypeDetail = Convert.ToUInt32(item["VEHICLE_TYPE_DETAIL"].ToString());
                        info.VehicleLabelID = Convert.ToUInt32(item["VEHICLE_LABEL"].ToString());
                        info.VehicleLabelDetailID = Convert.ToUInt32(item["VEHICLE_LABEL_DETAIL"].ToString());
                        info.VehicleSpeed = Convert.ToUInt32(item["VEHICLE_SPEED"].ToString());
                        info.Direction = Convert.ToUInt32(item["DIRECTION"].ToString());
                        info.RoadWayNum = Convert.ToUInt32(item["ROAD_WAY_NUM"].ToString());
                        info.PlateCoordRect = new Rectangle(Convert.ToInt32(item["PLATE_COORDX"].ToString()), Convert.ToInt32(item["PLATE_COORDY"].ToString()), Convert.ToInt32(item["PLATE_COORD_WIDTH"].ToString()), Convert.ToInt32(item["PLATE_COORD_HEIGHT"].ToString()));

                        byte[] bytes3 = (byte[])item["PLAT_IMG_DATA"];
                        int len3 = Convert.ToInt32(item["PLATE_IMG_SIZE"].ToString());
                        info.PlateImgData = IVX.DataModel.Common.GetImage(bytes3, len3);

                        info.VehiBodyCoordRect = new Rectangle(Convert.ToInt32(item["VEHIBODY_COORDX"].ToString()), Convert.ToInt32(item["VEHIBODY_COORDY"].ToString()), Convert.ToInt32(item["VEHIBODY_COORD_WIDTH"].ToString()), Convert.ToInt32(item["VEHIBODY_COORD_HEIGHT"].ToString()));
                        info.FullImgSize = new Size(Convert.ToInt32(item["FULL_IMG_WIDTH"].ToString()), Convert.ToInt32(item["FULL_IMG_HEIGHT"].ToString()));
                        info.ComposeImgSize = new Size(Convert.ToInt32(item["COMPOSE_IMG_WIDTH"].ToString()), Convert.ToInt32(item["COMPOSE_IMG_HEIGHT"].ToString()));

                        PlateDatas.Add(info);
                    }

                    return PlateDatas;

                }
                catch (Exception ex)
                {
                    MyLog4Net.Container.Instance.Log.DebugWithDebugView("QueryPlateData sql error:" + ex.ToString());

                    //Framework.Container.Instance.InteractionService.ShowMessageBox("数据库失败", Framework.Environment.PROGRAM_NAME);
                    return new List<PlateInfo>();
                }
            }

        }
                
        public Image GetPlateImageByID(ulong id)
        {
                    
            using (MySql.Data.MySqlClient.MySqlConnection conn
                = new MySql.Data.MySqlClient.MySqlConnection(string.Format(m_connString, RTRISServerIP, "rtrs_server_db")))
            {
                try
                {

                    string sql = "select "
                       + " img.FULL_IMG_SIZE,"
                       + " img.FULL_IMG_DATA"
                       + " FROM"
                       + " rt_vehicle_detect_info AS img"
                       + " where id = \"" + id + "\"";

                    MyLog4Net.Container.Instance.Log.Debug("GetPlateImageByID sql:" + sql);

                    conn.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    conn.Close();
                    Image img = null;
                    if (table.Rows.Count > 0)
                    {
                        byte[] bytes3 = (byte[])table.Rows[0]["FULL_IMG_DATA"];
                        int len3 = Convert.ToInt32(table.Rows[0]["FULL_IMG_SIZE"].ToString());
                        img = IVX.DataModel.Common.GetImage(bytes3, len3);
                    }
                    else
                        img = null;

                    return img;
                }
                catch (Exception ex)
                {
                    MyLog4Net.Container.Instance.Log.DebugWithDebugView("GetPlateImageByID sql error:" + ex.ToString());

                    //Framework.Container.Instance.InteractionService.ShowMessageBox("数据库失败", Framework.Environment.PROGRAM_NAME);
                    return null;
                }
            }

        }


        #endregion
        
        #region Event handlers

        #endregion
    }
}
