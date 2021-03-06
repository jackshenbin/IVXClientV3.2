﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    public class SDKCallException : Exception
    {
        public uint ErrorCode {get;set;}

        public SDKCallException(uint errorCode, string msg) :
            base(msg)
        {
            this.ErrorCode = errorCode;
        }
    }
}
