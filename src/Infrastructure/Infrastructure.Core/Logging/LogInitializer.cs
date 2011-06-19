using System;
using System.Net.Mime;
using Infrastructure.Core.Helpers;
using Infrastructure.Core.Resources;

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
                if (!isInitalized) {
                    HookUnhandledExceptionEvents();
                    logger.Debug("Initializing logging.");
                    ApplicationInformation.LogApplicationInfo();
                    isInitalized = true;
                }
            }
        }

        //todo: How will this work with windows apps?  There are some things that will slip through.  How about ASP.NET?
        static void HookUnhandledExceptionEvents() {
            AppDomain.CurrentDomain.UnhandledException += (o, e) => {
                try {
                    if (e.ExceptionObject is Exception) {
                        logger.Fatal(Messages.LogInitializer_HookUnhandledExceptionEvents_UnhandledException, e.ExceptionObject as Exception);
                    }
                    else {
                        logger.Fatal(Messages.LogInitializer_HookUnhandledExceptionEvents_Unhandled_UnknownException);
                    }
                } catch {
                    //can't do anything here.  We're already catching an unhandled exception.
                }
            };
        }
    }
}