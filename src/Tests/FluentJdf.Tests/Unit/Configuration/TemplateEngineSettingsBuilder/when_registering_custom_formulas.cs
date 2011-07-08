using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.Configuration;
using Machine.Specifications;
using Rhino.Mocks;

namespace FluentJdf.Tests.Unit.Configuration.TemplateEngineSettingsBuilder
{
    [Subject(typeof(FluentJdf.Configuration.TemplateEngineSettingsBuilder))]
    public class when_registering_custom_formulas {
        static FluentJdf.Configuration.TemplateEngineSettingsBuilder builder;
        static FluentJdf.Configuration.TemplateEngineSettings settings;

        Establish context = () => {
            settings = new FluentJdf.Configuration.TemplateEngineSettings();
            var library = MockRepository.GenerateStub<IFluentJdfLibrary>();
            builder = new FluentJdf.Configuration.TemplateEngineSettingsBuilder(library, settings);
        };

        Because of = () => builder.CustomFormula("customOne", () => "customOne");

        It should_have_one_custom_formula_in_settings = () => settings.CustomFormulas.Count.ShouldEqual(1);

        It should_have_custom_formula_with_name_registered = () => settings.CustomFormulas.ContainsKey("customOne").ShouldBeTrue();
    }
}
