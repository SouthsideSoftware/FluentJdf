using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FluentJdf.Encoding
{
    /// <summary>
    /// Encodes and decodes JDF transmissions.
    /// </summary>
    public interface IEncoding {
        /// <summary>
        /// Encode a collection of transmission parts to a stream.
        /// </summary>
        /// <param name="transmissionParts"></param>
        /// <returns></returns>
        EncodingResult Encode(ITransmissionPartCollection transmissionParts);
        /// <summary>
        /// Encode a single transmission part to a stream.
        /// </summary>
        /// <param name="transmissionPart"></param>
        /// <returns></returns>
        EncodingResult Encode(ITransmissionPart transmissionPart);
        /// <summary>
        /// Decode a stream with a mime type to a collection
        /// of transmission parts.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        ITransmissionPartCollection Decode(Stream stream, string mimeType);
    }
}
