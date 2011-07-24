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
    public class when_expanding_root_and_jobkey_folders {

        static FileTransmitterEncoder encoder = null;
        static Guid guid = Guid.Empty;
        static string jobId;
        static string jobKey;
        static string expanded = null;

        Establish context = () => {
            encoder = new FileTransmitterEncoder("id", @"file:///c:\temp");
            guid = Guid.NewGuid();
            jobId = 12.ToString();
            jobKey = 24.ToString();
            expanded = encoder.ExpandFolder(@"${Root}\${JobKey}", guid, jobId.ToString(), jobKey);
        };

        It should_equal_temp_and_jobkey_off_root = () => expanded.ShouldEqual(Path.Combine(@"c:\temp", jobKey));
    }
}
