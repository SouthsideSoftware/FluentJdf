using System;
using System.Collections.Generic;
using Infrastructure.Core;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Template engine settings interface.
    /// </summary>
    public interface ITemplateEngineSettings {
        /// <summary>
        /// Gets dictionary of custom formulas.
        /// </summary>
        ReadOnlyDictionary<string, Func<string>> CustomFormulas { get; }

        /// <summary>
        /// Register a custom formula.
        /// </summary>
        void RegisterCustomFormula(string formulaName, Func<string> formula);

        /// <summary>
        /// Reset to default settings.
        /// </summary>
        /// <returns></returns>
        ITemplateEngineSettings ResetToDefaults();
    }
}