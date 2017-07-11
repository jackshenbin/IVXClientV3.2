using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFormAppUtil
{
    public interface IEventAggregatorSubscriber
    {
        void UnSubscribe();
    }
}
