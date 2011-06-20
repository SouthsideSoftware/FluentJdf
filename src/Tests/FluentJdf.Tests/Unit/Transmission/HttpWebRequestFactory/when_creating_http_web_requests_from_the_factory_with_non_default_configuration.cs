using System;
using System.Net;
using FluentJdf.Configuration;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Transmission.HttpWebRequestFactory {
    [Subject(typeof(FluentJdf.Transmission.HttpWebRequestFactory))]
    public class when_creating_http_web_requests_from_the_factory_with_non_default_configuration {
        static FluentJdf.Transmission.HttpWebRequestFactory factory;
        static HttpWebRequest httpWebRequest;

        Establish context = () => {
            factory = new FluentJdf.Transmission.HttpWebRequestFactory();
            Library.Settings.ResetToDefaults();
            Library.Settings.WithHttpTransmissionSettings().TimeoutInSeconds(5).Proxy("http://proxy", true, "user", "password", "domain");
        };

        Because of = () => httpWebRequest = factory.Create(new Uri("http://foo"), "text/xml"); 

        It should_get_timeout_as_configured = () => httpWebRequest.Timeout.ShouldEqual(5*1000);

        It should_have_credentials_in_proxy = () => httpWebRequest.Proxy.Credentials.ShouldNotBeNull();

        It should_have_proxy_settings = () => httpWebRequest.Proxy.ShouldNotBeNull();

        It should_be_a_post = () => httpWebRequest.Method.ShouldEqual("POST");
    }
}