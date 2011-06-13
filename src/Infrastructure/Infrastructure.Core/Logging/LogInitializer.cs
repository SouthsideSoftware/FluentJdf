using Infrastructure.Core.Helpers;

namespace Infrastructure.Core.Logging
{
    /// <summary>
    /// Helpers for log4net logging
    /// </summary>
    public static class LogInitializer
    {
        static readonly ILog logger = LogManager.GetLogger(typeof(LogInitializer));

        static bool isInitalized;
        static readonly object locker = new object();

        /// <summary>
        /// Initialize the log4net system.  Watch the configuration file for changes.
        /// </summary>
        public static void Initialize()
        {
            lock (locker)
            {
                if (!isInitalized)
                {
                    logger.Debug("Initializing logging.");
                    ApplicationInformation.LogApplicationInfo();
                    isInitalized = true;
                }
            }
        }
    }
}