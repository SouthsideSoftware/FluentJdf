using System.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.Message {
    [Subject(typeof(FluentJdf.LinqToJdf.Message))]
    public class when_using_message_element_getter {
        static FluentJdf.LinqToJdf.Message simpleMessage;
        static FluentJdf.LinqToJdf.Message complexMessage;
        static FluentJdf.LinqToJdf.Message emptyJmf;

        Establish context = () => {
            simpleMessage = FluentJdf.LinqToJdf.Message.Create().AddCommand().SubmitQueueEntry().Message;
            complexMessage = FluentJdf.LinqToJdf.Message.Create().AddQuery().ForceGang().AddCommand().SubmitQueueEntry().Message;
            emptyJmf = FluentJdf.LinqToJdf.Message.Create().Message;
        };

        It should_get_message_when_there_is_one_message = () => simpleMessage.MessageElement.ShouldEqual(simpleMessage.Root.Elements().First());

        It should_get_first_message_when_there_are_two_messages = () => complexMessage.MessageElement.ShouldEqual(complexMessage.Root.Elements().First());

        It should_get_no_message_when_there_is_none = () => emptyJmf.MessageElement.ShouldBeNull();
    }
}