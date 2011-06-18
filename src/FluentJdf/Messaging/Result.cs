using FluentJdf.Encoding;
using FluentJdf.Messaging;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Utility {
    /// <summary>
    /// The result of a JMF message.
    /// </summary>
    public class Result : IResult {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="transmissionPartCollection"></param>
        public Result(ITransmissionPartCollection transmissionPartCollection) {
            ParameterCheck.ParameterRequired(transmissionPartCollection, "transmissionPartCollection");

            TransmissionPartCollection = transmissionPartCollection;
            //todo: get raw return code and populate return code
        }

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