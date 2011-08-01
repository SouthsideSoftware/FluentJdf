using System;
using System.IO;
using FluentJdf.Configuration;
using FluentJdf.Encoding;
using Infrastructure.Testing;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Encoding.EncodingFactory {
    [Subject(typeof (FluentJdf.Encoding.EncodingFactory))]
    public class when_creating_transmission_parts_by_mime_type_with_some_registered {
        static TransmissionPartFactory factory;

        Establish context = () => {
            FluentJdfLibrary.Settings.ResetToDefaults();
            FluentJdfLibrary.Settings.WithTransmissionPartSettings().TransmissionPartForMimeType<FluentJdf.Encoding.TransmissionPart>("one");
            FluentJdfLibrary.Settings.WithTransmissionPartSettings().TransmissionPartForMimeType<FluentJdf.Encoding.TransmissionPart>("two");
            FluentJdfLibrary.Settings.WithTransmissionPartSettings().TransmissionPartForMimeType<MockTransmissionPart3>("three");
            factory = new TransmissionPartFactory();
        };

        It should_fall_back_to_default_when_mime_type_is_not_registered =
            () =>
            factory.CreateTransmissionPart("name", TestDataHelper.Instance.GetTestStream("signs.jpg"), "xxx").ShouldBeOfType(
                FluentJdfLibrary.Settings.TransmissionPartSettings.DefaultTransmissionPart);

        It should_get_class_registered_for_mime_type_one =
            () =>
            factory.CreateTransmissionPart("name", TestDataHelper.Instance.GetTestStream("signs.jpg"), "one").ShouldBeOfType(
                typeof (FluentJdf.Encoding.TransmissionPart));

        It should_get_class_registered_for_mime_type_three =
            () =>
            factory.CreateTransmissionPart("name", TestDataHelper.Instance.GetTestStream("signs.jpg"), "three").ShouldBeOfType(
                typeof (MockTransmissionPart3));

        It should_get_class_registered_for_mime_type_two =
            () =>
            factory.CreateTransmissionPart("name", TestDataHelper.Instance.GetTestStream("signs.jpg"), "two").ShouldBeOfType(
                typeof (FluentJdf.Encoding.TransmissionPart));

        It should_have_id_even_when_one_is_not_passed =
            () =>
            factory.CreateTransmissionPart("name", TestDataHelper.Instance.GetTestStream("signs.jpg"), "one").Id.ShouldNotBeEmpty();

        It should_have_id_when_one_is_passed =
            () =>
            factory.CreateTransmissionPart("name", TestDataHelper.Instance.GetTestStream("signs.jpg"), "one", "id").Id.ShouldEqual("id");
    }

    public class MockTransmissionPart3 : ITransmissionPart {
        #region ITransmissionPart Members

        public void Dispose() {
            throw new NotImplementedException();
        }

        public Stream CopyOfStream() {
            throw new NotImplementedException();
        }

        public string Name {
            get { throw new NotImplementedException(); }
        }

        public string Id {
            get { throw new NotImplementedException(); }
        }

        public string MimeType {
            get { throw new NotImplementedException(); }
        }

        public void Initialize(string name, Stream stream, string mimeType, string id) {}

        #endregion
    }
}