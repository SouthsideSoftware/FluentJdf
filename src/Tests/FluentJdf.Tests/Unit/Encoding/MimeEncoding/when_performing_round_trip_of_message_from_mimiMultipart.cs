using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FluentJdf.Configuration;
using FluentJdf.Encoding;
using FluentJdf.Utility;
using Infrastructure.Core.Helpers;
using Infrastructure.Core.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Encoding.MimeEncoding {

    [Subject(typeof(FluentJdf.Encoding.MimeEncoding))]
    public class when_performing_round_trip_of_message_from_mimiMultipart {

        static ITransmissionPartCollection originalTransmissionPartCollection;
        static ITransmissionPartCollection roundTripTransmissionPartCollection;
        static EncodingResult endodedData;

        Establish context = () => {
            FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
            var originalStream = TestDataHelper.Instance.GetTestStream("mimeMultipart.txt");
            var originalStreamLength = originalStream.Length;
            originalTransmissionPartCollection =
                           new FluentJdf.Encoding.MimeEncoding(new TransmissionPartFactory()).Decode("test", originalStream,
                                                                               MimeTypeHelper.MimeMultipartMimeType);

            endodedData = new FluentJdf.Encoding.MimeEncoding(new TransmissionPartFactory()).Encode(originalTransmissionPartCollection);

        };

        Because of = () => roundTripTransmissionPartCollection =
                           new FluentJdf.Encoding.MimeEncoding(new TransmissionPartFactory()).Decode("test", endodedData.Stream,
                                                                               MimeTypeHelper.MimeMultipartMimeType);

        It should_have_same_number_of_messages = () => originalTransmissionPartCollection.Count.ShouldEqual(roundTripTransmissionPartCollection.Count);

        It should_have_same_jmf_id = () => originalTransmissionPartCollection.First().Id.ShouldEqual(roundTripTransmissionPartCollection.First().Id);

        It should_have_same_jdf_id = () => originalTransmissionPartCollection.Skip(1).First().Id.ShouldEqual(roundTripTransmissionPartCollection.Skip(1).First().Id);

        It should_have_same_jpg_id = () => originalTransmissionPartCollection.Last().Id.ShouldEqual(roundTripTransmissionPartCollection.Last().Id);

        It should_have_same_jmf_mime = () => originalTransmissionPartCollection.First().MimeType.ShouldEqual(roundTripTransmissionPartCollection.First().MimeType);

        It should_have_same_jdf_mime = () => originalTransmissionPartCollection.Skip(1).First().MimeType.ShouldEqual(roundTripTransmissionPartCollection.Skip(1).First().MimeType);

        It should_have_same_jpg_mime = () => originalTransmissionPartCollection.Last().MimeType.ShouldEqual(roundTripTransmissionPartCollection.Last().MimeType);

        It should_have_same_jmf_stream_data = () => originalTransmissionPartCollection.First().CopyOfStream().SameBytes(roundTripTransmissionPartCollection.First().CopyOfStream());

        It should_have_same_jdf_stream_data = () => originalTransmissionPartCollection.Skip(1).First().CopyOfStream().SameBytes(roundTripTransmissionPartCollection.Skip(1).First().CopyOfStream());

        It should_have_same_jpg_stream_data = () => originalTransmissionPartCollection.Last().CopyOfStream().SameBytes(roundTripTransmissionPartCollection.Last().CopyOfStream());

        It should_have_same_jmf_message = () => FluentJdf.LinqToJdf.Message.Load(originalTransmissionPartCollection.First().CopyOfStream())
                                        .Root.SameNodeStructure(FluentJdf.LinqToJdf.Message.Load(roundTripTransmissionPartCollection.First().CopyOfStream()).Root);

        It should_have_same_jdf_ticket = () => FluentJdf.LinqToJdf.Ticket.Load(originalTransmissionPartCollection.Skip(1).First().CopyOfStream())
                                        .Root.SameNodeStructure(FluentJdf.LinqToJdf.Ticket.Load(roundTripTransmissionPartCollection.Skip(1).First().CopyOfStream()).Root);

    }

}
