using System;

namespace Infrastructure.Core.Logging {
    /// <summary>
    /// Log manager.
    /// </summary>
    public static class LogManager {
        static ILogProvider logProvider;

        static ILogProvider LogProvider {
            get { return logProvider ?? (logProvider = Configuration.Settings.LogProvider); }
        }

        /// <summary>
        /// Gets the ILog implementation for the type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ILog GetLogger(Type type) {
            return LogProvider.GetLogger(type);
        }

        /// <summary>
        /// Gets the ILog implementation for the key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static ILog GetLogger(string key) {
            return LogProvider.GetLogger(key);
        }
    }
}