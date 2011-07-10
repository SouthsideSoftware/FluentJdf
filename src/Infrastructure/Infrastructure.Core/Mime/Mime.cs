using System;
using System.Text;
using System.IO;
using System.Xml;
using Infrastructure.Core.Helpers;
using Infrastructure.Core.Logging;
using Infrastructure.Core.Resources;

namespace Infrastructure.Core.Mime
{
	/// <summary>
	/// Alternative Mime which is designed to be compatible with Chilkat Mime.
	/// Chilkat Mime doesn't support Mono but this Mime will.
	/// </summary>
	public class Mime : IDisposable {
	    static ILog logger = LogManager.GetLogger(typeof (Mime));
		/// <summary>
		/// Mime header
		/// </summary>
		private MimeHeaderCollection _headers = new MimeHeaderCollection();
		/// <summary>
		/// Mime encoding for this part.
		/// </summary>
		private MimeEncoding _encoding = MimeEncoding.E7Bit;
		/// <summary>
		/// Indicate if this is a multi part mime
		/// </summary>
		private bool _isMultiPart = false;
		/// <summary>
		/// Boundary of multipart mime
		/// </summary>
		private string _boundary = null;
		/// <summary>
		/// The mime type of the part content.
		/// </summary>
		private string _contentType = "text/plain";
		/// <summary>
		/// The raw bytes for this mime.
		/// </summary>
		private byte [] _buffer;
		/// <summary>
		/// Mime Character set for this part.
		/// </summary>
		private MimeCharset _charset = MimeCharset.Ascii;
		/// <summary>
		/// The name of the file contained within this BodyPart
		/// </summary>
		private string _fileName;

        private string _bufferFileName;

		private string _encodedString;
		private const string MULTIPART = "multipart/related";
		/// <summary>
		/// Collection of nested mimes if thia is multi part mime.
		/// </summary>
		private MimeCollection _mimes = new MimeCollection();

		#region Enum
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

		#endregion

		#region Constructors
		/// <summary>
		/// Constructor.
		/// </summary>
		public Mime()
		{
		}

		/// <summary>
		/// Construct a mime from file.
		/// </summary>
		/// <param name="fileName">name of file to build a mime</param>
		public Mime(string fileName) 
			: this(File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
		{
			_fileName = fileName;
		}

		/// <summary>
		/// Construct a mime from byte array
		/// </summary>
		/// <param name="bytes">byte array to build a mime</param>
		public Mime(byte [] bytes) 
			: this(new MemoryStream(bytes))
		{
		}

		/// <summary>
		/// Construct a mime from stream.
		/// </summary>
		/// <param name="stream">stream to build a mime</param>
		public Mime(Stream stream) :
			this(new MimeParser(stream))
		{
		}

		/// <summary>
		/// Internal use to construct mime from mime parser
		/// </summary>
		/// <param name="mp">MimeParser</param>
		private Mime(MimeParser mp) : 
			this(ref mp, false)
		{
			CreateDefaultHeaders();
			mp = null;
		}

		/// <summary>
		/// Internal use to construct a child mime from mime parser
		/// </summary>
		/// <param name="mp"></param>
		/// <param name="isChildMime"></param>
		private Mime(ref MimeParser mp, bool isChildMime)
		{
			Parse(ref mp, isChildMime);
			//set filename
			if (_headers.Contains("Content-Disposition")
				&& _headers["Content-Disposition"].Parameters.Contains("filename")
				&& _fileName == null)
			{
				FileInfo fi = new FileInfo(_headers["Content-Disposition"].Parameters["filename"].Value);				
				_fileName = fi.Name;
			}
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the headers associated with this mime.
		/// </summary>
		public MimeHeaderCollection Headers
		{
			get
			{
				return _headers;
			}
		}

		/// <summary>
		/// Gets or sets the content type of this mime.
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

		#region Chilkat properties
		/// <summary>
		/// Gets the number of parts
		/// </summary>
		public int NumParts
		{
			get
			{
				return _mimes.Count;
			}
		}

		/// <summary>
		/// Gets or sets Content type encoding of mime file.
		/// </summary>
		public string Encoding
		{
			get
			{
				return Mime.MimeEncodingToString(_encoding);
			}
			set
			{
				_encoding = GetMimeEncoding(value);
				SetHeaderField("content-transfer-encoding", value);
			}
		}

		/// <summary>
		/// Gets or sets Name of mime file.
		/// </summary>
		public string Filename
		{
			get
			{
				return _fileName;
			}
			set
			{
                _fileName = value;
			}
		}
		#endregion

		/// <summary>
		/// Gets or sets the encoding of the part
		/// </summary>
		public MimeEncoding EncodingType
		{
			get
			{
				return _encoding;
			}
			set 
			{
				_encoding = value;
				SetHeaderField("content-transfer-encoding", Mime.MimeEncodingToString(value));
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
                if (_buffer == null && _bufferFileName != null)
                {
                    FileInfo fInfo = new FileInfo(_bufferFileName);
                    _buffer = new byte[fInfo.Length];
                    Stream stream = File.OpenRead(_bufferFileName);
                    try
                    {
                        stream.Read(_buffer, 0, (int)fInfo.Length);
                    }
                    finally
                    {
                        stream.Close();
                    }
                }
				return _buffer;
			}
			set 
			{
				_buffer = value;
				_encodedString = null;
			}
		}

		/// <summary>
		/// Boundary of the multi part
		/// </summary>
		public string Boundary
		{
			get
			{
				if (_boundary == null)
					_boundary = GenerateBoundary();
				return _boundary;
			}
			set
			{
				_boundary = value;
			}
		}

		private string outputBoundary
		{
			get
			{
				if (_boundary != null)
				{
					return MimeParser.BOUNDARY_PREFIX + _boundary;
				}
				return "";
			}
		}

		/// <summary>
		/// Determine if the mime has Parts
		/// </summary>
		public bool HasParts
		{
			get
			{
				return (_mimes.Count > 0);
			}
		}
		#endregion

		#region Static Methods
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
			throw new Exception(string.Format(Messages.Mime_GetMimeEncoding_UnrecognizedMimeEncoding));
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
                case "utf-7":
					return MimeCharset.Utf7;
				case "utf8":
                case "utf-8":
					return MimeCharset.Utf8;
			}
			throw new Exception(string.Format(Messages.Mime_GetMimeCharset_UnrecognizedCharset));
		}

