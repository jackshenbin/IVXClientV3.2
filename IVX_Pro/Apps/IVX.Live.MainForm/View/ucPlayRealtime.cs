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

namespace IVX.Live.MainForm.View
{
    public partial class ucPlayRealtime : UserControl
    {
        public event Action<string> PictureSaved4OCX;
        public event EventHandler CloseThis;

        #region 私有变量

        private Form formfull = new Form();

        private System.Drawing.Point PlayWindowLocation = new System.Drawing.Point(0, 0);

        private System.Drawing.Size PlayWindowSize = new System.Drawing.Size(1280, 1024);


        #endregion

        #region 属性
        [DefaultValue(false)]
        public bool ShowGotoCompare { get { return buttonGotoCompare.Visible; } set { buttonGotoCompare.Visible = value; } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaskInfoV3_1 Task { get; set; }
        [DefaultValue(false)]
        public bool IsPlay4OCX { get; set; }

        [DefaultValue("")]
        public string OCX_TaskName { get; set; }


        [DefaultValue(E_VDA_NET_STORE_DEV_PROTOCOL_TYPE.E_DEV_PROTOCOL_CONTYPE_NONE)]
        public DataModel.E_VDA_NET_STORE_DEV_PROTOCOL_TYPE OCX_Protocol { get; set; }
        [DefaultValue("")]
        public string OCX_IP { get; set; }
        [DefaultValue(0)]
        public uint OCX_Port { get; set; }
        [DefaultValue("")]
        public string OCX_User { get; set; }
        [DefaultValue("")]
        public string OCX_Pass { get; set; }
        [DefaultValue("")]
        public string OCX_Channel { get; set; }

        #endregion


        #region 构造
        public ucPlayRealtime()
        {
            InitializeComponent();
            PlayWindowSize = Screen.PrimaryScreen.Bounds.Size;
            PlayWindowLocation = Screen.PrimaryScreen.Bounds.Location;
        }
        #endregion

        #region 公共函数
        public void Clear()
        {
            ucSinglePlayWnd1.StopPlayReal();
            ucSinglePlayWnd1.UnInit();

        }


        #endregion

        #region 事件响应

        private void FormPlayHistory_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            ucSinglePlayWnd1.Init();
            SetButtonStatus();
            SetPlayStatusText();

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
                btnPlay_Click(this, null);
            }
        }

