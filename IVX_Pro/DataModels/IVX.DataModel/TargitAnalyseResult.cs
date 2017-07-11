using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    public class TargitAnalyseResult
    {
        public UInt32 FaceId { get; set; }								//人脸ID
        public bool IsIdentical { get; set; }								//是同一个人的标志（为true时，原始大图中的目标矩形有效；为false时，原始大图中的目标矩形无效）
        public string MatchPicPath { get; set; }	//匹配图路径
        public System.Drawing.Rectangle FaceRect { get; set; }								//目标矩形

    }

}
