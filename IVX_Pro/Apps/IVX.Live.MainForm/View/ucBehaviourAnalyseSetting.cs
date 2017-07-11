using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;
using DevComponents.Editors;

namespace IVX.Live.MainForm.View
{
    public partial class ucBehaviourAnalyseSetting : UserControl, IAnalyseSetting
    {
        #region AccidentAlarm
        private Point[] m_worldSC = null;

        public Point[] WorldSC
        {
            get
            {
                if (m_worldSC == null)
                {
                    ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
                    if (c==null || c.DrawImage == null)
                        return null;
                    if (c.ImageSC.Count != 6)
                        return null;
                    m_worldSC = new Point[6];

                    for (int i = 0; i < 6; i++)
                    {
                        m_worldSC[i] = new Point(c.ImageSC[i].X - c.ImageSC[0].X, c.ImageSC[i].Y - c.ImageSC[0].Y);
                    }
                }
				doubleInputX1.Value = m_worldSC[0].X;
				doubleInputX2.Value = m_worldSC[1].X;
				doubleInputX3.Value = m_worldSC[2].X;
				doubleInputX4.Value = m_worldSC[3].X;
				doubleInputX5.Value = m_worldSC[4].X;
				doubleInputX6.Value = m_worldSC[5].X;
				doubleInputY1.Value = m_worldSC[0].Y;
				doubleInputY2.Value = m_worldSC[1].Y;
				doubleInputY3.Value = m_worldSC[2].Y;
				doubleInputY4.Value = m_worldSC[3].Y;
				doubleInputY5.Value = m_worldSC[4].Y;
				doubleInputY6.Value = m_worldSC[5].Y;
                return m_worldSC;
            }
            set
            {
                m_worldSC = value;
				doubleInputX1.Value = m_worldSC[0].X;
				doubleInputX2.Value = m_worldSC[1].X;
				doubleInputX3.Value = m_worldSC[2].X;
				doubleInputX4.Value = m_worldSC[3].X;
				doubleInputX5.Value = m_worldSC[4].X;
				doubleInputX6.Value = m_worldSC[5].X;
				doubleInputY1.Value = m_worldSC[0].Y;
				doubleInputY2.Value = m_worldSC[1].Y;
				doubleInputY3.Value = m_worldSC[2].Y;
				doubleInputY4.Value = m_worldSC[3].Y;
				doubleInputY5.Value = m_worldSC[4].Y;
				doubleInputY6.Value = m_worldSC[5].Y;
            }
        }




        #endregion

        public ucBehaviourAnalyseSetting()
        {
            InitializeComponent();


            doubleInputX1.Tag = "1X";
            doubleInputX2.Tag = "2X";
            doubleInputX3.Tag = "3X";
            doubleInputX4.Tag = "4X";
            doubleInputX5.Tag = "5X";
            doubleInputX6.Tag = "6X";
            doubleInputY1.Tag = "1Y";
            doubleInputY2.Tag = "2Y";
            doubleInputY3.Tag = "3Y";
            doubleInputY4.Tag = "4Y";
            doubleInputY5.Tag = "5Y";
            doubleInputY6.Tag = "6Y";
        }

        public string AnalyseParam
        {
            set
            {
				ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
				//绘制检测区域
				List<Point> region = GetAnalyseCheckRegionFromXML(value);
				if (region.Count > 0)
					c.AnalyseAreaExParam = region;

				// 远处行人框
				List<Rectangle> FarRect = GetAnalyseFarRectFormXML(value);
				if (FarRect.Count > 0)
					c.FarAreaParam = FarRect;

				// 近处行人框
				List<Rectangle> NearRect = GetAnalyseNearRectFormXML(value);
				if (NearRect.Count > 0)
					c.NearAreaParam = NearRect;

				// 标定
				List<Point> vehiclemark = GetSceneMarkFromXML("ImageSC", value);
				c.ImageSC = vehiclemark;
				WorldSC = GetSceneMarkFromXML("WorldSC", value).ToArray();

				// 奔跑 拉横幅 撒传单 聚集
				GetAnalyseOther(value);

				// 越界线
				List<PassLine> pslineList = GetAnalysePassLine(value);
				if (pslineList.Count > 0)
					c.PassLineParam = pslineList;
				// 闯入闯出
				List<BreakRegion> ioRegion = GetAnalysePassRegion(value);
				if (ioRegion.Count > 0)
					c.BreakAreaParam = ioRegion;

            }
            get
            {
				return BuildAnalyseParamByBehaviour();
            }
        }

        public Control DrawHandle
        {
            get;
            set;
        }