        void ucSinglePlayWnd_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ucSinglePlayWnd wnd = sender as ucSinglePlayWnd;
            if (e.PropertyName == "VideoStatus" )
            {
                SetButtonStatus();
            }
            if (e.PropertyName == "VideoStatusString")
            {
                    SetPlayStatusText();
            }

        }

        void ucSinglePlayWnd_MouseDoubleClickEx(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                FullScreen();
        }

        void ucSinglePlayWnd_MouseClickEx(object sender, MouseEventArgs e)
        {
        }



        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (IsPlay4OCX)
            {
                ucSinglePlayWnd1.Protocol = OCX_Protocol;
                ucSinglePlayWnd1.IP = OCX_IP;
                ucSinglePlayWnd1.Port = OCX_Port;
                ucSinglePlayWnd1.VideoName = OCX_TaskName;
                ucSinglePlayWnd1.User = OCX_User;
                ucSinglePlayWnd1.Pass = OCX_Pass;
                ucSinglePlayWnd1.Channel = OCX_Channel;
                ucSinglePlayWnd1.StartPlayReal();

            }
            else
            {
                if (Task != null)
                {
                    ucSinglePlayWnd1.Protocol = Task.DeviceType;
                    ucSinglePlayWnd1.IP = Task.DeviceIP;
                    ucSinglePlayWnd1.Port = Task.DevicePort;
                    int index = Task.TaskName.LastIndexOf('_');
                    string camName = (index < 0) ? Task.TaskName : Task.TaskName.Substring(index + 1);
                    ucSinglePlayWnd1.VideoName = camName;//.CameraID;
                    ucSinglePlayWnd1.User = Task.LoginUser;
                    ucSinglePlayWnd1.Pass = Task.LoginPwd;
                    ucSinglePlayWnd1.Channel = Task.ChannelID;
                    ucSinglePlayWnd1.StartPlayReal();

                }
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            ucSinglePlayWnd1.StopPlayReal();
        }


        private void buttonX3_Click(object sender, EventArgs e)
        {

            string fileName = "";
            if (IsPlay4OCX)
            {
                string time = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string type = "视频截图";
                fileName = IVX.Live.MainForm.Framework.Environment.PictureSavePath.TrimEnd('\\') + '\\'
                    + OCX_TaskName.Trim().Replace(".", "_").Replace(":", "_") + type + time + ".jpg";

            }
            string retval = ucSinglePlayWnd1.GrabPictureData(fileName);

            if (!string.IsNullOrEmpty(retval))
            {
                if (IsPlay4OCX && PictureSaved4OCX != null)
                {
                    PictureSaved4OCX(retval);
                }
            }

        }        
        private void timer1_Tick(object sender, EventArgs e)
        {
            LabelTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void buttonGotoCompare_Click(object sender, EventArgs e)
        {
            Image img = ucSinglePlayWnd1.GrabPictureData(false);
            if (img != null)
            {
                FormSelectCompareParam f = new FormSelectCompareParam(true);

                f.InitPicture(img, new SelectedPictureParam());

                if (f.ShowDialog() == DialogResult.OK)
                {
                    BeginSearchInfo info = new BeginSearchInfo()
                    {
                        Image = img,
                        PictureParam = f.PictureParam,
                        SearchItem = Task.ToSearchItem(),
                         IsRealtimeTask = true,
                    };
                    if (!f.PictureParam.IsVehicle)
                        WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Publish(
                            new Tuple<SystemMenu, object>(new SystemMenu { URL = "FormPeopleSearch", Title = "行人检索", Discription = "行人检索" }, info));
                    else
                        WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Publish(
                            new Tuple<SystemMenu, object>(new SystemMenu { URL = "FormVehicleSearch", Title = "车辆检索", Discription = "车辆检索" }, info));
                    if (CloseThis != null)
                        CloseThis(sender, e);

                }

            }
        }

        #endregion

        #region 私有函数
        private void FullScreen()
        {
            if (panelEx5.Parent == formfull)
            {
                panelEx5.Parent = panelWin;
                //formfull.PreviewKeyDown -= formfull_PreviewKeyDown;
                formfull.TopMost = false;
                formfull.Close();

            }
            else
            {
                formfull = new Form();
                formfull.KeyPreview = true;
                formfull.BackColor = Color.FromArgb(32, 32, 32);
                formfull.ForeColor = Color.FromArgb(180, 180, 180);
                formfull.TopMost = true;
                formfull.ShowInTaskbar = false;
                formfull.Size = PlayWindowSize;
                formfull.StartPosition = FormStartPosition.Manual;
                formfull.Location = PlayWindowLocation;
                formfull.FormBorderStyle = FormBorderStyle.None;
                panelEx5.Parent = formfull;
                formfull.KeyDown += formfull_KeyDown;
                formfull.Show();
            }
        }
        void formfull_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && panelEx5.Parent == formfull)
            {
                panelEx5.Parent = panelWin;
                formfull.TopMost = false;
                formfull.KeyDown -= formfull_KeyDown;
                formfull.Close();
            }

        }


        private void SetPlayStatusText()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(SetPlayStatusText));
            }
            else
            {
                LabelStatus.Text = ucSinglePlayWnd1.VideoStatusString;
            }
        }
        private void SetButtonStatus()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(SetButtonStatus));
            }
            else
            {
                switch (ucSinglePlayWnd1.VideoStatus)
                {
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_NOVIDEO:
                        buttonPlay.Enabled = true;
                        buttonStop.Enabled = false;
                        buttonGrab.Enabled = false;
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_FAILED:
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_SYNTH_ERROR:
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_SEEK_ERROR:
                        ucSinglePlayWnd1.StopPlayReal();
                        buttonPlay.Enabled = true;
                        buttonStop.Enabled = false;
                        buttonGrab.Enabled = false;
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_NORMAL:
                        buttonPlay.Enabled = true;
                        buttonStop.Enabled = true;
                        buttonGrab.Enabled = true;
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_FINISH:
                        ucSinglePlayWnd1.StopPlayReal();
                        buttonPlay.Enabled = true;
                        buttonStop.Enabled = false;
                        buttonGrab.Enabled = false;
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_STARTPLAY_READY:
                        break;
                    case E_VDA_PLAY_STATUS.E_PLAY_STATUS_PAUSE:
                        buttonPlay.Enabled = true;
                        buttonStop.Enabled = true;
                        buttonGrab.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion






    }
}
