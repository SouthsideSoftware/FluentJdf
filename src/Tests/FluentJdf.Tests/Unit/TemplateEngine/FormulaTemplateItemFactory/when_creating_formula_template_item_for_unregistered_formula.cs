using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.Configuration;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.TemplateEngine.FormulaTemplateItemFactory
{
    [Subject(typeof(FluentJdf.TemplateEngine.FormulaTemplateItemFactory))]
    public class when_creating_formula_template_item_for_unregistered_formula {
        static Exception exception;
        static FluentJdf.TemplateEngine.FormulaTemplateItemFactory factory;

        Establish context = () => factory = new FluentJdf.TemplateEngine.FormulaTemplateItemFactory();

        Because of =
            () =>
            exception =
            Catch.Exception(() => factory.CreateFormulaItem(null, "var", 1, 2, "foo()", new TemplateEngineSettings()));

        It should_throw_a_template_expansion_exception = () => exception.ShouldBeOfType(typeof(FluentJdf.TemplateEngine.TemplateExpansionException));

        It should_have_function_name_in_exception_message = () => exception.Message.ShouldContain("foo()");
    }
}
