using System;
using System.Text;
using System.IO;
using Infrastructure.Core.Logging;
using Infrastructure.Core.Resources;

namespace Infrastructure.Core.Mime
{
	/// <summary> 
	/// Represents a mime message with a collection of headers and a 
	/// body.
	/// </summary>
	public class MimeMessage {
	    static ILog logger = LogManager.GetLogger(typeof (MimeMessage));
		private MimeHeaderCollection _headers = new MimeHeaderCollection();
		private MimeBodyPart _body = null;

		private string _encoding;
		private bool _isMultiPart = false;
		private string _boundary = null;

		#region Constructors
		/// <summary>
		/// Constructor.
		/// </summary>
		public MimeMessage()
		{
			CreateDefaultHeaders();
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public MimeMessage(MimeBodyPart body)
		{
			_body = body;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public MimeMessage(string fileName) 
			: this(File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
		{
			_body.FileName = fileName;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="bytes"></param>
		public MimeMessage(byte [] bytes) 
			: this(new MemoryStream(bytes))
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="stream"></param>
		public MimeMessage(Stream stream) 
		{
			MimeParser mp = new MimeParser(stream);
			Parse(ref mp, null);
			CreateDefaultHeaders();
			mp = null;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="mp">MimeParser</param>
		/// <param name="parentMultipartBody">Multipart Body of parent messages</param>
		protected MimeMessage(ref MimeParser mp, MimeMultipartBody parentMultipartBody)
		{
			if (parentMultipartBody != null)
			{
				parentMultipartBody.Add(this);
			}
			Parse(ref mp, parentMultipartBody);
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the headers associated with this message.
		/// </summary>
		public MimeHeaderCollection Headers
		{
			get
			{
				return _headers;
			}
		}

		/// <summary>
		/// Gets the content type of the body.
		/// </summary>
		/// <exception cref="MimeException">If the body is null.</exception>
		public string ContentType
		{
			get
			{
				if (_body == null) {
                    MimeException.ThrowAndLog(Messages.MimeMessage_ContentTypeUnknownBecauseNoBody, GetType());
				} 
				else 
				{
					return _body.ContentType;
				}

				return null;
			}
			set
			{
				if (_body != null)
				{
					_body.ContentType = value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the body of the message.
		/// </summary>
		public MimeBodyPart Body
		{
			get
			{
				return _body;
			}
			set 
			{
				_body = value;
			}
		}

		#region Chilkat properties
		/// <summary>
		/// Number of parts
		/// </summary>
		public int NumParts
		{
			get
			{
				if (_isMultiPart)
				{
					return ((MimeMultipartBody)_body).NumParts;
				}
				return 0;
			}
		}

		/// <summary>
		/// Content type encoding of mime file.
		/// </summary>
		public string Encoding
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

		/// <summary>
		/// Name of mime file.
		/// </summary>
		public string Filename
		{
			get
			{
				return _body.FileName;
			}
			set
			{
                _body.FileName = value;
			}
		}
		#endregion
		#endregion

		#region Methods
		/// <summary>
		/// Construct a new Mime Multipart message
		/// </summary>
		/// <returns></returns>
		public static MimeMessage CreateMimeMultipartRelated()
		{
			MimeMessage message = new MimeMessage();
			message._body = new MimeMultipartBody();
            message.Headers.Add(new MimeHeader("Content-Type:" + message._body.ContentType + "; boundary=" + ((MimeMultipartBody)message._body).Boundary));
			message._body.SetText("This is a multi-part message in MIME format.");
			message._isMultiPart = true;
			return message;
		}

		private void CreateDefaultHeaders()
		{
			if (_headers["mime-version"] == null)
			{
				_headers.Add(new MimeHeader("MIME-Version", "1.0"));
			}
		}

		/// <summary>
		/// Deletes the body.
		/// </summary>
		public void DeleteBody()
		{
			_body = null;
		}

		/// <summary>
		/// Output the mime message to a stream.
		/// </summary>
		/// <param name="stream"></param>
		public void Write(Stream stream)
		{
			if (_body == null)
			{
                MimeException.ThrowAndLog(Messages.MimeMessage_Write_MimeMustHaveBody, GetType());
			}

			StreamWriter writer = new StreamWriter(stream);
			try
			{
				writer.AutoFlush = true;
				_body.AddAdditionalHeader(_headers);
				writer.WriteLine(_headers.ToString());
				_body.Write(writer);
			}
			catch(Exception err)
			{
                logger.Error(err);
                throw;
			}
			finally 
			{
				writer.Close();
			}
		}

		internal void Write(StreamWriter writer)
		{
			try
			{
				_body.AddAdditionalHeader(_headers);
				writer.WriteLine(_headers.ToString());
				_body.Write(writer);
			} 
			catch(Exception err) 
			{
                logger.Error(err);
			    throw;
			}
		}

		private void Parse(ref MimeParser mp, MimeMultipartBody parentMultipartBody)
		{
			try
			{
				string sLine = "";
				byte [] buffer = null;
				bool isEOC = false;
				bool readBinaryBody = false;

				while(sLine != null)
				{
					//Check if the Binary encoding header is found
					if (_headers["content-transfer-encoding"] != null && 
						MimeBodyPart.GetMimeEncoding(_headers["content-transfer-encoding"].Value) == MimeBodyPart.MimeEncoding.Binary
						&& buffer == null)
					{
						readBinaryBody = true;
					}
					MimeParser.ChunkType chunkType = mp.ReadNextChunk(ref sLine, ref isEOC, ref readBinaryBody, ref buffer);

					switch(chunkType)
					{
						case MimeParser.ChunkType.VersionHeader:
						case MimeParser.ChunkType.Header:
							MimeHeader mh = new MimeHeader(sLine);
							InitializeMultipart(ref mp, mh);
							_headers.Add(mh);
							break;
						case MimeParser.ChunkType.Body:
							CreateBody(sLine, buffer);
							break;
						case MimeParser.ChunkType.StartBoundary:
							if (_body == null)
                                CreateBody("", buffer);
							MimeMessage firstMessage = new MimeMessage(ref mp, (MimeMultipartBody)_body);
							break;
						case MimeParser.ChunkType.Boundary:
							MimeMessage nextMessage = new MimeMessage(ref mp, parentMultipartBody);
							return;
						case MimeParser.ChunkType.EndBoundary:
							return;
						case MimeParser.ChunkType.EOF:
							break;
						default:
							break;
					}
				}
			}
			catch(Exception err)
			{
                logger.Error(err);
                throw;
			}
		}

		private void CreateBody(string sLine, byte [] buffer)
		{
			MimeBodyPart mbp = null;
			if (_isMultiPart)
			{
				mbp = new MimeMultipartBody(_boundary);
			}
			else
			{
				mbp = new MimeBasicPart();
			}
			_body = mbp;
			//Set content type
			string charset = null;
			if (_headers["content-type"] != null)
			{
				_body.ContentType = _headers["content-type"].Value;
				if (_headers["content-type"].Parameters["charset"] != null)
				{
					charset = _headers["content-type"].Parameters["charset"].Value;
				}
			}

			//Set content type
			if (_headers["content-transfer-encoding"] != null)
			{
				_body.Encoding = MimeBodyPart.GetMimeEncoding(_headers["content-transfer-encoding"].Value);
			}

			//Set text
			if (sLine != null)
			{
				if (_body.Encoding == MimeBodyPart.MimeEncoding.Binary)
				{
					//Copy buffer
					_body.Buffer = buffer;
				}
				else if (_body.Encoding == MimeBodyPart.MimeEncoding.Base64)
				{
					_body.Buffer = Convert.FromBase64String(sLine);
				}
				else
				{
					if (charset != null)
					{
						_body.SetText(sLine, MimeBodyPart.GetMimeCharset(charset));
					}
					else
					{
						_body.SetText(sLine);
					}
				}
			}
		}

		private void InitializeMultipart(ref MimeParser mp, MimeHeader mh)
		{
			//Check Content-Type
			if (mh.Name.ToLower().CompareTo("content-type") == 0
				&& mh.Value.StartsWith("multipart"))
			{
				_isMultiPart = true;
				mp.IsMultiPart = _isMultiPart;
							
				//Check boundary
				if (mh.Parameters["boundary"] != null)
				{
					_boundary = mh.Parameters["boundary"].Value;
					mp.Boundary = _boundary;
				}
			}
		}

		/// <summary>
		/// Returns string representation of the MimeMessage.
		/// </summary>
		/// <returns>string</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			try
			{
				_body.AddAdditionalHeader(_headers);
				sb.Append(_headers.ToString());
				sb.Append("\r\n");
				sb.Append(_body.ToString());
			}
			catch(Exception err)
			{
                logger.Error(err);
                throw;
			}
			return sb.ToString();
		}

		/// <summary>
		/// Returns byte representation of the MimeMessage.
		/// </summary>
		/// <returns>bytes</returns>
		public byte [] GetMimeBinary()
		{
			
			MemoryStream memStream = new MemoryStream();
			try
			{
				StringBuilder sb = new StringBuilder();
				byte [] bytes = null;
				_body.AddAdditionalHeader(_headers);
				sb.Append(_headers.ToString());
				sb.Append("\r\n\r\n");
                bytes = System.Text.Encoding.ASCII.GetBytes(sb.ToString());
				if (bytes != null)
				{
					memStream.Write(bytes, 0, bytes.Length);
				}
				bytes = _body.GetMimeBinary();
				if (bytes != null)
				{
					memStream.Write(bytes, 0, bytes.Length);
				}
			}
			catch(Exception err)
			{
                logger.Error(err);
                throw;
			}
			return memStream.ToArray();
		}

		#region Chilkat methods
		/// <summary>
		/// Return the part of given index as Mime message.
		/// </summary>
		/// <param name="partIndex">Index of part</param>
		/// <returns>MimeMessage</returns>
		public MimeMessage GetPart(int partIndex)
		{
			if (_isMultiPart && ((MimeMultipartBody)_body).NumParts > partIndex)
			{
				return ((MimeMultipartBody)_body).GetPart(partIndex);
			}
			return null;
		}

		/// <summary>
		/// Return the value of the specified header
		/// </summary>
		/// <param name="headerName">Name of header</param>
		/// <returns>value of specified header.</returns>
		public string GetHeaderField(string headerName)
		{
			if (_headers[headerName.ToLower()] != null)
			{
				return _headers[headerName.ToLower()].Value;
			}
			return "";
		}

		/// <summary>
		/// Return xml string as body
		/// </summary>
		/// <returns>string of xml body</returns>
		public string GetXml()
		{
			if (_body != null)
			{
				return _body.GetXml();
			}
			return "";
		}

		/// <summary>
		/// Return bytes as binary body
		/// </summary>
		/// <returns>bytes of binary body</returns>
		public byte [] GetBodyBinary()
		{
			if (_body != null)
			{
				return _body.GetBodyBinary();
			}
			return System.Text.Encoding.UTF8.GetBytes("");
		}

		/// <summary>
		/// Set header field
		/// </summary>
		/// <param name="nameField"></param>
		/// <param name="valueField"></param>
		public void SetHeaderField(string nameField, string valueField)
		{
			if (!_headers.Contains(nameField))
			{
				_headers.Add(new MimeHeader(nameField, valueField));
			}
			else
			{
                _headers[nameField].Value = valueField;
			}
		}

		/// <summary>
		/// Set body of the message from plain text
		/// </summary>
		/// <param name="plainText">plain text to set the body</param>
		public void SetBodyFromPlainText(string plainText)
		{
			if (_body == null)
			{
				_body = new MimeBasicPart();
			}
			_body.SetText(plainText);
		}

		/// <summary>
		/// Set body of the message from Xml text
		/// </summary>
		/// <param name="xmlText">Xml text to set the body</param>
		public void SetBodyFromXml(string xmlText)
		{
			SetBodyFromPlainText(xmlText);
			_body.ContentType = "text/xml";
		}

		/// <summary>
		/// Set body of the message from binary byte array
		/// </summary>
		/// <param name="buffer"></param>
		public void SetBodyFromBinary(byte [] buffer)
		{
			if (_body == null)
			{
				_body = new MimeBasicPart();
			}
			_body.Buffer = buffer;
		}

		/// <summary>
		/// Return boolean indicating whether the body of the message is xml
		/// </summary>
		public bool IsXml()
		{
			if (_body != null)
			{
				return _body.IsXml;
			}
			return false;
		}

		/// <summary>
		/// Append the given part to the body
		/// </summary>
		/// <param name="part"></param>
		public void AppendPart(MimeMessage part)
		{
			if (_isMultiPart)
			{
				if (_body == null)
				{
					_body  = new MimeMultipartBody();
				}
				((MimeMultipartBody)_body).Add(part);
			}
		}

		/// <summary>
		/// Return string of the whole message
		/// </summary>
		/// <returns></returns>
		public string GetMime()
		{
            return ToString();
		}
		#endregion
		#endregion
	}
}
