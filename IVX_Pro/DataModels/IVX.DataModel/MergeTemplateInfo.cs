using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    public class MergeTemplateInfo 
    {
        public UInt32 TemplateID { get; set; }

        public string  TemplateName { get; set; }

        public string  TemplateContent { get; set; }
        
    }

    public class TranceProtocolTypeInfo
    {
        public E_TRANS_PROTOCOL_TYPE Type { get; set; }

        public uint NStatus
        {
            get
            {
                return (uint)Type;
            }
        }

        public string Name { get; set; }

        public TranceProtocolTypeInfo(E_TRANS_PROTOCOL_TYPE type, string name)
        {
            Type = type;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }


}
