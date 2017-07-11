using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;

namespace IVX.Live.MainForm.View
{
    public partial class ucEditTaskAnalyseParam : UserControl
    {

        public event EventHandler OnOk;
        public event EventHandler OnCancel;
        public Image DrawImage 
        {
            get { return ucSingleDrawImageWnd1.DrawImage; } 
            set { ucSingleDrawImageWnd1.DrawImage = value; } 
        }

        private E_VIDEO_ANALYZE_TYPE AnalyseType { get; set; }
        public string AnalyseParam 
        {
            get
            {
                if (panelEx4.Controls.Count > 0)
                {
                    IAnalyseSetting item = panelEx4.Controls[0] as IAnalyseSetting;
                    return item.AnalyseParam;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (panelEx4.Controls.Count > 0)
                {
                    IAnalyseSetting item = panelEx4.Controls[0] as IAnalyseSetting;
                    item.AnalyseParam = value; 
                }
            }
        }


        public ucEditTaskAnalyseParam()
        {
            InitializeComponent();
        }

        public void SetAnalyseType(E_VIDEO_ANALYZE_TYPE item)
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
            AnalyseType = item;
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            if (panelEx4.Controls.Count > 0)
            {
                //IAnalyseSetting item = panelEx4.Controls[0] as IAnalyseSetting;
                //AnalyseParam = item.AnalyseParam;
                if (OnOk != null)
                    OnOk(this, e);
            }
        }

        private void ucEditTaskAnalyseParam_Load(object sender, EventArgs e)
        {

        }




        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (OnCancel != null)
                OnCancel(this, e);
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
                    if (type == AnalyseType)
                    {
                        if (panelEx4.Controls.Count > 0)
                        {
                            IAnalyseSetting item = panelEx4.Controls[0] as IAnalyseSetting;
                            if (ucSingleDrawImageWnd1.DrawImage != null)
                            {
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
