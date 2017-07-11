using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using IVX.DataModel;
using WinFormAppUtil.ViewModel;


namespace WinFormAppUtil
{
    public partial class FormLoadImage : Form
    {
        #region Fields

        private LoadImageViewModel m_viewModel;
        
        Image m_img = null;
        Rectangle m_rect = new Rectangle();

        int ZoomRate = 100;

        #endregion

        public CompareImageInfo CompareImageInfo
        {
            get
            {
                CompareImageInfo cmpImageInfo = null;

                if (m_viewModel != null)
                {
                    cmpImageInfo = m_viewModel.CompareImageInfo;
                }

                return cmpImageInfo;
            }
        } 

        #region Constructors

        public FormLoadImage(Image img = null,Rectangle rect = new Rectangle(),
            ImageType it = ImageType.Common)
        {
            InitializeComponent();
            ucLocalFileSystem1.FileFilter = "*.png,*.jpg";
            m_viewModel = new LoadImageViewModel(pictureBox1);
            //m_viewModel.PropertyChanged += new PropertyChangedEventHandler(m_VM_PropertyChanged);
            m_viewModel.CurrImageType = it;
            m_viewModel.PicControl = pictureBox1;
            m_viewModel.SetPicDrawTypeRect(DrawGraphType.AnalyseAreaEx, string.Empty);
            m_img = img;
            m_rect = rect;
        }

        #endregion

        #region Private helper functions

        void Zoom()
        {
            pictureBox1.Width = m_viewModel.CurrImage.Width * ZoomRate / 100;
            pictureBox1.Height = m_viewModel.CurrImage.Height * ZoomRate / 100;
            int center_x = ((m_viewModel.ImageRectangle.X + m_viewModel.ImageRectangle.Width) / 2) * ZoomRate / 100;
            int center_y = ((m_viewModel.ImageRectangle.Y + m_viewModel.ImageRectangle.Height) / 2) * ZoomRate / 100;
            splitContainerControl1.Panel2.HorizontalScroll.Value = center_x;
            splitContainerControl1.Panel2.VerticalScroll.Value = center_y;
            //pictureBox1.Left = splitContainerControl1.Panel2.Width/2 - center_x;
            //pictureBox1.Top = splitContainerControl1.Panel2.Height/2 - center_y;
        }

        #endregion

        #region Event handlers

        private void ucLocalFileSystem1_FilesDoubleClicked(object sender, EventArgs e)
        {
            if (ucLocalFileSystem1.SelectedFiles.Count > 0)
            {
                try
                {
                    string filepath = ucLocalFileSystem1.SelectedFiles[0];
                    m_viewModel.CurrImage /*= pictureBox1.Image*/ = Image.FromFile(filepath);
                    m_viewModel.ImageRectangle = new Rectangle(0, 0, m_viewModel.CurrImage.Width, m_viewModel.CurrImage.Height);
                    WinFormAppUtil.AppContainer.Instance.RecentLoadVideoFolder = filepath;
                }
                catch(Exception ex)
                {
                    WinFormAppUtil.AppContainer.Instance.InteractionService.ShowMessageBox("不是有效的图片文件", WinFormAppUtil.AppContainer.Instance.PROGRAM_NAME);
                }
            }
        }

        private void btnBaseImage_Click(object sender, EventArgs e)
        {
            //pictureBox1.Image = m_viewModel.BaseImage;
            m_viewModel.ReturnToBaseImage();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool ret= m_viewModel.Commit();
            if (ret)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void FormLoadImage_Load(object sender, EventArgs e)
        {
            m_viewModel.InitPic();
            ucLocalFileSystem1.SelectFolder(WinFormAppUtil.AppContainer.Instance.RecentLoadVideoFolder);

        }

        private void FormLoadImage_Shown(object sender, EventArgs e)
        {
            if (m_img != null)
            {
                m_viewModel.BaseImage = m_img;
                m_viewModel.CurrImage =  m_img ;
                m_viewModel.ImageRectangle = m_rect;
                //ZoomRate = 100;
                //Zoom();
            }

        }

        private void FormLoadImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.m_viewModel.ClearPic();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (ZoomRate >500)
                return;

            ZoomRate++;
            Zoom();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (ZoomRate < 5)
                return;
            ZoomRate--;
            Zoom();

        }

        #endregion

    }

}
