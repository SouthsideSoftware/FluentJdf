using System.Collections;

namespace Infrastructure.Core.Mime
{
	/// <summary>
	/// A collection based on an array list of mime messages.
	/// </summary>
	public class MimeMessageCollection : IEnumerable
	{
		private ArrayList _parts = new ArrayList();

		/// <summary>
		/// Constructor.
		/// </summary>
		public MimeMessageCollection()
		{
		}

		/// <summary>
		/// Add a mime message.
		/// </summary>
		/// <param name="part">The part to add.</param>
		/// <returns>The newly added part.</returns>
		public MimeMessage Add(MimeMessage part)
		{
			_parts.Add(part);
			return part;
		}

		/// <summary>
		/// Gets the mime message at the indicated index.
		/// </summary>
		public MimeMessage this[int index]
		{
			get
			{
				return (MimeMessage)_parts[index];
			}
		}

		/// <summary>
		/// Gets the number of elements currently in the collection.
		/// </summary>
		public int Count
		{
			get
			{
				return _parts.Count;
			}
		}

		/// <summary>
		/// Remove the MimeMessage at the given index.
		/// </summary>
		/// <param name="index">The index from which to remove.</param>
		public void RemoveAt(int index)
		{
			_parts.RemoveAt(index);
		}

		/// <summary>
		/// Remove the given MimeMessage from the collection.
		/// </summary>
		/// <param name="part">The part to remove.</param>
		public void Remove(MimeMessage part)
		{
			_parts.Remove(part);
		}

		#region IEnumerable Members

		/// <summary>
		/// Gets an enumerator over the MimeMessage objects in the collection.
		/// </summary>
		/// <returns>An enumerator over MimeMessage objects.</returns>
		public IEnumerator GetEnumerator()
		{
			return _parts.GetEnumerator();
		}

		#endregion
	}
}
