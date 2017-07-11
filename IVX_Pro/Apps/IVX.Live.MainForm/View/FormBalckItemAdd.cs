using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.Live.ViewModel;
using IVX.DataModel;

namespace IVX.Live.MainForm.View {
	public partial class FormBalckItemAdd : IVX.Live.MainForm.UILogics.FormBase {

		public static int PerPanelCount;
		public List<ucBlackPicbox> m_PanpelPicList;
		public List<BlackItem> m_BlackItemList;
		public UInt32 LibHandel { get; set; }

		public BlackListLib CurBlackListLib { get; set; }

		public event EventHandler RefreshTableFunc;

		public FormBalckItemAdd() {
			InitializeComponent();
			SetWindowSizeable(false);
			m_PanpelPicList = new List<ucBlackPicbox>{};
			m_PanpelPicList.Add(ucBlackPicboxcs1);
			m_PanpelPicList.Add(ucBlackPicboxcs2);
			m_PanpelPicList.Add(ucBlackPicboxcs3);
			m_PanpelPicList.Add(ucBlackPicboxcs4);
			m_PanpelPicList.Add(ucBlackPicboxcs5);
			m_PanpelPicList.Add(ucBlackPicboxcs6);
			m_PanpelPicList.Add(ucBlackPicboxcs7);
			m_PanpelPicList.Add(ucBlackPicboxcs8);
			m_PanpelPicList.Add(ucBlackPicboxcs9);
			m_PanpelPicList.Add(ucBlackPicboxcs10);
			m_PanpelPicList.Add(ucBlackPicboxcs11);
			m_PanpelPicList.Add(ucBlackPicboxcs12);
			m_PanpelPicList.Add(ucBlackPicboxcs13);
			m_PanpelPicList.Add(ucBlackPicboxcs14);
			m_PanpelPicList.Add(ucBlackPicboxcs15);
			m_PanpelPicList.Add(ucBlackPicboxcs16);
			m_PanpelPicList.Add(ucBlackPicboxcs17);
			m_PanpelPicList.Add(ucBlackPicboxcs18);
			PerPanelCount = 18;
			foreach (var item in m_PanpelPicList) {
				item.PicBox.Click +=  new System.EventHandler(pictureBox_Click);
			}
		}

		private void pictureBox_Click(object sender, EventArgs e) {
			FormBlackPicAdd m_form = new FormBlackPicAdd();
			m_form.AddFinished += AddFinsh;
			m_form.CurBlackListLib = CurBlackListLib;
			m_form.isAddMode = false;
			m_form.Init((BlackItem)((PictureBox)sender).Tag, ((PictureBox)sender).Image);
			m_form.Show();
		}

		private void buttonX2_Click(object sender, EventArgs e) {
			FormBlackPicAdd m_form = new FormBlackPicAdd();
			m_form.isAddMode = true;
			m_form.CurBlackListLib = CurBlackListLib;
			m_form.AddFinished += AddFinsh;
			m_form.LibHandel = LibHandel;
			m_form.ShowDialog();
		}

		private void buttonX3_Click(object sender, EventArgs e) {
			FormBlackPicsAdd m_form = new FormBlackPicsAdd();
			m_form.LibHandel = LibHandel;
			m_form.CurBlackListLib = CurBlackListLib;
			m_form.AddsFinished += AddFinsh;
			m_form.ShowDialog();
		}

		private void textBoxX1_TextChanged(object sender, EventArgs e) {

		}

		private void FormBalckItemAdd_Load(object sender, EventArgs e) {
			RefreshPanel();
			libName.Text = CurBlackListLib.Name;
		}

		private void RefreshPanel() {
			SetPanpeMaxCount();
			ReqBlackList();
			SetPanpelList();
		}

