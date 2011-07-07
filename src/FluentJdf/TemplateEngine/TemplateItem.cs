using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Data;
using FluentJdf.Resources;
using Infrastructure.Core.Logging;

namespace FluentJdf.TemplateEngine
{
	/// <summary>
	/// An item within a template.
	/// </summary>
	public abstract class TemplateItem {
	    static readonly ILog logger = LogManager.GetLogger(typeof (TemplateItem));
		/// <summary>
		/// The name of the item.
		/// </summary>
		protected string _name;

		/// <summary>
		/// This item's line number within the xml template file.
		/// </summary>
		protected int _lineNumber;

		/// <summary>
		/// This item's column position within the xml template file.
		/// </summary>
		protected int _positionInLine;

		/// <summary>
		/// The template item that contains this item.  May be null.
		/// </summary>
		protected TemplateItem _parent;

		/// <summary>
		/// A collection of all template items contained by this item.  May be empty.
		/// </summary>
		protected TemplateItemCollection _children = new TemplateItemCollection();

		/// <summary>
		/// If this template item replaces based on a table, this is the table.
		/// </summary>
		protected TableTemplateItem _parentTableItem;

		/// <summary>
		/// Construct an instance.
		/// </summary>
		/// <param name="parent">The template item that contains this item.</param>
		/// <param name="name">The name of this item.</param>
		/// <param name="lineNumber">This item's line number position within the xml template file.</param>
		/// <param name="positionInLine">This item's column position within the xml template file.</param>
		protected internal TemplateItem(TemplateItem parent, string name, int lineNumber, int positionInLine)
		{
			_name = name;
			_lineNumber = lineNumber;
			_positionInLine = positionInLine;
			_parent = parent;
			if (_parent != null)
			{
				_parent._children.Add(this);
			}

			if (name.IndexOf(".") != -1)
			{
				string [] parts = name.Split('.');
				if (parts.Length > 2) {
				    string mess =
				        string.Format(
				            Messages.TemplateItem_TemplateItem_VariableNameIsNotLegal,
				            name);
                    logger.Error(string.Format(Messages.ErrorAtLineAndColumn, mess, _lineNumber, _positionInLine));
                    throw new TemplateExpansionException(_lineNumber, _positionInLine, mess);
				}

				if (parts.Length == 2)
				{
					TemplateItem currentParent = this;
					while (_parentTableItem == null && currentParent.Parent != null)
					{
						currentParent = currentParent.Parent;
						if (currentParent is TableTemplateItem)
						{
							if (((TableTemplateItem)currentParent).IsTableOwner(parts[0]))
							{
								_parentTableItem = (TableTemplateItem)currentParent;
							}
						}
					}

					_name = parts[1];
				}
			}
		}

		/// <summary>
		/// Gets the TemplateItemCollection that contains the 
		/// child TemplateItems
		/// </summary>
		public TemplateItemCollection Children
		{
			get
			{
				return _children;
			}
		}

		/// <summary>
		/// Gets the parent of this item.
		/// </summary>
		/// <value>The parent of this item.</value>
		public TemplateItem Parent
		{
			get
			{
				return _parent;
			}
		}

		/// <summary>
		/// Gets the name of this item.
		/// </summary>
		/// <value>The name of this item.</value>
		public string Name
		{
			get
			{
				return _name;
			}
		}

		/// <summary>
		/// Gets the line number position of this item within the xml template file.
		/// </summary>
		/// <value>The line number position of this item within the xml template file.</value>
		public int LineNumber
		{
			get
			{
				return _lineNumber;
			}
		}

		/// <summary>
		/// Gets the column number position of this item within the xml template file.
		/// </summary>
		/// <value>The column number position of this item within the xml template file.</value>
		public int PositionInLine
		{
			get
			{
				return _positionInLine;
			}
		}

		/// <summary>
		/// Writes text to the output instance document based on this item.
		/// </summary>
		/// <param name="writer">The writer that will receive the data.</param>
		/// <param name="vars">A StringDictionary of name/value pairs for simple replacement fields.</param>
		/// <param name="dataSet">Tables used by table fields.</param>
		/// <returns>True if the replacement took place.</returns>
		protected internal abstract bool Generate(TextWriter writer, Dictionary<string, string> vars, DataSet dataSet);

		/// <summary>
		/// Dump diagnostics about the current item and all its children to the trace listeners.
		/// </summary>
		public void Dump()
		{
			Trace.WriteLine(ToString());
			_children.Dump();
		}
	}
}
