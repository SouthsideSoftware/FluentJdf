using System;
using FluentJdf.Configuration;
using FluentJdf.Encoding;
using FluentJdf.Messaging;
using FluentJdf.Tests.Unit.Configuration.TransmitterSettings;
using FluentJdf.Tests.Unit.Encoding.EncodingFactory;
using FluentJdf.Transmission;
using Infrastructure.Core.Result;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Transmission {
    [Subject(typeof(FluentJdf.Transmission.TransmitterFactory))]
    public class when_creating_transmitters_from_some_registered_schemes {
        static FluentJdf.Transmission.TransmitterFactory factory;

        Establish context = () => {
                                FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
                                FluentJdf.Configuration.FluentJdfLibrary.Settings.WithTransmitterSettings().TransmitterForScheme("http", typeof (MockHttpTransmitter));
                                FluentJdf.Configuration.FluentJdfLibrary.Settings.WithTransmitterSettings().TransmitterForScheme("file", typeof(MockFileTransmitter));
                                factory = new FluentJdf.Transmission.TransmitterFactory();
                            };

        It should_get_class_registered_for_http_scheme = () => factory.GetTransmitterForScheme("http").ShouldBeOfType(typeof(MockHttpTransmitter));

        It should_get_class_registered_for_file_scheme = () => factory.GetTransmitterForScheme("file").ShouldBeOfType(typeof(MockFileTransmitter));

        It should_get_class_registered_for_http_url = () => factory.GetTransmitterForUrl(new Uri("http://foo.com/")).ShouldBeOfType(typeof(MockHttpTransmitter));

        It should_get_class_registered_for_file_url = () => factory.GetTransmitterForUrl(new Uri("file://logs/foo.log")).ShouldBeOfType(typeof(MockFileTransmitter));

        It should_get_class_registered_for_http_url_string = () => factory.GetTransmitterForUrl("http://foo.com/").ShouldBeOfType(typeof(MockHttpTransmitter));

        It should_get_class_registered_for_file_url_string = () => factory.GetTransmitterForUrl("file://logs/foo.log").ShouldBeOfType(typeof(MockFileTransmitter));
    }

    public class MockHttpTransmitter : ITransmitter {
        public IJmfResult Transmit(Uri uri, ITransmissionPartCollection partsToSend) {
            throw new NotImplementedException();
        }

        public IJmfResult Transmit(string uri, ITransmissionPartCollection partsToSend) {
            throw new NotImplementedException();
        }
    }

    public class MockFileTransmitter : ITransmitter
    {
        public IJmfResult Transmit(Uri uri, ITransmissionPartCollection partsToSend)
        {
            throw new NotImplementedException();
        }

        public IJmfResult Transmit(string uri, ITransmissionPartCollection partsToSend)
        {
            throw new NotImplementedException();
        }
    }
}