using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{

    /// <summary>
    /// 任务详细信息
    /// </summary>
    [Serializable]
    public class TrafficeEventInfoV3_1: IDisposable
    {
        public Int64 EventId { get; set; }
        public string CameraCode { get; set; }
        public E_TRAFFIC_EVENT_TYPE EventType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public uint ObjRoadWayNum { get; set; }
        public List<Tuple<System.Drawing.Rectangle, System.IO.MemoryStream>> EventImgInfo { get; set; }
        public List<Tuple<System.Drawing.Rectangle, string>> EventImgURLInfo { get; set; }
        public System.IO.MemoryStream ComposeImgData { get; set; }
        public string ComposeImgURL { get; set; }
        public string EventVideoUrl { get; set; }
        public uint Reliability { get; set; }
        public string PlateNum { get; set; }
        public E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE PlateNumRow { get; set; }
        public uint PlateColor { get; set; }
        public uint VehicleColor { get; set; }
        public E_VDA_SEARCH_VEHICLE_TYPE VehicleType { get; set; }
        public E_VDA_SEARCH_VEHICLE_DETAIL_TYPE VehicleTypeDetail { get; set; }
        public uint VehicleLabel { get; set; }
        public uint VehicleLabelDetail { get; set; }
        public uint VehicleSpeed { get; set; }
        public E_VDA_VEHICLE_DRIVE_DIRECTION_TYPE Direction { get; set; }

        public void Dispose()
        {
            if (EventImgInfo != null)
            {
                foreach (var item in EventImgInfo)
                {
                    item.Item2.Dispose();
                    item.Item2.Close();
                }
                EventImgInfo = null;
            }

            if (ComposeImgData != null)
            {
                ComposeImgData.Dispose();
                ComposeImgData = null;
            }
        }

        public void Clear()
        {
            if (EventImgInfo != null)
            {
                foreach (var item in EventImgInfo)
                {
                    item.Item2.Dispose();
                    item.Item2.Close();
                }
                EventImgInfo = null;
            }
        }
    }
    public class TrafficeEventProperty : PropertyBase, IDisposable
    {
        private TrafficeEventInfoV3_1 _Control;
        public TrafficeEventProperty()
        {

        }
        public TrafficeEventProperty(TrafficeEventInfoV3_1 control)
        {
            this._Control = control;
        }
        [MyControlAttibute("相机编号", "基本信息")]
        public string CameraCode
        {
            get { return this._Control.CameraCode; }
        }
        [MyControlAttibute("出现时间", "基本信息")]
        public string StartTime
        {
            get { return this._Control.StartTime.ToString(DataModel.Constant.DATETIME_FORMAT); }
        }
        [MyControlAttibute("消失时间", "基本信息")]
        public string EndTime
        {
            get { return this._Control.EndTime.ToString(DataModel.Constant.DATETIME_FORMAT); }
        }
        [MyControlAttibute("事件类型", "基本信息")]
        public string EventType
        {
            get
            {
                var findobj = DataModel.Constant.TrafficEventTypeInfos.FirstOrDefault(item => item.Type == this._Control.EventType);
                if (findobj != null)
                    return findobj.Name;
                else
                    return "";

            }
        }


        [MyControlAttibute("车牌号", "车辆信息")]
        public string PlateNum
        {
            get
            {
                return string.Format("{0}", this._Control.PlateNum, this._Control.Reliability);
            }
        }

        [MyControlAttibute("车牌颜色", "车辆信息")]
        public string PlateColor
        {
            get
            {
                var findobj = DataModel.Constant.PlateColorInfos.FirstOrDefault(item => item.Type.ID == this._Control.PlateColor);
                if (findobj != null)
                    return findobj.Name;
                else
                    return "";
            }
        }
        [MyControlAttibute("车牌结构", "车辆信息")]
        public string PlateNumRow
        {
            get
            {
                var findobj = DataModel.Constant.VehiclePlateTypeInfos.FirstOrDefault(item => item.Type == this._Control.PlateNumRow);
                if (findobj != null)
                    return findobj.Name;
                else
                    return "";
            }
        }

        [MyControlAttibute("车标", "车辆信息")]
        public string VehicleLabel
        {
            get
            {
                var findobj = DataModel.Constant.VehicleLabelInfos.FirstOrDefault(item => item.Type == this._Control.VehicleLabel);
                if (findobj != null)
                    return findobj.Name;
                else
                    return "";

            }
        }
        [MyControlAttibute("子品牌", "车辆信息")]
        public string VehicleLabelDetail
        {
            get
            {
                var findobj = DataModel.Constant.GetVehicleDetailLabelInfosByParentId(this._Control.VehicleLabel).FirstOrDefault(item => item.Type == this._Control.VehicleLabelDetail);
                if (findobj != null)
                    return findobj.Name;
                else
                    return "";


            }
        }

        [MyControlAttibute("车型", "车辆信息")]
        public string VehicleType
        {
            get
            {
                var findobj = DataModel.Constant.VehicleTypeInfos.FirstOrDefault(item => item.Type == this._Control.VehicleType);
                if (findobj != null)
                    return findobj.Name;
                else
                    return "";
            }
        }

        [MyControlAttibute("车型细分", "车辆信息")]
        public string VehicleTypeDetail
        {
            get
            {
                var findobj = DataModel.Constant.VehicleDetailTypeInfos.FirstOrDefault(item => item.Type == this._Control.VehicleTypeDetail);
                if (findobj != null)
                    return findobj.Name;
                else
                    return "";
            }
        }

        [MyControlAttibute("车身颜色", "车辆信息")]
        public string VehicleColor
        {
            get
            {
                var findobj = DataModel.Constant.VehicleColorInfos.FirstOrDefault(item => item.Type.ID == this._Control.VehicleColor);
                if (findobj != null)
                    return findobj.Name;
                else
                    return "";
            }
        }

        [MyControlAttibute("车速", "车辆信息")]
        public string VehicleSpeed
        {
            get
            {
                return string.Format("{0} KM/H", this._Control.VehicleSpeed);
            }
        }

        [MyControlAttibute("方向", "车辆信息")]
        public string Direction
        {
            get
            {
                var findobj = DataModel.Constant.DriveDirectionTypeInfos.FirstOrDefault(item => item.Type == this._Control.Direction);
                if (findobj != null)
                    return findobj.Name;
                else
                    return "";
            }
        }


        public TrafficeEventInfoV3_1 GetBase()
        {
            return _Control;
        }


        public void Dispose()
        {
            _Control.Dispose();
        }
    }


}
