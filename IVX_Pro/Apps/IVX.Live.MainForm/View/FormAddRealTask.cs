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

namespace IVX.Live.MainForm.View
{
    public partial class FormAddRealTask : UILogics.FormBase
    {
        private ViewModel.TaskAddRealViewModel m_viewModel;

        public DataModel.E_VDA_NET_STORE_DEV_PROTOCOL_TYPE Protocol { get; set; }
        public string IP { get; set; }
        public uint Port { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string Channel { get; set; }
        public string VideoName { get { return Text; } set { Text = value; } }

        public string CameraID { get; set; }
        public FormAddRealTask()
        {
            InitializeComponent();
            UseMdiDefaultWindow(false);
            ucSinglePlayWnd1.HandleCreated += new EventHandler(ucSinglePlayWnd1_HandleCreated);

        }
        void ucSinglePlayWnd1_HandleCreated(object sender, EventArgs e)
        {
            new System.Threading.Thread(thPlay).Start();
        }
        private void thPlay()
        { DoPlay(); }

        private void DoPlay()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(DoPlay));
            }
            else
            {
                ucSinglePlayWnd1.Protocol = Protocol;
                ucSinglePlayWnd1.IP = IP;
                ucSinglePlayWnd1.Port = Port;
                ucSinglePlayWnd1.User = User;
                ucSinglePlayWnd1.Pass = Pass;
                ucSinglePlayWnd1.Channel = Channel;
                ucSinglePlayWnd1.Init();
                ucSinglePlayWnd1.StartPlayReal();
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            if (panelEx4.Controls.Count > 0)
            {
                IAnalyseSetting item = panelEx4.Controls[0] as IAnalyseSetting;
                if (ucSingleDrawImageWnd1.DrawImage == null)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("请先设置参考图片", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    return;
                }
                try
                {
                    if (m_viewModel.Submit(item.AnalyseParam))
                    {
                        this.Close();
                    }
                }
                catch (SDKCallException ex)
                {
                    MessageBoxEx.Show("添加实时任务失败，[" + ex.ErrorCode + "]" + ex.Message,Framework.Environment.PROGRAM_NAME,MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                }

            }
        }

        private void FormAddRealTask_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            m_viewModel = new ViewModel.TaskAddRealViewModel();
            m_viewModel.Protocol = Protocol;
            m_viewModel.IP = IP;
            m_viewModel.Port = Port;
            m_viewModel.User = User;
            m_viewModel.Pass = Pass;
            m_viewModel.Channel = Channel;
            m_viewModel.CameraID = CameraID;
            m_viewModel.CameraName = VideoName;
            List<Control> clist = CreateFilterControl();
            flowLayoutPanel1.Controls.AddRange(clist.ToArray());
            dateTimeStart.Value = DateTime.Now.AddHours(-1);
            dateTimeEnd.Value = DateTime.Now;
        }
        private List<Control> CreateFilterControl()
        {
            List<Control> clist = new List<Control>();

            foreach (E_VIDEO_ANALYZE_TYPE item in Enum.GetValues(typeof(E_VIDEO_ANALYZE_TYPE)))
            {
                if (item == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE)
                    continue;
                if (item == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ)
                    continue;
                if (item == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_VEHICLE)
                    continue;
                if (item == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_SPECIAL_EFFECT_WIPEOFF_FOG)
                    continue;
                if (item == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_IMAGE_SEARCH)
                    continue;
                if (item == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_ACCIDENT_ALARM)
                    continue;
                if (item == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BRIEAF)
                    continue;
                if (item == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_DYNAMIC_VEHICLE)
                    continue;
                if (item == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE)
                    continue;
                
                DevComponents.DotNetBar.ButtonX b = new DevComponents.DotNetBar.ButtonX();
                b.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
                b.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
                b.Name = "btnSelectAnalyseType_" + item.ToString();
                b.Size = new System.Drawing.Size(75, 23);
                b.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
                b.Click += new System.EventHandler(this.btnSetAnalyseType_Click);
                b.Text = DataModel.Constant.VideoAnalyzeTypeInfo.Single(it => it.Type == item).Name;
                b.Tag = item;
                clist.Add(b);
            }
            return clist;
        }

		private void SetSetAnalyseTypeBtnCheck(E_VIDEO_ANALYZE_TYPE analyzeType)
		{
			foreach (var item in flowLayoutPanel1.Controls) 
			{
				DevComponents.DotNetBar.ButtonX b = item as DevComponents.DotNetBar.ButtonX;
				if ((E_VIDEO_ANALYZE_TYPE)b.Tag == analyzeType)
				{
					b.Checked = true;
				}
				else 
				{
					b.Checked = false;
				}
			}
		}

