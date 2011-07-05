using System.Collections.Specialized;
using Infrastructure.Core;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Transmission.Logging.TransmissionData
{
    [Subject(typeof(FluentJdf.Transmission.Logging.TransmissionData))]
    public class when_getting_diagnostic_logging_string
    {
        static string diagnosticLoggingString;
        static FluentJdf.Transmission.Logging.TransmissionData transmissionData;

        Establish context = () =>
        {
            var headers = new NameValueCollection();
            headers.Add("One", "1");
            headers.Add("Two", "2");
            transmissionData = new FluentJdf.Transmission.Logging.TransmissionData(headers, new TempFileStream());
        };

        Because of = () => diagnosticLoggingString = transmissionData.ToLogString();

        It should_have_header_information_in_log_string = () => diagnosticLoggingString.ShouldContain("Header:One = 1");

        It should_have_default_content_type_since_headers_did_not_have_one = () => diagnosticLoggingString.ShouldContain("ContentType = text/html");
    }
}
