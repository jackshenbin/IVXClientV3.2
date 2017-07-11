using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Events;


namespace IVX.DataModel
{
    public class NavigateEvent : CompositePresentationEvent<Tuple< SystemMenu,object>> { }

    public class CmdExecuteEvent : CompositePresentationEvent<CmdItemInfo> { }

   
    public class LogoutEvent : CompositePresentationEvent<bool> { }

    public class QuitEvent : CompositePresentationEvent<string> { }

    public class ShowDialogEvent : CompositePresentationEvent<UIFuncItemInfo> { }

    public class AddUserGroupEvent : CompositePresentationEvent<uint> { }

    public class EditUserGroupEvent : CompositePresentationEvent<uint> { }

    public class DelUserGroupEvent : CompositePresentationEvent<uint> { }

    public class AddUserEvent : CompositePresentationEvent<uint> { }

    public class EditUserEvent : CompositePresentationEvent<uint> { }

    public class DelUserEvent : CompositePresentationEvent<uint> { }

    public class AddVideoSupplierDeviceEvent : CompositePresentationEvent<VideoSupplierDeviceInfo> { }

    public class EditVideoSupplierDeviceEvent : CompositePresentationEvent<VideoSupplierDeviceInfo> { }

    public class DelVideoSupplierDeviceEvent : CompositePresentationEvent<uint> { }

    public class AddLocalVideoTaskEvent : CompositePresentationEvent<string> { }

    public class TaskStatusChangedEvent : CompositePresentationEvent<uint> { }

    public class TaskAddedEvent : CompositePresentationEvent<TaskInfo> { }

    public class TaskModifiedEvent : CompositePresentationEvent<TaskInfo> { }

    public class TaskDeletedEvent : CompositePresentationEvent<uint> { }

    public class CaseAddedEvent : CompositePresentationEvent<CaseInfo> { }

    public class CaseModifiedEvent : CompositePresentationEvent<CaseInfo> { }

    public class CaseDeletedEvent : CompositePresentationEvent<uint> { }

    public class CameraAddedEvent : CompositePresentationEvent<CameraInfo> { }

    public class CameraModifiedEvent : CompositePresentationEvent<CameraInfo> { }

    public class CameraDeletedEvent : CompositePresentationEvent<uint> { }

    public class CameraGroupAddedEvent : CompositePresentationEvent<CameraGroupInfo> { }

    public class CameraGroupModifiedEvent : CompositePresentationEvent<CameraGroupInfo> { }

    public class CameraGroupDeletedEvent : CompositePresentationEvent<uint> { }

    public class ServerAddedEvent : CompositePresentationEvent<ServerInfo> { }

    public class ServerModifiedEvent : CompositePresentationEvent<ServerInfo> { }

    public class ServerDeletedEvent : CompositePresentationEvent<uint> { }

    public class TaskUnitProgressStatusChangedEvent : CompositePresentationEvent<uint> { }

    public class TaskUnitAnalyseFinishedEvent : CompositePresentationEvent<uint> { }

    public class TaskUnitImportFinishedEvent : CompositePresentationEvent<uint> { }

    //public class TaskUnitAddedEvent : CompositePresentationEvent<TaskUnitInfo> { }

    public class TaskUnitDeletedEvent : CompositePresentationEvent<uint> { }

    //public class CameraSelectionChangedEvent : CompositePresentationEvent<List<RealtimeCameraInfo>> { }

    public class AddCameraSelectedEvent : CompositePresentationEvent<RealtimeCameraInfo> { }

    public class DeleteCameraSelectedEvent : CompositePresentationEvent<string> { }

    public class BriefMouseClickChangedEvent : CompositePresentationEvent<BriefMouseClickInfo> { }

    //public class SearchItemResultReceivedEvent : CompositePresentationEvent<SearchItemResult> { }

    //public class PlayPosChangedEvent : CompositePresentationEvent<VideoStatusInfo> { }

    //public class PlaySeekErrorEvent : CompositePresentationEvent<VideoStatusInfo> { }

    //public class PlaySynthFailedEvent : CompositePresentationEvent<VideoStatusInfo> { }

    //public class PlayFailedEvent : CompositePresentationEvent<VideoStatusInfo> { }

    //public class PlayReadyEvent : CompositePresentationEvent<VideoStatusInfo> { }

    public class OCXPlayVideoEvent : CompositePresentationEvent<uint> { }

    public class OCXStopAllPlayVideoEvent : CompositePresentationEvent<string> { }

    public class OCXPlayObjectSearchVideoEvent : CompositePresentationEvent<uint> { }

    public class OCXPlayFaceSearchVideoEvent : CompositePresentationEvent<uint> { }

    public class OCXPlayCarSearchVideoEvent : CompositePresentationEvent<uint> { }

    public class OCXPlayCompareSearchVideoEvent : CompositePresentationEvent<uint> { }

    public class OCXPlayBriefVideoEvent : CompositePresentationEvent<uint> { }

    public class OCXStopPlayBriefVideoEvent : CompositePresentationEvent<string > { }

    public class ClearPlayVideoByHWndEvent : CompositePresentationEvent<IntPtr> { }
    
    //public class ResumePlayVideoEvent : CompositePresentationEvent<VideoStatusInfo> { }

    public class SearchFinishedEvent : CompositePresentationEvent<SearchResultSummaryV3_1> { }

    //public class SearchResultRecordSelectedEvent : CompositePresentationEvent<Tuple<SearchItem, SearchResultRecord>> { }

