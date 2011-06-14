using System;
using System.Text;
using System.Text.RegularExpressions;
using Infrastructure.Core.Logging;

namespace Infrastructure.Core.Mime
{
	/// <summary>
	/// Represents a parameter as defined in the RFC for content-type 
	/// header parameters.  That is, a name=value pair where the
	/// value may be enclosed in double quotes.
	/// </summary>
	/// <remarks>
	/// Per the RFC, text enclosed in parenthesis is treated as a comment
	/// and is ignored and stripped from the header value.
	/// </remarks>
	public class MimeHeaderParam : MimeHeaderBase {
	    static ILog logger = LogManager.GetLogger(typeof (MimeHeaderParam));
		private int _section = -1;
		private string _charset = "";
		private string _language = "";

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="val">The value.</param>
		public MimeHeaderParam(string name, string val) :
			base(name, val)
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="line">A line in the form name=value.</param>
		public MimeHeaderParam(string line) :
			base(line)
		{
		}

		/// <summary>
		/// Parse a line in the form name = value
		/// </summary>
		/// <param name="line">The line to parse.</param>
		/// <param name="name">(out) the name.</param>
		/// <param name="val">(out) the value.</param>
		/// <exception cref="MimeException">If the header param is not in the expected format.</exception>
		public override void ParseLine(string line, out string name, out string val)
		{
			line = line.Trim();
			if (line.IndexOf("=") == -1 ) {
			    var err = new MimeException(string.Format("Header Parameter is not in the expected name=value form.  The raw data is {0}", line));
                logger.Error(err);
			    throw err;
			}

			//Note handle
			//if val is in the encoded form such as "SeparationTestDoublePage%E2%82%AC_1.pdf"
			Regex r;
			Match m;
			name = "";
			val = "";

			//support RFC2231 standard
			/*
			an asterisk at the end of a parameter name acts as an
			indicator that character set and language information may appear at
			the beginning of the parameter value. A single quote is used to
			separate the character set, language, and actual value information in
			the parameter value string, and an percent sign is used to flag
			octets encoded in hexadecimal.  For example:

				Content-Type: application/x-stuff
				title*0*=us-ascii'en'This%20is%20even%20more%20
				title*1*=%2A%2A%2Afun%2A%2A%2A%20
				title*2="isn't it!"
			*/

			//TODO: RFC2231 supports the parameter continuation mechanism
			//We don't implement this mechanism yet.
			//We only read it in and write it out.

			//For example, filename*=<charset>'<language>'percentencodedstring --> take the percentencodedstring, decode the %xx and use this as filename; 
			//don't care about <language> (could be empty), <charset> could be utf-8 or us-ascii 
			r = new Regex(@"^(?<name>.+)(\*(?<index>\d+))?\*=(?<charset>.*)'(?<language>.*)'(?<value>.*)");
			m = r.Match(line);
			if (m.Success)
			{
				name = m.Groups["name"].Value;
				if (m.Groups["index"] != null && m.Groups["index"].Value.Length > 0)
                    _section = Convert.ToInt32(m.Groups["index"].Value);
				_charset = m.Groups["charset"].Value.ToLower();
				_language = m.Groups["language"].Value.ToLower();
				//Check if the charset is present
				//support only utf-8 or us-ascii at this time
				if (_charset.Length > 0 && (_charset.Equals("utf-8") || _charset.Equals("utf-7") || _charset.Equals("us-ascii")))
				{
					val = System.Web.HttpUtility.UrlDecode(m.Groups["value"].Value, 
						(_charset.Equals("utf-8"))?System.Text.Encoding.UTF8:((_charset.Equals("utf-8"))?System.Text.Encoding.UTF8:System.Text.Encoding.ASCII));
				}
				else
				{
					val = m.Groups["value"].Value;
				}
			}
			else
			{
				//filename=string    (string not between double quotes)  --> just take this string for the filename 
				int splitPos;
				int lineLength = line.Length;
				splitPos = line.IndexOf("=");
				if (splitPos > 0)
				{
					name = line.Substring(0, splitPos);
					val = line.Substring(splitPos + 1);
				}

				//Refer to RFC2822 for quoted-string
				//filename="quotestring"  --> take the quotestring and replace any \CHAR by CHAR, use this for the filename 
				//TODO: Resolve the issue.  If \" is present in the string, we can read ".  However, later on in the code, Regex _findParen in MimeHeaderBase takes out the "
				if (val.Length >= 2 && val.StartsWith("\"") && val.EndsWith("\""))
				{
					val = val.Substring(1, val.Length - 2);
					//Check for \CHAR
					int bslashPos;
					int startingIndex = 0;
					do
					{
						bslashPos = val.IndexOf("\\", startingIndex);
						if (bslashPos >= 0)
						{
							//take out the \
							val = val.Substring(0, bslashPos) + val.Substring(bslashPos + 1, val.Length - (bslashPos + 1));
							startingIndex = bslashPos + 1;
						}
					}while(bslashPos >= 0 && startingIndex < val.Length);
				}
			}
		}

		/// <summary>
		/// Return a header string in the form name:value. 
		/// </summary>
		/// <returns>The unterminated header string.</returns>
		public override string ToString()
		{
			//Check in the value is a non-us-ascii string.
			byte [] bytes = System.Text.Encoding.ASCII.GetBytes(Value);
			string str = System.Text.Encoding.ASCII.GetString(bytes);
			//this is a non-us-ascii string
			if (!str.Equals(Value))
			{
				_charset = "utf-8";
			}

			StringBuilder sb = new StringBuilder();
			sb.Append(Name);
			if (_section >= 0)
			{
				sb.Append("*" + _section.ToString());
			}

			//If _charset is present, the parameter is in RFC2231 standard
			if (_charset.Length > 0 && (_charset.Equals("utf-8") || _charset.Equals("utf-7") || _charset.Equals("us-ascii")))
			{
				sb.Append("*=");
				sb.Append(_charset);
				sb.Append("'");
				sb.Append(_language);
				sb.Append("'");
				sb.Append(System.Web.HttpUtility.UrlEncode(Value,
					(_charset.Equals("utf-8"))?System.Text.Encoding.UTF8:((_charset.Equals("utf-8"))?System.Text.Encoding.UTF7:System.Text.Encoding.ASCII)));
			}
			else
			{
				string val = Value;
				bool hasBackSlash = (val.IndexOf(@"\") >= 0);
				bool hasPercent = (val.IndexOf(@"%") >= 0);

				sb.Append("=\"");
				//Refer to RFC2822 for quoted-string
				//filename="quotestring"  --> take the quotestring and replace \ by \\ and " by \", use this for the filename 
				if (hasBackSlash)
					val = val.Replace("\\", "\\\\");
				if (hasBackSlash)
					val = val.Replace("\"", "\\\"");
				sb.Append(val);
				sb.Append("\"");
			}
			return sb.ToString();
		}
	}
}
