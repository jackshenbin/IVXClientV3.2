using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
     class SceneMark
    {
        public List<System.Drawing.Point> ImageSC;
        public List<System.Drawing.Point> WorldSC;

        public string ToXMLString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<SceneMark>");
            sb.AppendLine("<ImageSC>");
            sb.AppendLine("<PointNum>" + ImageSC.Count + "</PointNum>");
            sb.AppendLine("<PointSet>");
            foreach (System.Drawing.Point item in ImageSC)
            {
                sb.AppendLine("<Point>");
                sb.AppendLine("<X>" + item.X + "</X>");
                sb.AppendLine("<Y>" + item.Y + "</Y>");
                sb.AppendLine("</Point>");
            }
            sb.AppendLine("</PointSet>");
            sb.AppendLine("</ImageSC>");
            sb.AppendLine("<WorldSC>");
            sb.AppendLine("<PointNum>" + WorldSC.Count + "</PointNum>");
            sb.AppendLine("<PointSet>");
            foreach (System.Drawing.Point item in WorldSC)
            {
                sb.AppendLine("<Point>");
                sb.AppendLine("<X>" + item.X + "</X>");
                sb.AppendLine("<Y>" + item.Y + "</Y>");
                sb.AppendLine("</Point>");
            }
            sb.AppendLine("</PointSet>");
            sb.AppendLine("</WorldSC>");
            sb.AppendLine("</SceneMark>");

            return sb.ToString();
        }


        public static SceneMark LoadFromXml(System.Xml.XmlNode node)
        {
            SceneMark region = new SceneMark();
            region.ImageSC = new List<System.Drawing.Point>();
            foreach (System.Xml.XmlNode item in node.SelectNodes("ImageSC/PointSet/Point"))
            {
                region.ImageSC.Add(new System.Drawing.Point(Convert.ToInt32(item.SelectSingleNode("X").InnerText), Convert.ToInt32(item.SelectSingleNode("Y").InnerText)));
            }
            region.WorldSC = new List<System.Drawing.Point>();
            foreach (System.Xml.XmlNode item in node.SelectNodes("WorldSC/PointSet/Point"))
            {
                region.ImageSC.Add(new System.Drawing.Point(Convert.ToInt32(item.SelectSingleNode("X").InnerText), Convert.ToInt32(item.SelectSingleNode("Y").InnerText)));
            }

            return region;
        }
    }
}
