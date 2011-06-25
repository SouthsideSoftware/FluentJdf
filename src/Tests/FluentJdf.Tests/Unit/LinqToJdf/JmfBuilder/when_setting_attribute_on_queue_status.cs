using FluentJdf.LinqToJdf;
using FluentJdf.LinqToJdf.Builder.Jmf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JmfBuilder {
    [Subject("Highly fluent JMF interface")]
    public class when_setting_attribute_on_queue_status {
        static Message message;

        Because of = () => message = Message.Create().AddQuery().QueueStatus().With().Attribute("foo", "fi").Message;

        It should_have_attribute_foo_on_query = () => message.Root.Element(Element.Query).GetAttributeValueOrNull("foo").ShouldEqual("fi");
    }
}