using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Jdp.Jdf.Utility;

namespace Jdp.Jdf.Tests.Unit.Utility.StringHelper
{
    [Subject(typeof(Jdf.Utility.StringHelper))]
    public class when_using_contains_that_support_case_insensitive_comparisons {
        static string source = "This is a TeSt";

        It should_return_true_when_using_case_insensitive_contains_and_case_does_not_match = () => source.Contains("test", StringComparison.InvariantCultureIgnoreCase).ShouldBeTrue();

        It should_return_true_when_using_case_insensitive_contains_and_case_is_the_same = () => source.Contains("TeSt", StringComparison.InvariantCultureIgnoreCase).ShouldBeTrue();

        It should_return_false_when_using_case_sensitive_contains_and_case_does_not_match = () => source.Contains("test", StringComparison.CurrentCulture).ShouldBeFalse();

        It should_return_true_when_using_case_sensitive_contains_and_case_is_the_same = () => source.Contains("TeSt", StringComparison.CurrentCulture).ShouldBeTrue();
    }
}
