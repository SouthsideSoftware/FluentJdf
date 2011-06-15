using System.Xml.Linq;
using FluentJdf.Encoding;
using FluentJdf.LinqToJdf;
using Infrastructure.Core.Helpers;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Encoding.XmlTransmissionPart {
    [Subject(typeof(FluentJdf.Encoding.TransmissionPart))]
    public class when_xml_transmission_part_created_from_xml_that_is_neither_jdf_nor_jmf {
        static FluentJdf.Encoding.XmlTransmissionPart transmissionPart;

        //the JMF element has no namespace so is not JMF
        Because of = () => transmissionPart = new FluentJdf.Encoding.XmlTransmissionPart(new XDocument(new XElement("JMF")), "test1");

        It should_have_mime_type_for_xml = () => transmissionPart.MimeType.ShouldEqual(".xml".MimeType());

        It should_have_name_ending_with_same_text_as_file_name = () => transmissionPart.Name.Equals("test1");

        It should_have_an_id = () => transmissionPart.Id.ShouldNotBeEmpty();

        It should_be_able_to_get_stream = () => transmissionPart.CopyOfStream().ShouldNotBeNull();

        It should_have_xml_type_jdf = () => transmissionPart.XmlType.ShouldEqual(XmlType.Other);
    }
}