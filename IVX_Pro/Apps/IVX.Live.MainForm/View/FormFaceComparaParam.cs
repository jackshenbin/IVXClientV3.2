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
	public partial class FormFaceComparaParam : UILogics.FormBase {
		public FormFaceComparaParam() {
			InitializeComponent();
			paraStr = "";
			IMAGE = null;
		}
		List<Point> m_list;
        public override void UpdateUI()
        {
        }

        public override void Clear()
        {
        }

		public List<Point> GlobaRegionParam {
			get { return m_list; }
			set { ucSingleDrawImageWnd1.GlobaRegionParam = value; }
		}

		public Image IMAGE { 
			get { return ucSingleDrawImageWnd1.DrawImage; }
			set { ucSingleDrawImageWnd1.DrawImage = value; }
		}
		public string paraStr  { get; set; }

		private void buttonSelectPic_Click(object sender, EventArgs e) {
			System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
			ofd.RestoreDirectory = true;
			ofd.Filter = "图片文件|*.jpg;*.bmp;*.png|全部文件|*.*";
			ofd.InitialDirectory = Framework.Environment.PictureSavePath;
			if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				string fileName = ofd.FileName;
				Image temp = Image.FromFile(fileName);
				Image img = new Bitmap(temp);
				temp.Dispose();
				if (img != null) {
					ucSingleDrawImageWnd1.DrawImage = img;
					IMAGE = img;
					ucSingleDrawImageWnd1.ClearAllGraphs();
				}
			}
		}

		private void buttonX1_Click(object sender, EventArgs e) {
			
		}

		private void buttonReset_Click(object sender, EventArgs e) {
			ucSingleDrawImageWnd c = ucSingleDrawImageWnd1;
			c.ClearAllGraphs();
		}

		private void buttonOK_Click(object sender, EventArgs e) {
			ucSingleDrawImageWnd c = ucSingleDrawImageWnd1;
			m_list = c.GlobaRegionParam;
			Point start0 = m_list[0];
			Point start2 = m_list[2];
			int width = start2.X - start0.X;
			int height = start2.Y - start0.Y;
			paraStr = m_list[0].X.ToString() + ","
					+ m_list[0].Y.ToString() + "," 
					+ width.ToString() + "," 
					+ height.ToString();
			DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		private void checkBoxObjRect_CheckedChanged(object sender, EventArgs e) {
			if (checkBoxObjRect.Checked) {
				ucSingleDrawImageWnd c = ucSingleDrawImageWnd1;
				c.SetDrawType(DrawGraphType.GlobaRegion);
			}
		}
	}
}
