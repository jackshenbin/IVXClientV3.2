using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IVX.Live.MainForm.View
{
    public partial class ucFaceAnalyseSetting : UserControl,IAnalyseSetting
    {
        public bool GetFeature { get { return checkBoxX1.Checked; } set { checkBoxX1.Checked = value; } }
        public bool GetRace { get { return checkBoxX2.Checked; } set { checkBoxX2.Checked = value; } }

        public ucFaceAnalyseSetting()
        {
            InitializeComponent();
        }

        public string AnalyseParam
        {
            get
            {
                return BuildAnalyseParamByFace();
            }
            set
            {
                ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;

                bool feature = false;
                bool race = true;
                GetAnalyseFaceParamFromXML(value, out feature, out race);
                GetFeature = feature;
                GetRace = race;

            }
        }

        public Control DrawHandle
        {
            get;
            set;
        }


        private string BuildAnalyseParamByFace()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<root>");
            sb.AppendLine("<AlgorithmInitParam>");
            sb.AppendLine("<AlgorithmType>Face</AlgorithmType>");
            sb.AppendLine("<bGetFeature>" + (GetFeature?1:0) + "</bGetFeature>");
            sb.AppendLine("<bGetRace>" + (GetRace ? 1 : 0) + "</bGetRace>");
            sb.AppendLine("</AlgorithmInitParam>");
            sb.AppendLine("</root>");

            return sb.ToString();
        }
        private void GetAnalyseFaceParamFromXML(string xml, out bool frature, out bool race)
        {
            if (string.IsNullOrEmpty(xml))
            {
                frature = false;
                race = true;
                return;
            }
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);
            frature = Convert.ToInt32(xmldoc.SelectSingleNode("root/AlgorithmInitParam/bGetFeature").InnerText)==1;
            race = Convert.ToInt32(xmldoc.SelectSingleNode("root/AlgorithmInitParam/bGetRace").InnerText)==1;

        }
    }
}
