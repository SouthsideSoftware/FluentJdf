using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using FluentJdf.Configuration;
using FluentJdf.LinqToJdf;
using FluentJdf.Transmission;

namespace FluentJdf.Tests.Unit.Configuration.EncodingSettings {

    [Subject(typeof(FluentJdf.Configuration.EncodingSettings))]
    public class when_registering_file_transmitter_encoders {

        static Uri uriOne = null;
        static Uri uriTwo = null;
        static Dictionary<string, string> additionalItems;
        static string testKey = null;
        static string testValue = null;

        Establish context = () => {
            uriOne = new Uri(@"file:///c:\temp\SimpleSend\1\");
            uriTwo = new Uri(@"file:///c:\temp\SimpleSend\2\");
            additionalItems = new Dictionary<string, string>();
            testKey = "testKey";
            testValue = "testValue";
            additionalItems.Add(testKey, testValue);
        };

        It should_be_able_to_register_file_transmitter_encoder_with_uri = () => {
            Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
            FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdfLibrary.Settings.WithEncodingSettings().FileTransmitterEncoder("id", uriOne, true);
            FluentJdfLibrary.Settings.EncodingSettings.FileTransmitterEncoders.Count.ShouldEqual(1);
        };

        It should_be_able_to_register_file_transmitter_encoder_with_uri_with_id_of_id = () => {
            Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
            FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdfLibrary.Settings.WithEncodingSettings().FileTransmitterEncoder("id", uriOne, true);
            FluentJdfLibrary.Settings.EncodingSettings.FileTransmitterEncoders["id"].ShouldNotBeNull();
        };

        It should_be_able_to_register_file_transmitter_encoder_with_uri_with_mime_true = () => {
            Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
            FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdfLibrary.Settings.WithEncodingSettings().FileTransmitterEncoder("id", uriOne, true);
            FluentJdfLibrary.Settings.EncodingSettings.FileTransmitterEncoders["id"].UseMime.ShouldBeTrue();
        };

        It should_be_able_to_register_file_transmitter_encoder_with_uri_with_name_value_item = () => {
            Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
            FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdfLibrary.Settings.WithEncodingSettings().FileTransmitterEncoder("id", uriOne, true, additionalItems);
            FluentJdfLibrary.Settings.EncodingSettings.FileTransmitterEncoders["id"].NameValues.Count.ShouldEqual(1);
            FluentJdfLibrary.Settings.EncodingSettings.FileTransmitterEncoders["id"].NameValues[testKey].ShouldEqual(testValue);
        };

        It should_be_able_to_register_file_transmitter_encoder_with_string = () => {
            Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
            FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdfLibrary.Settings.WithEncodingSettings().FileTransmitterEncoder("id", uriOne.ToString(), true);
            FluentJdfLibrary.Settings.EncodingSettings.FileTransmitterEncoders.Count.ShouldEqual(1);
        };

        It should_be_able_to_register_file_transmitter_encoder_with_string_with_id_of_id = () => {
            Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
            FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdfLibrary.Settings.WithEncodingSettings().FileTransmitterEncoder("id", uriOne.ToString(), true);
            FluentJdfLibrary.Settings.EncodingSettings.FileTransmitterEncoders["id"].ShouldNotBeNull();
        };

        It should_be_able_to_register_file_transmitter_encoder_with_string_with_mime_true = () => {
            Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
            FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdfLibrary.Settings.WithEncodingSettings().FileTransmitterEncoder("id", uriOne, true);
            FluentJdfLibrary.Settings.EncodingSettings.FileTransmitterEncoders["id"].UseMime.ShouldBeTrue();
        };

        It should_be_able_to_register_file_transmitter_encoder_with_string_with_name_value_item = () => {
            Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
            FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdfLibrary.Settings.WithEncodingSettings().FileTransmitterEncoder("id", uriOne, true, additionalItems);
            FluentJdfLibrary.Settings.EncodingSettings.FileTransmitterEncoders["id"].NameValues.Count.ShouldEqual(1);
            FluentJdfLibrary.Settings.EncodingSettings.FileTransmitterEncoders["id"].NameValues[testKey].ShouldEqual(testValue);
        };

        It should_fail_if_two_FileTransmitterEncoders_with_the_same_id_are_added = () => {
            Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
            FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdfLibrary.Settings.WithEncodingSettings().FileTransmitterEncoder("id", uriOne, true);
            Exception exception = null;
            try {
                FluentJdfLibrary.Settings.WithEncodingSettings().FileTransmitterEncoder("id", uriTwo, true);
            }
            catch (Exception ex) {
                exception = ex;
            }

            exception.ShouldBeOfType<JdfException>();
            FluentJdfLibrary.Settings.EncodingSettings.FileTransmitterEncoders.Count.ShouldEqual(1);
        };

        It should_allow_two_transmitters_to_be_added_with_different_urlbase = () => {
            Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
            FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdfLibrary.Settings.WithEncodingSettings().FileTransmitterEncoder("id1", uriOne, true);
            FluentJdfLibrary.Settings.WithEncodingSettings().FileTransmitterEncoder("id2", uriTwo, true);

            FluentJdfLibrary.Settings.EncodingSettings.FileTransmitterEncoders.Count.ShouldEqual(2);
            FluentJdfLibrary.Settings.EncodingSettings.FileTransmitterEncoders["id1"].ShouldNotBeNull();
            FluentJdfLibrary.Settings.EncodingSettings.FileTransmitterEncoders["id2"].ShouldNotBeNull();
        };

        

    }
}
