using System;
using System.Collections.Generic;
using System.Text;

namespace IVX.Live.WSDataReceiveServices
{
public enum EnumProtocolType
{
    SEND_HEARTBEAT = 0x00000001,			// 发送心跳
    ACK_HEARTBEAT = 0x01000001,			// 收到心跳返回
    NOTE_UPLOAD_PLATE_DATA = 0x00000100,	// 车牌数据上传通知
    ACK_UPLOAD_PLATE_DATA = 0x01000100,	// 车牌数据上传成功返回
    NOTE_UPLOAD_TRAFFIC_EVENT = 0x00000200,	// 交通事件数据上传通知
    ACK_UPLOAD_TRAFFIC_EVENT = 0x01000200,	// 交通事件数据上传成功返回
    NOTE_UPLOAD_TRAFFIC_PARAM = 0x00000300,	// 交通参数数据上传通知
    ACK_UPLOAD_TRAFFIC_PARAM = 0x01000300,	// 交通参数数据上传成功返回
    NOTE_UPLOAD_BEHAVIOR_EVENT = 0x00000400,	// 行为事件数据上传通知
    ACK_UPLOAD_BEHAVIOR_EVENT = 0x01000400,   // 行为事件数据上传成功返回
    NOTE_UPLOAD_FACECONTROL_EVENT = 0x00000500,	// 人脸布控数据上传通知
    ACK_UPLOAD_FACECONTROL_EVENT = 0x01000500, //人脸布控数据上传成功返回
    NOTE_UPLOAD_MOVEOBJINFO_DATA = 0x00000600,	//运动物信息数据上传通知
    ACK_UPLOAD_MOVEOBJINFO_DATA = 0x01000600,	//运动物信息数据上传成功返回
    NOTE_UPLOAD_MOVEFEATURE_DATA = 0x00000700,	//运动物特征数据上传通知
    ACK_UPLOAD_MOVEFEATURE_DATA = 0x01000700,	//运动物特征数据上传成功返回
    NOTE_UPLOAD_COLORFEATURE_DATA = 0x00000800,	// 颜色特征数据上传通知
    ACK_UPLOAD_COLORFEATURE_DATA = 0x01000800,	// 颜色特征数据上传成功返回
    NOTE_UPLOAD_SCENEMARK_DATA = 0x00000900,	//运动物场景标定数据上传通知
    ACK_UPLOAD_SCENEMARK_DATA = 0x01000900, //运动物场景标定数据上传成功返回
    NOTE_UPLOAD_CROWD_DATA = 0x00000A00,	// 人群聚集数据上传通知
    ACK_UPLOAD_CROWD_DATA = 0x01000A00,   //人群聚集数据上传成功返回
    NOTE_UPLOAD_PEOPLECOUNT_DATA = 0x00000B00,	// 人数统计数据上传通知
    ACK_UPLOAD_PEOPLECOUNT_DATA = 0x01000B00,   //人数统计数据上传成功返回
    NOTE_UPLOAD_PEOPLECOUNTALARM_EVENT = 0x00000C00, //人数统计报警数据上传通知
    ACK_UPLOAD_PEOPLECOUNTALARM_EVENT = 0x01000C00,   //人数统计报警数据上传成功返回
    NOTE_IMAGE_SEARCH_DATA = 0x00000D00,  //二次识别数据上传通知（南昌项目定制）
    ACK_IMAGE_SEARCH_DATA = 0x01000D00,  //二次识别数据上传成功返回（南昌项目定制）
    NOTE_TRAFFIC_FEATURE_PARAM_DATA = 0x00000E00,  //交通特征参数上传通知
    ACK_TRAFFIC_FEATURE_PARAM_DATA = 0x01000E00,  //交通特征参数上传成功返回
    NOTE_IMAGE_SEARCH_STD_DATA = 0x00000F00, //二次识别数据上传通知（标准）
    ACK_IMAGE_SEARCH_STD_DATA = 0x01000F00, //二次识别数据上传通知返回（标准）
    NOTE_UPLOAD_MOVEOBJECT_PEOPLE_PUDONG_DATA = 0x00001000, //大框架运动物算法行人两轮车目标信息上传通知（浦东项目使用）
    ACK_UPLOAD_MOVEOBJECT_PEOPLE_PUDONG_DATA = 0x01001000, //大框架运动物算法行人两轮车目标信息上传通知返回（浦东项目使用）
    NOTE_UPLOAD_MOVEOBJECT_VEHICLE_PUDONG_DATA = 0x00001100, //大框架运动物算法车辆目标信息上传通知（浦东项目使用）
    ACK_UPLOAD_MOVEOBJECT_VEHICLE_PUDONG_DATA = 0x01001100, //大框架运动物算法车辆目标信息上传通知返回（浦东项目使用）

    SMS_MSG_FACE_ALARM_DATA_NOTIFY	=		0x00002000 , 	//人脸报警数据推送
    SMS_MSG_FACE_ALARM_DATA_RSP		=	0x01002000 , 	//人脸报警数据回复
    TIMEOUT = 0xEEEE,
}

}

 
