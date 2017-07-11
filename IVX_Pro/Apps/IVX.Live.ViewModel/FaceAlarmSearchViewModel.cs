using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;

namespace IVX.Live.ViewModel {

	public class FaceAlarmSearchViewModel {

		public event EventHandler SearchFinished;
		Dictionary<string, bool> m_DicFaceEvent;
		List<BehaviorInfo> m_taskList;
		List<FaceAlarmInfoV3_1> m_faceInfoList;
		bool m_OverTime;
		object m_lockVar;

		public FaceAlarmSearchViewModel()
        {
			m_DicFaceEvent = new Dictionary<string, bool> {};
			m_taskList = new List<BehaviorInfo> {};
			m_faceInfoList = new List<FaceAlarmInfoV3_1> { };
            m_lockVar = new object();
            m_OverTime = false;
        }

		public void StartFaceAlarmSearch(List<string> cameraIdList, string blackListStr, UInt32 beginTime, UInt32 endTime) {
			m_faceInfoList.Clear();
			m_DicFaceEvent.Clear();
			foreach (string cameraId in cameraIdList) {
				var info = Framework.Container.Instance.CommService.GET_RESULT_STORE_LIST(cameraId, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE_DYNAMIC);
				if (info == null) {
					continue;
				}
				string ip = info.StoreIP;
				uint port = info.StortPort;
				m_DicFaceEvent.Add(cameraId, false);
				SearchViewModelBase vm = new SearchViewModelBase(ip, port);
				// 设置当前 要查询的ID
				vm.FaceCameraId = cameraId;
				vm.BeginTimeSec = beginTime;
				vm.EndTimeSec = endTime;
				vm.BlackListStr = blackListStr;
				new System.Threading.Thread(SearchTrafficEventTh).Start((object)vm);
				// 子线程创建 开始查询
			}
			// 创建 总线程 收集数据
			new System.Threading.Thread(SearchCollectTh).Start();
		}

		// 查询----线程函数 
		private void SearchTrafficEventTh(object VmBaseObj) {
			SearchViewModelBase vm = (SearchViewModelBase)VmBaseObj;
			string CameraID = vm.FaceCameraId;
			List<FaceAlarmInfoV3_1> infoList = vm.SearchFaceAlarm(vm.FaceCameraId, vm.BeginTimeSec, vm.EndTimeSec, vm.BlackListStr);
			// 超时之后 不做处理
			if (m_OverTime) {
				return;
			}
			// if trafficInfoList == null 或者 count == 0
			else {
				// 添加数据
				lock (m_lockVar) {
					if (null != infoList) {
						m_faceInfoList.AddRange(infoList);
					}
					m_DicFaceEvent[CameraID] = true;
				}
			}
		}

		// 收集数据----总线程 
		private void SearchCollectTh() {

			UInt32 startSec = DataModel.Common.ConvertLinuxTime(DateTime.Now);
			UInt32 curSec = DataModel.Common.ConvertLinuxTime(DateTime.Now);

			while (curSec - startSec < 20) {
				// 没有超时 && 所有数据返回
				if (DataIsAllReturn()) {
					break;
				}
				// 停500ms
				System.Threading.Thread.Sleep(500);
				curSec = DataModel.Common.ConvertLinuxTime(DateTime.Now);
			}

			// 超时
			m_OverTime = true;
			if (SearchFinished != null) {
				SearchFinished((object)m_faceInfoList, null);
			}
		}

		private bool DataIsAllReturn() {
			foreach (var item in m_DicFaceEvent) {
				if (false == item.Value) {
					return false;
				}
			}
			return true;
		}

		public void Test_SearchFinsh() {
			if (SearchFinished != null) {
				SearchFinished((object)m_faceInfoList, null);
			}
		}

	}
}
