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
    public partial class ucMoveObjAnalyseSetting : UserControl,IAnalyseSetting
    {
        public bool CheckJam { get { return btnCheckJam.Checked; } set { btnCheckJam.Checked = value; } }
        public int JamNum { get { return spinEditNumJam.Value; } set { spinEditNumJam.Value = value; } }
        public int JamTime { get { return spinEditTimeJam.Value; } set { spinEditTimeJam.Value = value; } }

        public bool NV_StructualFeature 
        { 
            get {return  checkBoxNV_StructualFeature.Checked; } 
            set { checkBoxNV_StructualFeature.Checked = value; } 
        }
        public bool NV_GlobalFeature
        { 
            get {return  checkBoxNV_GlobalFeature.Checked; }
            set { checkBoxNV_GlobalFeature.Checked = value; } 
        }
        public bool NV_PartFeature 
        { 
            get {return  checkBoxNV_PartFeature.Checked; } 
            set { checkBoxNV_PartFeature.Checked = value; } 
        }
        public bool NV_Track
        { 
            get {return  checkBoxNV_Track.Checked; }
            set { checkBoxNV_Track.Checked = value; } 
        }
        public bool NV_SnapImage 
        { 
            get {return  checkBoxNV_SnapImage.Checked; }
            set { checkBoxNV_SnapImage.Checked = value; } 
        }



        public bool V_StructualFeature 
        { 
            get {return  checkBoxV_StructualFeature.Checked; } 
            set { checkBoxV_StructualFeature.Checked = value; } 
        }
        public bool V_GlobalFeature
        { 
            get {return  checkBoxV_GlobalFeature.Checked; }
            set { checkBoxV_GlobalFeature.Checked = value; } 
        }
        public bool V_PartFeature 
        { 
            get {return  checkBoxV_PartFeature.Checked; } 
            set { checkBoxV_PartFeature.Checked = value; } 
        }
        public bool V_Track
        { 
            get {return  checkBoxV_Track.Checked; }
            set { checkBoxV_Track.Checked = value; } 
        }
        public bool V_SnapImage 
        { 
            get {return  checkBoxV_SnapImage.Checked; }
            set { checkBoxV_SnapImage.Checked = value; } 
        }
        public ucMoveObjAnalyseSetting()
        {
            InitializeComponent();
        }

        public string AnalyseParam
        {
            get
            {
                return BuildAnalyseParamByMoveObj();
            }
            set
            {
                ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;

                bool checkjam = false;
                int jamnum = 0;
                int jamtime = 0;
                GetAccidentFromXML(value, out checkjam, out jamnum, out jamtime);
                CheckJam = checkjam;
                JamNum = jamnum;
                JamTime = jamtime;


                bool nv_StructualFeature =false;
                bool nv_GlobalFeature=false;
                bool nv_PartFeature=false;
                bool nv_Track=false;
                bool nv_SnapImage=false;
                bool v_StructualFeature=false;
                bool v_GlobalFeature=false;
                bool v_PartFeature=false;
                bool v_Track=false;
                bool v_SnapImage = false;
                GetReportResultFromXML(value
                    , out nv_StructualFeature
                    , out  nv_GlobalFeature
                    , out  nv_PartFeature
                    , out  nv_Track
                    , out  nv_SnapImage
                    , out  v_StructualFeature
                    , out  v_GlobalFeature
                    , out  v_PartFeature
                    , out  v_Track
                    , out  v_SnapImage
                    );

                NV_StructualFeature = nv_StructualFeature;
                NV_GlobalFeature = nv_GlobalFeature;
                NV_PartFeature = nv_PartFeature;
                NV_Track = nv_Track;
                NV_SnapImage = nv_SnapImage;
                V_StructualFeature = v_StructualFeature;
                V_GlobalFeature = v_GlobalFeature;
                V_PartFeature = v_PartFeature;
                V_Track = v_Track;
                V_SnapImage = v_SnapImage;

                List<Point> region = GetAnalyseMoveObjectRegionFromXML(value);
                if (region.Count > 0)
                    c.AnalyseAreaExParam = region;

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

        private string BuildAnalyseParamByMoveObj()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<root>");
            sb.AppendLine("<AlgorithmInitParam>");
            sb.AppendLine("<AlgorithmType>MoveObject</AlgorithmType>");
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
                sb.AppendLine("</CheckRegion>");
            }
            sb.AppendLine(BuildAccident());
            sb.AppendLine(BuildReportResult());

            sb.AppendLine("</AlgorithmInitParam>");
            sb.AppendLine("</root>");

            return sb.ToString();
        }

        private string BuildAccident()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<Accident>");
            sb.AppendLine("<CheckJam>");
            sb.AppendLine("<Enable>"+CheckJam.ToString().ToUpper()+"</Enable>");
            sb.AppendLine("<NumJamThresh>" + JamNum + "</NumJamThresh>");
            sb.AppendLine("<TimeJamThresh>" + JamTime + "</TimeJamThresh>");
            sb.AppendLine("</CheckJam>");
            sb.AppendLine("</Accident>");

            return sb.ToString();
 
        }
        private string BuildReportResult()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<ReportResult>");

            sb.AppendLine("<NonVehicle>");
            sb.AppendLine("<StructualFeature>");
            sb.AppendLine("<Enable>"+NV_StructualFeature.ToString().ToUpper()+"</Enable>");
            sb.AppendLine("</StructualFeature>");
            sb.AppendLine("<NonStructualFeature>");
            sb.AppendLine("<GlobalFeature>" + NV_GlobalFeature.ToString().ToUpper() + "</GlobalFeature>");
            sb.AppendLine("<PartFeature>" + NV_PartFeature.ToString().ToUpper() + "</PartFeature>");
            sb.AppendLine("</NonStructualFeature>");
            sb.AppendLine("<Track>");
            sb.AppendLine("<Enable>"+NV_Track.ToString().ToUpper()+"</Enable>");
            sb.AppendLine("</Track>");
            sb.AppendLine("<SnapImage>");
            sb.AppendLine("<Enable>"+NV_SnapImage.ToString().ToUpper()+"</Enable>");
            sb.AppendLine("</SnapImage>");
            sb.AppendLine("</NonVehicle>");

            sb.AppendLine("<Vehicle>");
            sb.AppendLine("<StructualFeature>");
            sb.AppendLine("<Enable>" + V_StructualFeature.ToString().ToUpper() + "</Enable>");
            sb.AppendLine("</StructualFeature>");
            sb.AppendLine("<NonStructualFeature>");
            sb.AppendLine("<GlobalFeature>" + V_GlobalFeature.ToString().ToUpper() + "</GlobalFeature>");
            sb.AppendLine("<PartFeature>" + V_PartFeature.ToString().ToUpper() + "</PartFeature>");
            sb.AppendLine("</NonStructualFeature>");
            sb.AppendLine("<Track>");
            sb.AppendLine("<Enable>" + V_Track.ToString().ToUpper() + "</Enable>");
            sb.AppendLine("</Track>");
            sb.AppendLine("<SnapImage>");
            sb.AppendLine("<Enable>" + V_SnapImage.ToString().ToUpper() + "</Enable>");
            sb.AppendLine("</SnapImage>");
            sb.AppendLine("</Vehicle>");

            sb.AppendLine("</ReportResult>");

            return sb.ToString();
 
        }

        private List<Point> GetAnalyseMoveObjectRegionFromXML(string xml)
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
            if (RegionPointList.Count == 1 && RegionPointList[0].X == -1)
                return ret;

            ret = RegionPointList;

            return ret;

        }


        private void GetAccidentFromXML(string xml, out bool checkJam, out int jamNum, out int jamTime)
        {
            if (string.IsNullOrEmpty(xml))
            {
                checkJam = false;
                jamNum = 10;
                jamTime = 20;
                return;
            }

            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);
            System.Xml.XmlNode checkJamNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/Accident/CheckJam/Enable");
            checkJam = Convert.ToBoolean(checkJamNode.InnerText);

            System.Xml.XmlNode jamNumNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/Accident/CheckJam/NumJamThresh");
            jamNum = Convert.ToInt32(jamNumNode.InnerText);

            System.Xml.XmlNode jamTimeNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/Accident/CheckJam/TimeJamThresh");
            jamTime = Convert.ToInt32(jamTimeNode.InnerText);


        }

        private void GetReportResultFromXML(string xml
            , out bool nv_StructualFeature
            , out bool nv_GlobalFeature
            , out bool nv_PartFeature
            , out bool nv_Track
            , out bool nv_SnapImage
            , out bool v_StructualFeature
            , out bool v_GlobalFeature
            , out bool v_PartFeature
            , out bool v_Track
            , out bool v_SnapImage )
        {
            if (string.IsNullOrEmpty(xml))
            {
                nv_StructualFeature=true;
                nv_GlobalFeature=true;
                nv_PartFeature=true;
                nv_Track=true;
                nv_SnapImage=true;
                v_StructualFeature=true;
                v_GlobalFeature=true;
                v_PartFeature=true;
                v_Track=true;
                v_SnapImage = true;
                return;
            }

            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);
            System.Xml.XmlNode nv_StructualFeatureNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ReportResult/NonVehicle/StructualFeature/Enable");
            nv_StructualFeature = Convert.ToBoolean(nv_StructualFeatureNode.InnerText);

            System.Xml.XmlNode nv_GlobalFeatureNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ReportResult/NonVehicle/NonStructualFeature/GlobalFeature");
            nv_GlobalFeature = Convert.ToBoolean(nv_GlobalFeatureNode.InnerText);

            System.Xml.XmlNode nv_PartFeatureNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ReportResult/NonVehicle/NonStructualFeature/PartFeature");
            nv_PartFeature = Convert.ToBoolean(nv_PartFeatureNode.InnerText);

            System.Xml.XmlNode nv_TrackNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ReportResult/NonVehicle/Track/Enable");
            nv_Track = Convert.ToBoolean(nv_TrackNode.InnerText);

            System.Xml.XmlNode nv_SnapImageNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ReportResult/NonVehicle/SnapImage/Enable");
            nv_SnapImage = Convert.ToBoolean(nv_SnapImageNode.InnerText);



            System.Xml.XmlNode v_StructualFeatureNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ReportResult/Vehicle/StructualFeature/Enable");
            v_StructualFeature = Convert.ToBoolean(v_StructualFeatureNode.InnerText);

            System.Xml.XmlNode v_GlobalFeatureNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ReportResult/Vehicle/NonStructualFeature/GlobalFeature");
            v_GlobalFeature = Convert.ToBoolean(v_GlobalFeatureNode.InnerText);

            System.Xml.XmlNode v_PartFeatureNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ReportResult/Vehicle/NonStructualFeature/PartFeature");
            v_PartFeature = Convert.ToBoolean(v_PartFeatureNode.InnerText);

            System.Xml.XmlNode v_TrackNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ReportResult/Vehicle/Track/Enable");
            v_Track = Convert.ToBoolean(v_TrackNode.InnerText);

            System.Xml.XmlNode v_SnapImageNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ReportResult/Vehicle/SnapImage/Enable");
            v_SnapImage = Convert.ToBoolean(v_SnapImageNode.InnerText);


        }

    }
}
