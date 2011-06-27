using System;
using System.IO;
using FluentJdf.Configuration;
using FluentJdf.Encoding;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Encoding.EncodingFactory {
    [Subject(typeof(FluentJdf.Encoding.EncodingFactory))]
    public class when_creating_encodings_by_mime_type_with_some_registered {
        static FluentJdf.Encoding.EncodingFactory factory;

        Establish context = () => {
                                FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
                                FluentJdf.Configuration.FluentJdfLibrary.Settings.WithEncodingSettings().EncodingForMimeType("one", typeof (MockEncoding));
                                FluentJdf.Configuration.FluentJdfLibrary.Settings.WithEncodingSettings().EncodingForMimeType("two", typeof(MockEncoding));
                                FluentJdf.Configuration.FluentJdfLibrary.Settings.WithEncodingSettings().EncodingForMimeType("three", typeof(MockEncoding3));
                                factory = new FluentJdf.Encoding.EncodingFactory();
                            };

        It should_get_class_registered_for_mime_type_one = () => factory.GetEncodingForMimeType("one").ShouldBeOfType(typeof(MockEncoding));

        It should_get_class_registered_for_mime_type_two = () => factory.GetEncodingForMimeType("two").ShouldBeOfType(typeof(MockEncoding));

        It should_get_class_registered_for_mime_type_three = () => factory.GetEncodingForMimeType("three").ShouldBeOfType(typeof(MockEncoding3));

        It should_fall_back_to_default_when_mime_type_is_not_registered = () => factory.GetEncodingForMimeType("four").ShouldBeOfType(FluentJdf.Configuration.FluentJdfLibrary.Settings.EncodingSettings.DefaultEncoding);
    }

    public class MockEncoding : IEncoding {
        public EncodingResult Encode(ITransmissionPartCollection transmissionParts) {
            throw new NotImplementedException();
        }

        public EncodingResult Encode(ITransmissionPart transmissionPart) {
            throw new NotImplementedException();
        }

        public ITransmissionPartCollection Decode(string name, Stream stream, string mimeType, string id = null) {
            throw new NotImplementedException();
        }
    }

    public class MockEncoding3 : IEncoding
    {
        public EncodingResult Encode(ITransmissionPartCollection transmissionParts)
        {
            throw new NotImplementedException();
        }

        public EncodingResult Encode(ITransmissionPart transmissionPart)
        {
            throw new NotImplementedException();
        }

        public ITransmissionPartCollection Decode(string name, Stream stream, string mimeType, string id = null)
        {
            throw new NotImplementedException();
        }
    }
}