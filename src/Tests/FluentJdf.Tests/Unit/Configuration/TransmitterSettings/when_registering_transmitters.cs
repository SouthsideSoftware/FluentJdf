using System;
using FluentJdf.Configuration;
using FluentJdf.Encoding;
using FluentJdf.Messaging;
using FluentJdf.Tests.Unit.Configuration.TransmissionPartSettings;
using FluentJdf.Transmission;
using Infrastructure.Core.Result;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Configuration.TransmitterSettings {
    [Subject(typeof (FluentJdf.Configuration.EncodingSettings))]
    public class when_registering_transmitters {
        static ITransmitter mockTransmitter;

        Establish context = () => { mockTransmitter = new MockTransmitter(); };

        It should_be_able_to_register_a_scheme_transmitter = () => {
                                                                 Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
                                                                 Library.Settings.ResetToDefaults();
                                                                 Library.Settings.WithTransmissionPartSettings().TransmissionPartForMimeType(
                                                                     "boohoo", typeof (MockTransmissionPart));
                                                                 Library.Settings.TransmissionPartSettings.TransmissionPartsByMimeType["boohoo"].
                                                                     ShouldEqual(typeof (MockTransmissionPart).FullName);
                                                             };
    }

    public class MockTransmitter : ITransmitter {
        public IJmfResult Transmit(Uri uri, ITransmissionPartCollection partsToSend) {
            throw new NotImplementedException();
        }

        public IJmfResult Transmit(string uri, ITransmissionPartCollection partsToSend) {
            throw new NotImplementedException();
        }
    }
}