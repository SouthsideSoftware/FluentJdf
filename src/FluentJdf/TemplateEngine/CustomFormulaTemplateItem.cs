using System;
using System.Collections.Generic;
using System.IO;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.TemplateEngine {
    /// <summary>
    /// Processes any configured formula that is not handled by a specific <see cref="FormulaTemplateItem"/> descendant.
    /// </summary>
    public class CustomFormulaTemplateItem : FormulaTemplateItem {
        Func<string> valueFunction;
        string functionName;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="parent">The template item that contains this item.</param>
        /// <param name="name">The name of this template item.</param>
        /// <param name="lineNumber">The line number within the xml template file.</param>
        /// <param name="positionInLine">The column number within the xml template file.</param>
        /// <param name="functionName">The name of the function include parameters.</param>
        /// <param name="valueFunction">The custom function for this formula</param>
        protected internal CustomFormulaTemplateItem(TemplateItem parent, string name, int lineNumber, int positionInLine, string functionName, Func<string> valueFunction) :
            base(parent, name, lineNumber, positionInLine)
        {
            ParameterCheck.ParameterRequired(valueFunction, "valueFunction");
            ParameterCheck.StringRequiredAndNotWhitespace(functionName, "functionName");

            this.valueFunction = valueFunction;
            this.functionName = functionName;
        }

        /// <summary>
        /// Write out the result of the configure custom function.
        /// </summary>
        /// <param name="writer">The writer which will receive the string.</param>
        /// <param name="vars">A Dictionary{string, object} of name/value replacement values.  Ignored.</param>
        /// <returns>True if the replacement was made.</returns>
        protected internal override bool Generate(TextWriter writer, Dictionary<string, object> vars)
        {
            if (!base.Generate(writer, vars))
            {
                writer.Write(valueFunction());
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