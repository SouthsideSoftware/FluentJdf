using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.LinqToJdf;

namespace FluentJdf.Encoding
{
    /// <summary>
    /// A collection of transmission parts indexed by id.
    /// </summary>
    public interface ITransmissionPartCollection : IDisposable, ICollection<ITransmissionPart>
    {
        /// <summary>
        /// Gets the first message in the transmission part collection
        /// </summary>
        /// <remarks>There should not be more than one, but if there is, this will just get the 
        /// first. Will be <see langword="null"/> if there is no message.</remarks>
        Message Message { get; }

        /// <summary>
        /// Returns <see langword="true"/> if there is a message in the collection.
        /// </summary>
        bool HasMessage { get; }

        /// <summary>
        /// Gets the message part if any.  
        /// </summary>
        /// <remarks>Returns <see langword="null"/> if there is no message part.</remarks>
        XmlTransmissionPart MessagePart { get; }
    }
}
