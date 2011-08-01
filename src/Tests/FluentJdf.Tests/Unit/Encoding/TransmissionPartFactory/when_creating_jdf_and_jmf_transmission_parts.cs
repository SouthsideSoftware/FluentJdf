using System.Xml.Linq;
using FluentJdf.Encoding;
using FluentJdf.LinqToJdf;
using Infrastructure.Container.CastleWindsor;
using Infrastructure.Core;
using Infrastructure.Core.Helpers;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Encoding.EncodingFactory {
    [Subject(typeof(FluentJdf.Encoding.TransmissionPartFactory))]
    public class when_creating_jdf_and_jmf_transmission_parts {
        static FluentJdf.Encoding.ITransmissionPartFactory factory;

        Establish context = () => {
            Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
            factory = new FluentJdf.Encoding.TransmissionPartFactory();
        };

        It should_get_jdf_transmission_part_for_jdf_content_when_creating_from_jdf_mime_type_stream = () => {
            using (var stream = new TempFileStream()) {
                var ticket = Ticket.CreateIntent().Ticket;
                ticket.Save(stream);
                var transmissionPart = factory.CreateTransmissionPart("test", stream, MimeTypeHelper.JdfMimeType);
                transmissionPart.ShouldBeOfType(typeof(TicketTransmissionPart));
            }

        };

        It should_get_jdf_transmission_part_for_jdf_content_when_creating_from_xml_mime_type_stream = () =>
        {
            using (var stream = new TempFileStream())
            {
                var ticket = Ticket.CreateIntent().Ticket;
                ticket.Save(stream);
                var transmissionPart = factory.CreateTransmissionPart("test", stream, MimeTypeHelper.XmlMimeType);
                transmissionPart.ShouldBeOfType(typeof(TicketTransmissionPart));
            }
        };

        It should_get_jdf_transmission_part_for_jdf_content_when_creating_from_ticket = () => {

            var ticket = Ticket.CreateIntent().Ticket;
            var transmissionPart = factory.CreateTransmissionPart("test", ticket);
            transmissionPart.ShouldBeOfType(typeof (TicketTransmissionPart));
        };

        It should_get_jdf_transmission_part_for_jdf_content_when_creating_from_document = () =>
        {

            var doc = new XDocument(Ticket.CreateIntent().Ticket);
            var transmissionPart = factory.CreateTransmissionPart("test", doc);
            transmissionPart.ShouldBeOfType(typeof(TicketTransmissionPart));
        };

        It should_get_jmf_transmission_part_for_jmf_content_when_creating_from_jmf_mime_type_stream = () =>
        {
            using (var stream = new TempFileStream()) {
                var message = Message.Create().AddQuery().SubmissionMethods().Message;
                message.Save(stream);
                var transmissionPart = factory.CreateTransmissionPart("test", stream, MimeTypeHelper.JmfMimeType);
                transmissionPart.ShouldBeOfType(typeof(MessageTransmissionPart));
            }

        };

        It should_get_jmf_transmission_part_for_jmf_content_when_creating_from_xml_mime_type_stream = () =>
        {
            using (var stream = new TempFileStream())
            {
                var message = Message.Create().AddQuery().SubmissionMethods().Message;
                message.Save(stream);
                var transmissionPart = factory.CreateTransmissionPart("test", stream, MimeTypeHelper.XmlMimeType);
                transmissionPart.ShouldBeOfType(typeof(MessageTransmissionPart));
            }
        };

        It should_get_jmf_transmission_part_for_jmf_content_when_creating_from_message = () => {

            var message = Message.Create().AddQuery().SubmissionMethods().Message;
            var transmissionPart = factory.CreateTransmissionPart("test", message);
            transmissionPart.ShouldBeOfType(typeof(MessageTransmissionPart));
        };

        It should_get_jmf_transmission_part_for_jmf_content_when_creating_from_document = () =>
        {

            var message = Message.Create().AddQuery().SubmissionMethods().Message;
            var doc = new XDocument(message);
            var transmissionPart = factory.CreateTransmissionPart("test", doc);
            transmissionPart.ShouldBeOfType(typeof(MessageTransmissionPart));
        };

        It should_get_xml_transmission_part_for_xml_content_when_creating_from_xml_mime_type_stream = () =>
        {
            using (var stream = new TempFileStream()) {
                var doc = new XDocument(new XElement("dfoo"));
                doc.Save(stream);
                var transmissionPart = factory.CreateTransmissionPart("test", stream, MimeTypeHelper.XmlMimeType);
                transmissionPart.ShouldBeOfType(typeof(FluentJdf.Encoding.XmlTransmissionPart));
            }

        };

        It should_get_xml_transmission_part_for_xml_content_when_creating_from_document = () => {

            var doc = new XDocument(new XElement("foo"));
            var transmissionPart = factory.CreateTransmissionPart("test", doc);
            transmissionPart.ShouldBeOfType(typeof (FluentJdf.Encoding.XmlTransmissionPart));
        };
    }
}