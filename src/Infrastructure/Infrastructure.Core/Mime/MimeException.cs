using System;
using System.Runtime.Serialization;

namespace Infrastructure.Core.Mime
{
	/// <exception>
	/// An exception occured in the oai.mime library.
	/// </exception> 
	[Serializable]
	public class MimeException : Exception
	{	
		/// <summary>
		/// Constructor.
		/// </summary>
		public	MimeException()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="Message">The message.</param>
		public MimeException(string Message) : base(Message)
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="Message">The message.</param>
		/// <param name="Inner">The inner exception.</param>
		public MimeException(string Message, Exception Inner) : base(Message, Inner)
		{
		}
		
		/// <summary>
		/// For serialization.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected MimeException(SerializationInfo info,
			StreamingContext context) : base(info, context)
		{
		}
	}
}
