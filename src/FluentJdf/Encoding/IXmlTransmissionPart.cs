using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FluentJdf.Encoding
{
    /// <summary>
    /// A transmission part that contains xml.  Usually JDF or JMF.
    /// </summary>
    interface IXmlTransmissionPart : ITransmissionPart
    {
        /// <summary>
        /// Gets the document for the transmission part.
        /// </summary>
        XDocument Document { get; }
    }
}
