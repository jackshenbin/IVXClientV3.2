using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{

    [Serializable]
    public class SelectedPictureParam
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

        public System.Drawing.Image DemoPicture { get; set; }
        public System.Drawing.Image BasePicture { get; set; }
    };
}
