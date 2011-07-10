using FluentJdf.Encoding;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
    public partial class SubmitQueueEntryCommandAttributeBuilder {
        /// <summary>
        /// Add a JDF that will be sent with this submit queue entry.
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public SubmitQueueEntryCommandAttributeBuilder Ticket(Ticket ticket) {
            ParameterCheck.ParameterRequired(ticket, "ticket");

            //todo: use the ITransmissionPartFactory
            var part = new TicketTransmissionPart(ticket, "Ticket");
            ParentJmfNode.Message.AddRelatedPart(part);
            //todo: the id of the part needs to go into the url of a new QueueSubmissionParams element
            return this;
        }
    }
}