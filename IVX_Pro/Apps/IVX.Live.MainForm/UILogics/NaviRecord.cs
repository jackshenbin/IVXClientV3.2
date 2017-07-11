using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVX.DataModel;

namespace IVX.Live.MainForm.UILogics
{
    public class NaviRecord
    {
        /// <summary>
        /// 每个功能大类对应的最近打开的小类
        /// </summary>
        private Dictionary<UIFuncItemInfo, UIFuncItemInfo> m_DTCategory2SubItem;

        /// <summary>
        /// 功能大类对应的全部小类
        /// </summary>
        private Dictionary<UIFuncItemInfo, List<UIFuncItemInfo>> m_DTCategory2SubItems;

        private Dictionary<UIFuncItemInfo, int> m_DTCategory2SplitPosition;

        private UIFuncItemInfo m_curFuncItemInfo;

        public NaviRecord()
        {
            m_DTCategory2SplitPosition = new Dictionary<UIFuncItemInfo, int>();
            m_DTCategory2SplitPosition.Add(UIFuncItemInfo.CROWDALARM, 220);
            m_DTCategory2SplitPosition.Add(UIFuncItemInfo.CROWDPLAY, 220);
            m_DTCategory2SplitPosition.Add(UIFuncItemInfo.CROWDQUERY, 220);


            m_DTCategory2SubItem = new Dictionary<UIFuncItemInfo, UIFuncItemInfo>();

            m_DTCategory2SubItems = new Dictionary<UIFuncItemInfo, List<UIFuncItemInfo>>();
        }

        /// <summary>
        /// 如果传入的是功能大类, 返回该大类最近操作过的该大类下的小类功能
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public UIFuncItemInfo GetSubItem(UIFuncItemInfo item)
        {
            UIFuncItemInfo subItem = item;

            if (item != null && m_DTCategory2SubItem.ContainsKey(item))
            {
                subItem = m_DTCategory2SubItem[item];
            }

            return subItem;
        }

        public void RegisterSubItem(UIFuncItemInfo subItem)
        {
            if (subItem != null && m_curFuncItemInfo != subItem)
            {
                if (subItem.Function == UIFunctionEnum.NewTask)
                {
                    return;
                }

                foreach (UIFuncItemInfo item in m_DTCategory2SubItems.Keys)
                {
                    if (m_DTCategory2SubItems[item].Contains(subItem))
                    {
                        m_DTCategory2SubItem[item] = subItem;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 更新大类对应最近使用小类功能字典
        /// </summary>
        /// <param name="subItem"></param>
        public void RegisterSubItem(UIFuncItemInfo subItem, int oldSplitPosition, out int splitPosition)
        {
            splitPosition = -1;
            if (subItem != null && m_curFuncItemInfo != subItem)
            {
                RegisterSubItem(subItem);

                // 需要记住旧的 splitposition
                UIFuncItemInfo catItemCur = null;
                UIFuncItemInfo catItemNew = subItem.Parent ?? subItem;
                if (m_curFuncItemInfo != null)
                {

                    catItemCur = m_curFuncItemInfo.Parent ?? m_curFuncItemInfo;
                    if (catItemCur != catItemNew)
                    {
                        if (!m_DTCategory2SplitPosition.ContainsKey(catItemCur))
                        {
                            m_DTCategory2SplitPosition.Add(catItemCur, oldSplitPosition);
                        }
                        else
                        {
                            m_DTCategory2SplitPosition[catItemCur] = oldSplitPosition;
                        }

                    }
                }
                if (m_DTCategory2SplitPosition.ContainsKey(catItemNew))
                {
                    splitPosition = m_DTCategory2SplitPosition[catItemNew];
                }
                m_curFuncItemInfo = subItem;
            }
        }
        //public void RegisterSubItem(UIFuncItemInfo subItem, int oldSplitPosition, out int splitPosition)
        //{
        //    splitPosition = -1;
        //    if (subItem != null && m_curFuncItemInfo != subItem)
        //    {
        //        RegisterSubItem(subItem);

        //        // 需要记住旧的 splitposition
        //        if (m_curFuncItemInfo != null)
        //        {
        //            UIFuncItemInfo catItemCur = m_curFuncItemInfo.Parent ?? m_curFuncItemInfo;
        //            UIFuncItemInfo catItemNew = subItem.Parent ?? subItem;

        //            if (catItemCur != catItemNew)
        //            {
        //                if (!m_DTCategory2SplitPosition.ContainsKey(catItemCur))
        //                {
        //                    m_DTCategory2SplitPosition.Add(catItemCur, oldSplitPosition);
        //                }
        //                else
        //                {
        //                    m_DTCategory2SplitPosition[catItemCur] = oldSplitPosition;
        //                }

        //                if (m_DTCategory2SplitPosition.ContainsKey(catItemNew))
        //                {
        //                    splitPosition = m_DTCategory2SplitPosition[catItemNew];
        //                }
        //            }
        //        }
        //        m_curFuncItemInfo = subItem;
        //    }
        //}

    }
}
