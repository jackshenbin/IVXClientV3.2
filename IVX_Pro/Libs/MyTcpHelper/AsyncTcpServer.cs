using System;
using System.Collections.Generic;

using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace MyTcpHelper
{
    /// <summary>
    /// 封装异步Tcp服务器
    /// </summary>
    public sealed class AsyncTcpServer : IDisposable
    {
        #region ===私有字段===

        /// <summary>
        /// Tcp端口监听器
        /// </summary>
        private TcpListener _tcpListener;

        /// <summary>
        /// 服务器终结点
        /// </summary>
        private IPEndPoint _serverIPEndPoint;

        /// <summary>
        /// 已连接的服务端套接字列表
        /// </summary>
        private List<TcpServerSocket> _connectedServerSockets;

        #endregion

        #region ===公有属性===

        /// <summary>
        /// 服务器端点
        /// </summary>
        public IPEndPoint ServerIPEndPoint
        {
            get
            {
                return this._serverIPEndPoint;
            }
        }

        #endregion

        #region ===构造函数===

        public AsyncTcpServer(IPEndPoint iep)
        {
            this._serverIPEndPoint = iep;

            this._tcpListener = new TcpListener(this._serverIPEndPoint);

            this._connectedServerSockets = new List<TcpServerSocket>();
        }

        #endregion

        #region ===事件委托===

        /// <summary>
        /// 接受端口的事件委托
        /// </summary>
        public event EventHandler<TcpServerEventArgs> OnAcceptSocket;

        /// <summary>
        /// 接收数据的事件委托
        /// </summary>
        public event EventHandler<TcpServerEventArgs> OnReceiveData;

        /// <summary>
        /// 发送数据的事件委托
        /// </summary>
        public event EventHandler<TcpServerEventArgs> OnSendData;

        /// <summary>
        /// 断开客户端连接时的事件委托
        /// </summary>
        public event EventHandler<TcpServerEventArgs> OnClientDisconnected;

        /////////////// <summary>
        /////////////// 接收到一包数据
        /////////////// </summary>
        ////////////public event RoutedPropertyChangedEventHandler<protocol> OneHollpackReceived;

        public event EventHandler OnError;
        #endregion

        #region ===对外公开方法===

        public bool Start()
        {
            try
            {
                this._tcpListener.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("启动AsyncTcpServer时发生异常：", ex));
                OnError(string.Format("启动AsyncTcpServer时发生异常：", ex), null);
                return false;
            }

            this._tcpListener.BeginAcceptSocket(new AsyncCallback(this.AcceptSocketCallback), this._tcpListener);

            return true;
        }

        public bool Stop()
        {
            bool bError = true;

            this.CloseAllSockets();

            try
            {
                this._tcpListener.Stop();

                bError = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("停止AsyncTcpServer时发生异常：", ex));
                OnError(string.Format("停止AsyncTcpServer时发生异常：", ex), null);

            }

            return !bError;
        }

        #region ===关闭套接字===

        /// <summary>
        /// 关闭套接字
        /// </summary>
        /// <param name="socket">要关闭的套接字</param>
        public void CloseSocket(TcpServerSocket socket)
        {
            if (!this._connectedServerSockets.Contains(socket))
            {
                return;
            }

            try
            {
                socket.Socket.Shutdown(SocketShutdown.Both);
                socket.Socket.Close();
            }
            catch (SocketException sex)
            {
                Debug.WriteLine(string.Format("AsyncTcpServer_CloseSocket_SocketException:{0}", sex.StackTrace));
                OnError(string.Format("AsyncTcpServer_CloseSocket_SocketException:{0}", sex.StackTrace), null);

            }
            catch (ObjectDisposedException oex)
            {
                Debug.WriteLine(string.Format("AsyncTcpServer_CloseSocket_ObjectDisposedException:{0}", oex.StackTrace));
                OnError(string.Format("AsyncTcpServer_CloseSocket_ObjectDisposedException:{0}", oex.StackTrace), null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("AsyncTcpServer_CloseSocket_Exception:{0}", ex.StackTrace));
                OnError(string.Format("AsyncTcpServer_CloseSocket_Exception:{0}", ex.StackTrace), null);
            }

            // 从列表中清除
            this.RemoveSocketFromList(socket);

            if (this.OnClientDisconnected != null)
            {
                this.OnClientDisconnected(this, new TcpServerEventArgs(socket));
            }
        }

        #endregion

        #endregion

        #region ===私有方法===

        #region ===接受连接的回调函数===

        /// <summary>
        /// 接受连接的回调函数
        /// </summary>
        /// <param name="ar"></param>
        private void AcceptSocketCallback(IAsyncResult ar)
        {
            TcpListener tcpListener = ar.AsyncState as TcpListener;

            Socket serverSocket = null;

            bool bError = true; ;

            try
            {
                serverSocket = tcpListener.EndAcceptSocket(ar);

                bError = false;
            }
            catch (SocketException sex)
            {
                Debug.WriteLine(string.Format("AsyncTcpServer_AcceptSocket_SocketException:{0}", sex.StackTrace));
                OnError(string.Format("AsyncTcpServer_AcceptSocket_SocketException:{0}", sex.StackTrace), null);
            }
            catch (ObjectDisposedException oex)
            {
                Debug.WriteLine(string.Format("AsyncTcpServer_AcceptSocket_ObjectDisposedException:{0}", oex.StackTrace));
                OnError(string.Format("AsyncTcpServer_AcceptSocket_ObjectDisposedException:{0}", oex.StackTrace), null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("AsyncTcpServer_AcceptSocket_Exception:{0}", ex.StackTrace));
                OnError(string.Format("AsyncTcpServer_AcceptSocket_Exception:{0}", ex.StackTrace), null);
            }



            Debug.WriteLine(string.Format("当前连接数:{0}", this._connectedServerSockets.Count));

            try
            {
                // 接受新连接
                tcpListener.BeginAcceptSocket(new AsyncCallback(this.AcceptSocketCallback), tcpListener);
            }
            catch (Exception exAcceptNew)
            {
                Debug.WriteLine(string.Format("接收新套接字时出错:{0}", exAcceptNew.StackTrace));
                OnError(string.Format("接收新套接字时出错:{0}", exAcceptNew.StackTrace), null);
            }

            if (bError)
            {
                return;
            }

            TcpServerSocket socketWrapper = new TcpServerSocket(serverSocket);
            //////////////socketWrapper.ProtocolReceiver.OnProtocolReceived += new RoutedPropertyChangedEventHandler<protocol>(ProtocolReceiver_OnProtocolReceived);

            // 加入连接列表
            this.AddSocketToList(socketWrapper);
            // 调用事件
            if (this.OnAcceptSocket != null)
            {
                this.OnAcceptSocket(this, new TcpServerEventArgs(socketWrapper));
            }

            bError = true;

            try
            {
                // 开始接收数据
                serverSocket.BeginReceive(socketWrapper.Buffer, 0, socketWrapper.Buffer.Length, SocketFlags.None, new AsyncCallback(this.ReceiveDataCallback), socketWrapper);

                bError = false;
            }
            catch (SocketException sex1)
            {
                Debug.WriteLine(string.Format("AsyncTcpServer_AcceptSocket_BeginReceive_SocketException:{0}", sex1.StackTrace));
                OnError(string.Format("AsyncTcpServer_AcceptSocket_BeginReceive_SocketException:{0}", sex1.StackTrace), null);
            }
            catch (ObjectDisposedException oex1)
            {
                Debug.WriteLine(string.Format("AsyncTcpServer_AcceptSocket_BeginReceive_ObjectDisposedException:{0}", oex1.StackTrace));
                OnError(string.Format("AsyncTcpServer_AcceptSocket_BeginReceive_ObjectDisposedException:{0}", oex1.StackTrace), null);
            }
            catch (Exception ex1)
            {
                Debug.WriteLine(string.Format("AsyncTcpServer_AcceptSocket_BeginReceive_Exception:{0}", ex1.StackTrace));
                OnError(string.Format("AsyncTcpServer_AcceptSocket_BeginReceive_Exception:{0}", ex1.StackTrace), null);
            }

            if (bError)
            {
                try
                {
                    //serverSocket.Shutdown(SocketShutdown.Both);
                    serverSocket.Close();

                    if (this.OnClientDisconnected != null)
                    {
                        this.OnClientDisconnected(this, new TcpServerEventArgs(serverSocket));
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(string.Format("关闭客户端连接出错:{0}", ex.StackTrace));
                    OnError(string.Format("关闭客户端连接出错:{0}", ex.StackTrace), null);
                }

                // 从列表中删除
                this.RemoveSocketFromList(socketWrapper);
            }


            // 清理引用
            serverSocket = null;
            socketWrapper = null;
        }

        /////////////// <summary>
        /////////////// 解协议的事件
        /////////////// </summary>
        /////////////// <param name="sender"></param>
        /////////////// <param name="e"></param>
        ////////////void ProtocolReceiver_OnProtocolReceived(object sender, RoutedPropertyChangedEventArgs<protocol> e)
        ////////////{

        ////////////    if (OneHollpackReceived != null)
        ////////////    {
        ////////////        OneHollpackReceived(sender, e);
        ////////////    }
        ////////////}

        #endregion

        #region ===接收数据的回调函数===

        /// <summary>
        /// 接收数据的回调函数
        /// </summary>
        /// <param name="ar"></param>
        private void ReceiveDataCallback(IAsyncResult ar)
        {
            TcpServerSocket serverSocket = ar.AsyncState as TcpServerSocket;

            int iReceiveBytesCount = 0;

            bool bError = true;

            try
            {
                iReceiveBytesCount = serverSocket.Socket.EndReceive(ar);

                bError = false;
            }
            catch (SocketException sex)
            {
                Debug.WriteLine(string.Format("AsyncTcpServer_EndReceive_SocketException:{0}", sex.ToString()));
                //OnError(string.Format("AsyncTcpServer_EndReceive_SocketException:[{1}]{0}", sex.ToString(), sex.SocketErrorCode.ToString()), null);
            }
            catch (ObjectDisposedException oex)
            {
                Debug.WriteLine(string.Format("AsyncTcpServer_EndReceive_ObjectDisposedException:{0}", oex.StackTrace));
                //OnError(string.Format("AsyncTcpServer_EndReceive_ObjectDisposedException:{0}", oex.StackTrace), null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("AsyncTcpServer_EndReceive_Exception:{0}", ex.StackTrace));
                //OnError(string.Format("AsyncTcpServer_EndReceive_Exception:{0}", ex.StackTrace), null);
            }

            // 发生错误或客户端断开连接则关闭套接字
            if (bError || iReceiveBytesCount == 0)
            {
                try
                {
                    serverSocket.Socket.Shutdown(SocketShutdown.Both);

                    serverSocket.Socket.Close();
                    OnError(string.Format("Socket.Shutdown"), null);

                }
                catch (SocketException sex)
                {
                    Debug.WriteLine(string.Format("AsyncTcpServer_ClientDisconnected_SocketException:{0}", sex.StackTrace));
                    OnError(string.Format("AsyncTcpServer_ClientDisconnected_SocketException:{0}", sex.StackTrace), null);
                }
                catch (ObjectDisposedException oex)
                {
                    Debug.WriteLine(string.Format("AsyncTcpServer_ClientDisconnected_ObjectDisposedException:{0}", oex.StackTrace));
                    OnError(string.Format("AsyncTcpServer_ClientDisconnected_ObjectDisposedException:{0}", oex.StackTrace), null);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(string.Format("AsyncTcpServer_ClientDisconnected_Exception:{0}", ex.StackTrace));
                    OnError(string.Format("AsyncTcpServer_ClientDisconnected_Exception:{0}", ex.StackTrace), null);
                }

                // 从连接列表中删除
                this.RemoveSocketFromList(serverSocket);

                if (this.OnClientDisconnected != null)
                {
                    this.OnClientDisconnected(this, new TcpServerEventArgs(serverSocket));
                }

                return;
            }

            ////////////if (OneHollpackReceived != null)
            ////////////{
            ////////////    //this.OnReceiveData(this, new TcpServerEventArgs(serverSocket, iReceiveBytesCount));
            ////////////    ///将数据传当前联接对像的解协议实例
            ////////////    serverSocket.ProtocolReceiver.ReceiveActive(serverSocket.Buffer.Take(iReceiveBytesCount).ToArray());
            ////////////}
            if (OnReceiveData != null)
                OnReceiveData(this, new TcpServerEventArgs(serverSocket, iReceiveBytesCount));

            bError = true;

            try
            {
                serverSocket.Socket.BeginReceive(serverSocket.Buffer, 0, serverSocket.Buffer.Length, SocketFlags.None, new AsyncCallback(this.ReceiveDataCallback), serverSocket);

                bError = false;
            }
            catch (SocketException sex)
            {
                Debug.WriteLine(string.Format("AsyncTcpServer_BeginReceive_SocketException:{0}", sex.StackTrace));
                OnError(string.Format("AsyncTcpServer_BeginReceive_SocketException:{0}", sex.StackTrace), null);
            }
            catch (ObjectDisposedException oex)
            {
                Debug.WriteLine(string.Format("AsyncTcpServer_BeginReceive_ObjectDisposedException:{0}", oex.StackTrace));
                OnError(string.Format("AsyncTcpServer_BeginReceive_ObjectDisposedException:{0}", oex.StackTrace), null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("AsyncTcpServer_BeginReceive_Exception:{0}", ex.StackTrace));
                OnError(string.Format("AsyncTcpServer_BeginReceive_Exception:{0}", ex.StackTrace), null);
            }

            if (bError)
            {
                // 从列表中删除
                this.RemoveSocketFromList(serverSocket);

                if (this.OnClientDisconnected != null)
                {
                    this.OnClientDisconnected(this, new TcpServerEventArgs(serverSocket));
                }
            }
        }

        #endregion

        #region ===关闭所有连接===

        /// <summary>
        /// 关闭所有连接
        /// </summary>
        private void CloseAllSockets()
        {
            lock (this._connectedServerSockets)
            {
                if (this._connectedServerSockets.Count == 0)
                {
                    return;
                }

                foreach (TcpServerSocket socket in this._connectedServerSockets)
                {
                    try
                    {
                        socket.Socket.Shutdown(SocketShutdown.Both);
                        socket.Socket.Close();
                    }
                    catch (SocketException sex)
                    {
                        Debug.WriteLine(string.Format("AsyncTcpServer_CloseSocket_SocketException:{0}", sex.StackTrace));
                        OnError(string.Format("AsyncTcpServer_CloseSocket_SocketException:{0}", sex.StackTrace), null);
                    }
                    catch (ObjectDisposedException oex)
                    {
                        Debug.WriteLine(string.Format("AsyncTcpServer_CloseSocket_ObjectDisposedException:{0}", oex.StackTrace));
                        OnError(string.Format("AsyncTcpServer_CloseSocket_ObjectDisposedException:{0}", oex.StackTrace), null);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(string.Format("AsyncTcpServer_CloseSocket_Exception:{0}", ex.StackTrace));
                        OnError(string.Format("AsyncTcpServer_CloseSocket_Exception:{0}", ex.StackTrace), null);
                    }

                    if (this.OnClientDisconnected != null)
                    {
                        this.OnClientDisconnected(this, new TcpServerEventArgs(socket));
                    }
                }

                // 清空列表
                this._connectedServerSockets.Clear();
            }
        }

        #endregion

        #region ===从连接列表中清除Socket===

        /// <summary>
        /// 从连接列表中清除Socket
        /// </summary>
        /// <param name="socket"></param>
        private void RemoveSocketFromList(TcpServerSocket socket)
        {
            lock (this._connectedServerSockets)
            {
                if (!this._connectedServerSockets.Contains(socket))
                {
                    return;
                }

                this._connectedServerSockets.Remove(socket);
            }
        }

        #endregion

        #region ===将Socket加入连接列表===

        /// <summary>
        /// 将Socket加入连接列表
        /// </summary>
        /// <param name="socket">要加入列表的Socket</param>
        private void AddSocketToList(TcpServerSocket socket)
        {
            lock (this._connectedServerSockets)
            {
                if (this._connectedServerSockets.Contains(socket))
                {
                    return;
                }

                this._connectedServerSockets.Add(socket);
            }
        }

        #endregion

        #endregion

        #region ===清理资源===

        private void Dispose(bool bDispose)
        {
            if (bDispose)
            {
            }

            this.CloseAllSockets();

            this._tcpListener.Stop();

            // 清理委托
            this.OnAcceptSocket = null;
            this.OnReceiveData = null;
            this.OnSendData = null;
            this.OnClientDisconnected = null;
        }

        ~AsyncTcpServer()
        {
            this.Dispose(false);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion


    }
}
