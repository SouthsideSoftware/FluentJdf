using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.Message {
    [Subject(typeof(FluentJdf.LinqToJdf.Message))]
    public class when_creating_from_a_template_in_an_xdocument {
        static FluentJdf.LinqToJdf.Message generatedMessage;
        static XDocument templateDocument;

        Establish context = () => templateDocument = new XDocument(FluentJdf.LinqToJdf.Message.Create().AddCommand().SubmitQueueEntry().With().Attribute("foo", "[:foo:]").Message);

        Because of = () => generatedMessage = FluentJdf.LinqToJdf.Message.CreateFromTemplate(templateDocument)
                                                  .With().NameValue("foo", "myFoo").Generate();

        It should_have_message_with_attribute_set_from_replacement = () => generatedMessage.Descendants(Element.Command).First().GetAttributeValueOrNull("foo").ShouldEqual("myFoo");
    }
}
