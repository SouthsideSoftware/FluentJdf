using System;
using System.IO;
using System.Text;
using Infrastructure.Core.Logging;
using Infrastructure.Core.Resources;

namespace Infrastructure.Core.Mime
{
	/// <summary>
	/// The body of a mime message.  
	/// </summary>
	public abstract class MimeBodyPart {
	    static ILog logger = LogManager.GetLogger(typeof (MimeBodyPart));
		/// <summary>
		/// The mime type of the part content.
		/// </summary>
		protected string _contentType = "text/plain";
		/// <summary>
		/// The raw bytes for this part.
		/// </summary>
		protected byte [] _buffer;
		/// <summary>
		/// Mime encoding for this part.
		/// </summary>
		protected MimeEncoding _encoding = MimeEncoding.E7Bit;
		/// <summary>
		/// Mime Character set for this part.
		/// </summary>
		protected MimeCharset _charset = MimeCharset.Ascii;

		/// <summary>
		/// The name of the file contained within this BodyPart
		/// </summary>
		protected string _fileName;

		private string _encodedString;

		/// <summary>
		/// Encoding of the part.
		/// </summary>
		public enum MimeEncoding
		{
			/// <summary>
			/// Bae64 Transfer encoding 
			/// </summary>
			Base64,
			/// <summary>
			/// Quoted printable transfer encoding.
			/// </summary>
			QuotedPrintable,
			/// <summary>
			/// This is just a hint that the data is binary in nature.  
			/// The data is not encoded in any way.
			/// </summary>
			Binary,
			/// <summary>
			/// This is just a hint that the data is 7bit ascii.  The data
			/// is not encoded in any way.
			/// </summary>
			E7Bit,
			/// <summary>
			/// This is just a hint that the data is 8bit ascii.  The 
			/// data is not encoded in any way.
			/// </summary>
			E8Bit
		}

		/// <summary>
		/// Return MimeEncoding enum based on given encoding string
		/// </summary>
		/// <param name="encoding">encoding string</param>
		/// <returns>MimeEncoding enum</returns>
		public static MimeEncoding GetMimeEncoding(string encoding)
		{
			switch (encoding.ToLower())
			{
				case "base64":
					return MimeEncoding.Base64;
				case "binary":
					return MimeEncoding.Binary;
				case "7bit":
					return MimeEncoding.E7Bit;
				case "8bit":
					return MimeEncoding.E8Bit;
				case "quoted-printable":
					return MimeEncoding.QuotedPrintable;
			}
			throw new Exception(Messages.MimeBodyPart_GetMimeEncoding_UnrecognizedMimeEncoding + encoding);
		}

		/// <summary>
		/// Allowable charsets
		/// </summary>
		public enum MimeCharset
		{
			/// <summary>
			/// The ASCII charset (Encoding.ASCII).  
			/// This is the most portable charset.
			/// </summary>
			Ascii,
			/// <summary>
			/// The BigEndianUnicode charset (Encoding.BigEndianUnicode)
			/// </summary>
			Utf7,
			/// <summary>
			/// The UTF8 charset (Encoding.UTF8).  This is
			/// the most portable charset that can carry double-byte Unicode
			/// characters.
			/// </summary>
			Utf8
		}


