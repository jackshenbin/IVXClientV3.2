﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVX.DataModel
{
    public static class ModelExtension
    {
        public static SearchItem ToSearchItem(this TaskUnitInfo taskUnit, PageInfoBase pageInfo)
        {
            SearchItem searchItem = new SearchItem()
            {
                TaskUnitId = taskUnit.TaskUnitID,
                PageInfo = pageInfo,
                CameraId = taskUnit.CameraId,
                CameraCode = taskUnit.CameraCode
            };
            return searchItem;
        }

    }
}
