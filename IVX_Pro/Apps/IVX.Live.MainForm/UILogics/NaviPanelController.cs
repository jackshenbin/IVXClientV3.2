using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IVX.DataModel;
using DevExpress.XtraTab;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WinFormAppUtil;

namespace IVX.Live.MainForm.UILogics
{
    public class NaviPanelController : IEventAggregatorSubscriber
    {
        #region Fields

        private UIFuncItemInfo m_CurrentFuncItemInfo;

        private UIFuncItemInfo m_PreviousFuncItemInfo;

        private Control m_tabCtrlContainer;

        #endregion
        
        #region Private helper functions

        private string GetName(UIFunctionEnum funcItem)
        {
            string name = string.Empty;
            switch (funcItem)
            {
                case UIFunctionEnum.CrowdAlarm:
                    name = "事件报警";
                    break;
                case UIFunctionEnum.CrowdPlay:
                    name = "预览";
                    break;
                case UIFunctionEnum.CrowdQuery:
                    name = "查询";
                    break;
                default:
                    break;
            }

            return name;

        }
        
        private XtraUserControl CreateNaviContent(UIFunctionEnum funcItem)
        {
            XtraUserControl ctl = null;
            switch (funcItem)
            {
                case UIFunctionEnum.CrowdAlarm:
                    ctl = new IVX.Live.Crowd.Views.ResourceTree.ucCameraTreeView();
                    break;
                case UIFunctionEnum.CrowdPlay:
                    ctl = new IVX.Live.Crowd.Views.ResourceTree.ucCameraTreeView();
                    break;
                case UIFunctionEnum.CrowdQuery:
                    ctl = new IVX.Live.Crowd.Views.ResourceTree.ucQueryTreeView();
                    break;
                default:
                    break;
            }

            return ctl;

        }
        
        private XtraUserControl GetNaviContent(UIFunctionEnum funcItem)
        {
            XtraUserControl tabTree = null;
            string name = GetName(funcItem);
            if (m_tabCtrlContainer.Controls.ContainsKey(name))
            {
                tabTree = (XtraUserControl)m_tabCtrlContainer.Controls[name];
            }
            else
            {
                tabTree = CreateNaviContent(funcItem);
                if (tabTree != null)
                {
                    tabTree.Dock = DockStyle.Fill;
                    tabTree.Name = GetName(funcItem);
                    tabTree.BorderStyle = BorderStyle.None;
                    m_tabCtrlContainer.Controls.Add(tabTree);
                }
            }
            return tabTree;
        }

        #endregion

        #region Constructors

        public NaviPanelController(Control container)
        {
            m_tabCtrlContainer = container;
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Subscribe(this.OnUINavigatorEvent);
            //Framework.Container.Instance.EvtAggregator.GetEvent<LeaveCaseEvent>().Subscribe(OnLeaveCase);
            WinFormAppUtil.AppContainer.Instance.RegisterEventSubscriber(this);
        }

        #endregion

        #region IEventAggregatorSubscriber implementations

        public void UnSubscribe()
        {
            WinFormAppUtil.AppContainer.Instance.EvtAggregator.GetEvent<NavigateEvent>().Unsubscribe(this.OnUINavigatorEvent);
            //Framework.Container.Instance.EvtAggregator.GetEvent<LeaveCaseEvent>().Unsubscribe(OnLeaveCase);
        }

        #endregion
        
        #region Event handlers

        public void OnUINavigatorEvent(UIFuncItemInfo funcItemInfo)
        {

            funcItemInfo = Container.Instance.NaviRecord.GetSubItem(funcItemInfo);
            Container.Instance.NaviRecord.RegisterSubItem(funcItemInfo);

            // m_tabCtrlContainer.SuspendLayout();

            XtraUserControl tabTree = GetNaviContent(funcItemInfo.Function);
            if (tabTree != null)
            {
                tabTree.BringToFront();
                m_PreviousFuncItemInfo = m_CurrentFuncItemInfo;

                if (funcItemInfo.Function == UIFunctionEnum.Backward)
                {
                    m_PreviousFuncItemInfo = null;
                    m_CurrentFuncItemInfo = m_PreviousFuncItemInfo;
                }
                else
                {
                    m_CurrentFuncItemInfo = funcItemInfo;
                }
            }
            // m_tabCtrlContainer.ResumeLayout();
        }


        #endregion

        internal void Cleanup()
        {
            
        }
    }
}
