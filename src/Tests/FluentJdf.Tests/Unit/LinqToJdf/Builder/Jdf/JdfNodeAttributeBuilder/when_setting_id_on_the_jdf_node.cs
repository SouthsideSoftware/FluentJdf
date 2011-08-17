using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.Builder.Jdf.JdfNodeAttributeBuilder {
    [Subject(typeof(FluentJdf.LinqToJdf.Builder.Jdf.JdfNodeAttributeBuilder))]
    public class when_setting_id_on_the_jdf_node {
        static FluentJdf.LinqToJdf.Ticket ticket;

        Because of = () => ticket = FluentJdf.LinqToJdf.Ticket.CreateIntent().With().Id("foo").Ticket;

        It should_have_id_as_set = () => ticket.Root.GetId().ShouldEqual("foo");
    }
}