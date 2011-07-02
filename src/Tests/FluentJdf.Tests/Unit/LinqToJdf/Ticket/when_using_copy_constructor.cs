using System.Linq;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.Ticket {
    [Subject(typeof(FluentJdf.LinqToJdf.Ticket))]
    public class when_using_copy_constructor {
        static FluentJdf.LinqToJdf.Ticket sourceTicket;
        static FluentJdf.LinqToJdf.Ticket copiedTicket;

        Establish context = () => sourceTicket = FluentJdf.LinqToJdf.Ticket.CreateIntent().WithInput().BindingIntent().Ticket;

        Because of = () => copiedTicket = new FluentJdf.LinqToJdf.Ticket(sourceTicket);

        It should_have_copied_content_same_elements_and_attributes_as_source = () => FluentJdf.LinqToJdf.Ticket.DeepEquals(copiedTicket, sourceTicket);

        It should_not_be_same_instance_of_root = () => copiedTicket.Root.ShouldNotEqual(sourceTicket.Root);

        It should_not_be_same_instance_of_first_child_of_root = () => copiedTicket.Root.Elements().First().ShouldNotEqual(sourceTicket.Root.Elements().First());
    }
}