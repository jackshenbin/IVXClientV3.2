using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    public class BeginSearchInfo
    {
        public SearchItemV3_1 SearchItem { get; set; }

        public System.Drawing.Image Image { get; set;}

        public SelectedPictureParam PictureParam { get; set; }

        public bool IsRealtimeTask { get; set; }
    }
}
