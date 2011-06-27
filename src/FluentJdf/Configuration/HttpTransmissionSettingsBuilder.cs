using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using FluentJdf.Resources;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Configuration
{
    /// <summary>
    /// Builds settings for HTTP transmission.
    /// </summary>
    public class HttpTransmissionSettingsBuilder {
        HttpTransmissionSettings httpTransmissionSettings;
        FluentJdfLibrary fluentJdfLibrary;

        internal HttpTransmissionSettingsBuilder(FluentJdfLibrary fluentJdfLibrary, HttpTransmissionSettings httpTransmissionSettings) {
            ParameterCheck.ParameterRequired(fluentJdfLibrary, "FluentJdfLibrary");
            ParameterCheck.ParameterRequired(httpTransmissionSettings, "httpTransmissionSettings");

            this.fluentJdfLibrary = fluentJdfLibrary;
            this.httpTransmissionSettings = httpTransmissionSettings;
        }

        /// <summary>
        /// Gets the owning FluentJdfLibrary settings.
        /// </summary>
        public FluentJdfLibrary Settings { get { return fluentJdfLibrary; } }

        /// <summary>
        /// Sets the timeout in seconds.
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        /// <exception cref="PreconditionException">If the timeout given is less than zero and not Timeout.Infinite.</exception>
        public HttpTransmissionSettingsBuilder TimeoutInSeconds(int seconds) {
            if (seconds < 0 && seconds != Timeout.Infinite) {
                throw new PreconditionException(Messages.HttpTransmissionSettingsBuilder_TimeoutInSeconds_MustNotBeLessThanZero);
            }

            httpTransmissionSettings.TimeoutInSeconds = seconds;
            return this;
        }


        /// <summary>
        /// Use the default proxy as defined in app.config or IE.
        /// </summary>
        /// <returns></returns>
        public HttpTransmissionSettingsBuilder UseDefaultProxy() {
            httpTransmissionSettings.ProxyUrl = null;
            httpTransmissionSettings.ProxyUserName = null;
            httpTransmissionSettings.ProxyPassword = null;
            httpTransmissionSettings.ProxyDomain = null;

            return this;
        }

        /// <summary>
        /// Use a specified proxy with optional credentials.
        /// </summary>
        /// <param name="proxyUrl"></param>
        /// <param name="bypassProxyOnLocal"></param>
        /// <param name="proxyUserName"></param>
        /// <param name="proxyPassword"></param>
        /// <param name="proxyDomain"></param>
        /// <returns></returns>
        public HttpTransmissionSettingsBuilder Proxy(string proxyUrl, bool bypassProxyOnLocal = true, string proxyUserName = null, string proxyPassword = null, string proxyDomain = null) {
            ParameterCheck.StringRequiredAndNotWhitespace(proxyUrl, "proxyUrl");

            httpTransmissionSettings.ProxyUrl = proxyUrl;
            httpTransmissionSettings.ProxyUserName = proxyUserName;
            httpTransmissionSettings.ProxyPassword = proxyPassword;
            httpTransmissionSettings.ProxyDomain = proxyDomain;
            httpTransmissionSettings.BypassProxyOnLocal = bypassProxyOnLocal;

            return this;
        }
    }
}
