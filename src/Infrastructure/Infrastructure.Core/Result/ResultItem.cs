using System;
using Infrastructure.Core.CodeContracts;

namespace Infrastructure.Core.Result
{
    /// <summary>
    /// Simple result item of result code and message
    /// </summary>
    [Serializable]
    public class ResultItem : IEquatable<ResultItem>
    {
        /// <summary>
        /// Create a new result item.
        /// </summary>
        /// <param name="resultCode">The result code.</param>
        /// <param name="message">The message.</param>
        public ResultItem(ResultCode resultCode, string message)
        {
            ParameterCheck.StringRequiredAndNotWhitespace(message, "message");

            ResultCode = resultCode;
            Message = message;
        }

        /// <summary>
        /// The result code associated with this message
        /// </summary>
        public ResultCode ResultCode { get; private set; }

        /// <summary>
        /// The message text.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// The type of the result item.
        /// </summary>
        public ResultItemType Type
        {
            get
            {
                return ResultCode < 0 ? ResultItemType.Error : ResultItemType.Warning;
            }
        }

        /// <summary>
        /// Equality checking for IEquatable implementation (LINQ friendly).
        /// </summary>
        /// <param name="other">The ResultItem to compare to this instance.</param>
        /// <returns>True if the members of this instance have the same values as the member of the other instance.</returns>
        public virtual bool Equals(ResultItem other)
        {
            if (other == null) return false;
            return other.ResultCode == ResultCode && other.Message == Message && Type == other.Type;
        }

        /// <summary>
        /// Check equality with another object
        /// </summary>
        /// <param name="obj">The object to check</param>
        /// <returns>True is the given object is a ResultItemBase and has the same member values
        /// as this instance.</returns>
        public override bool Equals(object obj)
        {
            if (obj is ResultItem) return Equals(obj as ResultItem);
            return base.Equals(obj);
        }

        /// <summary>
        /// Gets the hash code. 
        /// </summary>
        public override int GetHashCode()
        {
            return ResultCode.GetHashCode() ^ Message.GetHashCode();
        }

        /// <summary>
        /// Overrides the standard ToString() implementation
        /// </summary>
        /// <returns>A string with [result code] - [message].</returns>
        public override string ToString()
        {
            return string.Format("{0} - {1}", (int)ResultCode, Message);
        }
    }
}