		private string BuildAnalyseParamByBehaviour()
        {
			ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("<root>");
			sb.AppendLine("<AlgorithmInitParam>");
			sb.AppendLine("<AlgorithmType>Behaviour</AlgorithmType>");
			// 绘制检测区域
			if (c.AnalyseAreaExParam.Count > 0) {
				sb.AppendLine("<CheckRegion>");
				sb.AppendLine("<PointNum>" + c.AnalyseAreaExParam.Count + "</PointNum>");
				sb.AppendLine("<PointSet>");
				foreach (var item in c.AnalyseAreaExParam) {
					sb.AppendLine("<Point>");
					sb.AppendLine("<X>" + item.X + "</X>");
					sb.AppendLine("<Y>" + item.Y + "</Y>");
					sb.AppendLine("</Point>");
				}
				sb.AppendLine("</PointSet>");
				sb.AppendLine("</CheckRegion>");
			}
			sb.AppendLine("<CheckTimeInterval>3</CheckTimeInterval>");
			sb.AppendLine("<PasserbyRim>");
			//远处行人框
			sb.AppendLine(BuildAnalyseParamByFarRect());
			// 近处行人框
			sb.AppendLine(BuildAnalyseParamByNearRect());
			sb.AppendLine("</PasserbyRim>");
			// 标定
			sb.AppendLine(BuildAnalyseParamBySceneMark());

			//奔跑
			sb.AppendLine("<Run>");
			sb.AppendLine("<OutputResult>" + checkEditCheckRun.Checked.ToString().ToUpper() + "</OutputResult>");
			sb.AppendLine("<SpeedLowerLimit>" + RunInput.Text + "</SpeedLowerLimit>");
			sb.AppendLine("</Run>");
			// 拉横幅
			sb.AppendLine("<CarryBanner>");
			sb.AppendLine("<OutputResult>" + checkEditCheckCarryBanner.Checked.ToString().ToUpper() + "</OutputResult>");
			sb.AppendLine("</CarryBanner>");
			// 撒传单 
			sb.AppendLine("<FlyLeaflet>");
			sb.AppendLine("<OutputResult>" + checkEditCheckFlyLeaflet.Checked.ToString().ToUpper() + "</OutputResult>");
			sb.AppendLine("</FlyLeaflet>");
			// 聚集
			sb.AppendLine("<Mass>");
			sb.AppendLine("<OutputResult>" + checkEditCheckMass.Checked.ToString().ToUpper() + "</OutputResult>");
			sb.AppendLine("<HumanLowerLimit>" + MassInput.Text + "</HumanLowerLimit>");
			sb.AppendLine("</Mass>");

			//闯入闯出
			sb.AppendLine(BuildAnalyseParamByInOutSideRegion());
			// 越界线
			sb.AppendLine(BuildAnalyseParamByPassLine());
			sb.AppendLine("</AlgorithmInitParam>");
			sb.AppendLine("</root>");

			return sb.ToString();
        }

		private string BuildAnalyseParamByFarRect() {
			ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("<FarRect>");
			foreach (var item in c.FarAreaParam) {
				sb.AppendLine("<LTPoint>");
				sb.AppendLine("<X>" + item.X + "</X>");
				sb.AppendLine("<Y>" + item.Y + "</Y>");
				sb.AppendLine("</LTPoint>");
				sb.AppendLine("<Width>" + item.Width + "</Width>");
				sb.AppendLine("<Height>" + item.Height + "</Height>");
			}
			sb.AppendLine("</FarRect>");
			return sb.ToString();
		}

		private string BuildAnalyseParamByNearRect() {
			ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("<NearRect>");
			foreach (var item in c.NearAreaParam) {
				sb.AppendLine("<LTPoint>");
				sb.AppendLine("<X>" + item.X + "</X>");
				sb.AppendLine("<Y>" + item.Y + "</Y>");
				sb.AppendLine("</LTPoint>");
				sb.AppendLine("<Width>" + item.Width + "</Width>");
				sb.AppendLine("<Height>" + item.Height + "</Height>");
			}
			sb.AppendLine("</NearRect>");
			return sb.ToString();
		}

