using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using FluentJdf.LinqToJdf;

namespace FluentJdf.TemplateEngine
{
	/// <summary>
	/// Handles the generate() formula by generating a GUID string.
	/// </summary>
	public class GenerateFormulaTemplateItem : FormulaTemplateItem
	{
		/// <summary>
		/// Construct an instance.
		/// </summary>
		/// <param name="parent">The template item that contains this template item.</param>
		/// <param name="name">The name of this template item.</param>
		/// <param name="lineNumber">The line number withing the xml file.</param>
		/// <param name="positionInLine">The column number withing the xml file.</param>
		protected internal GenerateFormulaTemplateItem(TemplateItem parent, string name, int lineNumber, int positionInLine) :
			base(parent, name, lineNumber, positionInLine)
		{
		}

		/// <summary>
		/// Generate a GUID string.
		/// </summary>
		/// <param name="writer">Write to which to write the string.</param>
		/// <param name="vars">A Dictionary{string,object} of name/value replacement values.  Ignored.</param>
		/// <returns>True if the replacement occured.</returns>
		protected internal override bool Generate(TextWriter writer, Dictionary<string, object> vars)
		{
			if (!base.Generate(writer, vars))
			{
				writer.Write(Globals.CreateUniqueId("I_"));
			}

			return true;
		}

		/// <summary>
		/// Returns a string representation of the item.
		/// </summary>
		/// <returns>A string representation of the item.</returns>
		public override string ToString()
		{
			return Name + " = generate()";
		}
	}
}
