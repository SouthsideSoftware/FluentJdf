using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.Builder.Jdf.JdfNodeAttributeBuilder {
    [Subject(typeof(FluentJdf.LinqToJdf.Builder.Jdf.JdfNodeAttributeBuilder))]
    public class when_setting_arbitrary_attribute_on_the_jdf_node {
        static FluentJdf.LinqToJdf.Ticket ticket;

        Because of = () => ticket = FluentJdf.LinqToJdf.Ticket.CreateIntent().With().Attribute("fi", "foo").Ticket;

        It should_have_id_as_set = () => ticket.Root.GetAttributeValueOrNull("fi").ShouldEqual("foo");
    }
}