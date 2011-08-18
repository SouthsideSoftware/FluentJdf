using System.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfBuilder {
    [Subject("Highly fluent JDF interface")]
    public class when_creating_jdf_gray_box {
        static FluentJdf.LinqToJdf.Ticket ticket;

        Because of = () => ticket = FluentJdf.LinqToJdf.Ticket.CreateGrayBox(ProcessType.Cutting, ProcessType.Creasing).Ticket;

        It should_have_root_with_type_process_group = () => ticket.Root.GetJdfType().ShouldEqual("ProcessGroup");

        It should_have_xsi_type_for_process_group = () => ticket.Root.GetXsiTypeAttribute().ShouldEqual(ProcessType.ProcessGroup);

        It should_have_namespace_definition_for_xsi_with_xsi_prefix =
            () => ticket.Root.ToString().ShouldContain("xsi:");

        It should_have_correct_number_of_types = () => ticket.Root.GetJdfTypes().Length.ShouldEqual(2);

        It should_have_correct_first_type = () => ticket.Root.GetJdfTypes().First().ShouldEqual("Cutting");

        It should_have_correct_last_type = () => ticket.Root.GetJdfTypes().Last().ShouldEqual("Creasing");
    }
}