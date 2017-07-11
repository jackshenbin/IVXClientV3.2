using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;
using System.ComponentModel;

namespace IVX.Live.ViewModel
{
    public class MainNewViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string ServerMsg { get; set; }
        public Stack<SystemMenu> FormTree { get; set; }

        public bool IsConnected { get { return Framework.Container.Instance.CommService.IsConnected; } }
        public MainNewViewModel()
        {
            Framework.Container.Instance.CommService.FireMessage += new Action<string>(CommService_FireMessage);
            Framework.Container.Instance.CommService.UserDisConnected += CommService_UserDisConnected;
        }

        void CommService_UserDisConnected(string obj)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("UserDisConnected"));
        }

        void CommService_FireMessage(string obj)
        {
            ServerMsg = obj;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("ServerMsg"));
        }

        public void Clear()
        {
            Framework.Container.Instance.CommService.FireMessage -= new Action<string>(CommService_FireMessage);
            Framework.Container.Instance.CommService.UserDisConnected -= CommService_UserDisConnected;
            Framework.Container.Instance.CommService.UnInit();
        }

    }
}
