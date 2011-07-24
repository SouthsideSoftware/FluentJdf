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
    public class when_testing_file_transmitter_to_use_file_transmitter_encoder_write_to_disk {

        protected static FluentJdf.LinqToJdf.Message message;
        protected static IJmfResult result;
        static Uri rootFolderUri;
        static DirectoryInfo directoryInfo;

        Establish context = () => {

            rootFolderUri = new Uri(@"file:///c:\temp\SimpleSend\");

            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();

            FluentJdf.Configuration.FluentJdfLibrary.Settings.WithEncodingSettings()
                .FileTransmitterEncoder("mime", @"file:///c:\temp\SimpleSend\Mime", true)
                .FileTransmitterEncoder("id", @"file:///c:\temp\SimpleSend\")
                .FolderInfo(FluentJdf.Transmission.FolderInfoTypeEnum.Attachment, @"file:///c:\temp\SimpleSend\attach", @"file:///c:\temp\SimpleSend\", 1)
                .FolderInfo(FluentJdf.Transmission.FolderInfoTypeEnum.Jdf, @"file:///c:\temp\SimpleSend\${JobId}\jdf", @"file:///c:\temp\SimpleSend\", 3)
                .FolderInfo(FluentJdf.Transmission.FolderInfoTypeEnum.Jmf, @"file:///c:\temp\SimpleSend\${JobId}\jmf", @"file:///c:\temp\SimpleSend\", 2);

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
            }
            
            message = FileTransmitterTestSetupFactory.GetMessage();
            result = message.Transmit(rootFolderUri);
            directoryInfo = new DirectoryInfo(rootFolderUri.GetLocalPath());
        };

        private static string AttachmentFullName() {
            return directoryInfo.GetDirectories()
                .FirstOrDefault(item => item.Name.Equals("Attach", StringComparison.OrdinalIgnoreCase))
                .GetFiles().First().FullName;
        }

        private static string JdfFullName() {
            return directoryInfo.GetDirectories()
                .FirstOrDefault(item => !item.Name.Equals("Attach", StringComparison.OrdinalIgnoreCase))
                .GetDirectories().FirstOrDefault(item => item.Name.Equals("jdf", StringComparison.OrdinalIgnoreCase))
                .GetFiles().First().FullName;
        }

        private static string JmfFullName() {
            return directoryInfo.GetDirectories()
                .FirstOrDefault(item => !item.Name.Equals("Attach", StringComparison.OrdinalIgnoreCase))
                .GetDirectories().FirstOrDefault(item => item.Name.Equals("jmf", StringComparison.OrdinalIgnoreCase))
                .GetFiles().First().FullName;
        }

        It should_have_two_subfolders_in_directory = () => directoryInfo.GetDirectories().Count().ShouldEqual(2);

        It should_have_attachment_folder_in_directory = () => directoryInfo.GetDirectories().FirstOrDefault(item => item.Name.Equals("Attach", StringComparison.OrdinalIgnoreCase)).ShouldNotBeNull();

        It should_have_jdf_root_folder_in_directory = () => directoryInfo.GetDirectories().FirstOrDefault(item => !item.Name.Equals("Attach", StringComparison.OrdinalIgnoreCase)).ShouldNotBeNull();

        It should_have_jdf_and_jmf_folder_in_jdf_root_folder = () => directoryInfo.GetDirectories().FirstOrDefault(item => !item.Name.Equals("Attach", StringComparison.OrdinalIgnoreCase)).GetDirectories().Count().ShouldEqual(2);

        It should_have_attachment_equal_to_the_attachment_that_was_saved = () => File.ReadAllText(AttachmentFullName()).ShouldEqual("This is a test.");

        It should_have_jdf_ticket = () => FluentJdf.LinqToJdf.Ticket.Load(JdfFullName()).ShouldNotBeNull();

        It should_have_jmf_message = () => FluentJdf.LinqToJdf.Message.Load(JmfFullName()).ShouldNotBeNull();

    }
}
