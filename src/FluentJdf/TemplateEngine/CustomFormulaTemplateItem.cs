using System;
using System.Collections.Generic;
using System.IO;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.TemplateEngine {
    /// <summary>
    /// Processes any configured formula that is not handled by a specific <see cref="FormulaTemplateItem"/> descendant.
    /// </summary>
    public class CustomFormulaTemplateItem : FormulaTemplateItem {
        CustomFormula valueFunction;
        string functionName;
        string[] parameterNames;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="parent">The template item that contains this item.</param>
        /// <param name="name">The name of this template item.</param>
        /// <param name="lineNumber">The line number within the xml template file.</param>
        /// <param name="positionInLine">The column number within the xml template file.</param>
        /// <param name="functionName">The name of the function include parameters.</param>
        /// <param name="valueFunction">The custom function for this formula</param>
        /// <param name="parameterNames">The parameter names if the function is parameterized (otherwise null).</param>
        protected internal CustomFormulaTemplateItem(TemplateItem parent, string name, int lineNumber, int positionInLine, string functionName, Delegate valueFunction, string [] parameterNames) :
            base(parent, name, lineNumber, positionInLine)
        {
            ParameterCheck.ParameterRequired(valueFunction, "valueFunction");
            ParameterCheck.StringRequiredAndNotWhitespace(functionName, "functionName");

            this.valueFunction = new CustomFormula(functionName, valueFunction);
            this.functionName = functionName;
            this.parameterNames = parameterNames;
        }

        /// <summary>
        /// Write out the result of the configure custom function.
        /// </summary>
        /// <param name="writer">The writer which will receive the string.</param>
        /// <param name="vars">A Dictionary{string, object} of name/value replacement values.  Ignored.</param>
        /// <returns>True if the replacement was made.</returns>
        protected internal override bool Generate(TextWriter writer, Dictionary<string, object> vars)
        {
            if (!base.Generate(writer, vars)) {
                string[] parameters = null;
                if (parameterNames == null || parameterNames.Length == 0) {
                    parameters = new string[0];
                }
                else {
                    parameters = new string[parameterNames.Length];
                    int index = 0;
                    foreach (var parameterName in parameterNames) {
                        if (vars.ContainsKey(parameterName)) {
                            parameters[index] = vars[parameterName].ToString();
                        }
                    }
                }
                writer.Write(valueFunction.Execute(parameters));
            }

            return true;
        }

        /// <summary>
        /// Returns a string representation of the current item.
        /// </summary>
        /// <returns>A string representation of the current item.</returns>
        public override string ToString()
        {
            return string.Format("Name = {0}", functionName);
        }
    }
}