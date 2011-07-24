using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.Utility;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Utility.UriExtensionMethods {

    [Subject(typeof(FluentJdf.Utility.StringHelper))]
    public class when_verifying_local_path_for_uri {

        static Uri uri_c_drive_no_backslash;
        static Uri uri_c_drive_root;
        static Uri uri_unc_path_no_backslash;

        Establish context = () => {
            uri_c_drive_no_backslash = new Uri(@"file:///c:\temp\SimpleSend/MimeEncoded/");
            uri_c_drive_root = new Uri(@"file:///c:\");
            uri_unc_path_no_backslash = new Uri(@"file:///\\machine\SimpleSend/MimeEncoded/");
        };

        It should_have_correct_local_path_on_c_drive_item = () => uri_c_drive_no_backslash.GetLocalPath().ShouldEqual(@"c:\temp\SimpleSend\MimeEncoded\");

        It should_have_correct_local_path_on_c_root_item = () => uri_c_drive_root.GetLocalPath().ShouldEqual(@"c:\");

        It should_have_correct_local_path_on_unc_item = () => uri_unc_path_no_backslash.GetLocalPath().ShouldEqual(@"\\machine\SimpleSend\MimeEncoded\");
    }
}
