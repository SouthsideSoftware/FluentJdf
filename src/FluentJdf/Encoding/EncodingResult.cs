using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Encoding
{
    /// <summary>
    /// Result of encoding.
    /// </summary>
    public class EncodingResult
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="contentType"></param>
        public EncodingResult(Stream stream, string contentType) {
            ParameterCheck.ParameterRequired(stream, "stream");
            ParameterCheck.StringRequiredAndNotWhitespace(contentType, "contentType");

            Stream = stream;
            ContentType = contentType;
        }

        /// <summary>
        /// Gets the stream.
        /// </summary>
        public Stream Stream { get; private set; }

        /// <summary>
        /// Gets the content type.
        /// </summary>
        public string ContentType { get; private set; }
    }
}