		private void SetPanpeMaxCount() {
			int count = BlackListViewModel.Instance.GetBlackLibCount(LibHandel);
			pageBtn.MaxCount = (count / PerPanelCount);
			if (count % PerPanelCount > 0) {
				pageBtn.MaxCount += 1;
			}
			if (pageBtn.Index > pageBtn.MaxCount) {
				pageBtn.Index = pageBtn.MaxCount;
			}
			if (pageBtn.Index == 0 && pageBtn.MaxCount > 0) {
				pageBtn.Index = 1;
			}
		}

		// 获取开始的18个黑名单数据并显示
		private void ReqBlackList() {
			try {
				m_BlackItemList = BlackListViewModel.Instance.GetBlackItemList(LibHandel, pageBtn.Index, PerPanelCount);
			}
			catch (System.Exception ex) {
			}
		}

		private void SetPanpelList() {
			FillPicBox(m_BlackItemList);
		}

		private void FillPicBox(List<BlackItem> panelList) {
			for (int i = 0; i < m_PanpelPicList.Count; i++) {
				m_PanpelPicList[i].Pic = null;
				m_PanpelPicList[i].Tag = null;
				m_PanpelPicList[i].Visible = false;
				m_PanpelPicList[i].Update();
			}
			for (int i = 0; i < panelList.Count; i++) {
				// 如果图片状态
				if (panelList[i].PicState != (uint)E_PICTURE_STATE.STATE_FEATUER_OK) {
					m_PanpelPicList[i].isGray = true;
				}
				else {
					m_PanpelPicList[i].isGray = false;
				}
				m_PanpelPicList[i].Visible = true;
				m_PanpelPicList[i].PicBox.Tag = (object)panelList[i];
				m_PanpelPicList[i].Pic = Common.GetImage(panelList[i].PictureUrl);
				if (m_PanpelPicList[i].isGray) {
					m_PanpelPicList[i].SetGray();
				}
				// IVX.Live.MainForm.Properties.Resources.face;
			}
			//              
		}

		private void buttonX4_Click(object sender, EventArgs e) {
			for (int i = 0; i < 8; i++) {
				m_PanpelPicList[i].Visible = true;
			}
		}

		private void pageBtn_FirstClick(object sender, EventArgs e) {
			ResetCheck();
			ReqBlackList();
			SetPanpelList();
		}

		private void pageBtn_LastClick(object sender, EventArgs e) {
			ResetCheck();
			ReqBlackList();
			SetPanpelList();
		}

		private void pageBtn_NextClick(object sender, EventArgs e) {
			ResetCheck();
			ReqBlackList();
			SetPanpelList();
		}

		private void pageBtn_PrivClick(object sender, EventArgs e) {
			ResetCheck();
			ReqBlackList();
			SetPanpelList();
		}

		private void AddFinsh(object blackItem, EventArgs e) {
			RefreshPanel();
		}

		private void panelEx1_Click(object sender, EventArgs e) {

		}

		private void delBtn_Click(object sender, EventArgs e) {
			foreach (var item in m_PanpelPicList) {
				if (item.Checked && item.Visible) {
					BlackListViewModel.Instance.DelBlackListItem(((BlackItem)item.PicBox.Tag).PicHandel);
				}
			}
			ResetCheck();
			SetPanpeMaxCount();
			ReqBlackList();
			SetPanpelList();
		}

		private void ResetCheck() {
			checkBox1.Checked = false;
			foreach (var item in m_PanpelPicList) {
				item.Checked = false;
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e) {
			bool t_check = checkBox1.Checked;
			foreach(var item in m_PanpelPicList){
				item.Checked = t_check;
			}
		}

		private void FormBalckItemAdd_FormClosed(object sender, FormClosedEventArgs e) {
			if (RefreshTableFunc != null) {
				RefreshTableFunc(null,null);
			}
		}

		private void labelX3_Click(object sender, EventArgs e) {

		}

		private void ucBlackPicboxcs6_Load(object sender, EventArgs e) {

		}
	}
}
