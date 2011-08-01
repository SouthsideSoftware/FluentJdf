using System.IO;
using Infrastructure.Core.Helpers;
using Infrastructure.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Encoding.TransmissionPart {
    [Subject(typeof(FluentJdf.Encoding.TransmissionPart))]
    public class when_transmission_part_created_from_stream {
        static FluentJdf.Encoding.TransmissionPart transmissionPart;
        static Stream stream;

        Establish context = () => stream = TestDataHelper.Instance.GetTestStream("signs.jpg");

        Because of = () => transmissionPart = new FluentJdf.Encoding.TransmissionPart(stream, "signs.jpg", "signs.jpg".MimeType());

        It should_have_mime_type_for_jpg = () => transmissionPart.MimeType.ShouldEqual(".jpg".MimeType());

        It should_have_name_ending_with_jpg = () => transmissionPart.Name.EndsWith(".jpg");

        It should_have_an_id = () => transmissionPart.Id.ShouldNotBeEmpty();

        It should_be_able_to_get_stream = () => transmissionPart.CopyOfStream().ShouldNotBeNull();
    }
}