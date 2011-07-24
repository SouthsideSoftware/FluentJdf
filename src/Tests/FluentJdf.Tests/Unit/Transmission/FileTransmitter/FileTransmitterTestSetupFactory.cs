using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FluentJdf;
using FluentJdf.Encoding;
using FluentJdf.Transmission.Logging;

namespace FluentJdf.Tests.Unit.Transmission.FileTransmitter {

    /// <summary>
    /// Class used to create the base message for the FileTransmitter Tests
    /// </summary>
    internal static class FileTransmitterTestSetupFactory {

        public static List<FluentJdf.Transmission.FileTransmissionItem> GetFileTransmissionItem(string encoderId) {
            var encodingFactory = new EncodingFactory();
            var logger = new TransmissionLogger();
            var transmitterFactory = new FluentJdf.Transmission.TransmitterFactory();
            var transmitter = new FluentJdf.Transmission.FileTransmitter(encodingFactory, logger);

            var ticket = FluentJdf.LinqToJdf.Ticket.CreateIntent().Ticket;
            var message = FluentJdf.LinqToJdf.Message.Create().AddCommand().SubmitQueueEntry().With().Ticket(ticket).Message;

            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write("This is a test.");
            sw.Flush();
            ms.Position = 0;

            var attachmentPart = new TransmissionPart(ms, "TestAttachment", Infrastructure.Core.Helpers.MimeTypeHelper.TextMimeType, "id_1234");
            message.AddRelatedPart(attachmentPart);

            string name = string.Format("JMF{0}", Infrastructure.Core.Helpers.MimeTypeHelper.JmfExtension);
            var transmissionPartCollection = new TransmissionPartCollection();
            transmissionPartCollection.Add(new MessageTransmissionPart(message, name));
            transmissionPartCollection.AddRange(message.AdditionalParts);

            var encoder = FluentJdf.Configuration.FluentJdfLibrary.Settings.EncodingSettings.FileTransmitterEncoders
               .FirstOrDefault(item => item.Value.Id.Equals(encoderId, StringComparison.OrdinalIgnoreCase)).Value;

            return encoder.PrepareTransmission(transmissionPartCollection, new TransmissionPartFactory(), new EncodingFactory(), new TransmissionLogger()).OrderBy(item => item.Order).ToList();
        }

    }
}
