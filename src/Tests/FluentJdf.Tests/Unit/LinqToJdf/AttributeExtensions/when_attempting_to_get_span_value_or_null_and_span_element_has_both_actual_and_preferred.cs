using System.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.AttributeExtensions {
    [Subject(typeof(FluentJdf.LinqToJdf.AttributeExtensions))]
    public class when_attempting_to_get_span_value_or_null_and_span_element_has_both_actual_and_preferred {
        static FluentJdf.LinqToJdf.Ticket ticket;
        static string spanValue;

        Establish context = () => ticket = FluentJdf.LinqToJdf.Ticket.CreateIntent().WithInput().BindingIntent().AddNode(Element.BindingType).With().Attribute("Preferred", "test2").Attribute("Actual", "test").Ticket;

        Because of = () => spanValue = ticket.GetIntent().WithInput(Element.BindingIntent).Elements.First().GetSpanAttributeActualPreferredOrNull(Element.BindingType);

        It should_have_value_from_actual = () => spanValue.ShouldEqual("test");
    }
}