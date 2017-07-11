using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Globalization;
using IVX.DataModel;
using IVX.Live.ViewModel;
using IVX.Live.MainForm.Service;
using IVX.Live.MainForm.View;

namespace IVX.Live.MainForm {
	public partial class FormMainNew : IVX.Live.MainForm.UILogics.FormBase {
		IVX.Live.MainForm.UILogics.ContentPageController c;
		MainNewViewModel m_viewModel;
		View.FormExportList formExportList;
		SystemMenu m_currentForm;
		LoginViewModel m_logViewModel;
		public FormMainNew() {
			InitializeComponent();
			c = new UILogics.ContentPageController();
			labelItemTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			ShowStatusBar = false;
			labelItemTime.Tooltip = Framework.Environment.Version;
			labelItemStat.Tooltip = Framework.Environment.ServerIP;
		}

		private void AppCommandTheme_Executed(object sender, EventArgs e) {
			ICommandSource source = sender as ICommandSource;
			if (source.CommandParameter is string) {
				eStyle style = (eStyle)Enum.Parse(typeof(eStyle), source.CommandParameter.ToString());
				// Using StyleManager change the style and color tinting
				if (style == eStyle.Metro) {
					StyleManager.MetroColorGeneratorParameters = DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters.DarkBlue;


					StyleManager.Style = eStyle.Metro; // BOOM
				}
				else {
					// If previous style was Metro we need to update other properties as well

					StyleManager.ChangeStyle(style, Color.Empty);
				}

			}
			else if (source.CommandParameter is Color) {
				if (StyleManager.Style == eStyle.Metro)
					StyleManager.MetroColorGeneratorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White, (Color)source.CommandParameter);
				else
					StyleManager.ColorTint = (Color)source.CommandParameter;
			}
		}


		private void FormMain_Shown(object sender, EventArgs e) {

			WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Subscribe(OnNavigateEvent, Microsoft.Practices.Prism.Events.ThreadOption.WinFormUIThread);
			Text = Framework.Environment.PROGRAM_NAME;
			new System.Threading.Thread(thLogin).Start();

		}
		private void OnNavigateEvent(Tuple<SystemMenu, object> info) {
			if (m_currentForm != null) {
				if ((m_viewModel.FormTree.Count > 0 && m_viewModel.FormTree.Peek().URL != m_currentForm.URL)
					|| (m_viewModel.FormTree.Count == 0))
					m_viewModel.FormTree.Push(m_currentForm);
			}

			GoToFrom(info.Item1, info.Item2);
		}

		private void thLogin() {
			System.Threading.Thread.Sleep(200);
			DoLogin();
		}

		private void DoLogin() {
			if (InvokeRequired) {
				this.Invoke(new Action(DoLogin));
			}
			else {
				IVX.Live.MainForm.UILogics.FormBase f = c.GetContentPage(Framework.Environment.DefaultLoginPage.URL);
				f.WindowState = FormWindowState.Normal;
				f.StartPosition = FormStartPosition.CenterParent;
				if (f.ShowDialog() != System.Windows.Forms.DialogResult.OK) {

					this.Close();
				}
				else {
					logOutBtn.Visible = true;
					BuildMenu();
					if (ocx_VodSdk_Init()) {
						Framework.Environment.VODPlayControler = axvodocx1;
					}
					if (ocx_BriefSdk_Init()) {
						Framework.Environment.BriefPlayControler = axbriefocx1;
					}
					IVX.Live.MainForm.UILogics.FormBase f1 = c.GetContentPage(Framework.Environment.DefaultViewPage.URL);
					m_viewModel.FormTree = new Stack<SystemMenu>();
					m_currentForm = Framework.Environment.DefaultViewPage;
					f1.MdiParent = this;
					this.ActivateMdiChild(f1);
					labelX2.Text = "当前位置：" + Framework.Environment.DefaultViewPage.Title;
					f1.Size = new Size(this.Width - panelEx4.Width, panelEx4.Height + 20);
					f1.Show();
					timer1.Start();
					labelUser.Text = "您好，" + Framework.Environment.CurUserInfo.UserName;
				}
			}
		}
		bool ocx_VodSdk_Init() {
			MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_Init ");
			int retVal = axvodocx1.ocx_VodSdk_Init();
			MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_Init retVal:" + retVal);
			return retVal == 0;
		}

		bool ocx_BriefSdk_Init() {
			string initparam = "<root><PlayBufPoolSizeK>204800</PlayBufPoolSizeK></root>";
			MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefSdk_Init initparam:" + initparam);
			uint retVal = axbriefocx1.ocx_BriefVoddcInit(initparam);
			MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefSdk_Init retVal:" + retVal);
			return retVal == 0;
		}

