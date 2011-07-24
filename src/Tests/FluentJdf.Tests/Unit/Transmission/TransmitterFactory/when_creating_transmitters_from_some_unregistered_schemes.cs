using System;
using FluentJdf.Configuration;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Transmission.TransmitterFactory {

    [Subject(typeof(FluentJdf.Transmission.TransmitterFactory))]
    public class when_creating_transmitters_from_some_unregistered_schemes {
        static FluentJdf.Transmission.TransmitterFactory factory;

        Establish context = () => {
                                FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
                                FluentJdf.Configuration.FluentJdfLibrary.Settings.TransmitterSettings.ClearTransmitters();
                                factory = new FluentJdf.Transmission.TransmitterFactory();
                            };

        It should_throw_argument_exception_for_http_scheme = () => Catch.Exception(() => factory.GetTransmitterForScheme("http")).ShouldBe(typeof(ArgumentException));

        It should_throw_argument_exception_for_file_scheme = () => Catch.Exception(() => factory.GetTransmitterForScheme("file")).ShouldBe(typeof(ArgumentException));

        It should_throw_argument_exception_for_http_url = () => Catch.Exception(() => factory.GetTransmitterForUrl("http://foo.com/")).ShouldBe(typeof(ArgumentException));
    }
}