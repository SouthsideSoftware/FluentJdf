using System;
using System.Runtime.Serialization;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Exception in JDF extension.
    /// </summary>
    [Serializable]
    public class JdfException : Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public JdfException(){}

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message"></param>
        public JdfException(string message) : base(message) {}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public JdfException(string message, Exception innerException) : base(message, innerException) {}

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public JdfException(SerializationInfo info, StreamingContext context) : base(info, context) {}
    }
}
