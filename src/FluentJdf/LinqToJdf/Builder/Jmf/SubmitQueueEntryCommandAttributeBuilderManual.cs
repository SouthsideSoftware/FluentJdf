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

            ParentJmfNode.Message.AssociatedTicket = ticket;
            return this;
        }
    }
}