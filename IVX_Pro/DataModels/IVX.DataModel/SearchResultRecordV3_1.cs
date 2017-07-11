using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using DataModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Collections;

namespace IVX.DataModel
{

    public class SearchResultRecordV3_1 : IDisposable
    {
        public UInt64 ObjKey { get; set; }
        public E_SEARCH_RESULT_OBJECT_TYPE ObjType { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public UInt32 Similar { get; set; }
        public UInt32 UpBodyColor { get; set; }
        public UInt32 DownBodyColor { get; set; }
        public E_MOVE_OBJ_PEOPLE_BAG_TYPE BegType { get; set; }
        public string PlateNo { get; set; }
        public UInt32 PlateColor { get; set; }
        public E_VDA_SEARCH_VEHICLE_PLATE_STRUCT_TYPE PlateNumRow { get; set; }
        public uint VehicleLabel { get; set; }
        public uint VehicleLabelDetail { get; set; }
        public E_VDA_SEARCH_VEHICLE_TYPE VehicleType { get; set; }
        public E_VDA_SEARCH_VEHICLE_DETAIL_TYPE VehicleTypeDetail { get; set; }
        public uint VehicleColor { get; set; }
        public E_DRIVER_FEATURE_TYPE DriverIsPhoneing { get; set; }
        public UInt32 DriverIsPhoneingConf { get; set; }
        public E_DRIVER_FEATURE_TYPE DriverIsSafebelt { get; set; }
        public UInt32 DriverIsSafebeltConf { get; set; }
        public E_DRIVER_FEATURE_TYPE PassengerIsSafebelt { get; set; }
        public UInt32 PassengerIsSafebeltConf { get; set; }
        public E_DRIVER_FEATURE_TYPE DriverIsSunVisor { get; set; }
        public UInt32 DriverIsSunVisorConf { get; set; }
        public E_DRIVER_FEATURE_TYPE PassengerIsSunVisor { get; set; }
        public UInt32 PassengerIsSunVisorConf { get; set; }
        public string OriginalPicURL { get; set; }
        public string ThumbPicURL { get; set; }
        public string PlatePicURL { get; set; }
        public Image OriginalPic { get; set; }
        public Image ThumbPic { get; set; }
        public Image PlatePic { get; set; }
        public Rectangle ObjRect { get; set; }
        public Rectangle ObjDetailRect { get; set; }
        public Rectangle PlateRect { get; set; }

        public DateTime AdjustTime { get; set; }

        public string CameraID { get; set; }

        public void Dispose()
        {
            if (OriginalPic != null)
            {
                OriginalPic.Dispose();
                OriginalPic = null;
            }

            if (ThumbPic != null)
            {
                ThumbPic.Dispose();
                ThumbPic = null;
            }

            if (PlatePic != null)
            {
                PlatePic.Dispose();
                PlatePic = null;
            }
        }


    }


    public class MyControlAttibute : Attribute
    {
        private string _PropertyName;
        private string _PropertyCategory;
        private object _DefaultValue;
        public MyControlAttibute(string Name, string Category, object DefalutValue)
        {
            this._PropertyName = Name;
            this._PropertyCategory = Category;
            this._DefaultValue = DefalutValue;
        }
        public MyControlAttibute(string Name, string Category)
        {
            this._PropertyName = Name;
            this._PropertyCategory = Category;
            this._DefaultValue = "";
        }
        public MyControlAttibute(string Name)
        {
            this._PropertyName = Name;
            this._PropertyCategory = "";
            this._DefaultValue = "";
        }
        public string PropertyName
        {
            get { return this._PropertyName; }
        }
        public string PropertyCategory
        {
            get { return this._PropertyCategory; }
        }
        public object DefaultValue
        {
            get { return this._DefaultValue; }
        }
    }

