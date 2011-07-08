using System;
using FluentJdf.Configuration;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.TemplateEngine.FormulaTemplateItemFactory {
    [Subject(typeof(FluentJdf.TemplateEngine.FormulaTemplateItemFactory))]
    public class when_creating_formula_template_item_for_registered_formula {
        static TemplateEngineSettings templateEngineSettings;
        static FluentJdf.TemplateEngine.FormulaTemplateItem templateItem;
        static FluentJdf.TemplateEngine.FormulaTemplateItemFactory factory;

        Establish context = () => {
            templateEngineSettings = new TemplateEngineSettings();
            templateEngineSettings.RegisterCustomFormula("foo", () => "fooFormulaResult");
            factory = new FluentJdf.TemplateEngine.FormulaTemplateItemFactory();
        };

        Because of = () => templateItem = factory.CreateFormulaItem(null, "var", 1, 2, "foo()", templateEngineSettings);

        It should_be_of_type_custom_formula_template_item = () => templateItem.ShouldBeOfType(typeof(FluentJdf.TemplateEngine.CustomFormulaTemplateItem));

        It should_have_function_name_in_to_string = () => templateItem.ToString().ShouldContain("foo()");
    }
}