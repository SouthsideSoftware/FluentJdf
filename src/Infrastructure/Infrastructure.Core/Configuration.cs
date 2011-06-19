using System;
using System.Diagnostics.Contracts;
using System.Reflection;
using Infrastructure.Core.Container;
using Infrastructure.Core.Logging;

namespace Infrastructure.Core {
    /// <summary>
    /// Configuration of commons
    /// </summary>
    public class Configuration {
        static ILog logger;
        static Configuration settings = new Configuration();

        /// <summary>
        /// Gets the settings instance.
        /// </summary>
        public static Configuration Settings {get { return settings; }}

        IServiceLocator serviceLocator;

        Configuration() {
            LogProvider = new NullLogProvider();
        }

        /// <summary>
        /// Use this in code so that the logger is not used until after
        /// the log provider is initialized by configuration.  Otherwise, you will always get 
        /// the null logger provider.
        /// </summary>
        static ILog Logger {
            get {
                if (logger == null) {
                    logger = LogManager.GetLogger(typeof (Configuration));
                }
                return logger;
            }
        }

        /// <summary>
        /// Gets the service locator configured.
        /// </summary>
        public IServiceLocator ServiceLocator {get { return serviceLocator; }}

        /// <summary>
        /// Gets the configured log provider.
        /// </summary>
        internal ILogProvider LogProvider { get; private set; }

        /// <summary>
        /// Assigns the service locator builder.
        /// </summary>
        public void BuildWith(IServiceLocator serviceLocator) {
            Contract.Requires(serviceLocator != null);

            this.serviceLocator = serviceLocator;
        }

        /// <summary>
        /// Assigns the log provider.
        /// </summary>
        /// <param name="logProvider"></param>
        public void LogWith(ILogProvider logProvider) {
            Contract.Requires(logProvider != null);

            LogProvider = logProvider;
        }

        /// <summary>
        /// Apply the configuration.
        /// </summary>
        public void Configure() {
            LogInitializer.Initialize();
            try {
                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                    try {
                        foreach (Type t in assembly.GetTypes()) {
                            if (typeof (IComponentInstaller).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract &&
                                t.IsPublic) {
                                (Activator.CreateInstance(t) as IComponentInstaller).Install(serviceLocator);
                            }
                        }
                    }
                    catch (ReflectionTypeLoadException tle) {
                        Logger.ErrorFormat(
                            "Failed to load types from assembly {0}.  Details will follow this message.  The exception is {1}",
                            assembly.FullName, tle);
                        foreach (Exception e in tle.LoaderExceptions) {
                            Logger.ErrorFormat("\tLoader Error: {0}", e.Message);
                        }
                    }
                }
                serviceLocator.NativelyRegisterComponentsAndPlugins();
                serviceLocator.LogRegisteredComponents();
            }
            catch (Exception err) {
                Logger.ErrorFormat("Unexpected error occured when applying configuration.  The error is {0}.", err);
            }
        }
    }
}