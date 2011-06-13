using System;

namespace Infrastructure.Core.Logging
{
    /// <summary>
    /// Interface to get ILog instances.
    /// </summary>
    public interface ILogProvider {
        /// <summary>
        /// Gets the ILog implementation for the type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        ILog GetLogger(Type type);
        /// <summary>
        /// Gets the ILog implementation for the key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        ILog GetLogger(string key);
    }
}
