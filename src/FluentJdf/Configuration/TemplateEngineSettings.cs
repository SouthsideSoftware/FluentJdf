using System;
using System.Collections.Generic;
using Infrastructure.Core;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Settings for the template engine.
    /// </summary>
    public class TemplateEngineSettings : ITemplateEngineSettings {
        readonly IDictionary<string, Delegate> customFormulas;

        /// <summary>
        /// Constructor.
        /// </summary>
        public TemplateEngineSettings() {
            customFormulas = new Dictionary<string, Delegate>();
            CustomFormulas = new ReadOnlyDictionary<string, Delegate>(customFormulas);
        }

        #region ITemplateEngineSettings Members

        /// <summary>
        /// Gets dictionary of custom formulas.
        /// </summary>
        public ReadOnlyDictionary<string, Delegate> CustomFormulas { get; private set; }

        /// <summary>
        /// Register a custom formula.
        /// </summary>
        public void RegisterCustomFormula(string formulaName, Delegate formula) {
            ParameterCheck.ParameterRequired(formulaName, "formulaName");

            customFormulas[formulaName] = formula;
        }

        /// <summary>
        /// Reset to defaults.
        /// </summary>
        /// <returns></returns>
        public ITemplateEngineSettings ResetToDefaults() {
            customFormulas.Clear();
            Func<string> func = () => FluentJdfLibrary.Settings.JdfAuthoringSettings.JdfVersion;
            Delegate function = func;
            RegisterCustomFormula("configuredDefaultVersion", function);
            return this;
        }

        #endregion
    }
}