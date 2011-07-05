using Infrastructure.Core;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Transmission.Logging.TransmissionData {
    [Subject(typeof(FluentJdf.Transmission.Logging.TransmissionData))]
    public class when_creating_with_content_type_including_char_encoding {
        static FluentJdf.Transmission.Logging.TransmissionData webdata;

        Because of = () => webdata = new FluentJdf.Transmission.Logging.TransmissionData(new TempFileStream(), "foo;char-encoding=utf8");

        It should_have_content_type_without_qualifiers = () => webdata.ContentType.ShouldEqual("foo");
    }
}