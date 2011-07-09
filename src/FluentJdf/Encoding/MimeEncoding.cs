using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Encoding {

    /// <summary>
    /// Mime Encoder class used for multi part encoding.
    /// </summary>
    public class MimeEncoding : IEncoding {

        /// <summary>
        /// Encode a collection of parts.
        /// </summary>
        /// <param name="transmissionParts"></param>
        /// <returns></returns>
        public EncodingResult Encode(ITransmissionPartCollection transmissionParts) {
            ParameterCheck.ParameterRequired(transmissionParts, "transmissionParts");

            //if (transmissionParts.Count() > 1) {
            //    throw new NotSupportedException(Messages.PassThroughEncoder_Encode_CannotEncodeMoreThanOnePart);
            //}
            //return Encode(transmissionParts.First());

            throw new NotImplementedException();
        }

        /// <summary>
        /// Encode a part.
        /// </summary>
        /// <param name="transmissionPart"></param>
        /// <returns></returns>
        public EncodingResult Encode(ITransmissionPart transmissionPart) {
            ParameterCheck.ParameterRequired(transmissionPart, "transmissionPart");

            //return new EncodingResult(transmissionPart.CopyOfStream(), transmissionPart.MimeType);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Decode the given stream into a collection of parts.
        /// </summary>
        /// <returns></returns>
        public ITransmissionPartCollection Decode(string name, System.IO.Stream stream, string mimeType, string id = null) {
            ParameterCheck.ParameterRequired(stream, "stream");
            ParameterCheck.StringRequiredAndNotWhitespace(mimeType, "mimeType");

            //var transmissionPartCollection = new TransmissionPartCollection();
            //transmissionPartCollection.Add(transmissionPartFactory.CreateTransmissionPart(name, stream, mimeType, id));
            //return transmissionPartCollection;
            throw new NotImplementedException();
        }
    }
}
