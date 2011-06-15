using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentJdf.Encoding
{
    /// <summary>
    /// The type of xml
    /// </summary>
    public enum XmlType
    {
        /// <summary>
        /// Is JDF 
        /// </summary>
        Jdf,
        /// <summary>
        /// Is JMF
        /// </summary>
        Jmf,
        /// <summary>
        /// Is something other than JDF or JMF.
        /// </summary>
        Other
    }
}
