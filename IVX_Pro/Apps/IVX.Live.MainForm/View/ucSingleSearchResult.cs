using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.Live.ViewModel;
using IVX.DataModel;

namespace IVX.Live.MainForm.View
{
    public partial class ucSingleSearchResult : UserControl
    {
        [Category("Search")]
        public new event EventHandler Click;
        [Category("Search")]
        public new event EventHandler DoubleClick;
        [Category("Search")]
        public event EventHandler CheckedChanged;

        DataModel.SearchResultRecordV3_1 m_record;

        public DataModel.SearchResultRecordV3_1 Record
        {
            get { return m_record; }
            set { m_record = value; }
        }
        private bool m_checked = false;
        private int m_group = -1;

        [DefaultValue(false)]
        [Category("Search")]
        public bool Checked
        {
            get { return m_checked; }
            set
            {
                if (m_checked != value)
                {
                    m_checked = value;
                    if (CheckedChanged != null)
                        CheckedChanged(this, null);
                }

                if (m_checked)
                {
                    line1.ForeColor = line2.ForeColor = line3.ForeColor = line4.ForeColor = Color.Orange;
                    SetGroupItemUnchecked();
                }
                else
                {
                    line1.ForeColor = line2.ForeColor = line3.ForeColor = line4.ForeColor = Color.Transparent;
                }

            }
        }

        [Category("Search")]
        public int Group
        {
            get { return m_group; }
            set { m_group = value; }
        }

        public ucSingleSearchResult()
        {
            InitializeComponent();
        }


        private void ucSearchResultPanel_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
        }

		public void ShowResult(SearchResultFace record) {
			if (InvokeRequired) {
				Invoke(new Action<SearchResultFace>(ShowResult), record);
			}
			else {
				// 相机号
				labelX1.ForeColor = Color.Black;
				labelX1.Text = record.CameraID;
				labelX2.Text = Common.ConvertLinuxTime((uint)record.BeginTimeMilliSec).ToString(DataModel.Constant.DATETIME_FORMAT);
				string[] posStrs = record.FacePosition.Split(',');
				Rectangle FacePosition = new System.Drawing.Rectangle(Convert.ToInt32(posStrs[0]),
																	Convert.ToInt32(posStrs[1]),
																	Convert.ToInt32(posStrs[2]),
																	Convert.ToInt32(posStrs[3]));
				System.Drawing.Rectangle rect = FacePosition;
				System.Drawing.Image img = new System.Drawing.Bitmap(FacePosition.Width, FacePosition.Height);
				Graphics g = Graphics.FromImage(img);
				g.DrawImage(DataModel.Common.GetImage(record.OriFacePicPath), new Rectangle(0, 0, FacePosition.Width, FacePosition.Height), rect, GraphicsUnit.Pixel);
				g.Dispose();
				pictureBox1.Image = img;
			}
		}

		public void ShowResult(FaceAlarmInfoV3_1 record) {
			if (InvokeRequired) {
				Invoke(new Action<FaceAlarmInfoV3_1>(ShowResult), record);
			}
			else {
				// 相机号
				labelX1.ForeColor = Color.Black;
				labelX1.Text = record.CameraID;
				labelX2.Text = record.BeginTime.ToString();
				pictureBox1.Image = Common.GetImage(record.OriFacePicPath);
				System.Drawing.Rectangle rect = record.FacePosition;
				System.Drawing.Image img = new System.Drawing.Bitmap(record.FacePosition.Width, record.FacePosition.Height);
				Graphics g = Graphics.FromImage(img);
				g.DrawImage(DataModel.Common.GetImage(record.OriFacePicPath), new Rectangle(0, 0, record.FacePosition.Width, record.FacePosition.Height), rect, GraphicsUnit.Pixel);
				g.Dispose();
				pictureBox1.Image = img;
			}
		}

        public void ShowResult(DataModel.SearchResultRecordV3_1 record)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<DataModel.SearchResultRecordV3_1>(ShowResult), record);
            }
            else
            {
                if (record == m_record)
                    return;
                //pictureBox1.Image = null;
                //if (m_record != null)
                //    m_record.Dispose();
                m_record = record;
                labelX1.ForeColor = Color.Black;
                switch (record.ObjType)
                {
                    case  DataModel.E_SEARCH_RESULT_OBJECT_TYPE.E_SEARCH_RESULT_OBJECT_TYPE_VEHICLE:
                        labelX1.Text = record.PlateNo;
                        if (record.PlateNo == "11111111")
                        { labelX1.Text = "未检测到车牌"; labelX1.ForeColor = Color.Red; }
                        labelX2.Text = record.AdjustTime == new DateTime() ? record.BeginTime.ToString() : record.BeginTime.Add(record.AdjustTime.Subtract(Common.ZEROTIME)).ToString();
                        pictureBox1.Image = record.ThumbPic;
                        break;
                    case  DataModel.E_SEARCH_RESULT_OBJECT_TYPE.E_SEARCH_RESULT_OBJECT_TYPE_PASSAGER:
                    case  DataModel.E_SEARCH_RESULT_OBJECT_TYPE.E_SEARCH_RESULT_OBJECT_TYPE_TWOWHEEL:
                        var color = DataModel.Constant.MoveObjectColorInfos.FirstOrDefault(item => item.Type.ID == record.UpBodyColor);
                        
                        labelX1.Text = (color != null)?color.Name:"";
                        labelX2.Text = record.AdjustTime == new DateTime() ? record.BeginTime.ToString() : record.BeginTime.Add(record.AdjustTime.Subtract(Common.ZEROTIME)).ToString();
                        pictureBox1.Image = record.ThumbPic;
                        break;
                    case E_SEARCH_RESULT_OBJECT_TYPE.E_SEARCH_RESULT_OBJECT_TYPE_NOUSE:
                        labelX1.Text = "未知目标类型";labelX1.ForeColor = Color.GreenYellow;
                        labelX2.Text = record.AdjustTime == new DateTime() ? record.BeginTime.ToString() : record.BeginTime.Add(record.AdjustTime.Subtract(Common.ZEROTIME)).ToString();
                        pictureBox1.Image = record.ThumbPic;
                        break;
                    default:
                        break;
                }
            }
        }

        void CheckedPicture_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (m_checked)
            {
            }
            else
            {
                Checked = !m_checked;
            }
            if (Click != null)
                Click(this, e);
        }

        void CheckedPicture_MouseLeave(object sender, EventArgs e)
        {
            if (m_checked)
            {
                line1.ForeColor = line2.ForeColor = line3.ForeColor = line4.ForeColor = Color.Orange;
            }
            else
            {
                line1.ForeColor = line2.ForeColor = line3.ForeColor = line4.ForeColor = Color.Transparent;
            }
        }

        void CheckedPicture_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!m_checked)
            {
                line1.ForeColor = line2.ForeColor = line3.ForeColor = line4.ForeColor = Color.DeepSkyBlue;
            }
        }
        void CheckedPicture_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (DoubleClick != null)
                DoubleClick(this, e);
        }


        private void SetGroupItemUnchecked()
        {
            if (m_group == -1)
            {
                return;
            }
            else
            {
                IEnumerable<ucSingleSearchResult> list = this.Parent.Controls.OfType<ucSingleSearchResult>();
                foreach (ucSingleSearchResult item in list)
                {
                    if (item.Group == m_group && item != this)
                    {
                        item.Checked = false;
                    }
                }
            }
        }

        public void Clear()
        {
            pictureBox1.Image = null;
            //if (m_record != null)
            //    m_record.Dispose();

        }

    }
}
