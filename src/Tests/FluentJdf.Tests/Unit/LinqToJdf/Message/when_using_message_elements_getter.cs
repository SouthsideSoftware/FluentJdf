using System.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.Message {
    [Subject(typeof(FluentJdf.LinqToJdf.Message))]
    public class when_using_message_elements_getter {
        static FluentJdf.LinqToJdf.Message simpleMessage;
        static FluentJdf.LinqToJdf.Message complexMessage;
        static FluentJdf.LinqToJdf.Message emptyJmf;

        Establish context = () => {
            simpleMessage = FluentJdf.LinqToJdf.Message.Create().AddCommand().SubmitQueueEntry().Message;
            complexMessage = FluentJdf.LinqToJdf.Message.Create().AddQuery().ForceGang().AddCommand().SubmitQueueEntry().Message;
            emptyJmf = FluentJdf.LinqToJdf.Message.Create().Message;
        };

        It should_get_one_message_name_when_there_is_one_message = () => simpleMessage.MessageElements.Count().ShouldEqual(1);

        It should_get_two_message_names_when_there_are_two_messages = () => complexMessage.MessageElements.Count().ShouldEqual(2);

        It should_get_zero_message_names_on_an_empty_jmf = () => emptyJmf.MessageElements.Count().ShouldEqual(0);

        It should_get_the_correct_message_name_in_single_message_case = () => simpleMessage.MessageElements.First().Name.ShouldEqual(Element.Command);

        It should_get_correct_first_message_name_in_two_message_case =
            () => complexMessage.MessageElements.First().Name.ShouldEqual(Element.Query);

        It should_get_correct_second_message_name_in_two_message_case =
            () => complexMessage.MessageElements.Skip(1).Take(1).First().Name.ShouldEqual(Element.Command);
    }
}