    public class PeopleProperty : PropertyBase
    {
        private SearchResultRecordV3_1 _Control;
        public PeopleProperty()
        {
            
        }
        public PeopleProperty(SearchResultRecordV3_1 control)
        {
            this._Control = control;
        }
        [MyControlAttibute("出现时间", "基本信息")]
        public string  BeginTime
        {
            get { return this._Control.BeginTime.Add(this._Control.AdjustTime.Subtract(Common.ZEROTIME)).ToString(DataModel.Constant.DATETIME_FORMAT); }
        }
        [MyControlAttibute("消失时间", "基本信息")]
        public string EndTime
        {
            get { return this._Control.EndTime.Add(this._Control.AdjustTime.Subtract(Common.ZEROTIME)).ToString(DataModel.Constant.DATETIME_FORMAT); }
        }

        [MyControlAttibute("上身颜色", "人员信息")]
        public string  UpBodyColor
        {
            get {
                var findobj = DataModel.Constant.MoveObjectColorInfos.FirstOrDefault(item => item.Type.ID == this._Control.UpBodyColor);
                if (findobj != null)
                    return findobj.Name;
                else
                    return "";
            }
        }
        [MyControlAttibute("下身颜色", "人员信息")]
        public string DownBodyColor
        {
            get
            {
                var findobj = DataModel.Constant.MoveObjectColorInfos.FirstOrDefault(item => item.Type.ID == this._Control.DownBodyColor);
                if (findobj != null)
                    return findobj.Name;
                else
                    return "";
            }
        }
        [MyControlAttibute("背包类型", "人员信息")]
        public string BegType
        {
            get
            {
                var findobj = DataModel.Constant.BagTypeInfos.FirstOrDefault(item => item.Type == this._Control.BegType);
                if (findobj != null)
                    return findobj.Name;
                else
                    return "";
            }
        }
        [MyControlAttibute("目标类型", "基本信息")]
        public string ObjType
        {
            get
            {
                var findobj = DataModel.Constant.SearchResultObjectTypeInfos.FirstOrDefault(item => item.Type == this._Control.ObjType);
                if (findobj != null)
                    return findobj.Name;
                else
                    return "";

            }
        }

        [MyControlAttibute("相似度", "基本信息")]
        public string Similar
        {
            get
            {
                if (this._Control.Similar == 0)
                    return "";

                return string.Format("{0}%", this._Control.Similar);

            }
        }
    }
    public class UnknowProperty : PropertyBase
    {
        private SearchResultRecordV3_1 _Control;
        public UnknowProperty()
        {
            
        }
        public UnknowProperty(SearchResultRecordV3_1 control)
        {
            this._Control = control;
        }
        [MyControlAttibute("出现时间", "基本信息")]
        public string  BeginTime
        {
            get { return this._Control.BeginTime.Add(this._Control.AdjustTime.Subtract(Common.ZEROTIME)).ToString(DataModel.Constant.DATETIME_FORMAT); }
        }
        [MyControlAttibute("消失时间", "基本信息")]
        public string EndTime
        {
            get { return this._Control.EndTime.Add(this._Control.AdjustTime.Subtract(Common.ZEROTIME)).ToString(DataModel.Constant.DATETIME_FORMAT); }
        }

        [MyControlAttibute("目标类型", "基本信息")]
        public string ObjType
        {
            get
            {
                var findobj = DataModel.Constant.SearchResultObjectTypeInfos.FirstOrDefault(item => item.Type == this._Control.ObjType);
                if (findobj != null)
                    return findobj.Name;
                else
                    return "";

            }
        }

    }
    public class VehicleProperty : PropertyBase
    {
        private SearchResultRecordV3_1 _Control;
        public VehicleProperty()
        {
            
        }
        public VehicleProperty(SearchResultRecordV3_1 control)
        {
            this._Control = control;
        }
        [MyControlAttibute("出现时间", "基本信息")]
        public string BeginTime
        {
            get 
            {
                if (this._Control.AdjustTime == new DateTime())
                    return this._Control.BeginTime.ToString(Constant.DATETIME_FORMAT);
                
                return this._Control.BeginTime.Add(this._Control.AdjustTime.Subtract(Common.ZEROTIME)).ToString(DataModel.Constant.DATETIME_FORMAT); 
            }
        }
        [MyControlAttibute("消失时间", "基本信息")]
        public string EndTime
        {
            get
            {
                if (this._Control.AdjustTime == new DateTime())
                    return this._Control.EndTime.ToString(Constant.DATETIME_FORMAT);

                return this._Control.EndTime.Add(this._Control.AdjustTime.Subtract(Common.ZEROTIME)).ToString(DataModel.Constant.DATETIME_FORMAT);
            }
        }
        [MyControlAttibute("目标类型", "基本信息")]
        public string ObjType
        {
            get
            {
                var findobj = DataModel.Constant.SearchResultObjectTypeInfos.FirstOrDefault(item => item.Type == this._Control.ObjType);
                if (findobj != null)
                    return findobj.Name;
                else
                    return "";

            }
        }
        [MyControlAttibute("相似度", "基本信息")]
        public string Similar
        {
            get
            {
                if (this._Control.Similar == 0)
                    return "";

                return string.Format("{0}%", this._Control.Similar);

            }
        }



