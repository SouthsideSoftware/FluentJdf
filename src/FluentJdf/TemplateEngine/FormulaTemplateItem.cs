using System.Collections.Generic;
using System.IO;
using System.Data;

namespace FluentJdf.TemplateEngine
{
	/// <summary>
	/// Abstract base class that all formula replacements inherit from.
	/// </summary>
	/// <remarks>
	/// All formula items should inherit from this class and should call
	/// base.Generate() BEFORE doing their work to give the system a chance
	/// to replace the variable with a provided value if it exists.
	/// </remarks>
	public abstract class FormulaTemplateItem : TemplateItem
	{

		/// <summary>
		/// Constructs an instance of a formula template item.
		/// </summary>
		/// <param name="parent">The parent template item of this formula template item.</param>
		/// <param name="name">The name of the item.</param>
		/// <param name="lineNumber">The line number from the template.</param>
		/// <param name="positionInLine">The position within the line in the template.</param>
		protected internal FormulaTemplateItem(TemplateItem parent, string name, int lineNumber, int positionInLine) : 
			base(parent, name, lineNumber, positionInLine)
		{
		}

		/// <summary>
		/// Generates the properly-formatted XML for this formula item.
		/// </summary>
		/// <param name="writer">The text writer that will receive the XML</param>
		/// <param name="vars">A string dictionary containing name/value pairs used
		/// for variable replacement.</param>
		/// <param name="dataSet">A DataSet containing one or more tables for use inside table replacements.</param>
		/// <returns>True if the replacement was made successfully.</returns>
		protected internal override bool Generate(TextWriter writer, Dictionary<string, string> vars,  DataSet dataSet)
		{
			string val = null;

			if (parentTableItem != null)
			{
				val = parentTableItem.GetVariableValue(name);
			} 
			else 
			{
                if (vars.ContainsKey(name)) {
                    val = vars[name];
                }
			}
			if (val != null)
			{
				writer.Write(val);
				return true;
			} 
			
			return false;
			
		}
	}
}
