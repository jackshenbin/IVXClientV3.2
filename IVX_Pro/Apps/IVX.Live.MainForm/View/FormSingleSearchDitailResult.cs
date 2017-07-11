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
    public partial class FormSingleSearchDitailResult : UILogics.FormBase
    {
        SingleSearchResultPanelViewModel m_baseViewModel;

        uint m_taskId;
        DataModel.SearchResultRecordV3_1 m_currentRecord;
        List<DataModel.SearchResultRecordV3_1> m_allrecords = new List<SearchResultRecordV3_1>();
        public FormSingleSearchDitailResult()
        {
            InitializeComponent();
            advPropertyGrid1.Appearance.ReadOnlyPropertyStyle = new DevComponents.DotNetBar.ElementStyle(Color.Black);
            advPropertyGrid1.SetPropertyColumnWidth(0, 90);
        }
        public void Init(SingleSearchResultPanelViewModel basevm,uint taskId)
        {
            if (basevm != null)
            {
                m_baseViewModel = basevm;
                m_taskId = taskId;
                buttonReviewVideo.Visible = m_baseViewModel.GetTaskInfo(m_taskId).TaskType == TaskType.History;
                if (basevm.SearchResult != null)
                {
                    m_allrecords = basevm.SearchResult;
                    pageNavigatorEx1.MaxCount = m_allrecords.Count;
                    pageNavigatorEx1.Index = 1;
                }
            }
        }
        public override void UpdateUI()
        {
        }

        public override void Clear()
        {
            ucPlayHistory1.Clear();

        }

        private void NextRecord()
        {
            if (m_allrecords.Count > 0)
            {
                if (m_currentRecord == null)
                {
                    ShowResult( m_allrecords[0]);
                }
                else
                {
                    int index = m_allrecords.FindIndex(item => item.ObjKey == m_currentRecord.ObjKey && item.ObjType == m_currentRecord.ObjType);
                    if(index>=0)
                    {
                        index++;
                        if (index > m_allrecords.Count - 1)
                            index = m_allrecords.Count - 1;
                        ShowResult(m_allrecords[index]);

                    }
                }
            }
        }

        private void PrivRecord()
        {
            if (m_allrecords.Count > 0)
            {
                if (m_currentRecord == null)
                {
                    ShowResult(m_allrecords[m_allrecords.Count-1]);
                }
                else
                {
                    int index = m_allrecords.FindIndex(item => item.ObjKey == m_currentRecord.ObjKey && item.ObjType == m_currentRecord.ObjType);
                    if (index >= 0)
                    {
                        index--;
                        if (index <0)
                            index = 0;
                        ShowResult(m_allrecords[index]);

                    }
                }
            }
        }
        private void FirstRecord()
        {
            if (m_allrecords.Count > 0)
            {
                if (m_currentRecord == null)
                {
                    ShowResult( m_allrecords[0]);
                }
                else
                {
                 ShowResult(m_allrecords[0]);

                }
            }
        }

        private void LastRecord()
        {
            if (m_allrecords.Count > 0)
            {
                if (m_currentRecord == null)
                {
                    ShowResult(m_allrecords[m_allrecords.Count-1]);
                }
                else
                {
                    ShowResult(m_allrecords[m_allrecords.Count - 1]);
                }
            }
        }

        private void FormExportList_Load(object sender, EventArgs e)
        {
        }




        private void FormExportList_FormClosing(object sender, FormClosingEventArgs e)
        {
            pictureBox5.Image = null;

        }

        public void ShowResult(DataModel.SearchResultRecordV3_1 record)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<DataModel.SearchResultRecordV3_1>(ShowResult), record);
            }
            else
            {
                int index = m_allrecords.FindIndex(item => item.ObjKey == record.ObjKey && item.ObjType == record.ObjType);
                if (index >= 0)
                    pageNavigatorEx1.Index = index+1;
                m_currentRecord = record;
                m_baseViewModel.GetResultDetail(record);
                Image OriginalPicURL = Common.GetImage(record.OriginalPicURL);
                //if (record.OriginalPic == null)
                //    record.OriginalPic = Common.GetImage(record.OriginalPicURL);
                Rectangle ObjDetailRect = record.ObjDetailRect;
                ObjDetailRect.Offset(record.ObjRect.Location);
                pictureBox5.Image = DataModel.Common.Overlay(OriginalPicURL, record.ObjRect, record.PlateRect, ObjDetailRect);
                OriginalPicURL = null;
                switch (record.ObjType)
                {
                    case DataModel.E_SEARCH_RESULT_OBJECT_TYPE.E_SEARCH_RESULT_OBJECT_TYPE_VEHICLE:
                        advPropertyGrid1.SelectedObject = new VehicleProperty(record);
                        break;
                    case DataModel.E_SEARCH_RESULT_OBJECT_TYPE.E_SEARCH_RESULT_OBJECT_TYPE_PASSAGER:
                    case DataModel.E_SEARCH_RESULT_OBJECT_TYPE.E_SEARCH_RESULT_OBJECT_TYPE_TWOWHEEL:
                        advPropertyGrid1.SelectedObject = new PeopleProperty(record);
                        break;
                    case E_SEARCH_RESULT_OBJECT_TYPE.E_SEARCH_RESULT_OBJECT_TYPE_NOUSE:
                        advPropertyGrid1.SelectedObject = new UnknowProperty(record);
                        break;
                    default:
                        break;
                }
            }
        }


        private void buttonGrabpic_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(m_currentRecord.OriginalPicURL))
            {
                Image OriginalPicURL = Common.GetImage(m_currentRecord.OriginalPicURL);

                string time = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string type = "目标截图";
                string camid = m_baseViewModel.GetTaskInfo(m_taskId).ToString().Replace(".", "_").Replace(":", "_");
                string id = "["+m_currentRecord.ObjKey.ToString().Replace(".", "_").Replace(":", "_")+"]";
                string fileName = camid+id + type + time + ".jpg";
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
                    OriginalPicURL.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    OriginalPicURL.Dispose();
                }

            }

        }

        private void pageNavigatorEx1_FirstClick(object sender, EventArgs e)
        {
            FirstRecord();
            buttonReviewVideo.Text = "回溯";
            pictureBox5.BringToFront();
        }

        private void pageNavigatorEx1_ItemClick(int obj)
        {

        }

        private void pageNavigatorEx1_LastClick(object sender, EventArgs e)
        {
            LastRecord();
            buttonReviewVideo.Text = "回溯";
            pictureBox5.BringToFront();
        }

        private void pageNavigatorEx1_NextClick(object sender, EventArgs e)
        {
            NextRecord();
            buttonReviewVideo.Text = "回溯";
            pictureBox5.BringToFront();

        }

        private void pageNavigatorEx1_PrivClick(object sender, EventArgs e)
        {
            PrivRecord();
            buttonReviewVideo.Text = "回溯";
            pictureBox5.BringToFront();
        }

        private void buttonReviewVideo_Click(object sender, EventArgs e)
        {
            if(m_taskId>0)
            {
                if (buttonReviewVideo.Text == "回溯")
                {
                    buttonReviewVideo.Text = "原图";
                    ucPlayHistory1.BringToFront();
                    ucPlayHistory1.Task = m_baseViewModel.GetTaskInfo(m_taskId);
                    ucPlayHistory1.StartPlay(m_taskId
                        , new DateTime(m_currentRecord.BeginTime.Subtract(Common.ZEROTIME).Ticks)
                        , new DateTime(m_currentRecord.EndTime.Subtract(Common.ZEROTIME).Ticks));
                }
                else
                {
                    buttonReviewVideo.Text = "回溯";
                    pictureBox5.BringToFront();
                }
            }
        }

        private void ucPlayHistory1_CloseThis(object sender, EventArgs e)
        {
            this.Close();
        }

    }


}
