using System;
using System.Collections.Generic;
using System.Linq;
using FluentJdf.Configuration;
using FluentJdf.LinqToJdf;
using FluentJdf.Transmission;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Configuration.EncodingSettings {
    [Subject(typeof(FluentJdf.Configuration.EncodingSettings))]
    public class when_registering_file_transmitter_encoders_file_info_by_uri_with_default_reference_folder {
        static Uri uriOne = null;
        static FileTransmitterEncoder fileEncoder = null;
        static FileTransmitterEncoderBuilder builder = null;

        Establish context = () => uriOne = new Uri(@"file:///c:\temp\SimpleSend\1\");

        Because because_folder_info_configured_with_attachment = () => {
            Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
            FluentJdfLibrary.Settings.ResetToDefaults();
            builder = FluentJdfLibrary.Settings.WithEncodingSettings().FileTransmitterEncoder("id", uriOne, true);
            builder.FolderInfo(FolderInfoTypeEnum.Attachment, uriOne);
            fileEncoder = FluentJdfLibrary.Settings.EncodingSettings.FileTransmitterEncoders.Values.First();
        };

        It should_allow_file_info_to_be_added_to_encoder = () => {
            fileEncoder.FolderInfo.Count.ShouldEqual(1);
        };

        It should_have_correct_destination_folder_added_to_encoder = () => {
            fileEncoder.FolderInfo.First().DestinationFolder.ShouldEqual(uriOne.ToString());
        };

        It should_have_correct_reference_folder_added_to_encoder = () => {
            fileEncoder.FolderInfo.First().ReferenceFolder.ShouldEqual(uriOne.ToString());
        };
    }
}