using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.Data;

namespace FluentJdf.Template
{
	/// <summary>
	/// A colleciton of template items.
	/// </summary>
	public class TemplateItemCollection : IEnumerable
	{
		private ArrayList _items = new ArrayList();

		/// <summary>
		/// Constructor.
		/// </summary>
		protected internal TemplateItemCollection()
		{
		}

		/// <summary>
		/// Get a template item by index.
		/// </summary>
		/// <value>Returns the specified template item.</value>
		protected internal TemplateItem this[int index]
		{
			get
			{
				return (TemplateItem)_items[index];
			}
		}

		/// <summary>
		/// Gets the number of template items in this collection.
		/// </summary>
		/// <value>The number of template items in this collection.</value>
		protected internal int Count
		{
			get
			{
				return _items.Count;
			}
		}

		/// <summary>
		/// Add a template item to the collection.
		/// </summary>
		/// <param name="item">The template item to be added.</param>
		/// <returns>The newly added template item.</returns>
		protected internal TemplateItem Add(TemplateItem item)
		{
			_items.Add(item);
			return item;
		}

		/// <summary>
		/// Get an enumerator over the template items in this collection.
		/// </summary>
		/// <returns>An enumerator over the TemplateItem objects in the collection.</returns>
		public IEnumerator GetEnumerator()
		{
			return _items.GetEnumerator();
		}

		/// <summary>
		/// Write text to the instance document based on the items contained in this collection.
		/// </summary>
		/// <param name="writer">The writer that will receive the data.</param>
		/// <param name="vars">Simple replacement variables.</param>
		/// <param name="dataSet">Table replacement variables.</param>
		protected internal void Generate(StreamWriter writer, Dictionary<string, string> vars, DataSet dataSet)
		{
			foreach (TemplateItem item in this)
			{
				item.Generate(writer, vars, dataSet);
			}
		}

		/// <summary>
		/// Send a diagnostic display of all the items in this collection 
		/// to the trace listeners.
		/// </summary>
		public void Dump()
		{
			Trace.Indent();
			foreach (TemplateItem item in this)
			{
				item.Dump();
				Trace.WriteLine("********************************************************");
			}
			Trace.Unindent();
		}
	}
}
