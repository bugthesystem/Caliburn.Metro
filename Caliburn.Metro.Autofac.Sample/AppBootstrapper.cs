using Autofac;
using Caliburn.Micro;

namespace Caliburn.Metro.Autofac.Sample
{
    public class AppBootstrapper : CaliburnMetroAutofacBootstrapper<AppViewModel>
    {
        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<AppWindowManager>().As<IWindowManager>().SingleInstance();
            var assembly = typeof(AppViewModel).Assembly;
            builder.RegisterAssemblyTypes(assembly).Where(item => item.Name.EndsWith("ViewModel") && item.IsAbstract == false).AsSelf().SingleInstance();
        }
    }
}
