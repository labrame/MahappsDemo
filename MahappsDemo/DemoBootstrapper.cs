using Caliburn.Micro;

namespace MahappsDemo
{
    public class DemoBootstrapper : TypedAutofacBootStrapper<ShellViewModel>
    {
        public DemoBootstrapper()
        {
            Initialize();
        }

        protected override void ConfigureContainer(Autofac.ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
        }
    }
}
