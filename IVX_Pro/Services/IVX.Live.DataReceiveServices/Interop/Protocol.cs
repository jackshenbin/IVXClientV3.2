using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Net.Sockets;
using System.Linq;
using System.Diagnostics;
using IVX.DataModel;
using MyTcpHelper;

namespace IVX.Live.DataReceiveServices.Interop
{
    public class Protocol
    {
        static UInt32 workflow = 0;

        bool m_isStarting = false;

        public event EventHandler OnConnected;
        public event EventHandler OnDisConnected;
        public event EventHandler OnClintError;

        internal delegate void deleteReceiveNOTE_UPLOAD_PLATE_DATA(Protocol tcp, NOTE_UPLOAD_PLATE_DATA obj);
        internal delegate void deleteReceiveNOTE_UPLOAD_TRAFFIC_EVENT(Protocol tcp, NOTE_UPLOAD_TRAFFIC_EVENT obj);
        internal delegate void deleteReceiveNOTE_UPLOAD_TRAFFIC_PARAM(Protocol tcp, NOTE_UPLOAD_TRAFFIC_PARAM obj);
        internal delegate void deleteReceiveNOTE_UPLOAD_BEHAVIOR_EVENT(Protocol tcp, NOTE_UPLOAD_BEHAVIOR_EVENT obj);
        internal delegate void deleteReceiveNOTE_UPLOAD_FACECONTROL_EVENT(Protocol tcp, NOTE_UPLOAD_FACECONTROL_EVENT obj);
        internal delegate void deleteReceiveNOTE_UPLOAD_MOVEOBJINFO_DATA(Protocol tcp, NOTE_UPLOAD_MOVEOBJINFO_DATA obj);
        internal delegate void deleteReceiveNOTE_UPLOAD_MOVEFEATURE_DATA(Protocol tcp, NOTE_UPLOAD_MOVEFEATURE_DATA obj);
        internal delegate void deleteReceiveNOTE_UPLOAD_COLORFEATURE_DATA(Protocol tcp, NOTE_UPLOAD_COLORFEATURE_DATA obj);
        internal delegate void deleteReceiveNOTE_UPLOAD_SCENEMARK_DATA(Protocol tcp, NOTE_UPLOAD_SCENEMARK_DATA obj);
        internal delegate void deleteReceiveNOTE_UPLOAD_CROWD_DATA(Protocol tcp, NOTE_UPLOAD_CROWD_DATA obj);
        internal delegate void deleteReceiveNOTE_UPLOAD_PEOPLECOUNT_DATA(Protocol tcp, NOTE_UPLOAD_PEOPLECOUNT_DATA obj);
        internal delegate void deleteReceiveNOTE_UPLOAD_PEOPLECOUNTALARM_EVENT(Protocol tcp, NOTE_UPLOAD_PEOPLECOUNTALARM_EVENT obj);
        internal delegate void deleteReceiveNOTE_IMAGE_SEARCH_DATA(Protocol tcp, NOTE_IMAGE_SEARCH_DATA obj);
        internal delegate void deleteReceiveNOTE_TRAFFIC_FEATURE_PARAM_DATA(Protocol tcp, NOTE_TRAFFIC_FEATURE_PARAM_DATA obj);
        internal delegate void deleteReceiveNOTE_IMAGE_SEARCH_STD_DATA(Protocol tcp, NOTE_IMAGE_SEARCH_STD_DATA obj);
        internal delegate void deleteReceiveNOTE_UPLOAD_MOVEOBJECT_PEOPLE_PUDONG_DATA(Protocol tcp, NOTE_UPLOAD_MOVEOBJECT_PEOPLE_PUDONG_DATA obj);
        internal delegate void deleteReceiveNOTE_UPLOAD_MOVEOBJECT_VEHICLE_PUDONG_DATA(Protocol tcp, NOTE_UPLOAD_MOVEOBJECT_VEHICLE_PUDONG_DATA obj);

        internal event deleteReceiveNOTE_UPLOAD_PLATE_DATA OnReceiveNOTE_UPLOAD_PLATE_DATA;
        internal event deleteReceiveNOTE_UPLOAD_TRAFFIC_EVENT OnReceiveNOTE_UPLOAD_TRAFFIC_EVENT;
        internal event deleteReceiveNOTE_UPLOAD_TRAFFIC_PARAM OnReceiveNOTE_UPLOAD_TRAFFIC_PARAM;
        internal event deleteReceiveNOTE_UPLOAD_BEHAVIOR_EVENT OnReceiveNOTE_UPLOAD_BEHAVIOR_EVENT;
        internal event deleteReceiveNOTE_UPLOAD_FACECONTROL_EVENT OnReceiveNOTE_UPLOAD_FACECONTROL_EVENT;
        internal event deleteReceiveNOTE_UPLOAD_MOVEOBJINFO_DATA OnReceiveNOTE_UPLOAD_MOVEOBJINFO_DATA;
        internal event deleteReceiveNOTE_UPLOAD_MOVEFEATURE_DATA OnReceiveNOTE_UPLOAD_MOVEFEATURE_DATA;
        internal event deleteReceiveNOTE_UPLOAD_COLORFEATURE_DATA OnReceiveNOTE_UPLOAD_COLORFEATURE_DATA;
        internal event deleteReceiveNOTE_UPLOAD_SCENEMARK_DATA OnReceiveNOTE_UPLOAD_SCENEMARK_DATA;
        internal event deleteReceiveNOTE_UPLOAD_CROWD_DATA OnReceiveNOTE_UPLOAD_CROWD_DATA;
        internal event deleteReceiveNOTE_UPLOAD_PEOPLECOUNT_DATA OnReceiveNOTE_UPLOAD_PEOPLECOUNT_DATA;
        internal event deleteReceiveNOTE_UPLOAD_PEOPLECOUNTALARM_EVENT OnReceiveNOTE_UPLOAD_PEOPLECOUNTALARM_EVENT;
        internal event deleteReceiveNOTE_IMAGE_SEARCH_DATA OnReceiveNOTE_IMAGE_SEARCH_DATA;
        internal event deleteReceiveNOTE_TRAFFIC_FEATURE_PARAM_DATA OnReceiveNOTE_TRAFFIC_FEATURE_PARAM_DATA;
        internal event deleteReceiveNOTE_IMAGE_SEARCH_STD_DATA OnReceiveNOTE_IMAGE_SEARCH_STD_DATA;
        internal event deleteReceiveNOTE_UPLOAD_MOVEOBJECT_PEOPLE_PUDONG_DATA OnReceiveNOTE_UPLOAD_MOVEOBJECT_PEOPLE_PUDONG_DATA;
        internal event deleteReceiveNOTE_UPLOAD_MOVEOBJECT_VEHICLE_PUDONG_DATA OnReceiveNOTE_UPLOAD_MOVEOBJECT_VEHICLE_PUDONG_DATA;


        AsyncTcpServer TcpServer;


        public void Open(int port)
        {
            TcpServer = new AsyncTcpServer(new System.Net.IPEndPoint(
       System.Net.IPAddress.Any
       , port
     ));
            TcpServer.OnError += TcpServer_OnError;
            TcpServer.OnClientDisconnected += TcpServer_OnClientDisconnected;
            if (TcpServer.Start())
            {
                TcpServer.OnReceiveData += TcpServer_OnReceiveData;
                m_isStarting = true;
                ShowMessage("start....");
            }
            else
            {
                ShowMessage("start Listen(port:" + port + ") error！", true);
            }

        }

        void TcpServer_OnClientDisconnected(object sender, TcpServerEventArgs e)
        {
            lock (mapbuffer)
            {
                if (mapbuffer.ContainsKey(e.ServerSocket.Socket))
                {
                    Trace.WriteLine("WriteRingBuffer delete ReadWriteRingBuffer client:" + e.ServerSocket.Socket.Handle.ToInt64());

                    mapbuffer[e.ServerSocket.Socket].Tag = null;
                    mapbuffer[e.ServerSocket.Socket].Close();
                    mapbuffer[e.ServerSocket.Socket] = null;
                    mapbuffer.Remove(e.ServerSocket.Socket);
                }
            }
        }
        void TcpServer_OnError(object sender, EventArgs e)
        {
            ShowMessage("[ERROR] " + sender.ToString());
        }

        public void Close()
        {
            m_isStarting = false;
            TcpServer.Stop();
        }
        private void ShowMessage(string msg, bool iserror = false)
        {
            Trace.WriteLine(iserror ? "[ERR]" : "INFO" + "ShowMessage :" + msg);
            if (iserror)
                throw new SDKCallException(int.MaxValue, msg);
        }

        Dictionary<Socket, ReadWriteQueueBuffer> mapbuffer = new Dictionary<Socket, ReadWriteQueueBuffer>();

