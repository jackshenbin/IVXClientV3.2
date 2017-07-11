using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    public class SearchParaBase
    {
        public PageInfoBase PageInfo { get; set; }

        public SortType SortType { get; set; }

        public SearchParaBase()
        {
            PageInfo = new PageInfoBase();
            SortType = SortType.TimeAsc;
        }
    

    }
}
