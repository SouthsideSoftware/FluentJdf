using System;
using System.IO;
using System.Text;

namespace Infrastructure.Core.Mime
{
	/// <summary>
	/// Represents a MultiPart mime body.
	/// </summary>
	public class MimeMultipartBody : MimeBodyPart
	{
		private MimeMessageCollection _parts = new MimeMessageCollection();
		private string _boundary;
		private string _outputBoundary;


		/// <summary>
		/// Constructor.
		/// </summary>
		public MimeMultipartBody()
		{
			ContentType = "multipart/related";
			_boundary = GenerateBoundary();
			_outputBoundary = "--" + _boundary;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public MimeMultipartBody(string boundary)
		{
			ContentType = "multipart/related";
			_boundary = boundary;
			_outputBoundary = "--" + _boundary;
		}

		private string GenerateBoundary()
		{
			return "----" + Guid.NewGuid().ToString();
		}

		/// <summary>
		/// Boundary of the multi part
		/// </summary>
		public string Boundary
		{
			get
			{
				return _boundary;
			}
		}

		/// <summary>
		/// Add a mime message to the multipart message.
		/// </summary>
		/// <param name="part">The MimeMessage to add.</param>
		/// <returns>The newly added MimeMessage</returns>
		public MimeMessage Add(MimeMessage part)
		{
			return _parts.Add(part);
		}

		/// <summary>
		/// Remove the given MimeMessage from this multipart message.
		/// </summary>
		/// <param name="part">The MimeMessage to remove.</param>
		public void Remove(MimeMessage part)
		{
			_parts.Remove(part);
		}

		/// <summary>
		/// Number of parts
		/// </summary>
		public int NumParts
		{
			get
			{
				if (_parts == null)
					return 0;
				return _parts.Count;
			}
		}

		/// <summary>
		/// Return the part of given index as Mime message. 
		/// </summary>
		/// <param name="partIndex">Index of part</param>
		/// <returns>MimeMessage</returns>
		public MimeMessage GetPart(int partIndex)
		{
			if (_parts != null && _parts.Count > partIndex)
			{
				return (MimeMessage)_parts[partIndex];
			}
			return null;
		}

		/// <summary>
		/// Remove the MimeMessage at the given index.
		/// </summary>
		/// <param name="index">The index from which to remove a part.</param>
		public void RemoveAt(int index)
		{
			_parts.RemoveAt(index);
		}

		/// <summary>
		/// Write the body of this multipart message.
		/// </summary>
		/// <param name="writer">The writer that receives the output.</param>
		/// <remarks>
		/// The body of a multipart message consists of 1..n child parts.
		/// </remarks>
		protected override void WriteBody(StreamWriter writer)
		{
			base.WriteBody(writer);
			foreach (MimeMessage part in _parts)
			{
				writer.WriteLine("");
				writer.WriteLine(_outputBoundary);
				part.Write(writer);
			}
			writer.WriteLine("");
			writer.WriteLine(_outputBoundary + "--");
		}

		/// <summary>
		/// Returns a string representation of the MimeMultipartBody.
		/// </summary>
		/// <returns>string</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToString());
			foreach (MimeMessage part in _parts)
			{
				sb.Append("\r\n");
				sb.Append(_outputBoundary);
				sb.Append("\r\n");
				sb.Append(part.ToString());
			}
			sb.Append("\r\n");
			sb.Append(_outputBoundary + "--");
			return sb.ToString();
		}

		/// <summary>
		/// Returns byte representation of the MimeMessage.
		/// </summary>
		/// <returns>bytes</returns>
		public override byte [] GetMimeBinary()
		{
			MemoryStream memStream = new MemoryStream();
			try
			{
				byte [] bytes = null;
				bytes = base.GetBodyBinary();
				if (bytes != null)
				{
					memStream.Write(bytes, 0, bytes.Length);
				}
				foreach (MimeMessage part in _parts)
				{
					bytes = System.Text.Encoding.ASCII.GetBytes("\r\n" + _outputBoundary + "\r\n");
					if (bytes != null)
					{
						memStream.Write(bytes, 0, bytes.Length);
					}
                    bytes = part.GetMimeBinary();
					if (bytes != null)
					{
						memStream.Write(bytes, 0, bytes.Length);
					}
				}
				bytes = System.Text.Encoding.ASCII.GetBytes("\r\n" + _outputBoundary + "--");
				if (bytes != null)
				{
					memStream.Write(bytes, 0, bytes.Length);
				}
			}
			catch(Exception err)
			{
				throw new MimeException(err.Message);
			}
			return memStream.ToArray();
		}
	}
}