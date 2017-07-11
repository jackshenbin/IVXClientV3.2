using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using DevComponents.DotNetBar;
using IVX.DataModel;
using IVX.Live.ViewModel;
using System.Linq;

namespace IVX.Live.MainForm.View
{
    public partial class FormAddEditFaceSubscribe : IVX.Live.MainForm.UILogics.FormBase
    {
        SubscribeViewModel m_viewModel;
        public FormAddEditFaceSubscribe()
        {
            InitializeComponent();
            SetWindowSizeable(false);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
                DialogResult =System.Windows.Forms.DialogResult.OK;
        }


        private void buttonX1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }



        public override void UpdateUI()
        {
        }

        public override void Clear()
        {
            
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            m_viewModel = new SubscribeViewModel();
            m_viewModel.UserName = Framework.Environment.CurUserInfo.UserName;
            m_viewModel.ClientIP = Framework.Environment.LocalCommIP;
            m_viewModel.ClientPort = Framework.Environment.AlarmReceivePort;

            foreach (var item in m_viewModel.BlackListLibs)
	        {    
                DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX = new DevComponents.DotNetBar.Controls.CheckBoxX();

                checkBoxX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                checkBoxX.AutoSize = true;
                checkBoxX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
                checkBoxX.TabIndex = 0;
                checkBoxX.Text = item.Name+"["+item.PicCount+"]";
                checkBoxX.Tag = new Tuple<uint,uint>(item.Handel,0);
                checkBoxX.CheckedChangedEx += checkBoxX_CheckedChangedEx;
                flowLayoutPanel1.Controls.Add(checkBoxX);

	        }
            
            advTree1.DataSource = m_viewModel.FaceSubscribe;
        }

        void checkBoxX_CheckedChangedEx(object sender, DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs e)
        {
            if (e.EventSource != eEventSource.Code)
            {
                uint blackhandle = (e.NewChecked.Tag as Tuple<uint, uint>).Item1;
                uint subscribehandle = (e.NewChecked.Tag as Tuple<uint, uint>).Item2;
                if (e.NewChecked.Checked)
                {
                   uint ret = m_viewModel.SubscribeFaceAlarm(groupPanel2.Tag.ToString(),blackhandle);
                   if (ret > 0)
                       e.NewChecked.Tag = new Tuple<uint, uint>(blackhandle, ret); 
                   else
                       e.NewChecked.Checked = false;

                }
                else
                    m_viewModel.UnsubscribeFaceAlarm(groupPanel2.Tag.ToString(), subscribehandle);
                advTree1.DataSource = m_viewModel.FaceSubscribe;

            }
        }

        private void advTree1_DataSourceChanged(object sender, EventArgs e)
        {
            foreach (DevComponents.AdvTree.Node item in advTree1.Nodes)
            {
                item.Cells[2].TagString = "BlackListLibs";
                item.Cells[3].Text = "<a href=\"play\">视频播放</a>";
                item.Cells[4].Text = "<a href=\"del\">取消订阅</a>";
            }

        }

        private void advTree1_MarkupLinkClick(object sender, DevComponents.AdvTree.MarkupLinkClickEventArgs e)
        {
            if (e.HRef == "del")
            {

            }

        }
        DateTime t = new DateTime();
        private void advTree1_BeforeCellEdit(object sender, DevComponents.AdvTree.CellEditEventArgs e)
        {
            if(e.Cell.TagString == "BlackListLibs")
            {
                t = DateTime.Now;
                e.Cancel = true;
                groupPanel2.Location =  e.Cell.Bounds.Location;
                string camid = (e.Cell.Parent.DataKey as DataRowView).Row.ItemArray[1].ToString();
                List<SubscribeInfo> list = (e.Cell.Parent.DataKey as DataRowView).Row.ItemArray[3] as List<SubscribeInfo>;
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX = c as DevComponents.DotNetBar.Controls.CheckBoxX;
                    uint blackhandle = (checkBoxX.Tag as Tuple<uint, uint>).Item1;
                    var info = list.FirstOrDefault(item => item.BlackListHandle.ToString() == blackhandle.ToString());
                    
                    if (info!=null)
                    {
                        checkBoxX.Checked = true;
                        checkBoxX.Tag = new Tuple<uint,uint>(blackhandle, info.SubscribeHandle);
                    }
                }
                groupPanel2.Tag = camid;
                groupPanel2.Show();
            }
        }

        private void advTree1_AfterCellEditComplete(object sender, DevComponents.AdvTree.CellEditEventArgs e)
        {

        }

        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            groupPanel2.Hide();
        }

        private void groupPanel2_Leave(object sender, EventArgs e)
        {
        }

        private void advTree1_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void advTree1_MouseClick(object sender, MouseEventArgs e)
        {
            if (t != new DateTime() && DateTime.Now.Subtract(t).TotalMilliseconds > 500)
            {
                groupPanel2.Hide();
                t = new DateTime();
            }
        }

        private void groupPanel2_VisibleChanged(object sender, EventArgs e)
        {
            if(!groupPanel2.Visible)
            {
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX = c as DevComponents.DotNetBar.Controls.CheckBoxX;
                        checkBoxX.Checked = false;
                        uint blackhandle = (checkBoxX.Tag as Tuple<uint, uint>).Item1;
                        checkBoxX.Tag = new Tuple<uint, uint>(blackhandle, 0);
                }
                groupPanel2.Tag = null;
            }
        }

    }
}