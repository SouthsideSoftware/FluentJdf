using System.IO;

namespace Infrastructure.Core.Mime
{
	/// <summary>
	/// This represents mime message content such as text or binary data.
	/// </summary>
	public class MimeBasicPart : MimeBodyPart
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		public MimeBasicPart()
		{
		}

		/// <summary>
		/// Construct a basic part from a file.  Attempt to determine
		/// mime type from the file name.
		/// </summary>
		/// <param name="fileName">The file to read from.</param>
		public MimeBasicPart(string fileName)
		{
			string contentType = Config.MimeTypeOfExtension(Path.GetExtension(fileName));
			if (contentType != null)
			{
				_contentType = contentType;
			}

			//Copy the file to the buffer of the part
			MemoryStream memStream = StreamHelper.CopyToMemoryStream(File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read));
			_buffer = memStream.ToArray();
			memStream.Close();
		}
	}
}
