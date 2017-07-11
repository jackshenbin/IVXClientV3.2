using System.ComponentModel;
using System.Drawing;
using System.Linq;
// using BOCOM.IVX.Framework;
using IVX.DataModel;
using System.Collections.Generic;
using WinFormAppUtil;
using System;

namespace WinFormAppUtil.ViewModel
{
    public class LoadImageViewModel : ViewModelBase
    {
        #region Fields

        AxChannelDrawingLib.AxChannelDrawing m_PicControl;

        private System.Windows.Forms.Control m_PicPlayer;

        private Image m_baseImage = null;

        private Image m_currImage = null;

        private Rectangle m_imageRectangle = new Rectangle(350, 150, 200, 200);

        private Rectangle m_AnalyseArea;

        private CompareImageInfo m_CompareImageInfo;

        private int altsize = 20;

        #endregion

        #region Properties
        
        public Image BaseImage
        {
            get { return m_baseImage; }
            set
            {
                m_baseImage = value; 
            }
        }
        
        public Image CurrImage
        {
            get
            {
                if (m_currImage == null)
                {
                    m_currImage = m_baseImage;
                }
                return m_currImage; 
            }
            set
            {
                m_currImage = value;
                SetPicData(m_currImage);
            }
        }
        
        public Rectangle ImageRectangle
        {
            get
            {
                return m_AnalyseArea;
            }
            set
            {
                m_AnalyseArea = value;
            }
        }
        
        public ImageType CurrImageType { get; set; }

