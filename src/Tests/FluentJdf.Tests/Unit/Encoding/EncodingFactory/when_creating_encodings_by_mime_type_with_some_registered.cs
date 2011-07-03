using System;
using System.IO;
using FluentJdf.Configuration;
using FluentJdf.Encoding;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Encoding.EncodingFactory {
    [Subject(typeof (FluentJdf.Encoding.EncodingFactory))]
    public class when_creating_encodings_by_mime_type_with_some_registered {
        static FluentJdf.Encoding.EncodingFactory factory;

        Establish context = () => {
            FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdfLibrary.Settings.WithEncodingSettings().EncodingForMimeType<MockEncoding>("one");
            FluentJdfLibrary.Settings.WithEncodingSettings().EncodingForMimeType<MockEncoding>("two");
            FluentJdfLibrary.Settings.WithEncodingSettings().EncodingForMimeType<MockEncoding3>("three");
            factory = new FluentJdf.Encoding.EncodingFactory();
        };

        It should_fall_back_to_default_when_mime_type_is_not_registered =
            () => factory.GetEncodingForMimeType("four").ShouldBeOfType(FluentJdfLibrary.Settings.EncodingSettings.DefaultEncoding);

        It should_get_class_registered_for_mime_type_one = () => factory.GetEncodingForMimeType("one").ShouldBeOfType(typeof (MockEncoding));

        It should_get_class_registered_for_mime_type_three = () => factory.GetEncodingForMimeType("three").ShouldBeOfType(typeof (MockEncoding3));
        It should_get_class_registered_for_mime_type_two = () => factory.GetEncodingForMimeType("two").ShouldBeOfType(typeof (MockEncoding));
    }

    public class MockEncoding : IEncoding {
        #region IEncoding Members

        public EncodingResult Encode(ITransmissionPartCollection transmissionParts) {
            throw new NotImplementedException();
        }

        public EncodingResult Encode(ITransmissionPart transmissionPart) {
            throw new NotImplementedException();
        }

        public ITransmissionPartCollection Decode(string name, Stream stream, string mimeType, string id = null) {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class MockEncoding3 : IEncoding {
        #region IEncoding Members

        public EncodingResult Encode(ITransmissionPartCollection transmissionParts) {
            throw new NotImplementedException();
        }

        public EncodingResult Encode(ITransmissionPart transmissionPart) {
            throw new NotImplementedException();
        }

        public ITransmissionPartCollection Decode(string name, Stream stream, string mimeType, string id = null) {
            throw new NotImplementedException();
        }

        #endregion
    }
}