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
    public partial class FormEditRealtimeAnalyseParam : IVX.Live.MainForm.UILogics.FormBase
    {
        public TaskInfoV3_1 Task { get; set; }
        public E_VIDEO_ANALYZE_TYPE AlgthmType { get; set; }
        public string AnalyseParam { get; set; }
        public FormEditRealtimeAnalyseParam(TaskInfoV3_1 task, E_VIDEO_ANALYZE_TYPE algthmType, string analyseParam)
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

            ucSinglePlayWnd1.Protocol = Task.DeviceType;
            ucSinglePlayWnd1.IP = Task.DeviceIP;
            ucSinglePlayWnd1.Port = Task.DevicePort;
            ucSinglePlayWnd1.User = Task.LoginUser;
            ucSinglePlayWnd1.Pass = Task.LoginPwd;
            ucSinglePlayWnd1.Channel = Task.ChannelID;
            ucSinglePlayWnd1.StartPlayReal();

        }

        private void FormSingleTask_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucSinglePlayWnd1.StopPlayReal();

            ucSinglePlayWnd1.UnInit();
        }

        private void ucSinglePlayWnd1_MouseDoubleClickEx(object sender, MouseEventArgs e)
        {
            Image img = ucSinglePlayWnd1.GrabPictureData(false);
            if(img!=null)
            
            ucEditTaskAnalyseParam1.DrawImage= img;


        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Image img = ucSinglePlayWnd1.GrabPictureData(false);
            if (img != null)

                ucEditTaskAnalyseParam1.DrawImage = img;

            expandableSplitter1.Expanded = false;
        }
    }
}
