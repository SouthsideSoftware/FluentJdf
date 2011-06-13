using System;
using System.IO;
using System.Reflection;
using Infrastructure.Core.Logging;

namespace Infrastructure.Core.Helpers
{
    /// <summary>
    /// Common information about the application
    /// </summary>
    public static class ApplicationInformation
    {
        private static readonly string name;
        private static readonly string version;
        private static readonly string fileVersion;
        static ILog logger;

        /// <summary>
        /// Use this in code so that the logger is not used until after
        /// the log provider is initialized by configuration.  Otherwise, you will always get 
        /// the null logger provider.
        /// </summary>
        static ILog Logger
        {
            get
            {
                if (logger == null)
                {
                    logger = LogManager.GetLogger(typeof(ApplicationInformation));
                }
                return logger;
            }
        }

        static ApplicationInformation()
        {
            var assembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
            version = assembly.GetName().Version.ToString();
            name = "Unknown";
            fileVersion = "Unknown";

            foreach (object customAttribute in assembly.GetCustomAttributes(false))
            {
                if (customAttribute is AssemblyProductAttribute)
                {
                    name = ((AssemblyProductAttribute)customAttribute).Product;
                }
                if (customAttribute is AssemblyFileVersionAttribute)
                {
                    fileVersion = (customAttribute as AssemblyFileVersionAttribute).Version;
                }
            }
        }

        /// <summary>
        /// Logs information about the application to the configured loggers.
        /// </summary>
        public static void LogApplicationInfo()
        {
            Logger.DebugFormat("{0} Assembly Version {1} File Version {2}", Name,
                                Version, FileVersion);
        }

        /// <summary>
        /// Gets the name of the application as contained in the AssemblyProduct attribute
        /// of the entry assembly.
        /// </summary>
        public static string Name { get { return name; } }

        /// <summary>
        /// Gets the version of the application as contained in the AssemblyVersion attribute
        /// of the entry assembly.
        /// This is the value used by .NET to check for compatibility with callers.
        /// </summary>
        public static string Version { get { return version; } }

        /// <summary>
        /// Gets the file version of the application as contained in the AssemblyFileVersion attribute
        /// of the entry assembly.
        /// This is the library version with the build number.  Build number is not relevant
        /// when checking for compatibility.
        /// </summary>
        public static string FileVersion { get { return fileVersion; } }

        /// <summary>
        /// Gets the application directory.
        /// </summary>
        public static string Directory { get { return AppDomain.CurrentDomain.SetupInformation.ApplicationBase; } }

        /// <summary>
        /// Gets a boolean indicating whether of not the current application is a web application.
        /// </summary>
        /// <remarks>The application is considered a web application of the configuration file
        /// name is web.config.</remarks>
        public static bool IsWebApplication
        {
            get
            {
                string configFile = Path.GetFileName(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                return (string.Compare(configFile, "web.config", true) == 0);
            }
        }
    }
}
