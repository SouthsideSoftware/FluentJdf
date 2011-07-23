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

    [Subject(typeof(FluentJdf.Transmission.FileSpecUrlMangler))]
    public class when_mapping_preview_url {

        static string cid;
        static string replace;
        static Uri replaceUri;
        static Dictionary<string, string> mappings;
        static Ticket ticket;

        Establish context = () => {
            cid = "cid:ThisIsATest";
            replace = @"c:\temp\test\thisisafile.pdf";
            replaceUri = new Uri(replace);
            mappings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                {cid, replace}
            };
            ticket = FluentJdf.LinqToJdf.Ticket
                            .CreateProcess(ProcessType.Bending)
                            .AddNode(Element.ResourcePool)
                            .AddNode(Element.Preview)
                            .With().Attribute("PreviewType", "ThumbNail").Attribute("Status", "Draft").Attribute("URL", cid)
                            .Ticket;
        };

        Because of = () => {
            FileSpecUrlMangler.MapPreviewUrls(ticket, mappings, false);
        };

        It should_have_replaced_url_for_preview = () => new Uri(ticket.SelectJDFDescendant(Element.Preview).Attribute("URL").Value).ShouldEqual(replaceUri);
    }
}
