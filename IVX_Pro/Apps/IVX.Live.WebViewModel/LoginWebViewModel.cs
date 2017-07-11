using System;
using System.Collections.Generic;
using System.Text;
using IVX.DataModel;

namespace IVX.Live.WebViewModel
{
    public class LoginWebViewModel
    {
        private string serverip;
        private string localip;
        private string user;
        private string pass;
        public uint Login(string serverip, string localip,string user,string pass, out string msg)
        {
            this.serverip = serverip;
            this.localip = localip;
            this.user = user;
            this.pass = pass;

            uint id = 0;

            if (!Validate())
            {
                msg = "登录参数错误，不能为空";
                return id;
            }

            if (Framework.Container.Instance.CommService.Init(serverip, 9001))
            {
                try
                {
                    string hostname = System.Net.Dns.GetHostName() + "_" + localip;
                    id = Framework.Container.Instance.CommService.LOGIN(user, pass, hostname, 0);
                    if (id > 0)
                    {
                        msg = "连接成功";
                    }
                    else
                        msg = "用户名或密码错误";
                }
                catch (SDKCallException ex)
                {
                    msg = "登录服务器失败：" + ex.Message;
					MyLog4Net.Container.Instance.Log.Debug("Logout" + ex.ToString());
                }
            }
            else
            {
                msg = "无法连接服务器，请确认服务器地址是否正确";
            }
            return id;
        }

		public bool Logout(UInt32 userHandel) 
		{
			bool ret = false;
			try
			{
				//if (Framework.Container.Instance.CommService.LOGOUT() == 0)
				//{
					Framework.Container.Instance.CommService.UnInit();
					ret = true;
				//}
			}
			catch (SDKCallException ex)
			{
				MyLog4Net.Container.Instance.Log.Debug("Logout" + ex.ToString());
			}
			return ret;
		}

        private bool Validate()
        {
            if (string.IsNullOrEmpty(serverip))
                return false;

            if (string.IsNullOrEmpty(localip))
                return false;
            if (string.IsNullOrEmpty(user))
                return false;
            if (string.IsNullOrEmpty(pass))
                return false;
            return true;
        }

    }

}
