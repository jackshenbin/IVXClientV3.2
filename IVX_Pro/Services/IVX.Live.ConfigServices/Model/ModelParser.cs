using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using BOCOM.RealtimeProtocol;
using System.IO;
using System.Drawing.Imaging;
using BOCOM.DataModel;
using System.Diagnostics;
using DataModel;
// using BOCOM.IVX.Protocol.IVXRealtimeSDKProtocol;


namespace BOCOM.RealtimeProtocol.Model
{
    public static class ModelParser
    {

        public static Image GetImage(IntPtr startAddress, int byteSize)
        {
            Image img = null;
            byte[] bytes = new byte[byteSize];
            IntPtr ptr = startAddress;
            Marshal.Copy(ptr, bytes, 0, byteSize);

            try
            {
                MemoryStream ms = new MemoryStream(bytes);
                Image imgTmp = Image.FromStream(ms);
                // 新创建一张Image， 从imgTmp构造， 因为用工具.NETMemoryProfiler 看到有时 bytes不能被回收
                img = new Bitmap(imgTmp);
                img.Save("c:\\a.jpg");
                imgTmp.Dispose();
                ms.Dispose();
            }
            catch (Exception aex)
            {
                MyLog4Net.Container.Instance.Log.Error("Create image failed", aex);
                Debug.Assert(false, "Image.FromStream failed");
                img = null;
            }
            return img;
        }

        public static DateTime ConvertLinuxTime(uint linuxtime)
        {
            DateTime retTime = Common.ZEROTIME.AddSeconds(linuxtime);
            if (retTime < Common.ZEROTIME.AddYears(1))
                return new DateTime().AddSeconds(linuxtime);
            else
                return retTime;
        }

        public static UInt32 ConvertLinuxTime(DateTime dnettime)
        {
            if (dnettime < Common.ZEROTIME)
                return (uint)(dnettime.Subtract(new DateTime()).TotalSeconds);
            else
            {
                if (dnettime > Common.MAXTIME)
                    return (uint)(Common.MAXTIME.Subtract(Common.ZEROTIME).TotalSeconds);
                else
                    return (uint)(dnettime.Subtract(Common.ZEROTIME).TotalSeconds);
            }
        }


        public static byte[] ImageToJpegBytes(Image img)
        {
            byte[] bytes = null;

            ImageFormat format = img.RawFormat;

            using (MemoryStream ms = new MemoryStream())
            {
                //if(format.Equals(ImageFormat.Jpeg) ||
                //    format.Equals(ImageFormat.Bmp) ||
                //    format.Equals(ImageFormat.Gif) ||
                //    format.Equals(ImageFormat.Icon))
                {
                    img.Save(ms, ImageFormat.Jpeg);
                    bytes = new byte[ms.Length];

                    ms.Seek(0, SeekOrigin.Begin);
                    ms.Read(bytes, 0, bytes.Length);
                }
            }

            return bytes;
        }
    }
}
