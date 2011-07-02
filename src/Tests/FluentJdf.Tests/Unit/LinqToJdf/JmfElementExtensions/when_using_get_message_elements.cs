using System.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JmfElementExtensions {
    [Subject(typeof(FluentJdf.LinqToJdf.JmfElementExtensions))]
    public class when_using_get_message_elements {
        static FluentJdf.LinqToJdf.Message simpleMessage;
        static FluentJdf.LinqToJdf.Message complexMessage;
        static FluentJdf.LinqToJdf.Message emptyJmf;

        Establish context = () => {
            simpleMessage = FluentJdf.LinqToJdf.Message.Create().AddCommand().SubmitQueueEntry().Message;
            complexMessage = FluentJdf.LinqToJdf.Message.Create().AddQuery().ForceGang().AddCommand().SubmitQueueEntry().Message;
            emptyJmf = FluentJdf.LinqToJdf.Message.Create().Message;
        };

        It should_get_one_message_when_there_is_one_message = () => simpleMessage.Root.GetMessageElements().Count().ShouldEqual(1);

        It should_get_two_messages_when_there_are_two_messages = () => complexMessage.Root.GetMessageElements().Count().ShouldEqual(2);

        It should_get_zero_messages_on_an_empty_jmf = () => emptyJmf.Root.GetMessageElements().Count().ShouldEqual(0);

        It should_get_the_correct_message_name_in_single_message_case = () => simpleMessage.Root.GetMessageElements().First().Name.ShouldEqual(Element.Command);

        It should_get_correct_first_message_name_in_two_message_case =
            () => complexMessage.Root.GetMessageElements().First().Name.ShouldEqual(Element.Query);

        It should_get_correct_second_message_name_in_two_message_case =
            () => complexMessage.Root.GetMessageElements().Skip(1).Take(1).First().Name.ShouldEqual(Element.Command);
    }
}