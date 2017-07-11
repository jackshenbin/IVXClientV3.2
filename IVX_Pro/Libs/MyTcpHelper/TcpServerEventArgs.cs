using System;
using System.Collections.Generic;

using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace MyTcpHelper
{
    /// <summary>
    /// Tcp服务器事件参数定义
    /// </summary>
    public class TcpServerEventArgs : EventArgs
    {
        #region ===私有字段===

        /// <summary>
        /// 包装的Tcp服务端套接字
        /// </summary>
        private TcpServerSocket _serverSocket;

        /// <summary>
        /// 本次事件相关的数据大小
        /// </summary>
        private int _datasize;

        #endregion

        #region ===公有属性===

        /// <summary>
        /// 包装的Tcp服务端套接字
        /// </summary>
        public TcpServerSocket ServerSocket
        {
            get
            {
                return this._serverSocket;
            }
        }

        /// <summary>
        /// 本次事件相关的数据大小
        /// </summary>
        public int DataSize
        {
            get
            {
                return this._datasize;
            }
            set
            {
                if (value >= 0)
                {
                    this._datasize = value;
                }
            }
        }

        #endregion

        #region ===构造函数===

        public TcpServerEventArgs(TcpServerSocket serverSocket, int datasize)
        {
            Debug.Assert(serverSocket != null && datasize >= 0);

            if (serverSocket == null)
            {
                throw new Exception("TcpServerEventArgs_Constructor_Error:TcpServerSocket实例不能为空");
            }
            if (datasize < 0)
            {
                throw new Exception("TcpServerEventArgs_Constructor_Error:数据大小不能小于0");
            }

            this._serverSocket = serverSocket;

            this._datasize = datasize;
        }

        public TcpServerEventArgs(TcpServerSocket serverSocket)
            : this(serverSocket, 0)
        {
        }

        public TcpServerEventArgs(Socket socket, int datasize)
            : this(new TcpServerSocket(socket), datasize)
        {
        }

        public TcpServerEventArgs(Socket socket)
            : this(socket, 0)
        {
        }


        #endregion
    }
}
