using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using FluentJdf.Configuration;
using FluentJdf.Encoding;
using FluentJdf.Messaging;
using FluentJdf.Resources;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Logging;

namespace FluentJdf.Transmission
{
    /// <summary>
    /// Transmit JDF over HTTP and collect a response.
    /// </summary>
    public class HttpTransmitter : ITransmitter {
        static ILog logger = LogManager.GetLogger(typeof (HttpTransmitter));
        IHttpWebRequestFactory httpWebRequestFactory;

        readonly IEncodingFactory encodingfactory;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="encodingfactory"></param>
        /// <param name="httpWebRequestFactory"></param>
        public HttpTransmitter(IEncodingFactory encodingfactory, IHttpWebRequestFactory httpWebRequestFactory) {
            ParameterCheck.ParameterRequired(encodingfactory, "encodingfactory");
            ParameterCheck.ParameterRequired(httpWebRequestFactory, "httpWebRequestFactory");

            this.encodingfactory = encodingfactory;
            this.httpWebRequestFactory = httpWebRequestFactory;
        }

        /// <summary>
        /// Transmit data to the given URI.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="partsToSend"></param>
        /// <returns>A result that includes parsed JMF results if available.</returns>
        public IJmfResult Transmit(Uri uri, ITransmissionPartCollection partsToSend) {
            ParameterCheck.ParameterRequired(uri, "uri");
            ParameterCheck.ParameterRequired(partsToSend, "partsToSend");
            if (partsToSend.Count == 0) {
                throw new PreconditionException(Messages.HttpTransmitter_Transmit_AtLeastOneTransmissionPartIsRequired);
            }
            if (uri.IsFile || uri.Scheme.ToLower() != "http") {
                throw new PreconditionException(Messages.HttpTransmitter_Transmit_RequiresHttpUrl);
            }

            try {
                var encodingResult = encodingfactory.GetEncodingForTransmissionParts(partsToSend);
            } catch (Exception err) {
                logger.Error(string.Format(Messages.HttpTransmitter_Transmit_HttpTransmitter_UnexpectedException, uri), err);
                throw;
            }

            //todo: finish implementation
            return null;
        }

        /// <summary>
        /// Transmit data to the given uri (string).
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="partsToSend"></param>
        /// <returns>A result that includes parsed JMF results if available.</returns>
        public IJmfResult Transmit(string uri, ITransmissionPartCollection partsToSend) {
            ParameterCheck.StringRequiredAndNotWhitespace(uri, "uri");

            return Transmit(new Uri(uri), partsToSend);
        }
    }
}
