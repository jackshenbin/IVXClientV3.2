using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    public class AnalysisPlanInfo : ICloneable
    {
        /// <summary>
        /// 所属组ID
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// 监控点ID
        /// </summary>
        public uint CameraId { get; set; }

        public CameraInfo Camera { get; set; }

        /// <summary>
        /// 分析算法类型，见定义E_VDA_VIDEO_ANALYZE_TYPE或E_VDA_PIC_ANALYZE_TYPE
        /// </summary>
        public E_VIDEO_ANALYZE_TYPE AnalyzeType { get; set; }

        public E_VDA_TASK_UNIT_STATUS Status { get; set; }			//分析状态，见vdacomm.h中E_VDA_TASK_UNIT_ANALYZE_STATUS定义

        public string Discription { get; set; } //备注信息

        public uint UsageType { get; set; }

        public bool Enabled
        {
            get
            {
                return UsageType == 1;
            }
            set
            {
                UsageType = 0;
            }
        }

        public object Clone()
        {
            AnalysisPlanInfo newPlan = new AnalysisPlanInfo()
            {
                Camera = this.Camera,
                AnalyzeType = this.AnalyzeType,
                Discription = this.Discription,
                Id = this.Id,
                Status = this.Status,
                UsageType = this.UsageType,
            };

            return newPlan;
        }

    }
}
