using System.Text;
using Infrastructure.Core.Logging;
using Infrastructure.Core.Resources;

namespace Infrastructure.Core.Mime
{
	/// <summary>
	/// Represents a mime header in the form name:value.  Names are lower-cased 
	/// so lookups and usage of names is case-insensitive.
	/// </summary>
	/// <remarks>Per the RFC, comments in the value are stripped during parsing.</remarks>
	public class MimeHeader : MimeHeaderBase
	{
		private MimeHeaderParamCollection _parameters = new MimeHeaderParamCollection();
	    static ILog logger = LogManager.GetLogger(typeof (MimeHeaderBase));

		/// <summary>
		/// Construct a mime header from a line.  
		/// </summary>
		/// <param name="line">The line in name:value form.  The line does not include a crlf pair.</param>
		public MimeHeader(string line) : base(line)
		{
		}

		/// <summary>
		/// Constructs a mime header from a name and value.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="val">The value.</param>
		public MimeHeader(string name, string val) :
			base(name, val)
		{
		}

		/// <summary>
		/// Parse a line in the form name: value
		/// </summary>
		/// <param name="line">The line to parse.</param>
		/// <param name="name">(out) the name.</param>
		/// <param name="val">(out) the value.</param>
		/// <exception cref="MimeException">If the header param is not in the expected format.</exception>
		public override void ParseLine(string line, out string name, out string val)
		{
			string [] parts = line.Trim().Split(':');
			if (parts.Length < 2) {
			    var err = new MimeException(string.Format(Messages.MimeHeader_ParseLine_HeaderIsNotInCorrectForm, line));
                logger.Error(err);
			    throw err;
			}
			name = parts[0].Trim();
			//Attempt to parse
			if (parts.Length > 2)
			{
				parts = new string[2];
				parts[0] = name;
				int firstColon = line.IndexOf(":");
                parts[1] = line.Substring(firstColon + 1, line.Length - (firstColon + 1));
			}

			string [] valParts = parts[1].Split(';');
			if (valParts.Length > 1)
			{
				val = valParts[0];

				for (int parmIndex = 1; parmIndex < valParts.Length; parmIndex++)
				{
					_parameters.Add(new MimeHeaderParam(valParts[parmIndex]));
				}
			} 
			else 
			{
				val = parts[1];
			}
		}

		/// <summary>
		/// Gets the collection of parameters associated with this header.
		/// </summary>
		public MimeHeaderParamCollection Parameters
		{
			get
			{
				return _parameters;
			}
		}

		/// <summary>
		/// Return a header string in the form name:value. 
		/// </summary>
		/// <returns>The unterminated header string.</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(Name);
			sb.Append(": ");
			sb.Append(Value);
			sb.Append(_parameters.ToString());
			return sb.ToString();
		}
	}
}