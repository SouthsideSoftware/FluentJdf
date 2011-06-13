using System.Collections;
using System.IO;

namespace Infrastructure.Core.Mime
{
	/// <summary>
	/// Summary description for MimeCollection.
	/// </summary>
	public class MimeCollection : IEnumerable
	{
		private ArrayList _parts = new ArrayList();

		/// <summary>
		/// MimeCollection
		/// </summary>
		public MimeCollection()
		{
		}

		/// <summary>
		/// Add a mime message.
		/// </summary>
		/// <param name="part">The part to add.</param>
		/// <returns>The newly added part.</returns>
		public Mime Add(Mime part)
		{
			_parts.Add(part);
			return part;
		}

		/// <summary>
		/// Gets the mime message at the indicated index.
		/// </summary>
		public Mime this[int index]
		{
			get
			{
				return (Mime)_parts[index];
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
		/// Remove the Mime at the given index.
		/// </summary>
		/// <param name="index">The index from which to remove.</param>
		public void RemoveAt(int index)
		{
			_parts.RemoveAt(index);
		}

		/// <summary>
		/// Remove the given Mime from the collection.
		/// </summary>
		/// <param name="part">The part to remove.</param>
		public void Remove(Mime part)
		{
			_parts.Remove(part);
		}

		#region IEnumerable Members

		/// <summary>
		/// Gets an enumerator over the Mime objects in the collection.
		/// </summary>
		/// <returns>An enumerator over Mime objects.</returns>
		public IEnumerator GetEnumerator()
		{
			return _parts.GetEnumerator();
		}

		#endregion

		/// <summary>
		/// Write
		/// </summary>
		/// <param name="writer"></param>
		public void Write(StreamWriter writer)
		{
		}

		/// <summary>
		/// ToString
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return "";
		}

		/// <summary>
		/// GetMimeBinary
		/// </summary>
		/// <returns></returns>
		public byte [] GetMimeBinary()
		{
			byte [] buffer = null;
			return buffer;
		}
	}
}
