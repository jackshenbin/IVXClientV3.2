using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;

namespace IVX.Live.MainForm
{
    public partial class FormBriefTest : DevComponents.DotNetBar.Metro.MetroForm
    {
        private uint m_playHandle = 0;

        public FormBriefTest()
        {
            InitializeComponent();
            ocx_BriefSdk_Init();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            IVX.Live.MainForm.View.ucPlayBrief brief = Controls[0] as View.ucPlayBrief;
            brief.Clear();
            ocx_BriefSdk_UnInit();
        }

        private void FormBriefTest_Load(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ToastNotification.Show(this, "sdfadsfasdfsssss");
        }

        bool ocx_BriefSdk_Init()
        {
            string initparam = "<root><PlayBufPoolSizeK>204800</PlayBufPoolSizeK></root>";
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefSdk_Init initparam:" + initparam);
            uint retVal = axbriefocx1.ocx_BriefVoddcInit(initparam);
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefSdk_Init retVal:" + retVal);
            return retVal == 0;
        }
        int ocx_BriefSdk_UnInit()
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefSdk_UnInit ");
            axbriefocx1.ocx_BriefVoddcUnInit();
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefSdk_UnInit retVal:" + 0);
            return 0;
        }

        private void FormBriefTest_Shown(object sender, EventArgs e)
        {


        }
        private bool ocx_BriefVoddcAddDispatch(string ip, uint port, string datafile, string brieffile)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcAddDispatch ip:{0},port:{1},datafile:{2},brieffile:{3}", ip, port, datafile, brieffile);
            string tParam = string.Format("<root> " +
                                        "<Hwnd>{0}</Hwnd> " +
                                        "<NetIp>{1}</NetIp>" +
                                        "<MsgDispatchPort>{2}</MsgDispatchPort> " +
                                        "<TimeOutMs>120</TimeOutMs> " +
                                        "<BriefDataPath>{3}</BriefDataPath> " +
                                        "<BriefIndexPath>{4}</BriefIndexPath>" +
                                        "<AdjustTime>1463650345</AdjustTime> " +
                                        "</root>"
                                        , axVdaPlayer1.Handle.ToInt32()
                                        , ip
                                        , port
                                        , datafile
                                        , brieffile);
            string xml = axbriefocx1.ocx_BriefVoddcAddDispatch(tParam);
            /*<result> 
            <InstKey>1</InstKey> 
            <Ret>0</Ret> 
            </result>*/

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(xml);
            uint ret = Convert.ToUInt32(doc.SelectSingleNode("//result/Ret").InnerText);
            if (ret != 0)
                GetError(ret);

            uint playHandle = Convert.ToUInt32(doc.SelectSingleNode("//result/InstKey").InnerText);
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcAddDispatch retVal:" + ret + ",m_playHandle:" + playHandle);
            m_playHandle = playHandle;

            return ret == 0;

        }
        private void GetError(uint errorCode)
        {
            string error = Framework.Environment.BriefPlayControler.ocx_GetErrorDiscription(errorCode);
            if (errorCode > 0 && errorCode != 12)
            {
                MyLog4Net.Container.Instance.Log.Error(string.Format("SDKCallException errorCode:{0},errorString:{1}", errorCode, error));
                if (string.IsNullOrEmpty(error))
                {
                    Debug.Assert(false, "Failed but cannot get error message!");
                }
                throw new SDKCallException(errorCode, error);
            }
            else
            {
                Debug.Assert(false, "No valid error code!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ocx_BriefVoddcAddDispatch(textBoxIP.Text,Convert.ToUInt32( textBoxPort.Text), textBoxData.Text, textBoxIndex.Text);
        }

        private bool ocx_BriefVoddcStart()
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcStart m_playHandle:" + m_playHandle);

            uint retVal = axbriefocx1.ocx_BriefVoddcStart(m_playHandle);
            if (retVal != 0)
                GetError(retVal);
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcStart retVal:" + retVal);
            return retVal == 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ocx_BriefVoddcStart();
        }


        private uint ocx_BriefVoddcSetCommonFilter(E_VDA_BRIEF_DENSITY density, E_VDA_MOVEOBJ_TYPE objtype, E_MOVEOBJ_COLOR color)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcSetCommonFilter density:{0},objtype:{1},color:{2}", density, objtype, color);

            StringBuilder strParam = new StringBuilder();
            /*<root> 
            <Density></Density> <!--密度--> 
            <ObjType></ObjType> <!--目标类型--> 
            <ObjColorArray> <!--目标颜色--> 
            <ObjColor>0</ObjColor> 
            </ObjColorArray> 
            </root>*/
            int obj = 0;
            switch (objtype)
            {
                case E_VDA_MOVEOBJ_TYPE.E_VDA_MOVEOBJ_TYPE_ALL:
                    obj = 3;
                    break;
                case E_VDA_MOVEOBJ_TYPE.E_VDA_MOVEOBJ_TYPE_PEOPLE:
                    obj = 1;
                    break;
                case E_VDA_MOVEOBJ_TYPE.E_VDA_MOVEOBJ_TYPE_CAR:
                    obj = 2;
                    break;
                case E_VDA_MOVEOBJ_TYPE.E_VDA_MOVEOBJ_TYPE_UNKNOWN:
                    obj = 0;
                    break;
                default:
                    break;
            }
            strParam.AppendFormat("<root>");
            strParam.AppendFormat("<handle>{0}</handle>", m_playHandle);
            strParam.AppendFormat("<Density>{0}</Density>", ((int)density / 10f).ToString("0.0"));// <!--密度--> 
            strParam.AppendFormat("<ObjType>{0}</ObjType>", obj); //<!--目标类型--> 
            strParam.AppendFormat("<ObjColorArray>");// <!--目标颜色--> 
            strParam.AppendFormat("<ObjColor>{0}</ObjColor>", (int)color);
            strParam.AppendFormat("</ObjColorArray>");
            strParam.AppendFormat("<ValidTimeSectionArray/>");
            strParam.AppendFormat("<InvalidTimeSectionArray/>");
            strParam.AppendFormat("</root>");
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcSetCommonFilter strParam:{0}", strParam);


            uint ret = axbriefocx1.ocx_BriefVoddcSetCommonFilter(strParam.ToString());
            if (ret != 0)
                GetError(ret);
            MyLog4Net.Container.Instance.Log.DebugFormat("ocx_BriefVoddcSetCommonFilter ret:" + ret);
            return ret;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ocx_BriefVoddcSetCommonFilter(E_VDA_BRIEF_DENSITY.E_BRIEF_DENSITY_04, E_VDA_MOVEOBJ_TYPE.E_VDA_MOVEOBJ_TYPE_ALL, E_MOVEOBJ_COLOR.E_MOVEOBJ_COLOR_NOUSE);
        }

    }
}
