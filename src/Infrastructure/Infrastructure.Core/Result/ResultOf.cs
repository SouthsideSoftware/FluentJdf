using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace Infrastructure.Core.Result
{
    /// <summary>
    /// Generic wrapper to include a collection of result items with any return type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResultItem"></typeparam>
    [Serializable]
    public class ResultOf<T, TResultItem> : ResultItemCollection<TResultItem>
        where T : class
        where TResultItem : ResultItem
    {
        /// <summary>
        /// The wrapped value.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Indicate if the wrapped value is present.
        /// </summary>
        public bool HasValue { get { return Value != null; } }

        /// <summary>
        /// Create an empty wrapper.
        /// </summary>
        public ResultOf()
        {
            Value = null;
        }

        /// <summary>
        /// Create a wrapper with a value.
        /// </summary>
        /// <param name="value"></param>
        public ResultOf(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Create a wrapper from a result item collection
        /// </summary>
        /// <param name="messages"></param>
        public ResultOf(ResultItemCollection<TResultItem> messages)
        {
            ParameterCheck.ParameterRequired(messages, "messages");
            Value = null;
            AppendResult(messages);
        }

        /// <summary>
        /// Create a wrapper from a set of result items
        /// </summary>
        /// <param name="messages"></param>
        public ResultOf(IEnumerable<TResultItem> messages)
        {
            ParameterCheck.ParameterRequired(messages, "messages");
            Value = null;
            AddMessages(messages);
        }

        /// <summary>
        /// Create a wrapper from a single result item
        /// </summary>
        /// <param name="resultItem"></param>
        public ResultOf(TResultItem resultItem)
        {
            ParameterCheck.ParameterRequired(resultItem, "resultItem");
            Value = null;
            AddMessage(resultItem);
        }

        /// <summary>
        /// Create a wrapper with a value and  a collection of result items.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="resultItems"></param>
        public ResultOf(T value, ResultItemCollection<TResultItem> resultItems)
        {
            ParameterCheck.ParameterRequired(resultItems, "resultItems");
            Value = value;
            AppendResult(resultItems);
        }

        /// <summary>
        /// Convert the wrapper to a more-specific type
        /// </summary>
        /// <returns></returns>
        public ResultOf<T> ToResultOf()
        {
            var resultBase = new ResultBase();
            foreach (var item in Messages)
            {
                resultBase.AddMessage(item.ResultCode, item.Message);
            }
            return new ResultOf<T>(Value, resultBase);
        }

        /// <summary>
        /// Gets a string representation of this result.  Includes
        /// a string representation of the value if the value is
        /// non-null.
        /// </summary>
        public override string ToString()
        {
            return string.Format("Value: {0} Result: {1}", HasValue ? Value.ToString() : "NULL", base.ToString());
        }
    }

    /// <summary>
    /// Generic wrapper to include a collection of ResultItemBase with any return type.
    /// </summary>
    /// <typeparam name="T">The return type being wrapped.</typeparam>
    public class ResultOf<T>: ResultOf<T, ResultItemBase> where T: class
    {
        /// <summary>
        /// Cast to a ResultBase
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static implicit operator ResultBase(ResultOf<T> source)
        {
            var result = new ResultBase();
            result.AppendResult(source);
            return result;
        }

        /// <summary>
        /// Create an empty wrapper.
        /// </summary>
        public ResultOf() {}

        /// <summary>
        /// Create a wrapper with a value.
        /// </summary>
        /// <param name="value"></param>
        public ResultOf(T value): base(value) {}

        /// <summary>
        /// Create a wrapper with results.
        /// </summary>
        /// <param name="result"></param>
        public ResultOf(ResultItemCollection<ResultItemBase> result): base(result.Messages) {}

        /// <summary>
        /// Create a wrapper with an exception result.
        /// </summary>
        /// <param name="exception"></param>
        public ResultOf(Exception exception)
            : this(new ResultItemBase(ResultCode.UnexpectedException, exception.ToString())) {}

        /// <summary>
        /// Create a wrapper with a result item
        /// </summary>
        /// <param name="resultItem"></param>
        public ResultOf(ResultItemBase resultItem): base(resultItem) {}

        /// <summary>
        /// Create a wrapper with a result item
        /// </summary>
        public ResultOf(ResultCode resultCode, string message, XElement element = null)
            : base(new ResultItemBase(resultCode, message, element)) {}

        /// <summary>
        /// Create a wrapper with a value and results.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        public ResultOf(T value, ResultItemCollection<ResultItemBase> result): base(value, result) {}

        /// <summary>
        /// Append additional results to the ResultBase.
        /// </summary>
        /// <param name="otherResults"></param>
        /// <returns></returns>
        public ResultOf<T> Append(ResultBase otherResults)
        {
            ParameterCheck.ParameterRequired(otherResults, "otherResults");
            AppendResult(otherResults);
            return this;
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
    }
}
