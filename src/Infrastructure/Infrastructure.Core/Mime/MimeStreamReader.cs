using System;
using System.IO;
using System.Text;
using Infrastructure.Core.Logging;

namespace Infrastructure.Core.Mime
{
	/// <summary>
	/// Summary description for MimeStreamReader.
	/// </summary>
	public class MimeStreamReader {
	    static ILog logger = LogManager.GetLogger(typeof (MimeStreamReader));
		private Stream _stream;
		private char _lastChar;

		/// <summary>
		/// Mime StreamReader
		/// </summary>
		/// <param name="stream"></param>
		public MimeStreamReader(Stream stream)
		{
			_stream = stream;
			_stream.Position = 0;
		}

		/// <summary>
		/// Read the next line of current stream to string
		/// </summary>
		/// <returns>string of the next line</returns>
		public string ReadNexLine()
		{
			return ReadNexLine(false);
		}

		/// <summary>
		/// Read the next line of current stream to string
		/// </summary>
		/// <param name="ignoreLeadingNonreadableChar">If true, ignore leading-nonreadable characters
		/// a nonreadable character is the ASCII character with Dec > 125 or Hex > 7D
		/// </param>
		/// <returns>string of the next line</returns>
		public string ReadNexLine(bool ignoreLeadingNonreadableChar)
		{
			StringBuilder line = new StringBuilder();
			char c;
			bool isCRLF = false;
			try
			{
				do
				{
					isCRLF = false;
					int byteInt = _stream.ReadByte();
                    if (byteInt == -1)
                    {
                        if (line.Length == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return line.ToString();
                        }
                    }
					c = (char)byteInt;
					if (c.Equals((char)0))
						return line.ToString();
					else if (!IsNewLine(c))
					{
						if (!(ignoreLeadingNonreadableChar 
							&& line.Length == 0
							&& byteInt > 125))
						{
							line.Append(c);
						}
					}
						//Detect CRLF
					else if (_lastChar.Equals((char)13) && c.Equals((char)10))
					{
						isCRLF = true;
					}
					_lastChar = c;
				} while (isCRLF || (!IsNewLine(c) && !isCRLF));
			}
			catch(Exception err)
			{
                logger.Error(err);
			    throw;
			}
			return line.ToString();
		}

		private bool IsNewLine(char c)
		{
			return (c.Equals((char)13) || c.Equals((char)10));
		}

		private bool IsNewLine(int byteInt)
		{
			return (byteInt == 13 || byteInt == 10);
		}

		/// <summary>
		/// Determine if the next line is Boundary
		/// </summary>
		/// <param name="boundary"></param>
		/// <param name="boundaryPrefix"></param>
		/// <returns></returns>
		public bool IsNextLineBoundary(string boundary, string boundaryPrefix)
		{
			long cPosition = _stream.Position;
			bool IsBoundary = false;
			try
			{
				string sLine = ReadNexLine();
				if (MimeStreamReader.IsMimeBoundary(sLine, boundary, boundaryPrefix) || MimeStreamReader.IsMimeBoundaryLast(sLine, boundary, boundaryPrefix))
					IsBoundary = true;
			}
			catch(Exception err)
			{
				string msg = err.Message;
			}
			finally
			{
				_stream.Position = cPosition;
			}
			return IsBoundary;
		}

		/// <summary>
		/// Check for stream line for Mime Boundary
		/// </summary>
		/// <param name="streamLine"></param>
		/// <param name="boundary"></param>
		/// <param name="prefix"></param>
		/// <returns></returns>
		public static bool IsMimeBoundary(string streamLine, string boundary, string prefix)
		{
			if (streamLine == null || boundary == null || prefix == null)
				return false;
			return (streamLine.Trim().CompareTo(prefix + boundary) == 0);
		}

		/// <summary>
		/// Check for stream line for the last Mime Boundary
		/// </summary>
		/// <param name="streamLine"></param>
		/// <param name="boundary"></param>
		/// <param name="prefix"></param>
		/// <returns></returns>
		public static bool IsMimeBoundaryLast(string streamLine, string boundary, string prefix)
		{
			if (streamLine == null || boundary == null || prefix == null)
				return false;
			return (streamLine.Trim().CompareTo(prefix + boundary + prefix) == 0);
		}

		/// <summary>
		/// Read bytes of current stream
		/// </summary>
		/// <param name="boundary"></param>
		/// <param name="boundaryPrefix"></param>
		/// <returns></returns>
		public byte [] ReadBytes(string boundary, string boundaryPrefix)
		{
			byte [] buffer = null;
			if (_stream.CanSeek)
			{
				int initialLength = 32768;
				buffer = new byte [initialLength];

				bool endReading = false;
				long read = 0;
				try
				{
					//read byte line by line
					do
					{

						//Check in the next line is 
						if (IsNextLineBoundary(boundary, boundaryPrefix))
						{
							endReading = true;
						}
						else
						{
							int byteInt;
							bool newLine = false;

							do
							{
								//Read byte
								byteInt = _stream.ReadByte();

								//increase buffer size
								if (read == buffer.Length)
									buffer = GetBiggerBuffer(buffer);

								//Write byte
								if (!(read == 0 && IsNewLine(byteInt)))
								{
									buffer[read] = (byte)byteInt;
									read++;
								}

								//end of stream or end of file
								if (byteInt == -1)
								{
									newLine = true;
									endReading = true;
								}
									//New line
								else if (IsNewLine(byteInt))
								{
                                    newLine = true;
								}
							}while(!newLine);
						}
					} while (!endReading);
				}
				catch(Exception err)
				{
                    logger.Error(err);
				    throw;
				}
				finally
				{
					//Shrink buffer
					if (read > 0)
					{
						byte[] shrinkBuffer = new byte[read];
						Array.Copy(buffer, shrinkBuffer, read);
						buffer = shrinkBuffer;
					}
					else
					{
						buffer = null;
					}
				}
			}
			return buffer;
		}

		private byte [] GetBiggerBuffer(byte [] buffer)
		{
			byte[] newBuffer = new byte[buffer.Length*2];
			Array.Copy(buffer, newBuffer, buffer.Length);
			return newBuffer;
		}

		/// <summary>
		/// Position of current stream
		/// </summary>
		public long Position
		{
			get
			{
				return _stream.Position;
			}
		}

		/// <summary>
		/// Close current stream
		/// </summary>
		public void Close()
		{
			if (_stream != null)
				_stream.Close();
		}
	}
}
