using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;

namespace IVX.Live.ViewModel
{
    public class GisMapViewModel
    {

        private List<CameraInfoV3_1> m_cameraList;

        public List<CameraInfoV3_1> CameraList
        {
            get 
            {
                if(m_cameraList==null)
                    m_cameraList = Framework.Container.Instance.CommService.GET_CAMERA_LIST();
                return m_cameraList; 
            }
        }
        
    }
}