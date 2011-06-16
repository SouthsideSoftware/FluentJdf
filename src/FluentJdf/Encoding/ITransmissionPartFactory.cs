using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FluentJdf.Encoding
{
    /// <summary>
    /// Factory interface for transmission part creation.
    /// </summary>
    public interface ITransmissionPartFactory {
        /// <summary>
        /// Create a transmission part.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        ITransmissionPart CreateTransmissionPart(string name, Stream data, string mimeType, string id = null);
    }
}
