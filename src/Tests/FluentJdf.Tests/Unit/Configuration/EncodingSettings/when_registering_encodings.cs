using System;
using System.IO;
using FluentJdf.Configuration;
using FluentJdf.Encoding;
using Machine.Specifications;
using Rhino.Mocks;

namespace FluentJdf.Tests.Unit.Configuration.EncodingSettings {
    [Subject(typeof (FluentJdf.Configuration.EncodingSettings))]
    public class when_registering_encodings {
        static IEncoding mockEncoding;

        Establish context = () => { mockEncoding = new MockEncoding(); };

        It should_be_able_to_register_a_default_encoding = () => {
                                                               Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
                                                               FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
                                                               FluentJdf.Configuration.FluentJdfLibrary.Settings.WithEncodingSettings().DefaultEncoding(
                                                                   mockEncoding.GetType());
                                                               FluentJdf.Configuration.FluentJdfLibrary.Settings.EncodingSettings.DefaultEncoding.ShouldEqual(typeof (MockEncoding));
                                                           };

        It should_be_able_to_register_a_default_muti_part_encoding = () => {
                                                                         Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
                                                                         FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
                                                                         FluentJdf.Configuration.FluentJdfLibrary.Settings.WithEncodingSettings().DefaultMultiPartEncoding(
                                                                             mockEncoding.GetType());
                                                                         FluentJdf.Configuration.FluentJdfLibrary.Settings.EncodingSettings.DefaultMultiPartEncoding.ShouldEqual(typeof(MockEncoding));
                                                                     };

        It should_be_able_to_register_a_default_single_part_encoding = () => {
                                                                           Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
                                                                           FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
                                                                           FluentJdf.Configuration.FluentJdfLibrary.Settings.WithEncodingSettings().DefaultSinglePartEncoding(
                                                                               mockEncoding.GetType());
                                                                           FluentJdf.Configuration.FluentJdfLibrary.Settings.EncodingSettings.DefaultSinglePartEncoding.ShouldEqual(typeof(MockEncoding));
                                                                       };

        It should_be_able_to_register_a_mime_type_encoding = () => {
                                                                 Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
                                                                 FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
                                                                 FluentJdf.Configuration.FluentJdfLibrary.Settings.WithEncodingSettings().EncodingForMimeType("boohoo",
                                                                                                                             mockEncoding.GetType());
                                                                 FluentJdf.Configuration.FluentJdfLibrary.Settings.EncodingSettings.EncodingsByMimeType["boohoo"].ShouldEqual(
                                                                     typeof (MockEncoding).FullName);
                                                             };

        It should_be_able_to_register_and_use_a_default_encoding = () => {
                                                                       Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
                                                                       FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
                                                                       FluentJdf.Configuration.FluentJdfLibrary.Settings.WithEncodingSettings().DefaultEncoding
                                                                           (mockEncoding.GetType());
                                                                       new EncodingFactory().GetEncodingForMimeType("boohoo").ShouldBeOfType(
                                                                           mockEncoding.GetType());
                                                                   };

        It should_be_able_to_register_and_use_a_default_multi_part_encoding = () => {
                                                                                  Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
                                                                                  FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
                                                                                  FluentJdf.Configuration.FluentJdfLibrary.Settings.WithEncodingSettings().DefaultMultiPartEncoding
                                                                                      (mockEncoding.GetType());
                                                                                  new EncodingFactory().GetDefaultEncodingForMultiPart().
                                                                                      ShouldBeOfType(
                                                                                          mockEncoding.GetType());
                                                                              };

        It should_be_able_to_register_and_use_a_default_single_part_encoding = () => {
                                                                                   Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
                                                                                   FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
                                                                                   FluentJdf.Configuration.FluentJdfLibrary.Settings.WithEncodingSettings().DefaultSinglePartEncoding
                                                                                       (mockEncoding.GetType());
                                                                                   new EncodingFactory().GetDefaultEncodingForSinglePart().
                                                                                       ShouldBeOfType(
                                                                                           mockEncoding.GetType());
                                                                               };

        It should_be_able_to_register_and_use_a_mime_type_encoding = () => {
                                                                         Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
                                                                         FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
                                                                         FluentJdf.Configuration.FluentJdfLibrary.Settings.WithEncodingSettings().EncodingForMimeType("boohoo",
                                                                                                                                     mockEncoding.
                                                                                                                                         GetType());
                                                                         new EncodingFactory().GetEncodingForMimeType("boohoo").ShouldBeOfType(
                                                                             mockEncoding.GetType());
                                                                     };

        It should_be_able_to_register_same_encoder_as_all_defaults = () => {
                                                                         Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
                                                                         FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
                                                                         FluentJdf.Configuration.FluentJdfLibrary.Settings.WithEncodingSettings().
                                                                             DefaultEncoding(
                                                                                 mockEncoding.GetType());
                                                                         FluentJdf.Configuration.FluentJdfLibrary.Settings.WithEncodingSettings().
                                                                             DefaultSinglePartEncoding(
                                                                                 mockEncoding.GetType());
                                                                         FluentJdf.Configuration.FluentJdfLibrary.Settings.WithEncodingSettings().
                                                                             DefaultMultiPartEncoding(
                                                                                 mockEncoding.GetType());
                                                                     };
    }

    public class MockEncoding : IEncoding {
        public EncodingResult Encode(ITransmissionPartCollection transmissionParts) {
            throw new NotImplementedException();
        }

        public EncodingResult Encode(ITransmissionPart transmissionPart) {
            throw new NotImplementedException();
        }

        public ITransmissionPartCollection Decode(string name, Stream stream, string mimeType, string id = null) {
            throw new NotImplementedException();
        }
    }
}