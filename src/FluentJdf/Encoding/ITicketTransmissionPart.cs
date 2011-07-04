using System.Xml.Linq;
using FluentJdf.LinqToJdf;

namespace FluentJdf.Encoding {
    /// <summary>
    /// A transmission part that contains a JDF ticket.
    /// </summary>
    public interface ITicketTransmissionPart : ITransmissionPart
    {
        /// <summary>
        /// Gets the ticket for the transmission part.
        /// </summary>
        Ticket Ticket { get; }
    }
}