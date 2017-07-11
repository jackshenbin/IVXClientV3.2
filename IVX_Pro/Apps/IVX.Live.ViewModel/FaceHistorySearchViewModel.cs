using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;

namespace IVX.Live.ViewModel {
	public class FaceHistorySearchViewModel {

		private SearchServices.SearchServices m_SearchService = null;
		public event EventHandler SearchFinished;

		private SearchServices.SearchServices SearchService {
			get {
				if (m_SearchService == null) {
					m_SearchService = new SearchServices.SearchServices("http://{0}:{1}/?matchservice.wsdl");
				}
				return m_SearchService;
			}
		}

		public void StartSearchFaceHistory(SearchParaFace para) {
			try
			{
				// 获取 在哪个存储服务器上
				var info = Framework.Container.Instance.CommService.GET_RESULT_STORE_LIST(para.CameraID, E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE_DYNAMIC);
				if (info != null) {
					SearchService.Init(info.StoreIP, info.StortPort);
					SearchService.SearchFaceFinished += SearchService_SearchFinished;
					// 初始化  searchBase 然后 查询
					AddFaceSearchTask(para);
				}
				else {
					MyLog4Net.Container.Instance.Log.Debug("Error FaceHistorySearchViewModel StartSearchFaceHistory: StoreIP == null");
				}
			}
			catch (System.Exception ex)
			{
				MyLog4Net.Container.Instance.Log.Debug("Error FaceHistorySearchViewModel StartSearchFaceHistory:"+ex.ToString());
			}
		}

		private void AddFaceSearchTask(SearchParaFace para) {
			SearchService.ADD_FACE_TASK(para);
		}

		void SearchService_SearchFinished(List<SearchResultFace> faceResultList) {
			if (SearchFinished != null) {
				SearchFinished((object)faceResultList,null);
			}
			SearchService.SearchFaceFinished -= SearchService_SearchFinished;
		}

	}
}
