using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JmfBuilder {
    [Subject("Highly fluent JMF interface")]
    public class when_setting_attribute_on_submit_queue_entry {
        static Message message;

        Because of = () => message = Message.Create().AddCommand().SubmitQueueEntry().With().Attribute("foo", "fi").Message;

        It should_have_attribute_foo_on_command = () => message.Root.Element(Element.Command).GetAttributeValueOrNull("foo").ShouldEqual("fi");
    }
}