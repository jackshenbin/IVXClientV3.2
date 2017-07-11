using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    public class BreakRegion
    {
        public uint ID;
        public uint TimelyReportTimeInterval;

        public uint RegionType;
        public bool RegionTypeIn;
        public bool RegionTypeOut;

        public bool OutputResult;
        public List<System.Drawing.Point> RegionPointList;
        public HumanSuperscale BreakIn;
        public HumanSuperscale BreakOut;

        public string ToXMLString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<Region>");
            sb.AppendLine("<ID>" + ID + "</ID>");
            sb.AppendLine("<OutputResult>" + OutputResult.ToString().ToUpper() + "</OutputResult>");
            sb.AppendLine("<TimelyReportTimeInterval>" + TimelyReportTimeInterval + "</TimelyReportTimeInterval>");
            sb.AppendLine("<HumanSuperscale>");
            sb.AppendLine("<InSide>");
            sb.AppendLine(BreakIn.ToXMLString());
			sb.AppendLine("</InSide>");
			sb.AppendLine("<OutSide>");
            sb.AppendLine(BreakOut.ToXMLString());
            sb.AppendLine("</OutSide>");
            sb.AppendLine("</HumanSuperscale>");

            sb.AppendLine("<InSide>" + RegionTypeIn.ToString().ToUpper() + "</InSide>");
            sb.AppendLine("<OutSide>" + RegionTypeOut.ToString().ToUpper() + "</OutSide>");
            sb.AppendLine("<PointNum>" + RegionPointList.Count + "</PointNum>");
            sb.AppendLine("<PointSet>");
            foreach (System.Drawing.Point item in RegionPointList)
            {
                sb.AppendLine("<Point>");
                sb.AppendLine("<X>" + item.X + "</X>");
                sb.AppendLine("<Y>" + item.Y + "</Y>");
                sb.AppendLine("</Point>");
            }
            sb.AppendLine("</PointSet>");
            sb.AppendLine("</Region>");

            return sb.ToString();
        }


        public static BreakRegion LoadFromXml(System.Xml.XmlNode node)
        {
            BreakRegion region = new BreakRegion();
            region.ID = Convert.ToUInt32(node.SelectSingleNode("ID").InnerText);
            region.TimelyReportTimeInterval = Convert.ToUInt32(node.SelectSingleNode("TimelyReportTimeInterval").InnerText);
            region.OutputResult = Convert.ToBoolean(node.SelectSingleNode("OutputResult").InnerText);
            region.BreakIn = HumanSuperscale.LoadFromXml(node.SelectSingleNode("HumanSuperscale/InSide"));
            region.BreakOut = HumanSuperscale.LoadFromXml(node.SelectSingleNode("HumanSuperscale/OutSide"));

            region.RegionPointList = new List<System.Drawing.Point>();
            foreach (System.Xml.XmlNode item in node.SelectNodes("PointSet/Point"))
            {
                region.RegionPointList.Add(new System.Drawing.Point( Convert.ToInt32( item.SelectSingleNode("X").InnerText),Convert.ToInt32( item.SelectSingleNode("Y").InnerText)));
            }

            region.RegionTypeIn = Convert.ToBoolean(node.SelectSingleNode("InSide").InnerText);
            region.RegionTypeOut = Convert.ToBoolean(node.SelectSingleNode("OutSide").InnerText);
            region.RegionType = 0;
            return region;
        }
    }
}
