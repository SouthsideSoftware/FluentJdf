using System.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.Ticket {
    [Subject(typeof(FluentJdf.LinqToJdf.Ticket))]
    public class when_creating_from_a_template_in_a_ticket {
        static FluentJdf.LinqToJdf.Ticket generatedTicket;
        static FluentJdf.LinqToJdf.Ticket templateDocument;

        Establish context = () => templateDocument = FluentJdf.LinqToJdf.Ticket.CreateIntent().WithInput().BindingIntent().With().Attribute("foo", "[:foo:]").Ticket;

        Because of = () => generatedTicket = FluentJdf.LinqToJdf.Ticket.CreateFromTemplate(templateDocument)
                                                  .With().NameValue("foo", "myFoo").Generate();

        It should_have_message_with_attribute_set_from_replacement = () => generatedTicket.Descendants(Resource.BindingIntent).First().GetAttributeValueOrNull("foo").ShouldEqual("myFoo");
    }
}