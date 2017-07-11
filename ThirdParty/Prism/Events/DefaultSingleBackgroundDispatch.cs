using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Microsoft.Practices.Prism.Events
{
    public class DefaultSingleBackgroundDispatch
    {
        private static Thread s_Thread;
        private static object s_SyncObj = new object();
        public static Thread BackgroundThread
        {
            get
            {
                lock (s_SyncObj)
                {
                    if (s_Thread == null)
                    {
                        s_Thread = new Thread(null);
                    }
                }
            }
        }
    }
}
