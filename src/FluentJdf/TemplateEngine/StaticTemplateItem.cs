using System.Collections.Generic;
using System.IO;
using System.Data;

namespace FluentJdf.TemplateEngine
{
	/// <summary>
	/// Represents a block of static text.
	/// </summary>
	public class StaticTemplateItem : TemplateItem
	{
		private string _text;

		/// <summary>
		/// Construct an item.
		/// </summary>
		/// <param name="parent">The template item that contains this item.</param>
		/// <param name="name">The name of this item.</param>
		/// <param name="lineNumber">The line number in the xml template file.</param>
		/// <param name="positionInLine">The column number in the xml template file.</param>
		/// <param name="text">The static text this item will represent.</param>
		protected internal StaticTemplateItem(TemplateItem parent, string name, int lineNumber, int positionInLine, string text) :
			base(parent, name, lineNumber, positionInLine)
		{
			_text = text;
		}

		/// <summary>
		/// Gets the text from this item.
		/// </summary>
		/// <value>The text.</value>
		public string Text
		{
			get
			{
				return _text;
			}
		}

		/// <summary>
		/// Write the static text to the instance document.
		/// </summary>
		/// <param name="writer">The writer to which to write.</param>
		/// <param name="vars">Name/value pairs for replacement.  Ignored.</param>
		/// <param name="dataSet">Data for table replacements.  Ignored.</param>
		/// <returns>True if the replacement took place.</returns>
		protected internal override bool Generate(TextWriter writer, Dictionary<string, string> vars, DataSet dataSet)
		{
			writer.Write(_text);

			return true;
		}

		/// <summary>
		/// Gets a string representation of the current item.
		/// </summary>
		/// <returns>A string representation of the current item.</returns>
		public override string ToString()
		{
			return _text;
		}
	}
}
