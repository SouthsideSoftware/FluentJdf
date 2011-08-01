using System.Xml.Linq;
using Infrastructure.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Encoding.TransmissionPartCollection {
    [Subject(typeof(FluentJdf.Encoding.TransmissionPartCollection))]
    public class when_transmission_part_collection_contains_no_jmf_parts
    {
        static FluentJdf.Encoding.ITransmissionPartCollection transmissionPartCollection;

        Establish context = () => {
            transmissionPartCollection = new FluentJdf.Encoding.TransmissionPartCollection();
            transmissionPartCollection.Add(new FluentJdf.Encoding.XmlTransmissionPart(new XDocument(), "test"));
            transmissionPartCollection.Add(new FluentJdf.Encoding.TransmissionPart(TestDataHelper.Instance.PathToTestFile("signs.jpg")));
        };

        It should_not_have_a_message = () => transmissionPartCollection.Message.ShouldBeNull();

        It should_return_has_message_false = () => transmissionPartCollection.HasMessage.ShouldBeFalse();

        It should_not_have_a_message_part = () => transmissionPartCollection.MessagePart.ShouldBeNull();
    }
}