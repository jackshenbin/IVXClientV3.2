using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using IVX.Live.DataReceiveServices.Interop;

namespace IVX.Live.DemoView.App
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        List<string> m_filterList = new List<string>();
        Protocol realtimereceive = new Protocol();
            string imgpath = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            imgpath = Directory.GetParent(asm.Location).FullName;

            Text += " 监听端口：" + IVX.Live.DemoView.App.Properties.Settings.Default.ListenPort;
            realtimereceive.Open(IVX.Live.DemoView.App.Properties.Settings.Default.ListenPort);
            realtimereceive.OnReceiveNOTE_UPLOAD_BEHAVIOR_EVENT += realtimereceive_OnReceiveNOTE_UPLOAD_BEHAVIOR_EVENT;
            realtimereceive.OnReceiveNOTE_UPLOAD_PEOPLECOUNT_DATA += realtimereceive_OnReceiveNOTE_UPLOAD_PEOPLECOUNT_DATA;
            realtimereceive.OnReceiveNOTE_UPLOAD_MOVEOBJINFO_DATA += realtimereceive_OnReceiveNOTE_UPLOAD_MOVEOBJINFO_DATA;
            realtimereceive.OnReceiveNOTE_UPLOAD_CROWD_DATA += realtimereceive_OnReceiveNOTE_UPLOAD_CROWD_DATA;
            realtimereceive.OnReceiveNOTE_UPLOAD_PLATE_DATA += realtimereceive_OnReceiveNOTE_UPLOAD_PLATE_DATA;
            realtimereceive.OnReceiveNOTE_UPLOAD_TRAFFIC_EVENT += realtimereceive_OnReceiveNOTE_UPLOAD_TRAFFIC_EVENT;
            realtimereceive.OnReceiveNOTE_UPLOAD_TRAFFIC_PARAM += realtimereceive_OnReceiveNOTE_UPLOAD_TRAFFIC_PARAM;
            realtimereceive.OnReceiveNOTE_UPLOAD_PEOPLECOUNTALARM_EVENT += realtimereceive_OnReceiveNOTE_UPLOAD_PEOPLECOUNTALARM_EVENT;
            realtimereceive.OnReceiveNOTE_UPLOAD_FACECONTROL_EVENT += realtimereceive_OnReceiveNOTE_UPLOAD_FACECONTROL_EVENT;

            CreateFilter("FACECONTROL");
            CreateFilter("PEOPLECOUNTALARM");
            CreateFilter("TRAFFIC_PARAM");
            CreateFilter("TRAFFIC_EVENT");
            CreateFilter("PLATE");
            CreateFilter("CROWD");
            CreateFilter("MOVEOBJINFO");
            CreateFilter("PEOPLECOUNT");
            CreateFilter("BEHAVIOR");
        }

        void CreateFilter(string type)
        {
            CheckBox checkBox1 = new CheckBox();
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(3, 3);
            checkBox1.Name = "checkBox_" + type;
            checkBox1.Size = new System.Drawing.Size(78, 16);
            checkBox1.TabIndex = 0;
            checkBox1.Text = type;
            checkBox1.Tag = type;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.Checked = true;
            checkBox1.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
            // 
            flowLayoutPanel1.Controls.Add(checkBox1);

            if (!m_filterList.Contains(checkBox1.Text))
                m_filterList.Add(checkBox1.Text);

        }

        void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox1 = sender as CheckBox;
            if (checkBox1.Checked)
            {
                if (!m_filterList.Contains(checkBox1.Text))
                    m_filterList.Add(checkBox1.Text);
            }
            else
            {
                if (m_filterList.Contains(checkBox1.Text))
                    m_filterList.Remove(checkBox1.Text);
            }
        }
        void realtimereceive_OnReceiveNOTE_UPLOAD_FACECONTROL_EVENT(Protocol tcp, NOTE_UPLOAD_FACECONTROL_EVENT obj)
        {
            string msg = string.Format("ObjectId:{1}," + Environment.NewLine
                   + "StartTime:{2}," + Environment.NewLine
                   + "EndTime:{3}," + Environment.NewLine
                   + "EventObjRect:{4}," + Environment.NewLine
                   , obj.CameraCode
                   , obj.ObjectId
                   , obj.StartTime
                   , obj.EndTime
                   , obj.EventObjRect
                   );

            //MessageBox.Show(msg);
            AddItem("FACECONTROL", obj.CameraCode, msg, obj.Image);
        }

        void realtimereceive_OnReceiveNOTE_UPLOAD_PEOPLECOUNTALARM_EVENT(Protocol tcp, NOTE_UPLOAD_PEOPLECOUNTALARM_EVENT obj)
        {
            string msg = string.Format("DetectRegionID:{1}," + Environment.NewLine
                   + "BehaviorType:{2}," + Environment.NewLine
                   + "ObjectTotalNum:{3}," + Environment.NewLine
                   , obj.CameraCode
                   , obj.DetectRegionID
                   , obj.BehaviorType
                   , obj.ObjectTotalNum
                   );

            //MessageBox.Show(msg);
            AddItem("PEOPLECOUNTALARM", obj.CameraCode, msg, null);
        }

        void realtimereceive_OnReceiveNOTE_UPLOAD_TRAFFIC_PARAM(Protocol tcp, NOTE_UPLOAD_TRAFFIC_PARAM obj)
        {
            string msg = string.Format("StatiIctisTime:{1}," + Environment.NewLine
                               + "RoadWayNum:{2}," + Environment.NewLine
                               + "TrafficFluxBig:{3}," + Environment.NewLine
                               + "TrafficFluxMiddle:{4}," + Environment.NewLine
                               + "TrafficFluxSmall:{5}," + Environment.NewLine
                               + "TrafficFluxUnMotor:{6}," + Environment.NewLine
                               + "TrafficFluxPerson:{7}," + Environment.NewLine
                               + "TrafficFlux:{8}," + Environment.NewLine
                               + "AvgVehiSpeed:{9}," + Environment.NewLine
                               + "AvgOccupyRatio:{10}," + Environment.NewLine
                               + "QueueLen:{11}," + Environment.NewLine
                               + "AvgVehiDistance:{12}," + Environment.NewLine
                               , obj.CameraCode
                               , obj.StatiIctisTime
                               , obj.RoadWayNum
                               , obj.TrafficFluxBig
                               , obj.TrafficFluxMiddle
                               , obj.TrafficFluxSmall
                               , obj.TrafficFluxUnMotor
                               , obj.TrafficFluxPerson
                               , obj.TrafficFlux
                               , obj.AvgVehiSpeed
                               , obj.AvgOccupyRatio
                               , obj.QueueLen
                               , obj.AvgVehiDistance
                               );


            //MessageBox.Show(msg);
            AddItem("TRAFFIC_PARAM", obj.CameraCode, msg, null);
        }

        void realtimereceive_OnReceiveNOTE_UPLOAD_TRAFFIC_EVENT(Protocol tcp, NOTE_UPLOAD_TRAFFIC_EVENT obj)
        {
            string msg = string.Format("EventType:{1}," + Environment.NewLine
                                          + "StartTime:{2}," + Environment.NewLine
                                          + "EndTime:{3}," + Environment.NewLine
                                          + "ObjRoadWayNum:{4}," + Environment.NewLine
                                          + "EventObjRect:{5}," + Environment.NewLine
                                          + "EventImg1Size:{6}," + Environment.NewLine
                                          + "EventImg2Size:{7}," + Environment.NewLine
                                          + "ComposeImgSize:{8}," + Environment.NewLine
                                          + "Reliability:{9}," + Environment.NewLine
                                          + "PlateNum:{10}," + Environment.NewLine
                                          + "PlateNumRow:{11}," + Environment.NewLine
                                          + "PlateColor:{12}," + Environment.NewLine
                                           + "VehicleColor:{13}," + Environment.NewLine
                                           + "VehicleType:{14}," + Environment.NewLine
                                           + "VehicleTypeDetail:{15}," + Environment.NewLine
                                           + "VehicleLabel:{16}," + Environment.NewLine
                                           + "VehicleLabelDetail:{17}," + Environment.NewLine
                                           + "VehicleSpeed:{18}," + Environment.NewLine
                                           + "Direction:{19}," + Environment.NewLine
                                           + "RoadWayNum:{20}," + Environment.NewLine
                                          , obj.CameraCode
                                          , obj.EventType
                                          , obj.StartTime
                                          , obj.EndTime
                                          , obj.ObjRoadWayNum
                                          , obj.EventObjRect
                                          , obj.EventImg1Size
                                          , obj.EventImg2Size
                                          , obj.ComposeImgSize
                                          , obj.Reliability
                                          , obj.PlateNum
                                          , obj.PlateNumRow
                                          , obj.PlateColor
                                           , obj.VehicleColor
                                           , obj.VehicleType
                                           , obj.VehicleTypeDetail
                                           , obj.VehicleLabel
                                           , obj.VehicleLabelDetail
                                           , obj.VehicleSpeed
                                           , obj.Direction
                                           , obj.RoadWayNum
                                          );


            //MessageBox.Show(msg);
            AddItem("TRAFFIC_EVENT", obj.CameraCode, msg, obj.EventImg1Data);
        }

        void realtimereceive_OnReceiveNOTE_UPLOAD_PLATE_DATA(Protocol tcp, NOTE_UPLOAD_PLATE_DATA obj)
        {
            string msg = string.Format("TimeStamp:{1}," + Environment.NewLine
                   + "ObjectType:{2}," + Environment.NewLine
                   + "Reliability:{3}," + Environment.NewLine
                   + "PlateNum:{4}," + Environment.NewLine
                   + "PlateNumRow:{5}," + Environment.NewLine
                   + "PlateColor:{6}," + Environment.NewLine
                   + "VehicleColor:{7}," + Environment.NewLine
                   + "VehicleType:{8}," + Environment.NewLine
                   + "VehicleTypeDetail:{9}," + Environment.NewLine
                   + "VehicleLabel:{10}," + Environment.NewLine
                   + "VehicleLabelDetail:{11}," + Environment.NewLine
                   + "VehicleSpeed:{12}," + Environment.NewLine
                   + "Direction:{13}," + Environment.NewLine
                   + "RoadWayNum:{14}," + Environment.NewLine
                   , obj.CameraCode
                   , obj.TimeStamp
                   , obj.ObjectType
                   , obj.Reliability
                   , obj.PlateNum
                   , obj.PlateNumRow
                   , obj.PlateColor
                   , obj.VehicleColor
                   , obj.VehicleType
                   , obj.VehicleTypeDetail
                   , obj.VehicleLabel
                   , obj.VehicleLabelDetail
                   , obj.VehicleSpeed
                   , obj.Direction
                   , obj.RoadWayNum
                   );


            //MessageBox.Show(msg);
            AddItem("PLATE", obj.CameraCode, msg, obj.PlateImgData);
        }

        void realtimereceive_OnReceiveNOTE_UPLOAD_CROWD_DATA(Protocol tcp, NOTE_UPLOAD_CROWD_DATA obj)
        {
            string msg = string.Format("TimeSec:{1}," + Environment.NewLine
                   + "PeopleCount:{2}," + Environment.NewLine
                   + "Area:{3}," + Environment.NewLine
                   , obj.CameraCode
                   , obj.TimeSec
                   , obj.PeopleCount
                   , obj.Area
                   );
            foreach (var item in obj.CrowdDetectRegion)
            {
                msg += "(" + item.X + "," + item.Y + ")";
            }

            //MessageBox.Show(msg);
            AddItem("CROWD", obj.CameraCode, msg, obj.PseudHotImg);
        }

        void realtimereceive_OnReceiveNOTE_UPLOAD_MOVEOBJINFO_DATA(Protocol tcp, NOTE_UPLOAD_MOVEOBJINFO_DATA obj)
        {
            string msg = string.Format("ObjectId:{1}," + Environment.NewLine
                   + "ObjType:{2}," + Environment.NewLine
                   + "BeginTime:{3}," + Environment.NewLine
                   + "EndTime:{4}," + Environment.NewLine
                   , obj.CameraCode
                   , obj.ObjectId
                   , obj.ObjType
                   , obj.BeginTime
                   , obj.EndTime
                  
                   );

            if (obj.TrailPointList.Count >= 3)
            {
                Image img1 = new Bitmap(obj.TrailPointList[0].OriImg.Width, obj.TrailPointList[0].OriImg.Height);
                Graphics gh1 = Graphics.FromImage(img1);
                gh1.DrawImage(obj.TrailPointList[0].OriImg, new Point());
                gh1.DrawRectangle(new Pen(Color.Red, 2), obj.TrailPointList[0].ImgObjRect);
                gh1.DrawString(string.Format("ImgTs:{0},ImgFrameSeq:{1},ImgTimeStamp:{2}",obj.TrailPointList[0].Time,obj.TrailPointList[0].FrameSeq,obj.TrailPointList[0].TimeStam),new Font("微软雅黑", 30), Brushes.Blue, new PointF(11, 12));
                gh1.Dispose();

                Image img2 = new Bitmap(obj.TrailPointList[1].OriImg.Width, obj.TrailPointList[1].OriImg.Height);
                Graphics gh2 = Graphics.FromImage(img2);
                gh2.DrawImage(obj.TrailPointList[1].OriImg, new Point());
                gh2.DrawRectangle(new Pen(Color.Red, 2), obj.TrailPointList[1].ImgObjRect);
                gh2.DrawString(string.Format("ImgTs:{0},ImgFrameSeq:{1},ImgTimeStamp:{2}", obj.TrailPointList[1].Time, obj.TrailPointList[1].FrameSeq, obj.TrailPointList[1].TimeStam), new Font("微软雅黑", 30), Brushes.Blue, new PointF(11, 12));
                gh2.Dispose();

                Image img3 = new Bitmap(obj.TrailPointList[2].OriImg.Width, obj.TrailPointList[2].OriImg.Height);
                Graphics gh3 = Graphics.FromImage(img3);
                gh3.DrawImage(obj.TrailPointList[2].OriImg, new Point());
                gh3.DrawRectangle(new Pen(Color.Red, 2), obj.TrailPointList[2].ImgObjRect);
                gh3.DrawString(string.Format("ImgTs:{0},ImgFrameSeq:{1},ImgTimeStamp:{2}", obj.TrailPointList[2].Time, obj.TrailPointList[2].FrameSeq, obj.TrailPointList[2].TimeStam), new Font("微软雅黑", 30), Brushes.Blue, new PointF(11, 12));
                gh3.Dispose();

                Image imgfull = new Bitmap(1920, 1080);
                Graphics ghfull = Graphics.FromImage(imgfull);
                ghfull.DrawImage(img1,new Rectangle(0,0,960,540),new Rectangle(new Point(),img1.Size),GraphicsUnit.Pixel);
                ghfull.DrawImage(img2,new Rectangle(960,0,960,540),new Rectangle(new Point(),img2.Size),GraphicsUnit.Pixel);
                ghfull.DrawImage(img3,new Rectangle(0,540,960,540),new Rectangle(new Point(),img3.Size),GraphicsUnit.Pixel);
                gh3.Dispose();

                AddItem("MOVEOBJINFO", obj.CameraCode, msg, imgfull);
            }
            else
                AddItem("MOVEOBJINFO", obj.CameraCode, msg, null);
        }


        void realtimereceive_OnReceiveNOTE_UPLOAD_PEOPLECOUNT_DATA(Protocol tcp, NOTE_UPLOAD_PEOPLECOUNT_DATA obj)
        {
            string msg = string.Format( "DetectRegionID:{1}," + Environment.NewLine
                   + "BehaviorType:{2}," + Environment.NewLine
                   + "ObjectTotalNum:{3}," + Environment.NewLine
                   , obj.CameraCode
                   , obj.DetectRegionID
                   , obj.BehaviorType
                   , obj.ObjectTotalNum
                   );

            //MessageBox.Show(msg);
            AddItem("PEOPLECOUNT", obj.CameraCode, msg, null);

        }

        void realtimereceive_OnReceiveNOTE_UPLOAD_BEHAVIOR_EVENT(Protocol tcp, NOTE_UPLOAD_BEHAVIOR_EVENT obj)
        {
            string msg = string.Format("ObjectId:{1}," + Environment.NewLine
        + "EventType:{2}," + Environment.NewLine
        + "TimeStamp:{3}," + Environment.NewLine
        + "EventObjRect:{4}," + Environment.NewLine
        + "ObjType:{5}," + Environment.NewLine
        + "ObjNum:{6}," + Environment.NewLine
        //+ "Image:{10}," + Environment.NewLine
        //+ "Reserved:{11}," + Environment.NewLine
        , obj.CameraCode
        , obj.ObjectId
        , obj.EventType
        , obj.TimeStamp
        , obj.EventObjRect
        , obj.ObjType
        , obj.ObjNum
        //, obj.Image
        //, obj.Reserved
        );
            Image img = new Bitmap(obj.Image.Width, obj.Image.Height);
            Graphics gh = Graphics.FromImage(img);
            gh.DrawImage(obj.Image,new Point());
            gh.DrawRectangle(new Pen(Color.Red,2), obj.EventObjRect);
            gh.Dispose();
            //MessageBox.Show(msg);
            AddItem("BEHAVIOR",obj.CameraCode, msg, img);
        }

        void AddItem(string type , string camera, string value, Image img)
        {
            if (InvokeRequired && !IsDisposed)
            {
                this.BeginInvoke(new Action<string, string, string, Image>(AddItem), type, camera, value, img);
            }
            else
            {
                if (!m_filterList.Contains(type))
                    return;

                string path = "none";
                if(img!=null)
                {
                    path = imgpath + "\\" + type;
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    path = path + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    img.Save(path,System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                ListViewItem item = new ListViewItem(listView1.Items.Count.ToString());
                item.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff"));
                item.SubItems.Add(type);
                item.SubItems.Add(camera);
                item.SubItems.Add(value);
                item.SubItems.Add(path);
                listView1.Items.Add(item);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            realtimereceive.Close();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item =  listView1.GetItemAt(e.X, e.Y);
            if (item != null && item.SubItems[5].Text != "none")
            {
                string path = item.SubItems[5].Text;
                Image img = Bitmap.FromFile(path);
                Form f = new Form();
                f.BackgroundImage = img;
                f.BackgroundImageLayout = ImageLayout.Zoom;
                f.Text = path;
                f.WindowState = FormWindowState.Maximized;
                f.StartPosition = FormStartPosition.CenterScreen;
                f.Show();
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }
    }
}
