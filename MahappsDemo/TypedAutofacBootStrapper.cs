using Autofac;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MahappsDemo
{
    public class TypedAutofacBootStrapper<TViewModel> : BootstrapperBase
    {
        private Autofac.IContainer _container;
        protected Autofac.IContainer Container { get { return _container; } }

        protected override void Configure()
        {
            var builder = new ContainerBuilder();

            // register view model
            builder.RegisterAssemblyTypes(AssemblySource.Instance.ToArray())
              .Where(type => type.Name.EndsWith("ViewModel"))
              .AsSelf()
              .InstancePerDependency();

            // register views
            builder.RegisterAssemblyTypes(AssemblySource.Instance.ToArray())
              .Where(type => type.Name.EndsWith("View"))
              .Where(type => !(string.IsNullOrWhiteSpace(type.Namespace)) && type.Namespace.EndsWith("Views"))
              .AsSelf()
              .InstancePerDependency();

            builder.Register<IWindowManager>(c => new WindowManager()).InstancePerLifetimeScope();
            builder.Register<IEventAggregator>(c => new EventAggregator()).InstancePerLifetimeScope();

            ConfigureContainer(builder);

            _container = builder.Build();

        }
         
        protected override object GetInstance(Type serviceType, string key)
        {
          if (string.IsNullOrWhiteSpace(key))
          {
            if (Container.IsRegistered(serviceType))
              return Container.Resolve(serviceType);
          }
          else
          {
              if (Container.IsRegistered(serviceType))
              {
                  return Container.Resolve(serviceType);
              }
          }
          throw new Exception(string.Format("Could not locate any instances of contract {0}.", key ?? serviceType.Name));
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
          return Container.Resolve(typeof(IEnumerable<>).MakeGenericType(serviceType)) as IEnumerable<object>;
        }

        protected override void BuildUp(object instance)
        {
          Container.InjectProperties(instance);
        }

        protected virtual void ConfigureContainer(ContainerBuilder builder)
        {
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<TViewModel>();
        }
  }
}
