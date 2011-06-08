using System.Linq;
using System.Xml.Linq;
using System.Xml.Schema;
using Jdp.Jdf.LinqToJdf;
using Jdp.Jdf.Schema;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.Schema.ValidationMessage {
    [Subject(typeof (Jdf.Schema.ValidationMessage))]
    public class when_creating_validation_messages_with_various_options {
        static XDocument document;

        Establish context =
            () => document = Ticket.Create().AddNode().Process(ProcessType.Cutting, ProcessType.Creasing).WithInput().BindingIntent().Element.Document;

        It should_get_correct_xpath_text_and_type_when_source_is_nested_element = () => {
                                                                                      var message =
                                                                                          new Jdf.Schema.ValidationMessage(
                                                                                              document.Root.ResourcePoolElement().Element(
                                                                                                  Resource.BindingIntent),
                                                                                              XmlSeverityType.
                                                                                                  Error,
                                                                                              "test");
                                                                                      message.ValidationMessageType.ShouldEqual(
                                                                                          ValidationMessageType.Error);
                                                                                      message.Message.ShouldEqual("test");
                                                                                      message.XPath.ShouldEqual("/JDF/ResourcePool/BindingIntent");
                                                                                      document.JdfXPathSelectElement(message.XPath).ShouldEqual(
                                                                                          document.Descendants(Resource.BindingIntent).FirstOrDefault());
                                                                                  };

        It should_get_xpath_root_correct_text_and_type_when_source_is_not_element_or_attribute = () => {
                                                                                                     var message =
                                                                                                         new Jdf.Schema.ValidationMessage(document,
                                                                                                                                          XmlSeverityType
                                                                                                                                              .
                                                                                                                                              Error,
                                                                                                                                          "test");
                                                                                                     message.ValidationMessageType.ShouldEqual(
                                                                                                         ValidationMessageType.Error);
                                                                                                     message.Message.ShouldEqual("test");
                                                                                                     message.XPath.ShouldEqual("/");
                                                                                                 };

        It should_get_xpath_root_jdf_correct_text_and_type_when_source_is_root_element = () => {
                                                                                             var message =
                                                                                                 new Jdf.Schema.ValidationMessage(document.Root,
                                                                                                                                  XmlSeverityType.
                                                                                                                                      Error,
                                                                                                                                  "test");
                                                                                             message.ValidationMessageType.ShouldEqual(
                                                                                                 ValidationMessageType.Error);
                                                                                             message.Message.ShouldEqual("test");
                                                                                             message.XPath.ShouldEqual("/JDF");
                                                                                             document.JdfXPathSelectElement(message.XPath).ShouldEqual
                                                                                                 (document.Root);
                                                                                         };
    }
}