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
    public class when_mapping_file_spec_url {
       
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
                 .WithInput()
                 .FileSpec().With().Attribute("MimeType", "application/pdf").Attribute("URL", cid)
                 .Ticket;
        };

        Because of = () => {
            FileSpecUrlMangler.MapFileSpecUrls(ticket, mappings, false);
        };

        It should_have_replaced_url_for_filespec = () => new Uri(ticket.SelectJDFDescendant(Element.FileSpec).Attribute("URL").Value).ShouldEqual(replaceUri);
    }
}
