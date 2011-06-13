using System.Collections;

namespace Infrastructure.Core.Mime
{
	/// <summary>
	/// A collection based on an array list of mime body parts.
	/// </summary>
	public class MimeBodyPartCollection : IEnumerable
	{
		private ArrayList _parts = new ArrayList();

		/// <summary>
		/// Constructor.
		/// </summary>
		public MimeBodyPartCollection()
		{
		}

		/// <summary>
		/// Add a mime body part.
		/// </summary>
		/// <param name="part">The part to add.</param>
		/// <returns>The newly added part.</returns>
		public MimeBodyPart Add(MimeBodyPart part)
		{
			_parts.Add(part);
			return part;
		}

		/// <summary>
		/// Gets the mime body part at the indicated index.
		/// </summary>
		public MimeBodyPart this[int index]
		{
			get
			{
				return (MimeBodyPart)_parts[index];
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
		/// Remove the MimeBodyPart at the given index.
		/// </summary>
		/// <param name="index">The index from which to remove.</param>
		public void RemoveAt(int index)
		{
			_parts.RemoveAt(index);
		}

		/// <summary>
		/// Remove the given MimeBodyPart from the collection.
		/// </summary>
		/// <param name="part">The part to remove.</param>
		public void Remove(MimeBodyPart part)
		{
			_parts.Remove(part);
		}

		#region IEnumerable Members

		/// <summary>
		/// Gets an enumerator over the MimeBodyPart objects in the collection.
		/// </summary>
		/// <returns>An enumerator over MimeBodyPart objects.</returns>
		public IEnumerator GetEnumerator()
		{
			return _parts.GetEnumerator();
		}

		#endregion
	}
}
