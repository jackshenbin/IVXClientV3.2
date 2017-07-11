using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevComponents.AdvTree;
using IVX.DataModel;
using IVX.Live.MainForm.Service;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class FormSingleTrafficEventDetail : UILogics.FormBase
    {

        DataModel.TrafficeEventProperty m_currentRecord;
        List<DataModel.TrafficeEventProperty> m_allrecords = new List<TrafficeEventProperty>();
        public FormSingleTrafficEventDetail()
        {
            InitializeComponent();
            advPropertyGrid1.Appearance.ReadOnlyPropertyStyle = new DevComponents.DotNetBar.ElementStyle(Color.Black);
            advPropertyGrid1.SetPropertyColumnWidth(0, 90);
        }
        public void Init(List<TrafficeEventProperty> trafficEventList)
        {
            if (trafficEventList != null)
            {
                m_allrecords = trafficEventList;

                pageNavigatorEx1.MaxCount = m_allrecords.Count;
                pageNavigatorEx1.Index = 1;
            }
        }
        public override void UpdateUI()
        {
        }

        public override void Clear()
        {
        }

        public void NextRecord()
        {
            if (m_allrecords.Count > 0)
            {
                if (m_currentRecord == null)
                {
                    ShowResult(m_allrecords[0]);
                }
                else
                {
                    int index = m_allrecords.FindIndex(item => item.GetBase().EventId == m_currentRecord.GetBase().EventId);
                    if (index >= 0)
                    {
                        index++;
                        if (index > m_allrecords.Count - 1)
                            index = m_allrecords.Count - 1;
                        ShowResult(m_allrecords[index]);

                    }
                    else
                    {
                        if (m_allrecords.Count > 0)
                        {
                            index = 0;
                            ShowResult(m_allrecords[index]);
                        }
                    }
                }
            }

        }
        public void LastRecord()
        {
            if (m_allrecords.Count > 0)
            {
                if (m_currentRecord == null)
                {
                    ShowResult(m_allrecords[m_allrecords.Count - 1]);
                }
                else
                {
                    ShowResult(m_allrecords[m_allrecords.Count - 1]);
                }
            }

        }
        public void FirstRecord()
        {
            if (m_allrecords.Count > 0)
            {
                if (m_currentRecord == null)
                {
                    ShowResult(m_allrecords[0]);
                }
                else
                {
                    ShowResult(m_allrecords[0]);

                }
            }
        }

        public void PrivRecord()
        {
            if (m_allrecords.Count > 0)
            {
                if (m_currentRecord == null)
                {
                    ShowResult(m_allrecords[m_allrecords.Count-1]);
                }
                else
                {
                    int index = m_allrecords.FindIndex(item => item.GetBase().EventId == m_currentRecord.GetBase().EventId);
                    if (index >= 0)
                    {
                        index--;
                        if (index < 0)
                            index = 0;
                        ShowResult(m_allrecords[index]);

                    }
                    else
                    {
                        if (m_allrecords.Count > 0)
                        {
                            index = 0;
                            ShowResult(m_allrecords[index]);
                        }
                    }
                }
            }
        }

        private void FormExportList_Load(object sender, EventArgs e)
        {
        }




        private void FormExportList_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        public void ShowResult(DataModel.TrafficeEventProperty record)
        {
            if (record == null)
                return;

            if (InvokeRequired)
            {
                Invoke(new Action<DataModel.TrafficeEventProperty>(ShowResult), record);
            }
            else
            {
                int index = m_allrecords.FindIndex(item => item.GetBase().EventId == record.GetBase().EventId);
                if (index >= 0)
                    pageNavigatorEx1.Index = index + 1;
                pageNavigatorEx1.MaxCount = m_allrecords.Count;

                m_currentRecord = record;
                advPropertyGrid1.SelectedObject = record;
                if (record.GetBase().EventImgInfo.Count > 0 && checkBoxX1.Checked)
                {
                    pictureBox5.Image = DataModel.Common.Overlay(System.Drawing.Image.FromStream(record.GetBase().EventImgInfo[0].Item2), record.GetBase().EventImgInfo[0].Item1);
                }
                if (record.GetBase().EventImgInfo.Count > 1 && checkBoxX2.Checked)
                {
                    pictureBox5.Image = DataModel.Common.Overlay(System.Drawing.Image.FromStream(record.GetBase().EventImgInfo[1].Item2), record.GetBase().EventImgInfo[1].Item1);
                }
                if (record.GetBase().EventImgInfo.Count > 2 && checkBoxX3.Checked)
                {
                    pictureBox5.Image = DataModel.Common.Overlay(System.Drawing.Image.FromStream(record.GetBase().EventImgInfo[2].Item2), record.GetBase().EventImgInfo[2].Item1);
                }
                if (record.GetBase().EventImgURLInfo != null && record.GetBase().EventImgURLInfo.Count > 0)
                {
                    pictureBox5.Image = DataModel.Common.Overlay(Common.GetImage(record.GetBase().EventImgURLInfo[0].Item2), record.GetBase().EventImgURLInfo[0].Item1);
                }
                if (checkBoxX4.Checked)
                {
                    if (string.IsNullOrEmpty(record.GetBase().ComposeImgURL))
                        pictureBox5.Image = DataModel.Common.Overlay(System.Drawing.Image.FromStream(record.GetBase().ComposeImgData), new Rectangle());
                    else
                        pictureBox5.Image = DataModel.Common.Overlay(Common.GetImage(record.GetBase().ComposeImgURL), new Rectangle());
                }

            }
        }


        private void buttonGrabpic_Click(object sender, EventArgs e)
        {
            System.Drawing.Image img = null;
            if (m_currentRecord.GetBase().EventImgInfo.Count > 0 && checkBoxX1.Checked)
            {
                img = System.Drawing.Image.FromStream(m_currentRecord.GetBase().EventImgInfo[0].Item2);
            }
            if (m_currentRecord.GetBase().EventImgInfo.Count > 1 && checkBoxX2.Checked)
            {
                img = System.Drawing.Image.FromStream(m_currentRecord.GetBase().EventImgInfo[1].Item2);
            }
            if (m_currentRecord.GetBase().EventImgInfo.Count > 2 && checkBoxX3.Checked)
            {
                img = System.Drawing.Image.FromStream(m_currentRecord.GetBase().EventImgInfo[2].Item2);
            }
            if (m_currentRecord.GetBase().EventImgURLInfo != null && m_currentRecord.GetBase().EventImgURLInfo.Count > 0)
            {
                img = Common.GetImage( m_currentRecord.GetBase().EventImgURLInfo[0].Item2);
            }

            if (checkBoxX4.Checked)
            {
                if (string.IsNullOrEmpty(m_currentRecord.GetBase().ComposeImgURL))
                    img = System.Drawing.Image.FromStream(m_currentRecord.GetBase().ComposeImgData);
                else
                    img = Common.GetImage(m_currentRecord.GetBase().ComposeImgURL);
            }
            if (img != null)
            {
                string time = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string type = "事件截图";
                string fileName = m_currentRecord.EventType + m_currentRecord.PlateNum + type + time + ".jpg";
                bool needSave = true;

                System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
                    sfd.RestoreDirectory = true;
                    sfd.Filter = "图片文件|*.jpg;*.bmp;*.png|全部文件|*.*";
                    sfd.FileName = fileName;
                    sfd.InitialDirectory = Framework.Environment.PictureSavePath;
                    if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        fileName = sfd.FileName;
                    }
                    else
                    {
                        needSave = false;
                    }

                if (needSave)
                {
                    img.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }

            }

        }

        private void pageNavigatorEx1_FirstClick(object sender, EventArgs e)
        {
            FirstRecord();
            buttonPlayEvent.Text = "回溯";
            pictureBox5.BringToFront();
        }

        private void pageNavigatorEx1_LastClick(object sender, EventArgs e)
        {
            LastRecord();
            buttonPlayEvent.Text = "回溯";
            pictureBox5.BringToFront();
        }

        private void pageNavigatorEx1_NextClick(object sender, EventArgs e)
        {
            NextRecord();
            buttonPlayEvent.Text = "回溯";
            pictureBox5.BringToFront();
        }

        private void pageNavigatorEx1_PrivClick(object sender, EventArgs e)
        {
            PrivRecord();
            buttonPlayEvent.Text = "回溯";
            pictureBox5.BringToFront();
        }

        private void buttonPlayEvent_Click(object sender, EventArgs e)
        {
            if (buttonPlayEvent.Text == "回溯")
            {
                buttonPlayEvent.Text = "原图";
                ucPlayHistory1.BringToFront();
                ucPlayHistory1.Text = m_currentRecord.GetBase().EventVideoUrl;
            }
            else
            {
                buttonPlayEvent.Text = "回溯";
                pictureBox5.BringToFront();
            }

        }

    }


}
