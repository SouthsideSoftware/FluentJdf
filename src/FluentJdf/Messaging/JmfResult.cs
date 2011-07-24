using System.Collections.Generic;
using System.Linq;
using FluentJdf.Encoding;
using FluentJdf.LinqToJdf;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Messaging {
    //todo: extend to support multiple responses in one JMF
    /// <summary>
    /// The result of a JMF message.
    /// </summary>
    public class JmfResult : IJmfResult {

        /// <summary>
        /// Creates an empty success result
        /// </summary>
        public JmfResult() {
            Details = new List<IJmfResultDetail>();
            TransmissionPartCollection = new TransmissionPartCollection();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="transmissionPartCollection"></param>
        public JmfResult(ITransmissionPartCollection transmissionPartCollection) {
            ParameterCheck.ParameterRequired(transmissionPartCollection, "transmissionPartCollection");
            TransmissionPartCollection = transmissionPartCollection;

            Details = new List<IJmfResultDetail>();

            if (transmissionPartCollection.HasMessage) {
                Message jmf = transmissionPartCollection.Message;
                if (!jmf.HasBeenValidatedAtLeastOnce) {
                    jmf.Root.ValidateJmf();
                }

                var responseElements = jmf.JdfXPathSelectElements("//Response");
                foreach (var responseElement in responseElements) {
                    Details.Add(new JmfResultDetail(responseElement));
                }
            }
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
        /// Gets true if the JMF response
        /// indicates success.
        /// </summary>
        public bool IsSuccess {
            get {
                return Details.Count > 0 && (from detail in Details
                                             where detail.ReturnCode != ReturnCode.Success
                                             select detail).Count() == 0;
            }
        }

        #endregion
    }
}