    //public class SearchItemImageReceivedEvent : CompositePresentationEvent<SearchImageInfo> { }

    public class SearchBeginEvent : CompositePresentationEvent<SearchItemGroup> { }

    //public class SearchCloseEvent : CompositePresentationEvent<SearchSession> { }

    public class SwitchPageBeginEvent : CompositePresentationEvent<Tuple<uint, uint, string>> { }

    public class BriefObjectPlayBackEvent : CompositePresentationEvent<VodInfo> { }

    public class GotoCompareSearchEvent : CompositePresentationEvent<string> { }

    public class SetCompareImageInfoEvent : CompositePresentationEvent<CompareImageInfo> { }

    public class OpenBriefPlaybackVideoEvent : CompositePresentationEvent<VodInfo> { }

    public class CloseBriefPlaybackVideoEvent : CompositePresentationEvent<string> { }

    public class LogSearchReceivedEvent : CompositePresentationEvent<List<LogSearchResultInfo>> { }

    public class LogSearchBeginingEvent : CompositePresentationEvent<string> { }

    public class LogExportEvent : CompositePresentationEvent<string> { }

    public class SearchVideoFilerChangedEvent : CompositePresentationEvent<SearchResourceResultType> { }

    //public class SearchResoultPlaybackRequestEvent : CompositePresentationEvent<Tuple<SearchResultRecord, SearchType>> { }

    public class VideoDownloadStatusUpdateEvent : CompositePresentationEvent<DownloadInfo> { }

    public class VideoDownloadProgressUpdateEvent : CompositePresentationEvent<DownloadInfo> { }
    public class AddVideoDownloadEvent : CompositePresentationEvent<DownloadInfo> { }
    public class DelVideoDownloadEvent : CompositePresentationEvent<DownloadInfo> { }
    public class FinishVideoDownloadEvent : CompositePresentationEvent<DownloadInfo> { }

    public class ShowDownloadListFormEvent : CompositePresentationEvent<string> { }
    //public class PicturSavedEvent : CompositePresentationEvent<PictureSaveInfo> { }

    public class CrowdRealTimeEvent : CompositePresentationEvent<CrowdInfo> { }
    public class CrowdEvent : CompositePresentationEvent<List<CrowdInfo>> { }
    public class CrowdReportEvent : CompositePresentationEvent<List<CrowdStatistic>> { }
    
    public class DeleteResourceEvent : CompositePresentationEvent<List<int>>
    {

    }

    public class SearchLogEvent : CompositePresentationEvent<LogReqInfo>
    {

    }

    public class SingleOrMixModeSwitchEvent : CompositePresentationEvent<bool>
    {

    }

    public class ClearSearchEvent : CompositePresentationEvent<object>
    {

    }

    public class PlayResourceEvent : CompositePresentationEvent<PlayResourceInfo>
    {

    }

    public class CompareDrawModeChangeEvent : CompositePresentationEvent<E_VDA_SEARCH_MOVE_OBJ_RANGE_FILTER_TYPE>
    {

    }

    public class UserLoginEvent : CompositePresentationEvent<LoginToken>
    {
    }

    public class UserLogOutEvent : CompositePresentationEvent<object>
    {
    }

    public class LoginEvent : CompositePresentationEvent<bool> { }

    public class OCXAddFileEvent : CompositePresentationEvent<OCXAddFileInfo>
    {
    }

    public class ExpandLocalNodeEvent : CompositePresentationEvent<object>
    {
    }

    public class SetPlaywndFullEvent : CompositePresentationEvent<System.Windows.Forms.PreviewKeyDownEventArgs>
    {
    }

    public class PausePlayEvent : CompositePresentationEvent<System.Windows.Forms.PreviewKeyDownEventArgs>
    {
    }


    public class OpenImportNVRVideosFormEvent : CompositePresentationEvent<NVRAndChannelsInfo>
    {

    }

    public class NVRAndChannelsInfo
    {
        public string IP{get;set;}

        public int Port{get;set;}

        public string UserName{get;set;}
        
        public string Password{get;set;}
        
        public int Type{get;set;}

        public string Channels { get; set; }
    }


    public struct OCXAddFileInfo
    {
        public int id;
        public string name;
    }
    public class PlayResourceInfo
    {
        private Int32 _hrItem;		//资源节点句柄
        private string _szLocation;	//地点
        private Int64 _nTargetTs;			//目标时间
        private Int64 _nTargetAppearTs;			//目标出现时间
        private Int64 _nTargetDisappearTs;		//目标结束时间

        public Int32 hrItem
        {
            get { return _hrItem; }
            set { _hrItem = value; }
        }

        public string szLocation
        {
            get { return _szLocation; }
            set { _szLocation = value; }
        }

        public Int64 nTargetTs
        {
            get { return _nTargetTs; }
            set { _nTargetTs = value; }
        }

        public Int64 nTargetAppearTs
        {
            get { return _nTargetAppearTs; }
            set { _nTargetAppearTs = value; }
        }

        public Int64 nTargetDisappearTs
        {
            get { return _nTargetDisappearTs; }
            set { _nTargetDisappearTs = value; }
        }
    }

    public class VideoClosedEventArgs : EventArgs
    {
        public IntPtr WindowHandle { get; set; }

        public VideoClosedEventArgs(IntPtr playHandle)
            : base()
        {
            WindowHandle = playHandle;
        }
    }
}
