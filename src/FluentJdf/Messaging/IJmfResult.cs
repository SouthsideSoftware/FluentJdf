using FluentJdf.Encoding;

namespace FluentJdf.Messaging
{
    /// <summary>
    /// The result of a JMF message transmission.
    /// </summary>
    public interface IJmfResult
    {
        /// <summary>
        /// The collection of parts associated with the response.
        /// The first member of the collection is the JMF response.
        /// </summary>
        ITransmissionPartCollection TransmissionPartCollection { get; }
        /// <summary>
        /// Gets the integer return code from the response.
        /// </summary>
        int RawReturnCode { get; }
        /// <summary>
        /// Gets the parsed return code.
        /// </summary>
        ReturnCode ReturnCode { get; }
        /// <summary>
        /// Gets true if the JMF response
        /// indicates success.
        /// </summary>
        bool IsSuccess { get; }
    }
}
