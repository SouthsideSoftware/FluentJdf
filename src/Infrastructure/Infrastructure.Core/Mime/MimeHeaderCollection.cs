using System.Collections;
using System.Collections.Specialized;
using System.Text;

namespace Infrastructure.Core.Mime
{
	/// <summary>
	/// The collection of mime headers keyed by header name.
	/// </summary>
	public class MimeHeaderCollection : IEnumerable
	{
		private HybridDictionary _headers = new HybridDictionary();
		private ArrayList _listHeaders = new ArrayList();

		/// <summary>
		/// Constructor.
		/// </summary>
		public MimeHeaderCollection()
		{
		}

		/// <summary>
		/// Add a mime header.
		/// </summary>
		/// <param name="header">The header to add.</param>
		/// <returns>The newly added header.</returns>
		public MimeHeader Add(MimeHeader header)
		{
			string name = header.Name.ToLower();
			if (_headers.Contains(name))
			{
				_headers.Remove(name);
				RemoveFromList(name);
			}
			_listHeaders.Add(header);
			_headers.Add(header.Name.ToLower(), header);
			return header;
		}

		private void RemoveFromList(string name)
		{
			for (int x = 0; x < _listHeaders.Count; x++)
			{
				MimeHeader header = (MimeHeader)_listHeaders[x];
				if (header.Name == name)
				{
					_listHeaders.RemoveAt(x);
					break;
				}
			}
		}

		/// <summary>
		/// Gets the mime header by key.  Returns null if not found.
		/// </summary>
		public MimeHeader this[string key]
		{
			get
			{
				return (MimeHeader)_headers[key.ToLower()];
			}
		}

		/// <summary>
		/// Gets the mime header by index.
		/// </summary>
		public MimeHeader this[int index]
		{
			get
			{
				return (MimeHeader)_listHeaders[index];
			}
		}

		/// <summary>
		/// Gets the number of entries in the collection.
		/// </summary>
		public int Count
		{
			get
			{
				return _headers.Count;
			}
		}

		/// <summary>
		/// Returns true if the given header name exists in the collection.
		/// </summary>
		/// <param name="headerName">The header name to find.</param>
		/// <returns>True if the header exists.  Otherwise, false.</returns>
		public bool Contains(string headerName)
		{
			return _headers.Contains(headerName.ToLower());
		}
							 
		#region IEnumerable Members

		/// <summary>
		/// Get an enumerator.
		/// </summary>
		/// <returns>An enumerator over MimeHeader objects.</returns>
		public IEnumerator GetEnumerator()
		{
			return new MimeHeaderEnumerator(this);
		}

		#endregion

		/// <summary>
		/// Returns a string representation of the collection.
		/// </summary>
		/// <returns>Lines are terminated with CRLF as described in the MIME standard.</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			foreach (MimeHeader header in this)
			{
				if (sb.Length != 0)
				{
					sb.Append("\r\n");
				}
				sb.Append(header.ToString());
			}
			return sb.ToString();
		}
	}
}