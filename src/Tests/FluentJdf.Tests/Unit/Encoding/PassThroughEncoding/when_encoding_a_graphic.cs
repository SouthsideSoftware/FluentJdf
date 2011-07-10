using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FluentJdf.Encoding;
using Infrastructure.Core.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Encoding.PassThroughEncoding
{
    [Subject(typeof(FluentJdf.Encoding.PassThroughEncoding))]
    public class when_encoding_a_graphic {
        static EncodingResult result;
        static FluentJdf.Encoding.TransmissionPart transmissionPart;

        Establish context = () => transmissionPart = new FluentJdf.Encoding.TransmissionPart(TestDataHelper.Instance.PathToTestFile("signs.jpg"));

        Because of = () => {
                         result = new FluentJdf.Encoding.PassThroughEncoding(new TransmissionPartFactory()).Encode(transmissionPart);
                     };

        It should_have_a_result_stream = () => result.Stream.ShouldNotBeNull();

        It should_have_content_type_for_jpg = () => result.ContentType.ShouldEqual("image/jpeg");

        It should_have_result_stream_same_length_as_part_stream = () => transmissionPart.CopyOfStream().Length.ShouldEqual(result.Stream.Length);
    }
}
