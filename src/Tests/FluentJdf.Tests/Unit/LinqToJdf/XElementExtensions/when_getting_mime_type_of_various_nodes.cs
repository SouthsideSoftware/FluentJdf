using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Infrastructure.Core.Helpers;
using Machine.Specifications;
using FluentJdf.LinqToJdf;

namespace FluentJdf.Tests.Unit.LinqToJdf.XElementExtensions
{
    [Subject(typeof(FluentJdf.LinqToJdf.XElementExtensions))]
    public class when_getting_mime_type_of_various_nodes
    {
        It should_get_jdf_mime_type_from_jdf_node = () => Ticket.Create().AddNode().Intent().Element.MimeType().ShouldEqual(MimeTypeHelper.JdfMimeType);

        It should_get_jmf_mime_type_from_jmf_node = () => Ticket.Create().AddNode().Message().Element.MimeType().ShouldEqual(MimeTypeHelper.JmfMimeType);

        It should_get_other_mime_type_from_other_node_in_jmf = () => {
                                                                   var message = Ticket.Create().AddNode().Message().Element;
                                                                   var otherElement = new XElement("other");
                                                                   message.Add(otherElement);
                                                                   otherElement.MimeType().ShouldEqual(MimeTypeHelper.XmlMimeType);
                                                               };

        It should_get_jdf_mime_type_from_document_having_jdf_root = () => Ticket.Create().AddNode().Intent().Element.Document.MimeType().ShouldEqual(MimeTypeHelper.JdfMimeType);
    }
}
