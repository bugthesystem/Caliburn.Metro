Caliburn.Metro
==============

[![Support via Gratipay](https://cdn.rawgit.com/gratipay/gratipay-badge/2.3.0/dist/gratipay.svg)](https://gratipay.com/ziyasal/)  


Library combines [MahApps.Metro](http://mahapps.com/MahApps.Metro/) and [Caliburn.Micro](http://caliburnmicro.codeplex.com/) for Metro UI styled WPF applications 

It provides [Caliburn.Micro](http://caliburnmicro.codeplex.com/) **Bootstrapper** and [MahApps.Metro](http://mahapps.com/MahApps.Metro/) **MetroWindow** integrated  **WindowManager**. Also project contains [Autofac](http://code.google.com/p/autofac/) **Bootstrapper** integration. 


* [Nuget Package - Caliburn.Metro](https://nuget.org/packages/Caliburn.Metro)
* [Nuget Package - Caliburn.Metro.Autofac](https://nuget.org/packages/Caliburn.Metro.Autofac)

**Default Setup**
[Demo application](https://github.com/ziyasal/Caliburn.Metro/tree/master/Caliburn.Metro.Sample)
```csharp
  //Basic AppBootstrapper
  public class AppBootstrapper : CaliburnMetroCompositionBootstrapper<AppViewModel>
  {

  }
    
  //AppWindowManager with custom Main window
  [Export(typeof(IWindowManager))]
  public class AppWindowManager : MetroWindowManager
  {
      public override MetroWindow CreateCustomWindow(object view, bool windowIsView)
      {
          if (windowIsView)
          {
              return view as MainWindowContainer;
          }

          return new MainWindowContainer
          {
            Content = view
          };
      }
  }
```

**Autofac Bootstrapper Setup**
[Demo application](https://github.com/ziyasal/Caliburn.Metro/tree/master/Caliburn.Metro.Autofac.Sample)
```csharp
//Autofac AppBootstrapper
public class AppBootstrapper : CaliburnMetroAutofacBootstrapper<AppViewModel>
{
    protected override void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterType<AppWindowManager>().As<IWindowManager>().SingleInstance();
        var assembly = typeof(AppViewModel).Assembly;
        builder.RegisterAssemblyTypes(assembly)
            .Where(item => item.Name.EndsWith("ViewModel") && item.IsAbstract == false)
            .AsSelf()
            .SingleInstance();
    }
}

//AppWindowManager with custom Main window
public class AppWindowManager : MetroWindowManager
{
    public override MetroWindow CreateCustomWindow(object view, bool windowIsView)
    {
        if (windowIsView)
        {
            return view as MainWindowContainer;
        }
        return new MainWindowContainer
        {
            Content = view
        };
    }
}
```



**License**

Code and documentation are available according to the MIT License (see [LICENSE](https://github.com/ziyasal/Caliburn.Metro/blob/master/LICENSE)).
