using System.Xml.Linq;
using FluentJdf.Encoding;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.XElementExtensions {
    [Subject(typeof (FluentJdf.LinqToJdf.XElementExtensions))]
    public class when_getting_xml_type_of_various_nodes {
        It should_get_jdf_xml_type_from_document_having_jdf_root = () => FluentJdf.LinqToJdf.Ticket.CreateIntent().Element.Document.XmlType().ShouldEqual(XmlType.Jdf);
        It should_get_jdf_xml_type_from_jdf_node = () => FluentJdf.LinqToJdf.Ticket.CreateIntent().Element.XmlType().ShouldEqual(XmlType.Jdf);

        It should_get_jmf_xml_type_from_jmf_node = () => FluentJdf.LinqToJdf.Message.Create().Element.XmlType().ShouldEqual(XmlType.Jmf);

        It should_get_other_xml_type_from_other_node_in_jmf = () => {
            XElement message = FluentJdf.LinqToJdf.Message.Create().Element;
            var otherElement = new XElement("other");
            message.Add(otherElement);
            otherElement.XmlType().ShouldEqual(XmlType.Other);
        };
    }
}