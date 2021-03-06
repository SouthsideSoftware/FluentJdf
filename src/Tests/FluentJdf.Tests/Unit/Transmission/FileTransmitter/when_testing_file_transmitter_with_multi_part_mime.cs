﻿using System;
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
    public class when_testing_file_transmitter_with_multi_part_mime {

        static FluentJdf.Transmission.TransmitterFactory transmitterFactory;
        static IEncodingFactory encodingFactory;
        static FluentJdf.Transmission.Logging.ITransmissionLogger logger;
        static FluentJdf.Transmission.FileTransmitter transmitter;
        static FluentJdf.LinqToJdf.Message message;
        static FluentJdf.LinqToJdf.Ticket ticket;
        static string tempPath;

        Establish context = () => {
            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
            encodingFactory = new EncodingFactory();
            logger = new TransmissionLogger();
            var partFactory = new TransmissionPartFactory();
            transmitterFactory = new FluentJdf.Transmission.TransmitterFactory();
            transmitter = new FluentJdf.Transmission.FileTransmitter(encodingFactory, logger, partFactory);
            tempPath = Path.GetTempPath();
            ticket = FluentJdf.LinqToJdf.Ticket.CreateIntent().Ticket;
            message = FluentJdf.LinqToJdf.Message.Create().AddCommand().SubmitQueueEntry().With().Ticket(ticket).Message;
            FluentJdf.Configuration.FluentJdfLibrary.Settings.WithTransmitterSettings().InlineStreamLimit(12).StreamLogsFolder("me");
            FluentJdf.Configuration.FluentJdfLibrary.Settings.WithTransmitterSettings().TransmitterForScheme("file", typeof(FluentJdf.Transmission.FileTransmitter));
        };

        It should_have_a_stream_limit_of_12 = () => FluentJdf.Configuration.FluentJdfLibrary.Settings.TransmitterSettings.InlineStreamLimit.ShouldEqual(12);

        It should_have_a_stream_folder_of_me = () => FluentJdf.Configuration.FluentJdfLibrary.Settings.TransmitterSettings.StreamLogsFolder.ShouldEqual("me");

        It should_get_class_registered_for_file_scheme = () => transmitterFactory.GetTransmitterForScheme("file").ShouldBeOfType(typeof(FluentJdf.Transmission.FileTransmitter));

        It should_transmit_message_to_temp_file_location = () => {
            var path = new Uri("file:///" + Path.GetTempFileName() + ".jdf");
            try {
                var results = message.Transmit(path.LocalPath);
                File.Exists(path.LocalPath).ShouldBeTrue();
            }
            finally {
                File.Delete(path.LocalPath);
            }
        };

        It should_be_able_deserialize_back_into_parts = () => {
            var path = new Uri("file:///" + Path.GetTempFileName() + ".jdf");
            var results = message.Transmit(path.LocalPath);

            try {
                using (var stream = File.OpenRead(path.LocalPath)) {
                    var parts = new FluentJdf.Encoding.MimeEncoding(
                        new TransmissionPartFactory()).Decode("test", stream, Infrastructure.Core.Helpers.MimeTypeHelper.MimeMultipartMimeType);
                    parts.Count.ShouldEqual(2);
                    parts.First().MimeType.ShouldEqual("application/vnd.cip4-jmf+xml");
                    parts.Last().MimeType.ShouldEqual("application/vnd.cip4-jdf+xml");
                }
            }
            finally {
                File.Delete(path.LocalPath);
            }
        };

    }
}
