using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.Encoding;
using Infrastructure.Core.Result;

namespace FluentJdf.Transmission
{
    /// <summary>
    /// Interface for transmitting data.
    /// </summary>
    public interface ITransmitter {
        /// <summary>
        /// Transmit data to the given URI.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="partsToSend"></param>
        /// <returns>A result that includes parsed JMF results if available.</returns>
        ResultOf<ITransmissionPartCollection> Transmit(Uri uri, ITransmissionPartCollection partsToSend);

        /// <summary>
        /// Transmit data to the given uri (string).
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="partsToSend"></param>
        /// <returns>A result that includes parsed JMF results if available.</returns>
        ResultOf<ITransmissionPartCollection> Transmit(string uri, ITransmissionPartCollection partsToSend);
    }
}
