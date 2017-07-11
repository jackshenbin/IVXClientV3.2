using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;

namespace IVX.Live.ViewModel
{
    public class FtpFileSystemViewModel
    {
        public List<DataModel.VideoSupplierDeviceInfo> GET_NET_STORE_LIST()
        {
            return Framework.Container.Instance.CommService.GET_NET_STORE_LIST();
        }

    }
}
