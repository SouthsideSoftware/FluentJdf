using System;
using System.Collections.Generic;
using System.IO;
using System.Data;

namespace FluentJdf.TemplateEngine
{
	/// <summary>
	/// Processes the default() formula.
	/// </summary>
	public class JdfDefaultFormulaTemplateItem : FormulaTemplateItem {
        /// <summary>
        /// The null value placeholder value.
        /// </summary>
	    public static string NullValuePlaceholder = "[NULL]";
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="parent">The template item that contains this item.</param>
		/// <param name="name">The name of this template item.</param>
		/// <param name="lineNumber">The line number within the xml template file.</param>
		/// <param name="positionInLine">The column number withing the xml template file.</param>
		protected internal JdfDefaultFormulaTemplateItem(TemplateItem parent, string name, int lineNumber, int positionInLine) :
			base(parent, name, lineNumber, positionInLine)
		{
		}

		/// <summary>
		/// Generate an indicator that tells the parser to replace this value with the correct JDF default.
		/// </summary>
		/// <param name="writer">The writer that receives the data.</param>
		/// <param name="vars">Replacement name/value pairs.  Ignored.</param>
		/// <param name="dataSet">Replacement data for tables.  Ignored.</param>
		/// <returns>True if the replacement took place.</returns>
		protected internal override bool Generate(TextWriter writer, Dictionary<string, string> vars, DataSet dataSet)
		{
            if (!base.Generate(writer, vars, dataSet)) {
                writer.Write(NullValuePlaceholder);
                //throw new NotImplementedException("jdfDefault() is not yet implemented.");
            }

            return true;
		}

		/// <summary>
		/// Returns a string representation of this item.
		/// </summary>
		/// <returns>A string representation of this item.</returns>
		public override string ToString()
		{
			return Name + " = jdfDefault()";
		}
	}
}
