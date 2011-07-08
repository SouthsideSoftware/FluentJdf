using System;
using System.Collections.Generic;
using FluentJdf.Configuration;
using FluentJdf.Resources;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Logging;

namespace FluentJdf.TemplateEngine {
    /// <summary>
    /// Constructs specific desendants of FormulaTemplateItem
    /// </summary>
    public class FormulaTemplateItemFactory {
        static readonly ILog logger = LogManager.GetLogger(typeof (FormulaTemplateItemFactory));

        /// <summary>
        /// Construct a descendant of FormulaTemplateItem
        /// </summary>
        /// <param name="parent">Parent that contains this template item.</param>
        /// <param name="name">The name of this template item.</param>
        /// <param name="lineNumber">Line number within the xml template file.</param>
        /// <param name="positionInLine">Column number within the xml template file.</param>
        /// <param name="functionName">The name of the function.</param>
        /// <param name="templateEngineSettings">The template engine settings.</param>
        /// <returns>A FormulaTemplateItem descendant.</returns>
        public static FormulaTemplateItem CreateFormulaItem(TemplateItem parent, string name, int lineNumber, int positionInLine,
                                                                        string functionName, ITemplateEngineSettings templateEngineSettings) {
            ParameterCheck.StringRequiredAndNotWhitespace(name, "name");
            ParameterCheck.StringRequiredAndNotWhitespace(functionName, "functionName");

            if (functionName == "generate()") {
                return new GenerateFormulaTemplateItem(parent, name, lineNumber, positionInLine);
            }
            else if (functionName == "now()") {
                return new NowFormulaTemplateItem(parent, name, lineNumber, positionInLine);
            }
            else if (functionName == "jdfDefault()") {
                return new JdfDefaultFormulaTemplateItem(parent, name, lineNumber, positionInLine);
            }
            else {
                Dictionary<string, Func<string>> customFormulas = templateEngineSettings.CustomFormulas;
                int openParenPos = functionName.IndexOf("(");
                string funcNameWithoutParameters = functionName;
                if (openParenPos > -1) {
                    funcNameWithoutParameters = functionName.Substring(0, openParenPos);
                }
                if (customFormulas.ContainsKey(funcNameWithoutParameters)) {
                    return new CustomFormulaTemplateItem(parent, name, lineNumber, positionInLine, functionName, customFormulas[funcNameWithoutParameters]);
                }
            }

            string mess = string.Format(Messages.FormulaTemplateItemFactory_CreateFormulaItem_InvalidFunctionNameMessage, functionName);
            logger.ErrorFormat(Messages.ErrorAtLineAndColumn, mess, lineNumber, positionInLine);
            throw new TemplateExpansionException(lineNumber, positionInLine, mess);
        }
    }
}