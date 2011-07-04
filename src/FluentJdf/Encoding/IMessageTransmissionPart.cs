using FluentJdf.LinqToJdf;

namespace FluentJdf.Encoding {
    /// <summary>
    /// A transmission part that contains a JMF message
    /// </summary>
    public interface IMessageTransmissionPart : ITransmissionPart
    {
        /// <summary>
        /// Gets the message for the transmission part.
        /// </summary>
        Message Message { get; }
    }
}