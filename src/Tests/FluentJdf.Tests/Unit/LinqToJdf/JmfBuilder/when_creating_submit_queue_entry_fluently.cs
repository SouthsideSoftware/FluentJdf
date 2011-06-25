using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using FluentJdf.LinqToJdf.Builder.Jmf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JmfBuilder {
    [Subject("Highly fluent JMF interface")]
    public class when_creating_submit_queue_entry_fluently {
        static Message message;

        Because of = () => message = Message.Create().AddCommand().SubmitQueueEntry().Message;

        It should_have_jmf_at_root = () => message.Root.Name.ShouldEqual(Element.JMF);

        It should_have_command_in_jmf = () => message.Root.Element(Element.Command).ShouldNotBeNull();

        It should_have_type_submit_queue_entry = () => message.Root.Element(Element.Command).GetMessageType().ShouldEqual(Command.SubmitQueueEntry);

        It should_have_xsi_type_submit_queue_entry_command = () => message.Root.Element(Element.Command).GetXsiTypeAttribute().ShouldEqual(Command.XsiType(Command.SubmitQueueEntry));

        It should_have_an_id_in_command = () => message.Root.Element(Element.Command).GetId().ShouldNotBeNull();

        It should_have_id_starts_with_sqe = () => message.Root.Element(Element.Command).GetId().ShouldStartWith("SQE_");

        It should_have_namespace_definition_for_xsi_with_xsi_prefix =
            () => message.Root.ToString().ShouldContain("xsi:");

        It should_have_version_attribute_in_jmfwith_default_value = () => message.Root.GetVersion().ShouldEqual("1.4");

        It should_have_null_sender_id = () => message.Root.GetSenderId().ShouldBeNull();
    }
}