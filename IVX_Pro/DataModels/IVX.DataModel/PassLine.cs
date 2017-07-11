using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    public  class PassLine
    {
        public uint ID;
        public uint TimelyReportTimeInterval;
        public bool OutputResult;
        public uint PassLineType;
        public bool PassLinePos;
        public bool PassLineNeg;
        public System.Drawing.Point PassLineStart;
        public System.Drawing.Point PassLineEnd;
        public System.Drawing.Point DirectLineStart;
        public System.Drawing.Point DirectLineEnd;
        public HumanSuperscale PosBeyond;
        public HumanSuperscale NegBeyond;

        public string ToXMLString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<Line>");
            sb.AppendLine("<ID>"+ID+"</ID>");
            sb.AppendLine("<OutputResult>" + OutputResult.ToString().ToUpper() + "</OutputResult>");
            sb.AppendLine("<TimelyReportTimeInterval>" + TimelyReportTimeInterval + "</TimelyReportTimeInterval>");
            sb.AppendLine("<HumanSuperscale>");
            sb.AppendLine("<PosBeyond>");
            sb.AppendLine(PosBeyond.ToXMLString());
            sb.AppendLine("</PosBeyond>");
            sb.AppendLine("<NegBeyond>");
            sb.AppendLine(NegBeyond.ToXMLString());
            sb.AppendLine("</NegBeyond>");
            sb.AppendLine("</HumanSuperscale>");


            sb.AppendLine("<PosBeyond>" + PassLinePos.ToString().ToUpper() + "</PosBeyond>");
            sb.AppendLine("<NegBeyond>" + PassLineNeg.ToString().ToUpper() + "</NegBeyond>");
            sb.AppendLine("<BeyondLinePointSet>");
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + PassLineStart.X + "</X>");
            sb.AppendLine("<Y>" + PassLineStart.Y + "</Y>");
            sb.AppendLine("</Point>");
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + PassLineEnd.X + "</X>");
            sb.AppendLine("<Y>" + PassLineEnd.Y + "</Y>");
            sb.AppendLine("</Point>");
            sb.AppendLine("</BeyondLinePointSet>");
            sb.AppendLine("<DirectLinePointSet>");
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + DirectLineStart.X + "</X>");
            sb.AppendLine("<Y>" + DirectLineStart.Y + "</Y>");
            sb.AppendLine("</Point>");
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + DirectLineEnd.X + "</X>");
            sb.AppendLine("<Y>" + DirectLineEnd.Y + "</Y>");
            sb.AppendLine("</Point>");
            sb.AppendLine("</DirectLinePointSet>");
            sb.AppendLine("</Line>");

            return sb.ToString();
        }

        public static PassLine LoadFromXml(System.Xml.XmlNode node)
        {
            PassLine line = new PassLine();
            line.ID = Convert.ToUInt32(node.SelectSingleNode("ID").InnerText);
            line.TimelyReportTimeInterval = Convert.ToUInt32(node.SelectSingleNode("TimelyReportTimeInterval").InnerText);
            line.OutputResult = Convert.ToBoolean(node.SelectSingleNode("OutputResult").InnerText);
            line.PosBeyond = HumanSuperscale.LoadFromXml(node.SelectSingleNode("HumanSuperscale/PosBeyond"));
            line.NegBeyond = HumanSuperscale.LoadFromXml(node.SelectSingleNode("HumanSuperscale/NegBeyond"));

            line.DirectLineStart = new System.Drawing.Point(Convert.ToInt32(node.SelectNodes("DirectLinePointSet/Point/X")[0].InnerText), Convert.ToInt32(node.SelectNodes("DirectLinePointSet/Point/Y")[0].InnerText));
            line.DirectLineEnd = new System.Drawing.Point(Convert.ToInt32(node.SelectNodes("DirectLinePointSet/Point/X")[1].InnerText), Convert.ToInt32(node.SelectNodes("DirectLinePointSet/Point/Y")[1].InnerText));
            line.PassLineStart = new System.Drawing.Point(Convert.ToInt32(node.SelectNodes("BeyondLinePointSet/Point/X")[0].InnerText), Convert.ToInt32(node.SelectNodes("BeyondLinePointSet/Point/Y")[0].InnerText));
            line.PassLineEnd = new System.Drawing.Point(Convert.ToInt32(node.SelectNodes("BeyondLinePointSet/Point/X")[1].InnerText), Convert.ToInt32(node.SelectNodes("BeyondLinePointSet/Point/Y")[1].InnerText));
            line.PassLinePos = Convert.ToBoolean(node.SelectSingleNode("PosBeyond").InnerText);
            line.PassLineNeg = Convert.ToBoolean(node.SelectSingleNode("NegBeyond").InnerText);
            line.PassLineType = 0;
            return line;
        }
    }
}
