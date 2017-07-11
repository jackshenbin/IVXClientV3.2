using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace IVX.DataModel
{

    public class RVODFileInfo 
    {
        public UInt32 VodFileSize { get; set; }

        public string VodFileName { get; set; }

        public string ServerIP { get; set; }

        public uint ServerPort { get; set; }
    };
    
}
