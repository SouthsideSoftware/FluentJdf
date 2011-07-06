using System;
using System.IO;
using System.Collections.Specialized;
using System.Data;
using System.Threading;
using FluentJdf.LinqToJdf;
using FluentJdf.Resources;
using Infrastructure.Core.Logging;

namespace FluentJdf.Template
{
	/// <summary>
	/// Contains a set of fields that may be replaced based on data from a DataTable.
	/// </summary>
	public class TableTemplateItem : TemplateItem {
	    static readonly ILog logger = LogManager.GetLogger(typeof (TableTemplateItem));
		/// <summary>
		/// The name of the table.
		/// </summary>
		protected string _tableName;

		/// <summary>
		/// A TLS slot to hold the current row of data.
		/// </summary>
		protected LocalDataStoreSlot _currentRowSlot = Thread.AllocateDataSlot();

		/// <summary>
		/// A TLS slot to hold the current DataTable object.
		/// </summary>
		protected LocalDataStoreSlot _tableSlot = Thread.AllocateDataSlot();

		/// <summary>
		/// Create an instance.
		/// </summary>
		/// <param name="parent">The template item that contains this item.</param>
		/// <param name="name">The name of this item.</param>
		/// <param name="lineNumber">This items's line number within the xml template file.</param>
		/// <param name="positionInLine">This item's column number within the xml template file.</param>
		/// <param name="tableName">The name of the table for this item.</param>
		protected internal TableTemplateItem(TemplateItem parent, string name, int lineNumber, int positionInLine, string tableName) :
			base(parent, name, lineNumber, positionInLine)
		{
			_tableName = tableName;
		}

		/// <summary>
		/// Gets the table name for this table item.
		/// </summary>
		/// <value>The table name for this table item.</value>
		public string TableName
		{
			get
			{
				return _tableName;
			}
		}

		/// <summary>
		/// Returns true if this table item is for the given table.
		/// </summary>
		/// <param name="tableName">The table name to check.</param>
		/// <returns>True if this table item uses the named table.  Otherwise, false.</returns>
		protected internal bool IsTableOwner(string tableName)
		{
			return (tableName == _tableName);
		}

		/// <summary>
		/// Loop over all contained items and tell them to generate instance data text.
		/// </summary>
		/// <param name="writer">The writer that will receive output.</param>
		/// <param name="vars">The name/value pairs used for simple replacement fields.</param>
		/// <param name="dataSet">The dataset that contains the replacement data for table items.</param>
		/// <returns>True if the replacement took place.</returns>
		protected internal override bool Generate(TextWriter writer, StringDictionary vars, DataSet dataSet)
		{
			Thread.SetData(_tableSlot, null);
			Thread.SetData(_currentRowSlot, null);
			try
			{
				if (dataSet != null)
				{
					DataTable table = dataSet.Tables[_tableName];
					Thread.SetData(_tableSlot, table);
					if (table != null)
					{
						foreach (DataRow row in table.Rows)
						{
							Thread.SetData(_currentRowSlot, row);
							GenerateChildren(writer, vars, dataSet);
						}
					} 
					else {
					    var mess = Messages.TableTemplateItem_Generate_DataSetHasNoTable;
                        logger.ErrorFormat(Messages.ErrorAtLineAndColumn, mess, LineNumber, PositionInLine);
                        throw new TemplateExpansionException(LineNumber, PositionInLine, mess);
					}
				}
				
			}
			finally 
			{
				Thread.SetData(_tableSlot, null);
				Thread.SetData(_currentRowSlot, null);
			}
			 
			
			return true;
		}

		private void GenerateChildren(TextWriter writer, StringDictionary vars, DataSet dataSet)
		{
			foreach (TemplateItem item in _children)
			{
				item.Generate(writer, vars, dataSet);
			}
		}

		/// <summary>
		/// Returns the replacement value for the named field.
		/// </summary>
		/// <remarks>
		/// If the field does not exist in the table or the field in the 
		/// row has a null value, null is returned.
		/// </remarks>
		/// <param name="varName">The name of the field in the table.</param>
		/// <returns>A string data value or null.</returns>
		protected internal string GetVariableValue(string varName)
		{
			string val = null;
			System.Type type = null;

			DataTable table = (DataTable)Thread.GetData(_tableSlot);
			DataRow currentRow = (DataRow)Thread.GetData(_currentRowSlot);

			if (table != null && currentRow != null && table.Columns.Contains(varName))
			{
				if (!currentRow.IsNull(varName))
				{
					type = currentRow[varName].GetType();
					if (type == typeof(DateTime)) {
					    val = ((DateTime) currentRow[varName]).ToJdfDateTimeString();
					} 
					else 
					{
						val = currentRow[varName].ToString();
					}
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
			return "Table " + _tableName;
		}
	}
}
