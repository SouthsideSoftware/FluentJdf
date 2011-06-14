using System;
using System.Collections;
using System.IO;
using System.Text;
using Infrastructure.Core.Logging;
using Infrastructure.Core.Resources;

namespace Infrastructure.Core.Mime
{
	/// <summary>
	/// Parses a mime message stream.
	/// </summary>
	public class MimeParser {
	    static ILog logger = LogManager.GetLogger(typeof (MimeParser));
		/// <summary>
		/// The type of thing returned by Read routines
		/// </summary>
		public enum ChunkType
		{
			/// <summary>
			/// A version header.
			/// </summary>
			VersionHeader,
			/// <summary>
			/// A header.
			/// </summary>
			Header,
			/// <summary>
			/// An entity body
			/// </summary>
			Body,
			/// <summary>
			/// A start boundary line
			/// </summary>
			StartBoundary,
			/// <summary>
			/// A boundary line
			/// </summary>
			Boundary,
			/// <summary>
			/// An end boundary line
			/// </summary>
			EndBoundary,
			/// <summary>
			/// EOF reached.
			/// </summary>
			EOF,
            /// <summary>
            /// Unknown
            /// </summary>
            Unknown
		}

		private MimeStreamReader _sReader;
		private string _tempLine = null;
		private bool _isValid = false;
		const string MIME_VERSION_FIELD_NAME = "MIME-Version";
		internal const string BOUNDARY_PREFIX = "--";
		private bool _isMultiPart = false;
		private bool _isInHeaderChunk = false;
		private bool _headerFound = false;
		private string _boundary = null;
		private string _currentBoundary = "";
		private ArrayList _boundaryStack = null;

		#region Constructor and Destructor
		/// <summary>
		/// Constructor.
		/// </summary>
		public MimeParser(Stream stream)
		{
			//Initialize position to the BOF
			if (stream.CanSeek)
			{
				stream.Position = 0;
			}
			_sReader = new MimeStreamReader(stream);
		}

		/// <summary>
		/// Destructor
		/// </summary>
		~MimeParser()
		{
			if (_sReader != null)
			{
				_sReader.Close();
			}
		}
		#endregion

		#region Properties
		/// <summary>
		/// Flag indicating multipart Mime stream
		/// </summary>
		public bool IsMultiPart
		{
			get
			{
				return _isMultiPart;
			}
			set
			{
				_isMultiPart = value;
			}
		}

		/// <summary>
		/// Boundary of multipart Mime message
		/// </summary>
		public string Boundary
		{
			get
			{
				return _boundary;
			}
			set
			{
				if (_boundaryStack == null)
				{
					_boundaryStack = new ArrayList();
				}
				//Push new boundary
				_boundaryStack.Add(value);
				_boundary = value;
			}
		}

		private string LastBoundary
		{
			get
			{
				//Return last boundary
				if (_boundaryStack != null
					&& _boundaryStack.Count > 0)
				{
                    return _boundaryStack[_boundaryStack.Count - 1].ToString();
				}
				return "";
			}
		}
		#endregion

		#region Methods
		/// <summary>
		/// Reads the next chunk from the mime stream and returns it as byte.
		/// </summary>
		/// <param name="buffer">A byte array to hold the data chunk.</param>
		/// <param name="bytesRead">The number of bytes in the chunk.  Will be -1 if EOF.</param>
		/// <param name="isEndOfChunk">False if there is more to read in this chunk.</param>
		/// <returns>The type of thing in the buffer.  If EOF, the buffer is unchanged.</returns>
		public ChunkType ReadNextChunk(ref byte [] buffer, ref int bytesRead, ref bool isEndOfChunk)
		{
			return ChunkType.EOF;
		}

		/// <summary>
		/// Reads the next chunk from the mime stream and returns it as string.
		/// </summary>
		/// <param name="chunkString">A string to hold the data chunk.</param>
		/// <param name="isEndOfChunk">False if there is more to read in this chunk.</param>
		/// <returns>The type of thing in the buffer.  If EOF, the buffer is unchanged.</returns>
		public ChunkType ReadNextChunk(ref string chunkString, ref bool isEndOfChunk)
		{
			bool binary = false;
			byte [] buffer = null;
			return ReadNextChunk(ref chunkString, ref isEndOfChunk, ref binary, ref buffer);
		}

