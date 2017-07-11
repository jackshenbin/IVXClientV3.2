using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;
using System.Data;

namespace IVX.Live.ViewModel {
	public class BlackListViewModel {

		public event EventHandler AddProgressNotify;

		private BlackListViewModel() {
			m_instance = null;
		}

		public static BlackListViewModel Instance {
			get {
				if (m_instance == null) {
					m_instance = new BlackListViewModel();
				}
				return m_instance;
			}
		}

		private static BlackListViewModel m_instance;

		public DataTable BLackInfoList {
			get {
				DataTable t = new DataTable();
				var key = t.Columns.Add("Handel");
				t.PrimaryKey = new DataColumn[] { key };
				t.Columns.Add("Name");
				t.Columns.Add("Code");
				t.Columns.Add("PicCount");
				foreach (var item in GetBlackList()) {
					t.Rows.Add(item.Handel, item.Name, item.Code, item.PicCount);
				}
				return t;
			}
		}

		public List<BlackListLib> GetBlackList() {
			List<BlackListLib> t_blackListLib = null;
			try {
				t_blackListLib = Framework.Container.Instance.CommService.GET_BLACK_LIST();
			}
			catch (Exception ex) {
				MyLog4Net.Container.Instance.Log.Debug("Error BlackListViewModel GetBlackList:" + ex.ToString());
			}
			return t_blackListLib;
		}

		public int GetBlackLibCount(UInt32 libHandel) {
			List<BlackListLib> t_blackListLib = null; int picCount = 0;
			try {
				t_blackListLib = Framework.Container.Instance.CommService.GET_BLACK_LIST();
			}
			catch (Exception ex) {
				MyLog4Net.Container.Instance.Log.Debug("Error BlackListViewModel GetBlackLibCount:" + ex.ToString());
			}

			foreach (var item in t_blackListLib) {
				if (item.Handel == libHandel) {
					picCount = (int)item.PicCount;
					break;
				}
			}
			return picCount;
		}


		public bool AddBlackListLib(BlackListLib newListLib) {
			bool ret = true;
			try {
				ret = Framework.Container.Instance.CommService.ADD_BLACK_LIST(newListLib);
			}
			catch (Exception ex) {
				MyLog4Net.Container.Instance.Log.Debug("Error BlackListViewModel AddBlackListLib:" + ex.ToString());
				ret = false;
			}
			return ret;
		}

		public bool DelBlackListLib(UInt32 libHandel, out string desStr) {
			bool ret = false;
			desStr = "";
			try {
				ret = Framework.Container.Instance.CommService.DEl_BLACK_LIST(libHandel, out desStr); ;
			}
			catch (Exception ex) {
				MyLog4Net.Container.Instance.Log.Debug("Error BlackListViewModel DelBlackListLib:" + ex.ToString());
				ret = false;
			}
			return ret;
		}

		public List<BlackItem> GetBlackItemList(UInt32 blackListHandel, int pageNum, int perPageCount) {
			List<BlackItem> t_BlackItemList = null;
			try {
				t_BlackItemList = Framework.Container.Instance.CommService.GET_BLACK_FACE_PICTURE(blackListHandel, pageNum, perPageCount);
			}
			catch (Exception ex) {
				t_BlackItemList = new List<BlackItem> { };
				MyLog4Net.Container.Instance.Log.Debug("Error BlackListViewModel GetBlackItemList:" + ex.ToString());
			}
			return t_BlackItemList;
		}

		public bool AddBlackListItem(BlackItem item) {
			bool ret = false;
			try {
				ret = Framework.Container.Instance.CommService.ADD_BLACK_FACE_PICTURE(item);
			}
			catch (Exception ex) {
				MyLog4Net.Container.Instance.Log.Debug("Error BlackListViewModel AddBlackListItem:" + ex.ToString());
			}
			return ret;
		}

		public bool MdfBlackListItem(BlackItem item) {
			bool ret = false;
			try {
				ret = Framework.Container.Instance.CommService.MDF_BLACK_LIST_DATA(item);
			}
			catch (Exception ex) {
				MyLog4Net.Container.Instance.Log.Debug("Error BlackListViewModel MdfBlackListItem:" + ex.ToString());
			}
			return ret;
		}

		public bool DelBlackListItem(UInt32 PicHandel) {
			bool ret = false;
			try {
				ret = Framework.Container.Instance.CommService.DEL_BLACK_FACE_PICTURE(PicHandel);
			}
			catch (Exception ex) {
				MyLog4Net.Container.Instance.Log.Debug("Error BlackListViewModel DelBlackListItem:" + ex.ToString());
			}
			return ret;
		}

		private int cacRate(int sendCount, int toCount) {
			int rate = 0;
			if (sendCount == toCount) {
				rate = 100;
			}
			else {
				double r = (double)sendCount / (double)toCount;
				rate = (int)(r*100);
			}
			return rate;
		}

		public bool AddBlackListItem(List<BlackItem> itemList) {
			bool ret = false;
			int onceCount = 200;
			int toCount = itemList.Count;
			int leftCount = itemList.Count;
			try {
				for (int i = 0; i < itemList.Count; ) {
					if (leftCount >= onceCount) {
						List<BlackItem> list = itemList.GetRange(i, onceCount);
						Framework.Container.Instance.CommService.ADD_BLACK_FACE_PICTURE(list);
						i += onceCount;
						leftCount -= onceCount;
						if (AddProgressNotify != null) {
							AddProgressNotify(((object)cacRate(toCount - leftCount,toCount)), null);
						}
					}
					else if (leftCount > 0) {
						List<BlackItem> list = itemList.GetRange(i, leftCount);
						Framework.Container.Instance.CommService.ADD_BLACK_FACE_PICTURE(list);
						if (AddProgressNotify != null) {
							AddProgressNotify(((object)cacRate(toCount - leftCount, toCount)), null);
						}
						break;
					}
					else {
						break;
					}
				}
				if (AddProgressNotify != null) {
					AddProgressNotify(((object)100), null);
				}
				ret = true;
			}
			catch (Exception ex) {
				MyLog4Net.Container.Instance.Log.Debug("Error BlackListViewModel AddBlackListItem:" + ex.ToString());
			}
			return ret;
		}

	}
}
