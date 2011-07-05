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

        /// <summary>
        /// Initialize the properties.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        void InitalizeProperties(Message message, string name, string id);
    }
}