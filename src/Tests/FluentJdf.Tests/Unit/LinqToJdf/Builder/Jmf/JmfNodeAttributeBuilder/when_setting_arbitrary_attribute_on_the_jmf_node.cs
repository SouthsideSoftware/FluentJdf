using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.Builder.Jmf.JmfNodeAttributeBuilder {
    [Subject(typeof(FluentJdf.LinqToJdf.Builder.Jmf.JmfNodeAttributeBuilder))]
    public class when_setting_arbitrary_attribute_on_the_jmf_node {
        static FluentJdf.LinqToJdf.Message message;

        Because of = () => message = FluentJdf.LinqToJdf.Message.Create().With().Attribute("fi", "foo").Message;

        It should_have_id_as_set = () => message.Root.GetAttributeValueOrNull("fi").ShouldEqual("foo");
    }
}