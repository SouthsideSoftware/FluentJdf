using System.Collections.Generic;
using System.Linq;
using FluentJdf.Encoding;
using FluentJdf.LinqToJdf;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Messaging {
    /// <summary>
    /// The result of a JMF message.
    /// </summary>
    public class FileTransmissionJmfResult : IJmfResult {

        /// <summary>
        /// Creates an empty success result
        /// </summary>
        public FileTransmissionJmfResult() {
            Details = new List<IJmfResultDetail>();
            TransmissionPartCollection = new TransmissionPartCollection();
        }

        /// <summary>
        /// Gets the details of this result.
        /// </summary>
        public IList<IJmfResultDetail> Details {
            get;
            private set;
        }

        #region IJmfResult Members

        /// <summary>
        /// The collection of parts associated with the response.
        /// The first member of the collection is the JMF response.
        /// </summary>
        public ITransmissionPartCollection TransmissionPartCollection {
            get;
            private set;
        }

        /// <summary>
        /// Gets true to
        /// indicate success.
        /// </summary>
        public bool IsSuccess {
            get {
                return true;
            }
        }

        #endregion
    }
}