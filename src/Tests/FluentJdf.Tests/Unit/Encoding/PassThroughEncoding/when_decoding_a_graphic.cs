using System.IO;
using System.Linq;
using FluentJdf.Configuration;
using FluentJdf.Encoding;
using Infrastructure.Core.Helpers;
using Infrastructure.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Encoding.PassThroughEncoding {
    [Subject(typeof (FluentJdf.Encoding.PassThroughEncoding))]
    public class when_decoding_a_graphic {
        static ITransmissionPartCollection transmissionPartCollection;
        static long originalStreamLength;
        static Stream stream;

        Establish context = () => {
            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
            stream = TestDataHelper.Instance.GetTestStream("signs.jpg");
            originalStreamLength = stream.Length;
        };

        Because of = () => transmissionPartCollection =
                           new FluentJdf.Encoding.PassThroughEncoding(new TransmissionPartFactory()).Decode("test", stream,
                                                                               MimeTypeHelper.JpegMimeType);

        It should_have_a_stream_with_length_of_original_in_transmission_part =
            () => transmissionPartCollection.FirstOrDefault().CopyOfStream().Length.ShouldEqual(originalStreamLength);

        It should_have_a_transmission_part_in_collection =
            () => transmissionPartCollection.First().ShouldBe(typeof (FluentJdf.Encoding.TransmissionPart));

        It should_have_jpeg_mime_type_in_transmission_part =
            () => transmissionPartCollection.First().MimeType.ShouldEqual(MimeTypeHelper.JpegMimeType);

        It should_have_one_part_in_the_collection = () => transmissionPartCollection.Count.ShouldEqual(1);
    }
}