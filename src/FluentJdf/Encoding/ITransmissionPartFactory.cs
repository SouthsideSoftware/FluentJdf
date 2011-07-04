using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FluentJdf.Encoding
{
    /// <summary>
    /// Factory interface for transmission part creation.
    /// </summary>
    public interface ITransmissionPartFactory {
        /// <summary>
        /// Create a transmission part based on a stream.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        ITransmissionPart CreateTransmissionPart(string name, Stream data, string mimeType, string id = null);
        /// <summary>
        /// Creates a transmission part based on an <see cref="XDocument"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="doc"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>If the root is JDF, the part type registered for the JDF mime type is used.
        /// If the root is JMF, the part type registered for the JMF mime type is used.
        /// Otherwise, the part type registered for the generic xml mime type is used.</remarks>
        ITransmissionPart CreateTransmissionPart(string name, XDocument doc, string id = null);
    }
}
