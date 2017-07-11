using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.AdvTree;
using IVX.DataModel;
using IVX.Live.MainForm.Service;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class FormSelectCompareParam : UILogics.FormBase
    {
        public Image SelectedPicture
        {
            get
            {
                if (ucSingleDrawImageWnd1.DrawImage==null || ucSingleDrawImageWnd1.DrawImage.Size == new Size(1, 1))
                    return null;
                return ucSingleDrawImageWnd1.DrawImage;
            }
        }


        public SelectedPictureParam PictureParam
        {
            get
            {
                return m_viewModel.PictureParam;
            }
            set
            {
                m_viewModel.PictureParam = value;
            }
        }

        SelectCompareParamViewModel m_viewModel;
        public FormSelectCompareParam(bool showObjectType = false)
        {
            InitializeComponent();
            groupPanelObjectType.Visible = showObjectType;
        }

        public override void UpdateUI()
        {
        }

        public override void Clear()
        {
        }

        private void FormExportList_Load(object sender, EventArgs e)
        {
            if(m_viewModel==null)
                m_viewModel = new SelectCompareParamViewModel();

            new System.Threading.Thread(() => { System.Threading.Thread.Sleep(200); DoPlay(); }).Start();

        }
        private void DoPlay()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(DoPlay));
            }
            else
            {
                ucSingleDrawImageWnd1_HandleCreated(this, null);
            }
        }
        void ucSingleDrawImageWnd1_HandleCreated(object sender, EventArgs e)
        {
            if (m_viewModel.IsGlobalRegion) ucSingleDrawImageWnd1.GlobaRegionParam = m_viewModel.GlobalRegion;
            if (m_viewModel.IsParticalRegion) ucSingleDrawImageWnd1.ParticalRegionParam = m_viewModel.ParticalRegion;
            if (m_viewModel.IsPassLine) ucSingleDrawImageWnd1.PassLineParam = m_viewModel.PassLineList;
            if (m_viewModel.IsBreakRegion) ucSingleDrawImageWnd1.BreakAreaParam = m_viewModel.BreakRegionList;

            checkBoxBreakRect.Checked = m_viewModel.IsBreakRegion;
            checkBoxPassline.Checked = m_viewModel.IsPassLine;
            checkBoxObjRect.Checked = m_viewModel.IsGlobalRegion;
            checkBoxParticalRect.Checked = m_viewModel.IsParticalRegion;

        }

        private void FormExportList_FormClosing(object sender, FormClosingEventArgs e)
        {
        }



        private void buttonOK_Click(object sender, EventArgs e)
        {
            m_viewModel.IsBreakRegion = checkBoxBreakRect.Checked;
            m_viewModel.IsPassLine = checkBoxPassline.Checked;
            m_viewModel.IsGlobalRegion = checkBoxObjRect.Checked;
            m_viewModel.IsParticalRegion = checkBoxParticalRect.Checked;

            if (ucSingleDrawImageWnd1.DrawImage != null)
            {
                m_viewModel.GlobalRegion = ucSingleDrawImageWnd1.GlobaRegionParam;
                m_viewModel.ParticalRegion = ucSingleDrawImageWnd1.ParticalRegionParam;
                m_viewModel.PassLineList = ucSingleDrawImageWnd1.PassLineParam;
                m_viewModel.BreakRegionList = ucSingleDrawImageWnd1.BreakAreaParam;
                m_viewModel.BasePicture = ucSingleDrawImageWnd1.DrawImage;
                
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void buttonSelectPic_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.RestoreDirectory = true;
            ofd.Filter = "图片文件|*.jpg;*.bmp;*.png|全部文件|*.*";
            ofd.InitialDirectory = Framework.Environment.PictureSavePath;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = ofd.FileName;
                Image temp = Image.FromFile(fileName);
                Image img = new Bitmap(temp);
                temp.Dispose();
                if (img != null)
                {
                    ucSingleDrawImageWnd1.DrawImage = img; 
                    ucSingleDrawImageWnd1.ClearAllGraphs();
                }
            }

        }


        private void buttonReset_Click(object sender, EventArgs e)
        {
            ucSingleDrawImageWnd1.ClearAllGraphs();
            checkBoxBreakRect.Checked = false;
            checkBoxObjRect.Checked = false;
            checkBoxParticalRect.Checked = false;
            checkBoxPassline.Checked = false;
            ucSingleDrawImageWnd1.DrawImage = new Bitmap(1, 1);
        }



        internal void InitPicture(Image pic, SelectedPictureParam param)
        {
            m_viewModel = new SelectCompareParamViewModel();

            ucSingleDrawImageWnd1.DrawImage = pic;// param.BasePicture;
            m_viewModel.PictureParam = param;

        }

        private void checkBoxObjRect_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxObjRect.Checked)
                ucSingleDrawImageWnd1.SetDrawType(DrawGraphType.GlobaRegion);
            m_viewModel.IsGlobalRegion = checkBoxObjRect.Checked;

        }

        private void checkBoxParticalRect_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxParticalRect.Checked)
                ucSingleDrawImageWnd1.SetDrawType(DrawGraphType.ParticalRegion);
            m_viewModel.ParticalRegion = ucSingleDrawImageWnd1.ParticalRegionParam;
        }

        private void checkBoxPassline_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxPassline.Checked)
                ucSingleDrawImageWnd1.SetDrawType(DrawGraphType.PassLine);
            m_viewModel.PassLineList = ucSingleDrawImageWnd1.PassLineParam;
        }

        private void checkBoxBreakRect_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBreakRect.Checked)
                ucSingleDrawImageWnd1.SetDrawType(DrawGraphType.PassRegion);
            m_viewModel.BreakRegionList = ucSingleDrawImageWnd1.BreakAreaParam;
        }

        private void checkBoxPerson_CheckedChanged(object sender, EventArgs e)
        {
            m_viewModel.IsVehicle = checkBoxVehicle.Checked;
        }

        private void checkBoxVehicle_CheckedChanged(object sender, EventArgs e)
        {
            m_viewModel.IsVehicle = checkBoxVehicle.Checked;

        }
    }
}
