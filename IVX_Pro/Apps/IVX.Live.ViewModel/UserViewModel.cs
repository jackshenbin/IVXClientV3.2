using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;
using System.Data;

namespace IVX.Live.ViewModel {

	public class UserViewModel 
	{
		public event EventHandler SearchFinished;
		System.Threading.Thread  getUserListTh;

		// null not have data
		// count ==1 error
		// normal
		public void GetUserList() 
		{
			getUserListTh = new System.Threading.Thread(GetUserListFunc);
			getUserListTh.Start();
		}

		public void GetUserListFunc() 
		{
			List<UserInfo> userListInfo = null;
			try {
				userListInfo = Framework.Container.Instance.CommService.GET_USER_LIST_DATA();
			}
			catch (SDKCallException ex) {
				MyLog4Net.Container.Instance.Log.Debug("GetUserListFunc error" + ex.ToString());
				userListInfo = new List<UserInfo> { };
				UserInfo userInfo = new UserInfo();
				userInfo.UserName = "SDKError";
				userInfo.other = "日志管理-查询错误[" + ex.ErrorCode + "]:" + ex.Message;
				userListInfo.Add(userInfo);
			}

			if (SearchFinished != null) 
			{
				SearchFinished((object)userListInfo,null);
			}
		}

		// 出错 或查找不到 时 返回普通用户
		public UserInfo GetUserInfo(string userName) 
		{
			List<UserInfo> userListInfo = null;
			UserInfo curUser = null;

			if (userName == "superadmin") 
			{
				curUser = new UserInfo();
				curUser.UserName = "superadmin";
				curUser.UserRoleType = 0xff;
				return curUser;
			}

			try 
			{
				userListInfo = Framework.Container.Instance.CommService.GET_USER_LIST_DATA();
			}
			catch (SDKCallException ex) 
			{
				MyLog4Net.Container.Instance.Log.Debug("GetUserInfo error" + ex.ToString());
				return curUser;
			}

			foreach (var item in userListInfo) 
			{
				if (userName == item.UserName) 
				{
					curUser = item.Clone();
					break;
				}
			}
			return curUser;
		}

		public bool AddUser(UserInfo newUser) 
		{
			bool isSuccess = false;
			uint retVal = 1;
			try {
				retVal = Framework.Container.Instance.CommService.ADD_USER_INFO_REQ(newUser);
			}
			catch (SDKCallException ex) {
				MyLog4Net.Container.Instance.Log.Debug("AddUser error" + ex.ToString());
				newUser.other = ex.Message;
			}
			if (retVal == 0) isSuccess = true;
			return isSuccess;
		}

		public bool DelUser(UInt32 userHandel) 
		{
			bool isSuccess = false;
			uint retVal = 1;
			try {
				retVal = Framework.Container.Instance.CommService.DEL_USER_INFO_REQ(userHandel);
			}
			catch (SDKCallException ex) {
				MyLog4Net.Container.Instance.Log.Debug("DelUser error" + ex.ToString());
			}
			if (retVal == 0) isSuccess = true;
			return isSuccess;
		}

		public bool ModUser(UserInfo newUser)
		{
			bool isSuccess = false;
			uint retVal = 1;
			try {
				retVal = Framework.Container.Instance.CommService.MOD_USER_INFO_REQ(newUser);
			}
			catch (SDKCallException ex) {
				MyLog4Net.Container.Instance.Log.Debug("ModUser error" + ex.ToString());
			}
			if (retVal == 0) isSuccess = true;
			return isSuccess;
		}

	}
}
