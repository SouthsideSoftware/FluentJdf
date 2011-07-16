using System;
using System.Net;
using FluentJdf.Configuration;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Transmission {
    /// <summary>
    /// Factory used to create <see cref="HttpWebRequest"/> objects.
    /// </summary>
    public class HttpWebRequestFactory : IHttpWebRequestFactory {

        HttpTransmissionSettings settings = null;

        /// <summary>
        /// Create a new HttpWebRequestFactory
        /// </summary>
        /// <param name="settings"></param>
        public HttpWebRequestFactory(HttpTransmissionSettings settings) {
            ParameterCheck.ParameterRequired(settings, "settings");
            this.settings = settings;
        }

        /// <summary>
        /// Create a web request.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public HttpWebRequest Create(Uri uri, string contentType) {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);

            if (settings.HasProxySettings) {
                NetworkCredential credentials = null;
                if (settings.HasProxyCredentials) {
                    if (!string.IsNullOrWhiteSpace(settings.ProxyDomain)) {
                        credentials = new NetworkCredential(settings.ProxyUserName, settings.ProxyPassword, settings.ProxyDomain);
                    }
                    else {
                        credentials = new NetworkCredential(settings.ProxyUserName, settings.ProxyPassword);
                    }
                }

                WebProxy proxy = null;
                if (credentials != null) {
                    proxy = new WebProxy(settings.ProxyUrl, settings.BypassProxyOnLocal, null, credentials);
                }
                else {
                    proxy = new WebProxy(settings.ProxyUrl, settings.BypassProxyOnLocal);
                }
                request.Proxy = proxy;
            }
            request.Timeout = settings.TimeoutInSeconds * 1000;
            if (contentType != null && contentType.IndexOf(";") > 0) {
                request.ContentType = contentType.Substring(0, contentType.IndexOf(";"));
            }
            else {
                request.ContentType = contentType;
            }
            request.Method = "POST";

            return request;
        }
    }
}