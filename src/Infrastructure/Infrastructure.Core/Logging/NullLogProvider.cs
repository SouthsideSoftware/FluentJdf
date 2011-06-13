using System;

namespace Infrastructure.Core.Logging
{
    /// <summary>
    /// Implementation of ILogProvider that returns a do-nothing
    /// logger.
    /// </summary>
    public class NullLogProvider : ILogProvider {
        static ILog log = new NullLog();
        /// <summary>
        /// Gets the ILog implementation for the type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ILog GetLogger(Type type) {
            return log;
        }

        /// <summary>
        /// Gets the ILog implementation for the key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ILog GetLogger(string key) {
            throw new NotImplementedException();
        }
    }
}
