using System.Linq;
using System.Xml.Linq;
using FluentJdf.Encoding;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JmfBuilder {
    [Subject("Highly fluent JMF interface")]
    public class when_associating_ticket_with_submit_queue_entry {
        static FluentJdf.LinqToJdf.Message message;
        static FluentJdf.LinqToJdf.Ticket ticket;

        Establish context = () => ticket = FluentJdf.LinqToJdf.Ticket.CreateIntent().Ticket;

        Because of = () => message = FluentJdf.LinqToJdf.Message.Create().AddCommand().SubmitQueueEntry().With().Ticket(ticket).Message;

        It should_have_associated_ticket = () => message.AdditionalParts.Count.ShouldEqual(1);

        It should_have_the_correct_associated_ticket = () => XNode.DeepEquals((message.AdditionalParts.First() as TicketTransmissionPart).Ticket, ticket);

        It should_have_QueueSubmissionParams = () => message.SelectJDFDescendant("QueueSubmissionParams").ShouldNotBeNull();

        It should_have_QueueSubmissionParams_with_url_attribute = () => message.SelectJDFDescendant("QueueSubmissionParams").Attribute("URL").ShouldNotBeNull();

        It should_have_QueueSubmissionParams_with_correct_url_attribute_cid
                = () => message.SelectJDFDescendant("QueueSubmissionParams").Attribute("URL").Value.ShouldEqual("cid:" + message.AdditionalParts.First().Id);
    }
}