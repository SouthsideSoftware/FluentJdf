using System.Collections;

namespace Infrastructure.Core.Mime
{
	/// <summary>
	/// Enumerator over MimeHeader objects in a MimeHeaderCollection.
	/// </summary>
	public class MimeHeaderParamEnumerator : IEnumerator
	{
		private int _currentIndex;
		private MimeHeaderParamCollection _headers;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="headers">The MimeHeaderParamCollection over which to enumerate.</param>
		public MimeHeaderParamEnumerator(MimeHeaderParamCollection headers)
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

