using System;
using System.Collections.Generic;
using System.Reflection;

namespace Infrastructure.Core.Container
{
    /// <summary>
    /// Generic service locator
    /// </summary>
    public interface IServiceLocator
    {
        /// <summary>
        /// Get the default instance of the given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Resolve<T>();
        /// <summary>
        /// Get the default instance of the given type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object Resolve(Type type);
        /// <summary>
        /// Get the instance of the given type with the given key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Resolve<T>(string key);
        /// <summary>
        /// Get the instance of the given type with the given key.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        object Resolve(Type type, string key);
        /// <summary>
        /// Returns true if the given type can be resolved.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool CanResolve(Type type);
        /// <summary>
        /// Returns true if a component with the given type and key can be resolved.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        bool CanResolve(Type type, string key);
        /// <summary>
        /// Resolve all components of the given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> ResolveAll<T>();
        /// <summary>
        /// Get the handlers for the given type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IEnumerable<IHandler> GetAllHandlersFor(Type type);
        /// <summary>
        /// Release the given instance.
        /// </summary>
        /// <param name="item"></param>
        void Release(object item);
        /// <summary>
        /// Log information about the currently registered components.
        /// </summary>
        void LogRegisteredComponents();
        /// <summary>
        /// Load all plugins and run native container registration for each assembly (if available)
        /// </summary>
        void NativelyRegisterComponentsAndPlugins();

        /// <summary>
        /// Register an implementation of the given interface type with a 
        /// lifestyle that defaults to singleton under the key full name
        /// of implementation.
        /// </summary>
        /// <param name="interfaceType"></param>
        /// <param name="instanceType"></param>
        /// <param name="componentLifestyle"></param>
        void Register(Type interfaceType, Type instanceType,
                      ComponentLifestyle componentLifestyle = ComponentLifestyle.Singleton);

        /// <summary>
        /// Register an implementation of the given interface type with a 
        /// lifestyle that defaults to singleton and the given key.
        /// </summary>
        void Register(string key, Type interfaceType, Type instanceType,
                      ComponentLifestyle componentLifestyle = ComponentLifestyle.Singleton);
        /// <summary>
        /// Clear all components from the container.
        /// </summary>
        void Reset();

        /// <summary>
        /// Register remaining interface implementations as singletons
        /// in the given assmebly.
        /// </summary>
        void RegisterRemainingInterfaceImplementations(Assembly assembly);
    }
}
