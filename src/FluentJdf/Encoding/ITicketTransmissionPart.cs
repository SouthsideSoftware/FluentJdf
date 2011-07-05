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

        /// <summary>
        /// Initialize the properties.
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        void InitalizeProperties(Ticket ticket, string name, string id);
    }
}