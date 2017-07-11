//===================================================================================
// Microsoft patterns & practices
// Composite Application Guidance for Windows Presentation Foundation and Silverlight
//===================================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===================================================================================
using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace Microsoft.Practices.Prism.Events
{
    /// <summary>
    /// Wraps the Application Dispatcher.
    /// </summary>
    public class DefaultDispatcher : IDispatcherFacade
    {
        /// <summary>
        /// Forwards the BeginInvoke to the current application's <see cref="Dispatcher"/>.
        /// </summary>
        /// <param name="method">Method to be invoked.</param>
        /// <param name="arg">Arguments to pass to the invoked method.</param>
        public void BeginInvoke(Delegate method, object arg)
        {
            if (System.Windows.Application.Current != null)
            {
                System.Windows.Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, method, arg);
            }
        }
    }

    /// <summary>
    /// Wraps the Application Dispatcher.
    /// </summary>
    public class WinFormUIDispatcher : IDispatcherFacade
    {

        /// <summary>
        /// winform下的主窗口或是ocx方式下的预定义窗口
        /// </summary>
        public Control InvokeCtrl
        {
            get 
            {
                Control invokeCtrl = null;
                if (System.Windows.Forms.Application.OpenForms != null
                   && System.Windows.Forms.Application.OpenForms.Count > 0)
                {
                    invokeCtrl = System.Windows.Forms.Application.OpenForms[0];
                }
                else
                {
                    // 作为OCX使用时，没有Form
                    object obj = AppDomain.CurrentDomain.GetData("OCXContainer");
                    if (obj != null)
                    {
                        invokeCtrl = obj as Control;
                    }
                }
                return invokeCtrl;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public WinFormUIDispatcher()
        {
            Control invokeCtrl = InvokeCtrl;

            Debug.Assert(invokeCtrl != null, "No invoke control found in WinformDispatcher");
        }

        /// <summary>
        /// Forwards the BeginInvoke to the current application's <see cref="Dispatcher"/>.
        /// </summary>
        /// <param name="method">Method to be invoked.</param>
        /// <param name="arg">Arguments to pass to the invoked method.</param>
        public void BeginInvoke(Delegate method, object arg)
        {
            if (InvokeCtrl != null)
            {
                if (InvokeCtrl.InvokeRequired)
                {
                    InvokeCtrl.BeginInvoke(method, arg);
                }
                else
                {
                    method.DynamicInvoke(arg);
                }
            }
        }
    }
}