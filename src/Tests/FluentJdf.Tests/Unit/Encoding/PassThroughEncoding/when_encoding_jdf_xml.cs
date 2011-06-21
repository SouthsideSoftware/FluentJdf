using System.Xml.Linq;
using FluentJdf.Encoding;
using FluentJdf.LinqToJdf;
using Infrastructure.Core.Helpers;
using Infrastructure.Core.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Encoding.PassThroughEncoding {
    [Subject(typeof(FluentJdf.Encoding.PassThroughEncoding))]
    public class when_encoding_jdf_xml {
        static EncodingResult result;
        static FluentJdf.Encoding.XmlTransmissionPart transmissionPart;

        Establish context = () => transmissionPart = new FluentJdf.Encoding.XmlTransmissionPart(Ticket.CreateIntent().Element.Document, "test");

        Because of = () => {
                         result = new FluentJdf.Encoding.PassThroughEncoding().Encode(transmissionPart);
                     };

        It should_have_a_result_stream = () => result.Stream.ShouldNotBeNull();

        It should_have_content_type_for_jdf = () => result.ContentType.ShouldEqual(MimeTypeHelper.JdfMimeType);

        It should_have_result_stream_same_length_as_part_stream = () => transmissionPart.CopyOfStream().Length.ShouldEqual(result.Stream.Length);

        It should_create_same_document_from_encoding_stream = () => XDocument.DeepEquals(XDocument.Load(result.Stream), transmissionPart.Document);
    }
}