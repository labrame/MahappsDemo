using Caliburn.Micro.Autofac;

namespace MahappsDemo
{
    public class AppBootstrapper : Bootstrapper<ShellViewModel>
    {
      protected override void ConfigureBootstrapper()
        {  
            base.ConfigureBootstrapper();
            EnforceNamespaceConvention = false;
            ViewModelBaseType = typeof(IShell);
        }
    }
}
