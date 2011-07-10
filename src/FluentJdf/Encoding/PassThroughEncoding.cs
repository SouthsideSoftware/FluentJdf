using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using FluentJdf.Resources;
using Infrastructure.Core;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Encoding {
    /// <summary>
    /// Encoder that assumes the data passes through without
    /// any parsing.  That is, the raw data is in the format
    /// expected by the transmission part.
    /// </summary>
    public class PassThroughEncoding : IEncoding
    {
        ITransmissionPartFactory transmissionPartFactory;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="transmissionPartFactory"></param>
        public PassThroughEncoding(ITransmissionPartFactory transmissionPartFactory)
        {
            ParameterCheck.ParameterRequired(transmissionPartFactory, "transmissionPartFactory");

            this.transmissionPartFactory = transmissionPartFactory;
        }
        /// <summary>
        /// Encode a collection of parts.
        /// </summary>
        /// <param name="transmissionParts"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException">If the collection contains more than 1 part.</exception>
        public EncodingResult Encode(ITransmissionPartCollection transmissionParts) {
            ParameterCheck.ParameterRequired(transmissionParts, "transmissionParts");

            if (transmissionParts.Count() > 1) {
                throw new NotSupportedException(Messages.PassThroughEncoder_Encode_CannotEncodeMoreThanOnePart);
            }
            return Encode(transmissionParts.First());
        }

        /// <summary>
        /// Encode a part.
        /// </summary>
        /// <param name="transmissionPart"></param>
        /// <returns></returns>
        public EncodingResult Encode(ITransmissionPart transmissionPart) {
            ParameterCheck.ParameterRequired(transmissionPart, "transmissionPart");

            return new EncodingResult(transmissionPart.CopyOfStream(), transmissionPart.MimeType);
        }

        /// <summary>
        /// Decode the given stream into a collection of parts.
        /// </summary>
        /// <returns></returns>
        public ITransmissionPartCollection Decode(string name, Stream stream, string mimeType, string id = null) {
            ParameterCheck.ParameterRequired(stream, "stream");
            ParameterCheck.StringRequiredAndNotWhitespace(mimeType, "mimeType");

            var transmissionPartCollection = new TransmissionPartCollection();
            transmissionPartCollection.Add(transmissionPartFactory.CreateTransmissionPart(name, stream, mimeType, id));
            return transmissionPartCollection;
        }
    }
}
