using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// // using IVX.Live.Config.Framework;
using System.Threading;
using IVX.DataModel;
using System.Drawing;
using IVX.Live.ConfigServices.Interop;


namespace IVX.Live.ConfigServices
{
    public class GraphicDrawService
    {
        private Image m_Image;

        private IntPtr m_hPicWnd = IntPtr.Zero;

        private IVXRealtimeProtocol m_protocol;

        private IVXRealtimeProtocol IVXProtocol
        {
            get
            {
                return m_protocol;
            }
        }
        public IntPtr HPicWnd
        {
          get { return m_hPicWnd; }
            set 
            {
                if (value != IntPtr.Zero && m_hPicWnd != value)
                    m_hPicWnd = value; 
            }
        }

        public GraphicDrawService(IVXRealtimeProtocol protocol)
        {
            m_protocol = protocol;
        }

        public void Cleanup()
        {
            m_hPicWnd = IntPtr.Zero;
        }

        uint m_hPdoHandle = 0;

        public uint OpenPic()
        {
            m_hPdoHandle = IVXProtocol.Pdo_Open(m_hPicWnd, 0);
            return m_hPdoHandle;
        }

        public void ClosePic()
        {
            IVXProtocol.Pdo_Close(m_hPdoHandle);
            m_hPdoHandle = 0;
        }
        public void ClearDraw()
        {
            IVXProtocol.Pdo_DrawClear(m_hPdoHandle);
        }

        public void SetPic(Image img)
        {
            IVXProtocol.Pdo_DisplayPicDataSet(m_hPdoHandle, img);
            m_Image = img;
        }

        public void SetPicDrawTypeRect(E_PDO_DRAW_TYPE type)
        {
            IVXProtocol.Pdo_DrawTypeSet(m_hPdoHandle, type);
        }

        public List<Rectangle> GetPicDrawRect()
        {
            List<Rectangle> rects = IVXProtocol.Pdo_DrawRectGet(m_hPdoHandle);

            if (rects == null || rects.Count == 0)
            {
                rects.Add(new Rectangle(new Point(0, 0), m_Image.Size));
            }

            return rects;
        }

        public void SetPicDrawRect(List<Rectangle> rects)
        {
            IVXProtocol.Pdo_DrawRectSet(m_hPdoHandle, rects);
        }

        public List<PassLine> GetPicDrawCrossLines()
        {
            List<PassLine> lines = IVXProtocol.Pdo_CrossLinesGet(m_hPdoHandle);

            //if (rects == null || rects.Count == 0)
            //{
            //    rects.Add(new Rectangle(new Point(0, 0), m_Image.Size));
            //}

            return lines;
        }

        public void SetPicDrawCrossLines(List<PassLine> lines)
        {
            IVXProtocol.Pdo_CrossLinesSet(m_hPdoHandle, lines);
        }

        public List<BreakRegion> GetFencePolygons()
        {
            List<BreakRegion> polygons = IVXProtocol.Pdo_FencePolygonsGet(m_hPdoHandle);
            return polygons;
        }

        public void SetFencePolygons(List<BreakRegion> fences)
        {
            IVXProtocol.Pdo_FencePolygonsSet(m_hPdoHandle, fences);
        }
    }
}
