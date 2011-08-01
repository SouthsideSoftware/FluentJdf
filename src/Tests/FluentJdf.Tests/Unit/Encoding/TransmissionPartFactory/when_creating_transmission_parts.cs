using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.Configuration;
using FluentJdf.Encoding;
using Infrastructure.Container.CastleWindsor;
using Infrastructure.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Encoding.EncodingFactory
{
    [Subject(typeof(FluentJdf.Encoding.TransmissionPartFactory))]
    public class when_creating_transmission_parts {
        static FluentJdf.Encoding.TransmissionPartFactory factory;
        static ITransmissionPart defaultTransmissionPart;

        Establish context = () => {
                                Infrastructure.Core.Configuration.Settings.ServiceLocator.Reset();
                                FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
                                factory = new FluentJdf.Encoding.TransmissionPartFactory();
                            };

        Because of = () => {
                         defaultTransmissionPart = factory.CreateTransmissionPart("name", TestDataHelper.Instance.GetTestStream("signs.jpg"),
                                                                                  "image/jpeg");
                     };

        It should_have_default_transmission_part = () => defaultTransmissionPart.ShouldBeOfType(typeof (FluentJdf.Encoding.TransmissionPart));

        It should_have_a_stream_with_length = () => defaultTransmissionPart.CopyOfStream().Length.ShouldBeGreaterThan(0);

        It should_have_mime_type_jpeg = () => defaultTransmissionPart.MimeType.ShouldEqual("image/jpeg");

        It should_not_be_tracked_by_container =
            () =>
            (Infrastructure.Core.Configuration.Settings.ServiceLocator as WindsorServiceLocator).Container.Kernel.ReleasePolicy.HasTrack(
                defaultTransmissionPart).ShouldBeFalse();
    }
}
