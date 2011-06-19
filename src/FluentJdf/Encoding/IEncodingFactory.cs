using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentJdf.Encoding
{
    /// <summary>
    /// Interface for getting encodings.
    /// </summary>
    public interface IEncodingFactory {
        /// <summary>
        /// Gets the encoding for the given mime type.
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        IEncoding GetEncodingForMimeType(string mimeType);

        /// <summary>
        /// Gets the default encoding for transmission part collections
        /// containing a single part.
        /// </summary>
        /// <returns></returns>
        IEncoding GetDefaultEncodingForSinglePart();

        /// <summary>
        /// Gets the default encoding for transmission part collections
        /// containing multiple parts.
        /// </summary>
        /// <returns></returns>
        IEncoding GetDefaultEncodingForMultiPart();

        /// <summary>
        /// Gets the encoder for the given transmission part collection.
        /// </summary>
        /// <param name="transmissionPartCollection"></param>
        /// <returns></returns>
        IEncoding GetEncodingForTransmissionParts(ITransmissionPartCollection transmissionPartCollection);
    }
}
