using System.Threading;
using FluentJdf.Configuration;
using Infrastructure.Core.CodeContracts;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Configuration.HttpTransmissionSettings {
    [Subject(typeof (FluentJdf.Configuration.HttpTransmissionSettings))]
    public class when_setting_http_transmission_settings {
        It should_be_able_to_set_infinite_timeout = () => {
            Library.Settings.ResetToDefaults();
            Library.Settings.WithHttpTransmissionSettings().TimeoutInSeconds(Timeout.Infinite);
            Library.Settings.HttpTransmissionSettings.TimeoutInSeconds.ShouldEqual(Timeout.Infinite);
        };

        It should_be_able_to_set_proxy_with_credentials_but_no_domain = () => {
            Library.Settings.ResetToDefaults();
            Library.Settings.WithHttpTransmissionSettings().Proxy("http://proxyhere", true, "user", "password");
            Library.Settings.HttpTransmissionSettings.HasProxySettings.ShouldBeTrue();
        };

        It should_be_able_to_set_proxy_with_credentials_and_domain = () => {
            Library.Settings.ResetToDefaults();
            Library.Settings.WithHttpTransmissionSettings().Proxy("http://proxyhere", true, "user", "password", "domain");
            Library.Settings.HttpTransmissionSettings.HasProxySettings.ShouldBeTrue();
        };

        It should_be_able_to_set_proxy_with_just_url = () => {
            Library.Settings.ResetToDefaults();
            Library.Settings.WithHttpTransmissionSettings().Proxy("http://proxyhere");
            Library.Settings.HttpTransmissionSettings.HasProxySettings.ShouldBeTrue();
        };

        It should_be_able_to_set_timeout_to_positive_seconds = () => {
            Library.Settings.ResetToDefaults();
            Library.Settings.WithHttpTransmissionSettings().TimeoutInSeconds(5);
            Library.Settings.HttpTransmissionSettings.TimeoutInSeconds.ShouldEqual(5);
        };

        It should_fail_to_set_negative_timeout = () => {
            Library.Settings.ResetToDefaults();
            Catch.Exception(() => Library.Settings.WithHttpTransmissionSettings().TimeoutInSeconds(-100)).
                ShouldBe(typeof (PreconditionException));
        };

        It should_have_correct_settings_when_set_proxy_with_credentials_but_no_domain = () => {
            Library.Settings.ResetToDefaults();
            Library.Settings.WithHttpTransmissionSettings().Proxy("http://proxyhere", true, "user", "password");
            Library.Settings.HttpTransmissionSettings.ProxyUrl.ShouldEqual("http://proxyhere");
            Library.Settings.HttpTransmissionSettings.ProxyUserName.ShouldEqual("user");
            Library.Settings.HttpTransmissionSettings.ProxyPassword.ShouldEqual("password");
        };

        It should_have_correct_settings_when_set_proxy_with_credentials_and_domain = () => {
            Library.Settings.ResetToDefaults();
            Library.Settings.WithHttpTransmissionSettings().Proxy("http://proxyhere", true, "user", "password", "domain");
            Library.Settings.HttpTransmissionSettings.ProxyUrl.ShouldEqual("http://proxyhere");
            Library.Settings.HttpTransmissionSettings.ProxyUserName.ShouldEqual("user");
            Library.Settings.HttpTransmissionSettings.ProxyPassword.ShouldEqual("password");
            Library.Settings.HttpTransmissionSettings.ProxyDomain.ShouldEqual("domain");
        };

        It should_have_no_proxy_credentials_when_just_proxy_url_is_configured = () => {
            Library.Settings.ResetToDefaults();
            Library.Settings.WithHttpTransmissionSettings().Proxy("http://proxyhere");
            Library.Settings.HttpTransmissionSettings.HasProxyCredentials.ShouldBeFalse();
        };

        It should_have_no_proxy_set_by_default = () => {
            Library.Settings.ResetToDefaults();
            Library.Settings.HttpTransmissionSettings.HasProxySettings.ShouldBeFalse();
        };

        It should_have_proxy_credentials_when_configured = () => {
            Library.Settings.ResetToDefaults();
            Library.Settings.WithHttpTransmissionSettings().Proxy("http://proxyhere", true, "user", "password");
            Library.Settings.HttpTransmissionSettings.HasProxyCredentials.ShouldBeTrue();
        };
    }
}