using System.Collections.Generic;

namespace FluentJdf.Messaging {
    /// <summary>
    /// Details of a JMF result.
    /// </summary>
    public interface IJmfResultDetail {
        /// <summary>
        /// Gets the raw return code.
        /// </summary>
        int RawReturnCode { get; }

        /// <summary>
        /// Gets the return code.
        /// </summary>
        ReturnCode ReturnCode { get; }

        /// <summary>
        /// Gets the notifications if any.
        /// </summary>
        IList<Notification> Notifications { get; }

        /// <summary>
        /// Gets <see langword="true"/> on success.
        /// </summary>
        bool IsSuccess { get; }
    }
}