using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    public class RealAnalyseInfo 
    {
        /// <summary>
        /// //分析ID  //UUID
        /// </summary>
        public UInt32 dwAnalysisID { get; set; }

        public RealAnalyseServerUnitInfo realAnalyseServerInfo { get; set; }
        /// <summary>
        /// //分析服务并发ID
        /// </summary>
        public UInt32 dwConSerialNum { get; set; }	

        /// <summary>
        ///  //分析状态
        /// </summary>
        public E_IASSDK_REAL_ANALYZE_STATUS_TYPE eStatusType { get; set; }

        public RealAnalyseParam realAnalyseParam { get; set; }
        
    }
    public class RealAnalyseServerUnitInfo
    { 

        /// <summary>
        /// //分析服务ID
        /// </summary>
        public UInt32 dwServerID { get; set; }		
        /// <summary>
        /// //分析服务IP
        /// </summary>
        public string szServerIp { get; set; }
        /// <summary>
        /// //分析服务端口
        /// </summary>
        public UInt16 wServerPort { get; set; }

        public E_IASSDK_SERVER_UNIT_TYPE serverType { get; set; }
    }

    public class RealAnalyseParam
    {       
        /// <summary>
        /// //算法类型
        /// </summary>
        public E_VIDEO_ANALYZE_TYPE eAlgthmType { get; set; }
        /// <summary>
        /// //分析计划ID
        /// </summary>
        public UInt32 dwAnalysisPlanID { get; set; }

        public RealCameraInfo realCameraInfo { get; set; }
        /// <summary>
        /// //分析参数
        /// </summary>
        public string szAnalysisParam { get; set; }	
        /// <summary>
        /// //分析结果存储服务器IP(网络字节序)
        /// </summary>
        public string szArsIp { get; set; }			
        /// <summary>
        /// //分析结果存储服务器端口
        /// </summary>
        public UInt16 wArsPort { get; set; }		
    }

    public class RealCameraInfo
    {         /// <summary>
        /// //存储相机ID
        /// </summary>
        public string szCameraID { get; set; }
        /// <summary>
        /// //平台类型
        /// </summary>
        public UInt32 dwDeviceType { get; set; }
        /// <summary>
        /// //连接IP地址
        /// </summary>
        public string szDeviceIP { get; set; }
        /// <summary>
        /// //连接端口号
        /// </summary>
        public UInt16 dwDevicePort { get; set; }
        /// <summary>
        /// //登录用户
        /// </summary>
        public string szLoginUser { get; set; }
        /// <summary>
        /// //登录密码	
        /// </summary>
        public string szLoginPwd { get; set; }
        /// <summary>
        /// //平台通道ID
        /// </summary>
        public string szChannelID { get; set; }   


    }

    public class IasRealAnalyzeStatusTypeInfo
    {
        public E_IASSDK_REAL_ANALYZE_STATUS_TYPE Type { get; set; }

        public uint NStatus
        {
            get
            {
                return (uint)Type;
            }
        }

        public string Name { get; set; }

        public IasRealAnalyzeStatusTypeInfo(E_IASSDK_REAL_ANALYZE_STATUS_TYPE type, string name)
        {
            Type = type;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
    public class VideoAnalyzeTypeInfo
    {
        public E_VIDEO_ANALYZE_TYPE Type { get; set; }

        public uint NStatus
        {
            get
            {
                return (uint)Type;
            }
        }

        public string Name { get; set; }

        public VideoAnalyzeTypeInfo(E_VIDEO_ANALYZE_TYPE type, string name)
        {
            Type = type;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
