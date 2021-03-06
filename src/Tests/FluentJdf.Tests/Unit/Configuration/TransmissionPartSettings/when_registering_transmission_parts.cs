using FluentJdf.Configuration;
using FluentJdf.Encoding;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Configuration.TransmissionPartSettings {
    [Subject(typeof (FluentJdf.Configuration.EncodingSettings))]
    public class when_registering_transmission_parts {
        static ITransmissionPart mockTransmissionPart;

        Establish context = () => { mockTransmissionPart = new MockTransmissionPart(); };

        It should_be_able_to_register_a_default_transmission_part = () => {
            Infrastructure.Core.Configuration.Settings.ResetServiceLocator();
            FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdfLibrary.Settings.WithTransmissionPartSettings().DefaultTransmissionPart<MockTransmissionPart>();
            FluentJdfLibrary.Settings.TransmissionPartSettings.DefaultTransmissionPart.ShouldEqual(
                typeof (MockTransmissionPart));
        };

        It should_be_able_to_register_a_mime_type_encoding = () => {
            Infrastructure.Core.Configuration.Settings.ResetServiceLocator();
            FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdfLibrary.Settings.WithTransmissionPartSettings().TransmissionPartForMimeType<MockTransmissionPart>("boohoo");
            FluentJdfLibrary.Settings.TransmissionPartSettings.TransmissionPartsByMimeType["boohoo"].
                ShouldEqual(typeof (MockTransmissionPart));
        };
    }
}