		/// <summary>
		/// Reads the next chunk from the mime stream and returns it as string.
		/// </summary>
		/// <param name="chunkString">A string to hold the data chunk.</param>
		/// <param name="isEndOfChunk">False if there is more to read in this chunk.</param>
		/// <param name="readBinaryBody"></param>
		/// <param name="buffer"></param>
		/// <returns>The type of thing in the buffer.  If EOF, the buffer is unchanged.</returns>
		public ChunkType ReadNextChunk(ref string chunkString, ref bool isEndOfChunk, ref bool readBinaryBody, ref byte [] buffer)
		{
			string sLine = "";
			ChunkType chunkType = ChunkType.EOF;
			isEndOfChunk = true;
			bool readBinaryChunk = false;
			try
			{
				//Read EOF or boundary.  Ignore blank line between parts.
				while(sLine.Trim().Length == 0)
				{
					//Read binary
					if (readBinaryChunk)
					{
						buffer = ReadBytesToBoundary();
						readBinaryBody = false;
						break;
					}
					//Check if the previous line exists
					ReadNextLine(ref sLine);

					//EOF is found
					if (sLine == null)
					{
						chunkString = null;
						return chunkType;
					}

					//If this stream is multi parts and boundary found
					if (_isMultiPart && (IsMimeBoundary(sLine) || IsMimeBoundaryLast(sLine)))
					{
						_headerFound = false;
						return ParseBoundary(sLine, ref chunkString);
					}

					if (readBinaryBody && sLine.Trim().Length == 0)
                        readBinaryChunk = true;
				}

				//The first non-blank line is found
				//Validate if this is a valid MIME stream
				if (!_isValid)
				{
					return ValidateVersionHeader(sLine, ref chunkString);
				}

				//Read Header or Body
				bool isHeader = !_headerFound && IsMimeHeader(sLine);
				if (!_isInHeaderChunk && isHeader)
				{
					_isInHeaderChunk = true;
				}
				chunkType = isHeader?ChunkType.Header:ChunkType.Body;
				StringBuilder sb = new StringBuilder(sLine);
				string nextLine = "";
				bool isEndReading = false;
				//If a blank Line found, keep reading
				while(!isEndReading)
				{
					nextLine = _sReader.ReadNexLine();

					//EOF, boundary or a blank line after header is found
					if (nextLine == null //EOF
						|| (_isMultiPart && (IsMimeBoundary(nextLine) || IsMimeBoundaryLast(nextLine))) //Boundary
						|| (isHeader && nextLine.Trim().Length == 0 && !nextLine.StartsWith("\t")) //a line that looks empty but contains a tab is part of the header
						|| readBinaryChunk) //Blank line after header
					{
						//Save the unhandle line
						_headerFound = (_isInHeaderChunk && nextLine.Trim().Length == 0);
						_tempLine = nextLine;
						_isInHeaderChunk = false;
						isEndOfChunk = true;
						isEndReading = true;
					}
					else
					{
						//Save header chunk into array of headers
						if (_isInHeaderChunk)
						{
							isEndOfChunk = false;
							if (!IsMimeHeader(nextLine)) //Unfold header
							{
								sb.Append(nextLine.Trim());
							}
							else //This is the next header
							{
								_tempLine = nextLine;
								isEndReading = true;
							}
						}
						else  //body part
						{
							sb.Append("\r\n");
							sb.Append(nextLine);
						}
					}
				}
				chunkString = sb.ToString();
			}
			catch(Exception err)
			{
                logger.Error(err);
                throw;
			}
			return chunkType;
		}

		private byte [] ReadBytesToBoundary()
		{
			return _sReader.ReadBytes(_currentBoundary, BOUNDARY_PREFIX);
		}

		private void ReadNextLine(ref string sLine)
		{
			if (_tempLine != null)
			{
				sLine = _tempLine;
				_tempLine = null;
			}
			else
			{
				sLine = _sReader.ReadNexLine(!_isValid);
			}
		}

		private ChunkType ValidateVersionHeader(string sLine, ref string chunkString)
		{
			if (!IsMimeVersionHeader(sLine))
			{
                MimeException.ThrowAndLog(Messages.MimeParser_ValidateVersionHeader_InvalidMimeStream, GetType());
			}
			_isValid = true;
			chunkString = sLine.Trim();
			return ChunkType.VersionHeader;
		}

		private ChunkType ParseBoundary(string sLine, ref string chunkString)
		{
			if (_isMultiPart)
			{
				//Check the boundary
				if (IsMimeBoundary(sLine))
				{
					ChunkType chunkType = ChunkType.Boundary;
					if (_boundary.CompareTo(_currentBoundary) != 0) //Check the start boundary
					{
						_currentBoundary = _boundary;
						chunkType = ChunkType.StartBoundary;                       
					}
					chunkString = sLine.Trim();
					return chunkType;
				}
				else if (IsMimeBoundaryLast(sLine)) //Check the last boundary
				{
					PopBoundary();
					_boundary = LastBoundary;
					_currentBoundary = _boundary;
					chunkString = sLine.Trim();
					return ChunkType.EndBoundary;
				}
				else
				{
                    MimeException.ThrowAndLog(Messages.MimeParser_ParseBoundary_InvalidBoundaryString, GetType());
				}
			}
			else
			{
                MimeException.ThrowAndLog(Messages.MimeParser_ParseBoundary_InvalidMultipart, GetType());
			}

		    return ChunkType.Unknown;
		}

		private bool IsMimeVersionHeader(string streamLine)
		{
            return (streamLine.Trim().ToLower().StartsWith(MIME_VERSION_FIELD_NAME.ToLower()));
		}

		private bool IsMimeHeader(string streamLine)
		{
			//Test if this line is not a parameter line with :
			return (streamLine.Trim().IndexOf(":") > 1);
		}

		private bool IsMimeBoundary(string streamLine)
		{
			return MimeStreamReader.IsMimeBoundary(streamLine, _boundary, BOUNDARY_PREFIX);
		}

		private bool IsMimeBoundaryLast(string streamLine)
		{
			return MimeStreamReader.IsMimeBoundaryLast(streamLine, _boundary, BOUNDARY_PREFIX);

		}

		private void PopBoundary()
		{
			//Return last boundary
			if (_boundaryStack != null
				&& _boundaryStack.Count > 0)
			{
				_boundaryStack.RemoveAt(_boundaryStack.Count - 1);
			}
		}

		/// <summary>
		/// Determine if the next line is Boundary
		/// </summary>
		/// <param name="boundary"></param>
		/// <returns></returns>
		public bool IsNextLineBoundary(string boundary)
		{
			return _sReader.IsNextLineBoundary(boundary, BOUNDARY_PREFIX);
		}
		#endregion
	}
}