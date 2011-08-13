using Machine.Specifications;

namespace FluentJdf.Tests.Unit.TemplateEngine.CustomFormula {
    [Subject(typeof(FluentJdf.TemplateEngine.CustomFormula))]
    public class when_executing_a_custom_formula_with_three_parameters {
        static FluentJdf.TemplateEngine.CustomFormula customFormula;
        static string result;

        Establish context = () => customFormula = new FluentJdf.TemplateEngine.CustomFormula("testFunction", (s1, s2, s3) => string.Format("Parameters {0}, {1}, {2}", s1, s2, s3));

        Because of = () => result = customFormula.Execute("one", "two", "three");

        It should_have_correct_return_from_custom_function = () => result.ShouldEqual("Parameters one, two, three");
    };
}