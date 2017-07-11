using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel {

	public class SearchResultFace : IDisposable 
	{
		public string CameraID;
		public UInt64 ObjKey;
		public UInt32 Similar;
		public UInt64 BeginTimeMilliSec;
		public UInt64 EndTimeMilliSec;
		public UInt32 PeopleNation;
		public UInt32 PeopleAge;
		public UInt32 PeopleSex;
		public string OriFacePicPath;
		public string FacePosition;

		public void Dispose() {

		}

		public void Clear() {

		}
	}

	public class SearchResultFaceProperty : PropertyBase, IDisposable {
		private SearchResultFace _Control;
        public SearchResultFaceProperty()
        {

        }
		public SearchResultFaceProperty(SearchResultFace control)
        {
            this._Control = control;
        }

        [MyControlAttibute("相机编号", "基本信息")]
        public string CameraCode
        {
			get { return this._Control.CameraID; }
        }

        [MyControlAttibute("出现时间", "基本信息")]
        public string StartTime
        {
            get { return Common.ConvertLinuxTime((uint)this._Control.BeginTimeMilliSec).ToString(DataModel.Constant.DATETIME_FORMAT); }
        }

        [MyControlAttibute("消失时间", "基本信息")]
        public string EndTime
        {
            get { return Common.ConvertLinuxTime((uint)this._Control.EndTimeMilliSec).ToString(DataModel.Constant.DATETIME_FORMAT); }
        }

		[MyControlAttibute("民族", "基本信息")]
		public string PeopleNation
        {
            get
            {
                return string.Format("{0}", this._Control.PeopleNation);
            }
        }

		[MyControlAttibute("相似度", "基本信息")]
		public string PeopleSimilar {
			get {
				return string.Format("{0}", this._Control.Similar);
			}
		}

		[MyControlAttibute("年龄", "基本信息")]
		public string PeopleAge
        {
			get {
				return string.Format("{0}", this._Control.PeopleAge);
			}
        }

		[MyControlAttibute("性别", "基本信息")]
		public string PeopleSex {
			get {
				string ret = "";
				if(this._Control.PeopleSex == (uint)E_PEOPLE_SEX.女) {
					ret = "女";
				}
				else if(this._Control.PeopleSex == (uint)E_PEOPLE_SEX.男){
					ret = "男";
				}
				else {
					ret = "未知";
				}
				return ret;
			}
		}

		public SearchResultFace GetBase() {
			return _Control;
		}

		public void Dispose() {
			_Control.Dispose();
		}
	}
}
