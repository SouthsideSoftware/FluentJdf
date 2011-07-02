using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JmfBuilder {
    [Subject("Highly fluent JMF interface")]
    public class when_setting_id_on_queue_status {
        static FluentJdf.LinqToJdf.Message message;

        Because of = () => message = FluentJdf.LinqToJdf.Message.Create().AddQuery().QueueStatus().With().Id("fi").Message;

        It should_have_id_fi_on_query = () => message.Root.Element(Element.Query).GetAttributeValueOrNull("ID").ShouldEqual("fi");
    }
}