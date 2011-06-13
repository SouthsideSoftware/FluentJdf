using System;

namespace Infrastructure.Core.Container
{
    /// <summary>
    /// Interface to coordinate the creation and destruction 
    /// of a component via the service locator/container.
    /// </summary>
    public interface IHandler
    {
        /// <summary>
        /// Gets the service type.  Often an interface.
        /// </summary>
        Type Service { get; }
        /// <summary>
        /// Gets the implementation type of the service.
        /// </summary>
        Type Implementation { get; }
        /// <summary>
        /// Return an instance of the implementation type.
        /// </summary>
        /// <returns></returns>
        object Resolve();
        /// <summary>
        /// Gets the key that can be used to lookup this handler
        /// in the locator/container.
        /// </summary>
        string Key { get; }
    }
}