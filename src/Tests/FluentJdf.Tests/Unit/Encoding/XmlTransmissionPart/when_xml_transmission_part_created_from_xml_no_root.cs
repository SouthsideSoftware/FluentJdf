using System.Xml.Linq;
using FluentJdf.Encoding;
using Infrastructure.Core.Helpers;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Encoding.XmlTransmissionPart {
    [Subject(typeof(FluentJdf.Encoding.TransmissionPart))]
    public class when_xml_transmission_part_created_from_xml_no_root {
        static FluentJdf.Encoding.XmlTransmissionPart transmissionPart;

        Because of = () => transmissionPart = new FluentJdf.Encoding.XmlTransmissionPart(new XDocument(), "test1");

        It should_have_mime_type_for_xml = () => transmissionPart.MimeType.ShouldEqual(".xml".MimeType());

        It should_have_name_ending_with_same_text_as_file_name = () => transmissionPart.Name.Equals("test1");

        It should_have_an_id = () => transmissionPart.Id.ShouldNotBeEmpty();

        It throws_exception_when_trying_to_get_stream = () => Catch.Exception(() => transmissionPart.CopyOfStream()).ShouldNotBeNull();

        It should_have_xml_type_jdf = () => transmissionPart.XmlType.ShouldEqual(XmlType.Other);
    }
}