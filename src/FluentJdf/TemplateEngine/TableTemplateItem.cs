using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Threading;
using FluentJdf.LinqToJdf;
using FluentJdf.Resources;
using Infrastructure.Core.Logging;

namespace FluentJdf.TemplateEngine
{
	/// <summary>
	/// Contains a set of fields that may be replaced based on data from a DataTable.
	/// </summary>
	public class TableTemplateItem : TemplateItem {
	    static readonly ILog logger = LogManager.GetLogger(typeof (TableTemplateItem));

	    /// <summary>
	    /// The name of the table.
	    /// </summary>
	    protected string tableName;

        /// <summary>
        /// The table.
        /// </summary>
	    protected IEnumerable table;

        /// <summary>
        /// The current row/object from the table.
        /// </summary>
	    protected object row;

		/// <summary>
		/// Create an instance.
		/// </summary>
		/// <param name="parent">The template item that contains this item.</param>
		/// <param name="name">The name of this item.</param>
		/// <param name="lineNumber">This items's line number within the xml template file.</param>
		/// <param name="positionInLine">This item's column number within the xml template file.</param>
		/// <param name="tableName">The key of the item in the name/values dictionary that is the table.</param>
		protected internal TableTemplateItem(TemplateItem parent, string name, int lineNumber, int positionInLine, string tableName) :
			base(parent, name, lineNumber, positionInLine)
		{
			this.tableName = tableName;
		}

		/// <summary>
		/// Gets the table name for this table item.
		/// </summary>
		/// <value>The table name for this table item.</value>
		public string TableName
		{
			get
			{
				return tableName;
			}
		}

		/// <summary>
		/// Returns true if this table name is for the given table.
		/// </summary>
		/// <param name="tableName">The table name to check.</param>
		/// <returns>True if this table item uses the named table.  Otherwise, false.</returns>
		protected internal bool IsTableOwner(string tableName)
		{
			return (this.tableName == tableName);
		}

		/// <summary>
		/// Loop over all contained items and tell them to generate instance data text.
		/// </summary>
		/// <param name="writer">The writer that will receive output.</param>
		/// <param name="vars">The name/value pairs used for simple replacement fields.</param>
		/// <returns>True if the replacement took place.</returns>
		protected internal override bool Generate(TextWriter writer, Dictionary<string, object> vars)
		{
            if (!vars.ContainsKey(tableName) || !typeof(IEnumerable).IsAssignableFrom(vars[tableName].GetType())) {
                throw new ArgumentException(string.Format("The variable {0} is not eligible for table processing because it does not exist or is not IEnumerable",
                                                          tableName));
            }
            try {
                table = (IEnumerable) vars[tableName];

                foreach (var obj in table) {
                    row = obj;
                    GenerateChildren(writer, vars);
                }
            }
            finally {
                table = null;
                row = null;
            }
			 
			
			return true;
		}

		private void GenerateChildren(TextWriter writer, Dictionary<string, object> vars)
		{
			foreach (TemplateItem item in children)
			{
				item.Generate(writer, vars);
			}
		}

		/// <summary>
		/// Returns the replacement value for the named field.
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the field does not exist in the table or the field in the 
		/// row has a null value, null is returned.
		/// </para>
		/// <para>
		/// If the field name is ToString, then the string
		/// value of the object is returned.
		/// </para>
		/// </remarks>
		/// <param name="varName">The name of the field in the table.</param>
		/// <returns>A string data value or null.</returns>
		protected internal string GetVariableValue(string varName)
		{
			string val = null;
            if (varName == "ToString") return row.ToString();

            var propertyInfo = row.GetType().GetProperty(varName);
            if (propertyInfo != null) {
                var value = propertyInfo.GetValue(row, null);
                if (value is DateTime) {
                    val = ((DateTime) value).ToJdfDateTimeString();
                }
                else {
                    val = value.ToString();
                }
            }

		    return val;
		}

		/// <summary>
		/// Returns a string representation of the current item.
		/// </summary>
		/// <returns>A string representation of the current item.</returns>
		public override string ToString()
		{
			return "Table " + tableName;
		}
	}
}
