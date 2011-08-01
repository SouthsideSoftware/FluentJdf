using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Utility.StringHelper {

    [Subject(typeof(FluentJdf.Utility.StringHelper))]
    public class when_ensuring_path_ends_with_slash {

        It should_properly_handle_valid_path =
            () => FluentJdf.Utility.StringHelper.EnsureTrailingSlash("file://foo/fi/").ShouldEqual("file://foo/fi/");

        It should_properly_handle_ending_slash =
            () => FluentJdf.Utility.StringHelper.EnsureTrailingSlash(@"file://foo/fi\").ShouldEqual(@"file://foo/fi\");

        It should_properly_replace_var_with_back_slash_at_end_of_path =
            () => FluentJdf.Utility.StringHelper.EnsureTrailingSlash("file://foo/fi").ShouldEqual(@"file://foo/fi/");
    
    }
}
