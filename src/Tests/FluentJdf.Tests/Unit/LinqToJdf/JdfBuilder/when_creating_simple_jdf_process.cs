using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfBuilder {
    [Subject("Highly fluent JDF interface")]
    public class when_creating_simple_jdf_process {
        static Ticket ticket;

        Because of = () => ticket = Ticket.CreateProcess(ProcessType.Cutting).Ticket;

        It should_have_root_with_type_process_group = () => ticket.Root.GetMessageType().ShouldEqual("Cutting");
    }
}