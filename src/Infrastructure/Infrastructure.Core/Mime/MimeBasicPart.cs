using System.IO;
using Infrastructure.Core.Helpers;

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
		public MimeBasicPart(string fileName) {
		    var contentType = fileName.MimeType();
			if (contentType != null)
			{
				_contentType = contentType;
			}

			//Copy the file to the buffer of the part
		    var memStream = new MemoryStream();
            try
            {
                using (var sourceStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    sourceStream.CopyTo(memStream);
                    memStream.Seek(0, SeekOrigin.Begin);
                }
                _buffer = memStream.ToArray();
            }
            finally {
                memStream.Close();
            }
		}
	}
}
