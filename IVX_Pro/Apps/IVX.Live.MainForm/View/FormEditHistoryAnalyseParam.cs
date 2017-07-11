using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using IVX.DataModel;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class FormEditHistoryAnalyseParam : IVX.Live.MainForm.UILogics.FormBase
    {
        EditHistoryAnalyseParamViewModel m_viewModel;
        public TaskInfoV3_1 Task { get; set; }
        public E_VIDEO_ANALYZE_TYPE AlgthmType { get; set; }
        public string AnalyseParam { get; set; }
        public FormEditHistoryAnalyseParam(TaskInfoV3_1 task, E_VIDEO_ANALYZE_TYPE algthmType, string analyseParam)
        {
            InitializeComponent();
            Task = task;
            AlgthmType = algthmType;
            AnalyseParam = analyseParam;
        }

        void ucEditTaskAnalyseParam1_OnCancel(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        void ucEditTaskAnalyseParam1_OnOk(object sender, EventArgs e)
        {
            AnalyseParam = ucEditTaskAnalyseParam1.AnalyseParam;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }


        private void FormSingleTask_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            ucEditTaskAnalyseParam1.SetAnalyseType( AlgthmType);
            ucEditTaskAnalyseParam1.AnalyseParam = AnalyseParam;
            ucEditTaskAnalyseParam1.OnOk += ucEditTaskAnalyseParam1_OnOk;
            ucEditTaskAnalyseParam1.OnCancel += ucEditTaskAnalyseParam1_OnCancel;
            ucSinglePlayWnd1.Init();
            m_viewModel = new EditHistoryAnalyseParamViewModel();
            var mssinfo = m_viewModel.GetMssTaskInfo(Task.TaskId);
            if (mssinfo != null)
            {
                ucSinglePlayWnd1.MSS_IP = mssinfo.MssHostIp;
                ucSinglePlayWnd1.MSS_Port = mssinfo.MssHostPort;
                ucSinglePlayWnd1.MSS_Path = mssinfo.VideoPath;
                ucSinglePlayWnd1.VideoName = Task.TaskName;
                ucSinglePlayWnd1.PlayOrPauseOrResume();
            }
            else
                DevComponents.DotNetBar.MessageBoxEx.Show("无此视频文件", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void FormSingleTask_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucSinglePlayWnd1.StopPlayBack();

            ucSinglePlayWnd1.UnInit();
        }

        private void ucSinglePlayWnd1_MouseDoubleClickEx(object sender, MouseEventArgs e)
        {
            string path = ucSinglePlayWnd1.GrabPictureData(System.IO.Path.GetTempFileName());
            if (!string.IsNullOrEmpty(path))
            {
                Image temp = Image.FromFile(path);
                Image img = new Bitmap(temp);
                temp.Dispose();

                ucEditTaskAnalyseParam1.DrawImage = img;

            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string path = ucSinglePlayWnd1.GrabPictureData(System.IO.Path.GetTempFileName());
            if (!string.IsNullOrEmpty(path))
            {
                Image temp = Image.FromFile(path);
                Image img = new Bitmap(temp);
                temp.Dispose();
                ucEditTaskAnalyseParam1.DrawImage = img;
            }
            expandableSplitter1.Expanded = false ;
        }
    }
}
