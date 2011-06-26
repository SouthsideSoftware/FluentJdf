using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Reflection;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Container;
using Infrastructure.Core.Helpers;
using Infrastructure.Core.Logging;

namespace Infrastructure.Container.CastleWindsor
{
    /// <summary>
    /// Implementation of IServiceLocator for Castle Windsor.
    /// </summary>
    public class WindsorServiceLocator : IServiceLocator {
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
                    logger = LogManager.GetLogger(typeof(WindsorServiceLocator));
                }
                return logger;
            }
        }

        /// <summary>
        /// Gets the windsor container.
        /// </summary>
        public IWindsorContainer Container {get { return container; }}

        IWindsorContainer container;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="container"></param>
        public WindsorServiceLocator(IWindsorContainer container) {
            ParameterCheck.ParameterRequired(container, "container");

            this.container = container;
            InitializeContainerSettings();
        }

        /// <summary>
        /// Get the default instance of the given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        /// <summary>
        /// Get the default instance of the given type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public object Resolve(Type type)
        {
            return container.Resolve(type);
        }

        /// <summary>
        /// Get the instance of the given type with the given key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>(string key)
        {
            return container.Resolve<T>(key);
        }

        /// <summary>
        /// Get the instance of the given type with the given key.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Resolve(Type type, string key)
        {
            return container.Resolve(key, type);
        }

        /// <summary>
        /// Returns true if the given type can be resolved.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool CanResolve(Type type) {
            return container.Kernel.HasComponent(type.Name);
        }

        /// <summary>
        /// Returns true if a component with the given type and key can be resolved.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool CanResolve(Type type, string key) {
            return container.Kernel.HasComponent(key) && container.Kernel.GetHandler(key).ComponentModel.Service.Name == type.Name;
        }

        /// <summary>
        /// Resolve all components of the given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> ResolveAll<T>() {
            return container.ResolveAll<T>();
        }

        /// <summary>
        /// Get the handlers for the given type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEnumerable<IHandler> GetAllHandlersFor(Type type)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Release the given instance.
        /// </summary>
        /// <param name="item"></param>
        public void Release(object item)
        {
            container.Release(item);
        }

        /// <summary>
        /// Log information about the currently registered components.
        /// </summary>
        public void LogRegisteredComponents()
        {
            container.LogRegisteredComponents();
        }

        /// <summary>
        /// Load all plugins and run native container registration for each assembly (if available)
        /// </summary>
        public void NativelyRegisterComponentsAndPlugins()
        {
            string pluginPath = Path.Combine(ApplicationInformation.Directory, "plugins");
            if (!Directory.Exists(pluginPath))
            {
                Logger.WarnFormat(
                    "Plugins folder {0} does not exist.  This is OK as long as there are no plugins to load",
                    pluginPath);
            }
            container.LoadAndInstallAssemblies(new AssemblyFilter(pluginPath, "*.dll"), new AssemblyFilter(ApplicationInformation.Directory, "*.dll"));
        }

        /// <summary>
        /// Register an implementation of the given interface type with a 
        /// lifestyle that defaults to singleton under the key full name
        /// of implementation.
        /// </summary>
        /// <param name="interfaceType"></param>
        /// <param name="instanceType"></param>
        /// <param name="componentLifestyle"></param>
        public void Register(Type interfaceType, Type instanceType, ComponentLifestyle componentLifestyle = ComponentLifestyle.Singleton)
        {
            Register(instanceType.FullName, interfaceType, instanceType, componentLifestyle);
        }

        /// <summary>
        /// Register an implementation of the given interface type with a 
        /// lifestyle that defaults to singleton and the given key.
        /// </summary>
        public void Register(string key, Type interfaceType, Type instanceType, ComponentLifestyle componentLifestyle = ComponentLifestyle.Singleton){

            bool untracked = false;
            LifestyleType castleLifestyle = LifestyleType.Singleton;
            switch (componentLifestyle)
            {
                case ComponentLifestyle.Transient:
                    castleLifestyle = LifestyleType.Transient;
                    break;
                case ComponentLifestyle.TransientNoTracking:
                    castleLifestyle = LifestyleType.Custom;
                    untracked = true;
                    break;
                case ComponentLifestyle.Thread:
                    castleLifestyle = LifestyleType.Thread;
                    break;
                case ComponentLifestyle.PerWebRequest:
                    castleLifestyle = LifestyleType.PerWebRequest;
                    break;
            }
            if (untracked) {
                container.Register(Component.For(interfaceType).ImplementedBy(instanceType).LifeStyle.Custom<NonTrackedTransientLifestyle>().Named(key));
            }
            else {
                container.Register(Component.For(interfaceType).ImplementedBy(instanceType).LifeStyle.Is(castleLifestyle).Named(key));
            }
            
        }

        /// <summary>
        /// Resets the container.
        /// </summary>
        public void Reset() {
            container.Dispose();
            container = new WindsorContainer();
            InitializeContainerSettings();
        }

        void InitializeContainerSettings() {
            container.Kernel.ReleasePolicy = new LifecycledComponentsReleasePolicyWithNonTrackedTransientOption();
        }

        /// <summary>
        /// Register remaining interface implementations
        /// in the given assembly.
        /// </summary>
        public void RegisterRemainingInterfaceImplementations(Assembly assembly) {
            container.RegisterRemainingInterfaceImplementations(assembly);
        }
    }
}
