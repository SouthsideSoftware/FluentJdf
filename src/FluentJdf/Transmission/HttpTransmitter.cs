using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.Encoding;
using FluentJdf.Messaging;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Transmission
{
    /// <summary>
    /// Transmit JDF over HTTP and collect a response.
    /// </summary>
    public class HttpTransmitter : ITransmitter
    {
        /// <summary>
        /// Transmit data to the given URI.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="partsToSend"></param>
        /// <returns>A result that includes parsed JMF results if available.</returns>
        public IJmfResult Transmit(Uri uri, ITransmissionPartCollection partsToSend) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Transmit data to the given uri (string).
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="partsToSend"></param>
        /// <returns>A result that includes parsed JMF results if available.</returns>
        public IJmfResult Transmit(string uri, ITransmissionPartCollection partsToSend) {
            ParameterCheck.StringRequiredAndNotWhitespace(uri, "uri");

            return Transmit(new Uri(uri), partsToSend);
        }
    }
}
