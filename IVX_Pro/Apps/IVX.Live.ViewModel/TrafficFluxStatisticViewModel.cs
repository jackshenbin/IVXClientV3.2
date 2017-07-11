using IVX.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.Live.ViewModel
{
    public class TrafficFluxStatisticViewModel
    {
        public event EventHandler SearchFinished;
        Dictionary<string, bool> m_DicTrafficEvent;
        List<TaskStroreInfoV3_1> m_taskList;
        List<TrafficFluxStatisticInfo> m_trafficInfoListSum;
        bool m_OverTime;
        object m_lockVar;

        public TrafficFluxStatisticViewModel()
        {
            m_DicTrafficEvent    = new Dictionary<string, bool> {};
            m_taskList           = new List<TaskStroreInfoV3_1> {};
            m_trafficInfoListSum = new List<TrafficFluxStatisticInfo> { };
            m_lockVar            = new object();
            m_OverTime           = false;
        }

        public void ClearModelData()
        {
            m_DicTrafficEvent.Clear();
            m_taskList.Clear();
            m_trafficInfoListSum.Clear();
            m_OverTime = false;
        }

        public void Search(List<string> cameraIdList, UInt32 BeginTimeSec, UInt32 EndTimeSec, UInt32 TimeInterval)
        {
            //  清空上次查询数据 ...
            ClearModelData();
            // 不支持 查询所有相机
            if (null == cameraIdList)
            {
                return;
            }
            // 查询部分相机
            else
            {
                foreach (string cameraId in cameraIdList)
                {
                    var info = Framework.Container.Instance.CommService.GET_RESULT_STORE_LIST(cameraId, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD);
                    if (info == null)
                    {
                        continue;
                    }
                    string ip = info.StoreIP;
                    uint port = info.StortPort;
                    m_DicTrafficEvent.Add(cameraId, false);
                    SearchViewModelBase vm = new SearchViewModelBase(ip, port);
                    // 设置当前 要查询的ID
                    vm.TraffficCameraId = cameraId;
                    vm.BeginTimeSec = BeginTimeSec;
                    vm.EndTimeSec = EndTimeSec;
                    vm.TimeInterval = TimeInterval;
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
            string CameraID = vm.TraffficCameraId;
            List<TrafficFluxStatisticInfo> trafficInfoList = vm.SearchTrafficFluxStatistic(vm.TraffficCameraId, vm.BeginTimeSec, vm.EndTimeSec, vm.TimeInterval);
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
                    if (null != trafficInfoList)
                    {
                        m_trafficInfoListSum.AddRange(trafficInfoList);
                    }
                    m_DicTrafficEvent[CameraID] = true;
                }
            }
        }

        // 收集数据----总线程 
        private void SearchCollectTh()
        {
            UInt32 startSec = DataModel.Common.ConvertLinuxTime(DateTime.Now);
            UInt32 curSec = DataModel.Common.ConvertLinuxTime(DateTime.Now);
            while (curSec - startSec < 10)
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
                SearchFinished((object)m_trafficInfoListSum, null);
            }
        }
        public bool TimeIsLong(uint startTime, uint endTime, TrafficTimeType timeType)
        {

            switch (timeType)
            {
                case TrafficTimeType.MONTH:
                    if ((endTime - startTime) > 12 * 31 * 24 * 3600)
                    {
                        return true;
                    }
                    break;
                case TrafficTimeType.DAY:
                    if ((endTime - startTime) > 31 * 24 * 3600)
                    {
                        return true;
                    }
                    break;
                case TrafficTimeType.HOUR:
                    if ((endTime - startTime) > 24 * 3600)
                    {
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }
        private bool DataIsAllReturn()
        {
            foreach (var item in m_DicTrafficEvent)
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
