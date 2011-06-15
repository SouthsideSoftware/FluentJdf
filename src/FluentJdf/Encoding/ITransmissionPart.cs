using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FluentJdf.Encoding
{
    /// <summary>
    /// Represents a single part in a JDF
    /// transmissions.
    /// </summary>
    /// <remarks>For example, a JDF ticket, a JMF command or a PDF attachment.</remarks>
    public interface ITransmissionPart : IDisposable {
        /// <summary>
        /// Gets a copy of the stream associated with the part.
        /// </summary>
        Stream CopyOfStream();
        /// <summary>
        /// Gets the name of the part.  May not be unique.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Gets the id of the part.  Must be unique
        /// within the context of all parts in a single
        /// collection.
        /// </summary>
        string Id { get; }
        /// <summary>
        /// Gets the mime type of the part.
        /// </summary>
        string MimeType { get; }
    }
}
