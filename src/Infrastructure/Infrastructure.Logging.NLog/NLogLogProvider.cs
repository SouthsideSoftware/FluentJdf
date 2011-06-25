using System;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Logging;
using NLog.Config;

namespace Infrastructure.Logging.NLog
{
    /// <summary>
    /// Implementation of ILogProvider for NLog
    /// </summary>
    public class NLogLogProvider : ILogProvider
    {
        /// <summary>
        /// Constructor that gets nlog configuration from NLog.config.
        /// </summary>
        public NLogLogProvider(){}

        /// <summary>
        /// Constructor that gets nlog configuration from configuration object.
        /// </summary>
        /// <param name="config"></param>
        public NLogLogProvider(LoggingConfiguration config)
        {
            ParameterCheck.ParameterRequired(config, "config");

            global::NLog.LogManager.Configuration = config;
        }
        /// <summary>
        /// Gets the ILog implementation for the type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ILog GetLogger(Type type) {
            return new NLogLog(global::NLog.LogManager.GetLogger(type.FullName));
        }

        /// <summary>
        /// Gets the ILog implementation for the key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ILog GetLogger(string key) {
            return new NLogLog(global::NLog.LogManager.GetLogger(key));
        }
    }
}
