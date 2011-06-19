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

namespace FluentJdf.Transmission
{
    /// <summary>
    /// Transmit JDF over HTTP and collect a response.
    /// </summary>
    public class HttpTransmitter : ITransmitter
    {
        readonly IEncodingFactory encodingfactory;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="encodingfactory"></param>
        public HttpTransmitter(IEncodingFactory encodingfactory) {
            ParameterCheck.ParameterRequired(encodingfactory, "encodingfactory");

            this.encodingfactory = encodingfactory;
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

            return null;

            //var encodingResult = encodingfactory.
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

        /// <summary>
        /// Initialize the web request
        /// </summary>
        /// <param name="uri">The request URL</param>
        /// <param name="contentType">The content type of the request.</param>
        /// <returns>The web request.</returns>
        protected HttpWebRequest InitializeWebRequest(Uri uri, string contentType)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            var settings = Library.Settings.HttpTransmissionSettings;
            if (settings.HasProxySettings)
            {
                NetworkCredential credentials = null;
                if (settings.HasProxyCredentials)
                {
                    if (!string.IsNullOrWhiteSpace(settings.ProxyDomain))
                    {
                        credentials = new NetworkCredential(settings.ProxyUserName, settings.ProxyPassword, settings.ProxyDomain);
                    }
                    else
                    {
                        credentials = new NetworkCredential(settings.ProxyUserName, settings.ProxyPassword);
                    }
                }

                WebProxy proxy = null;
                if (credentials != null)
                {
                    proxy = new WebProxy(settings.ProxyUrl, settings.BypassProxyOnLocal, null, credentials);
                }
                else
                {
                    proxy = new WebProxy(settings.ProxyUrl, settings.BypassProxyOnLocal);
                }
                request.Proxy = proxy;
            }
            request.Timeout = settings.TimeoutInSeconds*1000;
            if (contentType != null && contentType.IndexOf(";") > 0)
            {
                request.ContentType = contentType.Substring(0, contentType.IndexOf(";"));
            }
            else
            {
                request.ContentType = contentType;
            }
            request.Method = "POST";

            return request;
        }
    }
}
