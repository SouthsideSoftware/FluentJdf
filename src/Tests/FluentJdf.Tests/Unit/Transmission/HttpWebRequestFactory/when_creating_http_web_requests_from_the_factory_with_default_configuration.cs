using System;
using System.Net;
using FluentJdf.Configuration;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Transmission.HttpWebRequestFactory
{
    [Subject(typeof(FluentJdf.Transmission.HttpWebRequestFactory))]
    public class when_creating_http_web_requests_from_the_factory_with_default_configuration {
        static FluentJdf.Transmission.HttpWebRequestFactory factory;
        static HttpWebRequest httpWebRequest;

        Establish context = () => {
            factory = new FluentJdf.Transmission.HttpWebRequestFactory();
            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
        };

        Because of = () => httpWebRequest = factory.Create(new Uri("http://foo"), "text/xml"); 

        It should_get_default_timeout = () => httpWebRequest.Timeout.ShouldEqual(100*1000);

        It should_be_a_post = () => httpWebRequest.Method.ShouldEqual("POST");
    }
}