		private string BuildAnalyseParamByInOutSideRegion() {
			//报警和定时上报  是 不相干
			ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
			if(!CheckInOutSide.Checked) return "";
			StringBuilder sb = new StringBuilder();
			// 闯入闯出
			sb.AppendLine("<InOutSideRegion>");
			foreach (var item in c.BreakAreaParam) {
				sb.AppendLine("<Region>");
				sb.AppendLine("<ID>" + "0" + "</ID>");
				sb.AppendLine("<OutputResult>" +TimeInOutSide.Checked.ToString().ToUpper() + "</OutputResult>");
				sb.AppendLine("<TimelyReportTimeInterval>" + InOutSideInput.Text + "</TimelyReportTimeInterval>");
				// 正向报警 和 反向报警 上限
				sb.AppendLine("<HumanSuperscale>");
				sb.AppendLine("<InSide>");
				sb.AppendLine("<Enable>" +InSideCheck.Checked.ToString().ToUpper() + "</Enable>");
				sb.AppendLine("<UpperLimit>" + InSideUpperLimit.Text + "</UpperLimit>");
				sb.AppendLine("<UnitTime>" + InSideUnitTime.Text + "</UnitTime>");
				sb.AppendLine("</InSide>");
				sb.AppendLine("<OutSide>");
				sb.AppendLine("<Enable>" + OutSideCheck.Checked.ToString().ToUpper() + "</Enable>");
				sb.AppendLine("<UpperLimit>" + OutSideUpperLimit.Text + "</UpperLimit>");
				sb.AppendLine("<UnitTime>" + OutSideUnitTime.Text + "</UnitTime>");
				sb.AppendLine("</OutSide>");
				sb.AppendLine("</HumanSuperscale>");
				//是否判断正向
				sb.AppendLine("<InSide>" + AllowInSide.Checked.ToString().ToUpper()+ "</InSide>");
				//是否判断反向
				sb.AppendLine("<OutSide>" + AllowOutSide.Checked.ToString().ToUpper()+ "</OutSide>");
				sb.AppendLine("<PointNum>" + item.RegionPointList.Count + "</PointNum>");

				sb.AppendLine("<PointSet>");
				foreach (var pointItem in item.RegionPointList) {
					sb.AppendLine("<Point>");
					sb.AppendLine("<X>" + pointItem.X + "</X>");
					sb.AppendLine("<Y>" + pointItem.Y + "</Y>");
					sb.AppendLine("</Point>");
				}
				sb.AppendLine("</PointSet>");
				sb.AppendLine("</Region>");
				break;
			}
			sb.AppendLine("</InOutSideRegion>");
			return sb.ToString();
		}

		private string BuildAnalyseParamByPassLine() {
			ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
			if (!checkEditPassLine.Checked) return "";
			StringBuilder sb = new StringBuilder();
			//越界
			sb.AppendLine("<BeyondLine>");
			foreach (var item in c.PassLineParam) {
				sb.AppendLine("<Line>");
				sb.AppendLine("<ID>" + "0" + "</ID>");
				sb.AppendLine("<OutputResult>" +  TimePassline.Checked.ToString().ToUpper()+ "</OutputResult>");
				sb.AppendLine("<TimelyReportTimeInterval>" + InputPassLine.Text + "</TimelyReportTimeInterval>");
				// 正向报警 和 反向报警 上限
				sb.AppendLine("<HumanSuperscale>");
				sb.AppendLine("<PosBeyond>");
				sb.AppendLine("<Enable>" + btnCheckPosBeyond.Checked.ToString().ToUpper() + "</Enable>");
				sb.AppendLine("<UpperLimit>" + PosBeyondUpperLimit.Text + "</UpperLimit>");
				sb.AppendLine("<UnitTime>" + PosBeyondUnitTime.Text + "</UnitTime>");
				sb.AppendLine("</PosBeyond>");
				sb.AppendLine("<NegBeyond>");
				sb.AppendLine("<Enable>" + btnCheckNegBeyond.Checked.ToString().ToUpper() + "</Enable>");
				sb.AppendLine("<UpperLimit>" + NegBeyondUpperLimit.Text + "</UpperLimit>");
				sb.AppendLine("<UnitTime>" + NegBeyondUnitTime.Text + "</UnitTime>");
				sb.AppendLine("</NegBeyond>");
				sb.AppendLine("</HumanSuperscale>");
				//是否判断正向
				sb.AppendLine("<PosBeyond>" + AllowPosBeyond.Checked.ToString().ToUpper() + "</PosBeyond>");
				//是否判断反向
				sb.AppendLine("<NegBeyond>" + AllowNegBeyond.Checked.ToString().ToUpper() + "</NegBeyond>");
				// 越界线 集合
				sb.AppendLine("<BeyondLinePointSet>");
				sb.AppendLine("<Point>");
				sb.AppendLine("<X>" + item.PassLineStart.X + "</X>");
				sb.AppendLine("<Y>" + item.PassLineStart.Y + "</Y>");
				sb.AppendLine("</Point>");
				sb.AppendLine("<Point>");
				sb.AppendLine("<X>" + item.PassLineEnd.X + "</X>");
				sb.AppendLine("<Y>" + item.PassLineEnd.Y + "</Y>");
				sb.AppendLine("</Point>");
				sb.AppendLine("</BeyondLinePointSet>");
				sb.AppendLine("<DirectLinePointSet>");
				if (item.PassLineType == 0) 
				{
					sb.AppendLine("<Point>");
					sb.AppendLine("<X>" + item.DirectLineEnd.X + "</X>");
					sb.AppendLine("<Y>" + item.DirectLineEnd.Y + "</Y>");
					sb.AppendLine("</Point>");
					sb.AppendLine("<Point>");
					sb.AppendLine("<X>" + item.DirectLineStart.X + "</X>");
					sb.AppendLine("<Y>" + item.DirectLineStart.Y + "</Y>");
					sb.AppendLine("</Point>");
				}
				else 
				{
					sb.AppendLine("<Point>");
					sb.AppendLine("<X>" + item.DirectLineStart.X + "</X>");
					sb.AppendLine("<Y>" + item.DirectLineStart.Y + "</Y>");
					sb.AppendLine("</Point>");
					sb.AppendLine("<Point>");
					sb.AppendLine("<X>" + item.DirectLineEnd.X + "</X>");
					sb.AppendLine("<Y>" + item.DirectLineEnd.Y + "</Y>");
					sb.AppendLine("</Point>");
				}
				sb.AppendLine("</DirectLinePointSet>");
				sb.AppendLine("</Line>");
				break;
			}
			sb.AppendLine("</BeyondLine>");
			return sb.ToString();
		}


