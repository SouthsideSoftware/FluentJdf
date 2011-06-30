using System;
using System.Runtime.Serialization;

namespace FluentJdf.Configuration
{
    /// <summary>
    /// Exception in JDF extension.
    /// </summary>
    [Serializable]
    public class LibraryConfigurationException : Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public LibraryConfigurationException() { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message"></param>
        public LibraryConfigurationException(string message) : base(message) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public LibraryConfigurationException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public LibraryConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}