using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using FluentJdf.Configuration;
using FluentJdf.Encoding;
using FluentJdf.Messaging;
using FluentJdf.Resources;
using FluentJdf.Transmission.Logging;
using Infrastructure.Core;
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
        readonly ITransmissionLogger transmissionLogger;

        readonly IEncodingFactory encodingfactory;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="encodingfactory"></param>
        /// <param name="httpWebRequestFactory"></param>
        /// <param name="transmissionLogger"></param>
        public HttpTransmitter(IEncodingFactory encodingfactory, IHttpWebRequestFactory httpWebRequestFactory, ITransmissionLogger transmissionLogger) {
            ParameterCheck.ParameterRequired(encodingfactory, "encodingfactory");
            ParameterCheck.ParameterRequired(httpWebRequestFactory, "httpWebRequestFactory");
            ParameterCheck.ParameterRequired(transmissionLogger, "transmissionLogger");

            this.encodingfactory = encodingfactory;
            this.httpWebRequestFactory = httpWebRequestFactory;
            this.transmissionLogger = transmissionLogger;
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
                var encodingResult = encodingfactory.GetEncodingForTransmissionParts(partsToSend).Encode(partsToSend);
                transmissionLogger.Log(new TransmissionData(encodingResult.Stream, encodingResult.ContentType, "Request"));

                var request = httpWebRequestFactory.Create(uri, encodingResult.ContentType);
                using (var outStream = request.GetRequestStream()) {
                    encodingResult.Stream.CopyTo(outStream);
                }

                var response = (HttpWebResponse) request.GetResponse();
                try {
                    var contentType = GetContentTypeOfResponse(response);

                    var responseStream = new TempFileStream();
                    response.GetResponseStream().CopyTo(responseStream);
                    transmissionLogger.Log(new TransmissionData(responseStream, contentType, "Response"));

                    var responseParts = encodingfactory.GetEncodingForMimeType(contentType).Decode("httpContent", responseStream,
                                                                                                   contentType);
                    return new JmfResult(responseParts);
                } finally {
                    response.Close();
                }
            } catch (Exception err) {
                logger.Error(string.Format(Messages.HttpTransmitter_Transmit_HttpTransmitter_UnexpectedException, uri), err);
                throw;
            }
        }

        string GetContentTypeOfResponse(HttpWebResponse response) {
            var contentType = response.ContentType.ToLower();
            string[] contentElements = contentType.Split(';');
            if (contentElements.Length > 1)
            {
                contentType = contentElements[0];
            }

            return contentType;
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