        private void WriteRingBuffer(Socket client, byte[] buffer, int index, int count)
        {
            lock (mapbuffer)
            {
                if (mapbuffer.ContainsKey(client))
                {
                    mapbuffer[client].Write(buffer, index, count);
                    Trace.WriteLine("WriteRingBuffer client:" + client.Handle.ToInt64() + ",left:" + (1024 * 1024 * 10 - mapbuffer[client].Count));
                }
                else
                {
                    Trace.WriteLine("WriteRingBuffer new ReadWriteRingBuffer client:" + client.Handle.ToInt64());
                    ReadWriteQueueBuffer ringbuf = new ReadWriteQueueBuffer();// (1024 * 1024 * 10);
                    ringbuf.Tag = client;
                    mapbuffer.Add(client, ringbuf);
                    mapbuffer[client].Write(buffer, index, count);
                    new System.Threading.Thread(DoProcessReceiveData).Start(ringbuf);

                }
            }
        }

        void TcpServer_OnReceiveData(object sender, TcpServerEventArgs e)
        {
            WriteRingBuffer(e.ServerSocket.Socket, e.ServerSocket.Buffer, 0, e.DataSize);
        }

        void DoProcessReceiveData(object obj)
        {
            ReadWriteQueueBuffer ringbuf = obj as ReadWriteQueueBuffer;
            if (ringbuf == null)
                return;
            while (m_isStarting)
            {
                if (ringbuf.Count > 4)
                {
                    if (ringbuf[0] == '<' &&
                        ringbuf[1] == '<' &&
                        ringbuf[2] == '<' &&
                        ringbuf[3] == '<')
                    {
                        int len = (ringbuf[12] << 24)
                            + (ringbuf[13] << 16)
                            + (ringbuf[14] << 8)
                            + (ringbuf[15]);
                        if (ringbuf.Count >= len)
                        {
                            Socket client = ringbuf.Tag as Socket;
                            if (client == null)
                                break;
                            byte[] ServerSocketBuffer = new byte[len + Marshal.SizeOf(typeof(HEAD))];
                            ringbuf.Read(ServerSocketBuffer, 0, len + Marshal.SizeOf(typeof(HEAD)));
                            IntPtr pdata = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(HEAD)));
                            Marshal.Copy(ServerSocketBuffer, 0, pdata, Marshal.SizeOf(typeof(HEAD)));
                            HEAD hd = (HEAD)Marshal.PtrToStructure(pdata, typeof(HEAD));
                            hd.CommandId = (uint)System.Net.IPAddress.NetworkToHostOrder((int)hd.CommandId);

                            if (!CheckCRC(ServerSocketBuffer))
                            {
                                return;
                            }


                            byte[] body = new byte[len];
                            Array.Copy(ServerSocketBuffer, Marshal.SizeOf(typeof(HEAD)), body, 0, len);
                            switch ((EnumProtocolType)hd.CommandId)
                            {
                                case EnumProtocolType.SEND_HEARTBEAT:
                                    OnReceiveData_HEARTBEAT(client, body);
                                    break;
                                case EnumProtocolType.NOTE_UPLOAD_PLATE_DATA:
                                    OnReceiveData_NOTE_UPLOAD_PLATE_DATA(client, body);
                                    break;
                                case EnumProtocolType.NOTE_UPLOAD_TRAFFIC_EVENT:
                                    OnReceiveData_NOTE_UPLOAD_TRAFFIC_EVENT(client, body);
                                    break;
                                case EnumProtocolType.NOTE_UPLOAD_TRAFFIC_PARAM:
                                    OnReceiveData_NOTE_UPLOAD_TRAFFIC_PARAM(client, body);
                                    break;
                                case EnumProtocolType.NOTE_UPLOAD_BEHAVIOR_EVENT:
                                    OnReceiveData_NOTE_UPLOAD_BEHAVIOR_EVENT(client, body);
                                    break;
                                case EnumProtocolType.NOTE_UPLOAD_FACECONTROL_EVENT:
                                    OnReceiveData_NOTE_UPLOAD_FACECONTROL_EVENT(client, body);
                                    break;
                                case EnumProtocolType.NOTE_UPLOAD_MOVEOBJINFO_DATA:
                                    OnReceiveData_NOTE_UPLOAD_MOVEOBJINFO_DATA(client, body);
                                    break;
                                case EnumProtocolType.NOTE_UPLOAD_MOVEFEATURE_DATA:
                                    OnReceiveData_NOTE_UPLOAD_MOVEFEATURE_DATA(client, body);
                                    break;
                                case EnumProtocolType.NOTE_UPLOAD_COLORFEATURE_DATA:
                                    OnReceiveData_NOTE_UPLOAD_COLORFEATURE_DATA(client, body);
                                    break;
                                case EnumProtocolType.NOTE_UPLOAD_SCENEMARK_DATA:
                                    OnReceiveData_NOTE_UPLOAD_SCENEMARK_DATA(client, body);
                                    break;
                                case EnumProtocolType.NOTE_UPLOAD_CROWD_DATA:
                                    OnReceiveData_NOTE_UPLOAD_CROWD_DATA(client, body);
                                    break;
                                case EnumProtocolType.NOTE_UPLOAD_PEOPLECOUNT_DATA:
                                    OnReceiveData_NOTE_UPLOAD_PEOPLECOUNT_DATA(client, body);
                                    break;
                                case EnumProtocolType.NOTE_UPLOAD_PEOPLECOUNTALARM_EVENT:
                                    OnReceiveData_NOTE_UPLOAD_PEOPLECOUNTALARM_EVENT(client, body);
                                    break;
                                case EnumProtocolType.NOTE_IMAGE_SEARCH_DATA:
                                    OnReceiveData_NOTE_IMAGE_SEARCH_DATA(client, body);
                                    break;
                                case EnumProtocolType.NOTE_TRAFFIC_FEATURE_PARAM_DATA:
                                    OnReceiveData_NOTE_TRAFFIC_FEATURE_PARAM_DATA(client, body);
                                    break;
                                case EnumProtocolType.NOTE_IMAGE_SEARCH_STD_DATA:
                                    OnReceiveData_NOTE_IMAGE_SEARCH_STD_DATA(client, body);
                                    break;
                                case EnumProtocolType.NOTE_UPLOAD_MOVEOBJECT_PEOPLE_PUDONG_DATA:
                                    OnReceiveData_NOTE_UPLOAD_MOVEOBJECT_PEOPLE_PUDONG_DATA(client, body);
                                    break;
                                case EnumProtocolType.NOTE_UPLOAD_MOVEOBJECT_VEHICLE_PUDONG_DATA:
                                    OnReceiveData_NOTE_UPLOAD_MOVEOBJECT_VEHICLE_PUDONG_DATA(client, body);
                                    break;
                                case EnumProtocolType.TIMEOUT:
                                    break;
                                default:
                                    break;
                            }
                            System.Threading.Thread.Sleep(50);
                        }
                        else
                        {
                            System.Threading.Thread.Sleep(100);
                        }
                    }
                    else
                    {
                        ringbuf.ReadByte();
                    }
                }
                else
                {
                    System.Threading.Thread.Sleep(100);
                }
            }
        }


        private void OnReceiveData_HEARTBEAT(Socket socket, byte[] data)
        {
            Send(socket, new tACK_HEARTBEAT(), typeof(tACK_HEARTBEAT), EnumProtocolType.ACK_HEARTBEAT);
        }
        private void OnReceiveData_NOTE_UPLOAD_CROWD_DATA(Socket socket, byte[] data)
        {
            NOTE_UPLOAD_CROWD_DATA obj = new NOTE_UPLOAD_CROWD_DATA();
            obj.CameraCode = ToString(ref data, 0, 64);
            obj.TimeSec = DataModel.Common.ZEROTIME.AddSeconds(ToUInt32(ref data));
            uint PseudHotImgBufferSize = ToUInt32(ref data);
            obj.PseudHotImg = ToImage(ref data, 0, (int)PseudHotImgBufferSize);
            uint CrowdDirectionMapImgBufferSize = ToUInt32(ref data);
            obj.CrowdDirectionMapImg = ToImage(ref data, 0, (int)CrowdDirectionMapImgBufferSize);
            uint OriginalImgBufferSize = ToUInt32(ref data);
            obj.OriginalImg = ToImage(ref data, 0, (int)OriginalImgBufferSize);

            obj.PeopleCount = ToUInt32(ref data);
            obj.Area = ToUInt32(ref data);
            uint CrowdDetectRegionPointNum = ToUInt32(ref data);

            obj.CrowdDetectRegion = new List<System.Drawing.Point>();
            for (int i = 0; i < CrowdDetectRegionPointNum; i++)
            {
                uint CrowdDetectRegionPointX = ToUInt32(ref data);
                uint CrowdDetectRegionPointY = ToUInt32(ref data);
                obj.CrowdDetectRegion.Add(new System.Drawing.Point((int)CrowdDetectRegionPointX, (int)CrowdDetectRegionPointY));
            }
            obj.Reserved = ToCharArray(ref data, 0, 32);

            if (OnReceiveNOTE_UPLOAD_CROWD_DATA != null)
                OnReceiveNOTE_UPLOAD_CROWD_DATA(this, obj);
        }
        private void OnReceiveData_NOTE_UPLOAD_FACECONTROL_EVENT(Socket socket, byte[] data)
        {
            NOTE_UPLOAD_FACECONTROL_EVENT obj = new NOTE_UPLOAD_FACECONTROL_EVENT();
            obj.CameraCode = ToString(ref data, 0, 64);
            obj.ObjectId = ToUInt32(ref data);
            uint StartTimeSec = ToUInt32(ref data);
            uint StartTimeMilliSec = ToUInt32(ref data);
            obj.StartTime = DataModel.Common.ZEROTIME.AddSeconds(StartTimeSec).AddMilliseconds(StartTimeMilliSec);
            uint EndTimeSec = ToUInt32(ref data);
            uint EndTimeMilliSec = ToUInt32(ref data);
            obj.EndTime = DataModel.Common.ZEROTIME.AddSeconds(EndTimeSec).AddMilliseconds(EndTimeMilliSec);
            uint EventObjCoordX = ToUInt32(ref data);
            uint EventObjCoordY = ToUInt32(ref data);
            uint EventObjWidth = ToUInt32(ref data);
            uint EventObjHeight = ToUInt32(ref data);
            obj.EventObjRect = new System.Drawing.Rectangle((int)EventObjCoordX, (int)EventObjCoordY, (int)EventObjWidth, (int)EventObjHeight);
            uint ImageBufferSize = ToUInt32(ref data);
            obj.Image = ToImage(ref data, 0, (int)ImageBufferSize);
            obj.Reserved = ToCharArray(ref data, 0, 32);

            if (OnReceiveNOTE_UPLOAD_FACECONTROL_EVENT != null)
                OnReceiveNOTE_UPLOAD_FACECONTROL_EVENT(this, obj);
        }
        private void OnReceiveData_NOTE_UPLOAD_PEOPLECOUNT_DATA(Socket socket, byte[] data)
        {
            NOTE_UPLOAD_PEOPLECOUNT_DATA obj = new NOTE_UPLOAD_PEOPLECOUNT_DATA();
            obj.CameraCode = ToString(ref data, 0, 64);
            obj.DetectRegionID = ToUInt32(ref data);
            obj.BehaviorType = ToUInt32(ref data);
            obj.ObjectTotalNum = ToUInt32(ref data);


            if (OnReceiveNOTE_UPLOAD_PEOPLECOUNT_DATA != null)
                OnReceiveNOTE_UPLOAD_PEOPLECOUNT_DATA(this, obj);
        }
        private void OnReceiveData_NOTE_UPLOAD_PEOPLECOUNTALARM_EVENT(Socket socket, byte[] data)
        {
            NOTE_UPLOAD_PEOPLECOUNTALARM_EVENT obj = new NOTE_UPLOAD_PEOPLECOUNTALARM_EVENT();
            obj.CameraCode = ToString(ref data, 0, 64);
            obj.DetectRegionID = ToUInt32(ref data);
            obj.BehaviorType = ToUInt32(ref data);
            obj.ObjectTotalNum = ToUInt32(ref data);
            obj.TimeStamp = DateTime.Now;

            if (OnReceiveNOTE_UPLOAD_PEOPLECOUNTALARM_EVENT != null)
                OnReceiveNOTE_UPLOAD_PEOPLECOUNTALARM_EVENT(this, obj);
        }
        private void OnReceiveData_NOTE_UPLOAD_MOVEOBJINFO_DATA(Socket socket, byte[] data)
        {
            NOTE_UPLOAD_MOVEOBJINFO_DATA obj = new NOTE_UPLOAD_MOVEOBJINFO_DATA();
            obj.CameraCode = ToString(ref data, 0, 64);
            obj.ObjectId = ToUInt32(ref data);
            obj.ObjType = ToUInt32(ref data);
            obj.BeginTime = DataModel.Common.ZEROTIME.AddMilliseconds(ToUInt64(ref data));
            obj.EndTime = DataModel.Common.ZEROTIME.AddMilliseconds(ToUInt64(ref data));
            uint TrailPointNum = ToUInt32(ref data);

            for (int i = 0; i < TrailPointNum; i++)
            {
                uint TrailPointFrameSeq = ToUInt32(ref data);
                uint TrailPointTimeStam = ToUInt32(ref data);
                ulong TrailPointTs = ToUInt64(ref data);
                uint TrailPointObjX = ToUInt32(ref data);
                uint TrailPointObjY = ToUInt32(ref data);
                uint TrailPointObjWidth = ToUInt32(ref data);
                uint TrailPointObjHeight = ToUInt32(ref data);
            }

            uint ImageNum = ToUInt32(ref data);
            obj.TrailPointList = new List<TrailPointInfo>();
            for (int i = 0; i < ImageNum; i++)
            {
                TrailPointInfo img = new TrailPointInfo();
                img.Time = DataModel.Common.ZEROTIME.AddMilliseconds(ToUInt64(ref data));
                img.FrameSeq = ToUInt32(ref data);
                img.TimeStam = ToUInt32(ref data);
                uint ImgObjX = ToUInt32(ref data);
                uint ImgObjY = ToUInt32(ref data);
                uint ImgObjWidth = ToUInt32(ref data);
                uint ImgObjHeight = ToUInt32(ref data);
                img.ImgObjRect = new System.Drawing.Rectangle((int)ImgObjX, (int)ImgObjY, (int)ImgObjWidth, (int)ImgObjHeight);
                uint OriImgBufferSize = ToUInt32(ref data);
                img.OriImg = ToImage(ref data, 0, (int)OriImgBufferSize);
                uint ThumbImgBufferSize = ToUInt32(ref data);
                img.ThumbImg = ToImage(ref data, 0, (int)ThumbImgBufferSize);
                obj.TrailPointList.Add(img);
            }
            obj.Reserved = ToCharArray(ref data, 0, 32);

            if (OnReceiveNOTE_UPLOAD_MOVEOBJINFO_DATA != null)
                OnReceiveNOTE_UPLOAD_MOVEOBJINFO_DATA(this, obj);
        }
        private void OnReceiveData_NOTE_UPLOAD_MOVEFEATURE_DATA(Socket socket, byte[] data)
        {
            NOTE_UPLOAD_MOVEFEATURE_DATA obj = new NOTE_UPLOAD_MOVEFEATURE_DATA();
            obj.CameraCode = ToString(ref data, 0, 64);
            obj.ObjectId = ToUInt32(ref data);
            obj.ObjType = ToUInt32(ref data);
            obj.BeginTime = DataModel.Common.ZEROTIME.AddMilliseconds(ToUInt64(ref data));
            obj.EndTime = DataModel.Common.ZEROTIME.AddMilliseconds(ToUInt64(ref data));
            uint ImageNum = ToUInt32(ref data);
            obj.BlobSurfList = new List<BlobSurfInfo>();
            for (int i = 0; i < ImageNum; i++)
            {
                BlobSurfInfo img = new BlobSurfInfo();
                uint BlobBufferSize = ToUInt32(ref data);
                img.BlobBuffer = ToCharArray(ref data, 0, (int)BlobBufferSize);
                uint SurfBufferSize = ToUInt32(ref data);
                img.SurfBuffer = ToCharArray(ref data, 0, (int)SurfBufferSize);
                obj.BlobSurfList.Add(img);
            }
            obj.Reserved = ToCharArray(ref data, 0, 32);

            if (OnReceiveNOTE_UPLOAD_MOVEFEATURE_DATA != null)
                OnReceiveNOTE_UPLOAD_MOVEFEATURE_DATA(this, obj);
        }
        private void OnReceiveData_NOTE_UPLOAD_COLORFEATURE_DATA(Socket socket, byte[] data)
        {
            NOTE_UPLOAD_COLORFEATURE_DATA obj = new NOTE_UPLOAD_COLORFEATURE_DATA();
            obj.CameraCode = ToString(ref data, 0, 64);
            obj.BeginTime = DataModel.Common.ZEROTIME.AddSeconds(ToUInt32(ref data));
            obj.EndTime = DataModel.Common.ZEROTIME.AddSeconds(ToUInt32(ref data));
            obj.BlackCount = ToUInt32(ref data);
            obj.WhiteCount = ToUInt32(ref data);
            obj.UsedFrames = ToUInt32(ref data);
            obj.Reserved = ToCharArray(ref data, 0, 32);

            if (OnReceiveNOTE_UPLOAD_COLORFEATURE_DATA != null)
                OnReceiveNOTE_UPLOAD_COLORFEATURE_DATA(this, obj);
        }
        private void OnReceiveData_NOTE_UPLOAD_SCENEMARK_DATA(Socket socket, byte[] data)
        {
            NOTE_UPLOAD_SCENEMARK_DATA obj = new NOTE_UPLOAD_SCENEMARK_DATA();
            obj.CameraCode = ToString(ref data, 0, 64);
            obj.BeginTime = DataModel.Common.ZEROTIME.AddSeconds(ToUInt32(ref data));
            obj.EndTime = DataModel.Common.ZEROTIME.AddSeconds(ToUInt32(ref data));
            uint ImageWidth = ToUInt32(ref data);
            uint ImageHeight = ToUInt32(ref data);
            obj.ImgSize = new System.Drawing.Size((int)ImageWidth, (int)ImageHeight);
            uint FarRectX = ToUInt32(ref data);
            uint FarRectY = ToUInt32(ref data);
            uint FarRectWidth = ToUInt32(ref data);
            uint FarRectHeight = ToUInt32(ref data);
            obj.FarRect = new System.Drawing.Rectangle((int)FarRectX, (int)FarRectY, (int)FarRectWidth, (int)FarRectHeight);
            uint NearRectX = ToUInt32(ref data);
            uint NearRectY = ToUInt32(ref data);
            uint NearRectWidth = ToUInt32(ref data);
            uint NearRectHeight = ToUInt32(ref data);
            obj.NearRect = new System.Drawing.Rectangle((int)NearRectX, (int)NearRectY, (int)NearRectWidth, (int)NearRectHeight);
            obj.Reserved = ToCharArray(ref data, 0, 32);

            if (OnReceiveNOTE_UPLOAD_SCENEMARK_DATA != null)
                OnReceiveNOTE_UPLOAD_SCENEMARK_DATA(this, obj);
        }
        private void OnReceiveData_NOTE_UPLOAD_PLATE_DATA(Socket socket, byte[] data)
        {
            NOTE_UPLOAD_PLATE_DATA obj = new NOTE_UPLOAD_PLATE_DATA();
            obj.CameraCode = ToString(ref data, 0, 64);
            uint TimeStampSec = ToUInt32(ref data);
            uint TimeStampMilliSec = ToUInt32(ref data);
            obj.TimeStamp = DataModel.Common.ZEROTIME.AddSeconds(TimeStampSec).AddMilliseconds(TimeStampMilliSec);
            obj.ObjectType = ToUInt32(ref data);
            obj.Reliability = ToUInt32(ref data);
            obj.PlateNum = ToString(ref data, 0, 12);
            obj.PlateNumRow = ToUInt32(ref data);
            obj.PlateColor = ToUInt32(ref data);
            obj.VehicleColor = ToUInt32(ref data);
            obj.VehicleType = ToUInt32(ref data);
            obj.VehicleTypeDetail = ToUInt32(ref data);
            obj.VehicleLabel = ToUInt32(ref data);
            obj.VehicleLabelDetail = ToUInt32(ref data);
            obj.VehicleSpeed = ToUInt32(ref data);
            obj.Direction = ToUInt32(ref data);
            obj.RoadWayNum = ToUInt32(ref data);
            uint PlateCoordX = ToUInt32(ref data);
            uint PlateCoordY = ToUInt32(ref data);
            uint PlateCoordWidth = ToUInt32(ref data);
            uint PlateCoordHeight = ToUInt32(ref data);
            obj.PlateCoordRect = new System.Drawing.Rectangle((int)PlateCoordX, (int)PlateCoordY, (int)PlateCoordWidth, (int)PlateCoordHeight);
            uint PlateImgSize = ToUInt32(ref data);
            obj.PlateImgData = ToImage(ref data, 0, (int)PlateImgSize);
            uint VehiBodyCoordX = ToUInt32(ref data);
            uint VehiBodyCoordY = ToUInt32(ref data);
            uint VehiBodyCoordWidth = ToUInt32(ref data);
            uint VehiBodyCoordHeight = ToUInt32(ref data);
            obj.VehiBodyCoordRect = new System.Drawing.Rectangle((int)VehiBodyCoordX, (int)VehiBodyCoordY, (int)VehiBodyCoordWidth, (int)VehiBodyCoordHeight);
            uint VehiBodyImgSize = ToUInt32(ref data);
            obj.VehiBodyImgData = ToImage(ref data, 0, (int)VehiBodyImgSize);
            uint FullImgWidth = ToUInt32(ref data);
            uint FullImgHeight = ToUInt32(ref data);
            obj.FullImgSize = new System.Drawing.Size((int)FullImgWidth, (int)FullImgHeight);
            uint FullImgSize = ToUInt32(ref data);
            obj.FullImgData = ToImage(ref data, 0, (int)FullImgSize);
            uint ComposeImgWidth = ToUInt32(ref data);
            uint ComposeImgHeight = ToUInt32(ref data);
            obj.ComposeImgSize = new System.Drawing.Size((int)ComposeImgWidth, (int)ComposeImgHeight);
            uint ComposeImgSize = ToUInt32(ref data);
            obj.ComposeImgData = ToImage(ref data, 0, (int)ComposeImgSize);
            obj.Reserved = ToCharArray(ref data, 0, 32);

            if (OnReceiveNOTE_UPLOAD_PLATE_DATA != null)
                OnReceiveNOTE_UPLOAD_PLATE_DATA(this, obj);
        }
        private void OnReceiveData_NOTE_UPLOAD_TRAFFIC_EVENT(Socket socket, byte[] data)
        {
            NOTE_UPLOAD_TRAFFIC_EVENT obj = new NOTE_UPLOAD_TRAFFIC_EVENT();
            obj.CameraCode = ToString(ref data, 0, 64);
            obj.EventType = ToUInt32(ref data);
            uint StartTimeSec = ToUInt32(ref data);
            uint StartTimeMilliSec = ToUInt32(ref data);
            obj.StartTime = DataModel.Common.ZEROTIME.AddSeconds(StartTimeSec).AddMilliseconds(StartTimeMilliSec);
            uint EndTimeSec = ToUInt32(ref data);
            uint EndTimeMilliSec = ToUInt32(ref data);
            obj.EndTime = DataModel.Common.ZEROTIME.AddSeconds(EndTimeSec).AddMilliseconds(EndTimeMilliSec);
            obj.ObjRoadWayNum = ToUInt32(ref data);
            uint EventImgSum = ToUInt32(ref data);
            obj.EventImgInfo = new List<EventImgInfo>();
            for (int i = 0; i < EventImgSum; i++)
            {
                EventImgInfo info = new EventImgInfo();
                uint EventObjCoordX = ToUInt32(ref data);
                uint EventObjCoordY = ToUInt32(ref data);
                uint EventObjWidth = ToUInt32(ref data);
                uint EventObjHeight = ToUInt32(ref data);
                info.EventObjRect = new System.Drawing.Rectangle((int)EventObjCoordX, (int)EventObjCoordY, (int)EventObjWidth, (int)EventObjHeight);
                uint EventImgSize = ToUInt32(ref data);
                info.EventImgData = ToImageStream(ref data, 0, (int)EventImgSize);
                obj.EventImgInfo.Add(info);
            }
            uint ComposeImgSize = ToUInt32(ref data);
            obj.ComposeImg = ToImageStream(ref data, 0, (int)ComposeImgSize);
            obj.EventVideoUrl = ToString(ref data, 0, 256);
            obj.Reliability = ToUInt32(ref data);
            obj.PlateNum = ToString(ref data, 0, 12);
            obj.PlateNumRow = ToUInt32(ref data);
            obj.PlateColor = ToUInt32(ref data);
            obj.VehicleColor = ToUInt32(ref data);
            obj.VehicleType = ToUInt32(ref data);
            obj.VehicleTypeDetail = ToUInt32(ref data);
            obj.VehicleLabel = ToUInt32(ref data);
            obj.VehicleLabelDetail = ToUInt32(ref data);
            obj.VehicleSpeed = ToUInt32(ref data);
            obj.Direction = ToUInt32(ref data);
            uint ReserveDataLen = ToUInt32(ref data);
            obj.Reserved = ToCharArray(ref data, 0, (int)ReserveDataLen);

            if (OnReceiveNOTE_UPLOAD_TRAFFIC_EVENT != null)
                OnReceiveNOTE_UPLOAD_TRAFFIC_EVENT(this, obj);
        }
        private void OnReceiveData_NOTE_UPLOAD_TRAFFIC_PARAM(Socket socket, byte[] data)
        {
            NOTE_UPLOAD_TRAFFIC_PARAM obj = new NOTE_UPLOAD_TRAFFIC_PARAM();
            obj.CameraCode = ToString(ref data, 0, 64);
            uint TimeSec = ToUInt32(ref data);
            obj.StatiIctisTime = DataModel.Common.ZEROTIME.AddSeconds(TimeSec);
            obj.RoadWayNum = ToUInt32(ref data);
            obj.TrafficFluxBig = ToUInt32(ref data);
            obj.TrafficFluxMiddle = ToUInt32(ref data);
            obj.TrafficFluxSmall = ToUInt32(ref data);
            obj.TrafficFluxUnMotor = ToUInt32(ref data);
            obj.TrafficFluxPerson = ToUInt32(ref data);
            obj.TrafficFlux = ToUInt32(ref data);
            obj.AvgVehiSpeed = ToUInt32(ref data);
            obj.AvgOccupyRatio = ToUInt32(ref data);
            obj.QueueLen = ToUInt32(ref data);
            obj.AvgVehiDistance = ToUInt32(ref data);
            obj.Reserved = ToCharArray(ref data, 0, 32);

            if (OnReceiveNOTE_UPLOAD_TRAFFIC_PARAM != null)
                OnReceiveNOTE_UPLOAD_TRAFFIC_PARAM(this, obj);
        }
        private void OnReceiveData_NOTE_UPLOAD_BEHAVIOR_EVENT(Socket socket, byte[] data)
        {
            NOTE_UPLOAD_BEHAVIOR_EVENT obj = new NOTE_UPLOAD_BEHAVIOR_EVENT();
            obj.CameraCode = ToString(ref data, 0, 64);
            obj.ObjectId = ToUInt32(ref data);
            obj.EventType = ToUInt32(ref data);
            uint StartTimeSec = ToUInt32(ref data);
            uint StartTimeMilliSec = ToUInt32(ref data);
            obj.StartTime = DataModel.Common.ZEROTIME.AddSeconds(StartTimeSec).AddMilliseconds(StartTimeMilliSec);
            uint EndTimeSec = ToUInt32(ref data);
            uint EndTimeMilliSec = ToUInt32(ref data);
            obj.EndTime = DataModel.Common.ZEROTIME.AddSeconds(EndTimeSec).AddMilliseconds(EndTimeMilliSec);
            uint EventObjCoordX = ToUInt32(ref data);
            uint EventObjCoordY = ToUInt32(ref data);
            uint EventObjWidth = ToUInt32(ref data);
            uint EventObjHeight = ToUInt32(ref data);
            obj.EventObjRect = new System.Drawing.Rectangle((int)EventObjCoordX, (int)EventObjCoordY, (int)EventObjWidth, (int)EventObjHeight);

            obj.ObjType = ToUInt32(ref data);
            obj.ObjNum = ToUInt32(ref data);
            uint ImageBufferSize = ToUInt32(ref data);
            obj.Image = ToImageStream(ref data, 0, (int)ImageBufferSize);
            obj.EventVideoUrl = ToString(ref data, 0, 256);
            obj.Reserved = ToCharArray(ref data, 0, 32);

            if (OnReceiveNOTE_UPLOAD_BEHAVIOR_EVENT != null)
                OnReceiveNOTE_UPLOAD_BEHAVIOR_EVENT(this, obj);
        }
        private void OnReceiveData_NOTE_IMAGE_SEARCH_DATA(Socket socket, byte[] data)
        {
            NOTE_IMAGE_SEARCH_DATA obj = new NOTE_IMAGE_SEARCH_DATA();
            obj.CameraCode = ToString(ref data, 0, 64);
            obj.SeqNum = ToUInt64(ref data);
            obj.CrossroadId = ToUInt64(ref data);
            obj.DirectionId = ToUInt64(ref data);
            obj.Time = DataModel.Common.ZEROTIME.AddMilliseconds(ToUInt64(ref data));
            uint EventObjCoordX = ToUInt32(ref data);
            uint EventObjCoordY = ToUInt32(ref data);
            uint EventObjWidth = ToUInt32(ref data);
            uint EventObjHeight = ToUInt32(ref data);
            obj.Rect = new System.Drawing.Rectangle((int)EventObjCoordX, (int)EventObjCoordY, (int)EventObjWidth, (int)EventObjHeight);
            uint FeartureSize = ToUInt32(ref data);
            obj.FeartureBuffer = ToCharArray(ref data, 0, (int)FeartureSize);
            uint ImageBufferSize = ToUInt32(ref data);
            obj.Image = ToImage(ref data, 0, (int)ImageBufferSize);
            obj.Reserved = ToCharArray(ref data, 0, 32);

            if (OnReceiveNOTE_IMAGE_SEARCH_DATA != null)
                OnReceiveNOTE_IMAGE_SEARCH_DATA(this, obj);
        }
        private void OnReceiveData_NOTE_TRAFFIC_FEATURE_PARAM_DATA(Socket socket, byte[] data)
        {
            NOTE_TRAFFIC_FEATURE_PARAM_DATA obj = new NOTE_TRAFFIC_FEATURE_PARAM_DATA();
            obj.CameraCode = ToString(ref data, 0, 64);
            obj.MoveObjId = ToUInt32(ref data);
            obj.ObjectType = ToUInt32(ref data);
            uint StartTimeSec = ToUInt32(ref data);
            uint StartTimeMilliSec = ToUInt32(ref data);
            obj.TimeStamp = DataModel.Common.ZEROTIME.AddSeconds(StartTimeSec).AddMilliseconds(StartTimeMilliSec);

            uint RectX = ToUInt32(ref data);
            uint RectY = ToUInt32(ref data);
            uint RectWidth = ToUInt32(ref data);
            uint RectHeight = ToUInt32(ref data);
            obj.Rect = new System.Drawing.Rectangle((int)RectX, (int)RectY, (int)RectWidth, (int)RectHeight);
            uint ImageBufferSize = ToUInt32(ref data);
            obj.Image = ToImage(ref data, 0, (int)ImageBufferSize);
            uint ThumbImageSize = ToUInt32(ref data);
            obj.ThumbImage = ToImage(ref data, 0, (int)ThumbImageSize);
            uint FeartureSize = ToUInt32(ref data);
            obj.FeartureBuffer = ToCharArray(ref data, 0, (int)FeartureSize);
            obj.Reliability = ToUInt32(ref data);
            obj.PlateNum = ToString(ref data, 0, 12);
            obj.PlateNumRow = ToUInt32(ref data);
            obj.PlateColor = ToUInt32(ref data);
            obj.VehicleColor = ToUInt32(ref data);
            obj.VehicleType = ToUInt32(ref data);
            obj.VehicleTypeDetail = ToUInt32(ref data);
            obj.VehicleLabel = ToUInt32(ref data);
            obj.VehicleLabelDetail = ToUInt32(ref data);
            obj.VehicleSpeed = ToUInt32(ref data);
            obj.Direction = ToUInt32(ref data);
            obj.RoadWayNum = ToUInt32(ref data);
            uint PlateCoordX = ToUInt32(ref data);
            uint PlateCoordY = ToUInt32(ref data);
            uint PlateCoordWidth = ToUInt32(ref data);
            uint PlateCoordHeight = ToUInt32(ref data);
            obj.PlateCoordRect = new System.Drawing.Rectangle((int)PlateCoordX, (int)PlateCoordY, (int)PlateCoordWidth, (int)PlateCoordHeight);

            obj.Reserved = ToCharArray(ref data, 0, 32);

            if (OnReceiveNOTE_TRAFFIC_FEATURE_PARAM_DATA != null)
                OnReceiveNOTE_TRAFFIC_FEATURE_PARAM_DATA(this, obj);
        }
        private void OnReceiveData_NOTE_IMAGE_SEARCH_STD_DATA(Socket socket, byte[] data)
        {
            NOTE_IMAGE_SEARCH_STD_DATA obj = new NOTE_IMAGE_SEARCH_STD_DATA();
            obj.CameraCode = ToString(ref data, 0, 64);

            if (OnReceiveNOTE_IMAGE_SEARCH_STD_DATA != null)
                OnReceiveNOTE_IMAGE_SEARCH_STD_DATA(this, null);
        }
        private void OnReceiveData_NOTE_UPLOAD_MOVEOBJECT_PEOPLE_PUDONG_DATA(Socket socket, byte[] data)
        {
            NOTE_UPLOAD_MOVEOBJECT_PEOPLE_PUDONG_DATA obj = new NOTE_UPLOAD_MOVEOBJECT_PEOPLE_PUDONG_DATA();
            obj.CameraCode = ToString(ref data, 0, 64);

            if (OnReceiveNOTE_UPLOAD_MOVEOBJECT_PEOPLE_PUDONG_DATA != null)
                OnReceiveNOTE_UPLOAD_MOVEOBJECT_PEOPLE_PUDONG_DATA(this, null);
        }
        private void OnReceiveData_NOTE_UPLOAD_MOVEOBJECT_VEHICLE_PUDONG_DATA(Socket socket, byte[] data)
        {
            NOTE_UPLOAD_MOVEOBJECT_VEHICLE_PUDONG_DATA obj = new NOTE_UPLOAD_MOVEOBJECT_VEHICLE_PUDONG_DATA();
            obj.CameraCode = ToString(ref data, 0, 64);
            obj.ObjId = ToUInt32(ref data);
            obj.ObjType = ToUInt32(ref data);
            ulong BeginTimeMilliSec = ToUInt64(ref data);
            obj.BeginTimeMilliSec = DataModel.Common.ZEROTIME.AddMilliseconds(BeginTimeMilliSec);
            ulong EndTimeMilliSec = ToUInt64(ref data);
            obj.EndTimeMilliSec = DataModel.Common.ZEROTIME.AddMilliseconds(EndTimeMilliSec);
            obj.FeatureVersion = ToString(ref data, 0, 32);
            obj.PlateNum = ToString(ref data, 0, 12);
            obj.PlateReliability = ToUInt32(ref data);
            obj.PlateColor = ToUInt32(ref data);
            obj.PlateNumRow = ToUInt32(ref data);
            obj.VehicleLabel = ToUInt32(ref data);
            obj.VehicleLabelDetail = ToUInt32(ref data);
            obj.VehicleType = ToUInt32(ref data);
            obj.VehicleTypeDetail = ToUInt32(ref data);
            uint ColorNum = ToUInt32(ref data);
            obj.VehicleColorInfo = new List<VehicleColorInfo>();
            for (int i = 0; i < ColorNum; i++)
            {
                VehicleColorInfo info = new VehicleColorInfo();
                info.VehicleColor =  ToUInt32(ref data);
                info.VehicleColourConf =  ToUInt32(ref data);
                obj.VehicleColorInfo.Add(info);
            }
            obj.DriverIsPhoneing = ToUInt32(ref data);
            obj.DriverIsPhoneingConf = ToUInt32(ref data);
            obj.DriverIsSafebelt = ToUInt32(ref data);
            obj.DriverIsSafebeltConf = ToUInt32(ref data);
            obj.PassengerIsSafebelt = ToUInt32(ref data);
            obj.PassengerIsSafebeltCof = ToUInt32(ref data);
            obj.DriverIsSunVisor = ToUInt32(ref data);
            obj.DriverIsSunVisorConf = ToUInt32(ref data);
            obj.PassengerIsSunVisor = ToUInt32(ref data);
            obj.PassengerIsSunVisorConf = ToUInt32(ref data);
            int DriverRectX = (int)ToUInt32(ref data);
            int DriverRectY = (int)ToUInt32(ref data);
            int DriverRectWidth = (int)ToUInt32(ref data);
            int DriverRectHeight = (int)ToUInt32(ref data);
            obj.DriverRect = new System.Drawing.Rectangle(DriverRectX, DriverRectY, DriverRectWidth, DriverRectHeight);
            int PassengerRectX = (int)ToUInt32(ref data);
            int PassengerRectY = (int)ToUInt32(ref data);
            int PassengerRectWidth = (int)ToUInt32(ref data);
            int PassengerRectHeight = (int)ToUInt32(ref data);
            obj.PassengerRect = new System.Drawing.Rectangle(PassengerRectX, PassengerRectY, PassengerRectWidth, PassengerRectHeight);
            uint GlobalFeartureSize = ToUInt32(ref data);
            obj.GlobalFearture = ToCharArray(ref data, 0, (int)GlobalFeartureSize);
            uint RegionFeartureSize = ToUInt32(ref data);
            obj.RegionFearture = ToCharArray(ref data, 0, (int)RegionFeartureSize);
            uint TrailPointNum = ToUInt32(ref data);
            obj.TrailInfo = new List<TrailInfo>();
            for (int i = 0; i < TrailPointNum; i++)
            {
                TrailInfo info = new TrailInfo();
                info.TrailTs = ToUInt64(ref data);
                info.TrailFrameSeq = ToUInt32(ref data);
                ulong TrailTimeStamp = ToUInt64(ref data);
                info.TrailTimeStamp = DataModel.Common.ZEROTIME.AddMilliseconds(TrailTimeStamp);
                int TrailObjRectX = (int)ToUInt32(ref data);
                int TrailObjRectY = (int)ToUInt32(ref data);
                int TrailObjRectWidth = (int)ToUInt32(ref data);
                int TrailObjRectHeight = (int)ToUInt32(ref data);
                info.TrailObjRect = new System.Drawing.Rectangle(TrailObjRectX, TrailObjRectY, TrailObjRectWidth, TrailObjRectHeight);
                obj.TrailInfo.Add(info);
            }
            int ObjRectX = (int)ToUInt32(ref data);
            int ObjRectY = (int)ToUInt32(ref data);
            int ObjRectWidth = (int)ToUInt32(ref data);
            int ObjRectHeight = (int)ToUInt32(ref data);
            obj.ObjRect = new System.Drawing.Rectangle(ObjRectX, ObjRectY, ObjRectWidth, ObjRectHeight);
            uint ObjImgBufferSize = ToUInt32(ref data);
            obj.ObjImg = ToImageStream(ref data, 0, (int)ObjImgBufferSize);
            int PlateRectX = (int)ToUInt32(ref data);
            int PlateRectY = (int)ToUInt32(ref data);
            int PlateRectWidth = (int)ToUInt32(ref data);
            int PlateRectHeight = (int)ToUInt32(ref data);
            obj.PlateRect = new System.Drawing.Rectangle(PlateRectX, PlateRectY, PlateRectWidth, PlateRectHeight);
            uint PlateImgBufferSize = ToUInt32(ref data);
            obj.PlateImg = ToImageStream(ref data, 0, (int)PlateImgBufferSize);
            uint ImageUrlLen = ToUInt32(ref data);
            obj.ImageUrl = ToString(ref data, 0, (int)ImageUrlLen);
            uint OriginalImageSize = ToUInt32(ref data);
            obj.OriginalImage = ToImageStream(ref data, 0, (int)OriginalImageSize);
            uint ReserveDataLen = ToUInt32(ref data);
            obj.ReserveData = ToCharArray(ref data, 0, (int)ReserveDataLen);


            if (OnReceiveNOTE_UPLOAD_MOVEOBJECT_VEHICLE_PUDONG_DATA != null)
                OnReceiveNOTE_UPLOAD_MOVEOBJECT_VEHICLE_PUDONG_DATA(this, obj);
        }

        public static uint ToUInt32(ref byte[] data, int index = 0, bool needremove = true)
        {
            uint retval = 0;
            retval += (Convert.ToUInt32(data[index + 0]) << 24);
            retval += (Convert.ToUInt32(data[index + 1]) << 16);
            retval += (Convert.ToUInt32(data[index + 2]) << 8);
            retval += Convert.ToUInt32(data[index + 3]);

            Array.Copy(data, index + 4, data, index, data.Length - 4);
            return retval;
        }
        public static ulong ToUInt64(ref byte[] data, int index = 0, bool needremove = true)
        {
            ulong retval = 0;
            retval += (Convert.ToUInt64(data[index + 0]) << 56);
            retval += (Convert.ToUInt64(data[index + 1]) << 48);
            retval += (Convert.ToUInt64(data[index + 2]) << 40);
            retval += (Convert.ToUInt64(data[index + 3]) << 32);
            retval += (Convert.ToUInt64(data[index + 4]) << 24);
            retval += (Convert.ToUInt64(data[index + 5]) << 16);
            retval += (Convert.ToUInt64(data[index + 6]) << 8);
            retval += Convert.ToUInt64(data[index + 7]);

            Array.Copy(data, index + 8, data, index, data.Length - 8);
            return retval;
        }
        public static string ToString(ref byte[] data, int index, int count, bool needremove = true)
        {
            //StringBuilder sb = new StringBuilder();
            //foreach (var item in data)
            //{
            //    if (item == '\0')
            //        break;
            //    sb.Append((char)item);
            //}
            //Array.Copy(data, index + count, data, index, data.Length - count);
            //char[] dest = new char[sb.Length];
            //sb.CopyTo(0, dest, 0, sb.Length);
            //string ret = System.Text.ASCIIEncoding.Default.GetString(System.Text.UTF8Encoding.Default.GetBytes(dest));
            //return ret;
            int i = 0;
            foreach (var item in data)
            {
                if (item == '\0')
                    break;
                i++;
            }

            byte[] dest = new byte[i];
            Array.Copy(data, dest, i);

            Array.Copy(data, index + count, data, index, data.Length - count);

            //return Encoding.Default.GetString( Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("GBK"), dest));
            return Encoding.Default.GetString(dest);
        }
        public static byte[] ToCharArray(ref byte[] data, int index, int count, bool needremove = true)
        {

            byte[] dest = new byte[count];
            Array.Copy(data, dest, count);

            Array.Copy(data, index + count, data, index, data.Length - count);

            return dest;
        }
        public static System.Drawing.Image ToImage(ref byte[] data, int index, int count, bool needremove = true)
        {
            try
            {
                System.Drawing.Image tmp = IVX.DataModel.Common.GetImage(data, index, count);
                Array.Copy(data, index + count, data, index, data.Length - count);

                return tmp;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ToImage error:" + ex.ToString());
                return null;
            }
        }
        public static System.IO.MemoryStream ToImageStream(ref byte[] data, int index, int count, bool needremove = true)
        {
            try
            {
                byte[] bytes = new byte[count];
                Array.Copy(data, index, bytes, 0, count);

                System.IO.MemoryStream tmp = new System.IO.MemoryStream(bytes);
                Array.Copy(data, index + count, data, index, data.Length - count);

                return tmp;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ToImage error:" + ex.ToString());
                return null;
            }
        }

        void m_tcpManager_OnConnectFail(object sender, TcpClientEventArgs e)
        {
            m_isStarting = false;
            if (OnDisConnected != null)
                OnDisConnected(e.Description, null);
        }

        void m_tcpManager_OnConnectSuccess(object sender, TcpClientEventArgs e)
        {
            if (OnConnected != null)
                OnConnected(e.Description, null);
        }


        private void Send(Socket socket, object st, Type sttype, EnumProtocolType protocoltype)
        {

            IntPtr plogin = Marshal.AllocHGlobal(Marshal.SizeOf(st));
            Marshal.StructureToPtr(st, plogin, false);
            byte[] body = new byte[Marshal.SizeOf(st)];
            Marshal.Copy(plogin, body, 0, Marshal.SizeOf(st));
            Marshal.FreeHGlobal(plogin);

            HEAD hd = CreateHeaderByProtocolType(protocoltype);
            hd.MsgLength = (uint)body.Length;
            hd.MsgLength = (uint)System.Net.IPAddress.HostToNetworkOrder(hd.MsgLength);


            uint crc = 0;
            IntPtr phd = Marshal.AllocHGlobal(Marshal.SizeOf(hd));
            Marshal.StructureToPtr(hd, phd, false);
            byte[] protocol = new byte[Marshal.SizeOf(hd) + body.Length];
            Marshal.Copy(phd, protocol, 0, Marshal.SizeOf(hd));
            Array.Copy(body, 0, protocol, Marshal.SizeOf(hd), body.Length);
            for (int i = 0; i < protocol.Length; i++)
                crc += (uint)protocol[i];
            for (int i = 0; i < body.Length; i++)
                crc += (uint)body[i];

            crc = (uint)System.Net.IPAddress.HostToNetworkOrder(crc);

            protocol[Marshal.SizeOf(hd) - 4] = (byte)((crc >> 24) & 0xff);
            protocol[Marshal.SizeOf(hd) - 3] = (byte)((crc >> 16) & 0xff);
            protocol[Marshal.SizeOf(hd) - 2] = (byte)((crc >> 8) & 0xff);
            protocol[Marshal.SizeOf(hd) - 1] = (byte)(crc & 0xff);
            Marshal.FreeHGlobal(phd);
            socket.Send(protocol);

        }
        /// <summary>
        /// 摘要:依据协议类型,创建包头
        /// </summary>
        /// <param name="ptype">协议类型</param>
        /// <returns>协议包包头</returns>
        private static HEAD CreateHeaderByProtocolType(EnumProtocolType ptype)
        {
            HEAD h = new HEAD();
            h.flag1 = 0x3C;
            h.flag2 = 0x3C;
            h.flag3 = 0x3C;
            h.flag4 = 0x3C;
            h.CommandId = (UInt32)ptype;
            h.Version = 0x01000001;
            h.WorkflowId = unchecked(workflow++);
            h.Reserve = 0;
            h.CheckCode = 0;
            h.MsgLength = 0;

            if (workflow >= 4000000000)
                workflow = 0;


            return h;
        }
        private bool CheckCRC(byte[] data)
        {
            return true;
        }


    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct tACK_HEARTBEAT
    {
    }



    internal class NOTE_UPLOAD_CROWD_DATA
    {
        public string CameraCode { get; set; }
        public DateTime TimeSec { get; set; }
        public System.Drawing.Image PseudHotImg { get; set; }
        public System.Drawing.Image CrowdDirectionMapImg { get; set; }
        public System.Drawing.Image OriginalImg { get; set; }
        public uint PeopleCount { get; set; }
        public uint Area { get; set; }
        public List<System.Drawing.Point> CrowdDetectRegion { get; set; }

        public byte[] Reserved = new byte[32];
    }
    internal class NOTE_UPLOAD_PEOPLECOUNT_DATA
    {
        public string CameraCode { get; set; }
        public uint DetectRegionID { get; set; }
        public uint BehaviorType { get; set; }
        public uint ObjectTotalNum { get; set; }
    }
    internal class NOTE_UPLOAD_BEHAVIOR_EVENT
    {
        public string CameraCode { get; set; }
        public uint ObjectId { get; set; }
        public uint EventType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public System.Drawing.Rectangle EventObjRect { get; set; }
        public uint ObjType { get; set; }
        public uint ObjNum { get; set; }
        public System.IO.MemoryStream Image { get; set; }
        public string EventVideoUrl { get; set; }

        public byte[] Reserved = new byte[32];

    }
    internal class NOTE_UPLOAD_MOVEOBJINFO_DATA
    {
        public string CameraCode { get; set; }
        public uint ObjectId { get; set; }
        public uint ObjType { get; set; }//目标类型,0不确定，1车，2人，3两轮车
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<TrailPointInfo> TrailPointList { get; set; }

        public byte[] Reserved = new byte[32];

    }
    internal class NOTE_UPLOAD_PLATE_DATA
    {
        public string CameraCode { get; set; }
        public DateTime TimeStamp { get; set; }
        public uint ObjectType { get; set; }
        public uint Reliability { get; set; }
        public string PlateNum { get; set; }
        public uint PlateNumRow { get; set; }
        public uint PlateColor { get; set; }
        public uint VehicleColor { get; set; }
        public uint VehicleType { get; set; }
        public uint VehicleTypeDetail { get; set; }
        public uint VehicleLabel { get; set; }
        public uint VehicleLabelDetail { get; set; }
        public uint VehicleSpeed { get; set; }
        public uint Direction { get; set; }
        public uint RoadWayNum { get; set; }
        public System.Drawing.Rectangle PlateCoordRect { get; set; }
        public System.Drawing.Image PlateImgData { get; set; }
        public System.Drawing.Rectangle VehiBodyCoordRect { get; set; }
        public System.Drawing.Image VehiBodyImgData { get; set; }
        public System.Drawing.Size FullImgSize { get; set; }
        public System.Drawing.Image FullImgData { get; set; }
        public System.Drawing.Size ComposeImgSize { get; set; }
        public System.Drawing.Image ComposeImgData { get; set; }

        public byte[] Reserved = new byte[32];


    }
    internal class NOTE_UPLOAD_TRAFFIC_EVENT
    {

        public string CameraCode { get; set; }
        public uint EventType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public uint ObjRoadWayNum { get; set; }
        public List<EventImgInfo> EventImgInfo { get; set; }
        public System.IO.MemoryStream ComposeImg { get; set; }
        public string EventVideoUrl { get; set; }
        public uint Reliability { get; set; }
        public string PlateNum { get; set; }
        public uint PlateNumRow { get; set; }
        public uint PlateColor { get; set; }
        public uint VehicleColor { get; set; }
        public uint VehicleType { get; set; }
        public uint VehicleTypeDetail { get; set; }
        public uint VehicleLabel { get; set; }
        public uint VehicleLabelDetail { get; set; }
        public uint VehicleSpeed { get; set; }
        public uint Direction { get; set; }
        public byte[] Reserved { get; set; }

    }

    internal class EventImgInfo
    {
        public System.Drawing.Rectangle EventObjRect { get; set; }
        public System.IO.MemoryStream EventImgData { get; set; }

    }
    internal class NOTE_UPLOAD_TRAFFIC_PARAM
    {
        public string CameraCode { get; set; }
        public DateTime StatiIctisTime { get; set; }
        public uint RoadWayNum { get; set; }
        public uint TrafficFluxBig { get; set; }
        public uint TrafficFluxMiddle { get; set; }
        public uint TrafficFluxSmall { get; set; }
        public uint TrafficFluxUnMotor { get; set; }
        public uint TrafficFluxPerson { get; set; }
        public uint TrafficFlux { get; set; }
        public uint AvgVehiSpeed { get; set; }
        public uint AvgOccupyRatio { get; set; }
        public uint QueueLen { get; set; }
        public uint AvgVehiDistance { get; set; }
        public byte[] Reserved = new byte[32];

    }
    internal class NOTE_UPLOAD_PEOPLECOUNTALARM_EVENT
    {

        public string CameraCode { get; set; }
        public uint DetectRegionID { get; set; }
        public uint BehaviorType { get; set; }
        public uint ObjectTotalNum { get; set; }
        public DateTime TimeStamp { get; set; }

    }
    internal class NOTE_UPLOAD_FACECONTROL_EVENT
    {
        public string CameraCode { get; set; }
        public uint ObjectId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CurrenTime { get; set; }
        public System.Drawing.Rectangle EventObjRect { get; set; }
        public System.Drawing.Image Image { get; set; }
        public System.Drawing.Image ThumbImage { get; set; }
        public byte[] FaceFeature { get; set; }
        public byte[] Reserved = new byte[32];
    }
    internal class NOTE_UPLOAD_MOVEFEATURE_DATA
    {
        public string CameraCode { get; set; }
        public uint ObjectId { get; set; }
        public uint ObjType { get; set; }//目标类型,0不确定，1车，2人，3两轮车
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<BlobSurfInfo> BlobSurfList { get; set; }
        public byte[] Reserved = new byte[32];
    }
    internal class NOTE_UPLOAD_COLORFEATURE_DATA
    {
        public string CameraCode { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public uint BlackCount { get; set; }
        public uint WhiteCount { get; set; }
        public uint UsedFrames { get; set; }
        public byte[] Reserved = new byte[32];
    }
    internal class NOTE_UPLOAD_SCENEMARK_DATA
    {
        public string CameraCode { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public System.Drawing.Size ImgSize { get; set; }
        public System.Drawing.Rectangle FarRect { get; set; }
        public System.Drawing.Rectangle NearRect { get; set; }
        public byte[] Reserved = new byte[32];

    }
    internal class NOTE_IMAGE_SEARCH_DATA
    {
        public string CameraCode { get; set; }
        public UInt64 SeqNum { get; set; }
        public UInt64 CrossroadId { get; set; }
        public UInt64 DirectionId { get; set; }
        public DateTime Time { get; set; }
        public System.Drawing.Rectangle Rect { get; set; }
        public byte[] FeartureBuffer { get; set; }
        public System.Drawing.Image Image { get; set; }
        public byte[] Reserved = new byte[32];
    }
    internal class NOTE_TRAFFIC_FEATURE_PARAM_DATA
    {
        public string CameraCode { get; set; }
        public uint MoveObjId { get; set; }
        public uint ObjectType { get; set; }
        public DateTime TimeStamp { get; set; }
        public System.Drawing.Rectangle Rect { get; set; }
        public System.Drawing.Image Image { get; set; }
        public System.Drawing.Image ThumbImage { get; set; }
        public byte[] FeartureBuffer { get; set; }
        public uint Reliability { get; set; }
        public string PlateNum { get; set; }
        public uint PlateNumRow { get; set; }
        public uint PlateColor { get; set; }
        public uint VehicleColor { get; set; }
        public uint VehicleType { get; set; }
        public uint VehicleTypeDetail { get; set; }
        public uint VehicleLabel { get; set; }
        public uint VehicleLabelDetail { get; set; }
        public uint VehicleSpeed { get; set; }
        public uint Direction { get; set; }
        public uint RoadWayNum { get; set; }
        public System.Drawing.Rectangle PlateCoordRect { get; set; }

        public byte[] Reserved = new byte[32];



    }

    internal class TrailPointInfo
    {
        public uint FrameSeq { get; set; }
        public uint TimeStam { get; set; }
        public DateTime Time { get; set; }
        public System.Drawing.Rectangle ImgObjRect { get; set; }
        public System.Drawing.Image OriImg { get; set; }
        public System.Drawing.Image ThumbImg { get; set; }
    }
    internal class BlobSurfInfo
    {
        public byte[] BlobBuffer { get; set; }
        public byte[] SurfBuffer { get; set; }
    }

    internal class NOTE_IMAGE_SEARCH_STD_DATA
    {
        public string CameraCode { get; set; }
        public string PicId { get; set; }
        public DateTime PicTime { get; set; }
        public string FeatureVersion { get; set; }
        public List<VehicleInfo> VehicleInfo { get; set; }
        public string ImageUrl { get; set; }
        public System.Drawing.Image Image { get; set; }
        public byte[] ReserveData { get; set; }
    }

    internal class VehicleInfo
    {
        public System.Drawing.Rectangle VehicleRect { get; set; }
        public System.Drawing.Image ThumbImg { get; set; }
        public System.Drawing.Rectangle PlateRect { get; set; }
        public System.Drawing.Image PlateImg { get; set; }
        public uint PlateReliability { get; set; }
        public string PlateNum { get; set; }
        public uint PlateNumRow { get; set; }
        public uint PlateColor { get; set; }
        public uint VehicleColor { get; set; }
        public uint VehicleType { get; set; }
        public uint VehicleTypeDetail { get; set; }
        public uint VehicleLabel { get; set; }
        public uint VehicleLabelDetail { get; set; }
        public uint DriverIsPhoneing { get; set; }
        public uint DriverIsPhoneingConf { get; set; }
        public uint DriverIsSafebelt { get; set; }
        public uint DriverIsSafebeltConf { get; set; }
        public uint PassengerIsSafebelt { get; set; }
        public uint PassengerIsSafebeltCof { get; set; }
        public uint DriverIsSunVisor { get; set; }
        public uint DriverIsSunVisorConf { get; set; }
        public uint PassengerIsSunVisor { get; set; }
        public uint PassengerIsSunVisorConf { get; set; }
        public System.Drawing.Rectangle DriverRect { get; set; }
        public System.Drawing.Rectangle PassengerRect { get; set; }
        public byte[] GlobalFearture { get; set; }
        public byte[] RegionFearture { get; set; }
    }

    internal class NOTE_UPLOAD_MOVEOBJECT_PEOPLE_PUDONG_DATA
    {
        public string CameraCode { get; set; }
        public uint ObjId { get; set; }
        public uint ObjType { get; set; }
        public DateTime BeginTimeMilliSec { get; set; }
        public DateTime EndTimeMilliSec { get; set; }
        public string FeatureVersion { get; set; }
        public List<BodyColourInfo> BodyColourInfo { get; set; }
        public byte[] GlobalFearture { get; set; }
        public byte[] RegionFearture { get; set; }
        public List<TrailInfo> TrailInfo { get; set; }
        public System.Drawing.Rectangle ObjRec { get; set; }
        public System.Drawing.Image ObjImg { get; set; }
        public string ImageUrl { get; set; }
        public System.Drawing.Image OriginalImage { get; set; }
        public byte[] ReserveData { get; set; }

    }

    internal class BodyColourInfo
    {
        public uint UpBodyColour { get; set; }
        public uint UpBodyColourConf { get; set; }
        public uint DownBodyColour { get; set; }
        public uint DownBodyColourConf { get; set; }
    }
    internal class TrailInfo
    {
        public ulong TrailTs { get; set; }
        public uint TrailFrameSeq { get; set; }
        public DateTime TrailTimeStamp { get; set; }
        public System.Drawing.Rectangle TrailObjRect { get; set; }
    }
    internal class NOTE_UPLOAD_MOVEOBJECT_VEHICLE_PUDONG_DATA
    {
        public string CameraCode { get; set; }
        public uint ObjId { get; set; }
        public uint ObjType { get; set; }
        public DateTime BeginTimeMilliSec { get; set; }
        public DateTime EndTimeMilliSec { get; set; }
        public string FeatureVersion { get; set; }
        public string PlateNum { get; set; }
        public uint PlateReliability { get; set; }
        public uint PlateColor { get; set; }
        public uint PlateNumRow { get; set; }
        public uint VehicleLabel { get; set; }
        public uint VehicleLabelDetail { get; set; }
        public uint VehicleType { get; set; }
        public uint VehicleTypeDetail { get; set; }
        public List<VehicleColorInfo> VehicleColorInfo { get; set; }
        public uint DriverIsPhoneing { get; set; }
        public uint DriverIsPhoneingConf { get; set; }
        public uint DriverIsSafebelt { get; set; }

        public uint DriverIsSafebeltConf { get; set; }
        public uint PassengerIsSafebelt { get; set; }
        public uint PassengerIsSafebeltCof { get; set; }
        public uint DriverIsSunVisor { get; set; }
        public uint DriverIsSunVisorConf { get; set; }
        public uint PassengerIsSunVisor { get; set; }
        public uint PassengerIsSunVisorConf { get; set; }
        public System.Drawing.Rectangle DriverRect { get; set; }
        public System.Drawing.Rectangle PassengerRect { get; set; }
        public byte[] GlobalFearture { get; set; }
        public byte[] RegionFearture { get; set; }
        public List<TrailInfo> TrailInfo { get; set; }
        public System.Drawing.Rectangle ObjRect { get; set; }
        public System.IO.MemoryStream ObjImg { get; set; }
        public System.Drawing.Rectangle PlateRect { get; set; }
        public System.IO.MemoryStream PlateImg { get; set; }

        public string ImageUrl { get; set; }
        public System.IO.MemoryStream OriginalImage { get; set; }
        public byte[] ReserveData { get; set; }
    }

    internal class VehicleColorInfo
    {
        public uint VehicleColor { get; set; }
        public uint VehicleColourConf { get; set; }

    }
}
