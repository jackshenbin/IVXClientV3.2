using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;

namespace IVX.Live.MainForm.View {
	public partial class FormFaceDetailInfo : UILogics.FormBase {

		List<SearchResultFaceProperty> m_allrecords;
		DataModel.SearchResultFaceProperty m_currentRecord;

		public FormFaceDetailInfo() {
			InitializeComponent();
			advPropertyGrid1.Appearance.ReadOnlyPropertyStyle = new DevComponents.DotNetBar.ElementStyle(Color.Black);
			advPropertyGrid1.SetPropertyColumnWidth(0, 90);
		}

		public override void UpdateUI() {
		}

		public override void Clear() {
		}

		public void Init(List<SearchResultFaceProperty> faceResultInfo,SearchResultFaceProperty record) {
			if (faceResultInfo != null) {
				m_allrecords = faceResultInfo;
				pageNavigatorEx1.MaxCount = m_allrecords.Count;
				pageNavigatorEx1.Index = 1;
				m_currentRecord = record; 
			}
		}

		public void NextRecord() {
			if (m_allrecords.Count > 0) {
				if (m_currentRecord == null) {
					ShowResult(m_allrecords[0]);
				}
				else {
					int index = m_allrecords.FindIndex(item => item.GetBase().ObjKey == m_currentRecord.GetBase().ObjKey);
					if (index >= 0) {
						index++;
						if (index > m_allrecords.Count - 1)
							index = m_allrecords.Count - 1;
						ShowResult(m_allrecords[index]);
					}
					else {
						if (m_allrecords.Count > 0) {
							index = 0;
							ShowResult(m_allrecords[index]);
						}
					}
				}
			}

		}

		public void LastRecord() {
			if (m_allrecords.Count > 0) {
				if (m_currentRecord == null) {
					ShowResult(m_allrecords[m_allrecords.Count - 1]);
				}
				else {
					ShowResult(m_allrecords[m_allrecords.Count - 1]);
				}
			}
		}

		public void FirstRecord() {
			if (m_allrecords.Count > 0) {
				if (m_currentRecord == null) {
					ShowResult(m_allrecords[0]);
				}
				else {
					ShowResult(m_allrecords[0]);

				}
			}
		}

		public void PrivRecord() {
			if (m_allrecords.Count > 0) {
				if (m_currentRecord == null) {
					ShowResult(m_allrecords[m_allrecords.Count - 1]);
				}
				else {
					int index = m_allrecords.FindIndex(item => item.GetBase().ObjKey == m_currentRecord.GetBase().ObjKey);
					if (index >= 0) {
						index--;
						if (index < 0)
							index = 0;
						ShowResult(m_allrecords[index]);
					}
					else {
						if (m_allrecords.Count > 0) {
							index = 0;
							ShowResult(m_allrecords[index]);
						}
					}
				}
			}
		}

		private void FormExportList_Load(object sender, EventArgs e) {
		}

		private void FormExportList_FormClosing(object sender, FormClosingEventArgs e) {
		}

		public void ShowResult(DataModel.SearchResultFaceProperty record) {
			if (record == null)
				return;
			m_currentRecord = record;
			if (InvokeRequired) {
				Invoke(new Action<DataModel.SearchResultFaceProperty>(ShowResult), record);
			}
			else {
				int index = m_allrecords.FindIndex(item => item.GetBase().ObjKey == m_currentRecord.GetBase().ObjKey);
				if (index >= 0)
					pageNavigatorEx1.Index = index + 1;
				pageNavigatorEx1.MaxCount = m_allrecords.Count;

				m_currentRecord = record;
				advPropertyGrid1.SelectedObject = record;

				Image img = Common.GetImage(record.GetBase().OriFacePicPath);
				string[] pointStr = record.GetBase().FacePosition.Split(',');

				pictureBox5.Image = img;
				Graphics gs = Graphics.FromImage(img);
				Pen pen = new Pen(Color.Red,3);
				gs.DrawRectangle(pen,Convert.ToInt32(pointStr[0]),Convert.ToInt32(pointStr[1]),Convert.ToInt32(pointStr[2]),Convert.ToInt32(pointStr[3]));

			}
		}


		private void buttonGrabpic_Click(object sender, EventArgs e) {
			System.Drawing.Image img = null;

			if (img != null) {
				string time = DateTime.Now.ToString("yyyyMMddHHmmssfff");
				string type = "截图";
				string fileName = type + time + ".jpg";
				bool needSave = true;

				System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
				sfd.RestoreDirectory = true;
				sfd.Filter = "图片文件|*.jpg;*.bmp;*.png|全部文件|*.*";
				sfd.FileName = fileName;
				sfd.InitialDirectory = Framework.Environment.PictureSavePath;
				if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
					fileName = sfd.FileName;
				}
				else {
					needSave = false;
				}

				if (needSave) {
					img.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
				}

			}

		}

		private void pageNavigatorEx1_FirstClick(object sender, EventArgs e) {
			FirstRecord();
		}

		private void pageNavigatorEx1_LastClick(object sender, EventArgs e) {
			LastRecord();
		}

		private void pageNavigatorEx1_NextClick(object sender, EventArgs e) {
			NextRecord();
		}

		private void pageNavigatorEx1_PrivClick(object sender, EventArgs e) {
			PrivRecord();
		}

		private void buttonGrabpic_Click_1(object sender, EventArgs e) {
			System.Drawing.Image img = pictureBox5.Image;
			if (img != null) {
				string time = DateTime.Now.ToString("yyyyMMddHHmmssfff");
				string type = "截图";
				string fileName = type + time + ".jpg";
				bool needSave = true;

				System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
				sfd.RestoreDirectory = true;
				sfd.Filter = "图片文件|*.jpg;*.bmp;*.png|全部文件|*.*";
				sfd.FileName = fileName;
				sfd.InitialDirectory = Framework.Environment.PictureSavePath;
				if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
					fileName = sfd.FileName;
				}
				else {
					needSave = false;
				}

				if (needSave) {
					img.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
				}

			}
		}

	}
}
