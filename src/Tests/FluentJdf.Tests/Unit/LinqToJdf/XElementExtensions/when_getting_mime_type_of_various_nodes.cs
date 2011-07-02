using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using Infrastructure.Core.Helpers;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.XElementExtensions {
    [Subject(typeof (FluentJdf.LinqToJdf.XElementExtensions))]
    public class when_getting_mime_type_of_various_nodes {
        It should_get_jdf_mime_type_from_document_having_jdf_root =
            () => FluentJdf.LinqToJdf.Ticket.CreateIntent().Element.Document.MimeType().ShouldEqual(MimeTypeHelper.JdfMimeType);

        It should_get_jdf_mime_type_from_jdf_node = () => FluentJdf.LinqToJdf.Ticket.CreateIntent().Element.MimeType().ShouldEqual(MimeTypeHelper.JdfMimeType);

        It should_get_jmf_mime_type_from_jmf_node =
            () => FluentJdf.LinqToJdf.Message.Create().Element.MimeType().ShouldEqual(MimeTypeHelper.JmfMimeType);

        It should_get_other_mime_type_from_other_node_in_jmf = () => {
            XElement message = FluentJdf.LinqToJdf.Message.Create().Element;
            var otherElement = new XElement("other");
            message.Add(otherElement);
            otherElement.MimeType().ShouldEqual(MimeTypeHelper.XmlMimeType);
        };
    }
}