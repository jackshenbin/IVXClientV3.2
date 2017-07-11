using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFormAppUtil
{
    public class LoginToken
    {
        public string ServerIP { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public int Port{ get; set; }
        public int LocalPort{ get; set; }


        public LoginToken(string serverIP, string userName, string password, int port, int localPort)
        {
            ServerIP = serverIP;
            UserName = userName;
            Password = password;

            Port = port;
            LocalPort = localPort;
        }
    }
}
