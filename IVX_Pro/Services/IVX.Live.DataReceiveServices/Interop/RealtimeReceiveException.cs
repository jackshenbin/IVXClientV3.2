using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.Live.DataReceiveServices.Interop
{
    public class RealtimeReceiveException : Exception
    {

        public RealtimeReceiveException(string msg) :
            base(msg)
        {
        }
    }
}
