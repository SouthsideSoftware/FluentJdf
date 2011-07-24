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
using FluentJdf.Utility;
using Infrastructure.Core.Helpers;

//TODO this should really be an integration test.

namespace FluentJdf.Tests.Unit.Transmission.FileTransmitter {

    [Subject(typeof(FluentJdf.Transmission.FileTransmitter))]
    public class when_testing_file_transmitter_to_use_file_transmitter_encoder_write_to_disk_mime {

        static FluentJdf.LinqToJdf.Message message;
        static IJmfResult result;
        static Uri rootFolderUri;
        static DirectoryInfo directoryInfo;
        static ITransmissionPartCollection transmissionParts;

        Establish context = () => {

            rootFolderUri = new Uri(@"file:///c:\temp\SimpleSend\Mime").EnsureTrailingSlash();

            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();

            FluentJdf.Configuration.FluentJdfLibrary.Settings.WithEncodingSettings()
                .FileTransmitterEncoder("mime", rootFolderUri, true);

        };

        Because because = () => {

            if (Directory.Exists(rootFolderUri.GetLocalPath())) {

                var dir = new DirectoryInfo(rootFolderUri.GetLocalPath());

                //try to delete one folder at a time
                foreach (var subfolder in dir.GetDirectories()) {
                    try {
                        subfolder.Delete(true);
                    }
                    finally {

                    }
                }

                foreach (var file in dir.GetFiles()) {
                    try {
                        file.Delete();
                    }
                    finally {

                    }
                }
            }

            message = FileTransmitterTestSetupFactory.GetMessage();
            result = message.Transmit(rootFolderUri);
            directoryInfo = new DirectoryInfo(rootFolderUri.GetLocalPath());

            using (var stream = File.OpenRead(MimeFullName())) {
                transmissionParts = new FluentJdf.Encoding.MimeEncoding(new TransmissionPartFactory()).Decode("test", stream,
                                                                                                  MimeTypeHelper.MimeMultipartMimeType);
            }
        };

        private static string MimeFullName() {
            return directoryInfo.GetFiles().First().FullName;
        }

        It should_have_no_subdirectory = () => directoryInfo.GetDirectories().Count().ShouldEqual(0);

        It should_have_one_file_in_directory = () => directoryInfo.GetFiles().Count().ShouldEqual(1);

        It should_contain_three_parts = () => transmissionParts.Count.ShouldEqual(3);

        It should_have_a_first_part_of_jmf = () => transmissionParts.First().MimeType.ShouldEqual("application/vnd.cip4-jmf+xml");

        It should_have_a_first_part_of_jmf_that_is_valid_message = () =>
                                FluentJdf.LinqToJdf.Message.Load(transmissionParts.First().CopyOfStream()).ShouldNotBeNull();

        It should_have_a_second_part_of_jdf = () => transmissionParts.Skip(1).First().MimeType.ShouldEqual("application/vnd.cip4-jdf+xml");

        It should_have_a_second_part_of_jdf_that_is_valid_ticket = () =>
                                FluentJdf.LinqToJdf.Ticket.Load(transmissionParts.Skip(1).First().CopyOfStream()).ShouldNotBeNull();

        It should_have_a_third_part_of_text = () => transmissionParts.Skip(2).First().MimeType.ShouldEqual("text/plain");

        It should_have_a_text_length_of_16 = () => transmissionParts.Skip(2).First().CopyOfStream().Length.ShouldEqual(16);

        It should_have_attachment_equal_to_the_attachment_that_was_saved 
            = () => new StreamReader(transmissionParts.Skip(2).First().CopyOfStream()).ReadToEnd().Trim().ShouldEqual("This is a test.");

        It should_have_jdf_ticket = () => FluentJdf.LinqToJdf.Ticket.Load(transmissionParts.Skip(1).First().CopyOfStream()).ShouldNotBeNull();

        It should_have_jmf_message = () => FluentJdf.LinqToJdf.Message.Load(transmissionParts.First().CopyOfStream()).ShouldNotBeNull();
    }
}
