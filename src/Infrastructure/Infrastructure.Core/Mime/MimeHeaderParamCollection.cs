using System.Collections;
using System.Collections.Specialized;
using System.Text;
using Infrastructure.Core.Logging;
using Infrastructure.Core.Resources;

namespace Infrastructure.Core.Mime
{
	/// <summary>
	/// The collection of mime headers keyed by header name.
	/// </summary>
	public class MimeHeaderParamCollection : IEnumerable
	{
		private HybridDictionary _headers = new HybridDictionary();
		private ArrayList _listHeaders = new ArrayList();
	    static ILog logger = LogManager.GetLogger(typeof (MimeHeaderParamCollection));

		/// <summary>
		/// Constructor.
		/// </summary>
		public MimeHeaderParamCollection()
		{
		}

		/// <summary>
		/// Add a mime param header.
		/// </summary>
		/// <param name="header">The header to add.</param>
		/// <returns>The newly added header.</returns>
		public MimeHeaderParam Add(MimeHeaderParam header)
		{
			if (_headers.Contains(header.Name)) {
			    var err = new MimeException(string.Format(Messages.MimeHeaderParamCollection_Add_HeaderParamWithNameExists, header));
                logger.Error(err);
			    throw err;
			}
			_listHeaders.Add(header);
			_headers.Add(header.Name, header);
			return header;
		}

		/// <summary>
		/// Add a mime param header at a specific position.
		/// </summary>
		/// <param name="index">the zero-based position to add.</param>
		/// <param name="header">The header to add.</param>
		/// <returns>The newly added header.</returns>
		public MimeHeaderParam AddAt(int index, MimeHeaderParam header)
		{
			if (_headers.Contains(header.Name)) {
			    var err = new MimeException(string.Format(Messages.MimeHeaderParamCollection_Add_HeaderParamWithNameExists, header));
                logger.Error(err);
			    throw err;
			}
			if (index < 0) {
			    var err = new MimeException(string.Format(Messages.MimeHeaderParamCollection_AddAt_InvalidPositionForMiimeHeader, index));
                logger.Error(err);
			    throw err;
			}
			if (index >= _listHeaders.Count)
			{
				return Add(header);
			}

			//Copy the last item
			_listHeaders.Add((MimeHeaderParam)_listHeaders[_listHeaders.Count - 1]);

            //Move other items
			if (_listHeaders.Count > 2 && index <= _listHeaders.Count - 2)
			{
				for(int i = _listHeaders.Count - 2; i >= index; i--)
				{
					_listHeaders[i + 1] = (MimeHeaderParam)_listHeaders[i];
				}
			}

			//Save this item at the specific index
			_listHeaders[index] = header;
			_headers.Add(header.Name, header);
			return header;
		}

		/// <summary>
		/// Determines whether the header parameter collection contains a specific key.
		/// </summary>
		/// <param name="key">key to find</param>
		/// <returns>True if the collection contains the specific key. False if not.</returns>
		public bool Contains(string key)
		{
			return _headers.Contains(key);
		}

		/// <summary>
		/// Gets the mime param header by key.  Returns null if not found.
		/// </summary>
		public MimeHeaderParam this[string key]
		{
			get
			{
				return (MimeHeaderParam)_headers[key.ToLower()];
			}
		}

		/// <summary>
		/// Gets the mime param header by index.
		/// </summary>
		public MimeHeaderParam this[int index]
		{
			get
			{
				return (MimeHeaderParam)_listHeaders[index];
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
							 
		#region IEnumerable Members

		/// <summary>
		/// Get an enumerator.
		/// </summary>
		/// <returns>An enumerator over MimeHeader objects.</returns>
		public IEnumerator GetEnumerator()
		{
			return new MimeHeaderParamEnumerator(this);
		}

		#endregion

		/// <summary>
		/// Returns a string representation of the collection.
		/// </summary>
		/// <returns>Parameters are seperated with a ';' as described in the mime standard.</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			for(int i = 0; i < _listHeaders.Count; i++)
			{
				sb.Append("; ");
				sb.Append(((MimeHeaderParam)_listHeaders[i]).ToString());
			}
			return sb.ToString();
		}
	}
}

