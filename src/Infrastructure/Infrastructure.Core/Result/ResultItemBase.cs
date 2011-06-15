using System;
using System.Xml.Linq;

namespace Infrastructure.Core.Result
{
    /// <summary>
    /// A result item with an associated XML element
    /// </summary>
    public class ResultItemBase: ResultItem, IEquatable<ResultItemBase>
    {
        /// <summary>
        /// The associated XML element.
        /// </summary>
        public XElement Element { get; private set; }

        /// <summary>
        /// Gets the C data.
        /// </summary>
        public XCData CData { get; private set; }

        /// <summary>
        /// Create a new ResultItemBase
        /// </summary>
        /// <param name="resultCode"></param>
        /// <param name="message"></param>
        /// <param name="element"></param>
        public ResultItemBase(ResultCode resultCode, string message, XElement element = null)
            : base(resultCode, message)
        {
            Element = element;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultItemBase"/> class.
        /// </summary>
        /// <param name="resultCode">The result code.</param>
        /// <param name="message">The message.</param>
        /// <param name="cdata">The cdata.</param>
        /// <param name="element">The element.</param>
        public ResultItemBase(ResultCode resultCode, string message, XCData cdata, XElement element = null)
            : base(resultCode, message)
        {
            Element = element;
            CData = cdata;
        }

        /// <summary>
        /// Equality checking for IEquatable implementation (LINQ friendly).
        /// </summary>
        /// <param name="other">The ResultItemBase to compare to this instance.</param>
        /// <returns>True if the members of this instance have the same values as the member of the other instance.</returns>
        public bool Equals(ResultItemBase other)
        {
            if (other == null) return false;
            return other.Element == Element && Equals(other as ResultItem);
        }

        /// <summary>
        /// Check equality with another object
        /// </summary>
        /// <param name="obj">The object to check</param>
        /// <returns>True is the given object is a ResultItemBase and has the same member values
        /// as this instance.</returns>
        public override bool Equals(object obj)
        {
            if (obj is ResultItemBase) return Equals(obj as ResultItemBase);
            return base.Equals(obj);
        }

        /// <summary>
        /// Gets the hash code. 
        /// </summary>
        public override int GetHashCode()
        {
            return ResultCode.GetHashCode() ^ Message.GetHashCode();
        }
    }

}
