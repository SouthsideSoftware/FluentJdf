using FluentJdf.Configuration;
using FluentJdf.Encoding;
using FluentJdf.Tests.Unit.Configuration.TransmissionPartSettings;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Encoding.EncodingFactory {
    [Subject(typeof(FluentJdf.Encoding.EncodingFactory))]
    public class when_creating_encodings_for_transmission_part_collections {
        static FluentJdf.Encoding.EncodingFactory factory;
        static IEncoding zeroPartEncoding;
        static IEncoding onePartEncoding;
        static IEncoding twoPartEncoding;
        static IEncoding threePartEncoding;

        Establish context = () => {
            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
            factory = new FluentJdf.Encoding.EncodingFactory();
        };

        Because of = () => {
            var transmissionParts = new FluentJdf.Encoding.TransmissionPartCollection();
            zeroPartEncoding = factory.GetEncodingForTransmissionParts(transmissionParts);

            transmissionParts.Add(new MockTransmissionPart());
            onePartEncoding = factory.GetEncodingForTransmissionParts(transmissionParts);

            transmissionParts.Add(new MockTransmissionPart());
            twoPartEncoding = factory.GetEncodingForTransmissionParts(transmissionParts);

            transmissionParts.Add(new MockTransmissionPart());
            threePartEncoding = factory.GetEncodingForTransmissionParts(transmissionParts);
        };

        It should_have_default_single_part_encoding_when_getting_encoding_with_zero_transmission_parts = () => zeroPartEncoding.ShouldBe(FluentJdf.Configuration.FluentJdfLibrary.Settings.EncodingSettings.DefaultSinglePartEncoding);

        It should_have_default_single_part_encoding_when_getting_encoding_with_one_transmission_parts = () => onePartEncoding.ShouldBe(FluentJdf.Configuration.FluentJdfLibrary.Settings.EncodingSettings.DefaultSinglePartEncoding);

        It should_have_default_multi_part_encoding_when_getting_encoding_with_two_transmission_parts = () => twoPartEncoding.ShouldBe(FluentJdf.Configuration.FluentJdfLibrary.Settings.EncodingSettings.DefaultMultiPartEncoding);

        It should_have_default_multi_part_encoding_when_getting_encoding_with_three_transmission_parts = () => threePartEncoding.ShouldBe(FluentJdf.Configuration.FluentJdfLibrary.Settings.EncodingSettings.DefaultMultiPartEncoding);
    }
}