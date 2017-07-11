using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    public class SearchImageInfo
    {
        public System.Drawing.Image Image { get; set; }

        public string ImageURL { get; set; }

        public uint dwImageSize { get; set; }
        
        /// DWORD->unsigned int
        public uint dwCameraID { get; set; }

        public string CameraCode { get; set; }

        /// DWORD->unsigned int
        public uint dwTaskUnitID { get; set; }

        /// DWORD->unsigned int
        public uint dwMoveObjID { get; set; }

        public bool Matched { get; set; }

    }
}
