using System.Diagnostics.Contracts;
using Infrastructure.Core;

namespace Infrastructure.Logging.Log4Net
{
    /// <summary>
    /// Extensions for working with configuration.
    /// </summary>
    public static class ConfigurationExtension
    {
        /// <summary>
        /// Log using log4net (default settings)
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static Configuration LogWithLog4Net(this Configuration configuration)
        {
            Contract.Requires(configuration != null);

            configuration.LogWith(new Log4NetLogProvider());
            return configuration;
        }
    }
}
