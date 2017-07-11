using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm {
	public partial class FormBlackPicAdd : IVX.Live.MainForm.UILogics.FormBase {

		public event EventHandler AddFinished;

		public FormBlackPicAdd() {
			InitializeComponent();
		}

		public UInt32 LibHandel { get; set; }
		public bool isAddMode { get; set; }
		public BlackItem curItem { get;set;}

		public BlackListLib CurBlackListLib { get; set; }

		public void SetMode() {
			if (isAddMode) {
				this.Text = "单个录入";
				picState.Visible = false;
			}
			else {
				this.Text = "单个查看";
				picState.Visible = true;
			}
		}

		private void pictureBox5_Click(object sender, EventArgs e) {
			OpenFileDialog fileDia = new OpenFileDialog();
			fileDia.Filter = "图片文件|*.*";
			if (fileDia.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				Image img = Image.FromFile(fileDia.FileName);
				pictureBox5.Image = img;
			}
		}

		private void cancelBtn_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void AddBtn_Click(object sender, EventArgs e) {
			errorLabel.Text = "";
			BlackItem newItem = new BlackItem();
			newItem.LibHandel = LibHandel;
			newItem.Name = nameTextBox.Text;
			newItem.PeopleSex = (UInt32)sexBox.SelectedIndex + 1;
			newItem.PeopleAge = (UInt32)Convert.ToInt32(ageText.Text);
			newItem.PeopleHeight = Convert.ToUInt32(heightText.Text);
			newItem.PeopleWeight = Convert.ToUInt32(weightText.Text);
			newItem.BloodType = (UInt32)bloodBox.SelectedIndex + 1;
			// 身份证号
			newItem.PeopleCard = cardText.Text;
			newItem.Address = adressTxt.Text;
			newItem.picData = Convert.ToBase64String(Common.ImageToJpegBytes(pictureBox5.Image));
			if (isAddMode) {
				if (BlackListViewModel.Instance.AddBlackListItem(newItem)) {
					this.Close();
					if (AddFinished != null) {
						AddFinished(null, null);
					}
				}
				else {
					errorLabel.Text = "添加失败!";
				}
			}
			// 修改模式
			else {
				newItem.PicHandel = curItem.PicHandel;
				if (BlackListViewModel.Instance.MdfBlackListItem(newItem)) {
					this.Close();
					if (AddFinished != null) {
						AddFinished(null, null);
					}
				}
				else {
					errorLabel.Text = "修改失败!";
				}
			}
		}

		private void FormBlackPicAdd_Load(object sender, EventArgs e) {
			errorLabel.Text = "";
			SetMode();
			libName.Text = CurBlackListLib.Name;
		}

		private void ageText_TextChanged(object sender, EventArgs e) {

		}

		public void Init(BlackItem newItem,Image img) {
			if (newItem == null) return;
			curItem = newItem;
			LibHandel = newItem.LibHandel;
			nameTextBox.Text = newItem.Name;
			
			ageText.Text	 = newItem.PeopleAge.ToString();
			pictureBox5.Image = img;

			sexBox.SelectedIndex = (int)newItem.PeopleSex - 1;
			heightText.Text = newItem.PeopleHeight.ToString();
			weightText.Text = newItem.PeopleWeight.ToString();
			bloodBox.SelectedIndex = (int)newItem.BloodType-1;

			cardText.Text = newItem.PeopleCard;
			adressTxt.Text = newItem.Address;

		}

	}
}
