using System;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.TemplateEngine.CustomFormula {
    [Subject(typeof(FluentJdf.TemplateEngine.CustomFormula))]
    public class when_executing_a_custom_formula_with_wrong_number_of_parameters {
        static FluentJdf.TemplateEngine.CustomFormula customFormula;

        Establish context = () => customFormula = new FluentJdf.TemplateEngine.CustomFormula("testFunction", (s1, s2, s3) => string.Format("Parameters {0}, {1}, {2}", s1, s2, s3));

        It should_throw_template_api_exception_when_executing = () => {
            Action act = () => customFormula.Execute("one", "two");
            Catch.Exception(act).ShouldBeOfType(typeof(FluentJdf.TemplateEngine.TemplateApiException));
        };
    }
}