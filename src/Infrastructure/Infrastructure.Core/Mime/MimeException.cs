using System;
using System.Reflection;
using System.Runtime.Serialization;
using Infrastructure.Core.Logging;
using Infrastructure.Core.Resources;

namespace Infrastructure.Core.Mime
{
	/// <exception>
	/// An exception occured in the oai.mime library.
	/// </exception> 
	[Serializable]
	public class MimeException : Exception {
	    static ILog logger = LogManager.GetLogger(typeof (MimeException));
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

        /// <summary>
        /// Log a new mime exception and then throw it.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="callingType"></param>
        public static void ThrowAndLog(string message, Type callingType) {
            var err = new MimeException(message);
            ILog logger = LogManager.GetLogger(callingType);
            logger.Error(err);
            throw err;
        }
	}
}
