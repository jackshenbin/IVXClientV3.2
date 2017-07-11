using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using DataModel;

namespace IVX.DataModel
{
    [Serializable]
    public class PlateInfo 
    {
        public ulong ID { get; set; }
        public string CameraID { get; set; }
        public DateTime TimeStampSec { get; set; }
        public uint ObjectType { get; set; }
        public uint Reliability { get; set; }
        public string Similarate
        {
            get
            {
                string sRet = string.Format("{0}%", Reliability);

                return sRet;
            }
        }

        public string PlateNum { get; set; }
        public uint PlateNumRow { get; set; }
        public uint PlateColor { get; set; }
        public ColorName PlateColorName { get; set; }
        public uint VehicleColor { get; set; }
        public ColorName VehicleColorName { get; set; }
        public uint VehicleType { get; set; }
        public uint VehicleTypeDetail { get; set; }
        public VehicleDetailTypeInfo VehicleDetailTypeInfo
        {
            get
            {
                int index = (int)VehicleTypeDetail;
                //Debug.Assert(index >= 0 && index < Constant.VehicleDetailTypeInfos.Length);
                if (index >= 0 && index < Constant.VehicleDetailTypeInfos.Length)
                {
                    return Constant.VehicleDetailTypeInfos[index];
                }
                else
                {
                    return Constant.VehicleDetailTypeInfos[Constant.VehicleDetailTypeInfos.Length - 1];
                }
            }
        }

        public uint VehicleLabelID { get; set; }
        public VehicleBrandInfo VehicleLabel { get; set; }
        public uint VehicleLabelDetailID { get; set; }
        public VehicleBrandInfo VehicleLabelDetail { get; set; }
        public uint VehicleSpeed { get; set; }
        public uint Direction { get; set; }
        public uint RoadWayNum { get; set; }
        public System.Drawing.Rectangle PlateCoordRect { get; set; }
        public System.Drawing.Image PlateImgData { get; set; }
        public System.Drawing.Rectangle VehiBodyCoordRect { get; set; }
        public System.Drawing.Image VehiBodyImgData { get; set; }
        public System.Drawing.Size FullImgSize { get; set; }
        public System.Drawing.Image FullImgData { get; set; }
        public System.Drawing.Size ComposeImgSize { get; set; }
        public System.Drawing.Image ComposeImgData { get; set; }


    };
}
