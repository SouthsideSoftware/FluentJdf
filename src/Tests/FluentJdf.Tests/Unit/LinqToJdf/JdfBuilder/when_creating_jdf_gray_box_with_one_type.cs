using System.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfBuilder {
    [Subject("Highly fluent JDF interface")]
    public class when_creating_jdf_gray_box_with_one_type {
        static FluentJdf.LinqToJdf.Ticket ticket;

        Because of = () => ticket = FluentJdf.LinqToJdf.Ticket.CreateGrayBox(ProcessType.Cutting).Ticket;

        It should_have_root_with_type_process_group = () => ticket.Root.GetJdfType().ShouldEqual("ProcessGroup");

        It should_have_xsi_type_for_process_group = () => ticket.Root.GetXsiTypeAttribute().ShouldEqual(ProcessType.ProcessGroup);

        It should_have_namespace_definition_for_xsi_with_xsi_prefix =
            () => ticket.Root.ToString().ShouldContain("xsi:");

        It should_have_correct_number_of_types = () => ticket.Root.GetJdfTypes().Length.ShouldEqual(1);

        It should_have_correct_first_type = () => ticket.Root.GetJdfTypes().First().ShouldEqual("Cutting");
    }
}