using System.Diagnostics.Contracts;
using Infrastructure.Core;
using Infrastructure.Core.CodeContracts;
using NLog.Config;

namespace Infrastructure.Logging.NLog
{
    /// <summary>
    /// Extensions for working with configuration.
    /// </summary>
    public static class ConfigurationExtension
    {
        /// <summary>
        /// Log using NLog (default settings)
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static Configuration LogWithNLog(this Configuration configuration)
        {
            ParameterCheck.ParameterRequired(configuration, "configuration");

            configuration.LogWith(new NLogLogProvider());
            return configuration;
        }

        /// <summary>
        /// Log using NLog (default settings)
        /// </summary>
        /// <returns></returns>
        public static Configuration LogWithNLog(this Configuration configuration, LoggingConfiguration loggingConfiguration)
        {
            ParameterCheck.ParameterRequired(configuration, "configuration");
            ParameterCheck.ParameterRequired(loggingConfiguration, "loggingConfiguration");

            configuration.LogWith(new NLogLogProvider(loggingConfiguration));
            return configuration;
        }
    }
}