		/// <summary>
		/// Return MimeCharset enum based on given charset string
		/// </summary>
		/// <param name="charset">charset string</param>
		/// <returns>MimeCharset enum</returns>
		public static MimeCharset GetMimeCharset(string charset)
		{
			switch (charset.ToLower())
			{
				case "us-ascii":
					return MimeCharset.Ascii;
				case "utf7":
					return MimeCharset.Utf7;
				case "utf8":
					return MimeCharset.Utf8;
			}
			throw new Exception(Messages.MimeBodyPart_GetMimeCharsetUnrecognizedCharset + charset);
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public MimeBodyPart()
		{
		}

		/// <summary>
		/// Gets or sets the content type of the body 
		/// (e.g. multipart/related, text/xml).
		/// </summary>
		public string ContentType
		{
			get
			{
				return _contentType;
			}
			set 
			{
				_contentType = value.ToLower();
			}
		}

		/// <summary>
		/// Gets or sets the encoding of the part
		/// </summary>
		public MimeEncoding Encoding
		{
			get
			{
				return _encoding;
			}
			set 
			{
				_encoding = value;
			}
		}

		private string EncodedString
		{
			get
			{
				if (_encodedString == null && _buffer != null)
				{
					_encodedString = Convert.ToBase64String(_buffer, 0, _buffer.Length);
				}
				return _encodedString;
			}
		}

		/// <summary>
		/// Gets or sets the raw byte array associated with the body part.
		/// </summary>
		public byte [] Buffer
		{
			get
			{
				return _buffer;
			}
			set 
			{
				_buffer = value;
				_encodedString = null;
			}
		}

		/// <summary>
		/// Returns a RFC2045 content transfer encoding value for a
		/// given MimeEncoding.
		/// </summary>
		/// <returns></returns>
		protected string MimeEncodingToString(MimeEncoding encoding)
		{
			switch (encoding)
			{
				case MimeEncoding.Base64:
					return "base64";
				case MimeEncoding.Binary:
					return "binary";
				case MimeEncoding.E7Bit:
					return "7bit";
				case MimeEncoding.E8Bit:
					return "8bit";
				case MimeEncoding.QuotedPrintable:
					return "quoted-printable";
				default:
					return "7bit";
			}
		}

		/// <summary>
		/// Returns a RFC2045 charset string for a given charset.
		/// </summary>
		/// <returns></returns>
		protected string MimeCharsetToString(MimeCharset charset)
		{
			switch (charset)
			{
				case MimeCharset.Ascii:
					return "us-ascii";
				case MimeCharset.Utf7:
					return "UTF-7";
				case MimeCharset.Utf8:
					return "UTF-8";
				default:
					return "us-ascii";
			}
		}

		/// <summary>
		/// Write this part to the output.
		/// </summary>
		/// <param name="writer">A StreamWriter connected to the output stream.</param>
		/// <remarks>
		/// MimeMessage controls opening and closing the StreamWriter.
		/// </remarks>
		protected internal virtual void Write(StreamWriter writer)
		{
			WriteBody(writer);
		}

		/// <summary>
		/// Encode the body and write to the output stream.
		/// </summary>
		/// <param name="writer">A StreamWriter to receive the output.</param>
		protected virtual void WriteBody(StreamWriter writer)
		{
			if (_buffer != null)
			{
				writer.WriteLine("");
				switch (_encoding)
				{
					case MimeEncoding.Base64:
						GetBase64String(writer);
						break;
					case MimeEncoding.QuotedPrintable:
						//TODO: support quoted printable properly
						writer.BaseStream.Write(_buffer, 0, _buffer.Length);
						break;
					default:
						writer.BaseStream.Write(_buffer, 0, _buffer.Length);
						break;
				}
			}
		}

		/// <summary>
		/// This method checks and adds additional required header fields.  
		/// 1. If it is a text type, add the character set
		/// 2. Check and add Content-Transfer-Encoding
		/// 3. Calculates the content length.  For base64 encoding, this
		/// requires encoding the buffer.  Therefore, the encoded data is stored in
		/// _encodedString for use during the body right when base64 encoding is used.
		/// </summary>
		public void AddAdditionalHeader(MimeHeaderCollection headers)
		{
			//Add Content-Type
			if (!headers.Contains("Content-Type") && _contentType != null)
			{
				MimeHeader mh = new MimeHeader("Content-Type", _contentType);
				//if it is a text type, add the character set
				if (_contentType.StartsWith("text/"))
				{
					mh.Parameters.Add(new MimeHeaderParam("charset", MimeCharsetToString(_charset)));
				} 
				headers.Add(mh);
			}

			//Add Content-Transfer-Encoding
			if (!headers.Contains("Content-Transfer-Encoding") && _encoding != MimeEncoding.E7Bit)
			{
				headers.Add(new MimeHeader("Content-Transfer-Encoding", MimeEncodingToString(_encoding)));
			}
			
			//Add Content-Disposition: attachment; filename="Job_10235.jdf"
			if (!headers.Contains("Content-Disposition") && _fileName != null)
			{
				headers.Add(new MimeHeader("Content-Disposition", @"attachment; filename=""" + _fileName + @""""));
			}

			//Add Content-Length
			if (_buffer != null)
			{
				int contentLength = 0;
				if (_encoding == MimeEncoding.Base64)
				{
					_encodedString = Convert.ToBase64String(_buffer, 0, _buffer.Length);
					contentLength = _encodedString.Length;
				} 
				else 
				{
					_encodedString = null;
					contentLength = _buffer.Length;
				}

				if (contentLength != 0)
				{
					if (!headers.Contains("Content-Length"))
					{
						headers.Add(new MimeHeader("Content-Length", contentLength.ToString()));
					}
					else
					{
                        headers["Content-Length"].Value = contentLength.ToString();
					}
				}
			}

		}

		/// <summary>
		/// Gets the text from the part assuming us-ascii charset.
		/// </summary>
		/// <returns>The text from the part.</returns>
		public string GetText()
		{
			return GetText(MimeCharset.Ascii);
		}

		/// <summary>
		/// Gets the text from the part with a given encoding.
		/// </summary>
		/// <param name="charset">The charset to use (e.g. MimeCharset.Ascii)</param>
		/// <returns>The text from the part</returns>
		public string GetText(MimeCharset charset)
		{
			switch (charset)
			{
				case MimeCharset.Ascii:
					return System.Text.Encoding.ASCII.GetString(_buffer);
				case MimeCharset.Utf7:
					return System.Text.Encoding.UTF7.GetString(_buffer);
				case MimeCharset.Utf8:
					return System.Text.Encoding.UTF8.GetString(_buffer);
			}
			return null;
		}

		/// <summary>
		/// Sets the underlying part buffer from a string using the ASCII character set.
		/// </summary>
		/// <param name="val">The string to put in the part.</param>
		/// <remarks>
		/// ContentType becomes text/plain.
		/// </remarks>
		public void SetText(string val)
		{
			SetText(val, MimeCharset.Ascii);
		}

		/// <summary>
		/// Sets the underlying part buffer from a string using the given character set.
		/// </summary>
		/// <param name="val">The string to put in the part.</param>
		/// <param name="charset">The charcter set used to convert the string to bytes.</param>
		public void SetText(string val, MimeCharset charset)
		{
			_charset = charset;
			switch (charset)
			{
				case MimeCharset.Ascii:
					_buffer = System.Text.Encoding.ASCII.GetBytes(val);
					break;
				case MimeCharset.Utf7:
					_buffer = System.Text.Encoding.UTF7.GetBytes(val);
					break;
				case MimeCharset.Utf8:
					_buffer = System.Text.Encoding.UTF8.GetBytes(val);
					break;
			}
		}

		/// <summary>
		/// Returns a string representation of the MimeBodyPart.
		/// </summary>
		/// <returns>string</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			try
			{
				if (_buffer != null)
				{
					switch (_encoding)
					{
						case MimeEncoding.Base64:
							sb.Append(GetBase64String());
							break;
						case MimeEncoding.Binary:
							sb.Append("\r\n");
							sb.Append(GetText(_charset));
							break;
						case MimeEncoding.QuotedPrintable:
							//TODO: support quoted printable properly
							sb.Append("\r\n");
							sb.Append(GetText(_charset));
							break;
						default:
							sb.Append("\r\n");
							sb.Append(GetText(_charset));
							break;
					}
				}
			}
			catch(Exception err)
			{
                logger.Error(err);
			    throw;
			}
			return sb.ToString();
		}

		private string GetBase64String()
		{
			return GetBase64String(null);
		}
		
		private string GetBase64String(StreamWriter writer)
		{
			StringBuilder sb = new StringBuilder();
			string body = EncodedString;
			int startIndex = 0;
			int bodyLength = body.Length;
			//write out the body in 76 character chunks
			while (startIndex < bodyLength)
			{
				int length = 76;
				if (bodyLength - startIndex < length)
				{
					length = bodyLength - startIndex;
				}
				if (writer != null)
				{
					writer.WriteLine(body.Substring(startIndex, length));
				}
				else
				{
					sb.Append("\r\n");
					sb.Append(body.Substring(startIndex, length));
				}
				startIndex += length;
			}
			return sb.ToString();
		}

		/// <summary>
		/// Returns byte representation of the MimeMessage.
		/// </summary>
		/// <returns>bytes</returns>
		public virtual byte [] GetMimeBinary()
		{
			try
			{
				if (_buffer != null)
				{
					switch (_encoding)
					{
						case MimeEncoding.Base64:
                            return System.Text.Encoding.UTF8.GetBytes(GetBase64String());
						default:
                            return _buffer;
					}
				}
			}
			catch(Exception err)
			{
                logger.Error(err);
			    throw;
			}
			return _buffer;
		}

		#region Chilkat compliant methods
		/// <summary>
		/// Return boolean indicating whether the body of the message is xml
		/// </summary>
		public bool IsXml
		{
			get
			{
				if (_buffer != null)
				{
					string text = GetText(_charset);
                    return text.ToLower().StartsWith("<?xml version=");
				}
				return false;
			}
		}

		/// <summary>
		/// The name of the file contained within this BodyPart
		/// </summary>
		public string FileName
		{
			get {  return _fileName; }
			set { _fileName = value; }    
		}

		/// <summary>
		/// Return xml string as body
		/// </summary>
		/// <returns>string of xml body</returns>
		public string GetXml()
		{
			if (_buffer != null)
			{
				return GetText(_charset);
			}
			return null;
		}

		/// <summary>
		/// Return bytes as binary body
		/// </summary>
		/// <returns>bytes of binary body</returns>
		public byte [] GetBodyBinary()
		{
			if (_buffer != null)
			{
				return _buffer;
			}
			return null;
		}
		#endregion
	}
}
