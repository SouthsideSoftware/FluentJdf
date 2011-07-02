using System.Linq;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.Message {
    [Subject(typeof(FluentJdf.LinqToJdf.Message))]
    public class when_using_copy_constructor {
        static FluentJdf.LinqToJdf.Message sourceMessage;
        static FluentJdf.LinqToJdf.Message copiedMessage;

        Establish context = () => sourceMessage = FluentJdf.LinqToJdf.Message.Create().AddQuery().SubmissionMethods().Message;

        Because of = () => copiedMessage = new FluentJdf.LinqToJdf.Message(sourceMessage);

        It should_have_copied_content_same_elements_and_attributes_as_source = () => FluentJdf.LinqToJdf.Message.DeepEquals(copiedMessage, sourceMessage);

        It should_not_be_same_instance_of_root = () => copiedMessage.Root.ShouldNotEqual(sourceMessage.Root);

        It should_not_be_same_instance_of_first_child_of_root = () => copiedMessage.Root.Elements().First().ShouldNotEqual(sourceMessage.Root.Elements().First());
    }
}