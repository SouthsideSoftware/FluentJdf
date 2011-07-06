using FluentJdf.Resources;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Logging;

namespace FluentJdf.Template
{
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
		/// <param name="funcName">The name of the function.</param>
		/// <returns>A FormulaTemplateItem descendant.</returns>
		protected internal static FormulaTemplateItem CreateFormulaItem(TemplateItem parent, string name, int lineNumber, int positionInLine, string funcName)
		{
		    ParameterCheck.ParameterRequired(parent, "parent");
		    ParameterCheck.StringRequiredAndNotWhitespace(name, "name");
		    ParameterCheck.StringRequiredAndNotWhitespace(funcName, "funcName");

			if (funcName == "generate()")
			{
				return new GenerateFormulaTemplateItem(parent, name, lineNumber, positionInLine);
			} 
			else if (funcName == "now()")
			{
				return new NowFormulaTemplateItem(parent, name, lineNumber, positionInLine);
			} 
			else if (funcName == "jdfDefault()")
			{
				return new JdfDefaultFormulaTemplateItem(parent, name, lineNumber, positionInLine);
			} 
			else {
			    string mess = string.Format(Messages.FormulaTemplateItemFactory_CreateFormulaItem_InvalidFunctionNameMessage, funcName);
                logger.ErrorFormat(Messages.ErrorAtLineAndColumn, mess, lineNumber, positionInLine);
                throw new TemplateExpansionException(lineNumber, positionInLine, mess);
			}
		}
	}
}
