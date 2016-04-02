using Microsoft.Practices.Unity;
using MigraPle.Api.Configurations;
using MigraPle.Windows.Facade;
using MigraPle.Windows.Proxy;
using MigraPle.Windows.Proxy.Http;

namespace MigraPle.Api.Windows.Resolver
{
    public class KernelResolver
    {
        public void ConfigureKernel(IUnityContainer container)
        {
            container.RegisterType<ILoginFacade,LoginFacade>();
            container.RegisterType<ILoginProxy,LoginProxy>();
            container.RegisterType<IConnectionProxy,ConnectionProxy>();
            container.RegisterType<IHttpClientGetter,HttpClientGetter>();
            container.RegisterType<IConfigurationGetter, ConfigurationGetter>();
        }
    }
}
