using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using IVX.DataModel;
using IVX.Live.ViewModel;
using System.Threading;

namespace IVX.Live.MainForm.View {
	public partial class FormBlackPicsAdd : IVX.Live.MainForm.UILogics.FormBase {

		public event EventHandler AddsFinished;
		public BlackListLib CurBlackListLib { get; set; }
		SearchFinshInvoke   m_progressFunc;
		public List<BlackItem> m_list;

		public FormBlackPicsAdd() {
			InitializeComponent();
			m_list = new List<BlackItem> {};
		}

		public override void UpdateUI() {
		}

		public override void Clear() {
		}

		public UInt32 LibHandel { get; set; }

		private void button1_Click(object sender, EventArgs e) {
			OpenFileDialog fileDia = new OpenFileDialog();
			fileDia.Filter = "zip压缩包|*.zip";
			if (fileDia.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				// set FilePath 
				zipFileBox.Text = fileDia.FileName;
			}
		}

		private void Test() {
			if (!Directory.Exists(@"C:\Face1")) {
				MessageBox.Show("文件不存在无法添加");
				return;
			}
			string[] files = Directory.GetFiles(@"C:\Face1");
			List<BlackItem> list = new List<BlackItem> { };
			for (int i = 0; i < files.Length; i++) {
				BlackItem newItem = new BlackItem();
				newItem.LibHandel = LibHandel;
				newItem.Name = "aa";
				newItem.PeopleCard = "340604199209062219";
				Image img = Image.FromFile(files[i]);
				newItem.picData = Convert.ToBase64String(Common.ImageToJpegBytes(img));
				list.Add(newItem);
			}
			BlackListViewModel.Instance.AddBlackListItem(list);
			this.Close();
			if (AddsFinished != null) {
				AddsFinished(null, null);
			}
			MessageBox.Show("添加成功");
		}

		private void FormBlackPicsAdd_Load(object sender, EventArgs e) {
			libName.Text = CurBlackListLib.Name;
			m_progressFunc += new SearchFinshInvoke(AddProgressNotifyFunc);
			BlackListViewModel.Instance.AddProgressNotify += ucAddProgressNotify;
		}

		private void button4_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void button3_Click(object sender, EventArgs e) {
			string filePath = Path.GetDirectoryName(zipFileBox.Text);
			string desPath = Path.Combine(filePath,"img");
			ZipFileViewModel.UnZip(zipFileBox.Text, desPath);
			MessageBox.Show("解压完成,点击确定开始上传", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			// 创建线程开始上传 
			Thread th = new System.Threading.Thread(StartLoadPicImage);
			th.Start(desPath);
		}

		private void StartLoadPicImage(object desPath) {
			DataTable dt = CreateDataTable(Path.Combine((string)desPath, "faceinfo.csv"));
			CreateBlackItemList(dt, (string)desPath);
			AddBlackItemList();
		}

		public void AddBlackItemList() {
			if (m_list.Count <= 0) {
				return;
			}
			BlackListViewModel.Instance.AddBlackListItem(m_list);
		}

		public void CreateBlackItemList(DataTable dt,string picDirPath) {
			string imgFileName = "";
			string imgFilePath = "";
			m_list.Clear();
			for (int i = 0; i < dt.Rows.Count; i++) {
				BlackItem newItem = new BlackItem();
				newItem.LibHandel = LibHandel;
				newItem.Name = dt.Rows[i]["XM"].ToString();
				if (dt.Rows[i]["IMGNAME"].ToString() == "") {
					continue;
				}
				imgFileName = dt.Rows[i]["IMGNAME"].ToString() + ".jpg";
				imgFilePath = Path.Combine(picDirPath, imgFileName);
				Image img = Image.FromFile(imgFilePath);
				newItem.picData = Convert.ToBase64String(Common.ImageToJpegBytes(img));
				img.Dispose();
				m_list.Add(newItem);
			}
		}

		public DataTable CreateDataTable(string filePath) {
			DataTable dt = new DataTable();
			FileStream fs = new FileStream(filePath, FileMode.Open,FileAccess.Read);
			StreamReader sr = new StreamReader(fs,Encoding.Default);
			string strLine = "";
			string[] aryLine = null;
			string[] tableHead = null;
			int columnCount = 0;
			bool isFirst = true;
			while ((strLine = sr.ReadLine()) != null) {
				if (isFirst) {
					tableHead = strLine.Split(',');
					isFirst = false;
					columnCount = tableHead.Length;
					// 创建列
					for (int i = 0; i < columnCount; i++) {
						DataColumn dc = new DataColumn(tableHead[i]);
						dt.Columns.Add(dc);
					}
				}
				else {
					aryLine = strLine.Split(',');
					DataRow dr = dt.NewRow();
					// 创建行
					for (int j = 0; j < columnCount; j++) {
						dr[j] = aryLine[j];
					}
					dt.Rows.Add(dr);
				}
			}
			sr.Close();
			fs.Close();
			return dt;
		}

		void AddProgressNotifyFunc(object value) {
			int barValue = (int)value;
			progressBar1.Value = barValue;
			proLab.Text = barValue.ToString() + "%";
			this.Update();
			if (barValue == 100) {
				MessageBox.Show("添加完成", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				this.Close();
				if (AddsFinished != null) {
					AddsFinished(null, null);
				}
			}
		}

		// 查询 返回函数
		void ucAddProgressNotify(object value, EventArgs e) {
			Invoke(m_progressFunc, value);
		}
		private void FormBlackPicsAdd_FormClosed(object sender, FormClosedEventArgs e) {
			BlackListViewModel.Instance.AddProgressNotify -= ucAddProgressNotify;
		}

	}
}
