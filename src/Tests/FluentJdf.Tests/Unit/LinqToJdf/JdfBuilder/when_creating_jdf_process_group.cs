using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfBuilder {
    [Subject("Highly fluent JDF interface")]
    public class when_creating_jdf_process_group {
        static Ticket ticket;

        Because of = () => ticket = Ticket.CreateProcessGroup().Ticket;

        It should_have_root_with_type_process_group = () => ticket.Root.GetMessageType().ShouldEqual("ProcessGroup");
    }
}