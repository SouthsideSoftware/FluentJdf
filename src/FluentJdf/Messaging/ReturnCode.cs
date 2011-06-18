using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentJdf.Messaging
{
    /// <summary>
    /// JMF return codes defined by the standard
    /// </summary>
    public enum ReturnCode
    {
        /// <summary>
        /// Success
        /// </summary>
        Success = 0,
        /// <summary>
        /// General error.
        /// </summary>
        GeneralError = 1,
        /// <summary>
        /// Internal error.
        /// </summary>
        InternalError = 2,
        /// <summary>
        /// Error code does not match one of the 
        /// values defined in the standard.
        /// </summary>
        Unknown = int.MaxValue
    }
}