        public AxChannelDrawingLib.AxChannelDrawing PicControl
        {
            get { return m_PicControl; }
            set { m_PicControl = value; }
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

        public CompareImageInfo CompareImageInfo
        {
            get { return m_CompareImageInfo; }
            set { m_CompareImageInfo = value; }
        } 

        #endregion

        #region Constructors

        public LoadImageViewModel(System.Windows.Forms.Control c)
        {
            m_PicPlayer = c;

            CurrImageType = ImageType.Common;
        }


        #endregion
        
        public List<Rectangle> GetAnalyseAreas()
        {
            if (CurrImage == null)
            {
                return null;
            }

            string strregion = m_PicControl.GetGraphData((uint)DrawGraphType.AnalyseAreaEx);
            List<Rectangle> ret = new List<Rectangle>();
            if (strregion == "")
            {
                return null;
                // ret.Add(new Rectangle(1, 1, CurrImage.Width - 2, CurrImage.Height - 2));
                //return ret;
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

            ret.Add(new Rectangle(p0, new Size(w, h)));
            return ret;
        }

        public void SetPicDrawTypeRect(DrawGraphType type, string graphName=null)
        {
            int nModeSel = 0;
            int strTypeID = 0;
            string strTypeName = "";
            string strSelText = "";

            switch (type)
            {
                case DrawGraphType.AnalyseAreaEx:
                    nModeSel = 2;
                    strTypeID = (int)type;

                    strTypeName = "检测区域";
                    break;
                case DrawGraphType.PassLine:
                    nModeSel = 7;
                    strTypeID = (int)type;
                    strTypeName = "越界线";
                    break;
                case DrawGraphType.PassRegion:
                    nModeSel = 3;
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
                    nModeSel = 3;
                    strTypeID = (int)type;
                    strTypeName = "车牌检测区";
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
                    + "</DrawingMode>", nModeSel, strTypeID, graphName == null?strTypeName : graphName);
            m_PicControl.SetCurrentDrawMode(strSelText);


        }
        
        public void SetPicData(Image img)
        {
            string szBase64Buff = Convert.ToBase64String(IVX.DataModel.Common.ImageToJpegBytes(img));

            string strXmlContent = string.Format("<?xml version=\"1.0\"?>" + System.Environment.NewLine
                                    + "<SrcPicParam>" + System.Environment.NewLine
                                    + "<PicType>JPG</PicType>" + System.Environment.NewLine
                                    + "<BASE64Data>{0}</BASE64Data>" + System.Environment.NewLine
                                    + "</SrcPicParam>", szBase64Buff);
            m_PicControl.SetPicData(strXmlContent);


        }

        public void SetPicDrawData(DrawGraphType type, object o)
        {
            int nModeSel = 0;
            int strTypeID = 0;
            string strTypeName = "";
            string strBody = "";
            string strSelTextH = "<GraphData>" + System.Environment.NewLine
                + "<GraphTypeInfo typeid =\"{1}\" >" + System.Environment.NewLine
                + "<GraphTypeItem pattern=\"{0}\" graphname=\"{2}\">" + System.Environment.NewLine;
            string strSelTextT = "</GraphTypeItem>" + System.Environment.NewLine
                + "</GraphTypeInfo>" + System.Environment.NewLine
                + "</GraphData>" + System.Environment.NewLine;

            bool needDraw = true;
            switch (type)
            {
                case DrawGraphType.AnalyseAreaEx:
                    Rectangle rect = (Rectangle)o;
                    if (rect != null)
                    {
                        Point p1 = rect.Location;
                        Point p2 = new Point(p1.X + rect.Width, p1.Y);
                        Point p3 = new Point(p2.X, p2.Y + rect.Height);
                        Point p4 = new Point(p1.X, p1.Y + rect.Height);
                        strBody =
                                       "<PointList>" + System.Environment.NewLine +
                                           "<Point>" + p1.X + "," + p1.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p2.X + "," + p2.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p3.X + "," + p3.Y + "</Point>" + System.Environment.NewLine +
                                           "<Point>" + p4.X + "," + p4.Y + "</Point>" + System.Environment.NewLine +
                                       "</PointList>" + System.Environment.NewLine;

                    }
                    else
                        needDraw = false;
                    nModeSel = 3;
                    strTypeName = "检测区域";
                    strTypeID = (int)type;
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
                    nModeSel = 3;
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
                case DrawGraphType.VehicleRegion:
                    nModeSel = 3;
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
                    nModeSel = 3;
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
                    nModeSel = 3;
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
                m_PicControl.SetGraphData(strSelText);
            }

        }


        #region Public helper functions


        public Image GetCutImage()
        {
            if (m_currImage == null)
                return null;
            Rectangle rect = ImageRectangle;

            Bitmap bitmap = new Bitmap(rect.Width + altsize, rect.Height + altsize);
            
            Graphics dc = Graphics.FromImage(bitmap);
            dc.DrawImage(m_currImage, new Rectangle(0, 0, bitmap.Width, bitmap.Height)
                , new Rectangle(rect.X - altsize / 2, rect.Y - altsize / 2, rect.Width + altsize, rect.Height + altsize), GraphicsUnit.Pixel);
            dc.DrawRectangle(new Pen(Color.Red, 3), altsize / 2, altsize / 2, rect.Width, rect.Height);
            dc.Save();
            return bitmap;
        }

        public void ReturnToBaseImage()
        {
            CurrImage = m_baseImage;
        }

        public bool Commit()
        {
            if (!Validate())
            {
                return false;
            }

            // WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Publish(UIFuncItemInfo.SEARCH);

            // WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<GotoCompareSearchEvent>().Publish("");
            m_CompareImageInfo = new CompareImageInfo();
            m_CompareImageInfo.Image = CurrImage;
            m_CompareImageInfo.RegionImage = GetCutImage();
            m_CompareImageInfo.ImageRectangle = ImageRectangle;
            m_CompareImageInfo.ImageType = CurrImageType;
            // WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<SetCompareImageInfoEvent>().Publish(info);

            return true;
           
        }

        private bool Validate()
        {
            m_AnalyseArea = Rectangle.Empty;

            if (CurrImage == null)
            {
                WinFormAppUtil.AppContainer.Instance.InteractionService.ShowMessageBox("未设置比对图，请选择图片后继续。", WinFormAppUtil.AppContainer.Instance.PROGRAM_NAME, System.Windows.Forms.MessageBoxButtons.OK);
                return false;
            }

            List<Rectangle> analyseRects = GetAnalyseAreas();
            if (analyseRects == null)
            {
                string msg = "未绘制比对框是否继续？";
                if (WinFormAppUtil.AppContainer.Instance.InteractionService.ShowMessageBox(msg, WinFormAppUtil.AppContainer.Instance.PROGRAM_NAME, System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                {
                    return false;
                }

                m_AnalyseArea = new Rectangle(1, 1, CurrImage.Width - 2, CurrImage.Height - 2);
                return true;
            }

            m_AnalyseArea = analyseRects[0];

            return true;
        }

        public void InitPic()
        {
            // Framework.Container.Instance.GraphicDrawService.HPicWnd = m_PicPlayer.Handle;
            // Framework.Container.Instance.GraphicDrawService.OpenPic();
        }

        public void ClearPic()
        {
            // Framework.Container.Instance.GraphicDrawService.ClosePic();
        }
        #endregion

    }

}


