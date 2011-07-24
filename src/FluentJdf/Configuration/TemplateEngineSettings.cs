using System;
using System.Collections.Generic;
using FluentJdf.Encoding;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Settings for the template engine.
    /// </summary>
    public class TemplateEngineSettings : ITemplateEngineSettings {

        IDictionary<string, Func<string>> customFormulas;

        /// <summary>
        /// Constructor.
        /// </summary>
        public TemplateEngineSettings() {
            customFormulas = new Dictionary<string, Func<string>>();
            CustomFormulas = new ReadOnlyDictionary<string, Func<string>>(customFormulas);
        }

        /// <summary>
        /// Gets dictionary of custom formulas.
        /// </summary>
        public ReadOnlyDictionary<string, Func<string>> CustomFormulas {
            get;
            private set;
        }
        /// <summary>
        /// Register a custom formula.
        /// </summary>
        public void RegisterCustomFormula(string formulaName, Func<string> formula) {
            ParameterCheck.ParameterRequired(formulaName, "formulaName");

            customFormulas[formulaName] = formula;
        }

        /// <summary>
        /// Reset to defaults.
        /// </summary>
        /// <returns></returns>
        public ITemplateEngineSettings ResetToDefaults() {
            customFormulas.Clear();
            RegisterCustomFormula("configuredDefaultVersion", () => FluentJdfLibrary.Settings.JdfAuthoringSettings.JdfVersion);
            return this;
        }
    }
}