using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using DataModel;
using System.ComponentModel;
using System.Diagnostics;

namespace IVX.DataModel
{

    public class SearchResultRecordTiny 
    {

        public UInt64 ObjectKey { get; set; }//号

        public DateTime TargetStartTs { get; set; }//目标出现时间
        public DateTime TargetEndTs { get; set; }//目标消失时间

        public E_SEARCH_RESULT_OBJECT_TYPE ObjectType { get; set; }//目标类型（人、车、不确定）

        public Rectangle ObjectDetailRect { get; set; } //局部特征框

        public UInt32 Similar { get; set; }

        public DateTime AdjustTime { get; set; }


    }
}
