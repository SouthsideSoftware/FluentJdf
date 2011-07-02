using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.Ticket
{
    [Subject(typeof(FluentJdf.LinqToJdf.Ticket))]
    public class when_using_parse {
        static FluentJdf.LinqToJdf.Ticket sourceTicket;
        static FluentJdf.LinqToJdf.Ticket parsedTicket;

        Establish context = () => sourceTicket = FluentJdf.LinqToJdf.Ticket.CreateIntent().WithInput().BindingIntent().Ticket;

        Because of = () => parsedTicket = FluentJdf.LinqToJdf.Ticket.Parse(sourceTicket.ToString());

        It should_have_parsed_content_same_as_source = () => FluentJdf.LinqToJdf.Ticket.DeepEquals(parsedTicket, sourceTicket);
    }
}
