using System.IO;
using System.Linq;
using FluentJdf.Encoding;
using FluentJdf.LinqToJdf;
using Infrastructure.Core.Helpers;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Encoding.PassThroughEncoding {
    [Subject(typeof (FluentJdf.Encoding.PassThroughEncoding))]
    public class when_decoding_jmf_xml {
        static ITransmissionPartCollection transmissionPartCollection;
        static long originalStreamLength;
        static Stream stream;

        Establish context = () => {
                                stream =
                                    new FluentJdf.Encoding.XmlTransmissionPart(Ticket.Create().AddNode().Message().Element.Document, "test").
                                        CopyOfStream();
                                originalStreamLength = stream.Length;
                            };

        Because of = () => transmissionPartCollection =
                           new FluentJdf.Encoding.PassThroughEncoding().Decode("test", stream,
                                                                               MimeTypeHelper.JmfMimeType);

        It should_have_a_stream_with_length_of_original_in_transmission_part =
            () => transmissionPartCollection.FirstOrDefault().CopyOfStream().Length.ShouldEqual(originalStreamLength);

        It should_have_a_xml_transmission_part_in_collection =
            () => transmissionPartCollection.First().ShouldBe(typeof (FluentJdf.Encoding.XmlTransmissionPart));

        It should_have_one_part_in_the_collection = () => transmissionPartCollection.Count.ShouldEqual(1);

        It should_have_jmf_mime_type_in_transmission_part =
            () => transmissionPartCollection.First().MimeType.ShouldEqual(MimeTypeHelper.JmfMimeType);
    }
}