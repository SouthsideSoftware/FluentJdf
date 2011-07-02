using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JmfBuilder {
    [Subject("Highly fluent JMF interface")]
    public class when_associating_ticket_with_submit_queue_entry {
        static FluentJdf.LinqToJdf.Message message;
        static FluentJdf.LinqToJdf.Ticket ticket;

        Establish context = () => ticket = FluentJdf.LinqToJdf.Ticket.CreateIntent().Ticket;

        Because of = () => message = FluentJdf.LinqToJdf.Message.Create().AddCommand().SubmitQueueEntry().With().Ticket(ticket).Message;

        It should_have_associated_ticket = () => message.AssociatedTicket.ShouldNotBeNull();

        It should_have_the_correct_associated_ticket = () => XNode.DeepEquals(message.AssociatedTicket, ticket);
    }
}