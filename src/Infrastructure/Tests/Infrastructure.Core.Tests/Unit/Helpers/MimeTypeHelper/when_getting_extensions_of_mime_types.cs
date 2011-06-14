using Infrastructure.Core.Helpers;
using Machine.Specifications;

namespace Infrastructure.Core.Tests.Unit.Helpers.MimeTypeHelper {
    [Subject(typeof (Core.Helpers.MimeTypeHelper))]
    public class when_getting_extensions_of_mime_types {
        It should_have_extension_for_jdf_mime_type =
            () => "application/vnd.cip4-jdf+xml".MimeTypeExtension().ShouldEqual(Core.Helpers.MimeTypeHelper.JdfExtension);

        It should_have_extension_for_jdf_mime_type_using_MimeTypeExtensionOf =
            () =>
            Core.Helpers.MimeTypeHelper.MimeTypeExtensionOf("application/vnd.cip4-jdf+xml").ShouldEqual(Core.Helpers.MimeTypeHelper.JdfExtension);

        It should_have_extension_for_jmf_mime_type =
            () => "application/vnd.cip4-jmf+xml".MimeTypeExtension().ShouldEqual(Core.Helpers.MimeTypeHelper.JmfExtension);

        It should_have_extension_for_multipart_mime_type =
            () => "multipart/related".MimeTypeExtension().ShouldEqual(Core.Helpers.MimeTypeHelper.MimeJmfFirstPartExtension);

        It should_have_extension_for_pdf_mime_type = () => "application/pdf".MimeTypeExtension().ShouldEqual(Core.Helpers.MimeTypeHelper.PdfExtension);

        It should_have_extension_for_pdf_mime_type_uppercase =
            () => "application/PDF".MimeTypeExtension().ShouldEqual(Core.Helpers.MimeTypeHelper.PdfExtension);

        It should_have_extension_for_png_mime_type = () => "image/png".MimeTypeExtension().ShouldEqual(".png");
    }
}