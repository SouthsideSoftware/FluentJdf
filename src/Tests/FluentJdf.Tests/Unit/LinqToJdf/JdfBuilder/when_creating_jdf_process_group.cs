using FluentJdf.LinqToJdf;
using FluentJdf.LinqToJdf.Builder.Jmf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfBuilder {
    [Subject("Highly fluent JDF interface")]
    public class when_creating_jdf_process_group {
        static Ticket ticket;

        Because of = () => ticket = Ticket.CreateProcessGroup().Ticket;

        It should_have_root_with_type_process_group = () => ticket.Root.GetMessageType().ShouldEqual("ProcessGroup");

        It should_have_xsi_type_process_group = () => ticket.Root.GetXsiTypeAttribute().ShouldEqual(ProcessType.ProcessGroup);

        It should_have_namespace_definition_for_xsi_with_xsi_prefix =
            () => ticket.Root.ToString().ShouldContain("xsi:");
    }
}