        private string BuildAnalyseParamBySceneMark()
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<SceneMark>");
            sb.AppendLine("<ImageSC>");
            sb.AppendLine("<PointNum>" + c.ImageSC.Count + "</PointNum>");
            sb.AppendLine("<PointSet>");
            System.Drawing.Point item = c.ImageSC[0];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");
            item = c.ImageSC[2];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");
            item = c.ImageSC[3];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");
            item = c.ImageSC[5];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");
            item = c.ImageSC[1];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");
            item = c.ImageSC[4];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");


            sb.AppendLine("</PointSet>");
            sb.AppendLine("</ImageSC>");


            sb.AppendLine("<WorldSC>");
            sb.AppendLine("<PointNum>" + WorldSC.Length + "</PointNum>");
            sb.AppendLine("<PointSet>");
            item = WorldSC[0];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");
            item = WorldSC[2];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");
            item = WorldSC[3];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");
            item = WorldSC[5];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");
            item = WorldSC[1];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");
            item = WorldSC[4];
            sb.AppendLine("<Point>");
            sb.AppendLine("<X>" + item.X + "</X>");
            sb.AppendLine("<Y>" + item.Y + "</Y>");
            sb.AppendLine("</Point>");

            sb.AppendLine("</PointSet>");
            sb.AppendLine("</WorldSC>");
            sb.AppendLine("</SceneMark>");
            return sb.ToString();

        }

        private void GetCarFastFromXML(string xml, out uint CarFast, out uint CarLow, out uint CarStop, out uint Flux, out uint Jam)
        {
            if (string.IsNullOrEmpty(xml))
            {
                CarFast = 100;
                CarLow = 20;
                CarStop = 120;
                Flux = 120;
                Jam = 120;
                return;
            }
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);
            System.Xml.XmlNode CheckCarFast = xmldoc.SelectSingleNode("root/AlgorithmInitParam/Accident/CheckCarFast/Limen");
            CarFast = Convert.ToUInt32(CheckCarFast.InnerText);

            System.Xml.XmlNode CheckCarLow = xmldoc.SelectSingleNode("root/AlgorithmInitParam/Accident/CheckCarLow/Limen");
            CarLow = Convert.ToUInt32(CheckCarLow.InnerText);

            System.Xml.XmlNode CheckCarStop = xmldoc.SelectSingleNode("root/AlgorithmInitParam/Accident/CheckCarStop/Limen");
            CarStop = Convert.ToUInt32(CheckCarStop.InnerText);

            System.Xml.XmlNode CheckCarFlux = xmldoc.SelectSingleNode("root/AlgorithmInitParam/Flux/TimelyReportTimeInterval");
            Flux = Convert.ToUInt32(CheckCarFlux.InnerText);

