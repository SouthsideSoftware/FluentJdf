using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FluentJdf.Configuration;
using FluentJdf.Encoding;
using Infrastructure.Core.Helpers;
using Infrastructure.Core.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Encoding.MimeEncoding {

    [Subject(typeof(FluentJdf.Encoding.MimeEncoding))]
    public class when_decoding_mimeMulti_part {

        static ITransmissionPartCollection transmissionPartCollection;
        static long originalStreamLength;
        static Stream stream;

        Establish context = () => {
            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
            stream = TestDataHelper.Instance.GetTestStream("mimeMultipart.txt");
            originalStreamLength = stream.Length;
        };

        Because of = () => transmissionPartCollection =
                           new FluentJdf.Encoding.MimeEncoding(new TransmissionPartFactory()).Decode("test", stream,
                                                                               MimeTypeHelper.MimeMultipartMimeType);

        It should_contain_three_parts = () => transmissionPartCollection.Count.ShouldEqual(3);

        It should_have_a_first_part_of_jmf = () => transmissionPartCollection.First().MimeType.ShouldEqual("application/vnd.cip4-jmf+xml");

        //Not sure how to get to the message or ticket that I see in Dump()
        //It should_have_a_first_part_of_jmf_that_is_valid_message = () => transmissionPartCollection.First().;

        It should_have_a_second_part_of_jdf = () => transmissionPartCollection.Skip(1).First().MimeType.ShouldEqual("application/vnd.cip4-jdf+xml");

        //It should_have_a_second_part_of_jdf_that_is_valid_ticket = () => transmissionPartCollection;

        It should_have_a_third_part_of_jpg = () => transmissionPartCollection.Skip(2).First().MimeType.ShouldEqual("image/jpg");

        It should_have_a_jpg_length_of_17913 = () => transmissionPartCollection.Skip(2).First().CopyOfStream().Length.ShouldEqual(17913);

    }
}
