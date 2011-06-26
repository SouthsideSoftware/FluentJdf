using System;
using System.Collections.Generic;
using System.Linq;
using FluentJdf.Encoding;
using Infrastructure.Core.CodeContracts;
using FluentJdf.LinqToJdf;

namespace FluentJdf.Messaging {
    //todo: extend to support multiple responses in one JMF
    /// <summary>
    /// The result of a JMF message.
    /// </summary>
    public class JmfResult : IJmfResult {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="transmissionPartCollection"></param>
        public JmfResult(ITransmissionPartCollection transmissionPartCollection) {
            ParameterCheck.ParameterRequired(transmissionPartCollection, "transmissionPartCollection");
            Notifications = new List<Notification>();

            ReturnCode = ReturnCode.Unknown;
            RawReturnCode = (int) ReturnCode;
            TransmissionPartCollection = transmissionPartCollection;
            if (transmissionPartCollection.Count > 0) {
                var transmissionPart = transmissionPartCollection.First();
                if (transmissionPart is XmlTransmissionPart && (transmissionPart as XmlTransmissionPart).XmlType == XmlType.Jmf) {
                    var jmf = new Message((transmissionPart as XmlTransmissionPart).Document);
                    if (!jmf.HasBeenValidatedAtLeastOnce) {
                        jmf.ValidateJmf();
                    }
                    var responseElement = jmf.JdfXPathSelectElement("//Response");
                    if (responseElement != null) {
                        var returnCode = responseElement.GetAttributeValueAsIntOrNull("ReturnCode");
                        if (returnCode != null) {
                            RawReturnCode = returnCode.Value;
                            Messaging.ReturnCode outReturnCode;
                            if (Enum.TryParse(responseElement.GetAttributeValueOrNull("ReturnCode"), true, out outReturnCode)) {
                                ReturnCode = outReturnCode;
                            }
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Gets the list of notifications if any.
        /// </summary>
        public IList<Notification> Notifications { get; private set; }
        /// <summary>
        /// The collection of parts associated with the response.
        /// The first member of the collection is the JMF response.
        /// </summary>
        public ITransmissionPartCollection TransmissionPartCollection { get; private set; }

        /// <summary>
        /// Gets the integer return code from the response.
        /// </summary>
        public int RawReturnCode { get; private set; }

        /// <summary>
        /// Gets the parsed return code.
        /// </summary>
        public ReturnCode ReturnCode { get; private set; }

        /// <summary>
        /// Gets true if the JMF response
        /// indicates success.
        /// </summary>
        public bool IsSuccess {
            get { return ReturnCode == ReturnCode.Success; }
        }
    }
}