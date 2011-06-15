using FluentJdf.Encoding;
using Infrastructure.Core.Helpers;
using Infrastructure.Core.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Encoding.XmlTransmissionPart {
    [Subject(typeof(FluentJdf.Encoding.TransmissionPart))]
    public class when_xml_transmission_part_created_from_file {
        static FluentJdf.Encoding.XmlTransmissionPart transmissionPart;

        Because of = () => transmissionPart = new FluentJdf.Encoding.XmlTransmissionPart(TestDataHelper.Instance.PathToTestFile("sampleJdf.xml"));

        It should_have_mime_type_for_jdf = () => transmissionPart.MimeType.ShouldEqual(".jdf".MimeType());

        It should_have_name_ending_with_same_text_as_file_name = () => transmissionPart.Name.EndsWith(".xml");

        It should_have_an_id = () => transmissionPart.Id.ShouldNotBeEmpty();

        It should_be_able_to_get_stream = () => transmissionPart.CopyOfStream().ShouldNotBeNull();

        It should_have_xml_type_jdf = () => transmissionPart.XmlType.ShouldEqual(XmlType.Jdf);
    }
}