using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    public class SearchParaV3_1 : ICloneable
    {
        #region Fileds

        //private static readonly DateTime ZEROTIME = new DateTime(1970, 1, 1).ToLocalTime();
        //private static readonly DateTime MAXTIME = new DateTime(1970, 1, 1).ToLocalTime().AddSeconds(uint.MaxValue);

        private SearchResultDisplayMode m_DisplayMode;
        private TimeRange m_TimeRange;
        private FilterCondition m_FilterCondition;

        #endregion

        #region Properties

        public SearchType SearchType { get; set; }
        public uint Similar { get; set; }
        public uint ResultNumRange { get; set; }
        public SortType SortType { get; set; }


        public SearchResultDisplayMode DisplayMode
        {
            get
            {
                return m_DisplayMode;
            }
            set
            {
                m_DisplayMode = value;
            }
        }

        public string  CameraID { get; set; }

        public DateTime StartTime
        {
            get
            {
                return m_TimeRange.DTStart;
            }
            set
            {
                m_TimeRange.DTStart = value;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return m_TimeRange.DTEnd;
            }
            set
            {
                m_TimeRange.DTEnd = value;
            }
        }


        public object this[string key]
        {
            get
            {
                return m_FilterCondition[key];
            }
            set
            {
                m_FilterCondition[key] = value;
            }
        }

        #endregion

        #region Constructors

        public SearchParaV3_1()
        {
            CameraID = "";
            m_FilterCondition = new FilterCondition();
            m_TimeRange = new TimeRange() { DTStart = Common.ZEROTIME, DTEnd = Common.MAXTIME };
            SortType = SortType.TimeAsc;
            ResultNumRange = 10000;
            Similar = 100;

        }

        public SearchParaV3_1(SearchType searchType)
            : this()
        {
            SearchType = searchType;
        }

        #endregion



        public object Clone()
        {
            SearchParaV3_1 searchParaNew = new SearchParaV3_1(SearchType)
            {
                CameraID = this.CameraID,
                SortType = this.SortType,
                ResultNumRange = this.ResultNumRange,
                SearchType = this.SearchType,
                Similar = this.Similar,
                 m_TimeRange = this.m_TimeRange,
                //StartTime = this.StartTime,
                //EndTime = this.EndTime,
                 m_DisplayMode = this.m_DisplayMode,
                  m_FilterCondition =  new FilterCondition(),
                //DisplayMode = this.DisplayMode,
            };

            if (this.m_FilterCondition != null)
            {
                ICollection<string> keys = this.m_FilterCondition.GetAllKeys();
                if (keys != null)
                {
                    foreach (string key in keys)
                    {
                        searchParaNew[key] = this[key];
                    }
                }
            }

            return searchParaNew;
        }
    }

}
