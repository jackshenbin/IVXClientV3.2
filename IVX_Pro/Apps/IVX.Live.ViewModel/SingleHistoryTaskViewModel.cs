using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IVX.DataModel;

namespace IVX.Live.ViewModel
{
    public class SingleHistoryTaskViewModel
    {
        public SingleHistoryTaskViewModel()
        {
        }

        public int CalcProgress(IVX.DataModel.E_VDA_TASK_STATUS stat, int progress)
        {
            int totalprogress = 0;
            switch (stat)
            {
                case E_VDA_TASK_STATUS.E_TASK_STATUS_NOUSE:
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_WAITING:
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_WAIT:
                    totalprogress = 100;
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_EXECUTING:
                    totalprogress = 200 + (int)(progress / 5);
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_IMPORT_FAILED:
                    totalprogress = 0 ;
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_WAIT:
                    totalprogress = 400 ;
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_EXECUTING:
                    totalprogress = 500 + (int)(progress*2 / 5);
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FINISH:
                    totalprogress = 1000;
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_FAILED:
                    totalprogress = 500;
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_ANALYSE_SUSPEND:
                    totalprogress = 0;
                    break;
                case E_VDA_TASK_STATUS.E_TASK_STATUS_BEEN_DELETE:
                    totalprogress = 0;
                    break;
                default:
                    break;
            }
            return totalprogress;
        }
    }
}
