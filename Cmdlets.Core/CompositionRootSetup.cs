using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TIKSN.Analytics.Logging;
using TIKSN.DependencyInjection;

namespace TIKSN.Cmdlets.Core
{
    public class CompositionRootSetup : AutofacCompositionRootSetupBase
    {
        private static Lazy<IServiceProvider> lazyServiceProvider = new Lazy<IServiceProvider>(
            () => new CompositionRootSetup(ConfigurationRootSetup.ConfigurationRoot).CreateServiceProvider(),
            false);

        public CompositionRootSetup(IConfigurationRoot configurationRoot) : base(configurationRoot)
        {
        }

        public static IServiceProvider ServiceProvider => lazyServiceProvider.Value;

        protected override void ConfigureContainerBuilder(ContainerBuilder builder)
        {
            builder.RegisterType<LoggingSetup>().As<LoggingSetupBase>();
        }

        protected override void ConfigureOptions(IServiceCollection services, IConfigurationRoot configuration)
        {
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
        }
    }
}