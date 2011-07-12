using FluentJdf.Encoding;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
    public partial class SubmitQueueEntryCommandAttributeBuilder {

        readonly ITransmissionPartFactory transmissionPartFactory 
            = Infrastructure.Core.Configuration.Settings.ServiceLocator.Resolve<ITransmissionPartFactory>();

        /// <summary>
        /// Add a JDF that will be sent with this submit queue entry.
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public SubmitQueueEntryCommandAttributeBuilder Ticket(Ticket ticket) {
            ParameterCheck.ParameterRequired(ticket, "ticket");

            var part = transmissionPartFactory.CreateTransmissionPart("Ticket", ticket);
            ParentJmfNode.Message.AddRelatedPart(part);
            var name = Globals.JdfName("QueueSubmissionParams"); //TODO once params are generated, move to use the constant.
            //http://www.faqs.org/rfcs/rfc2387.html
            AddNode(name).With().Attribute("URL", string.Format("cid:{0}", part.Id));
            return this;
        }
    }
}