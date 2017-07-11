using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;
using System.ComponentModel;
using IVX.Live.SearchServices;

namespace IVX.Live.ViewModel
{
    public class FaceAlarmControlViewModel
    {

        public void AddFaceAlarmControl(string cameraID, uint controlThreshold, uint blackListHandle, uint controlNation = 1000, uint controlSex = 3, uint beginAge = 0, uint endAge = 0)
        {
            E_VIDEO_ANALYZE_TYPE type = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE_DYNAMIC;
            var rs = Framework.Container.Instance.CommService.GET_RESULT_STORE_LIST(cameraID, type);
            if (rs != null)
            {
                SearchServices.SearchServices m_SearchService = new SearchServices.SearchServices("http://{0}:{1}/?matchservice.wsdl");
                m_SearchService.Init(rs.StoreIP, rs.StortPort);

                var sublist = m_SearchService.ADD_FACE_CONTORL_DATA(cameraID, controlThreshold, blackListHandle, controlNation, controlSex, beginAge, endAge);
            }
        }

        public DataTable FaceControlList
        {
            get
            {
                DataTable t = new DataTable();
                var key = t.Columns.Add("ID", typeof(int)); ;
                t.PrimaryKey = new DataColumn[] { key };
                t.Columns.Add("CameraID");
                t.Columns.Add("ControlThreshold");
                t.Columns.Add("BlackListHandle");
                t.Columns.Add("ControlNation");
                t.Columns.Add("ControlSex");
                t.Columns.Add("ControlAge");
                t.Columns.Add("FaceControlInfo", typeof(FaceControlInfo));

                var rslist = Framework.Container.Instance.CommService.GET_RESULT_STORE_LIST(E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE_DYNAMIC);
                List<FaceControlInfo> list = new List<FaceControlInfo>();
                if(rslist!=null && rslist.Count>0)
                {
                    foreach (var rs in rslist)
                    {
                        SearchServices.SearchServices m_SearchService = new SearchServices.SearchServices("http://{0}:{1}/?matchservice.wsdl");
                        m_SearchService.Init(rs.StoreIP, rs.StortPort);

                        try
                        {
                            var sublist = m_SearchService.GET_FACE_CONTORL_DATA();
                            if (sublist != null && sublist.Count > 0)
                                list.AddRange(sublist);
                        }
                        catch (SDKCallException ex)
                        {
                            if (ex.ErrorCode != (uint)SDKCallExceptionCode.NoSuchResult)
                                throw ex;
                        }
                    }
                }
                //FaceControlInfo info = new FaceControlInfo()
                //{
                //    FaceControlHandle = 1,
                //    ControlThreshold = 80,
                //    BlackListHandle = new List<uint>() { 1 },
                //    CameraID = "cam1",
                //    ControlNation = new List<E_PEOPLE_NATION>() { E_PEOPLE_NATION.汉族},
                //    ControlSex =  E_MOVE_OBJ_PEOPLE_GENDER_TYPE.E_MOVE_OBJ_PEOPLE_GENDER_TYPE_MALE,
                //    BeginAge =  E_MOVE_OBJ_PEOPLE_AGE_TYPE.E_MOVE_OBJ_PEOPLE_AGE_TYPE_INFANCY,
                //    EndAge =  E_MOVE_OBJ_PEOPLE_AGE_TYPE.E_MOVE_OBJ_PEOPLE_AGE_TYPE_AGEDNESS,
                //};
                //list.Add(info);
                if (list != null && list.Count>0)
                {
                    foreach (var item in list)
                    {
                        StringBuilder sbblack=new StringBuilder();
                        item.BlackListHandle.ForEach(it => sbblack.Append(it.ToString() + ","));
                        StringBuilder sbnation = new StringBuilder();
                        item.ControlNation.ForEach(it=>sbnation.Append( it.ToString()+","));
                        
                        //string age = Constant.PeopleAgeTypeInfos.SingleOrDefault(it => it.Type == item.BeginAge).Name + "-" + Constant.PeopleAgeTypeInfos.SingleOrDefault(it => it.Type == item.EndAge).Name;
                        string age =string.Format("{0}-{1}",item.BeginAge,item.EndAge);
                        string sex = Constant.PeopleSexTypeInfos.SingleOrDefault(it => it.Type == item.ControlSex).Name;
                        t.Rows.Add(item.FaceControlHandle, item.CameraID, item.ControlThreshold, sbblack.ToString().Trim( ',' ), sbnation.ToString().Trim(','), sex, age, item);
                    }
                }
                return t;
            }
        }


        public void DelFaceControlByID(string cameraID, uint id)
        {
            E_VIDEO_ANALYZE_TYPE type = E_VIDEO_ANALYZE_TYPE.E_ANALYZE_FACE_DYNAMIC;
            var rs = Framework.Container.Instance.CommService.GET_RESULT_STORE_LIST(cameraID, type);
            if (rs != null)
            {
                SearchServices.SearchServices m_SearchService = new SearchServices.SearchServices("http://{0}:{1}/?matchservice.wsdl");
                m_SearchService.Init(rs.StoreIP, rs.StortPort);

                m_SearchService.DEL_FACE_CONTORL_DATA(id);
            }
        }
    }
}
