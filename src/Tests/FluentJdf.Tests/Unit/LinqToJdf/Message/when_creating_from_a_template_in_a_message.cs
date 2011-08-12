using System.Linq;
using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.Message {
    [Subject(typeof(FluentJdf.LinqToJdf.Message))]
    public class when_creating_from_a_template_in_a_message {
        static FluentJdf.LinqToJdf.Message generatedMessage;
        static FluentJdf.LinqToJdf.Message templateDocument;

        Establish context = () => templateDocument = FluentJdf.LinqToJdf.Message.Create().AddCommand().SubmitQueueEntry().With().Attribute("foo", "[:foo:]").Message;

        Because of = () => generatedMessage = FluentJdf.LinqToJdf.Message.CreateFromTemplate(templateDocument)
                                                  .With().NameValue("foo", "myFoo").Generate();

        It should_have_message_with_attribute_set_from_replacement = () => generatedMessage.Descendants(Element.Command).First().GetAttributeValueOrNull("foo").ShouldEqual("myFoo");
    }
}