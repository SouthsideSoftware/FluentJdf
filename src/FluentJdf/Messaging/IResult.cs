using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.Encoding;
using FluentJdf.Messaging;

namespace FluentJdf.Utility
{
    /// <summary>
    /// The result of a JMF message transmission.
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// The collection of parts associated with the response.
        /// The first member of the collection is the JMF response.
        /// </summary>
        ITransmissionPartCollection TransmissionPartCollection { get; }
        /// <summary>
        /// Gets the integer return code from the response.
        /// </summary>
        int RawReturnCode { get; }
        /// <summary>
        /// Gets the parsed return code.
        /// </summary>
        ReturnCode ReturnCode { get; }
        /// <summary>
        /// Gets true if the JMF response
        /// indicates success.
        /// </summary>
        bool IsSuccess { get; }
    }
}
