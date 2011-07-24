using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.Configuration;
using FluentJdf.Encoding;
using FluentJdf.Messaging;
using FluentJdf.Transmission.Logging;
using Infrastructure.Core.Result;
using Machine.Specifications;
using System.IO;

namespace FluentJdf.Tests.Unit.Transmission.FileTransmitter {

    [Subject(typeof(FluentJdf.Transmission.FileTransmitter))]
    public class when_testing_file_transmitter_to_use_file_transmitter_encoder {

        protected static List<FluentJdf.Transmission.FileTransmissionItem> preparedItems;

        Establish context = () => {

            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();

            FluentJdf.Configuration.FluentJdfLibrary.Settings.WithEncodingSettings()
                .FileTransmitterEncoder("mime", @"file:///c:\temp\SimpleSend\Mime", true)
                .FileTransmitterEncoder("id", @"file:///c:\temp\SimpleSend\")
                .FolderInfo(FluentJdf.Transmission.FolderInfoTypeEnum.Attachment, @"file:///c:\temp\SimpleSend\attach", @"file:///c:\temp\SimpleSend\", 1)
                .FolderInfo(FluentJdf.Transmission.FolderInfoTypeEnum.Jdf, @"file:///c:\temp\SimpleSend\${JobId}\jdf", @"file:///c:\temp\SimpleSend\", 3)
                .FolderInfo(FluentJdf.Transmission.FolderInfoTypeEnum.Jmf, @"file:///c:\temp\SimpleSend\${JobId}\jmf", @"file:///c:\temp\SimpleSend\", 2);

        };

        Because because = () => preparedItems = FileTransmitterTestSetupFactory.GetFileTransmissionItem("id");

        It should_have_three_transmitted_parts = () => preparedItems.Count.ShouldEqual(3);

        It should_have_attachment_in_first_position_by_id = () => preparedItems.First().Part.Id.ShouldEqual("id_1234");

        It should_have_attachment_in_first_position_by_mime = () => preparedItems.First().MimeType.ShouldEqual("text/plain");

        It should_have_jmf_in_second_position_by_mime = () => preparedItems.Skip(1).First().MimeType.ShouldEqual("application/vnd.cip4-jmf+xml");

        It should_have_jdf_in_last_position_by_mime = () => preparedItems.Last().MimeType.ShouldEqual("application/vnd.cip4-jdf+xml");

    }
}
