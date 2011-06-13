using System.Collections;

namespace Infrastructure.Core.Mime
{
	/// <summary>
	/// Enumerator over MimeHeader objects in a MimeHeaderCollection.
	/// </summary>
	public class MimeHeaderEnumerator : IEnumerator
	{
		private int _currentIndex;
		private MimeHeaderCollection _headers;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="headers">The MimeHeaderCollection over which to enumerate.</param>
		public MimeHeaderEnumerator(MimeHeaderCollection headers)
		{
			_headers = headers;
			_currentIndex = -1;
		}

		#region IEnumerator Members

		/// <summary>
		/// Reset the enumerator to one before the first element.
		/// </summary>
		public void Reset()
		{
			_currentIndex = -1;
		}

		/// <summary>
		/// Get the current element.
		/// </summary>
		public object Current
		{
			get
			{
				return _headers[_currentIndex];
			}
		}

		/// <summary>
		/// Move to the next element.
		/// </summary>
		/// <returns>True if there was a next element.</returns>
		public bool MoveNext()
		{
			if (_currentIndex < _headers.Count - 1)
			{
				_currentIndex++;
				return true;
			} 
			else 
			{
				return false;
			}
		}
		#endregion
	}
}