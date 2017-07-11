using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using IVX.DataModel;
using System.Collections.Generic;
using System.Drawing;

namespace IVX.Live.ConfigServices.Interop
{
    #region 基本结构体


    ///// <summary>
    ///// 播放绘图相关接口 绘制的越界线信息
    ///// </summary>
    //[StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    //internal struct TVDASDK_DRAW_PASSLINE
    //{
    //    /// <summary>
    //    /// 越界线列表
    //    /// </summary>
    //    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = Common.VDA_PASSLINE_MAXNUM)]
    //    public TVDASDK_IA_SEARCH_PASS_LINE[] atPassLineList;

    //    /// <summary>
    //    /// 越界线数量
    //    /// </summary>
    //    public UInt32 dwPassLineNum;
    //};

    ///// <summary>
    ///// 绘制的闯入闯出区域信息
    ///// </summary>
    //[StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    //internal struct TVDASDK_DRAW_BREAK_REGION
    //{
    //    /// <summary>
    //    /// 闯入闯出区域
    //    /// </summary>
    //    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = Common.VDA_BREAK_REGION_MAXNUM)]
    //    public TVDASDK_SEARCH_BREAK_REGION[] atBreakRegionList;

    //    /// <summary>
    //    /// 闯入闯出区域数量
    //    /// </summary>
    //    public UInt32 dwBreakRegionNum;
    //};



    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    internal struct TPDO_RECT
    {
        public UInt32 dwX;
        public UInt32 dwY;
        public UInt32 dwWidth;
        public UInt32 dwHeight;
    };

