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
    public class DynamicTrafficPlateInfo : IDisposable
    {
        public long PlateId { get; set; }
        //public uint ObjId { get; set; }
        public string CameraCode { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PlateNum { get; set; }
        public uint Reliability { get; set; }
        public uint PlateColor { get; set; }
        //public E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE PlateNumRow { get; set; }
        //public E_VDA_SEARCH_VEHICLE_TYPE VehicleType { get; set; }
        //public E_VDA_SEARCH_VEHICLE_DETAIL_TYPE VehicleTypeDetail { get; set; }
        //public uint VehicleLabel { get; set; }
        //public uint VehicleLabelDetail { get; set; }
        //public List<uint> VehicleColorInfo { get; set; }
        //public uint DriverIsPhoneing { get; set; }
        //public uint DriverIsPhoneingConf { get; set; }
        //public uint DriverIsSafebelt { get; set; }

        //public uint DriverIsSafebeltConf { get; set; }
        //public uint PassengerIsSafebelt { get; set; }
        //public uint PassengerIsSafebeltCof { get; set; }
        //public uint DriverIsSunVisor { get; set; }
        //public uint DriverIsSunVisorConf { get; set; }
        //public uint PassengerIsSunVisor { get; set; }
        //public uint PassengerIsSunVisorConf { get; set; }
        //public System.Drawing.Rectangle DriverRect { get; set; }
        //public System.Drawing.Rectangle PassengerRect { get; set; }
        //public System.Drawing.Rectangle ObjRect { get; set; }
        //public System.IO.MemoryStream ObjImg { get; set; }
        public System.Drawing.Rectangle PlateRect { get; set; }
        //public System.IO.MemoryStream PlateImg { get; set; }
        //public System.IO.MemoryStream OriginalImage { get; set; }
        public string PlateImgUrl { get; set; }
        public string OrgImgUrl { get; set; }


        public void Dispose()
        {
            //if (ObjImg != null)
            //{
            //    ObjImg.Dispose();
            //    ObjImg = null;
            //}
            //if (PlateImg != null)
            //{
            //    PlateImg.Dispose();
            //    PlateImg = null;
            //}
            //if (OriginalImage != null)
            //{
            //    OriginalImage.Dispose();
            //    OriginalImage = null;
            //}
        }

        public void Clear()
        {
            //if (ObjImg != null)
            //{
            //    ObjImg.Dispose();
            //    ObjImg = null;
            //}
            //if (PlateImg != null)
            //{
            //    PlateImg.Dispose();
            //    PlateImg = null;
            //}
            //if (OriginalImage != null)
            //{
            //    OriginalImage.Dispose();
            //    OriginalImage = null;
            //}
        }
    }
    public class DynamicTrafficePlateProperty : PropertyBase, IDisposable
    {
        private DynamicTrafficPlateInfo _Control;
        public DynamicTrafficePlateProperty()
        {

        }
        public DynamicTrafficePlateProperty(DynamicTrafficPlateInfo control)
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

        [MyControlAttibute("车牌号", "车辆信息")]
        public string PlateNum
        {
            get
            {
                return string.Format("{0}[{1}%]", this._Control.PlateNum, this._Control.Reliability);
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
        //[MyControlAttibute("车牌结构", "车辆信息")]
        //public string PlateNumRow
        //{
        //    get
        //    {
        //        var findobj = DataModel.Constant.VehiclePlateTypeInfos.FirstOrDefault(item => item.Type == this._Control.PlateNumRow);
        //        if (findobj != null)
        //            return findobj.Name;
        //        else
        //            return "";
        //    }
        //}

        //[MyControlAttibute("车标", "车辆信息")]
        //public string VehicleLabel
        //{
        //    get
        //    {
        //        var findobj = DataModel.Constant.VehicleLabelInfos.FirstOrDefault(item => item.Type == this._Control.VehicleLabel);
        //        if (findobj != null)
        //            return findobj.Name;
        //        else
        //            return "";

        //    }
        //}
        //[MyControlAttibute("子品牌", "车辆信息")]
        //public string VehicleLabelDetail
        //{
        //    get
        //    {
        //        var findobj = DataModel.Constant.GetVehicleDetailLabelInfosByParentId(this._Control.VehicleLabel).FirstOrDefault(item => item.Type == this._Control.VehicleLabelDetail);
        //        if (findobj != null)
        //            return findobj.Name;
        //        else
        //            return "";


        //    }
        //}

        //[MyControlAttibute("车型", "车辆信息")]
        //public string VehicleType
        //{
        //    get
        //    {
        //        var findobj = DataModel.Constant.VehicleTypeInfos.FirstOrDefault(item => item.Type == this._Control.VehicleType);
        //        if (findobj != null)
        //            return findobj.Name;
        //        else
        //            return "";
        //    }
        //}

        //[MyControlAttibute("车型细分", "车辆信息")]
        //public string VehicleTypeDetail
        //{
        //    get
        //    {
        //        var findobj = DataModel.Constant.VehicleDetailTypeInfos.FirstOrDefault(item => item.Type == this._Control.VehicleTypeDetail);
        //        if (findobj != null)
        //            return findobj.Name;
        //        else
        //            return "";
        //    }
        //}

        //[MyControlAttibute("车身颜色", "车辆信息")]
        //public string VehicleColor
        //{
        //    get
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        foreach (int color in this._Control.VehicleColorInfo)
        //        {
        //            var findobj = DataModel.Constant.VehicleColorInfos.FirstOrDefault(item => item.Type.ID == color);
        //            if (findobj != null)
        //                sb.Append(findobj.Name + ",");

        //        }
        //        if (sb.Length > 0)
        //            sb.Remove(sb.Length - 1, 1);
        //        return sb.ToString();
        //    }
        //}




        public DynamicTrafficPlateInfo GetBase()
        {
            return _Control;
        }


        public void Dispose()
        {
            _Control.Dispose();
        }
    }


}
