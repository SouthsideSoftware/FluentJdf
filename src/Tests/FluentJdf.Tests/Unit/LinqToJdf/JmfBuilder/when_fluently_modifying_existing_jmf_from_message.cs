using System.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JmfBuilder {
    [Subject("Highly fluent JMF interface")]
    public class when_fluently_modifying_existing_jmf_from_message {
        static Message message;

        Establish context = () => message = Message.Create().AddCommand().SubmitQueueEntry().Message;

        Because of = () => message.ModifyJmfNode().AddCommand().SubmitQueueEntry();

        It should_have_jmf_at_root = () => message.Root.Name.ShouldEqual(Element.JMF);

        It should_have_two_commands_in_jmf = () => message.Root.Elements(Element.Command).Count().ShouldEqual(2);

        It should_have_type_submit_queue_entry_for_first_command = () => message.Root.Elements(Element.Command).First().GetMessageType().ShouldEqual(Command.SubmitQueueEntry);

        It should_have_type_submit_queue_entry_for_second_command = () => message.Root.Elements(Element.Command).Skip(1).Take(1).First().GetMessageType().ShouldEqual(Command.SubmitQueueEntry);

        It should_have_commands_with_unique_ids = () => message.Root.Elements(Element.Command).Skip(1).Take(1).First().GetId().ShouldNotEqual(
            message.Root.Elements(Element.Command).First().GetId());
    }
}