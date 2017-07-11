using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;

namespace IVX.Live.ViewModel {

	public class LogViewModel {
		public event EventHandler SearchFinished;
		System.Threading.Thread getLogListTh;

		public void GetLogInfoList(LogSearchParam parm) 
		{
			getLogListTh = new System.Threading.Thread(GetLogInfoFunc);
			getLogListTh.Start((object)parm);
		}

		public void Stop() 
		{
			getLogListTh = null;
		}

		public void Clear()
		{
			if (getLogListTh != null) 
			{
				getLogListTh.Abort();
			}
		}

		private void GetLogInfoFunc(object parmObj)
		{
			List<LogSearchResultInfo> logListObj = null;
			try
			{
				logListObj = Framework.Container.Instance.CommService.GET_LOG_LIST_DATA((LogSearchParam)parmObj);
			}
			catch (SDKCallException ex)
			{
				logListObj = new List<LogSearchResultInfo> { };
				LogSearchResultInfo logInfo = new LogSearchResultInfo();
				logInfo.OptName = "SDKError";
				logInfo.Description = "日志管理-查询:" + ex.Message;
				logListObj.Add(logInfo);
			}
			
			if (SearchFinished != null)
			{
				SearchFinished((object)logListObj,null);
			}
		}
	}
}
