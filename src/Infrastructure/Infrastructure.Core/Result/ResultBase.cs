namespace Infrastructure.Core.Result
{
    /// <summary>
    /// A collection of ResultItemBase items
    /// </summary>
    public class ResultBase: ResultItemCollection<ResultItemBase>
    {
        /// <summary>
        /// Helper method to create a ResultBase containing one message.
        /// </summary>
        /// <param name="resultCode"></param>
        /// <param name="messageText"></param>
        /// <returns></returns>
        public static ResultBase WithMessage(ResultCode resultCode, string messageText)
        {
            var resultBase = new ResultBase();
            resultBase.AddMessage(new ResultItemBase(resultCode, messageText));
            return resultBase;
        }

        /// <summary>
        /// Adds a message with a given result code.
        /// </summary>
        /// <param name="resultCode">The result code.</param>
        /// <param name="message">The message.</param>
        public void AddMessage(ResultCode resultCode, string message)
        {
            AddMessage(new ResultItemBase(resultCode, message));
        }

        /// <summary>
        /// Add a message with format like string.Format.
        /// </summary>
        /// <param name="resultCode">The result code.</param>
        /// <param name="message">The message optionally including format specifiers.</param>
        /// <param name="parms">Additional parameters used to fill in the format specifiers.</param>
        public void AddMessageFormat(ResultCode resultCode, string message, params object[] parms)
        {
            if (parms == null || parms.Length == 0)
            {
                AddMessage(resultCode, message);
            }
            else
            {
                AddMessage(resultCode, string.Format(message, parms));
            }
        }
    }
}
