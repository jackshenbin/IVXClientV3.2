using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    public class SearchItem : SearchParaBase
    {
        private bool m_IsFinished = false;

        public bool IsFinished
        {
            get
            {
                return m_IsFinished;
            }
            set
            {
                lock (this)
                {
                    if (m_IsFinished != value)
                    {
                        m_IsFinished = value;
                    }
                }
            }
        }

        public SearchResultSingleSummary ResultSummary { get; set; }

        public uint TaskUnitId { get; set; }

        public uint CameraId { get; set; }

        /// <summary>
        /// 底层检索标示
        /// </summary>
        public uint SearchHandle { get; set; }

        /// <summary>
        /// 实时检索时相机唯一编号
        /// </summary>
        public string CameraCode{ get; set; }

        public string CameraName { get; set; }

    }
}
