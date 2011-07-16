using System;
using System.Collections.Generic;
using FluentJdf.Encoding;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Settings for the template engine.
    /// </summary>
    public class TemplateEngineSettings : ITemplateEngineSettings {
        /// <summary>
        /// Constructor.
        /// </summary>
        public TemplateEngineSettings() {
            CustomFormulas = new Dictionary<string, Func<string>>();
        }

        /// <summary>
        /// Gets dictionary of custom formulas.
        /// </summary>
        public Dictionary<string, Func<string>> CustomFormulas { get; private set; }
        /// <summary>
        /// Register a custom formula.
        /// </summary>
        public void RegisterCustomFormula(string formulaName, Func<string> formula) {
            ParameterCheck.ParameterRequired(formulaName, "formulaName");

            CustomFormulas[formulaName] = formula;
        }

        /// <summary>
        /// Reset to defaults.
        /// </summary>
        /// <returns></returns>
        public ITemplateEngineSettings ResetToDefaults() {
            CustomFormulas.Clear();
            RegisterCustomFormula("configuredDefaultVersion", () => FluentJdfLibrary.Settings.JdfAuthoringSettings.JdfVersion);
            return this;
        }
    }
}