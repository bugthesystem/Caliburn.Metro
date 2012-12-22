using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using Caliburn.Micro;

namespace Caliburn.Metro
{
    public class CaliburnMetroCompositionBootstrapper<TRootViewModel> : Bootstrapper<TRootViewModel>
    {
        protected CompositionContainer Container { get; private set; }

        protected override void Configure()
        {
            Container = new CompositionContainer(new AggregateCatalog(AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>()));
            ConfigureBootstrapper();

            CompositionBatch batch = new CompositionBatch();
            ConfigureContainer(batch);
            batch.AddExportedValue(Container);

            Container.Compose(batch);
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            if (serviceType == null) throw new ArgumentNullException("serviceType");
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            var exports = Container.GetExportedValues<object>(contract);

            if (exports.Any())
            {
                return exports.First();
            }

            throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
        }

        protected virtual void ConfigureBootstrapper()
        {
        }

        protected virtual void ConfigureContainer(CompositionBatch builder)
        {
        }
    }
}