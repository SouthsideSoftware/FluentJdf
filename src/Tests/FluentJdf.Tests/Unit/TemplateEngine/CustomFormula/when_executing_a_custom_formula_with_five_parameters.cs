using Machine.Specifications;

namespace FluentJdf.Tests.Unit.TemplateEngine.CustomFormula {
    [Subject(typeof(FluentJdf.TemplateEngine.CustomFormula))]
    public class when_executing_a_custom_formula_with_five_parameters {
        static FluentJdf.TemplateEngine.CustomFormula customFormula;
        static string result;

        Establish context = () => customFormula = new FluentJdf.TemplateEngine.CustomFormula("testFunction", (s1, s2, s3, s4, s5) => string.Format("Parameters {0}, {1}, {2}, {3}, {4}", s1, s2, s3, s4, s5));

        Because of = () => result = customFormula.Execute("one", "two", "three", "four", "five");

        It should_have_correct_return_from_custom_function = () => result.ShouldEqual("Parameters one, two, three, four, five");
    };
}