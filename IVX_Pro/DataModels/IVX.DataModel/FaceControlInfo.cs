using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel {

	public class FaceControlInfo {

        public List<uint> BlackListHandle{get;set;}
        public string CameraID { get; set; }

        public UInt32 FaceControlHandle { get; set; }
        public UInt32 ControlThreshold { get; set; }

        public List<E_PEOPLE_NATION> ControlNation { get; set; }	//	民族	（UINT32）
        public uint BeginAge { get; set; }	//	年龄
        public uint EndAge { get; set; }	//	年龄
        public E_MOVE_OBJ_PEOPLE_GENDER_TYPE ControlSex { get; set; }	//	性别	性别
	}

}
