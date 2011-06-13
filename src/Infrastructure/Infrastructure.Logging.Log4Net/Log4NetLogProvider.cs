using System;
using System.IO;
using Infrastructure.Core.Logging;
using log4net.Config;

namespace Infrastructure.Logging.Log4Net
{
    /// <summary>
    /// Implementation of ILogProvider for Log4Net.
    /// </summary>
    public class Log4NetLogProvider : ILogProvider
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <remarks>Reads config from log4net.config.</remarks>
        public Log4NetLogProvider() {
            XmlConfigurator.ConfigureAndWatch(
                        new FileInfo(Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "log4net.config")));
        }
        /// <summary>
        /// Gets the ILog implementation for the type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ILog GetLogger(Type type) {
            return new Log4NetLog(log4net.LogManager.GetLogger(type));
        }

        /// <summary>
        /// Gets the ILog implementation for the key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ILog GetLogger(string key) {
            return new Log4NetLog(log4net.LogManager.GetLogger(key));
        }
    }
}
