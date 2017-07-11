using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Events;
using System.Windows.Forms;
using DataModel;

namespace WinFormAppUtil
{
    public class AppContainer
    {
        #region Fields

        private static AppContainer s_Instance = null;

        private EventAggregator m_evtAggregator = null;

        private CacheManager m_cacheMgr = null;

        private Dictionary<string, ITask> m_DTName2Task = new Dictionary<string, ITask>();

        private IInteractionService m_InteractionService;

        private VVMDataBindings m_vvmDataBindings = null;

        private List<IEventAggregatorSubscriber> m_eventSubscribers = null;

        #endregion

        public EventAggregator EvtAggregator
        {
            get
            {
                return this.m_evtAggregator;
            }
        }

        public CacheManager CacheMgr
        {
            get
            {
                return m_cacheMgr;
            }
        }

        public Control MainControl
        {
            get;
            set;
        }

        public VVMDataBindings VVMDataBindings
        {
            get
            {
                if (m_vvmDataBindings == null)
                {
                    m_vvmDataBindings = new VVMDataBindings();
                }
                return m_vvmDataBindings;
            }
        }

        public string PROGRAM_NAME { get; set; }

        public IInteractionService InteractionService
        {
            get
            {
                if (m_InteractionService == null)
                {
                    m_InteractionService = new InteractionService();
                }
                return m_InteractionService;
            }
            set
            {
                m_InteractionService = value;
            }
        }

        public string RecentLoadVideoFolder { get; set; }

        #region Constructors

        private AppContainer()
        {
            this.m_evtAggregator = new EventAggregator();
            m_eventSubscribers = new List<IEventAggregatorSubscriber>();

            m_cacheMgr = new CacheManager();
            
        }

        public static AppContainer Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = new AppContainer();
                }
                return s_Instance;
            }
        }

        #endregion


        public void RegisterEventSubscriber(IEventAggregatorSubscriber subscriber)
        {
            if (!m_eventSubscribers.Contains(subscriber))
            {
                m_eventSubscribers.Add(subscriber);
            }
        }

        public void UnRegisterEventSubscriber(IEventAggregatorSubscriber subscriber)
        {
            if (m_eventSubscribers.Contains(subscriber))
            {
                subscriber.UnSubscribe();
                m_eventSubscribers.Remove(subscriber);
            }
        }

        public void UnSubscribeEvents()
        {
            if (m_eventSubscribers.Count > 0)
            {
                foreach (IEventAggregatorSubscriber subscriber in m_eventSubscribers)
                {
                    subscriber.UnSubscribe();
                }
                m_eventSubscribers.Clear();
            }
        }


        public void HandleInputValidateFailEvent(NotifyPropertyChangedModel dataSource, string dataMember)
        {
            VVMDataBindings dataBindings = VVMDataBindings;

            Control ctrl = dataBindings.GetControl(dataSource, dataMember);
            if (ctrl != null)
            {
                ctrl.Focus();
            }
        }


    }

}
