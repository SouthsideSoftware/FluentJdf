using System.IO;
using System.Linq;
using FluentJdf.Configuration;
using FluentJdf.Encoding;
using FluentJdf.LinqToJdf;
using Infrastructure.Core.Helpers;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Encoding.PassThroughEncoding {
    [Subject(typeof (FluentJdf.Encoding.PassThroughEncoding))]
    public class when_decoding_jdf_xml {
        static ITransmissionPartCollection transmissionPartCollection;
        static long originalStreamLength;
        static Stream stream;

        Establish context = () => {
            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
            stream =
                new FluentJdf.Encoding.XmlTransmissionPart(Ticket.CreateIntent().Element.Document, "test").
                    CopyOfStream();
            originalStreamLength = stream.Length;
        };

        Because of = () => transmissionPartCollection =
                           new FluentJdf.Encoding.PassThroughEncoding(new TransmissionPartFactory()).Decode("test", stream,
                                                                               MimeTypeHelper.JdfMimeType);

        It should_have_a_stream_with_length_of_original_in_transmission_part =
            () => transmissionPartCollection.FirstOrDefault().CopyOfStream().Length.ShouldEqual(originalStreamLength);

        It should_have_a_ticket_transmission_part_in_collection =
            () => transmissionPartCollection.First().ShouldBe(typeof (FluentJdf.Encoding.TicketTransmissionPart));

        It should_have_jdf_mime_type_in_transmission_part =
            () => transmissionPartCollection.First().MimeType.ShouldEqual(MimeTypeHelper.JdfMimeType);

        It should_have_one_part_in_the_collection = () => transmissionPartCollection.Count.ShouldEqual(1);
    }
}