using ExpectedObjects;
using Infrastructure.Core;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Transmission.Logging.TransmissionData
{
    [Subject(typeof(FluentJdf.Transmission.Logging.TransmissionData))]
    public class when_creating_with_simple_content_type {
        static FluentJdf.Transmission.Logging.TransmissionData transmissionData;
        static ExpectedObject expectedWebData;

        Establish context = () => expectedWebData = new {
                                                            ContentType = "foo"
                                                        }.ToExpectedObject();

        Because of = () => transmissionData = new FluentJdf.Transmission.Logging.TransmissionData(new TempFileStream(), "foo");

        It should_have_content_type_as_set = () => expectedWebData.ShouldMatch(transmissionData);
    }
}