    //绘制的矩形信息
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    internal struct TPDO_DRAW_RECT
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = Common.PDO_DRAW_RECT_MAXNUM)]
        public TPDO_RECT[] atRectList;	//绘制的矩形列表
        public UInt32 dwRectNum;		//矩形数量
    };

    #region 越界线结构体

    //注：！！ 越界线的方向线和方向类型是反的，故在接口输入输出时需要转换
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct TPDO_CROSSLINE
    {
        public Point ptBegin;					//越界线起点
        public Point ptEnd;					//越界线终点
        //E_DIRECTION_TYPE eDirectionType;//
        public uint uDirectType;				//越界线方向：0:向外,1:向里,2:双向
        public Point ptDirectBegin;			//越界方向线起点
        public Point ptDirectEnd;				//越界方向线终点
    };

    //绘制的矩形信息
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    internal struct TPDO_DRAW_CROSSLINES
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = Common.PDO_DRAW_RECT_MAXNUM)]
        public TPDO_CROSSLINE[] atCrossLineList;	//绘制的矩形列表
        public UInt32 dwNum;		//矩形数量
    };

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    internal struct TPDO_DRAW_FENCEPOLYGONS
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = Common.PDO_DRAW_RECT_MAXNUM)]
        public TCROSS_FRAME_GRAPH[] atCrossLineList;	//绘制的矩形列表
        public UInt32 dwNum;		//矩形数量
    };

    #endregion

    #region 闯入闯出多边形结构体

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct TCROSS_FRAME_GRAPH
    {
        public TPOINT_SET sPointSet;			//闯入闯出顶点集
        public uint uDirectType;
    };

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct TPOINT_SET
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = Common.PDO_POINT_ARRAY_SIZE)]
       public Point[] Points;	//点数组
	   public  uint nRealSize;					//点数组实际大小
    };
    
    #endregion

    //文件路径
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    internal struct TPDO_FILE_PATH
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Common.PDO_FILEPATH_MAXLEN)]
        public string szFilePath; //文件路径
    };
    #endregion

    #region 回调定义

    /*===========================================================
    功  能：播放窗口鼠标动作通知回调函数
    参  数：lVodHandle - 播放标示句柄
		    dwOptType - 下载状态，见E_VDA_PLAY_WND_MOUSE_OPT_TYPE
		    dwX - 鼠标所在x轴窗口坐标
		    dwY - 鼠标所在y轴窗口坐标
		    dwUserData - 用户数据
    返回值：无
    ===========================================================*/
    [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
    internal delegate void TfuncPlayWndMouseOptNtfCB(Int32 lVodHandle, UInt32 dwOptType, UInt32 dwX, UInt32 dwY, UInt32 dwUserData);

    //鼠标事件回调函数
    [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
    internal delegate void TFuncPDOMouseOptNtfCB(Int32 hPdoHandle, E_PDO_MOUSE_EVENT eMouseEvent,
                                                UInt32 dwX, UInt32 dwY, UInt32 dwUserData);

    #endregion

    internal partial class IVXDrawSDKProtocol
    {
        #region 绘图相关


        /*=================================================================
        功  能：开启显示图片叠加控制
        参  数：hWnd：显示图片的窗口句柄
                ptInitParam:初始化函数参数
                phPdoHandle:返回操作标示句柄
        返回值：成功返回PDO_OK，失败返回错误码
        =================================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 Pdo_Open(IntPtr hWnd, TFuncPDOMouseOptNtfCB pfuncMouseEventCb,
                                            UInt32 dwUserData, out UInt32 phPdoHandle);

        /*=================================================================
        功  能：关闭显示图片叠加控制
        参  数：hPdoHandle：标示句柄
        返回值：成功返回PDO_OK，失败返回错误码
        =================================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 Pdo_Close(UInt32 hPdoHandle);

        /*=================================================================
        功  能：设置要显示的本地图片文件
        参  数：hPdoHandle：标示句柄
                tPicFilePath：图片文件路径
                dwPicType：图片格式类型，见E_PDO_PIC_TYPE		
        返回值：成功返回PDO_OK，失败返回错误码
        =================================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 Pdo_DisplayPicFileSet(UInt32 hPdoHandle, TPDO_FILE_PATH tPicFilePath);

        /*=================================================================
        功  能：设置要显示的本地图片文件
        参  数：hPdoHandle：标示句柄
                pPicData：图片数据
                dwPicDataSize：图片数据大小
                dwPicType：图片格式类型，见E_PDO_PIC_TYPE		
        返回值：成功返回PDO_OK，失败返回错误码
        =================================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 Pdo_DisplayPicDataSet(UInt32 hPdoHandle, IntPtr pPicData,
                                                          UInt32 dwPicDataSize, UInt32 dwPicType);

        /*===========================================================
        功  能：设置绘图类型（如画线，画矩形等内容)
        参  数：hPdoHandle - 标示句柄
                dwDrawType - 搜索行为过滤类型 见E_PDO_DRAW_TYPE
        返回值：成功返回PDO_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 Pdo_DrawTypeSet(UInt32 hPdoHandle, UInt32 dwDrawType);

        /*===========================================================
        功  能：清除播放绘制内容
        参  数：hPdoHandle - 标示句柄
        返回值：成功返回PDO_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 Pdo_DrawClear(UInt32 hPdoHandle);

        /*===========================================================
        功  能：获取绘制的矩形信息
        参  数：hPdoHandle - 标示句柄
                ptDrawRect - 绘制的矩形信息
        返回值：成功返回PDO_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 Pdo_DrawRectGet(UInt32 hPdoHandle, out TPDO_DRAW_RECT ptDrawRect);
        /*===========================================================
        功  能：设置绘制的矩形信息
        参  数：hPdoHandle - 标示句柄
		        ptDrawRect - 绘制的矩形信息
        返回值：成功返回PDO_OK，失败返回错误码
        ===========================================================*/
        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 Pdo_DrawRectSet(UInt32 hPdoHandle, ref TPDO_DRAW_RECT ptDrawRect);

        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 Pdo_CrossLinesGet(UInt32 hPdoHandle, out TPDO_DRAW_CROSSLINES ptCrossLines);

        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 Pdo_CrossLinesSet(UInt32 hPdoHandle, ref TPDO_DRAW_CROSSLINES ptCrossLines);

        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 Pdo_FencePolygonsGet(UInt32 hPdoHandle, out TPDO_DRAW_FENCEPOLYGONS ptCrossLines);

        [DllImport(DLLPATH, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 Pdo_FencePolygonsSet(UInt32 hPdoHandle, ref TPDO_DRAW_FENCEPOLYGONS ptCrossLines);

        #endregion

    }

    public partial class IVXRealtimeProtocol
    {
        #region 绘图相关

        
        /// <summary>
        /// 开启显示图片叠加控制
        /// </summary>
        /// <param name="hWnd">显示图片的窗口句柄</param>
        /// <param name="dwUserData"></param>
        /// <returns>返回操作标示句柄</returns>
        public UInt32 Pdo_Open(IntPtr hWnd, UInt32 dwUserData)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDrawSDKProtocol Pdo_Open hWnd:" + hWnd);
            m_pfuncMouseEventCb = OnPDOMouseOptNtfCB;
            UInt32 phPdoHandle = 0;
            UInt32 retVal = IVXDrawSDKProtocol.Pdo_Open(hWnd, null, dwUserData, out phPdoHandle);
            //if (0 != retVal)
            //{
            //    // 调用失败，抛异常
            //    CheckError();
            //}
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDrawSDKProtocol Pdo_Open ret:" + retVal);
            return phPdoHandle;
        }

        /// <summary>
        /// 关闭显示图片叠加控制
        /// </summary>
        /// <param name="hPdoHandle">标示句柄</param>
        /// <returns>成功返回PDO_OK，失败返回错误码</returns>
        public UInt32 Pdo_Close(UInt32 hPdoHandle)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log,"IVXDrawSDKProtocol Pdo_Close hPdoHandle:" + hPdoHandle);
            UInt32 retVal = IVXDrawSDKProtocol.Pdo_Close(hPdoHandle);
            //if (0 != retVal)
            //{
            //    // 调用失败，抛异常
            //    CheckError();
            //}
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log,"IVXDrawSDKProtocol Pdo_Close ret:" + retVal);
            return retVal;

        }

        /// <summary>
        /// 设置要显示的本地图片文件
        /// </summary>
        /// <param name="hPdoHandle">标示句柄</param>
        /// <param name="picFilePath">图片文件路径</param>
        /// <returns>成功返回PDO_OK，失败返回错误码</returns>
        public UInt32 Pdo_DisplayPicFileSet(UInt32 hPdoHandle, string picFilePath)
        {
            TPDO_FILE_PATH tPicFilePath = new TPDO_FILE_PATH();
            tPicFilePath.szFilePath = picFilePath;
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log,"IVXDrawSDKProtocol Pdo_DisplayPicFileSet hPdoHandle:" + hPdoHandle + ",PicFilePath:" + picFilePath);
            UInt32 retVal = IVXDrawSDKProtocol.Pdo_DisplayPicFileSet(hPdoHandle, tPicFilePath);
            //if (0 != retVal)
            //{
            //    // 调用失败，抛异常
            //    CheckError();
            //}
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log,"IVXDrawSDKProtocol Pdo_DisplayPicFileSet ret:" + retVal);
            return retVal;

        }

        /// <summary>
        /// 设置要显示的本地图片文件
        /// </summary>
        /// <param name="hPdoHandle">标示句柄</param>
        /// <param name="image">图片数据</param>
        /// <returns>成功返回PDO_OK，失败返回错误码</returns>
        public UInt32 Pdo_DisplayPicDataSet(UInt32 hPdoHandle, System.Drawing.Image image)
        {
            IntPtr pPicData = IntPtr.Zero;
            UInt32 dwPicDataSize = 0;
            if (image != null)
            {
                byte[] bytes = Common.ImageToJpegBytes(image);

                dwPicDataSize = (uint)bytes.Length;
                pPicData = Marshal.AllocHGlobal(bytes.Length);

                Marshal.Copy(bytes, 0, pPicData, bytes.Length);

            }
            UInt32 dwPicType = (uint)E_PDO_PIC_TYPE.E_PDO_PIC_JPG;//图片格式类型，见E_PDO_PIC_TYPE

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log,"IVXDrawSDKProtocol Pdo_DisplayPicDataSet hPdoHandle:" + hPdoHandle);
            UInt32 retVal = IVXDrawSDKProtocol.Pdo_DisplayPicDataSet(hPdoHandle, pPicData, dwPicDataSize, dwPicType);
            //if (0 != retVal)
            //{
            //    // 调用失败，抛异常
            //    CheckError();
            //}
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log,"IVXDrawSDKProtocol Pdo_DisplayPicDataSet ret:" + retVal);
            
            if (pPicData!=IntPtr.Zero)
                Marshal.FreeHGlobal(pPicData);

            return retVal;
        }

        /// <summary>
        /// 设置绘图类型（如画线，画矩形等内容)
        /// </summary>
        /// <param name="hPdoHandle">标示句柄</param>
        /// <param name="dwDrawType">搜索行为过滤类型 见E_PDO_DRAW_TYPE</param>
        /// <returns>成功返回PDO_OK，失败返回错误码</returns>
        public UInt32 Pdo_DrawTypeSet(UInt32 hPdoHandle, E_PDO_DRAW_TYPE dwDrawType)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log,"IVXDrawSDKProtocol Pdo_DrawTypeSet hPdoHandle:" + hPdoHandle + ",dwDrawType:" + dwDrawType);
            UInt32 retVal = IVXDrawSDKProtocol.Pdo_DrawTypeSet(hPdoHandle, (uint)dwDrawType);
            //if (0 != retVal)
            //{
            //    // 调用失败，抛异常
            //    CheckError();
            //}
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log,"IVXDrawSDKProtocol Pdo_DrawTypeSet ret:" + retVal);
            return retVal;

        }

        /// <summary>
        /// 清除播放绘制内容
        /// </summary>
        /// <param name="hPdoHandle">标示句柄</param>
        /// <returns>成功返回PDO_OK，失败返回错误码</returns>
        public UInt32 Pdo_DrawClear(UInt32 hPdoHandle)
        {
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log,"IVXDrawSDKProtocol Pdo_DrawClear hPdoHandle:" + hPdoHandle);
            UInt32 retVal = IVXDrawSDKProtocol.Pdo_DrawClear(hPdoHandle);
            //if (0 != retVal)
            //{
            //    // 调用失败，抛异常
            //    CheckError();
            //}
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log,"IVXDrawSDKProtocol Pdo_DrawClear ret:" + retVal);
            return retVal;
        }

        /// <summary>
        /// 获取绘制的矩形信息
        /// </summary>
        /// <param name="hPdoHandle">标示句柄</param>
        /// <returns>绘制的矩形信息</returns>
        public List<System.Drawing.Rectangle> Pdo_DrawRectGet(UInt32 hPdoHandle)
        {
            TPDO_DRAW_RECT ptDrawRect = new TPDO_DRAW_RECT();

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log,"IVXDrawSDKProtocol Pdo_DrawRectGet hPdoHandle:" + hPdoHandle);
            UInt32 retVal = IVXDrawSDKProtocol.Pdo_DrawRectGet(hPdoHandle, out ptDrawRect);
            //if (0 != retVal)
            //{
            //    // 调用失败，抛异常
            //    CheckError();
            //}
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log,"IVXDrawSDKProtocol Pdo_DrawRectGet ret:" + retVal);
            List<System.Drawing.Rectangle> ret = new List<System.Drawing.Rectangle>();
            for (int i = 0; i < ptDrawRect.dwRectNum; i++)
            {
                ret.Add(
                    new System.Drawing.Rectangle((int)ptDrawRect.atRectList[i].dwX, (int)ptDrawRect.atRectList[i].dwY, (int)ptDrawRect.atRectList[i].dwWidth, (int)ptDrawRect.atRectList[i].dwHeight)
                    );
            }
            return ret;
        }

        public UInt32 Pdo_DrawRectSet(UInt32 hPdoHandle, List<System.Drawing.Rectangle> rects)
        {
            TPDO_DRAW_RECT ptDrawRect = new TPDO_DRAW_RECT();
            ptDrawRect.dwRectNum = (uint)rects.Count;
            ptDrawRect.atRectList = new TPDO_RECT[Common.PDO_DRAW_RECT_MAXNUM];

            for (int i = 0; i < ptDrawRect.dwRectNum; i++)
            {
                ptDrawRect.atRectList[i] = new TPDO_RECT { dwHeight = (uint)rects[i].Height, dwWidth = (uint)rects[i].Width, dwX = (uint)rects[i].X, dwY = (uint)rects[i].Y };
            }

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDrawSDKProtocol Pdo_DrawRectSet hPdoHandle:" + hPdoHandle);
            UInt32 retVal = IVXDrawSDKProtocol.Pdo_DrawRectSet(hPdoHandle, ref ptDrawRect);
            //if (0 != retVal)
            //{
            //    // 调用失败，抛异常
            //    CheckError();
            //}
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDrawSDKProtocol Pdo_DrawRectSet ret:" + retVal);

            return retVal;
        }

        public List<PassLine> Pdo_CrossLinesGet(UInt32 hPdoHandle)
        {
            TPDO_DRAW_CROSSLINES crossLines;
            List<PassLine> list = new List<PassLine>();
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDrawSDKProtocol Pdo_DrawRectGet hPdoHandle:" + hPdoHandle);
            UInt32 retVal = IVXDrawSDKProtocol.Pdo_CrossLinesGet(hPdoHandle, out crossLines);
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDrawSDKProtocol Pdo_DrawRectGet ret:" + retVal);

            for (int i = 0; i < crossLines.dwNum; i++)
            {
                uint passtype = 2;
                if (crossLines.atCrossLineList[i].uDirectType == 0)
                    passtype = 1;
                else if (crossLines.atCrossLineList[i].uDirectType == 1)
                    passtype = 0;

                list.Add(new PassLine()
                {
                    DirectLineEnd = crossLines.atCrossLineList[i].ptDirectEnd,
                    DirectLineStart = crossLines.atCrossLineList[i].ptDirectBegin,
                    ID = (uint)i,
                    PassLineEnd = crossLines.atCrossLineList[i].ptEnd,
                    PassLineStart = crossLines.atCrossLineList[i].ptBegin,
                    PassLineType = passtype,
                }
                );
            }
            return list;
        }

        public UInt32 Pdo_CrossLinesSet(UInt32 hPdoHandle, List<PassLine> crossLineList)
        {
            TPDO_DRAW_CROSSLINES crossLines;

            crossLines.dwNum = (uint)crossLineList.Count;

            TPDO_CROSSLINE[] ps = new TPDO_CROSSLINE[Common.PDO_DRAW_RECT_MAXNUM];
            for (int i = 0; i < crossLineList.Count; i++)
            {
                uint passtype = 2;
                if (crossLineList[i].PassLineType == 0)
                    passtype = 1;
                else if (crossLineList[i].PassLineType == 1)
                    passtype = 0;

                ps[i] = new TPDO_CROSSLINE()
                {
                    ptBegin = crossLineList[i].PassLineStart,
                    ptDirectBegin = crossLineList[i].DirectLineStart,
                    ptDirectEnd = crossLineList[i].DirectLineEnd,
                    ptEnd = crossLineList[i].PassLineEnd,
                    uDirectType = passtype,
                };
            }

            crossLines.atCrossLineList = ps;

            UInt32 retVal = IVXDrawSDKProtocol.Pdo_CrossLinesSet(hPdoHandle, ref crossLines);

            //for (int i = 0; i < fencePolygons.dwNum; i++)
            //{
            //    polygons.Add(fencePolygons.atCrossLineList[i].sPointSet);
            //}
            return retVal;
        }

        public List<BreakRegion> Pdo_FencePolygonsGet(UInt32 hPdoHandle)
        {
            TPDO_DRAW_FENCEPOLYGONS fencePolygons;
            List<BreakRegion> list = new List<BreakRegion>();

            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDrawSDKProtocol Pdo_DrawRectGet hPdoHandle:" + hPdoHandle);
            UInt32 retVal = IVXDrawSDKProtocol.Pdo_FencePolygonsGet(hPdoHandle, out fencePolygons);
            MyLog4Net.ILogExtension.DebugWithDebugView(MyLog4Net.Container.Instance.Log, "IVXDrawSDKProtocol Pdo_DrawRectGet ret:" + retVal);

            for (int i = 0; i < fencePolygons.dwNum; i++)
            {
                BreakRegion temp = new BreakRegion()
                {
                    ID = (uint)i,
                    RegionType = fencePolygons.atCrossLineList[i].uDirectType,
                    RegionPointList = new List<Point>(),
                };
                for (int j = 0; j < fencePolygons.atCrossLineList[i].sPointSet.nRealSize; j++)
                {
                    temp.RegionPointList.Add(fencePolygons.atCrossLineList[i].sPointSet.Points[j]);

                }
                list.Add(temp);
            }
            return list;
        }

        public UInt32 Pdo_FencePolygonsSet(UInt32 hPdoHandle, List<BreakRegion> polygons)
        {
            TPDO_DRAW_FENCEPOLYGONS fencePolygons;
            
            fencePolygons.dwNum = (uint)polygons.Count;

            TCROSS_FRAME_GRAPH[] ps = new TCROSS_FRAME_GRAPH[Common.PDO_DRAW_RECT_MAXNUM];
            for(int i = 0; i < polygons.Count; i++)
            {
                ps[i].sPointSet.nRealSize = (uint)polygons[i].RegionPointList.Count;
                ps[i].sPointSet.Points = new Point[Common.PDO_POINT_ARRAY_SIZE];
                polygons[i].RegionPointList.CopyTo(0, ps[i].sPointSet.Points, 0, polygons[i].RegionPointList.Count);
                ps[i].uDirectType = polygons[i].RegionType;
            }

            fencePolygons.atCrossLineList = ps;

            UInt32 retVal = IVXDrawSDKProtocol.Pdo_FencePolygonsSet(hPdoHandle, ref fencePolygons);
            
            //for (int i = 0; i < fencePolygons.dwNum; i++)
            //{
            //    polygons.Add(fencePolygons.atCrossLineList[i].sPointSet);
            //}
            return retVal;
        }

        #endregion
    }
}
