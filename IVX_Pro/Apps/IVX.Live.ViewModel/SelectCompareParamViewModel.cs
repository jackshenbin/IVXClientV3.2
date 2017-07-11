using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;
using System.Drawing;

namespace IVX.Live.ViewModel
{
    public class SelectCompareParamViewModel
    {
        public bool IsPassLine { get; set; }
        public bool IsBreakRegion { get; set; }
        public bool IsGlobalRegion { get; set; }
        public bool IsParticalRegion { get; set; }
        public bool IsVehicle { get; set; }
        public List<PassLine> PassLineList { get; set; }
        public List<BreakRegion> BreakRegionList { get; set; }
        public List<System.Drawing.Point> GlobalRegion { get; set; }
        public List<System.Drawing.Point> ParticalRegion { get; set; }

        public System.Drawing.Image DemoPicture 
        { get
            {
                if (BasePicture == null)
                    return null;
            List<System.Drawing.Point> ps = new List<Point>();
            if(IsGlobalRegion)
                ps.AddRange(GlobalRegion);
            if (IsParticalRegion)
                ps.AddRange(ParticalRegion);
            if (IsPassLine)
            {
                foreach (var item in PassLineList)
                {
                    ps.Add(item.DirectLineEnd);
                    ps.Add(item.DirectLineStart);
                    ps.Add(item.PassLineEnd);
                    ps.Add(item.PassLineStart);
                }
            }
            if (IsBreakRegion)
            {
                foreach (var item in BreakRegionList)
                {
                    ps.AddRange(item.RegionPointList);
                }
            }
            Point p0 = new Point();
            int w = 0;
            int h = 0;
            if (ps.Count > 0)
            {
                p0 = ps[0];
                foreach (Point p in ps)
                {
                    p0 = MinPoint(p0, p);
                }
                w = ps.Max(pw => pw.X - p0.X);
                h = ps.Max(ph => ph.Y - p0.Y);
            }
            if (w == 0 || h == 0)
            {
                w = BasePicture.Width;
                h = BasePicture.Height;
            }
                //ret.Add(new Rectangle(ps[0].X, ps[0].Y, ps[2].X - ps[0].X, ps[2].Y - ps[0].Y));
               System.Drawing.Rectangle rect = new Rectangle(p0, new Size(w, h));
               System.Drawing.Image img = new System.Drawing.Bitmap(w, h);
               Image temp = new Bitmap(BasePicture);
               Graphics g = Graphics.FromImage(temp);
               if (IsGlobalRegion)
                   g.DrawPolygon(new Pen(Color.Yellow,2), GlobalRegion.ToArray());
               if (IsParticalRegion)
                   g.DrawPolygon(new Pen(Color.Yellow, 2), ParticalRegion.ToArray());
               if (IsPassLine)
               {
                   foreach (var item in PassLineList)
                   {
                       g.DrawLine(new Pen(Color.Yellow, 2), item.PassLineStart, item.PassLineEnd);
                       g.DrawLine(new Pen(Color.Yellow, 2), item.DirectLineStart, item.DirectLineEnd);
                   }
               }
               if (IsBreakRegion)
               {
                   foreach (var item in BreakRegionList)
                   {
                       g.DrawPolygon(new Pen(Color.Yellow, 2), item.RegionPointList.ToArray());
                   }
               }
               g.Dispose();
                g = Graphics.FromImage(img);
                g.DrawImage(temp, new Rectangle(0, 0, w, h), rect, GraphicsUnit.Pixel);
               g.Dispose();
               return img;
        }
        }

        public Image BasePicture { get; set; }
        private Point MinPoint(Point p1, Point p2)
        {
            decimal d1 = (p1.X * p1.X + p1.Y * p1.Y);
            decimal d2 = (p2.X * p2.X + p2.Y * p2.Y);
            if (d1 <= d2)
                return p1;
            else
                return p2;
        }

        public SelectedPictureParam PictureParam
        {
            get
            {
                SelectedPictureParam param = new SelectedPictureParam()
                {
                     IsPassLine = this.IsPassLine,
                      IsParticalRegion = this.IsParticalRegion,
                       IsGlobalRegion = this.IsGlobalRegion,
                        IsBreakRegion = this.IsBreakRegion,
                    PassLineList = IsPassLine?this.PassLineList:new List<PassLine>(),                    
                    BreakRegionList = IsBreakRegion? this.BreakRegionList:new List<BreakRegion>(),
                    GlobalRegion = IsGlobalRegion? this.GlobalRegion:new List<System.Drawing.Point>(),
                    ParticalRegion = IsParticalRegion? this.ParticalRegion:new List<System.Drawing.Point>(),
                    DemoPicture = this.DemoPicture,
                     IsVehicle = this.IsVehicle,
                      BasePicture = this.BasePicture,
                };
                return param;
            }
            set
            {
                this.BreakRegionList= value.BreakRegionList;
                this.PassLineList = value.PassLineList;
                this.GlobalRegion = value.GlobalRegion;
                this.ParticalRegion = value.ParticalRegion;
                this.IsPassLine = value.IsPassLine;
                this.IsBreakRegion = value.IsBreakRegion;
                this.IsGlobalRegion = value.IsGlobalRegion;
                this.IsParticalRegion = value.IsParticalRegion;
                this.IsVehicle = value.IsVehicle;
            }
        }

    }
}