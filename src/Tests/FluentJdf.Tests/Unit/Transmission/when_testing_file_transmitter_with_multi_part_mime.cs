using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.Configuration;
using FluentJdf.Encoding;
using FluentJdf.Messaging;
using FluentJdf.Transmission;
using FluentJdf.Transmission.Logging;
using Infrastructure.Core.Result;
using Machine.Specifications;
using System.IO;

namespace FluentJdf.Tests.Unit.Transmission {

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
            transmitterFactory = new FluentJdf.Transmission.TransmitterFactory();
            transmitter = new FileTransmitter(encodingFactory, logger);
            tempPath = Path.GetTempPath();
            ticket = FluentJdf.LinqToJdf.Ticket.CreateIntent().Ticket;
            message = FluentJdf.LinqToJdf.Message.Create().AddCommand().SubmitQueueEntry().With().Ticket(ticket).Message;
            FluentJdf.Configuration.FluentJdfLibrary.Settings.WithTransmitterSettings().TransmitterForScheme("file", typeof(FileTransmitter));
            //message.Transmit("file:///Test");
        };

        It should_get_class_registered_for_file_scheme = () => transmitterFactory.GetTransmitterForScheme("file").ShouldBeOfType(typeof(FileTransmitter));

        It should_transmit_message_to_temp_file_location = () => {
            var path = new Uri("file:///" + Path.Combine(Path.GetTempPath(), Path.GetTempFileName() + ".jdf"));
            try {
                var results = message.Transmit(path.LocalPath);
                File.Exists(path.LocalPath).ShouldBeTrue();
            }
            finally {
                File.Delete(path.LocalPath);
            }
        };

        It should_be_able_deserialize_back_into_parts = () => {
            var path = new Uri("file:///" + Path.Combine(Path.GetTempPath(), Path.GetTempFileName() + ".jdf"));
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
