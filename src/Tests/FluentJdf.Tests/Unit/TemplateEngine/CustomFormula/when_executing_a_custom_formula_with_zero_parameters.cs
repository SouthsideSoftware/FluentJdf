using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.TemplateEngine.CustomFormula {
    [Subject(typeof(FluentJdf.TemplateEngine.CustomFormula))]
    public class when_executing_a_custom_formula_with_zero_parameters {
        static FluentJdf.TemplateEngine.CustomFormula customFormula;
        static string result;

        Establish context = () => customFormula = new FluentJdf.TemplateEngine.CustomFormula("testFunction", () => "noParameters");

        Because of = () => result = customFormula.Execute();

        It should_have_correct_return_from_custom_function = () => result.ShouldEqual("noParameters");
    };
}
