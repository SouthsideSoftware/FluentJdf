using System;
using System.IO;
using FluentJdf.Configuration;
using FluentJdf.Encoding;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Configuration.TransmissionPartSettings {
    [Subject(typeof (FluentJdf.Configuration.EncodingSettings))]
    public class when_registering_transmission_parts {
        static ITransmissionPart mockTransmissionPart;

        Establish context = () => { mockTransmissionPart = new MockTransmissionPart(); };

        It should_be_able_to_register_a_default_transmission_part = () => {
                                                                        Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
                                                                        Library.Settings.ResetToDefaults();
                                                                        Library.Settings.WithTransmissionPartSettings().DefaultTransmissionPart(
                                                                            typeof (MockTransmissionPart));
                                                                        Library.Settings.TransmissionPartSettings.DefaultTransmissionPart.ShouldEqual(
                                                                            typeof (MockTransmissionPart));
                                                                    };

        It should_be_able_to_register_a_mime_type_encoding = () => {
                                                                 Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
                                                                 Library.Settings.ResetToDefaults();
                                                                 Library.Settings.WithTransmissionPartSettings().TransmissionPartForMimeType(
                                                                     "boohoo", typeof (MockTransmissionPart));
                                                                 Library.Settings.TransmissionPartSettings.TransmissionPartsByMimeType["boohoo"].
                                                                     ShouldEqual(typeof (MockTransmissionPart).FullName);
                                                             };
    }

    public class MockTransmissionPart : ITransmissionPart {
        public void Dispose() {
            throw new NotImplementedException();
        }

        public Stream CopyOfStream() {
            throw new NotImplementedException();
        }

        public string Name {
            get { throw new NotImplementedException(); }
        }

        public string Id {
            get { throw new NotImplementedException(); }
        }

        public string MimeType {
            get { throw new NotImplementedException(); }
        }

        public void Initialize(string name, Stream stream, string mimeType, string id) {
            throw new NotImplementedException();
        }
    }
}