		int ocx_VodSdk_UnInit() {
			MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_UnInit ");
			int retVal = axvodocx1.ocx_VodSdk_UnInit();
			MyLog4Net.Container.Instance.Log.DebugFormat("ocx_VodSdk_UnInit retVal:" + retVal);
			return retVal;
		}
		int ocx_BriefSdk_UnInit() {
			MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefSdk_UnInit ");
			axbriefocx1.ocx_BriefVoddcUnInit();
			MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefSdk_UnInit retVal:" + 0);
			return 0;
		}

		void CommService_FireMessage(string obj) {
			if (InvokeRequired) {
				this.Invoke(new Action<string>(CommService_FireMessage), obj);
			}
			else {
				labelItemStat.Text = obj;
			}
		}
		private void BuildMenu() {
			Dictionary<string, List<SystemMenu>> dt = Framework.Environment.GetSystemMenu();
			foreach (var item in dt) {
				SideBarPanelItem sideBarPanelItem = new SideBarPanelItem();
				// 
				sideBarPanelItem.FontBold = true;
				sideBarPanelItem.Image = c.GetPageICON(item.Key);
				sideBarPanelItem.Text = item.Key;
				sideBarPanelItem.Name = "sideBarPanelItem" + item.Key;
				sideBarPanelItem.ExpandChange += sideBarPanelItem_ExpandChange;
				foreach (var item1 in item.Value) {
					// 
					ButtonItem buttonItem = new ButtonItem();
					buttonItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
					buttonItem.Image = c.GetPageImage(item1.Title);
					buttonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
					buttonItem.Text = item1.Title;
					buttonItem.Tooltip = item1.Discription;
					buttonItem.Tag = item1;
					//buttonItem.OptionGroup = "1";
					//buttonItem.AutoCheckOnClick = true;
					buttonItem.Click += new System.EventHandler(buttonItem_Click);
					sideBarPanelItem.SubItems.Add(buttonItem);
					// 
				}
				sideBar1.Panels.Add(sideBarPanelItem);
			}
			sideBar1.Refresh();
		}

		void sideBarPanelItem_ExpandChange(object sender, EventArgs e) {
			(sender as SideBarPanelItem).Image = ((sender as SideBarPanelItem).Expanded == true) ?
				global::IVX.Live.MainForm.Properties.Resources.下 : global::IVX.Live.MainForm.Properties.Resources.播放1;

		}


		private void buttonItem_Click(object sender, EventArgs e) {
			ButtonItem bt = sender as ButtonItem;
			if (bt == null)
				return;
			SystemMenu menu = bt.Tag as SystemMenu;
			if (m_currentForm != null) {
				if ((m_viewModel.FormTree.Count > 0 && m_viewModel.FormTree.Peek().URL != m_currentForm.URL)
					|| (m_viewModel.FormTree.Count == 0))
					m_viewModel.FormTree.Push(m_currentForm);
			}
			GoToFrom(menu, null);
		}

		private void GoToFrom(SystemMenu menu, object action) {
			if (menu != null) {
				IVX.Live.MainForm.UILogics.FormBase f = c.GetContentPage(menu.URL);
				if (f == null)
					return;
				//if (menu.IsDialog)
				//{
				//    f.WindowState = FormWindowState.Normal;
				//    //f.Size = this.Size;
				//    f.StartPosition = FormStartPosition.CenterParent;
				//    f.ShowDialog();
				//}
				//else
				{
					f.MdiParent = this;
					//this.ActivateMdiChild(f);
					labelX2.Text = "当前位置：" + menu.Title;
					m_currentForm = menu;
					f.Size = new Size(this.Width - panelEx4.Width, panelEx4.Height + 20);
					f.Show();
					f.Activate();
					if (action != null)
						f.DoAction(action);
				}
				//if (!string.IsNullOrEmpty(menu.ParentURL))
				//{
				//    IVX.Live.MainForm.UILogics.FormBase f1 = c.GetContentPage(menu.ParentURL);
				//    f1.MdiParent = this;
				//    this.ActivateMdiChild(f1);
				//    f1.Show();
				//    f1.UpdateUI();
				//}
				string parentMenu = "";
				Dictionary<string, List<SystemMenu>> dt = Framework.Environment.GetSystemMenu();
				foreach (var item in dt) {
					foreach (SystemMenu it in item.Value) {
						if (it.URL == menu.URL) { parentMenu = item.Key; break; }
					}
					if (!string.IsNullOrEmpty(parentMenu))
						break;
				}
				if (!string.IsNullOrEmpty(parentMenu)) {
					sideBar1.GetItem("sideBarPanelItem" + parentMenu).Expanded = true;
				}
			}
		}