            System.Xml.XmlNode CheckCarJam = xmldoc.SelectSingleNode("root/AlgorithmInitParam/Accident/CheckJam/TimelyReportTimeInterval");
            Jam = Convert.ToUInt32(CheckCarJam.InnerText);

        }
        private void GetGetCarPlateFromXML(string xml, out bool CheckNoReversePlate, out bool CheckCarCrossPlate, out bool CheckCarFastPlate, out bool CheckCarLowPlate, out bool CheckCarStopPlate)
        {
            if (string.IsNullOrEmpty(xml))
            {
                CheckNoReversePlate = true;
                CheckCarCrossPlate = true;
                CheckCarFastPlate = true;
                CheckCarLowPlate = true;
                CheckCarStopPlate = true;
                return;
            }

            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);
            System.Xml.XmlNode CheckNoReverse = xmldoc.SelectSingleNode("root/AlgorithmInitParam/Accident/CheckNoReverse/GetCarPlate");
            CheckNoReversePlate = Convert.ToBoolean(CheckNoReverse.InnerText);

            System.Xml.XmlNode CheckCarCross = xmldoc.SelectSingleNode("root/AlgorithmInitParam/Accident/CheckCarCross/GetCarPlate");
            CheckCarCrossPlate = Convert.ToBoolean(CheckCarCross.InnerText);

            System.Xml.XmlNode CheckCarFast = xmldoc.SelectSingleNode("root/AlgorithmInitParam/Accident/CheckCarFast/GetCarPlate");
            CheckCarFastPlate = Convert.ToBoolean(CheckCarFast.InnerText);

            System.Xml.XmlNode CheckCarLow = xmldoc.SelectSingleNode("root/AlgorithmInitParam/Accident/CheckCarLow/GetCarPlate");
            CheckCarLowPlate = Convert.ToBoolean(CheckCarLow.InnerText);

            System.Xml.XmlNode CheckCarStop = xmldoc.SelectSingleNode("root/AlgorithmInitParam/Accident/CheckCarStop/GetCarPlate");
            CheckCarStopPlate = Convert.ToBoolean(CheckCarStop.InnerText);
        }

        private void GetCheckObjectFromXML(string xml, out bool checkPeopleFeature, out bool checkPeople, out bool checkTwoWheelFeature, out bool checkTwoWheel, out bool checkVehicleFeature, out bool checkVehicle)
        {
            if (string.IsNullOrEmpty(xml))
            {
                checkPeopleFeature = false;
                checkPeople = true;
                checkTwoWheelFeature = false;
                checkTwoWheel = true;
                checkVehicleFeature = true;
                checkVehicle = true;
                return;
            }

            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);
            System.Xml.XmlNode checkPeopleNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ObjectCheck/CheckPeople/Enable");
            checkPeople = Convert.ToBoolean(checkPeopleNode.InnerText);
            System.Xml.XmlNode checkPeopleFeatureNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ObjectCheck/CheckPeople/FeatureGet");
            checkPeopleFeature = Convert.ToBoolean(checkPeopleFeatureNode.InnerText);

            System.Xml.XmlNode checkTwoWheelNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ObjectCheck/CheckTwoWheel/Enable");
            checkTwoWheel = Convert.ToBoolean(checkTwoWheelNode.InnerText);
            System.Xml.XmlNode checkTwoWheelFeatureNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ObjectCheck/CheckTwoWheel/FeatureGet");
            checkTwoWheelFeature = Convert.ToBoolean(checkTwoWheelFeatureNode.InnerText);

            System.Xml.XmlNode checkVehicleNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ObjectCheck/CheckVehicle/Enable");
            checkVehicle = Convert.ToBoolean(checkVehicleNode.InnerText);
            System.Xml.XmlNode checkVehicleFeatureNode = xmldoc.SelectSingleNode("root/AlgorithmInitParam/ObjectCheck/CheckVehicle/FeatureGet");
            checkVehicleFeature = Convert.ToBoolean(checkVehicleFeatureNode.InnerText);


        }

        private List<Point> GetSceneMarkFromXML(string type, string xml)
        {
            List<Point> ret = new List<Point>();
            if (string.IsNullOrEmpty(xml))
            {
                ret.Add(new Point());
                ret.Add(new Point());
                ret.Add(new Point());
                ret.Add(new Point());
                ret.Add(new Point());
                ret.Add(new Point());
                return ret;
            }
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);

            System.Xml.XmlNode item = xmldoc.SelectSingleNode("root/AlgorithmInitParam/SceneMark/" + type);
            List<System.Drawing.Point> RegionPointList = new List<System.Drawing.Point>();
            foreach (System.Xml.XmlNode it in item.SelectNodes("PointSet/Point"))
            {
                RegionPointList.Add(new System.Drawing.Point(Convert.ToInt32(it.SelectSingleNode("X").InnerText), Convert.ToInt32(it.SelectSingleNode("Y").InnerText)));
            }
            RegionPointList.Insert(1, RegionPointList[4]);
            RegionPointList.Insert(4, RegionPointList[6]);

            ret = RegionPointList.Take(6).ToList();

            return ret;
        }

        private List<Point> GetRoadRegionFromXML(string xml)
        {
            List<Point> ret = new List<Point>();
            if (string.IsNullOrEmpty(xml))
                return ret;
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);

            System.Xml.XmlNode item = xmldoc.SelectSingleNode("root/AlgorithmInitParam/RoadRegion/RoadInfo");
            List<System.Drawing.Point> RegionPointList = new List<System.Drawing.Point>();
            foreach (System.Xml.XmlNode it in item.SelectNodes("PointSet/Point"))
            {
                RegionPointList.Add(new System.Drawing.Point(Convert.ToInt32(it.SelectSingleNode("X").InnerText), Convert.ToInt32(it.SelectSingleNode("Y").InnerText)));
            }
            ret = RegionPointList;
            return ret;
        }

        private bool GetAnalyseVehicleNoplatIncludeFromXML(string xml)
        {
            if (string.IsNullOrEmpty(xml))
                return true;

            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);
            bool area = Convert.ToBoolean(xmldoc.SelectSingleNode("root/AlgorithmInitParam/CarPlate/CheckNoCarPlate").InnerText);

            return area;
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            if (c == null)
                return;

            CheckBoxX barCheckItem = sender as CheckBoxX;
            if (!barCheckItem.Checked)
            {
                c.DriveWays[Convert.ToInt32(barCheckItem.Tag) - 11] = false;
            }
            else
            {
                c.SetDrawType((DrawGraphType)barCheckItem.Tag);
                c.DriveWays[Convert.ToInt32(barCheckItem.Tag) - 11] = true;
            }
        }
        private void checkButton2_Click(object sender, EventArgs e)
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            if (c == null)
                return;
            ButtonX barCheckItem = sender as ButtonX;
            c.SetDrawType((DrawGraphType)barCheckItem.Tag);

        }

        private void spinEdit_WorldSC_EditValueChanged(object sender, EventArgs e)
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            if (c == null || m_worldSC==null)
                return;

            DoubleInput edit = sender as DoubleInput;
            switch (edit.Tag.ToString())
            {
                case "1X": m_worldSC[0].X = Convert.ToInt32(edit.Value); break;
                case "1Y": m_worldSC[0].Y = Convert.ToInt32(edit.Value); break;
                case "2X": m_worldSC[1].X = Convert.ToInt32(edit.Value); break;
                case "2Y": m_worldSC[1].Y = Convert.ToInt32(edit.Value); break;
                case "3X": m_worldSC[2].X = Convert.ToInt32(edit.Value); break;
                case "3Y": m_worldSC[2].Y = Convert.ToInt32(edit.Value); break;
                case "4X": m_worldSC[3].X = Convert.ToInt32(edit.Value); break;
                case "4Y": m_worldSC[3].Y = Convert.ToInt32(edit.Value); break;
                case "5X": m_worldSC[4].X = Convert.ToInt32(edit.Value); break;
                case "5Y": m_worldSC[4].Y = Convert.ToInt32(edit.Value); break;
                case "6X": m_worldSC[5].X = Convert.ToInt32(edit.Value); break;
                case "6Y": m_worldSC[5].Y = Convert.ToInt32(edit.Value); break;
                default:
                    break;
            }
        }

        private void btnAnalyseRegion_Click(object sender, EventArgs e)
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            if (c == null || WorldSC == null)
                return;

            c.SetDrawType(DrawGraphType.AnalyseAreaEx);

        }

        private void btnMark_Click(object sender, EventArgs e)
        {
            ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
            if (c == null || WorldSC == null)
                return;
            c.SetDrawType(DrawGraphType.ImageSC);
        }

		private void passLineBtn_Click(object sender, EventArgs e) {
			ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
			if (c == null || WorldSC == null)
				return;
			c.SetDrawType(DrawGraphType.PassLine);
		}

		private void btnFar_Click(object sender, EventArgs e) {
			ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
			if (c == null || WorldSC == null)
				return;
			c.SetDrawType(DrawGraphType.FarArea);
		}

		private void btnNear_Click(object sender, EventArgs e) {
			ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
			if (c == null || WorldSC == null)
				return;
			c.SetDrawType(DrawGraphType.NearArea);
		}

		private void InOutSideBtn_Click(object sender, EventArgs e) {
			ucSingleDrawImageWnd c = DrawHandle as ucSingleDrawImageWnd;
			if (c == null || WorldSC == null)
				return;
			c.SetDrawType(DrawGraphType.PassRegion);
		}

		private List<Point> GetAnalyseCheckRegionFromXML(string xml) {
			List<Point> ret = new List<Point>();
			if (string.IsNullOrEmpty(xml))
				return ret;
			System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
			xmldoc.LoadXml(xml);

			System.Xml.XmlNode item = xmldoc.SelectSingleNode("root/AlgorithmInitParam/CheckRegion");
			List<System.Drawing.Point> RegionPointList = new List<System.Drawing.Point>();
			foreach (System.Xml.XmlNode it in item.SelectNodes("PointSet/Point")) {
				RegionPointList.Add(new System.Drawing.Point(Convert.ToInt32(it.SelectSingleNode("X").InnerText), Convert.ToInt32(it.SelectSingleNode("Y").InnerText)));
			}
			if (RegionPointList.Count == 1 && RegionPointList[0].X == -1)
				return ret;
			ret = RegionPointList;
			return ret;
		}

		private List<Rectangle> GetAnalyseFarRectFormXML(string xml) {
			List<Rectangle> ret = new List<Rectangle>();
			if (string.IsNullOrEmpty(xml))
				return ret;
			System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
			xmldoc.LoadXml(xml);
			System.Xml.XmlNode item = xmldoc.SelectSingleNode("root/AlgorithmInitParam/PasserbyRim");
			System.Xml.XmlNodeList nodelist = item.SelectNodes("FarRect");
			foreach (System.Xml.XmlNode it in nodelist) {
				Rectangle rect = new Rectangle();
				rect.X = Convert.ToInt32(it.SelectSingleNode("LTPoint/X").InnerText);
				rect.Y = Convert.ToInt32(it.SelectSingleNode("LTPoint/Y").InnerText);
				rect.Width = Convert.ToInt32(it.SelectSingleNode("Width").InnerText);
				rect.Height = Convert.ToInt32(it.SelectSingleNode("Height").InnerText);
				ret.Add(rect);
			}
			return ret;
		}

		private List<Rectangle> GetAnalyseNearRectFormXML(string xml) {
			List<Rectangle> ret = new List<Rectangle>();
			if (string.IsNullOrEmpty(xml))
				return ret;
			System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
			xmldoc.LoadXml(xml);
			System.Xml.XmlNode item = xmldoc.SelectSingleNode("root/AlgorithmInitParam/PasserbyRim");
			System.Xml.XmlNodeList nodelist = item.SelectNodes("NearRect");
			foreach (System.Xml.XmlNode it in nodelist) {
				Rectangle rect = new Rectangle();
				rect.X = Convert.ToInt32(it.SelectSingleNode("LTPoint/X").InnerText);
				rect.Y = Convert.ToInt32(it.SelectSingleNode("LTPoint/Y").InnerText);
				rect.Width = Convert.ToInt32(it.SelectSingleNode("Width").InnerText);
				rect.Height = Convert.ToInt32(it.SelectSingleNode("Height").InnerText);
				ret.Add(rect);
			}
			return ret;
		}

		private void GetAnalyseOther(string xml) {
			if (string.IsNullOrEmpty(xml))
				return;
			System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
			xmldoc.LoadXml(xml);
			// 奔跑 
			checkEditCheckRun.Checked = xmldoc.SelectSingleNode("root/AlgorithmInitParam/Run/OutputResult").InnerText == "TRUE";
			if (checkEditCheckRun.Checked) {
				RunInput.Text = xmldoc.SelectSingleNode("root/AlgorithmInitParam/Run/SpeedLowerLimit").InnerText;
			}
			// 拉横幅
			checkEditCheckCarryBanner.Checked = xmldoc.SelectSingleNode("root/AlgorithmInitParam/CarryBanner/OutputResult").InnerText == "TRUE";

			// 撒传单
			checkEditCheckFlyLeaflet.Checked = xmldoc.SelectSingleNode("root/AlgorithmInitParam/FlyLeaflet/OutputResult").InnerText == "TRUE";

			// 聚集
			checkEditCheckMass.Checked = xmldoc.SelectSingleNode("root/AlgorithmInitParam/Mass/OutputResult").InnerText == "TRUE";
			if (checkEditCheckRun.Checked) {
				MassInput.Text = xmldoc.SelectSingleNode("root/AlgorithmInitParam/Mass/HumanLowerLimit").InnerText;
			}
		}

		private List<PassLine> GetAnalysePassLine(string xml) {
			List<PassLine> pslineList = new List<PassLine> { };
			if (string.IsNullOrEmpty(xml))
				return pslineList;
			System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
			xmldoc.LoadXml(xml);
			System.Xml.XmlNode item = xmldoc.SelectSingleNode("root/AlgorithmInitParam/BeyondLine/Line");
			checkEditPassLine.Checked = item.SelectSingleNode("OutputResult").InnerText == "TRUE";
			TimePassline.Checked      = item.SelectSingleNode("OutputResult").InnerText == "TRUE";
			InputPassLine.Text = item.SelectSingleNode("TimelyReportTimeInterval").InnerText;
			// 是否正向 
			AllowPosBeyond.Checked = item.SelectSingleNode("PosBeyond").InnerText == "TRUE";
			// 是否反向
			AllowNegBeyond.Checked = item.SelectSingleNode("NegBeyond").InnerText == "TRUE";
			btnCheckPosBeyond.Checked = item.SelectSingleNode("HumanSuperscale/PosBeyond/Enable").InnerText == "TRUE";
			if (btnCheckPosBeyond.Checked) {
				PosBeyondUnitTime.Text = item.SelectSingleNode("HumanSuperscale/PosBeyond/UnitTime").InnerText;
				PosBeyondUpperLimit.Text = item.SelectSingleNode("HumanSuperscale/PosBeyond/UpperLimit").InnerText;
			}
			btnCheckNegBeyond.Checked = item.SelectSingleNode("HumanSuperscale/NegBeyond/Enable").InnerText == "TRUE";
			if (btnCheckNegBeyond.Checked) {
				NegBeyondUnitTime.Text = item.SelectSingleNode("HumanSuperscale/NegBeyond/UnitTime").InnerText;
				NegBeyondUpperLimit.Text = item.SelectSingleNode("HumanSuperscale/NegBeyond/UpperLimit").InnerText;
			}
			PassLine pslint = PassLine.LoadFromXml(item);
			Point temp = pslint.DirectLineStart;
			pslint.DirectLineStart = pslint.DirectLineEnd;
			pslint.DirectLineEnd =  temp;
			pslint.PassLineType = 0;
			pslineList.Add(pslint);
			return pslineList;
		}

		private List<BreakRegion> GetAnalysePassRegion(string xml) {
			List<BreakRegion> brList = new List<BreakRegion> { };
			if (string.IsNullOrEmpty(xml))
				return brList;
			System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
			xmldoc.LoadXml(xml);
			System.Xml.XmlNode item = xmldoc.SelectSingleNode("root/AlgorithmInitParam/InOutSideRegion/Region");
			CheckInOutSide.Checked = item.SelectSingleNode("OutputResult").InnerText == "TRUE";
			TimeInOutSide.Checked  = item.SelectSingleNode("OutputResult").InnerText == "TRUE";
			InOutSideInput.Text = item.SelectSingleNode("TimelyReportTimeInterval").InnerText;
			AllowInSide.Checked = item.SelectSingleNode("InSide").InnerText == "TRUE";
			AllowOutSide.Checked = item.SelectSingleNode("OutSide").InnerText == "TRUE";
			InSideCheck.Checked = item.SelectSingleNode("HumanSuperscale/InSide/Enable").InnerText == "TRUE";
			if (btnCheckPosBeyond.Checked) {
				InSideUnitTime.Text = item.SelectSingleNode("HumanSuperscale/InSide/UnitTime").InnerText;
				InSideUpperLimit.Text = item.SelectSingleNode("HumanSuperscale/InSide/UpperLimit").InnerText;
			}
			OutSideCheck.Checked = item.SelectSingleNode("HumanSuperscale/OutSide/Enable").InnerText == "TRUE";
			if (OutSideCheck.Checked) {
				OutSideUnitTime.Text = item.SelectSingleNode("HumanSuperscale/OutSide/UnitTime").InnerText;
				OutSideUpperLimit.Text = item.SelectSingleNode("HumanSuperscale/OutSide/UpperLimit").InnerText;
			}
			BreakRegion bRegion = BreakRegion.LoadFromXml(item);
			brList.Add(bRegion);
			return brList;
		}

		private void SetPassLineEnable(bool enable) 
		{
			InputPassLine.Enabled = enable;
			passLineBtn.Enabled = enable;
			TimePassline.Enabled = enable;
			AllowPosBeyond.Enabled = enable;
			AllowNegBeyond.Enabled = enable;
			btnCheckPosBeyond.Enabled = enable;
			btnCheckNegBeyond.Enabled = enable;
			PosBeyondUnitTime.Enabled = enable;
			PosBeyondUpperLimit.Enabled = enable;
			NegBeyondUnitTime.Enabled = enable;
			NegBeyondUpperLimit.Enabled = enable;
		}

		private void SetInOutSideEnable(bool enable) 
		{
			TimeInOutSide.Enabled = enable;
			InOutSideBtn.Enabled = enable;
			InOutSideInput.Enabled = enable;
			AllowInSide.Enabled = enable;
			AllowOutSide.Enabled = enable;
			InSideCheck.Enabled = enable;
			OutSideCheck.Enabled = enable;
			InSideUnitTime.Enabled = enable;
			InSideUpperLimit.Enabled = enable;
			OutSideUnitTime.Enabled = enable;
			OutSideUpperLimit.Enabled = enable;
		}

		private void checkEditPassLine_CheckedChanged(object sender, EventArgs e) 
		{
			SetPassLineEnable(checkEditPassLine.Checked);
		}

		private void CheckInOutSide_CheckedChanged(object sender, EventArgs e)
		{
			SetInOutSideEnable(CheckInOutSide.Checked);
		}

    }
}
