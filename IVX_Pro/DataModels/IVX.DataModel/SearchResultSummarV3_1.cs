using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Collections;
using System.Diagnostics;
// using BOCOM.IVX.Logic;
using System.Data;

namespace IVX.DataModel
{

    public class SearchResultSummaryV3_1
    {
        private List<SearchResultRecordV3_1> m_searchResultSingleSummaryList
            = new List<SearchResultRecordV3_1>();

        private uint m_searchSessionID = 0;
        private SearchParaV3_1 m_SearchPara = null;
        public List<SearchResultRecordV3_1> SearchResultSingleSummaryList
        {
            get { return m_searchResultSingleSummaryList; }
            set { m_searchResultSingleSummaryList = value; }
        }
        public SearchParaV3_1 SearchPara
        {
            get { return m_SearchPara ?? new SearchParaV3_1(SearchType.Person); }
            set { m_SearchPara = value; }
        }
        public E_VDA_SEARCH_STATUS SearchStatus { get; set; }
        public object SearchVM { get; set; }

        public uint SearchSessionID
        {
            get { return m_searchSessionID; }
            set { m_searchSessionID = value; }
        }

        public SearchItemV3_1 SearchItem { get; set; }

        public string ObjectRect { get; set; }
    }

}
