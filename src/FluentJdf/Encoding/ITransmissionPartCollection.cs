using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentJdf.Encoding
{
    /// <summary>
    /// A collection of transmission parts indexed by id.
    /// </summary>
    public interface ITransmissionPartCollection : IDisposable, ICollection<ITransmissionPart>
    {
    }
}
