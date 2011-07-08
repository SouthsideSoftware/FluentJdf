using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Configuration.TemplateEngineSettings
{
    [Subject(typeof(FluentJdf.Configuration.TemplateEngineSettings))]
    public class when_registering_custom_formulas {
        static FluentJdf.Configuration.TemplateEngineSettings templateEngineSettings;

        Establish context = () => templateEngineSettings = new FluentJdf.Configuration.TemplateEngineSettings();

        Because of = () => templateEngineSettings.RegisterCustomFormula("foo", () => "foo");

        It should_be_able_to_access_configured_formula = () => templateEngineSettings.CustomFormulas["foo"]().ShouldEqual("foo");
    }
}
