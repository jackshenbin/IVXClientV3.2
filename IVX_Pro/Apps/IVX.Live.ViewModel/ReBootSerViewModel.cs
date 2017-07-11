using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;
using System.Data;
using Bocom.Live.SocketLib;
using System.IO;

namespace IVX.Live.ViewModel {

	public delegate void NotifyReBootForm(string ip,string status);

	public class ReBootSerViewModel 
	{
		public List<string> serInfo;
		public Dictionary<string, bool> serAckInfo;
		object Lockobj;
		public NotifyReBootForm notifyForm;

		public ReBootSerViewModel()
		{
			serInfo = new List<string> { };
			serAckInfo = new Dictionary<string, bool> { };
			SocketManager.RecvMsg += new onRecvMsg(onRecvAck);
			SocketManager.ConnectAck = null;
			SocketManager.SendCountChange = null;
			Lockobj = new object();
			Bocom.Live.LogDefine.Log.Instance.Close();
		}

		public DataTable ServerList
		{
			get 
			{
				DataTable t = new DataTable();
				t.Columns.Add("ServerIP");
				t.Columns.Add("Status");
				foreach (var item in serInfo) 
				{
					string statusStr = "----";
					t.Rows.Add(item, statusStr);
				}
				return t;
			}
		}

		public void Clear() 
		{
			SocketManager.RecvMsg -= new onRecvMsg(onRecvAck);
		}

		public List<string> GetSerInfo() 
		{
			var serList = Framework.Container.Instance.CommService.GET_SVERVER_LIST();
			serInfo.Clear();
			foreach(var item in serList) 
			{
				if (!serInfo.Contains(item.ServerIP)) 
				{
					serInfo.Add(item.ServerIP);
				}
			}
			return serInfo;
		}

		public void ReBootSingle(string SerIp) 
		{
			MyLog4Net.Container.Instance.Log.Debug("ReBootSingle" + SerIp);
			serAckInfo.Clear();
			serAckInfo[SerIp] = false;
			SocketManager.GetInstatnce().CreatConnect(SerIp);
			RunScript(SerIp);
			new System.Threading.Thread(OutTimeFunc).Start();
		}

		public void ReBootAll() 
		{
			MyLog4Net.Container.Instance.Log.Debug("ReBootAll");
			serAckInfo.Clear();
			foreach (var item in serInfo) 
			{
				serAckInfo[item] = false;
				// ip is item.Key;
				SocketManager.GetInstatnce().CreatConnect(item);
				RunScript(item);
			}
			new System.Threading.Thread(OutTimeFunc).Start();
		}

		public void onRecvAck(Bocom.Live.Define.Common.MSGTYPE ackType, string ip) 
		{
			// 当前 ip已经回复 
			serAckInfo[ip] = true;

			lock(Lockobj) 
			{
				string status = "";
				switch (ackType)
				{
					case Bocom.Live.Define.Common.MSGTYPE.ID_CMD_RUNBATFILE_SUCCESS:
						status = "重启成功";
						break;
					case Bocom.Live.Define.Common.MSGTYPE.ID_CMD_RUNBATFILE_FAIL:
						status = "重启失败";
						break;
					default:
						status = "未知错误";
						break;
				}
				if (notifyForm != null) 
				{
					MyLog4Net.Container.Instance.Log.Debug("onRecvAck" + ip+":"+status);
					notifyForm(ip, status);
				}
			}
		}

		public void DeleteSocket(string ip) 
		{
			SocketManager.GetInstatnce().DeleteConnect(ip);
		}

		private void OutTimeFunc() 
		{
			UInt32 startSec = DataModel.Common.ConvertLinuxTime(DateTime.Now);
			UInt32 curSec = startSec;
			//超时时间为 15s
			while (curSec - startSec < 20) 
			{
				 System.Threading.Thread.Sleep(10);
				 curSec = DataModel.Common.ConvertLinuxTime(DateTime.Now);
				 if (IsAllReturn()) return;
			}

			foreach (var item in serAckInfo)
			{
				if (item.Value == false) 
				{
					if (notifyForm != null) 
					{
						notifyForm(item.Key, "重启失败");
						MyLog4Net.Container.Instance.Log.Debug("OutTimeFunc:" + item.Key + ":重启失败!" );
					}
				}
			}
		}

		private bool IsAllReturn() 
		{
			foreach (var item in serAckInfo) 
			{
				if (item.Value == false)
				{
					return false;
				}
			}
			MyLog4Net.Container.Instance.Log.Debug("-----IsAllReturn true-----");
			return true;
		}

		public  void CreateScript(FileStream bat)
		{
			string text = @"cd /d wdogapp" + System.Environment.NewLine;
			text += @"call uninstall.cmd" + System.Environment.NewLine;
			text += @"choice /t 5 /d y /n >nul" + System.Environment.NewLine;
			text += @"call install.cmd" + System.Environment.NewLine;
			byte[] strByte = System.Text.Encoding.ASCII.GetBytes(text);
			bat.Write(strByte, 0, strByte.Length);
		}

		public void RunScript(string ip)
		{
			string batDir = Path.Combine(System.Environment.CurrentDirectory, "bat");
			if (!Directory.Exists(batDir)) {
				Directory.CreateDirectory(batDir);
			}
			// SocketManager.GetInstatnce().DoCommand(Common.CMDTYPE.CMD_STOPSER, ipItem.ip);
			//----------------stop.bat
			List<string> str1 = new List<string> { };
			string batFilePath = Path.Combine(batDir, "Script.bat");
			// 如果不存在 则创建
			FileStream bat = System.IO.File.Open(batFilePath, FileMode.Create, FileAccess.Write);
			CreateScript(bat);
			bat.Close();
			str1.Add("Script.bat");      // xmlName 
			SocketManager.GetInstatnce().DoCommand(Bocom.Live.Define.Common.CMDTYPE.CMD_BATFILENAME, ip, str1);
			// 发送文件
			str1.Clear();
			str1.Add(batFilePath);
			SocketManager.GetInstatnce().DoCommand(Bocom.Live.Define.Common.CMDTYPE.CMD_SENDXML, ip, str1);
			// 运行文件
			SocketManager.GetInstatnce().DoCommand(Bocom.Live.Define.Common.CMDTYPE.CMD_RUNBATFILE, ip, str1);
			str1.Clear();
			bat.Close();
		}
	}
}