        [MyControlAttibute("车牌号", "车辆信息")]
        public string PlateNo
        {
            get
            {
                if (this._Control.PlateNo == "11111111")
                    return "未检测到车牌";
                return string.Format("{0}", this._Control.PlateNo,100);
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
        public string  VehicleType
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
        public string  VehicleTypeDetail
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


        #region 人员信息暂时不使用
        //[MyControlAttibute("驾驶员打电话", "人员信息")]
        //public string  DriverIsPhoneing
        //{
        //    get
        //    {
        //        var findobj = DataModel.Constant.VehicleDriverFeatureTypeInfos.FirstOrDefault(item => item.Type == this._Control.DriverIsPhoneing);
        //        if (findobj != null)
        //            return string.Format("{0}[{1}%]", findobj.Name, this._Control.DriverIsPhoneingConf);
        //        else
        //            return "";
        //    }
        //}


        //[MyControlAttibute("驾驶员系安全带", "人员信息")]
        //public string  DriverIsSafebelt
        //{
        //    get
        //    {
        //        var findobj = DataModel.Constant.VehicleDriverFeatureTypeInfos.FirstOrDefault(item => item.Type == this._Control.DriverIsSafebelt);
        //        if (findobj != null)
        //            return string.Format("{0}[{1}%]", findobj.Name, this._Control.DriverIsSafebeltConf);
        //        else
        //            return "";
        //    }
        //}


        //[MyControlAttibute("副驾驶系安全带", "人员信息")]
        //public string PassengerIsSafebelt
        //{
        //    get
        //    {
        //        var findobj = DataModel.Constant.VehicleDriverFeatureTypeInfos.FirstOrDefault(item => item.Type == this._Control.PassengerIsSafebelt);
        //        if (findobj != null)
        //            return string.Format("{0}[{1}%]", findobj.Name, this._Control.PassengerIsSafebeltConf);
        //        else
        //            return "";
        //    }
        //}


        //[MyControlAttibute("驾驶员遮阳板", "人员信息")]
        //public string  DriverIsSunVisor
        //{
        //    get
        //    {
        //        var findobj = DataModel.Constant.VehicleDriverFeatureTypeInfos.FirstOrDefault(item => item.Type == this._Control.DriverIsSunVisor);
        //        if (findobj != null)
        //            return string.Format("{0}[{1}%]", findobj.Name, this._Control.DriverIsSunVisorConf);
        //        else
        //            return "";
        //    }
        //}


        //[MyControlAttibute("副驾驶遮阳板", "人员信息")]
        //public string  PassengerIsSunVisor
        //{
        //    get
        //    {
        //        var findobj = DataModel.Constant.VehicleDriverFeatureTypeInfos.FirstOrDefault(item => item.Type == this._Control.PassengerIsSunVisor);
        //        if (findobj != null)
        //            return string.Format("{0}[{1}%]",findobj.Name , this._Control.PassengerIsSunVisorConf);
        //        else
        //            return "";
        //    }
        //}

        #endregion

    }

    public delegate void PropertyChanged(object Value);
    /// <summary>
    /// 主要是实现中文化属性显示
    /// </summary>
    public class PropertyBase : ICustomTypeDescriptor
    {
        /// <summary>
        /// 下面这段代码来源于：http://www.bluespace.cn/Html/Csdn/2_47/View_4702219.html
        /// </summary>
        /// <returns></returns>
        #region ICustomTypeDescriptor 显式接口定义
        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }
        string ICustomTypeDescriptor.GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }
        string ICustomTypeDescriptor.GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }
        TypeConverter ICustomTypeDescriptor.GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }
        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }
        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
        {
            return null;
        }
        object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }
        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }
        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }
        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return ((ICustomTypeDescriptor)this).GetProperties(new Attribute[0]);
        }
        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
        {
            ArrayList props = new ArrayList();
            Type thisType = this.GetType();
            PropertyInfo[] pis = thisType.GetProperties();
            foreach (PropertyInfo p in pis)
            {
                if (p.DeclaringType == thisType || p.PropertyType.ToString() == "System.Drawing.Color")
                {
                    //判断属性是否显示
                    BrowsableAttribute Browsable = (BrowsableAttribute)Attribute.GetCustomAttribute(p, typeof(BrowsableAttribute));
                    if (Browsable != null)
                    {
                        if (Browsable.Browsable == true || p.PropertyType.ToString() == "System.Drawing.Color")
                        {
                            PropertyStub psd = new PropertyStub(p, attributes);
                            props.Add(psd);
                        }
                    }
                    else
                    {
                        PropertyStub psd = new PropertyStub(p, attributes);
                        props.Add(psd);
                    }
                }
            }
            PropertyDescriptor[] propArray = (PropertyDescriptor[])props.ToArray(typeof(PropertyDescriptor));
            return new PropertyDescriptorCollection(propArray);
        }
        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
        #endregion
    }
    /// <summary>
    /// 下面这段代码来源于：http://www.bluespace.cn/Html/Csdn/2_47/View_4702219.html
    /// </summary>
    #region PropertyStub 定义
    public class PropertyStub : PropertyDescriptor
    {
        PropertyInfo info;
        public PropertyStub(PropertyInfo propertyInfo, Attribute[] attrs)
            : base(propertyInfo.Name, attrs)
        {
            this.info = propertyInfo;
        }
        public override Type ComponentType
        {
            get { return this.info.ReflectedType; }
        }
        public override bool IsReadOnly
        {
            get { return this.info.CanWrite == false; }
        }
        public override Type PropertyType
        {
            get { return this.info.PropertyType; }
        }
        public override bool CanResetValue(object component)
        {
            return false;
        }
        public override object GetValue(object component)
        {
            //Console.WriteLine("GetValue: " + component.GetHashCode());
            try
            {
                return this.info.GetValue(component, null);
            }
            catch
            {
                return null;
            }
        }
        public override void ResetValue(object component)
        {
        }
        public override void SetValue(object component, object value)
        {
            //Console.WriteLine("SetValue: " + component.GetHashCode());
            this.info.SetValue(component, value, null);
        }
        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
        //通过重载下面这个属性，可以将属性在PropertyGrid中的显示设置成中文
        public override string DisplayName
        {
            get
            {
                if (info != null)
                {
                    MyControlAttibute uicontrolattibute = (MyControlAttibute)Attribute.GetCustomAttribute(info, typeof(MyControlAttibute));
                    if (uicontrolattibute != null)
                        return uicontrolattibute.PropertyName;
                    else
                    {
                        return info.Name;
                    }
                }
                else
                    return "";
            }
        }
        public override string Category
        {
            get
            {
                if (info != null)
                {
                    MyControlAttibute uicontrolattibute = (MyControlAttibute)Attribute.GetCustomAttribute(info, typeof(MyControlAttibute));
                    if (uicontrolattibute != null)
                        return uicontrolattibute.PropertyCategory;
                    else
                    {
                        return info.Name;
                    }
                }
                else
                    return "";
            }
            
        }
        
    }
    #endregion
}
