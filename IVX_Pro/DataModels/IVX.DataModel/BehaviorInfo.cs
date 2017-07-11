using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using DataModel;

namespace IVX.DataModel
{
    /// <summary>
    /// behaviorInfo 
    /// </summary>
    [Serializable]
    public class BehaviorInfo
    {
        public string CameraID { get; set; }
        public uint ObjectId { get; set; }
        public BehaviorType EventType { get; set; }
        public System.Drawing.Rectangle EventObjRect { get; set; }
        public E_SEARCH_RESULT_OBJECT_TYPE ObjType { get; set; }
        public uint ObjNum { get; set; }
        public System.IO.MemoryStream Image { get; set; }

		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public String EventImgUrl { get; set; }
		public String EventVideoUrl { get; set; }

        public void Dispose()
        {
            if (Image != null)
            {
                Image.Dispose();
                Image = null;
            }
        }

        public void Clear()
        {
            if (Image != null)
            {
                Image = null;
            }
        }
    }
    public class BehaviorProperty : PropertyBase, IDisposable
    {
        private BehaviorInfo _Control;
        public BehaviorProperty()
        {

        }
        public BehaviorProperty(BehaviorInfo control)
        {
            this._Control = control;
        }
        [MyControlAttibute("相机编号", "基本信息")]
        public string CameraCode
        {
            get { return this._Control.CameraID; }
        }
        [MyControlAttibute("开始时间", "基本信息")]
        public string StartTime
        {
            get { return this._Control.StartTime.ToString(DataModel.Constant.DATETIME_FORMAT); }
        }
        [MyControlAttibute("结束时间", "基本信息")]
        public string EndTime
        {
            get { return this._Control.EndTime.ToString(DataModel.Constant.DATETIME_FORMAT); }
        }
        [MyControlAttibute("事件类型", "基本信息")]
        public string EventType
        {
            get
            {
                var findobj = DataModel.Constant.BehaviorTypeInfo.FirstOrDefault(item => item.Type == this._Control.EventType);
                if (findobj != null)
                    return findobj.Name;
                else
                    return "";

            }
        }


        [MyControlAttibute("编号", "行为事件信息")]
        public string ObjectId
        {
            get
            {
                return this._Control.ObjectId.ToString();
            }
        }

        [MyControlAttibute("目标类型", "行为事件信息")]
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

        public BehaviorInfo GetBase()
        {
            return _Control;
        }


        public void Dispose()
        {
            _Control.Dispose();
        }
    }

}
