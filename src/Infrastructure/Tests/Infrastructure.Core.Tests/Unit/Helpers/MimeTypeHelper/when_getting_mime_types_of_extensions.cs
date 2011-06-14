using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Core.Helpers;
using Machine.Specifications;

namespace Infrastructure.Core.Tests.Unit.Helpers.MimeTypeHelper
{
    [Subject(typeof(Core.Helpers.MimeTypeHelper))]
    public class when_getting_mime_types_of_extensions
    {
        It should_have_mime_type_for_dot_pdf = () => ".pdf".MimeType().ShouldEqual(Core.Helpers.MimeTypeHelper.PdfMimeType);

        It should_have_mime_type_for_dot_PDF = () => ".PDF".MimeType().ShouldEqual(Core.Helpers.MimeTypeHelper.PdfMimeType);

        It should_have_mime_type_for_pdf_no_dot = () => "pdf".MimeType().ShouldEqual(Core.Helpers.MimeTypeHelper.PdfMimeType);

        It should_have_mime_type_for_path_ending_in_dot_pdf = () => @"c:\foo\fii\fee_tom.pdf".MimeType().ShouldEqual(Core.Helpers.MimeTypeHelper.PdfMimeType);

        It should_have_mime_type_for_path_containing_dots_ending_in_dot_pdf = () => @"c:\foo\fii\fee.tom.pdf".MimeType().ShouldEqual(Core.Helpers.MimeTypeHelper.PdfMimeType);

        It should_have_mime_type_for_dot_jdf = () => ".jdf".MimeType().ShouldEqual(Core.Helpers.MimeTypeHelper.JdfMimeType);

        It should_have_mime_type_for_dot_jmf = () => ".jmf".MimeType().ShouldEqual(Core.Helpers.MimeTypeHelper.JmfMimeType);

        It should_have_mime_type_for_dot_mjd = () => ".mjd".MimeType().ShouldEqual(Core.Helpers.MimeTypeHelper.MimeMultipartMimeType);

        It should_have_mime_type_for_dot_mjm = () => ".mjm".MimeType().ShouldEqual(Core.Helpers.MimeTypeHelper.MimeMultipartMimeType);

        It should_have_mime_type_for_dot_png = () => ".png".MimeType().ShouldEqual("image/png");

        It should_have_mime_type_for_dot_pdf_using_MimeTypOf = () => Core.Helpers.MimeTypeHelper.MimeTypeOf(".pdf").ShouldEqual(Core.Helpers.MimeTypeHelper.PdfMimeType);

        It should_have_mime_type_for_dot_png_using_MimeTypeOf = () => Core.Helpers.MimeTypeHelper.MimeTypeOf(".png").ShouldEqual("image/png");
    }
}
