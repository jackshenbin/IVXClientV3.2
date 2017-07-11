using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;

namespace IVX.Live.ViewModel
{
    public class SearchResultPanelViewModel
    {
        private SearchType m_searchType;
        public event EventHandler SearchBegin;

        public List<SearchItemV3_1> SearchItems { get; set; }
        public SearchResultPanelViewModel(SearchType searchType)
        {
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<SearchBeginEvent>().Subscribe(OnSearchBegin, Microsoft.Practices.Prism.Events.ThreadOption.PublisherThread);
            m_searchType = searchType;
        }
        public void Clear()
        { 
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<SearchBeginEvent>().Unsubscribe(OnSearchBegin);   
        }
        private void OnSearchBegin(SearchItemGroup items)
        {
            if (items.SearchType == m_searchType)
            {
                SearchItems = items.SearchItems;
                if (SearchBegin!=null)
                {
                    SearchBegin(this, null); 
                }
            }
        }

    }
}