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
    public class when_testing_file_transmitter_to_use_file_transmitter_encoder_mime {

        protected static List<FluentJdf.Transmission.FileTransmissionItem> preparedItems;

        Establish context = () => {

            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();

            FluentJdf.Configuration.FluentJdfLibrary.Settings.WithEncodingSettings()
                .FileTransmitterEncoder("mime", @"file:///c:\temp\SimpleSend\Mime", true);

        };

        Because because = () => preparedItems = FileTransmitterTestSetupFactory.GetFileTransmissionItem("mime");

        It should_have_three_transmitted_parts = () => preparedItems.Count.ShouldEqual(1);

        It should_have_attachment_in_first_position_by_mime = () => preparedItems.First().MimeType.ShouldEqual("multipart/related");

    }
}
