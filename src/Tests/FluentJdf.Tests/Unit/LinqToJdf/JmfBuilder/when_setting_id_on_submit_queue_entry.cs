using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JmfBuilder {
    [Subject("Highly fluent JMF interface")]
    public class when_setting_id_on_submit_queue_entry {
        static FluentJdf.LinqToJdf.Message message;

        Because of = () => message = FluentJdf.LinqToJdf.Message.Create().AddCommand().SubmitQueueEntry().With().Id("fi").Message;

        It should_have_attribute_value_fi_for_id_on_command = () => message.Root.Element(Element.Command).GetAttributeValueOrNull("ID").ShouldEqual("fi");
    }
}