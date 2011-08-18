using System.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfBuilder {
    [Subject("Highly fluent JDF interface")]
    public class when_adding_a_jdf_gray_box_with_one_type_to_an_existing_jdf {
        static FluentJdf.LinqToJdf.Ticket ticket;

        Because of = () => ticket = FluentJdf.LinqToJdf.Ticket.CreateProcessGroup().AddGrayBox(ProcessType.Cutting).Ticket;

        It should_have_correct_number_of_types_in_gray_box = () => ticket.Root.Descendants(Element.JDF).First().GetJdfTypes().Length.ShouldEqual(1);

        It should_have_correct_first_type_in_gray_box = () => ticket.Root.Descendants(Element.JDF).First().GetJdfTypes().First().ShouldEqual("Cutting");
    }
}