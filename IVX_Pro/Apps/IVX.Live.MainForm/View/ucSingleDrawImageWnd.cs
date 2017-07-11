using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;
using IVX.Live.ViewModel;

namespace IVX.Live.MainForm.View
{
    public partial class ucSingleDrawImageWnd : UserControl,INotifyPropertyChanged
    {
        #region 事件
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region 私有变量
        private Image m_drawImage;

        #endregion

        #region 属性

        public Image DrawImage
        {
            get { return m_drawImage; }
            set
            { 
                if (value == null)
                    return;

                m_drawImage = value; 
                SetPicData(value);

            }
        }

        public bool[] DriveWays = new bool[6];
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<PassLine> PassLineParam
        {
            get
            {
                string strregion = GetGraphData(DrawGraphType.PassLine);
                List<PassLine> ret = new List<PassLine>();
                if (strregion == "")
                {
                    ret.Add(new PassLine()
                    {
                        PassLineStart = new Point(30, Convert.ToInt32(DrawImage.Height / 2f)),
                        PassLineEnd = new Point(DrawImage.Width - 30, Convert.ToInt32(DrawImage.Height / 2f)),
                        DirectLineStart = new Point(Convert.ToInt32(DrawImage.Width / 2f), Convert.ToInt32(DrawImage.Height / 2f) - 20),
                        DirectLineEnd = new Point(Convert.ToInt32(DrawImage.Width / 2f), Convert.ToInt32(DrawImage.Height / 2f) + 20),
                        ID = 0,
                        PassLineType = 0,

                    });
                    return ret;
                }
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(strregion);
                int index = 0;
                foreach (System.Xml.XmlNode item in xmldoc.SelectNodes("GraphData/GraphTypeInfo/GraphTypeItem"))
                {
                    List<Point> ps = new List<Point>();
                    foreach (System.Xml.XmlNode n in item.SelectNodes("PointList/Point"))
                    {
                        string[] xy = n.InnerText.Split(',');
                        ps.Add(new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1])));
                    };
                    int direct = Convert.ToInt32(item.SelectSingleNode("LineDirection").InnerText);
                    string[] StartPoint = item.SelectSingleNode("StartPoint").InnerText.Split(',');
                    string[] EndPoint = item.SelectSingleNode("EndPoint").InnerText.Split(',');
                    PassLine pl = new PassLine()
                    {
                        PassLineStart = ps[0],
                        PassLineEnd = ps[1],
                        DirectLineStart = new Point(Convert.ToInt32(StartPoint[0]), Convert.ToInt32(StartPoint[1])),
                        DirectLineEnd = new Point(Convert.ToInt32(EndPoint[0]), Convert.ToInt32(EndPoint[1])),
                        ID = (uint)index,
                        PassLineType = (uint)direct,
                        TimelyReportTimeInterval = 0,
                    };
                    index++;
                    ret.Add(pl);
                }

