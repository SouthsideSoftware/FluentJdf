using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Used to build submit queue entry
    /// </summary>
    public class JmfSubmitQueueEntryCommandBuilder : JmfCommandBuilder {
        internal const string IdPrefix = "SQE_";

        internal  JmfSubmitQueueEntryCommandBuilder(JmfNodeBuilder parent) : base(parent, Command.SubmitQueueEntry, IdPrefix) {
            ParameterCheck.ParameterRequired(parent, "parent");
        }

        /// <summary>
        /// Add a JDF that will be sent with this submit queue entry.
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public JmfSubmitQueueEntryCommandBuilder WithJdf(Ticket ticket) {
            ParameterCheck.ParameterRequired(ticket, "ticket");

            ParentJmfNode.Message.AssociatedTicket = ticket;
            return this;
        }
    }
}