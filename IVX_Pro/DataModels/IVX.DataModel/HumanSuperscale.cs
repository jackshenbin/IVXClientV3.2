using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    public class HumanSuperscale
    {
        public bool Enable;
        public uint UpperLimit;

        public uint UnitTime;

        public string ToXMLString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<Enable>" + Enable.ToString().ToUpper() + "</Enable>");
            sb.AppendLine("<UpperLimit>" + UpperLimit + "</UpperLimit>");
            sb.AppendLine("<UnitTime>" + UnitTime + "</UnitTime>");

            return sb.ToString();
        }


        public static HumanSuperscale LoadFromXml(System.Xml.XmlNode node)
        {
            HumanSuperscale h = new HumanSuperscale();
            h.Enable = Convert.ToBoolean(node.SelectSingleNode("Enable").InnerText);
            h.UpperLimit = Convert.ToUInt32(node.SelectSingleNode("UpperLimit").InnerText);
            h.UnitTime = Convert.ToUInt32(node.SelectSingleNode("UnitTime").InnerText);
            return h;
        }
    }
}
