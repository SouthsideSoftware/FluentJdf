using System;
using Infrastructure.Core.Logging;

namespace Infrastructure.Logging.NLog
{
    /// <summary>
    /// Implementation of ILogProvider for NLog
    /// </summary>
    public class NLogLogProvider : ILogProvider
    {
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
