using FluentJdf.LinqToJdf;
using FluentJdf.LinqToJdf.Builder.Jmf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JmfBuilder {
    [Subject("Highly fluent JMF interface")]
    public class when_creating_queue_status_fluently {
        static Message message;

        Because of = () => message = Message.Create().AddCommand().QueueStatus().Message;

        It should_have_jmf_at_root = () => message.Root.Name.ShouldEqual(Element.JMF);

        It should_have_query_in_jmf = () => message.Root.Element(Element.Query).ShouldNotBeNull();

        It should_have_type_queue_status = () => message.Root.Element(Element.Query).GetMessageType().ShouldEqual(Query.QueueStatus);

        It should_have_xsi_type_queue_status_query = () => message.Root.Element(Element.Query).GetXsiTypeAttribute().ShouldEqual("QueryQueueStatus");

        It should_have_an_id_in_command = () => message.Root.Element(Element.Query).GetId().ShouldNotBeNull();

        It should_have_id_starts_with_qs = () => message.Root.Element(Element.Query).GetId().ShouldStartWith("QS_");

        It should_have_namespace_definition_for_xsi_with_xsi_prefix =
            () => message.Root.ToString().ShouldContain("xsi:");

        It should_have_version_attribute_in_jmfwith_default_value = () => message.Root.GetVersion().ShouldEqual("1.4");

        It should_have_null_sender_id = () => message.Root.GetSenderId().ShouldBeNull();
    }
}