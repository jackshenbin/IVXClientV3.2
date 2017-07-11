using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    public class DriveWayRegion
    {
        public uint ChannelID;
        public System.Drawing.Point DirectLineStart;
        public System.Drawing.Point DirectLineEnd;

        public List<System.Drawing.Point> RegionPointList;

        public System.Drawing.Point FluxLineStart;
        public System.Drawing.Point FluxLineEnd;

        public float Angle;

        public string ToXMLString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<ChannelInfo>");
            sb.AppendLine("<ChannelID>" + ChannelID + "</ChannelID>");
            sb.AppendLine("<DirectLine>");
            sb.AppendLine("<StartPoint>");
            sb.AppendLine("<X>" + DirectLineStart .X+ "</X>");
            sb.AppendLine("<Y>" + DirectLineStart.Y + "</Y>");
            sb.AppendLine("</StartPoint>");
            sb.AppendLine("<EndPoint>");
            sb.AppendLine("<X>" + DirectLineEnd.X + "</X>");
            sb.AppendLine("<Y>" + DirectLineEnd.Y + "</Y>");
            sb.AppendLine("</EndPoint>");
            sb.AppendLine("</DirectLine>");
            sb.AppendLine("<FluxLine>");
            sb.AppendLine("<StartPoint>");
            sb.AppendLine("<X>" + FluxLineStart.X + "</X>");
            sb.AppendLine("<Y>" + FluxLineStart.Y + "</Y>");
            sb.AppendLine("</StartPoint>");
            sb.AppendLine("<EndPoint>");
            sb.AppendLine("<X>" + FluxLineEnd.X + "</X>");
            sb.AppendLine("<Y>" + FluxLineEnd.Y + "</Y>");
            sb.AppendLine("</EndPoint>");
            sb.AppendLine("</FluxLine>");
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
            sb.AppendLine("</ChannelInfo>");

            return sb.ToString();
        }


        public static DriveWayRegion LoadFromXml(System.Xml.XmlNode node)
        {
            DriveWayRegion region = new DriveWayRegion();
            region.ChannelID = Convert.ToUInt32(node.SelectSingleNode("ChannelID").InnerText);
            region.DirectLineStart = new System.Drawing.Point(Convert.ToInt32(node.SelectSingleNode("DirectLine/StartPoint/X").InnerText), Convert.ToInt32(node.SelectSingleNode("DirectLine/StartPoint/Y").InnerText));
            region.DirectLineEnd = new System.Drawing.Point(Convert.ToInt32(node.SelectSingleNode("DirectLine/EndPoint/X").InnerText), Convert.ToInt32(node.SelectSingleNode("DirectLine/EndPoint/Y").InnerText));
            region.FluxLineStart = new System.Drawing.Point(Convert.ToInt32(node.SelectSingleNode("FluxLine/StartPoint/X").InnerText), Convert.ToInt32(node.SelectSingleNode("FluxLine/StartPoint/Y").InnerText));
            region.FluxLineEnd = new System.Drawing.Point(Convert.ToInt32(node.SelectSingleNode("FluxLine/EndPoint/X").InnerText), Convert.ToInt32(node.SelectSingleNode("FluxLine/EndPoint/Y").InnerText));
            region.RegionPointList = new List<System.Drawing.Point>();
            foreach (System.Xml.XmlNode item in node.SelectNodes("PointSet/Point"))
            {
                region.RegionPointList.Add(new System.Drawing.Point( Convert.ToInt32( item.SelectSingleNode("X").InnerText),Convert.ToInt32( item.SelectSingleNode("Y").InnerText)));
            }

            return region;
        }
    }
}
