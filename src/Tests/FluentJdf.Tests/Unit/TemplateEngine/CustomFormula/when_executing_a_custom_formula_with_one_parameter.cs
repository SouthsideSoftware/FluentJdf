using Machine.Specifications;

namespace FluentJdf.Tests.Unit.TemplateEngine.CustomFormula {
    [Subject(typeof(FluentJdf.TemplateEngine.CustomFormula))]
    public class when_executing_a_custom_formula_with_one_parameter {
        static FluentJdf.TemplateEngine.CustomFormula customFormula;
        static string result;

        Establish context = () => customFormula = new FluentJdf.TemplateEngine.CustomFormula("testFunction", s1 => string.Format("Parameter {0}", s1));

        Because of = () => result = customFormula.Execute("one");

        It should_have_correct_return_from_custom_function = () => result.ShouldEqual("Parameter one");
    };
}