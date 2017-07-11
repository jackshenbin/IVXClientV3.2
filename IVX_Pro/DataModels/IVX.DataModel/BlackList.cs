using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel {

	public class BlackListLib {
		public BlackListLib() {
			picList = new List<BlackItem> { };
		}
		public UInt32 PicCount;
		public List<BlackItem> picList;
		public string Name;
		public string Code;
		public string OtherInfo;
		public UInt32 Handel;
	}

	public class BlackItem {
		public UInt32 LibHandel;
		public UInt32 PicHandel;
		public string PictureUrl;	//	图片Url（string）
		public string picData;
		public string Name;			//	姓名（string）
		public string Id;
		public string PeopleCard;	// 身份证号
		public string PeopleNation;	//	民族	（UINT32）
		public UInt32 PeopleAge;	//	年龄
		public UInt32 PeopleSex;	//	性别	性别
		public UInt32 PeopleHeight; //	身高	
		public UInt32 PeopleWeight; //	体重	
		public UInt32 BloodType;	//	血型	
		public string Address;		//	地址	
		public string other;
		public UInt32 PicState;
		public UInt32 Similar;
	}

}
