using Microsoft.Extensions.Configuration;
using System;
using TIKSN.Configuration;

namespace TIKSN.Cmdlets
{
    public class ConfigurationRootSetup : ConfigurationRootSetupBase
    {
        private static Lazy<IConfigurationRoot> lazyConfigurationRoot = new Lazy<IConfigurationRoot>(() => new ConfigurationRootSetup().GetConfigurationRoot(), false);

        public static IConfigurationRoot ConfigurationRoot { get { return lazyConfigurationRoot.Value; } }
    }
}