using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Infrastructure.Core.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Encoding.TransmissionPartCollection {
    [Subject(typeof(FluentJdf.Encoding.TransmissionPartCollection))]
    public class when_transmission_part_collection_has_one_jmf_part
    {
        static FluentJdf.Encoding.TransmissionPartCollection transmissionPartCollection;

        Establish context = () => {
            transmissionPartCollection = new FluentJdf.Encoding.TransmissionPartCollection();
            transmissionPartCollection.Add(new FluentJdf.Encoding.XmlTransmissionPart(new XDocument(), "test"));
            transmissionPartCollection.Add(new FluentJdf.Encoding.TransmissionPart(TestDataHelper.Instance.PathToTestFile("signs.jpg")));
            transmissionPartCollection.Add(new FluentJdf.Encoding.XmlTransmissionPart(new XDocument(new XElement(Element.JMF)), "test2"));
        };

        It should_have_a_message = () => transmissionPartCollection.Message.ShouldNotBeNull();

        It should_return_has_message_true = () => transmissionPartCollection.HasMessage.ShouldBeTrue();

        It should_have_a_message_part = () => transmissionPartCollection.MessagePart.ShouldNotBeNull();
    }
}