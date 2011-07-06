using System;
using System.Collections.Specialized;
using System.IO;
using System.Data;

namespace FluentJdf.Template
{
	/// <summary>
	/// Processes the now() formula.
	/// </summary>
	public class NowFormulaTemplateItem : FormulaTemplateItem
	{
		private static System.Globalization.CultureInfo _usEnglishCultureInfo = new System.Globalization.CultureInfo("en-US");
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="parent">The template item that contains this item.</param>
		/// <param name="name">The name of this template item.</param>
		/// <param name="lineNumber">The line number within the xml template file.</param>
		/// <param name="positionInLine">The column number within the xml template file.</param>
		protected internal NowFormulaTemplateItem(TemplateItem parent, string name, int lineNumber, int positionInLine) :
			base(parent, name, lineNumber, positionInLine)
		{
		}

		/// <summary>
		/// Write out the current time in standard JDF format.
		/// </summary>
		/// <param name="writer">The writer which will receive the string.</param>
		/// <param name="vars">A StringDictionary of name/value replacement values.  Ignored.</param>
		/// <param name="dataSet">Data for use in table replacements.  Ignored.</param>
		/// <returns>True if the replacement was made.</returns>
		protected internal override bool Generate(TextWriter writer, StringDictionary vars, DataSet dataSet)
		{
			if (!base.Generate(writer, vars, dataSet))
			{
				writer.Write(DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ", _usEnglishCultureInfo));
			}

			return true;
		}

		/// <summary>
		/// Returns a string represenation of the current item.
		/// </summary>
		/// <returns>A string representation of the current item.</returns>
		public override string ToString()
		{
			return Name + " = now()";
		}
	}
}
