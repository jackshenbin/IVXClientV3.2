using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;

namespace IVX.Live.MainForm.View {

	public partial class ucBlackPicbox : UserControl {

		public ucBlackPicbox() {
			InitializeComponent();
			isGray = false;
		}

		public bool Visible {
			get { return pictureBox1.Visible;}
			set { 
				pictureBox1.Visible=  value;
				checkBox1.Visible  = value;
			}
		}

		public bool isGray {get;set;}

		public bool Checked {
			get { return checkBox1.Checked;}
			set {checkBox1.Checked = value;}
		}

		public bool CheckeVisible {
			get { return checkBox1.Visible; }
			set { checkBox1.Visible = value; }
		}

		public Image Pic {
			get { return pictureBox1.Image; }
			set { pictureBox1.Image = value; }
		}

		public PictureBox PicBox {
			get { return pictureBox1; }
		}

		public void SetGray() {
			pictureBox1.Refresh();
			Brush fill_b = new SolidBrush(Color.FromArgb(100, 140, 140, 140));
			pictureBox1.CreateGraphics().FillRectangle(fill_b, pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
			pictureBox1.Update();
		}


		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);
			if (isGray) {
				SetGray();	
			}
		}
	}
}
