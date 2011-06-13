using System.Text.RegularExpressions;

namespace Infrastructure.Core.Mime
{
	/// <summary>
	/// Base class for MimeHeader and MimeHeaderParam.
	/// </summary>
	public abstract class MimeHeaderBase
	{
		private static Regex _findParen = new Regex(@"(\(.*\))|(\"")", RegexOptions.Compiled);
		private string _name;
		private string _value;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="val">The value.</param>
		public MimeHeaderBase(string name, string val)
		{	
			_name = name.Trim();
			SetValue(val);
		}

		/// <summary>
		/// A line containing the header.  The child classes's ParseLine
		/// function will determine how the line is parsed.
		/// </summary>
		/// <param name="line">A line containing header information.</param>
		public MimeHeaderBase(string line)
		{
			string name, val;
			ParseLine(line, out name, out val);
			SetValue(val);
			_name = name.Trim();
		}

		/// <summary>
		/// Gets the name.
		/// </summary>
		public string Name
		{
			get
			{
				return _name;
			}
		}

		/// <summary>
		/// Gets the value.
		/// </summary>
		public string Value
		{
			get
			{
				return _value;
			}
			set
			{
                _value = value;
			}
		}

		private void SetValue(string val)
		{
			_value = _findParen.Replace(val, "").Trim();
		}

		/// <summary>
		/// Parse a line.
		/// </summary>
		/// <param name="line">The line to parse.</param>
		/// <remarks>
		/// Override this in child classes.
		/// </remarks>
		/// <param name="name"></param>
		/// <param name="val"></param>
		public abstract void ParseLine(string line, out string name, out string val);
	}
}