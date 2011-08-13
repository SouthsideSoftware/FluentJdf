using Machine.Specifications;

namespace FluentJdf.Tests.Unit.TemplateEngine.CustomFormula {
    [Subject(typeof(FluentJdf.TemplateEngine.CustomFormula))]
    public class when_executing_a_custom_formula_with_two_parameters {
        static FluentJdf.TemplateEngine.CustomFormula customFormula;
        static string result;

        Establish context = () => customFormula = new FluentJdf.TemplateEngine.CustomFormula("testFunction", (s1, s2) => string.Format("Parameters {0}, {1}", s1, s2));

        Because of = () => result = customFormula.Execute("one", "two");

        It should_have_correct_return_from_custom_function = () => result.ShouldEqual("Parameters one, two");
    };
}