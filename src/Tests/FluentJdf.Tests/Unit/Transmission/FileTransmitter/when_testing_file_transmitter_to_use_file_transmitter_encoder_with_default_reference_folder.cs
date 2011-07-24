using System.Collections.Generic;
using System.Linq;
using FluentJdf.Configuration;
using FluentJdf.LinqToJdf;
using FluentJdf.Transmission;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Transmission.FileTransmitter {
    [Subject(typeof (FluentJdf.Transmission.FileTransmitter))]
    public class when_testing_file_transmitter_to_use_file_transmitter_encoder_with_default_reference_folder {
        protected static List<FileTransmissionItem> preparedItems;

        Because because = () => preparedItems = FileTransmitterTestSetupFactory.GetFileTransmissionItem("id");

        Establish context = () => {
            FluentJdfLibrary.Settings.ResetToDefaults();

            FluentJdfLibrary.Settings.WithEncodingSettings()
                .FileTransmitterEncoder("mime", @"file:///c:\temp\SimpleSend\Mime", true)
                .FileTransmitterEncoder("id", @"file:///c:\temp\SimpleSend\")
                .FolderInfo(FolderInfoTypeEnum.Attachment, @"file:///c:\temp\SimpleSend\attach")
                .FolderInfo(FolderInfoTypeEnum.Jdf, @"file:///c:\temp\SimpleSend\${JobId}\jdf")
                .FolderInfo(FolderInfoTypeEnum.Jmf, @"file:///c:\temp\SimpleSend\${JobId}\jmf");
        };

        It should_have_attachment_in_last_position_by_id = () => preparedItems.Last().Part.Id.ShouldEqual("id_1234");

        It should_have_attachment_in_last_position_by_mime = () => preparedItems.Last().MimeType.ShouldEqual("text/plain");

        It should_have_jdf_in_second_position_by_mime = () => preparedItems.Skip(1).First().MimeType.ShouldEqual("application/vnd.cip4-jdf+xml");

        It should_have_jmf_in_first_position_by_mime = () => preparedItems.First().MimeType.ShouldEqual("application/vnd.cip4-jmf+xml");

        It should_have_three_transmitted_parts = () => preparedItems.Count.ShouldEqual(3);

        It should_reference_jdf_from_jmf_using_reference_path = () => {
            var jobId = Ticket.Load(preparedItems.Skip(1).First().CopyOfStream()).Root.GetJobId();
            Message.Load(preparedItems.First().CopyOfStream()).Root.Descendants(Element.QueueSubmissionParams).First().GetAttributeValueOrNull("URL").ShouldStartWith(
                string.Format(@"file:///c:/temp/simplesend/JDF_{0}/jdf/", jobId));
        };

        It should_reference_attachment_from_jdf_using_reference_path =
            () =>
            Ticket.Load(preparedItems.Skip(1).First().CopyOfStream()).GetIntent().WithInput().RunList().Elements.First().Descendants(Element.FileSpec).First().GetAttributeValueOrNull("URL").ShouldStartWith(
                @"file:///c:/temp/simplesend/attach/");
    }
}