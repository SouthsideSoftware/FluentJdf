using System;
using FluentJdf.Encoding;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Settings for the template engine.
    /// </summary>
    public class TemplateEngineSettingsBuilder : SettingsBuilderBase {
        ITemplateEngineSettings templateEngineSettings;

        internal TemplateEngineSettingsBuilder(IFluentJdfLibrary fluentJdfLibrary, ITemplateEngineSettings templateEngineSettings) : base(fluentJdfLibrary) {
            ParameterCheck.ParameterRequired(templateEngineSettings, "templateEngineSettings");

            this.templateEngineSettings = templateEngineSettings;
        }

        /// <summary>
        /// Register a custom formula.
        /// </summary>
        /// <param name="name">The name of the formula.  This will be used in templates and is case sensitive. </param>
        /// <param name="customFormula">A custom formula that returns the string that will be used in the instance
        /// generated from the template provided a specific replacement value is not provided when
        /// calling Template.Generate().</param>
        public TemplateEngineSettingsBuilder CustomFormula(string name, Func<string> customFormula) {
            ParameterCheck.StringRequiredAndNotWhitespace(name, "name");
            ParameterCheck.ParameterRequired(customFormula, "customFormula");

            templateEngineSettings.RegisterCustomFormula(name, customFormula);

            return this;
        }
    }
}