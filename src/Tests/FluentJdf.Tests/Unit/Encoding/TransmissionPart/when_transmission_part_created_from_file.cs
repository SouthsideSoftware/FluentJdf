using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Core.Testing;
using Machine.Specifications;
using Infrastructure.Core.Helpers;

namespace FluentJdf.Tests.Unit.Encoding.TransmissionPart
{
    [Subject(typeof(FluentJdf.Encoding.TransmissionPart))]
    public class when_transmission_part_created_from_file {
        static FluentJdf.Encoding.TransmissionPart transmissionPart;

        Because of = () => transmissionPart = new FluentJdf.Encoding.TransmissionPart(TestDataHelper.Instance.PathToTestFile("signs.jpg"));

        It should_have_mime_type_for_jpg = () => transmissionPart.MimeType.ShouldEqual(".jpg".MimeType());

        It should_have_name_ending_with_jpg = () => transmissionPart.Name.EndsWith(".jpg");

        It should_have_an_id = () => transmissionPart.Id.ShouldNotBeEmpty();

        It should_be_able_to_get_stream = () => transmissionPart.CopyOfStream().ShouldNotBeNull();
    }
}
