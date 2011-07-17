using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using FluentJdf.Configuration;
using FluentJdf.Transmission;

namespace FluentJdf.Tests.Unit.Configuration.EncodingSettings {

    [Subject(typeof(FluentJdf.Configuration.EncodingSettings))]
    public class when_registering_file_transmitter_encoders_file_info_by_uri {
        static Uri uriOne = null;
        static Uri uriTwo = null;
        static Dictionary<string, string> additionalItems;
        static string testKey = null;
        static string testValue = null;
        static FileTransmitterEncoder fileEncoder = null;
        static FileTransmitterEncoderBuilder builder = null;

        Establish context = () => {
            uriOne = new Uri(@"file:///c:\temp\SimpleSend\1\");
            uriTwo = new Uri(@"file:///c:\temp\SimpleSend\2\");
            additionalItems = new Dictionary<string, string>();
            testKey = "testKey";
            testValue = "testValue";
            additionalItems.Add(testKey, testValue);
        };

        Because because_folder_info_configured_with_attachment = () => {
            Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
            FluentJdfLibrary.Settings.ResetToDefaults();
            builder = FluentJdfLibrary.Settings.WithEncodingSettings().FileTransmitterEncoder("id", uriOne, true);
            builder.FolderInfo(FolderInfoTypeEnum.Attachment, uriOne, uriTwo, 2, additionalItems);
            fileEncoder = FluentJdfLibrary.Settings.EncodingSettings.FileTransmitterEncoders.Values.First();
        };

        It should_allow_file_info_to_be_added_to_encoder = () => {
            fileEncoder.FolderInfo.Count.ShouldEqual(1);
        };

        It should_have_correct_destination_folder_added_to_encoder = () => {
            fileEncoder.FolderInfo.First().DestinationFolder.ShouldEqual(uriOne.ToString());
        };

        It should_have_correct_reference_folder_added_to_encoder = () => {
            fileEncoder.FolderInfo.First().ReferenceFolder.ShouldEqual(uriTwo.ToString());
        };

        It should_have_order_of_two = () => {
            fileEncoder.FolderInfo.First().Order.ShouldEqual(2);
        };

        It should_have_one_name_value_item = () => {
            fileEncoder.FolderInfo.First().NameValues.Count.ShouldEqual(1);
        };

        It should_have_one_name_value_item_with_correct_key_and_value = () => {
            fileEncoder.FolderInfo.First().NameValues[testKey].ShouldEqual(testValue);
        };

        It should_not_allow_second_item_added_with_same_type = () => {
            Exception exception = null;
            try {
                builder.FolderInfo(FolderInfoTypeEnum.Attachment, uriOne.ToString(), uriTwo.ToString(), 2, additionalItems);
            }
            catch (Exception ex) {
                exception = ex;
            }

            exception.ShouldNotBeNull();
            fileEncoder.FolderInfo.Count.ShouldEqual(1);
        };
    }
}
