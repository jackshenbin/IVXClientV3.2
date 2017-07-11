using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;

namespace IVX.Live.ViewModel
{
    public class EditHistoryAnalyseParamViewModel
    {
        public TaskMSSInfoV3_1 GetMssTaskInfo(uint taskid)
        {
            List<TaskMSSInfoV3_1> mssinfo = Framework.Container.Instance.CommService.QUERY_TASK_MSS(new List<uint>() { taskid });
            if (mssinfo != null && mssinfo.Count > 0)
                return mssinfo[0];
            else

                return null;
        }


    }
}
