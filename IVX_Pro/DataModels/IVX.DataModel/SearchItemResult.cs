using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    /// <summary>
    /// 一个检索单元的检索结果， 如一个TaskUnit， 或一个Camera的检索结果
    /// </summary>
    public class SearchItemResult
    {
        public bool Succeed { get; set; }

        public PageInfoBase PageInfo { get; set; }

        public uint SearchId { get; set; }

        public uint TaskUnitId { get; set; }

        public string CameraCode { get; set; }

        /// <summary>
        /// 底层对于同一次检索， 对应一个 Camera的Handle
        /// </summary>
        public uint KeyHandle { get; set; }

        public List<SearchResultRecord> ResultRecords { get; set; }
    }
}
