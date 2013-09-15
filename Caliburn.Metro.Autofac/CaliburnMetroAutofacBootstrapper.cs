using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Metro.Core;
using Caliburn.Micro;
using Autofac;
using Autofac.Core;

namespace Caliburn.Metro.Autofac
{
    public class CaliburnMetroAutofacBootstrapper<TRootModel> : AutofacBootstrapper<TRootModel>
    {
        protected override void ConfigureBootstrapper()
        {
            AutoSubscribeEventAggegatorHandlers = false;
            CreateWindowManager = () => (IWindowManager)new MetroWindowManager();
            CreateEventAggregator = () => (IEventAggregator)new EventAggregator();

            EnforceNamespaceConvention = true;
            ViewModelBaseType = typeof(System.ComponentModel.INotifyPropertyChanged);
        }
    }
}