		private void FormMainNew_FormClosing(object sender, FormClosingEventArgs e) {
			if (m_viewModel.IsConnected) {
				if (MessageBoxEx.Show("是否要关闭程序？", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != System.Windows.Forms.DialogResult.Yes) {
					e.Cancel = true;
				}
				else {
					m_viewModel.PropertyChanged -= m_viewModel_PropertyChanged;
					c.Cleanup();
					m_viewModel.Clear();
					VideoExportService.Instence.Clear();
					ocx_VodSdk_UnInit();
					ocx_BriefSdk_UnInit();
					WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Unsubscribe(OnNavigateEvent);
					WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<AddVideoDownloadEvent>().Unsubscribe(OnAddVideoDownload);
					WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<DelVideoDownloadEvent>().Unsubscribe(OnDelVideoDownload);
					notifyIcon1.Visible = false;
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e) {
			if (IsDisposed)
				return;
			labelItemTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
			if (DateTime.Now.Second % 5 == 0) {
				labelExportStat.Text = VideoExportService.Instence.GetNextInfo();
				if (!string.IsNullOrEmpty(labelExportStat.Text)) {
					notifyIcon1.Visible = true;
				}
				else
					notifyIcon1.Visible = false;
			}
		}

		void notifyIcon1_Click(object sender, EventArgs e) {
			if (formExportList != null)
				return;
			formExportList = new View.FormExportList();
			formExportList.ShowDialog();
			formExportList = null;
		}

		private void FormMainNew_Load(object sender, EventArgs e) {
			if (DesignMode)
				return;
			m_viewModel = new MainNewViewModel();
			m_logViewModel = new LoginViewModel();
			m_viewModel.PropertyChanged += m_viewModel_PropertyChanged;
			WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<AddVideoDownloadEvent>().Subscribe(OnAddVideoDownload, Microsoft.Practices.Prism.Events.ThreadOption.WinFormUIThread);
			WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<DelVideoDownloadEvent>().Subscribe(OnDelVideoDownload, Microsoft.Practices.Prism.Events.ThreadOption.WinFormUIThread);
		}

		void m_viewModel_PropertyChanged(object sender, PropertyChangedEventArgs e) {
			if (e.PropertyName == "ServerMsg") {
				CommService_FireMessage(m_viewModel.ServerMsg);
			}
			else if (e.PropertyName == "UserDisConnected") {
                MyLog4Net.Container.Instance.Log.Debug("FormMainNew UserDisConnected Relogin");
				Relogin();
			}
		}

		private void Relogin() {
			if (InvokeRequired) {
				this.Invoke(new Action(Relogin));
			}
			else {
				m_viewModel.PropertyChanged -= m_viewModel_PropertyChanged;
				m_viewModel.Clear();
				c.Cleanup();
				VideoExportService.Instence.Clear();
				ocx_VodSdk_UnInit();
				ocx_BriefSdk_UnInit();

				notifyIcon1.Visible = false;
				sideBar1.Panels.Clear();
				labelX2.Text = "";
				labelUser.Text = "欢迎您，请登录";
				labelItemStat.Text = "正在连接服务器...";
				for (int i = this.MdiChildren.Length; i > 0; i--) {
					this.MdiChildren[i - 1].Close();
				}
				this.ActivateMdiChild(null);

				m_viewModel = new MainNewViewModel();
				m_viewModel.PropertyChanged += m_viewModel_PropertyChanged;
				DoLogin();

			}
		}

		private void buttonFormBack_Click(object sender, EventArgs e) {
			if (m_viewModel.FormTree != null && m_viewModel.FormTree.Count > 0) {
				GoToFrom(m_viewModel.FormTree.Pop(), null);
			}
		}

		private void labelExportStat_Click(object sender, EventArgs e) {
			if (formExportList != null)
				return;
			formExportList = new View.FormExportList();
			formExportList.ShowDialog();
			formExportList = null;
		}


		private void OnAddVideoDownload(DownloadInfo info) {
			notifyIcon1.Visible = true;
			notifyIcon1.ShowBalloonTip(500, "开始下载", info.LocalSaveFilePath, ToolTipIcon.Info);
		}

		private void OnDelVideoDownload(DownloadInfo info) {
			notifyIcon1.ShowBalloonTip(500, "取消下载", info.LocalSaveFilePath, ToolTipIcon.Info);
		}

		private void labelUser_Click(object sender, EventArgs e) {
			// 如果 用户已退出
			if (!logOutBtn.Visible) {
                MyLog4Net.Container.Instance.Log.Debug("FormMainNew labelUser_Click Relogin");
                Relogin();
			}
			else {
				if (Framework.Environment.CurUserInfo.UserName != "superadmin") {
					FormUserInfoSingle m_userInfo = new FormUserInfoSingle();
					m_userInfo.InitFormInfo(Framework.Environment.CurUserInfo);
					m_userInfo.ShowDialog();
				}
			}
		}

		private void logOutBtn_Click(object sender, EventArgs e) {
			//如果退出请求成功
			if (m_logViewModel.Logout(Framework.Environment.CurUserInfo.UserHandle)) {
				logOutBtn.Visible = false;
                MyLog4Net.Container.Instance.Log.Debug("FormMainNew logOutBtn_Click Relogin");
                Relogin();
			}
		}

	}
}
