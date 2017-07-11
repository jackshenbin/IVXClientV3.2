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
    public partial class ucCrowdAnalyseSetting : UserControl,IAnalyseSetting
    {
        public double CollectArea { get {return  doubleInput2.Value; } set { doubleInput2.Value = value; } }
        public uint CollectTimeInterval { get { return (uint)integerInput1.Value; } set { integerInput1.Value = (int)value; } }

        public ucCrowdAnalyseSetting()
        {
            InitializeComponent();
        }

        public string AnalyseParam
        {
            get
            {
                return BuildAnalyseParamByCollect();
            }
            set
            {
                ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;

                double area = 0;
                uint time = 0;
                GetAnalyseCollectParamFromXML(value, out area, out time);
                CollectArea = area;
                CollectTimeInterval = time;
                List<Point> collectregion = GetAnalyseCollectRegionFromXML(value);
                if (collectregion.Count > 0)
                    c.AnalyseAreaExParam = collectregion;

            }
        }

        public Control DrawHandle
        {
            get;
            set;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            c.SetDrawType(DataModel.DrawGraphType.AnalyseAreaEx);
        }

        private string BuildAnalyseParamByCollect()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<root>");
            sb.AppendLine("<AlgorithmInitParam>");
            sb.AppendLine("<AlgorithmType>CrowdAnalyse</AlgorithmType>");
            if (c.AnalyseAreaExParam.Count > 0)
            {
                sb.AppendLine("<CheckRegion>");
                sb.AppendLine("<PointNum>" + c.AnalyseAreaExParam.Count + "</PointNum>");
                sb.AppendLine("<PointSet>");
                foreach (var item in c.AnalyseAreaExParam)
                {
                    sb.AppendLine("<Point>");
                    sb.AppendLine("<X>" + item.X + "</X>");
                    sb.AppendLine("<Y>" + item.Y + "</Y>");
                    sb.AppendLine("</Point>");

                }
                sb.AppendLine("</PointSet>");
                sb.AppendLine("<Area>" + CollectArea.ToString("0.##") + "</Area>");
                sb.AppendLine("</CheckRegion>");
            }

            sb.AppendLine("<TimelyReportTimeInterval>" + CollectTimeInterval + "</TimelyReportTimeInterval>");
            sb.AppendLine("</AlgorithmInitParam>");
            sb.AppendLine("</root>");

            return sb.ToString();
        }
        private void GetAnalyseCollectParamFromXML(string xml, out double collectArea, out uint collectTime)
        {
            if (string.IsNullOrEmpty(xml))
            {
                collectArea = 20;
                collectTime = 5;
                return;
            }
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);
            collectArea = Convert.ToDouble(xmldoc.SelectSingleNode("root/AlgorithmInitParam/CheckRegion/Area").InnerText);
            collectTime = Convert.ToUInt32(xmldoc.SelectSingleNode("root/AlgorithmInitParam/TimelyReportTimeInterval").InnerText);

        }
        private List<Point> GetAnalyseCollectRegionFromXML(string xml)
        {
            List<Point> ret = new List<Point>();
            if (string.IsNullOrEmpty(xml))
                return ret;
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);

            System.Xml.XmlNode item = xmldoc.SelectSingleNode("root/AlgorithmInitParam/CheckRegion");
            List<System.Drawing.Point> RegionPointList = new List<System.Drawing.Point>();
            foreach (System.Xml.XmlNode it in item.SelectNodes("PointSet/Point"))
            {
                RegionPointList.Add(new System.Drawing.Point(Convert.ToInt32(it.SelectSingleNode("X").InnerText), Convert.ToInt32(it.SelectSingleNode("Y").InnerText)));
            }
            ret = RegionPointList;

            return ret;

        }

    }
}
