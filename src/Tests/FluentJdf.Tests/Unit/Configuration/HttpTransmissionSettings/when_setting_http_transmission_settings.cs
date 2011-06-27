using System.Threading;
using FluentJdf.Configuration;
using Infrastructure.Core.CodeContracts;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Configuration.HttpTransmissionSettings {
    [Subject(typeof (FluentJdf.Configuration.HttpTransmissionSettings))]
    public class when_setting_http_transmission_settings {
        It should_be_able_to_set_infinite_timeout = () => {
            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdf.Configuration.FluentJdfLibrary.Settings.WithHttpTransmissionSettings().TimeoutInSeconds(Timeout.Infinite);
            FluentJdf.Configuration.FluentJdfLibrary.Settings.HttpTransmissionSettings.TimeoutInSeconds.ShouldEqual(Timeout.Infinite);
        };

        It should_be_able_to_set_proxy_with_credentials_but_no_domain = () => {
            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdf.Configuration.FluentJdfLibrary.Settings.WithHttpTransmissionSettings().Proxy("http://proxyhere", true, "user", "password");
            FluentJdf.Configuration.FluentJdfLibrary.Settings.HttpTransmissionSettings.HasProxySettings.ShouldBeTrue();
        };

        It should_be_able_to_set_proxy_with_credentials_and_domain = () => {
            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdf.Configuration.FluentJdfLibrary.Settings.WithHttpTransmissionSettings().Proxy("http://proxyhere", true, "user", "password", "domain");
            FluentJdf.Configuration.FluentJdfLibrary.Settings.HttpTransmissionSettings.HasProxySettings.ShouldBeTrue();
        };

        It should_be_able_to_set_proxy_with_just_url = () => {
            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdf.Configuration.FluentJdfLibrary.Settings.WithHttpTransmissionSettings().Proxy("http://proxyhere");
            FluentJdf.Configuration.FluentJdfLibrary.Settings.HttpTransmissionSettings.HasProxySettings.ShouldBeTrue();
        };

        It should_be_able_to_set_timeout_to_positive_seconds = () => {
            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdf.Configuration.FluentJdfLibrary.Settings.WithHttpTransmissionSettings().TimeoutInSeconds(5);
            FluentJdf.Configuration.FluentJdfLibrary.Settings.HttpTransmissionSettings.TimeoutInSeconds.ShouldEqual(5);
        };

        It should_fail_to_set_negative_timeout = () => {
            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
            Catch.Exception(() => FluentJdf.Configuration.FluentJdfLibrary.Settings.WithHttpTransmissionSettings().TimeoutInSeconds(-100)).
                ShouldBe(typeof (PreconditionException));
        };

        It should_have_correct_settings_when_set_proxy_with_credentials_but_no_domain = () => {
            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdf.Configuration.FluentJdfLibrary.Settings.WithHttpTransmissionSettings().Proxy("http://proxyhere", true, "user", "password");
            FluentJdf.Configuration.FluentJdfLibrary.Settings.HttpTransmissionSettings.ProxyUrl.ShouldEqual("http://proxyhere");
            FluentJdf.Configuration.FluentJdfLibrary.Settings.HttpTransmissionSettings.ProxyUserName.ShouldEqual("user");
            FluentJdf.Configuration.FluentJdfLibrary.Settings.HttpTransmissionSettings.ProxyPassword.ShouldEqual("password");
        };

        It should_have_correct_settings_when_set_proxy_with_credentials_and_domain = () => {
            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdf.Configuration.FluentJdfLibrary.Settings.WithHttpTransmissionSettings().Proxy("http://proxyhere", true, "user", "password", "domain");
            FluentJdf.Configuration.FluentJdfLibrary.Settings.HttpTransmissionSettings.ProxyUrl.ShouldEqual("http://proxyhere");
            FluentJdf.Configuration.FluentJdfLibrary.Settings.HttpTransmissionSettings.ProxyUserName.ShouldEqual("user");
            FluentJdf.Configuration.FluentJdfLibrary.Settings.HttpTransmissionSettings.ProxyPassword.ShouldEqual("password");
            FluentJdf.Configuration.FluentJdfLibrary.Settings.HttpTransmissionSettings.ProxyDomain.ShouldEqual("domain");
        };

        It should_have_no_proxy_credentials_when_just_proxy_url_is_configured = () => {
            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdf.Configuration.FluentJdfLibrary.Settings.WithHttpTransmissionSettings().Proxy("http://proxyhere");
            FluentJdf.Configuration.FluentJdfLibrary.Settings.HttpTransmissionSettings.HasProxyCredentials.ShouldBeFalse();
        };

        It should_have_no_proxy_set_by_default = () => {
            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdf.Configuration.FluentJdfLibrary.Settings.HttpTransmissionSettings.HasProxySettings.ShouldBeFalse();
        };

        It should_have_proxy_credentials_when_configured = () => {
            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdf.Configuration.FluentJdfLibrary.Settings.WithHttpTransmissionSettings().Proxy("http://proxyhere", true, "user", "password");
            FluentJdf.Configuration.FluentJdfLibrary.Settings.HttpTransmissionSettings.HasProxyCredentials.ShouldBeTrue();
        };
    }
}