        private void btnSetAnalyseType_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonX b = sender as DevComponents.DotNetBar.ButtonX;
            if (b != null && b.Tag is E_VIDEO_ANALYZE_TYPE)
            {
                E_VIDEO_ANALYZE_TYPE item = (E_VIDEO_ANALYZE_TYPE)b.Tag;
				SetSetAnalyseTypeBtnCheck(item);
                GetAnalyseSettingPanel(item);
            }
        }

        private void GetAnalyseSettingPanel(E_VIDEO_ANALYZE_TYPE item)
        {
            if (panelEx4.Controls.ContainsKey("ucAnalyseSetting_" + item.ToString()))
            {
                panelEx4.Controls["ucAnalyseSetting_" + item.ToString()].BringToFront();
            }
            else
            {
                Control uc;
                switch (item)
                {
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE_DYNAMIC:
                        uc = new ucFaceAnalyseSetting();
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD:
                        uc = new ucTrafficEventAnalyseSetting();
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD:
                        uc = new ucCrowdAnalyseSetting();
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ_PLATFORM:
                        uc = new ucMoveObjAnalyseSetting();
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_PERSON_COUNT:
                        uc = new ucPeopleCountAnalyseSetting();
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BEHAVIOR_ALARM:
                        uc = new ucBehaviourAnalyseSetting();
                        break;
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_ACCIDENT_ALARM:
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BRIEAF:
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE:
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ:
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_VEHICLE:
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_SPECIAL_EFFECT_WIPEOFF_FOG:
                    case E_VIDEO_ANALYZE_TYPE.E_ANALYZE_IMAGE_SEARCH:
                    default:
                        uc = null;
                        break;
                }
                if (uc != null)
                {
                    ((IAnalyseSetting)uc).DrawHandle = ucSingleDrawImageWnd1;
                    uc.Name = "ucAnalyseSetting_" + item.ToString();
                    uc.Dock = DockStyle.Fill;
                    panelEx4.Controls.Add(uc);
                    uc.BringToFront();
                }
            }

            m_viewModel.AnalyseType = item;
        }

        private void btnSearchHistoryVideoList_Click(object sender, EventArgs e)
        {
            List<object[]> list = m_viewModel.InitFileList(Channel, dateTimeStart.Value, dateTimeEnd.Value);
            foreach (var vals in list)
            {
                ucTaskAdd1.AddFile(vals[0].ToString(), vals[1].ToString(), Convert.ToUInt64(vals[2]), 3, DataModel.Common.ConvertLinuxTime(Convert.ToUInt32(vals[3])), DataModel.Common.ConvertLinuxTime(Convert.ToUInt32(vals[4])));
                
            }
        }

        private void ucTaskAdd1_OnOk(object sender, EventArgs e)
        {
            this.Close();

        }

        private void ucTaskAdd1_OnCancel(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FormAddRealTask_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucSinglePlayWnd1.StopPlayReal();
            ucSinglePlayWnd1.UnInit();
        }

        private void buttonGrab_Click(object sender, EventArgs e)
        {

            var image = ucSinglePlayWnd1.GrabPictureData(false);
            if (image != null)
            { ucSingleDrawImageWnd1.DrawImage = image; }
            else
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
                        ucSingleDrawImageWnd1.DrawImage = img;
                }
            }
            ucSingleDrawImageWnd1.BringToFront();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            ucSinglePlayWnd1.BringToFront();
        }

        private void superTabControl1_SelectedTabChanged(object sender, DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs e)
        {
            if (e.NewValue == superTabItem1)
            {
                ucSingleDrawImageWnd1.DrawImage = ucSinglePlayWnd1.GrabPictureData(false);
                ucSingleDrawImageWnd1.BringToFront();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonClearAllGraphs_Click(object sender, EventArgs e)
        {
            ucSingleDrawImageWnd1.ClearAllGraphs();
        }

        private void buttonOutput_Click(object sender, EventArgs e)
        {
            if (panelEx4.Controls.Count > 0)
            {
                IAnalyseSetting item = panelEx4.Controls[0] as IAnalyseSetting;
                if (ucSingleDrawImageWnd1.DrawImage != null)
                {
                    string xml = item.AnalyseParam;
                    string time = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    string type = "AnalyseParam";
                    string fileName = type + time + ".xml";
                    bool needSave = true;

                    System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
                    sfd.RestoreDirectory = true;
                    sfd.Filter = "配置文件|*.xml";
                    sfd.FileName = fileName;
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
                        System.IO.File.WriteAllText(fileName, xml);
                    }

                }
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new OpenFileDialog();
            ofd.RestoreDirectory = true;
            ofd.Filter = "配置文件|*.xml";
            string fileName = "";
            E_VIDEO_ANALYZE_TYPE type = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = ofd.FileName;
                try
                {
                    string xml = System.IO.File.ReadAllText(fileName);
                    System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                    xmldoc.LoadXml(xml);
                    System.Xml.XmlNode typenode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/AlgorithmType");


                    switch (typenode.InnerXml)
                    {
                        case "Behaviour":
                            type = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_BEHAVIOR_ALARM;
                            break;
                        case "CrowdAnalyse":
                            type = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROWD;
                            break;
                        case "Face":
                            type = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE_DYNAMIC;
                            break;
                        case "PeopleCount":
                            type = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_PERSON_COUNT;
                            break;
                        case "Crossroad":
                            type = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD;
                            break;
                        case "MoveObject":
                            type = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ_PLATFORM;
                            break;
                        default:
                            break;
                    }
                    if (type != E_VIDEO_ANALYZE_TYPE.E_ANALYZE_NOUSE)
                    {
                        GetAnalyseSettingPanel(type);
                        if (panelEx4.Controls.Count > 0)
                        {
                            IAnalyseSetting item = panelEx4.Controls[0] as IAnalyseSetting;
                            if (ucSingleDrawImageWnd1.DrawImage != null)
                            {
								SetSetAnalyseTypeBtnCheck(type);
                                item.AnalyseParam = xml;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("导入配置文件错误。" + ex.Message, Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK);
                }
            }



        }




    }
}
