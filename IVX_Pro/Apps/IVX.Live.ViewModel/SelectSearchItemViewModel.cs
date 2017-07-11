using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;

namespace IVX.Live.ViewModel
{
    public class SelectSearchItemViewModel
    {
        public List<SearchItemV3_1> SelectedItems { get; private set; }

        public List<SearchItemV3_1> UnSelectedItems { get; private set; }

        public SelectSearchItemViewModel()
        {
            SelectedItems = new List<SearchItemV3_1>();
            UnSelectedItems = new List<SearchItemV3_1>();
        }
        public List<SearchItemV3_1> GetAllSearchItems()
        {
            List<SearchItemV3_1> list = new List<SearchItemV3_1>();
            Framework.Container.Instance.CommService.GET_TASK_LIST().ForEach(
                item =>
                {
                    if(item.StatusList.Exists(xx=>xx.AlgthmType ==E_VIDEO_ANALYZE_TYPE.E_ANALYZE_MOVEOBJ_PLATFORM || xx.AlgthmType == E_VIDEO_ANALYZE_TYPE.E_ANALYZE_CROSSROAD))
                    {
                        if (item.TaskType == TaskType.History /*&& item.Status == E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FINISH */)
                            list.Add(item.ToSearchItem());
                    }
                }
                );
            Framework.Container.Instance.CommService.GET_CAMERA_LIST().ForEach(
                item =>
                {
                    list.Add(item.ToSearchItem());
                }
                );
            return list;
        }

        
        public void ClearSelection()
        {
            SelectedItems.Clear();
            UnSelectedItems = GetAllSearchItems();
        }

        public void SelectAllSelection()
        {
            SelectedItems = GetAllSearchItems();
            UnSelectedItems.Clear();
        }
        public void AddSelectedItem(SearchItemV3_1 item)
        {
            var sel = SelectedItems.FirstOrDefault(it => it.CameraID == item.CameraID);
            if (sel == null)
                SelectedItems.Add(item);

            var unsel = UnSelectedItems.FirstOrDefault(it => it.CameraID == item.CameraID);
            if (unsel != null)
                UnSelectedItems.Remove(unsel);
        }

        public void RemoveSelectedItem(SearchItemV3_1 item)
        {
            var sel = SelectedItems.FirstOrDefault(it => it.CameraID == item.CameraID);
            if (sel != null)
                SelectedItems.Remove(sel);

            var unsel = UnSelectedItems.FirstOrDefault(it => it.CameraID == item.CameraID);
            if (unsel == null)
                UnSelectedItems.Add(item);
        }

    }
}