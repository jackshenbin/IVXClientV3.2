using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View {
	public partial class ucFaceHistorySearch : UserControl {

		FaceHistorySearchViewModel m_vm;
		List<SearchResultFace> m_list;

		List<Point> m_gloList;
		public ucFaceHistorySearch() {
			InitializeComponent();
		}

		private bool  isPicUse { get; set;}
		private string objRectStr { get; set; }

		private void SetTreeArg() {
			if (DesignMode) return;
			ucTaskTreeBase1.HasRootNode = false;
			ucTaskTreeBase1.HasCheck = true;
			//历史行为事件
			ucTaskTreeBase1.AnalyseFilter = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE_DYNAMIC;
			ucTaskTreeBase1.HasHistoryTask = false;
			ucTaskTreeBase1.TreeTitle = "人脸布控监测点";
		}

		private void ucFaceHistorySearch_Load(object sender, EventArgs e) {
			if (DesignMode) return;
			m_vm = new FaceHistorySearchViewModel();
			m_vm.SearchFinished += m_ucFaceHistorySearchResultPanel.m_viewModel_SearchFinished;
			dateTimeStart.Value = DateTime.Now.AddHours(-1);
			dateTimeEnd.Value = DateTime.Now;
			SetTreeArg();
			ucTaskTreeBase1.InitTree();
			m_list = new List<SearchResultFace> {};
			isPicUse = false;
			objRectStr = "";
			sexBox.SelectedIndex = 0;
		}

		private void searchBtn_Click(object sender, EventArgs e) {

			SearchParaFace facePara = new SearchParaFace();
			if (!ucTaskTreeBase1.IsHasChecked) {
				MessageBox.Show("请选择一个监测点");
				return;
			}
			List<string> CameraIDList = ucTaskTreeBase1.GetCheckTCameraIDList();
			facePara.CameraID = CameraIDList[0];
			facePara.startTime = Common.ConvertLinuxTime(dateTimeStart.Value);
			facePara.endTime = Common.ConvertLinuxTime(dateTimeEnd.Value);
			facePara.Similar = 1;
			facePara.PeopleNation = 1;
			facePara.BeginAge = (uint)startAge.Value;
			facePara.EndAge = (uint)endAge.Value;
			facePara.PeopleSex = (uint)sexBox.SelectedIndex;
			
			if (objRectStr != "") {
				facePara.picData = Convert.ToBase64String(Common.ImageToJpegBytes(pictureBox1.Image));
				facePara.ObjRect = objRectStr;
				facePara.SortType = SortType.SimilarityDes;
			}
			else {
				facePara.picData = "";
				facePara.ObjRect = "";
				facePara.SortType = SortType.TimeAsc;
			}
			isPicUse = false;
			m_ucFaceHistorySearchResultPanel.StartWait();
			m_vm.StartSearchFaceHistory(facePara);
			
			// Test 
			//if (m_list.Count == 0) {
			//    m_list.Clear();
			//    for (int i = 0; i < 30; i++) {
			//        SearchResultFace item = new SearchResultFace();
			//        item.ObjKey = (uint)i;
			//        item.CameraID = "CameraID_" + i.ToString();
			//        item.PeopleSex = 1;
			//        item.PeopleAge = 3;
			//        item.BeginTimeMilliSec = Common.ConvertLinuxTime(DateTime.Now);
			//        item.EndTimeMilliSec = Common.ConvertLinuxTime(DateTime.Now);
			//        m_list.Add(item);
			//    }
			//}
			//else {
			//    m_list.Clear();
			//}
			//m_ucFaceHistorySearchResultPanel.m_viewModel_SearchFinished(m_list, null);
		}
		 
		private void buttonX3_Click(object sender, EventArgs e) {
			dateTimeStart.Value = DateTime.Now.AddHours(-12);
			dateTimeEnd.Value = DateTime.Now;
		}

		private void buttonX2_Click(object sender, EventArgs e) {
			dateTimeStart.Value = DateTime.Now.AddHours(-24);
			dateTimeEnd.Value = DateTime.Now;
		}

		private void pictureBox1_Click(object sender, EventArgs e) {
			FormFaceComparaParam paramForm = new FormFaceComparaParam();

			if (objRectStr != "") {
				paramForm.IMAGE = pictureBox1.Image;
				paramForm.GlobaRegionParam = m_gloList;
			}

			if (paramForm.ShowDialog() == DialogResult.OK) {
				pictureBox1.Image = paramForm.IMAGE;
				objRectStr = paramForm.paraStr;
				if (objRectStr != "") {
					m_gloList = paramForm.GlobaRegionParam;
				}
			}
		}

		private void ucTaskTreeBase1_Load(object sender, EventArgs e) {

		}
	}
}
