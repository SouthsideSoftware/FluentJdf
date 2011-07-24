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

        It should_be_able_deserialize_back_into_parts = () => {
            var stream = preparedItems.First().CopyOfStream();
            stream.Seek(0, SeekOrigin.Begin);
            var parts = new FluentJdf.Encoding.MimeEncoding(
                new TransmissionPartFactory()).Decode("test", stream, Infrastructure.Core.Helpers.MimeTypeHelper.MimeMultipartMimeType);
            parts.Count.ShouldEqual(3);
            parts.First().MimeType.ShouldEqual("application/vnd.cip4-jmf+xml");
            parts.Skip(1).First().MimeType.ShouldEqual("application/vnd.cip4-jdf+xml");
            parts.Last().MimeType.ShouldEqual("text/plain");
        };

    }
}
