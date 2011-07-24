using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.Utility;
using Machine.Specifications;


namespace FluentJdf.Tests.Unit.Utility.UriExtensionMethods {

    [Subject(typeof(FluentJdf.Utility.StringHelper))]
    public class when_verifying_uri_for_trailing_backslash {

        static Uri uri_c_drive_no_backslash;
        static Uri uri_unc_path_no_backslash;

        Establish context = () => {
            uri_c_drive_no_backslash = new Uri(@"file:///c:\temp\SimpleSend\MimeEncoded").EnsureTrailingSlash();
            uri_unc_path_no_backslash = new Uri(@"file:///\\machine\SimpleSend/MimeEncoded").EnsureTrailingSlash();
        };

        It should_put_backslash_on_c_drive_item = () => uri_c_drive_no_backslash.LocalPath.ShouldEndWith(@"\");

        It should_put_backslash_on_unc_path_item = () => uri_unc_path_no_backslash.LocalPath.ShouldEndWith(@"\");

    }
}