		/// <summary>
		/// Returns a RFC2045 content transfer encoding value for a
		/// given MimeEncoding.
		/// </summary>
		/// <returns></returns>
		public static string MimeEncodingToString(MimeEncoding encoding)
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
		public static string MimeCharsetToString(MimeCharset charset)
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
		#endregion

		#region Parsing Methods
		/// <summary>
		/// Parsing mime from stream
		/// </summary>
		/// <param name="mp"></param>
		/// <param name="isChildMime"></param>
		private void Parse(ref MimeParser mp, bool isChildMime)
		{			
			try
			{
				string sLine = "";
				byte [] buffer = null;
				bool isEOC = false;
				bool readBinaryBody = false;

				//Read line by line
				//if line is null, end of file is detected.
				while(sLine != null)
				{
                    if (isChildMime && _headers["content-type"] != null && _headers["content-type"].Value != "multipart/related")
                    {
                        readBinaryBody = true;
                    }

					//Read next chunk
					//Usually the next line except for reading binary body.  
					//Reading binary body will read until the boundary is found
					MimeParser.ChunkType chunkType = mp.ReadNextChunk(ref sLine, ref isEOC, ref readBinaryBody, ref buffer);

					//perform task based on the chunk type
                    switch (chunkType)
                    {
                        case MimeParser.ChunkType.VersionHeader:
                        case MimeParser.ChunkType.Header:
                            MimeHeader mh = new MimeHeader(sLine);
                            InitializeMultipart(ref mp, mh);
                            _headers.Add(mh);
                            break;
                        case MimeParser.ChunkType.Body:
                            CreateBody(sLine, buffer);
                            //Check if the next line is the boundary of this child mime
                            if (isChildMime && !_isMultiPart)
                                return;
                            break;
                        case MimeParser.ChunkType.StartBoundary:
                        case MimeParser.ChunkType.Boundary:
                            Mime childMessage = new Mime(ref mp, true);
                            _mimes.Add(childMessage);
                            break;
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

		private void CreateBody(string sLine, byte [] buffer)
		{
			//Doublecheck content-type and content-transfer-encoding
			if (_isMultiPart)
			{
				ContentType = MULTIPART;
				if (_boundary == null)
					_boundary = GenerateBoundary();
			}

			//Set content type
			if (_headers["content-type"] != null)
			{
				ContentType = _headers["content-type"].Value;
			}

			//Set content transfer encoding
			if (_headers["content-transfer-encoding"] != null)
			{
				EncodingType = GetMimeEncoding(_headers["content-transfer-encoding"].Value);
			}

			//Set buffer or text
			if (sLine != null)
			{
				if (EncodingType == MimeEncoding.Binary)
				{
					//Copy buffer
					_buffer = buffer;
				}
				else if (EncodingType == MimeEncoding.Base64)
				{
                    sLine = System.Text.Encoding.ASCII.GetString(buffer);
					_buffer = Convert.FromBase64String(sLine);
				}
				else
				{
                    if (buffer != null)
                    {
                        sLine = System.Text.Encoding.UTF8.GetString(buffer);
                    }
					if (_headers["content-type"] != null
						&& _headers["content-type"].Parameters["charset"] != null)
					{
                        MimeCharset charset = GetMimeCharset(_headers["content-type"].Parameters["charset"].Value);
						SetText(sLine, charset);
					}
					else
					{
						SetText(sLine);
					}
				}
			}
		}

		#endregion

		#region MimeBinary Methods
		/// <summary>
		/// Returns byte representation of the Mime.
		/// </summary>
		/// <returns>bytes</returns>
		public byte [] GetMimeBinary()
		{
            Stream mimeStream = GetMimeStream();
            byte [] outBytes = new byte[mimeStream.Length];
            try
            {
                mimeStream.Read(outBytes, 0, (int)mimeStream.Length);
            }
            finally
            {
                mimeStream.Close();
            }
            return outBytes;
		}

        /// <summary>
        /// Gets a memory stream that contains the mime.
        /// </summary>
        /// <returns>A memory stream.</returns>
        public Stream GetMimeStream()
        {
            return GetMimeStream(null);
        }

        /// <summary>
        /// Gets a stream containing the mime.
        /// </summary>
        /// <param name="tempFileName">If non-null, the content is placed in the given file and a FileStream is returned.
        /// If this is null, a memory stream is returned.</param>
        /// <returns>A stream containg the mime.</returns>
        public Stream GetMimeStream(string tempFileName)
        {
            Stream mimeStream = null;
            if (tempFileName != null)
            {
                mimeStream = File.OpenWrite(tempFileName);
            }
            else
            {
                mimeStream = new MemoryStream();
            }
            try
            {
                StringBuilder sb = new StringBuilder();
                byte[] bytes = null;

                //Header
                AddAdditionalHeader();
                //have to read the body here so the header for content length can be added
                string bodyFileName = GetMimeBodyFile(tempFileName);
                sb.Append(_headers.ToString());
                sb.Append("\r\n\r\n");
                bytes = System.Text.Encoding.ASCII.GetBytes(sb.ToString());
                if (bytes != null)
                {
                    mimeStream.Write(bytes, 0, bytes.Length);
                }

                //write Body
                if (bodyFileName != null)
                {
                    try
                    {
                        using (var sourceStream = File.OpenRead(bodyFileName)) {
                            sourceStream.CopyTo(mimeStream);
                            mimeStream.Flush();
                        }
                    }
                    finally
                    {
                        try
                        {
                            File.Delete(bodyFileName);
                        }
                        catch (Exception err)
                        {
                            logger.ErrorFormat(Messages.Mime_GetMimeStream_CouldNotDeleteTempFileUsedToCreateBody,
                                bodyFileName, err);
                        }
                    }
                }

                //nested Mimes
                if (_mimes.Count > 0)
                {
                    string nestedFileName = GetMimeCollectionFile(tempFileName);
                    try
                    {
                        using (var sourceStream = File.OpenRead(nestedFileName))
                        {
                            sourceStream.CopyTo(mimeStream);
                            mimeStream.Flush();
                        }
                    }
                    finally
                    {
                        try
                        {
                            File.Delete(nestedFileName);
                        }
                        catch (Exception err)
                        {
                            logger.ErrorFormat(Messages.Mime_GetMimeStream_CouldNotDeleteTempFileUsedToCreateBody,
                                nestedFileName, err);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                logger.Error(err);
                throw;
            }
            finally
            {
                if (mimeStream.GetType() == typeof(FileStream)) {
                    mimeStream.Close();
                }
            }

            if (tempFileName != null)
            {
                return File.OpenRead(tempFileName);
            }

            return mimeStream as MemoryStream;
        }

        private string GetMimeBodyFile(string tempFileName)
        {
            string bodyFileName = Guid.NewGuid().ToString() + ".buf";
            try
            {
                string workingDir = null;
                if (tempFileName != null)
                {
                    workingDir = Path.GetDirectoryName(tempFileName);
                }
                else
                {
                    workingDir = Path.GetTempPath();
                }

                bodyFileName = Path.Combine(workingDir, bodyFileName);

                if (_bufferFileName != null)
                {
                    switch (_encoding)
                    {
                        case MimeEncoding.Base64:
                            Base64EncodeContent(workingDir, bodyFileName);
                            break;
                        default:
                            using (var sourceStream = File.Open(_bufferFileName, FileMode.Create, FileAccess.Read, FileShare.Read)) {
                                using (var destStream = File.Open(bodyFileName, FileMode.Create, FileAccess.Write)) {
                                    sourceStream.CopyTo(destStream);
                                    destStream.Flush();
                                }
                            }
                            break;
                    }
                }
                else if (_buffer != null)
                {
                    using (var sourceStream = new MemoryStream(GetMimeBodyBinary())) {
                        using (var destStream = File.Open(bodyFileName, FileMode.Create, FileAccess.Write)) {
                            sourceStream.CopyTo(destStream);
                            destStream.Flush();
                        }
                    }
                }
                else
                {
                    bodyFileName = null;
                }
            }
            catch (Exception err)
            {
                logger.Error(err);
                throw;
            }

            if (File.Exists(bodyFileName))
            {
                long contentLength = 0;
                FileInfo fi = new FileInfo(bodyFileName);
                contentLength = fi.Length;
                if (contentLength > 0)
                {
                    if (!_headers.Contains("Content-Length"))
                    {
                        _headers.Add(new MimeHeader("Content-Length", contentLength.ToString()));
                    }
                    else
                    {
                        _headers["Content-Length"].Value = contentLength.ToString();
                    }
                }
            }

            return bodyFileName;
        }

        private void Base64EncodeContent(string workingDir, string bodyFileName)
        {
            string tempFile = Path.Combine(workingDir, Guid.NewGuid().ToString() + ".buf");
            try
            {
                //todo: the size should be configured
                byte[] buffer = new byte[10000];
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                settings.OmitXmlDeclaration = true;
                settings.CloseOutput = true;
                settings.Encoding = ASCIIEncoding.ASCII;
                Stream stream = File.OpenRead(_bufferFileName);
                try
                {
                    XmlWriter writer = XmlWriter.Create(tempFile, settings);
                    try
                    {
                        long bytesRead = 0;
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            writer.WriteBase64(buffer, 0, (int)bytesRead);
                        }
                    }
                    finally
                    {
                        writer.Close();
                    }
                }
                finally
                {
                    stream.Close();
                }

                //write the data out to the data file with \r\n every 76 characters
                buffer = new byte[76];
                Stream inStream = File.OpenRead(tempFile);
                try
                {
                    Stream outStream = File.Open(bodyFileName, FileMode.Create, FileAccess.Write);
                    try
                    {
                        long bytesRead = 0;
                        bool firstChunk = true;
                        while ((bytesRead = inStream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            if (!firstChunk)
                            {
                                byte [] eolBytes = System.Text.Encoding.ASCII.GetBytes("\r\n");
                                if (eolBytes != null)
                                {
                                    outStream.Write(eolBytes, 0, eolBytes.Length);
                                }
                            }
                            firstChunk = false;
                            outStream.Write(buffer, 0, (int)bytesRead);
                        }
                    }
                    finally
                    {
                        outStream.Close();
                    }
                }
                finally
                {
                    inStream.Close();
                }
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    try
                    {
                        File.Delete(tempFile);
                    }
                    catch (Exception err)
                    {
                        logger.ErrorFormat("Could not delete temp file {0} used to base64 encode binary data",
                            tempFile, err);
                    }
                }
            }
        }

		private byte [] GetMimeBodyBinary()
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

		private byte [] GetMimeCollectionBinary()
		{
			MemoryStream memStream = new MemoryStream();
			try
			{
				byte [] bytes;
				foreach (Mime mime in _mimes)
				{
					bytes = System.Text.Encoding.ASCII.GetBytes("\r\n" + outputBoundary + "\r\n");
					if (bytes != null)
					{
						memStream.Write(bytes, 0, bytes.Length);
					}
					bytes = mime.GetMimeBinary();
					if (bytes != null)
					{
						memStream.Write(bytes, 0, bytes.Length);
					}
				}
				bytes = System.Text.Encoding.ASCII.GetBytes("\r\n" + outputBoundary + MimeParser.BOUNDARY_PREFIX);
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

        private string GetMimeCollectionFile(string tempFileName)
        {
            string collectionFileName = Guid.NewGuid().ToString() + ".buf";
            try
            {
                string workingDir = null;
                if (tempFileName != null)
                {
                    workingDir = Path.GetDirectoryName(tempFileName);
                }
                else
                {
                    workingDir = Path.GetTempPath();
                }

                byte[] bytes = null;
                collectionFileName = Path.Combine(workingDir, collectionFileName);
                using (Stream outStream = File.Open(collectionFileName, FileMode.Create, FileAccess.Write)) {
                    foreach (Mime mime in _mimes)
                    {
                        bytes = System.Text.Encoding.ASCII.GetBytes("\r\n" + outputBoundary + "\r\n");
                        if (bytes != null)
                        {
                            outStream.Write(bytes, 0, bytes.Length);
                        }
                        string mimePartFileName = Path.Combine(workingDir, Guid.NewGuid().ToString() + ".buf");
                        Stream mimePartStream = mime.GetMimeStream(mimePartFileName);
                        try
                        {
                            using (var sourceStream = mimePartStream) {
                                sourceStream.CopyTo(outStream);
                            }
                        }
                        finally
                        {
                            try
                            {
                                if (File.Exists(mimePartFileName))
                                {
                                    File.Delete(mimePartFileName);
                                }
                            }
                            catch (Exception err)
                            {
                                logger.ErrorFormat(Messages.Mime_GetMimeStream_CouldNotDeleteTempFileUsedToCreateBody,
                                    mimePartFileName, err);
                            }
                        }
                    }
                    bytes = System.Text.Encoding.ASCII.GetBytes("\r\n" + outputBoundary + MimeParser.BOUNDARY_PREFIX);
                    if (bytes != null)
                    {
                        outStream.Write(bytes, 0, bytes.Length);
                    }
                    outStream.Flush();
                }
            }
            catch (Exception err)
            {
                logger.Error(Messages.Mime_GetMimeCollectionFile_ErrorDuringEncoding, err);
                throw new MimeException(Messages.Mime_GetMimeCollectionFile_ErrorDuringEncoding, err);
            }

            return collectionFileName;
        }
		#endregion

		#region ToString Methods
		/// <summary>
		/// Returns string representation of the Mime.
		/// </summary>
		/// <returns>string</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			try
			{
				AddAdditionalHeader();
				sb.Append(_headers.ToString());
				sb.Append("\r\n");
				sb.Append(BodyToString());
				sb.Append(MimeCollectionToString());
			}
			catch(Exception err)
			{
                logger.Error(err);
			    throw;
			}
			return sb.ToString();
		}

		private string BodyToString()
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

		private string MimeCollectionToString()
		{
			StringBuilder sb = new StringBuilder();
			foreach (Mime mime in _mimes)
			{
				sb.Append("\r\n");
				sb.Append(outputBoundary);
				sb.Append("\r\n");
				sb.Append(mime.ToString());
			}
			sb.Append("\r\n");
			sb.Append(outputBoundary + MimeParser.BOUNDARY_PREFIX);
			return sb.ToString();
		}
		#endregion

		#region Write Methods
		/// <summary>
		/// Output the mime message to a stream.
		/// </summary>
		/// <param name="stream"></param>
		public void Write(Stream stream)
		{
			StreamWriter writer = new StreamWriter(stream);
			try
			{
				writer.AutoFlush = true;
				Write(writer);

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

		/// <summary>
		/// Write to the stream writer
		/// </summary>
		/// <param name="writer"></param>
		public void Write(StreamWriter writer)
		{
			try
			{
				AddAdditionalHeader();
				writer.WriteLine(_headers.ToString());
				WriteBody(writer);
				if (_mimes.Count > 0)
				{
					foreach (Mime mime in _mimes)
					{
						writer.WriteLine("");
						writer.WriteLine(outputBoundary);
						mime.Write(writer);
					}
					writer.WriteLine("");
					writer.WriteLine(outputBoundary + MimeParser.BOUNDARY_PREFIX);
				}
			} 
			catch(Exception err) 
			{
                logger.Error(err);
			    throw;
			}
		}

		/// <summary>
		/// Encode the body and write to the stream writer.
		/// </summary>
		/// <param name="writer">A StreamWriter to receive the output.</param>
		private void WriteBody(StreamWriter writer)
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
		#endregion

		#region Chilkat methods
		/// <summary>
		/// Return the part of given index as Mime message.
		/// </summary>
		/// <param name="partIndex">Index of part</param>
		/// <returns>Mime</returns>
		public Mime GetPart(int partIndex)
		{
			if (_mimes.Count > partIndex)
			{
				return _mimes[partIndex];
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
	    /// <param name="charset"></param>
	    public void SetBodyFromPlainText(string plainText, MimeCharset charset)
        {
            SetText(plainText, charset);
        }

		/// <summary>
		/// Set body of the message from plain text
		/// </summary>
		/// <param name="plainText">plain text to set the body</param>
		public void SetBodyFromPlainText(string plainText)
		{
			SetText(plainText);
		}

		/// <summary>
		/// Set body of the message from Xml text
		/// </summary>
		/// <param name="xmlText">Xml text to set the body</param>
		public void SetBodyFromXml(string xmlText)
		{
            //SetBodyFromPlainText(xmlText);
			SetBodyFromPlainText(xmlText, MimeCharset.Utf8);
			_contentType = "text/xml";
		}

		/// <summary>
		/// Set body of the message from binary byte array
		/// </summary>
		/// <param name="buffer"></param>
		public void SetBodyFromBinary(byte [] buffer)
		{
			_buffer = buffer;
		}


		/// <summary>
		/// Return boolean indicating whether the body of the message is xml
		/// </summary>
		public bool IsXml()
		{
			if (_buffer != null)
			{
				string text = GetText(_charset);
				return text.ToLower().StartsWith("<?xml version=");
			}
			return false;
		}

		/// <summary>
		/// Append the given part to the body
		/// </summary>
		/// <param name="part"></param>
		public void AppendPart(Mime part)
		{
			_mimes.Add(part);
		}

		/// <summary>
		/// Return string of the whole message
		/// </summary>
		/// <returns></returns>
		public string GetMime()
		{
			return ToString();
		}

		/// <summary>
		/// Construct a new Mime Multipart message
		/// </summary>
		/// <returns></returns>
		public void NewMultipartRelated()
		{
			SetHeaderField("MIME-Version", "1.0");
			_contentType = MULTIPART;
			_boundary = GenerateBoundary();
			Headers.Add(new MimeHeader("Content-Type:" + ContentType + "; boundary=" + Boundary));
//			SetText("This is a multi-part message in MIME format.");
			_isMultiPart = true;
		}
		#endregion

		#region Methods
		private void CreateDefaultHeaders()
		{
			SetHeaderField("MIME-Version", "1.0");
			CreateDefaultType();
		}

		/// <summary>
		/// Copy Content-type of the first body part and put into 'type' parameter in Content-type header of the mime.
		/// </summary>
		public void CreateDefaultType()
		{
			//if content-type = multipart/related, copy the content-type from the first body part
			//and put it into "type" parameter at the first position
			if (_headers.Contains("Content-Type"))
			{
				_contentType = _headers["Content-Type"].Value;
				//Find the content-type of the first body part
				if (_contentType.ToLower().Equals(MULTIPART) 
					&& _mimes.Count > 0)
				{
					 if (!_mimes[0].Headers.Contains("Content-Type"))
						 _mimes[0].AddContentType();

					string subType = _mimes[0].Headers["Content-Type"].Value;
					MimeHeader mh = _headers["Content-Type"];
					if (!mh.Parameters.Contains("type"))
					{
						mh.Parameters.AddAt(0, new MimeHeaderParam("type", subType));
					}
					else
					{
						mh.Parameters["type"].Value = subType;
					}
					if (!mh.Parameters.Contains("charset"))
					{
						mh.Parameters.AddAt(1, new MimeHeaderParam("charset", "us-ascii"));
					}
				}
			}
		}

		/// <summary>
		/// Add child message
		/// </summary>
		/// <param name="childMime"></param>
		public void Add(Mime childMime)
		{
			_mimes.Add(childMime);
		}

		/// <summary>
		/// Set body of the message from file.
		/// </summary>
		/// <param name="fileName">The file to read from.</param>
		public void SetBodyFromFile(string fileName) {
		    string contentType = fileName.MimeType();
			if (contentType != null)
			{
				_contentType = contentType;
			}
			_fileName = fileName;
            _bufferFileName = fileName;

            ////Copy the file to the buffer of the part
            //MemoryStream memStream = StreamHelper.CopyToMemoryStream(File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read));
            //_buffer = memStream.ToArray();
            //memStream.Close();
		}

		private string GenerateBoundary()
		{
			return "----" + Guid.NewGuid().ToString();
		}

		/// <summary>
		/// This method checks and adds additional required header fields.  
		/// 1. If it is a text type, add the character set
		/// 2. Check and add Content-Transfer-Encoding
		/// 3. Calculates the content length.  For base64 encoding, this
		/// requires encoding the buffer.  Therefore, the encoded data is stored in
		/// _encodedString for use during the body right when base64 encoding is used.
		/// </summary>
		public void AddAdditionalHeader()
		{
            AddAdditionalHeader(_headers);
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
			AddContentType(headers);

			//Add Content-Transfer-Encoding
			if (!headers.Contains("Content-Transfer-Encoding") && _encoding != MimeEncoding.E7Bit)
			{
				headers.Add(new MimeHeader("Content-Transfer-Encoding", Mime.MimeEncodingToString(_encoding)));
			}
			
			//Add Content-Disposition: attachment; filename="Job_10235.jdf"
			if (!headers.Contains("Content-Disposition") && _fileName != null)
			{
				FileInfo fi = new FileInfo(_fileName);				
				MimeHeader mh = new MimeHeader("Content-Disposition", "attachment");
				mh.Parameters.Add(new MimeHeaderParam("filename", fi.Name));
				headers.Add(mh);
			}

			//Add Content-Length
            if (_buffer != null)
            {
                int contentLength = 0;
                if (_encoding == MimeEncoding.Base64)
                {
                    if (EncodedString.Length % 76 > 0)
                    {
                        contentLength = EncodedString.Length / 76 * 2 + EncodedString.Length + 1;
                    }
                    else
                    {
                        contentLength = EncodedString.Length / 76 * 2 + EncodedString.Length;
                    }

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
		/// Add Content type to header
		/// </summary>
		public void AddContentType()
		{
			AddContentType(_headers);
		}

		/// <summary>
		/// Add Content type to the given header
		/// </summary>
		/// <param name="headers">headers to add content typ</param>
		public void AddContentType(MimeHeaderCollection headers)
		{
			if (!headers.Contains("Content-Type") && _contentType != null)
			{
				MimeHeader mh = new MimeHeader("Content-Type", _contentType);
				//if it is a text type, add the character set
				if (_contentType.StartsWith("text/") || _contentType.StartsWith("application/vnd.cip4-j"))
				{
					mh.Parameters.Add(new MimeHeaderParam("charset", Mime.MimeCharsetToString(_charset)));
				} 
				headers.Add(mh);
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
					sb.Append(body.Substring(startIndex, length));
					sb.Append("\r\n");
				}
				startIndex += length;
			}
			return sb.ToString();
		}

		/// <summary>
		/// Return the part of given contentId as Mime.
		/// </summary>
		/// <param name="contentId">Content-Id of mime</param>
		/// <returns>Mime with the specified contentID.</returns>
		public Mime GetPartByContentId(string contentId)
		{
			if (_mimes.Count > 0)
			{
				foreach(Mime mime in _mimes)
				{
					if (mime.Headers.Contains("content-id")
						&& mime.Headers["content-id"].Value.ToLower().Equals(contentId.ToLower()))
                        return mime;
				}
			}
			return null;
		}
		#endregion

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="isDisposing"></param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                if (_bufferFileName != null)
                {
                    if (File.Exists(_bufferFileName))
                    {
                        try
                        {
                            File.Delete(_bufferFileName);
                        }
                        catch (Exception err)
                        {
                            logger.ErrorFormat(Messages.Mime_Dispose_CouldNoDeleteMimeBufferFile, _bufferFileName, err);
                        }
                    } 
                }
                if (_mimes != null)
                {
                    foreach (Mime mime in _mimes)
                    {
                        mime.Dispose();
                    }
                }
            }
        }
	}
}
