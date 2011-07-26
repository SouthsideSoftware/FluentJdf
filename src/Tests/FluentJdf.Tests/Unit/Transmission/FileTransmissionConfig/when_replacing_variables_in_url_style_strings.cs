using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Transmission.FileTransmissionConfig {
    [Subject(typeof(FluentJdf.Transmission.FileTransmissionConfig))]
    public class when_replacing_variables_in_url_style_strings {
        It should_properly_replace_at_start_of_path = () => FluentJdf.Transmission.FileTransmissionConfig.ReplaceVar("${var}//foo/fi/", "var", "replacement").ShouldEqual("replacement//foo/fi/");

        It should_properly_replace_in_middle_of_path =
            () => FluentJdf.Transmission.FileTransmissionConfig.ReplaceVar("file://foo/${var}/fi/", "var", "replacement").ShouldEqual("file://foo/replacement/fi/");

        It should_properly_replace_var_at_end_of_path =
            () => FluentJdf.Transmission.FileTransmissionConfig.ReplaceVar("file://foo/fi/${var}", "var", "replacement").ShouldEqual("file://foo/fi/replacement");

        It should_properly_replace_var_before_ending_slash =
            () => FluentJdf.Transmission.FileTransmissionConfig.ReplaceVar("file://foo/fi/${var}/", "var", "replacement").ShouldEqual("file://foo/fi/replacement/");

        [Ignore("Right now we don't handle embedded forward and back slashed in the replacment variable")] It should_properly_replace_var_with_back_slash_at_end_of_path =
            () => FluentJdf.Transmission.FileTransmissionConfig.ReplaceVar("file://foo/fi/${var}", "var", @"\replacement\").ShouldEqual(@"file://foo/fi/replacement\");

        [Ignore("Right now we don't handle embedded forward and back slashed in the replacment variable")] It should_properly_replace_var_with_back_slash_at_start_of_path =
            () => FluentJdf.Transmission.FileTransmissionConfig.ReplaceVar("${var}//foo/fi/", "var", @"\replacement\").ShouldEqual(@"\replacement//foo/fi/");

        [Ignore("Right now we don't handle embedded forward and back slashed in the replacment variable")] It should_properly_replace_var_with_back_slash_before_ending_slash =
            () => FluentJdf.Transmission.FileTransmissionConfig.ReplaceVar("file://foo/fi/${var}/", "var", @"\replacement\").ShouldEqual(@"file://foo/fi/replacement\");

        [Ignore("Right now we don't handle embedded forward and back slashed in the replacment variable")] It should_properly_replace_var_with_back_slash_in_middle_of_path =
            () => FluentJdf.Transmission.FileTransmissionConfig.ReplaceVar("file://foo/${var}/fi/", "var", @"\replacement\").ShouldEqual(@"file://foo/replacement/fi/");

        [Ignore("Right now we don't handle embedded forward and back slashed in the replacment variable")] It should_properly_replace_var_with_back_slash_when_appears_twice_in_path =
            () => FluentJdf.Transmission.FileTransmissionConfig.ReplaceVar("file://foo/${var}/fi/${var}", "var", @"\replacement\").ShouldEqual(@"file://foo/replacement/fi/replacement\");

        [Ignore("Right now we don't handle embedded forward and back slashed in the replacment variable")] It should_properly_replace_var_with_slash_at_end_of_path =
            () => FluentJdf.Transmission.FileTransmissionConfig.ReplaceVar("file://foo/fi/${var}", "var", "/replacement/").ShouldEqual("file://foo/fi/replacement/");

        [Ignore("Right now we don't handle embedded forward and back slashed in the replacment variable")] It should_properly_replace_var_with_slash_at_start_of_path =
            () => FluentJdf.Transmission.FileTransmissionConfig.ReplaceVar("${var}//foo/fi/", "var", "/replacement/").ShouldEqual("/replacement//foo/fi/");

        [Ignore("Right now we don't handle embedded forward and back slashed in the replacment variable")] It should_properly_replace_var_with_slash_before_ending_slash =
            () => FluentJdf.Transmission.FileTransmissionConfig.ReplaceVar("file://foo/fi/${var}/", "var", "/replacement/").ShouldEqual("file://foo/fi/replacement/");

        [Ignore("Right now we don't handle embedded forward and back slashed in the replacment variable")] It should_properly_replace_var_with_slash_in_middle_of_path =
            () => FluentJdf.Transmission.FileTransmissionConfig.ReplaceVar("file://foo/${var}/fi/", "var", "/replacement/").ShouldEqual("file://foo/replacement/fi/");

        [Ignore("Right now we don't handle embedded forward and back slashed in the replacment variable")] It should_properly_replace_var_with_slash_when_appears_twice_in_path =
            () => FluentJdf.Transmission.FileTransmissionConfig.ReplaceVar("file://foo/${var}/fi/${var}", "var", "/replacement/").ShouldEqual("file://foo/replacement/fi/replacement/");

        It should_properly_replace_when_appears_twice_in_path =
            () => FluentJdf.Transmission.FileTransmissionConfig.ReplaceVar("file://foo/${var}/fi/${var}", "var", "replacement").ShouldEqual("file://foo/replacement/fi/replacement");
    }
}