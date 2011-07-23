using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using FluentJdf.Configuration;
using FluentJdf.LinqToJdf;
using FluentJdf.Transmission;
using System.IO;

namespace FluentJdf.Tests.Unit.Transmission.FileTransmitterEncoders {

    [Subject(typeof(FluentJdf.Transmission.FileTransmitterEncoder))]
    public class when_mapping_map_message_url_cid {

        static FileTransmitterEncoder enc;
        static string cid;
        static string replace;
        static Uri replaceUri;
        static Dictionary<string, string> mappings;
        static Message messageQSP;
        static Message messageReQSP;

        Establish context = () => {
            cid = "cid:ThisIsATest";
            replace = @"c:\temp\test\thisisafile.jmf";
            replaceUri = new Uri(replace);
            mappings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                {cid, replace}
            };
            messageQSP = FluentJdf.LinqToJdf.Message.Create().AddCommand().SubmitQueueEntry()
                        .AddNode(Element.QueueSubmissionParams).With().Attribute("Hold", "true").Attribute("URL", cid)
                        .Message;

            messageReQSP = FluentJdf.LinqToJdf.Message.Create().AddCommand().ResubmitQueueEntry()
                       .AddNode(Element.ResubmissionParams).With().Attribute("Hold", "true").Attribute("URL", cid)
                       .Message;

            enc = new FileTransmitterEncoder("id", @"file:///c:\temp\SimpleSend\MimeEncoded");
        };

        Because of = () => {
            enc.MapMessageUrls(messageQSP, mappings);
            enc.MapMessageUrls(messageReQSP, mappings);
        };

        It should_have_replaced_url_for_submit_queue_entry = () => new Uri(messageQSP.SelectJDFDescendant(Element.QueueSubmissionParams).Attribute("URL").Value).ShouldEqual(replaceUri);

        It should_have_replaced_url_for_resubmit_queue_entry = () => new Uri(messageReQSP.SelectJDFDescendant(Element.ResubmissionParams).Attribute("URL").Value).ShouldEqual(replaceUri);

        //It should_equal_temp_and_jobkey_off_root = () => expanded.ShouldEqual(Path.Combine(@"c:\temp", jobKey));

    }
}
