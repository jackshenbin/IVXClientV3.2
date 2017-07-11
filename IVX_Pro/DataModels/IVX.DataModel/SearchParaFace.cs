using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel {

	public class SearchParaFace : SearchParaBase {
		public string CameraID;
		public UInt32 startTime;
		public UInt32 endTime;
		public int ResultNumRange;
		public int Similar;
		public string picData;
		public string ObjRect;
		public uint matchTaskId;
		public UInt32 PeopleNation;
		public UInt32 PeopleSex;
		public UInt32 BeginAge;
		public UInt32 EndAge;
	}

}
