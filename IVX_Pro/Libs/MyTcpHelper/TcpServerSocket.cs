using System;
using System.Collections.Generic;

using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace MyTcpHelper
{
    /// <summary>
    /// 包装服务器端套接字
    /// </summary>
    public class TcpServerSocket
    {
        #region ===自定义常量===

        /// <summary>
        /// 缺省缓冲区大小
        /// </summary>
        private const int DEFAULT_BUFFER_SIZE = 4096;

        #endregion

        #region ===私有字段===

        /// <summary>
        /// 套接字
        /// </summary>
        private Socket _socket;

        /// <summary>
        /// 数据缓冲区
        /// </summary>
        private byte[] _buffer;


        private string[] RIDs;

        #endregion


        #region ===公有属性===

        /// <summary>
        /// 数据缓冲区
        /// </summary>
        public byte[] Buffer
        {
            get
            {
                return this._buffer;
            }
        }

        /// <summary>
        /// 套接字
        /// </summary>
        public Socket Socket
        {
            get
            {
                return this._socket;
            }
        }


        #endregion

     

        #region ===构造函数===

        public TcpServerSocket(Socket socket)
            : this(socket, DEFAULT_BUFFER_SIZE)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="socket">要包装的套接字</param>
        /// <param name="buffersize">缓冲区大小</param>
        public TcpServerSocket(Socket socket, int buffersize)
        {
            Debug.Assert(socket != null && buffersize > 0);

            if (socket == null)
            {
                throw new Exception("TcpServerSocket_Constructor_Error:套接字不能为空");
            }
            if (buffersize <= 0)
            {
                throw new Exception("TcpServerSocket_Constructor_Error:数据缓冲区长度须大于0");
            }

            this._socket = socket;

            this._buffer = new byte[buffersize];

        }

        #endregion
    }
}