                return ret;
            }
            set
            {
                value.ForEach(line => SetGraphData(DrawGraphType.PassLine, line));
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PassLine PeopleCountLineParam
        {
            get
            {
                string strregion = GetGraphData(DrawGraphType.PeopleCountLine);
                PassLine ret = new PassLine();
                if (strregion == "")
                {
                    ret = new PassLine()
                    {
                        PassLineStart = new Point(30, Convert.ToInt32(DrawImage.Height / 2f)),
                        PassLineEnd = new Point(DrawImage.Width - 30, Convert.ToInt32(DrawImage.Height / 2f)),
                        DirectLineStart = new Point(),
                        DirectLineEnd = new Point(),
                        ID = 0,
                        PassLineType = 0,

                    };
                    return ret;
                }
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(strregion);

                System.Xml.XmlNode item = xmldoc.SelectSingleNode("GraphData/GraphTypeInfo/GraphTypeItem");
                List<Point> ps = new List<Point>();
                foreach (System.Xml.XmlNode n in item.SelectNodes("PointList/Point"))
                {
                    string[] xy = n.InnerText.Split(',');
                    ps.Add(new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1])));
                };
                ret = new PassLine()
                {
                    PassLineStart = ps[0],
                    PassLineEnd = ps[1],
                    DirectLineStart = new Point(),
                    DirectLineEnd = new Point(),
                    ID = 0,
                    PassLineType = 0,
                    TimelyReportTimeInterval = 0,
                };


                return ret;
            }
            set
            {
                SetGraphData(DrawGraphType.PeopleCountLine, value);
            }

        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Tuple<Point,Point>> ChangeChannelLineParam
        {
            get
            {
                string strregion = GetGraphData(DrawGraphType.ChangeChannelLine);
                List<Tuple<Point, Point>> ret = new List<Tuple<Point, Point>>();
                if (strregion == "")
                {
                    ret.Add(new Tuple<Point, Point>(new Point(30, 30), new Point(DrawImage.Width - 30, 30)));
                    return ret;
                }
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(strregion);

                foreach (System.Xml.XmlNode item in xmldoc.SelectNodes("GraphData/GraphTypeInfo/GraphTypeItem"))
                {
                    List<Point> ps = new List<Point>();
                    foreach (System.Xml.XmlNode n in item.SelectNodes("PointList/Point"))
                    {
                        string[] xy = n.InnerText.Split(',');
                        ps.Add(new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1])));
                    };
                    ret.Add(new Tuple<Point, Point>(ps[0], ps[1]));

                }
                return ret;
            }
            set
            {
                SetGraphData(DrawGraphType.ChangeChannelLine, value);
            }

        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Tuple<Point, Point>> PressChannelLineParam
        {
            get
            {
                string strregion = GetGraphData(DrawGraphType.PressChannelLine);
                List<Tuple<Point, Point>> ret = new List<Tuple<Point, Point>>();
                if (strregion == "")
                {
                    ret.Add(new Tuple<Point, Point>(new Point(30, 40), new Point(DrawImage.Width - 30, 40)));
                    return ret;
                }
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(strregion);

                foreach (System.Xml.XmlNode item in xmldoc.SelectNodes("GraphData/GraphTypeInfo/GraphTypeItem"))
                {
                    List<Point> ps = new List<Point>();
                    foreach (System.Xml.XmlNode n in item.SelectNodes("PointList/Point"))
                    {
                        string[] xy = n.InnerText.Split(',');
                        ps.Add(new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1])));
                    };
                    ret.Add(new Tuple<Point, Point>(ps[0], ps[1]));

                }
                return ret;
            }
            set
            {
                SetGraphData(DrawGraphType.PressChannelLine, value);
            }

        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Tuple<Point, Point> StopLineParam
        {
            get
            {
                string strregion = GetGraphData(DrawGraphType.StopLine);
                Tuple<Point, Point> ret = new Tuple<Point, Point>(new Point(),new Point());
                if (strregion == "")
                {
                    ret = new Tuple<Point, Point>(new Point(30, 50), new Point(DrawImage.Width - 30, 50));

                    return ret;
                }
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(strregion);

                System.Xml.XmlNode item = xmldoc.SelectSingleNode("GraphData/GraphTypeInfo/GraphTypeItem");
                
                List<Point> ps = new List<Point>();
                foreach (System.Xml.XmlNode n in item.SelectNodes("PointList/Point"))
                {
                    string[] xy = n.InnerText.Split(',');
                    ps.Add(new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1])));
                };
                ret = new Tuple<Point, Point>(ps[0], ps[1]);

                
                return ret;
            }
            set
            {
                SetGraphData(DrawGraphType.StopLine, value);
            }

        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Tuple<Point, Point> SecondLineParam
        {
            get
            {
                string strregion = GetGraphData(DrawGraphType.SecondLine);
                Tuple<Point, Point> ret = new Tuple<Point, Point>(new Point(), new Point());
                if (strregion == "")
                {
                    ret = new Tuple<Point, Point>(new Point(30, 60), new Point(DrawImage.Width - 30, 60));
                    return ret;
                }
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(strregion);

                System.Xml.XmlNode item = xmldoc.SelectSingleNode("GraphData/GraphTypeInfo/GraphTypeItem");

                List<Point> ps = new List<Point>();
                foreach (System.Xml.XmlNode n in item.SelectNodes("PointList/Point"))
                {
                    string[] xy = n.InnerText.Split(',');
                    ps.Add(new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1])));
                };
                ret = new Tuple<Point, Point>(ps[0], ps[1]);


                return ret;
            }
            set
            {
                SetGraphData(DrawGraphType.SecondLine, value);
            }

        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Tuple<Point, Point> NoStraightLineParam
        {
            get
            {
                string strregion = GetGraphData(DrawGraphType.NoStraightLine);
                Tuple<Point, Point> ret = new Tuple<Point, Point>(new Point(), new Point());
                if (strregion == "")
                {
                    ret = new Tuple<Point, Point>(new Point(30, 70), new Point(DrawImage.Width - 30, 70));
                    return ret;
                }
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(strregion);

                System.Xml.XmlNode item = xmldoc.SelectSingleNode("GraphData/GraphTypeInfo/GraphTypeItem");

                List<Point> ps = new List<Point>();
                foreach (System.Xml.XmlNode n in item.SelectNodes("PointList/Point"))
                {
                    string[] xy = n.InnerText.Split(',');
                    ps.Add(new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1])));
                };
                ret = new Tuple<Point, Point>(ps[0], ps[1]);


                return ret;
            }
            set
            {
                SetGraphData(DrawGraphType.NoStraightLine, value);
            }

        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Tuple<Point, Point> NoLeftLineParam
        {
            get
            {
                string strregion = GetGraphData(DrawGraphType.NoLeftLine);
                Tuple<Point, Point> ret = new Tuple<Point, Point>(new Point(), new Point());
                if (strregion == "")
                {
                    ret = new Tuple<Point, Point>(new Point(30, 80), new Point(DrawImage.Width - 30, 80));
                    return ret;
                }
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(strregion);

                System.Xml.XmlNode item = xmldoc.SelectSingleNode("GraphData/GraphTypeInfo/GraphTypeItem");

                List<Point> ps = new List<Point>();
                foreach (System.Xml.XmlNode n in item.SelectNodes("PointList/Point"))
                {
                    string[] xy = n.InnerText.Split(',');
                    ps.Add(new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1])));
                };
                ret = new Tuple<Point, Point>(ps[0], ps[1]);


                return ret;
            }
            set
            {
                SetGraphData(DrawGraphType.NoLeftLine, value);
            }

        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Tuple<Point, Point> NoRightLineParam
        {
            get
            {
                string strregion = GetGraphData(DrawGraphType.NoRightLine);
                Tuple<Point, Point> ret = new Tuple<Point, Point>(new Point(), new Point());
                if (strregion == "")
                {
                    ret = new Tuple<Point, Point>(new Point(30, 90), new Point(DrawImage.Width - 30, 90));
                    return ret;
                }
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(strregion);

                System.Xml.XmlNode item = xmldoc.SelectSingleNode("GraphData/GraphTypeInfo/GraphTypeItem");

                List<Point> ps = new List<Point>();
                foreach (System.Xml.XmlNode n in item.SelectNodes("PointList/Point"))
                {
                    string[] xy = n.InnerText.Split(',');
                    ps.Add(new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1])));
                };
                ret = new Tuple<Point, Point>(ps[0], ps[1]);


                return ret;
            }
            set
            {
                SetGraphData(DrawGraphType.NoRightLine, value);
            }

        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Tuple<Point, Point> NoTurnAroundLineParam
        {
            get
            {
                string strregion = GetGraphData(DrawGraphType.NoTurnAroundLine);
                Tuple<Point, Point> ret = new Tuple<Point, Point>(new Point(), new Point());
                if (strregion == "")
                {
                    ret = new Tuple<Point, Point>(new Point(30, 100), new Point(DrawImage.Width - 30, 100));
                    return ret;
                }
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(strregion);

                System.Xml.XmlNode item = xmldoc.SelectSingleNode("GraphData/GraphTypeInfo/GraphTypeItem");

                List<Point> ps = new List<Point>();
                foreach (System.Xml.XmlNode n in item.SelectNodes("PointList/Point"))
                {
                    string[] xy = n.InnerText.Split(',');
                    ps.Add(new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1])));
                };
                ret = new Tuple<Point, Point>(ps[0], ps[1]);


                return ret;
            }
            set
            {
                SetGraphData(DrawGraphType.NoTurnAroundLine, value);
            }

        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<BreakRegion> BreakAreaParam
        {
            get
            {
                string strregion = GetGraphData(DrawGraphType.PassRegion);
                List<BreakRegion> ret = new List<BreakRegion>();
                if (strregion == "")
                {
                    List<Point> ps = new List<Point>();
                    ps.Add(new Point(30, 30));
                    ps.Add(new Point(DrawImage.Width - 30, 30));
                    ps.Add(new Point(DrawImage.Width - 30, DrawImage.Height - 30));
                    ps.Add(new Point(30, DrawImage.Height - 30));
                    ret.Add(new BreakRegion()
                    {
                        ID = 0,
                        RegionPointList = ps,
                        RegionType = 2,

                    });
                    return ret;
                }
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(strregion);
                int index = 0;
                foreach (System.Xml.XmlNode item in xmldoc.SelectNodes("GraphData/GraphTypeInfo/GraphTypeItem"))
                {
                    List<Point> ps = new List<Point>();
                    foreach (System.Xml.XmlNode n in item.SelectNodes("PointList/Point"))
                    {
                        string[] xy = n.InnerText.Split(',');
                        ps.Add(new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1])));
                    };
                    uint direct = Convert.ToUInt32(item.SelectSingleNode("PolygonDirection").InnerText);
                    BreakRegion br = new BreakRegion()
                    {
                        ID = (uint)index,
                        RegionType = direct,
                        TimelyReportTimeInterval = 0,
                        RegionPointList = ps,
                    };
                    index++;
                    ret.Add(br);
                }

                return ret;
            }
            set
            {
                value.ForEach(br => SetGraphData(DrawGraphType.PassRegion, br));
            }

        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Point> AnalyseAreaExParam
        {
            get
            {
                string strregion = GetGraphData(DrawGraphType.AnalyseAreaEx);
                List<Point> ret = new List<Point>();
                if (strregion == "")
                {
                    ret.Add(new Point(20, 20));
                    ret.Add(new Point(Convert.ToInt32(DrawImage.Width / 2f), 20));
                    ret.Add(new Point(DrawImage.Width - 20, 20));
                    ret.Add(new Point(DrawImage.Width - 20, DrawImage.Height - 20));
                    ret.Add(new Point(Convert.ToInt32(DrawImage.Width / 2f), DrawImage.Height - 20));
                    ret.Add(new Point(20, DrawImage.Height - 20));
                    return ret;
                }
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(strregion);
                System.Xml.XmlNode item = xmldoc.SelectSingleNode("GraphData/GraphTypeInfo/GraphTypeItem");

                List<Point> ps = new List<Point>();
                foreach (System.Xml.XmlNode n in item.SelectNodes("PointList/Point"))
                {
                    string[] xy = n.InnerText.Split(',');
                    ps.Add(new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1])));
                };
                ret = ps;
                return ret;
            }
            set
            {
                SetGraphData(DrawGraphType.AnalyseAreaEx, value);
            }

        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Rectangle> CarPlateAreaParam
        {
            get
            {
                string strregion = GetGraphData(DrawGraphType.VehicleRegion);
                List<Rectangle> ret = new List<Rectangle>();
                if (strregion == "")
                {
                    ret.Add(new Rectangle(30, Convert.ToInt32(2 * DrawImage.Height / 3f), DrawImage.Width - 60, Convert.ToInt32(DrawImage.Width / 3f) - 60));
                    return ret;
                }
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(strregion);
                System.Xml.XmlNode item = xmldoc.SelectSingleNode("GraphData/GraphTypeInfo/GraphTypeItem");

                List<Point> ps = new List<Point>();
                foreach (System.Xml.XmlNode n in item.SelectNodes("PointList/Point"))
                {
                    string[] xy = n.InnerText.Split(',');
                    ps.Add(new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1])));
                };
                Point p0 = ps[0];
                foreach (Point p in ps)
                {
                    p0 = MinPoint(p0, p);
                }
                int w = ps.Max(pw => pw.X - p0.X);
                int h = ps.Max(ph => ph.Y - p0.Y);
                //ret.Add(new Rectangle(ps[0].X, ps[0].Y, ps[2].X - ps[0].X, ps[2].Y - ps[0].Y));
                ret.Add(new Rectangle(p0, new Size(w, h)));
                return ret;
            }
            set
            {
                if(value.Count>0)
                SetGraphData(DrawGraphType.VehicleRegion, value.First());
            }

        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<DriveWayRegion> DriveWayRegionParam
        {
            get
            {
                List<DriveWayRegion> ret = new List<DriveWayRegion>();
                for (int i = 0; i < DriveWays.Length; i++)
                {
                    if (DriveWays[i])
                    {
                        string strregion = GetGraphData((DrawGraphType)((uint)DrawGraphType.DriveWay1 + (uint)i));
                        if (strregion == "")
                            continue;
                        System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                        xmldoc.LoadXml(strregion);
                        System.Xml.XmlNode item = xmldoc.SelectSingleNode("GraphData/GraphTypeInfo/GraphTypeItem");

                        List<Point> ps = new List<Point>();
                        foreach (System.Xml.XmlNode n in item.SelectNodes("PointList/Point"))
                        {
                            string[] xy = n.InnerText.Split(',');
                            ps.Add(new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1])));
                        };
                        string[] StartPoint = item.SelectSingleNode("StartPoint").InnerText.Split(',');
                        string[] EndPoint = item.SelectSingleNode("EndPoint").InnerText.Split(',');
                        float angle = Convert.ToSingle(item.SelectSingleNode("Angle").InnerText);


                        DriveWayRegion r = new DriveWayRegion()
                        {
                            ChannelID = (uint)(i + 1),
                            RegionPointList = ps,
                            Angle = angle,
                            DirectLineStart = new Point(Convert.ToInt32(StartPoint[0]), Convert.ToInt32(StartPoint[1])),
                            DirectLineEnd = new Point(Convert.ToInt32(EndPoint[0]), Convert.ToInt32(EndPoint[1])),
                        };
                        Point fluxps = new Point();
                        Point fluxpe = new Point();
                        VehicleFluxLine((DrawGraphType)((uint)DrawGraphType.VehicleFluxLine1 + (uint)i), r, out fluxps, out fluxpe);
                        r.FluxLineStart = fluxps;
                        r.FluxLineEnd = fluxpe;
                        ret.Add(r);
                    }
                }
                if (ret.Count == 0)
                {
                    List<Point> ps = new List<Point>();
                    ps.Add(new Point(40, 40));
                    ps.Add(new Point(DrawImage.Width - 40, 40));
                    ps.Add(new Point(DrawImage.Width - 40, DrawImage.Height - 40));
                    ps.Add(new Point(30, DrawImage.Height - 40));

                    ret.Add(new DriveWayRegion
                    {
                        Angle = 0,
                        ChannelID = 1,
                        RegionPointList = ps,
                        DirectLineStart = new Point(100, 100),
                        DirectLineEnd = new Point(100, 200),
                        FluxLineStart = new Point(100, DrawImage.Height - 100),
                        FluxLineEnd = new Point(DrawImage.Width - 100, DrawImage.Height - 100),
                    });
                }
                return ret;
            }
            set
            {
                foreach (var item in value)
                {
                    SetGraphData((DrawGraphType)(DrawGraphType.DriveWay1 + (int)item.ChannelID-1), item);
                    SetGraphData((DrawGraphType)(DrawGraphType.VehicleFluxLine1 + (int)item.ChannelID-1), item);
                }
            }

        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Rectangle> FarAreaParam
        {
            get
            {
                string strregion = GetGraphData(DrawGraphType.FarArea);
                List<Rectangle> ret = new List<Rectangle>();
                if (strregion == "")
                {
                    ret.Add(new Rectangle(30, 30, 100, 200));
                    return ret;
                }
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(strregion);
                System.Xml.XmlNode item = xmldoc.SelectSingleNode("GraphData/GraphTypeInfo/GraphTypeItem");

                List<Point> ps = new List<Point>();
                foreach (System.Xml.XmlNode n in item.SelectNodes("PointList/Point"))
                {
                    string[] xy = n.InnerText.Split(',');
                    Point newp = new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1]));
                    ps.Add(newp);
                };

                Point p0 = ps[0];
                foreach (Point p in ps)
                {
                    p0 = MinPoint(p0, p);
                }
                int w = ps.Max(pw => pw.X - p0.X);
                int h = ps.Max(ph => ph.Y - p0.Y);
                //ret.Add(new Rectangle(ps[0].X, ps[0].Y, ps[2].X - ps[0].X, ps[2].Y - ps[0].Y));
                ret.Add(new Rectangle(p0, new Size(w, h)));
                return ret;
            }
            set
            {
                if (value.Count>0)
                    SetGraphData(DrawGraphType.FarArea, value.First());
            }

        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Rectangle> NearAreaParam
        {
            get
            {
                string strregion = GetGraphData(DrawGraphType.NearArea);
                List<Rectangle> ret = new List<Rectangle>();
                if (strregion == "")
                {
                    ret.Add(new Rectangle(DrawImage.Width - 30 - 200, DrawImage.Height - 30 - 400, 200, 400));
                    return ret;
                }
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(strregion);
                System.Xml.XmlNode item = xmldoc.SelectSingleNode("GraphData/GraphTypeInfo/GraphTypeItem");

                List<Point> ps = new List<Point>();
                foreach (System.Xml.XmlNode n in item.SelectNodes("PointList/Point"))
                {
                    string[] xy = n.InnerText.Split(',');
                    ps.Add(new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1])));
                };
                Point p0 = ps[0];
                foreach (Point p in ps)
                {
                    p0 = MinPoint(p0, p);
                }
                int w = ps.Max(pw => pw.X - p0.X);
                int h = ps.Max(ph => ph.Y - p0.Y);
                //ret.Add(new Rectangle(ps[0].X, ps[0].Y, ps[2].X - ps[0].X, ps[2].Y - ps[0].Y));
                ret.Add(new Rectangle(p0, new Size(w, h)));
                return ret;
            }
            set
            {
                if (value.Count>0)
                    SetGraphData(DrawGraphType.NearArea, value.First());
            }

        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Point> ImageSC
        {
            get
            {
                string strregion = GetGraphData(DrawGraphType.ImageSC);
                List<Point> ret = new List<Point>();
                if (strregion == "")
                {
                    ret.Add(new Point(20, 20));
                    ret.Add(new Point(Convert.ToInt32(DrawImage.Width / 2f), 20));
                    ret.Add(new Point(DrawImage.Width - 20, 20));
                    ret.Add(new Point(DrawImage.Width - 20, DrawImage.Height - 20));
                    ret.Add(new Point(Convert.ToInt32(DrawImage.Width / 2f), DrawImage.Height - 20));
                    ret.Add(new Point(20, DrawImage.Height - 20));
                    return ret;
                }
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(strregion);
                System.Xml.XmlNode item = xmldoc.SelectSingleNode("GraphData/GraphTypeInfo/GraphTypeItem");

                List<Point> ps = new List<Point>();
                foreach (System.Xml.XmlNode n in item.SelectNodes("PointList/Point"))
                {
                    string[] xy = n.InnerText.Split(',');
                    ps.Add(new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1])));
                };
                if (ps.Count != 6)
                {
                    throw new SDKCallException(1, "标定设置错误，必须为六个点，请删除后重新设置。");
                }
                ret = ps;
                return ret;
            }
            set
            {
                SetGraphData(DrawGraphType.ImageSC, value);
            }

        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Point> GlobaRegionParam
        {
            get
            {
                string strregion = GetGraphData(DrawGraphType.GlobaRegion);
                List<Point> ret = new List<Point>();
                if (strregion == "")
                {
                    ret.Add(new Point(20, 20));
                    ret.Add(new Point(Convert.ToInt32(DrawImage.Width / 2f), 20));
                    ret.Add(new Point(DrawImage.Width - 20, 20));
                    ret.Add(new Point(DrawImage.Width - 20, DrawImage.Height - 20));
                    ret.Add(new Point(Convert.ToInt32(DrawImage.Width / 2f), DrawImage.Height - 20));
                    ret.Add(new Point(20, DrawImage.Height - 20));
                    return ret;
                }
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(strregion);
                System.Xml.XmlNode item = xmldoc.SelectSingleNode("GraphData/GraphTypeInfo/GraphTypeItem");

                List<Point> ps = new List<Point>();
                foreach (System.Xml.XmlNode n in item.SelectNodes("PointList/Point"))
                {
                    string[] xy = n.InnerText.Split(',');
                    ps.Add(new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1])));
                };
                ret = ps;
                return ret;
            }
            set
            {
                SetGraphData(DrawGraphType.GlobaRegion, value);
            }

        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Point> ParticalRegionParam
        {
            get
            {
                string strregion = GetGraphData(DrawGraphType.ParticalRegion);
                List<Point> ret = new List<Point>();
                if (strregion == "")
                {
                    ret.Add(new Point(20, 20));
                    ret.Add(new Point(Convert.ToInt32(DrawImage.Width / 2f), 20));
                    ret.Add(new Point(DrawImage.Width - 20, 20));
                    ret.Add(new Point(DrawImage.Width - 20, DrawImage.Height - 20));
                    ret.Add(new Point(Convert.ToInt32(DrawImage.Width / 2f), DrawImage.Height - 20));
                    ret.Add(new Point(20, DrawImage.Height - 20));
                    return ret;
                }
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(strregion);
                System.Xml.XmlNode item = xmldoc.SelectSingleNode("GraphData/GraphTypeInfo/GraphTypeItem");

                List<Point> ps = new List<Point>();
                foreach (System.Xml.XmlNode n in item.SelectNodes("PointList/Point"))
                {
                    string[] xy = n.InnerText.Split(',');
                    ps.Add(new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1])));
                };
                ret = ps;
                return ret;
            }
            set
            {
                SetGraphData(DrawGraphType.ParticalRegion, value);
            }

        }
        #endregion

        #region 构造
        public ucSingleDrawImageWnd()
        {
            InitializeComponent();

        }
        #endregion

        #region 公共函数

        public void ClearAllGraphs()
        {
            DeleteGraghs(0);
        }

        public void ClearSelectGraph()
        {
            DeleteSelectedGragh();
        }

        public void SetDrawType(DrawGraphType type)
        {
            SetCurrentDrawMode(type);
        }
        #endregion

        #region DrawOCX

        int DeleteGraghs(uint graphTypeId)
        {
            if (axChannelDrawing1 == null || !axChannelDrawing1.IsHandleCreated)
                return 0;

            axChannelDrawing1.DeleteGraghs(graphTypeId);
            return 0;
        }
        int DeleteSelectedGragh()
        {
            if (axChannelDrawing1 == null || !axChannelDrawing1.IsHandleCreated)
                return 0;

            axChannelDrawing1.DeleteSelectedGragh();
            return 0;
        }
        string GetGraphData(DrawGraphType graphType)
        {
            if (axChannelDrawing1==null || !axChannelDrawing1.IsHandleCreated)
                return "";

            string retVal = axChannelDrawing1.GetGraphData((uint)graphType);
            return retVal;
        }
        void SetCurrentDrawMode(DrawGraphType type)
        {
            if (axChannelDrawing1 == null || !axChannelDrawing1.IsHandleCreated)
                return;

            int nModeSel = 0;
            int strTypeID = 0;
            string strTypeName = "";
            string strSelText = "";

            switch (type)
            {
                case DrawGraphType.AnalyseAreaEx:
                    nModeSel = 3;
                    strTypeID = (int)type;

                    strTypeName = "检测区域";
                    break;
                case DrawGraphType.GlobaRegion:
                    nModeSel = 2;
                    strTypeID = (int)type;

                    strTypeName = "全局特征框";
                    break;
                case DrawGraphType.ParticalRegion:
                    nModeSel = 2;
                    strTypeID = (int)type;

                    strTypeName = "局部特征框";
                    break;
                case DrawGraphType.PassLine:
                    nModeSel = 7;
                    strTypeID = (int)type;
                    strTypeName = "越界线";
                    break;
                case DrawGraphType.PassRegion:
                    nModeSel = 6;
                    strTypeID = (int)type;
                    strTypeName = "闯入闯出";
                    break;
                case DrawGraphType.DriveWay1:
                case DrawGraphType.DriveWay2:
                case DrawGraphType.DriveWay3:
                case DrawGraphType.DriveWay4:
                case DrawGraphType.DriveWay5:
                case DrawGraphType.DriveWay6:
                    nModeSel = 5;
                    strTypeID = (int)type;
                    strTypeName = "车道" + (strTypeID - 10);
                    break;
                case DrawGraphType.VehicleRegion:
                    nModeSel = 2;
                    strTypeID = (int)type;
                    strTypeName = "车牌检测区";
                    break;
                case DrawGraphType.VehicleFluxLine1:
                case DrawGraphType.VehicleFluxLine2:
                case DrawGraphType.VehicleFluxLine3:
                case DrawGraphType.VehicleFluxLine4:
                case DrawGraphType.VehicleFluxLine5:
                case DrawGraphType.VehicleFluxLine6:
                    nModeSel = 1;
                    strTypeID = (int)type;
                    strTypeName = "流量线" + (strTypeID - 4);
                    break;
                case DrawGraphType.PeopleCountLine:
                    nModeSel = 7;
                    strTypeID = (int)type;
                    strTypeName = "人数线";
                    break;
                case DrawGraphType.FarArea:
                    nModeSel = 2;
                    strTypeID = (int)type;
                    strTypeName = "远处行人框";
                    break;
                case DrawGraphType.NearArea:
                    nModeSel = 2;
                    strTypeID = (int)type;
                    strTypeName = "近处行人框";
                    break;
                case DrawGraphType.ImageSC:
                    nModeSel = 3;
                    strTypeID = (int)type;
                    strTypeName = "标定";
                    break;
                case DrawGraphType.ChangeChannelLine:
                    nModeSel = 1;
                    strTypeID = (int)type;
                    strTypeName = "变道线";
                    break;
                case DrawGraphType.PressChannelLine:
                    nModeSel = 1;
                    strTypeID = (int)type;
                    strTypeName = "压道线" ;
                    break;
                case DrawGraphType.StopLine:
                    nModeSel = 1;
                    strTypeID = (int)type;
                    strTypeName = "停止线" ;
                    break;
                case DrawGraphType.SecondLine:
                    nModeSel = 1;
                    strTypeID = (int)type;
                    strTypeName = "斑马线中线" ;
                    break;
                case DrawGraphType.NoStraightLine:
                    nModeSel = 1;
                    strTypeID = (int)type;
                    strTypeName = "禁止直行线" ;
                    break;
                case DrawGraphType.NoLeftLine:
                    nModeSel = 1;
                    strTypeID = (int)type;
                    strTypeName = "禁止左转线" ;
                    break;
                case DrawGraphType.NoRightLine:
                    nModeSel = 1;
                    strTypeID = (int)type;
                    strTypeName = "禁止右转线";
                    break;
                case DrawGraphType.NoTurnAroundLine:
                    nModeSel = 1;
                    strTypeID = (int)type;
                    strTypeName = "禁止掉头线" ;
                    break;

                case DrawGraphType.None:
                    nModeSel = 0;
                    strTypeID = 0;
                    strTypeName = "";
                    break;
                default:
                    break;
            }
            strSelText = string.Format("<?xml version=\"1.0\"?>" + System.Environment.NewLine
                    + "<DrawingMode>" + System.Environment.NewLine
                    + "<GraphPattern>{0}</GraphPattern>" + System.Environment.NewLine
                    + "<GraphTypeId>{1}</GraphTypeId>" + System.Environment.NewLine
                    + "<GraphName>{2}</GraphName>" + System.Environment.NewLine
                    + "</DrawingMode>", nModeSel, strTypeID, strTypeName);
            axChannelDrawing1.SetCurrentDrawMode(strSelText);


        }
        void SetGraphData(DrawGraphType type, object o)
        {
            if (axChannelDrawing1 == null || !axChannelDrawing1.IsHandleCreated)
                return;

            int nModeSel = 0;
            int strTypeID = 0;
            string strTypeName = "";
            string strBody = "";
            string strSelTextH = "<GraphData>" + System.Environment.NewLine
                + "<GraphTypeInfo typeid =\"{1}\"  pattern=\"{0}\" graphname=\"{2}\">" + System.Environment.NewLine
                + "<GraphTypeItem>" + System.Environment.NewLine;
            string strSelTextT = "</GraphTypeItem>" + System.Environment.NewLine
                + "</GraphTypeInfo>" + System.Environment.NewLine
                + "</GraphData>" + System.Environment.NewLine;

            bool needDraw = true;
            switch (type)
            {
                case DrawGraphType.AnalyseAreaEx:
                    nModeSel = 3;
                    strTypeName = "检测区域";
                    strTypeID = (int)type;

                    List<Point> rectex = o as List<Point>;
                    if (rectex != null)
                    {
                        string poings = "";
                        foreach (Point p in rectex)
                        {
                            poings += "<Point>" + p.X + "," + p.Y + "</Point>" + System.Environment.NewLine;
                        }
                        strBody += "<PointList>" + System.Environment.NewLine
                                        + poings
                                    + "</PointList>" + System.Environment.NewLine;
                    }
                    else
                        needDraw = false;
                    break;
                case DrawGraphType.GlobaRegion:
                    nModeSel = 2;
                    strTypeID = (int)type;

                    strTypeName = "全局特征框";
                    List<Point> rectg = o as List<Point>;
                    if (rectg != null)
                    {
                        string poings = "";
                        foreach (Point p in rectg)
                        {
                            poings += "<Point>" + p.X + "," + p.Y + "</Point>" + System.Environment.NewLine;
                        }
                        strBody += "<PointList>" + System.Environment.NewLine
                                        + poings
                                    + "</PointList>" + System.Environment.NewLine;
                    }
                    else
                        needDraw = false;
                    break;
                case DrawGraphType.ParticalRegion:
                    nModeSel = 2;
                    strTypeID = (int)type;

                    strTypeName = "局部特征框";
                    List<Point> rectp = o as List<Point>;
                    if (rectp != null)
                    {
                        string poings = "";
                        foreach (Point p in rectp)
                        {
                            poings += "<Point>" + p.X + "," + p.Y + "</Point>" + System.Environment.NewLine;
                        }
                        strBody += "<PointList>" + System.Environment.NewLine
                                        + poings
                                    + "</PointList>" + System.Environment.NewLine;
                    }
                    else
                        needDraw = false;
                    break;
                case DrawGraphType.PassLine:
                    nModeSel = 7;
                    strTypeID = (int)type;
                    strTypeName = "越界线";
                    PassLine pl = o as PassLine;
                    if (pl != null)
                    {
                        strBody = "<PointList>" + System.Environment.NewLine
                                        + "<Point>" + pl.PassLineStart.X + "," + pl.PassLineStart.Y + "</Point>" + System.Environment.NewLine
                                        + "<Point>" + pl.PassLineEnd.X + "," + pl.PassLineEnd.Y + "</Point>" + System.Environment.NewLine
                                    + "</PointList>" + System.Environment.NewLine
                                    + "<LineDirection>" + pl.PassLineType + "</LineDirection>" + System.Environment.NewLine
                                    + "<StartPoint>" + pl.DirectLineStart.X + "," + pl.DirectLineStart.Y + "</StartPoint>" + System.Environment.NewLine
                                    + "<EndPoint>" + pl.DirectLineEnd.X + "," + pl.DirectLineEnd.Y + "</EndPoint>" + System.Environment.NewLine;

                    }
                    else
                        needDraw = false;
                    break;
                case DrawGraphType.PassRegion:
                    nModeSel = 6;
                    strTypeID = (int)type;
                    strTypeName = "闯入闯出";
                    BreakRegion br = o as BreakRegion;
                    if (br != null)
                    {
                        string poings = "";
                        foreach (Point p in br.RegionPointList)
                        {
                            poings += "<Point>" + p.X + "," + p.Y + "</Point>" + System.Environment.NewLine;
                        }
                        strBody += "<PointList>" + System.Environment.NewLine
                                        + poings
                                    + "</PointList>" + System.Environment.NewLine
                                + "<PolygonDirection>" + br.RegionType + "</PolygonDirection>" + System.Environment.NewLine;

                    }
                    else
                        needDraw = false;
                    break;
                case DrawGraphType.DriveWay1:
                case DrawGraphType.DriveWay2:
                case DrawGraphType.DriveWay3:
                case DrawGraphType.DriveWay4:
                case DrawGraphType.DriveWay5:
                case DrawGraphType.DriveWay6:
                    nModeSel = 5;
                    strTypeID = (int)type;
                    strTypeName = "车道" + (strTypeID - 10);
                    DriveWayRegion dwr = o as DriveWayRegion;
                    if (dwr != null)
                    {
                        string poings = "";
                        foreach (Point p in dwr.RegionPointList)
                        {
                            poings += "<Point>" + p.X + "," + p.Y + "</Point>" + System.Environment.NewLine;
                        }
                        strBody = "<PointList>" + System.Environment.NewLine
                                        + poings
                                    + "</PointList>" + System.Environment.NewLine
                                    + "<Angle></Angle>" + System.Environment.NewLine
                                    + "<StartPoint>" + dwr.DirectLineStart.X + "," + dwr.DirectLineStart.Y + "</StartPoint>" + System.Environment.NewLine
                                    + "<EndPoint>" + dwr.DirectLineEnd.X + "," + dwr.DirectLineEnd.Y + "</EndPoint>" + System.Environment.NewLine;

                    }

                    else
                        needDraw = false;
                    break;
                case DrawGraphType.VehicleFluxLine1:
                case DrawGraphType.VehicleFluxLine2:
                case DrawGraphType.VehicleFluxLine3:
                case DrawGraphType.VehicleFluxLine4:
                case DrawGraphType.VehicleFluxLine5:
                case DrawGraphType.VehicleFluxLine6:
                    nModeSel = 5;
                    strTypeID = (int)type;
                    strTypeName = "流量线" + (strTypeID - 4);
                    DriveWayRegion dwrflux = o as DriveWayRegion;
                    if (dwrflux != null)
                    {
                        Point p1 = dwrflux.FluxLineStart;
                        Point p2 = dwrflux.FluxLineEnd;
                        strBody = "<PointList>" + System.Environment.NewLine +
                                           "<Point>" + p1.X + "," + p1.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p2.X + "," + p2.Y + "</Point>" + System.Environment.NewLine +
                                       "</PointList>" + System.Environment.NewLine;
                    }
                    else
                        needDraw = false;
                    break;
                case DrawGraphType.PeopleCountLine:
                    nModeSel = 7;
                    strTypeID = (int)type;
                    strTypeName = "人数线";
                    PassLine peoplecountline = o as PassLine;
                    if (peoplecountline != null)
                    {
                        Point p1 = peoplecountline.PassLineStart;
                        Point p2 = peoplecountline.PassLineEnd;
                        strBody = "<PointList>" + System.Environment.NewLine +
                                           "<Point>" + p1.X + "," + p1.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p2.X + "," + p2.Y + "</Point>" + System.Environment.NewLine +
                                       "</PointList>" + System.Environment.NewLine;
                    }
                    else
                        needDraw = false;
                    break;
                case DrawGraphType.VehicleRegion:
                    nModeSel = 2;
                    strTypeID = (int)type;
                    strTypeName = "车牌检测区";
                    Rectangle vehrect = (Rectangle)o;
                    if (vehrect != null)
                    {
                        Point p1 = vehrect.Location;
                        Point p2 = new Point(p1.X + vehrect.Width, p1.Y);
                        Point p3 = new Point(p2.X, p2.Y + vehrect.Height);
                        Point p4 = new Point(p1.X, p1.Y + vehrect.Height);
                        strBody = "<PointList>" + System.Environment.NewLine +
                                           "<Point>" + p1.X + "," + p1.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p2.X + "," + p2.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p3.X + "," + p3.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p4.X + "," + p4.Y + "</Point>" + System.Environment.NewLine +
                                       "</PointList>" + System.Environment.NewLine;
                    }
                    else
                        needDraw = false;
                    break;
                case DrawGraphType.ImageSC:
                    nModeSel = 3;
                    strTypeID = (int)type;
                    strTypeName = "标定";
                    List<Point> sm = (List<Point>)o;
                    if (sm != null)
                    {
                        string poings = "";
                        foreach (Point p in sm)
                        {
                            poings += "<Point>" + p.X + "," + p.Y + "</Point>" + System.Environment.NewLine;
                        }
                        strBody += "<PointList>" + System.Environment.NewLine
                                        + poings
                                    + "</PointList>" + System.Environment.NewLine;
                    }
                    else
                        needDraw = false;
                    break;

                case DrawGraphType.FarArea:
                    nModeSel = 2;
                    strTypeID = (int)type;
                    strTypeName = "远处行人框";
                    Rectangle recFar = (Rectangle)o;
                    if (recFar != null)
                    {
                        Point p1 = recFar.Location;
                        Point p2 = new Point(p1.X + recFar.Width, p1.Y);
                        Point p3 = new Point(p2.X, p2.Y + recFar.Height);
                        Point p4 = new Point(p1.X, p1.Y + recFar.Height);
                        strBody = "<PointList>" + System.Environment.NewLine +
                                           "<Point>" + p1.X + "," + p1.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p2.X + "," + p2.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p3.X + "," + p3.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p4.X + "," + p4.Y + "</Point>" + System.Environment.NewLine +
                                       "</PointList>" + System.Environment.NewLine;
                    }
                    else
                        needDraw = false;
                    break;
                case DrawGraphType.NearArea:
                    nModeSel = 2;
                    strTypeID = (int)type;
                    strTypeName = "近处行人框";
                    Rectangle recNear = (Rectangle)o;
                    if (recNear != null)
                    {
                        Point p1 = recNear.Location;
                        Point p2 = new Point(p1.X + recNear.Width, p1.Y);
                        Point p3 = new Point(p2.X, p2.Y + recNear.Height);
                        Point p4 = new Point(p1.X, p1.Y + recNear.Height);
                        strBody = "<PointList>" + System.Environment.NewLine +
                                           "<Point>" + p1.X + "," + p1.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p2.X + "," + p2.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p3.X + "," + p3.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p4.X + "," + p4.Y + "</Point>" + System.Environment.NewLine +
                                       "</PointList>" + System.Environment.NewLine;
                    }
                    else
                        needDraw = false;
                    break;

                case DrawGraphType.ChangeChannelLine:
                    nModeSel = 1;
                    strTypeID = (int)type;
                    strTypeName = "变道线";
                    List<Tuple<Point, Point>> changeChannelLine = o as List<Tuple<Point, Point>>;
                    if (changeChannelLine != null && changeChannelLine.Count>0)
                    {
                        foreach (var item in changeChannelLine)
                        {
                        Point p1 = item.Item1;
                        Point p2 = item.Item2;
                        strBody += "<GraphTypeItem><PointList>" + System.Environment.NewLine +
                                           "<Point>" + p1.X + "," + p1.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p2.X + "," + p2.Y + "</Point>" + System.Environment.NewLine +
                                       "</PointList></GraphTypeItem>" + System.Environment.NewLine;
                        }
                        int id1 = strBody.IndexOf("<GraphTypeItem>");
                        int id2 = strBody.LastIndexOf("</GraphTypeItem>");
                        strBody = strBody.Remove(id1, "<GraphTypeItem>".Length);
                        strBody = strBody.Remove(id2 - "</GraphTypeItem>".Length + 1);
                    }
                    else
                        needDraw = false;
                    break;
                case DrawGraphType.PressChannelLine:
                    nModeSel = 1;
                    strTypeID = (int)type;
                    strTypeName = "压道线";
                    List<Tuple<Point, Point>> pressChannelLine = o as List<Tuple<Point, Point>>;
                    if (pressChannelLine != null && pressChannelLine.Count > 0)
                    {
                        foreach (var item in pressChannelLine)
                        {
                        Point p1 = item.Item1;
                        Point p2 = item.Item2;
                        strBody += "<GraphTypeItem><PointList>" + System.Environment.NewLine +
                                           "<Point>" + p1.X + "," + p1.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p2.X + "," + p2.Y + "</Point>" + System.Environment.NewLine +
                                       "</PointList></GraphTypeItem>" + System.Environment.NewLine;
                        }
                        int id1 = strBody.IndexOf("<GraphTypeItem>");
                        int id2 = strBody.LastIndexOf("</GraphTypeItem>");
                        strBody = strBody.Remove(id1, "<GraphTypeItem>".Length);
                        strBody = strBody.Remove(id2 - "</GraphTypeItem>".Length + 1);
                    }
                    else
                        needDraw = false;

                    break;
                case DrawGraphType.StopLine:
                    nModeSel = 1;
                    strTypeID = (int)type;
                    strTypeName = "停止线";
                    Tuple<Point, Point> stopLine = o as Tuple<Point, Point>;
                    if (stopLine != null )
                    {
                        Point p1 = stopLine.Item1;
                        Point p2 = stopLine.Item2;
                        strBody += "<PointList>" + System.Environment.NewLine +
                                           "<Point>" + p1.X + "," + p1.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p2.X + "," + p2.Y + "</Point>" + System.Environment.NewLine +
                                       "</PointList>" + System.Environment.NewLine;
                    }
                    else
                        needDraw = false;
                    break;
                case DrawGraphType.SecondLine:
                    nModeSel = 1;
                    strTypeID = (int)type;
                    strTypeName = "斑马线中线";
                    Tuple<Point, Point> secondLine = o as Tuple<Point, Point>;
                    if (secondLine != null)
                    {
                        Point p1 = secondLine.Item1;
                        Point p2 = secondLine.Item2;
                        strBody += "<PointList>" + System.Environment.NewLine +
                                           "<Point>" + p1.X + "," + p1.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p2.X + "," + p2.Y + "</Point>" + System.Environment.NewLine +
                                       "</PointList>" + System.Environment.NewLine;
                    }
                    else
                        needDraw = false;
                    break;
                case DrawGraphType.NoStraightLine:
                    nModeSel = 1;
                    strTypeID = (int)type;
                    strTypeName = "禁止直行线";
                    Tuple<Point, Point> noStraightLine = o as Tuple<Point, Point>;
                    if (noStraightLine != null)
                    {
                        Point p1 = noStraightLine.Item1;
                        Point p2 = noStraightLine.Item2;
                        strBody += "<PointList>" + System.Environment.NewLine +
                                           "<Point>" + p1.X + "," + p1.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p2.X + "," + p2.Y + "</Point>" + System.Environment.NewLine +
                                       "</PointList>" + System.Environment.NewLine;
                    }
                    else
                        needDraw = false;
                    break;
                case DrawGraphType.NoLeftLine:
                    nModeSel = 1;
                    strTypeID = (int)type;
                    strTypeName = "禁止左转线";
                    Tuple<Point, Point> noLeftLine = o as Tuple<Point, Point>;
                    if (noLeftLine != null)
                    {
                        Point p1 = noLeftLine.Item1;
                        Point p2 = noLeftLine.Item2;
                        strBody += "<PointList>" + System.Environment.NewLine +
                                           "<Point>" + p1.X + "," + p1.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p2.X + "," + p2.Y + "</Point>" + System.Environment.NewLine +
                                       "</PointList>" + System.Environment.NewLine;
                    }
                    else
                        needDraw = false;
                    break;
                case DrawGraphType.NoRightLine:
                    nModeSel = 1;
                    strTypeID = (int)type;
                    strTypeName = "禁止右转线";
                    Tuple<Point, Point> noRightLine = o as Tuple<Point, Point>;
                    if (noRightLine != null)
                    {
                        Point p1 = noRightLine.Item1;
                        Point p2 = noRightLine.Item2;
                        strBody += "<PointList>" + System.Environment.NewLine +
                                           "<Point>" + p1.X + "," + p1.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p2.X + "," + p2.Y + "</Point>" + System.Environment.NewLine +
                                       "</PointList>" + System.Environment.NewLine;
                    }
                    else
                        needDraw = false;
                    break;
                case DrawGraphType.NoTurnAroundLine:
                    nModeSel = 1;
                    strTypeID = (int)type;
                    strTypeName = "禁止掉头线";
                    Tuple<Point, Point> noTurnAroundLine = o as Tuple<Point, Point>;
                    if (noTurnAroundLine != null)
                    {
                        Point p1 = noTurnAroundLine.Item1;
                        Point p2 = noTurnAroundLine.Item2;
                        strBody += "<PointList>" + System.Environment.NewLine +
                                           "<Point>" + p1.X + "," + p1.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p2.X + "," + p2.Y + "</Point>" + System.Environment.NewLine +
                                       "</PointList>" + System.Environment.NewLine;
                    }
                    else
                        needDraw = false;
                    break;

                case DrawGraphType.None:
                    needDraw = false;
                    break;
                default:
                    needDraw = false;
                    break;
            }
            if (needDraw)
            {
                string strSelText = string.Format("<?xml version=\"1.0\"?>" + System.Environment.NewLine
                        + strSelTextH + System.Environment.NewLine
                        + strBody + System.Environment.NewLine
                        + strSelTextT, nModeSel, strTypeID, strTypeName);
                axChannelDrawing1.SetGraphData(strSelText);
            }
        }
        void SetPicData(Image img)
        {
            if (axChannelDrawing1 == null || !axChannelDrawing1.IsHandleCreated)
                return;

            string szBase64Buff = Convert.ToBase64String(DataModel.Common.ImageToJpegBytes(img));

            string strXmlContent = string.Format("<?xml version=\"1.0\"?>" + System.Environment.NewLine
                                    + "<SrcPicParam>" + System.Environment.NewLine
                                    + "<PicType>JPG</PicType>" + System.Environment.NewLine
                                    + "<BASE64Data>{0}</BASE64Data>" + System.Environment.NewLine
                                    + "</SrcPicParam>", szBase64Buff);
            axChannelDrawing1.SetPicData(strXmlContent);

        }

        #endregion

        #region 私有函数
        private void VehicleFluxLine(DrawGraphType type, DriveWayRegion region, out Point ps, out Point pe)
        {
            string strregion = GetGraphData(type);

            if (strregion == "")
            {
                int minx = region.RegionPointList.Min(item => item.X);
                int miny = region.RegionPointList.Min(item => item.Y);
                int maxx = region.RegionPointList.Max(item => item.X);
                int maxy = region.RegionPointList.Max(item => item.Y);
                int w = Math.Abs(region.DirectLineStart.X - region.DirectLineEnd.X);
                int h = Math.Abs(region.DirectLineStart.Y - region.DirectLineEnd.Y);
                if (w <= h)
                {
                    ps = new Point(minx + 100, maxy - 100);
                    pe = new Point(maxx - 100, maxy - 100);
                }
                else
                {
                    ps = new Point(maxx - 100, miny + 100);
                    pe = new Point(maxx - 100, maxy - 100);

                }
                return;
            }
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(strregion);

            System.Xml.XmlNode node = xmldoc.SelectSingleNode("GraphData/GraphTypeInfo/GraphTypeItem");

            List<Point> pl = new List<Point>();
            foreach (System.Xml.XmlNode n in node.SelectNodes("PointList/Point"))
            {
                string[] xy = n.InnerText.Split(',');
                pl.Add(new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1])));
            };
            ps = pl[0];
            pe = pl[1];



        }
        private Point MinPoint(Point p1, Point p2)
        {
            decimal d1 = (p1.X * p1.X + p1.Y * p1.Y);
            decimal d2 = (p2.X * p2.X + p2.Y * p2.Y);
            if (d1 <= d2)
                return p1;
            else
                return p2;
        }


        #endregion

        #region 事件响应

        private void ucSinglePlayWnd_Load(object sender, EventArgs e)
        {

        }

        private void buttonClearAllGraphs_Click(object sender, EventArgs e)
        {
            ClearSelectGraph();
        }
        #endregion


    }


}
