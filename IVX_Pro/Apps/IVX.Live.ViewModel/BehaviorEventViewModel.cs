using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;

namespace IVX.Live.ViewModel {
	public class BehaviorEventViewModel 
	{
		public event EventHandler SearchFinished;
        Dictionary<string, bool> m_DicBehaviorEvent;
		List<BehaviorInfo> m_taskList;
		List<BehaviorInfo> m_BehaviorInfoListSum;
        bool                     m_OverTime;
        object                   m_lockVar;
		public BehaviorEventViewModel()
        {
			m_DicBehaviorEvent = new Dictionary<string, bool> { };
			m_taskList = new List<BehaviorInfo> { };
			m_BehaviorInfoListSum = new List<BehaviorInfo> { };
            m_lockVar = new object();
            m_OverTime = false;
        }

        public void ClearModelData()
        {
			m_DicBehaviorEvent.Clear();
            m_taskList.Clear();
			m_BehaviorInfoListSum.Clear();
            m_OverTime = false;
        }

        public void Search(List<string> cameraIdList,UInt32 BeginTimeSec,UInt32 EndTimeSec,string EventTypeList)
        {
            //  清空上次查询数据 ...
            ClearModelData();
            // 查询所有相机
            if(null == cameraIdList)
            {
                // 获取所有ip和端口 
				var infoList = Framework.Container.Instance.CommService.GET_RESULT_STORE_LIST(E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BEHAVIOR_ALARM);
                if (infoList != null)
                {
                  // 查询
                  foreach (var info in infoList)
                  {
                      string ip = info.StoreIP;
                      uint port = info.StortPort;
                      string cameraId = "ip:" + ip + port.ToString();
					  m_DicBehaviorEvent.Add(cameraId, false);
                      SearchViewModelBase vm = new SearchViewModelBase(ip, port);
                      // 设置当前 要查询的ID
					  vm.BehaviorCameraId = cameraId;
                      vm.BeginTimeSec = BeginTimeSec;
                      vm.EndTimeSec = EndTimeSec;
                      vm.EventTypeList = EventTypeList;
                      new System.Threading.Thread(SearchTrafficEventTh).Start((object)vm);
                  }
                }
            }
            // 查询部分相机
            else
            {
                foreach (string cameraId in cameraIdList)
                {
					var info = Framework.Container.Instance.CommService.GET_RESULT_STORE_LIST(cameraId, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BEHAVIOR_ALARM);
                    if(info == null)
                    {
                        continue;
                    }
                    string ip = info.StoreIP;
                    uint port = info.StortPort;
					m_DicBehaviorEvent.Add(cameraId, false);
                    SearchViewModelBase vm = new SearchViewModelBase(ip, port);
                    // 设置当前 要查询的ID
					vm.BehaviorCameraId = cameraId;
                    vm.BeginTimeSec = BeginTimeSec;
                    vm.EndTimeSec = EndTimeSec;
                    vm.EventTypeList = EventTypeList;
                    new System.Threading.Thread(SearchTrafficEventTh).Start((object)vm);
                    // 子线程创建 开始查询
                }
            }
            // 创建 总线程 收集数据
            new System.Threading.Thread(SearchCollectTh).Start();
        }

        // 查询----线程函数 
        private void SearchTrafficEventTh(object VmBaseObj)
        {
            SearchViewModelBase vm = (SearchViewModelBase)VmBaseObj;
			string CameraID = vm.BehaviorCameraId;
			List<BehaviorInfo> behaviorInfoList = vm.SearchBehaviorHistoryEvent(vm.BehaviorCameraId, vm.BeginTimeSec, vm.EndTimeSec, vm.EventTypeList);
            // 超时之后 不做处理
            if (m_OverTime)
            {
                return;
            }
            // if trafficInfoList== null 或者 count ==0
            else
            {
                //添加数据
                lock (m_lockVar)
                {
					if (null != behaviorInfoList)
                    {
						m_BehaviorInfoListSum.AddRange(behaviorInfoList);
                    }
					m_DicBehaviorEvent[CameraID] = true; 
                }
            }
        }

        // 收集数据----总线程 
        private void SearchCollectTh()
        {
            UInt32 startSec = DataModel.Common.ConvertLinuxTime(DateTime.Now);
            UInt32 curSec = DataModel.Common.ConvertLinuxTime(DateTime.Now);
            while(curSec - startSec < 10)
            {
                //没有超时 &&所有数据返回
                if (DataIsAllReturn())
                {
                    break;
                }
                //停500ms
                System.Threading.Thread.Sleep(500);
                curSec = DataModel.Common.ConvertLinuxTime(DateTime.Now);
            }
            //超时
            m_OverTime = true;
            if (SearchFinished != null)
            {
				SearchFinished((object)m_BehaviorInfoListSum, null);
            }
        }

        private bool DataIsAllReturn()
        {
			foreach (var item in m_DicBehaviorEvent)
            {
                if (false == item.Value)
                {
                    return false;
                }
            }
            return true;
        }
	}
}
