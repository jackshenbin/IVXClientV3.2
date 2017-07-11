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
    public partial class FormSingleBehaviourEvnetDetail : UILogics.FormBase
    {

        DataModel.BehaviorProperty m_currentRecord;
        List<DataModel.BehaviorProperty> m_allrecords = new List<BehaviorProperty>();
        public FormSingleBehaviourEvnetDetail()
        {
            InitializeComponent();
            advPropertyGrid1.Appearance.ReadOnlyPropertyStyle = new DevComponents.DotNetBar.ElementStyle(Color.Black);
            advPropertyGrid1.SetPropertyColumnWidth(0, 90);
			ImageUseURL = false;
        }

		public bool ImageUseURL { get; set; }

        public void Init(List<BehaviorProperty> trafficEventList)
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
                    int index = m_allrecords.FindIndex(item => item.GetBase().ObjectId == m_currentRecord.GetBase().ObjectId);
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
                    int index = m_allrecords.FindIndex(item => item.GetBase().ObjectId == m_currentRecord.GetBase().ObjectId);
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

        public void ShowResult(DataModel.BehaviorProperty record)
        {
            if (record == null)
                return;

            if (InvokeRequired)
            {
                Invoke(new Action<DataModel.BehaviorProperty>(ShowResult), record);
            }
            else
            {
                int index = m_allrecords.FindIndex(item => item.GetBase().ObjectId == record.GetBase().ObjectId);
                if (index >= 0)
                    pageNavigatorEx1.Index = index + 1;
                pageNavigatorEx1.MaxCount = m_allrecords.Count;

                m_currentRecord = record;
                advPropertyGrid1.SelectedObject = record;
				if (ImageUseURL)
					pictureBox5.Image = DataModel.Common.Overlay(Common.GetImage(record.GetBase().EventImgUrl), record.GetBase().EventObjRect);
				else	
					pictureBox5.Image = DataModel.Common.Overlay(System.Drawing.Image.FromStream(record.GetBase().Image), record.GetBase().EventObjRect);
            }
        }


        private void buttonGrabpic_Click(object sender, EventArgs e)
        {
            System.Drawing.Image img =null;
			if (ImageUseURL) 
			{
				img = Common.GetImage(m_currentRecord.GetBase().EventImgUrl);
			}
            else 
			{
				img = System.Drawing.Image.FromStream(m_currentRecord.GetBase().Image);
			}
            if (img != null)
            {
                string time = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string type = "行为事件截图";
                string fileName = m_currentRecord.EventType + type + time + ".jpg";
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
        }

        private void pageNavigatorEx1_LastClick(object sender, EventArgs e)
        {
            LastRecord();
        }

        private void pageNavigatorEx1_NextClick(object sender, EventArgs e)
        {
            NextRecord();
        }

        private void pageNavigatorEx1_PrivClick(object sender, EventArgs e)
        {
            PrivRecord();
        }


    }


}
