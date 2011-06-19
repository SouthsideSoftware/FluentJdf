using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace FluentJdf.Configuration
{
    /// <summary>
    /// Settings for the HTTP 
    /// </summary>
    public class HttpTransmissionSettings
    {
        /// <summary>
        /// Reset to default settings.
        /// </summary>
        /// <returns></returns>
        public HttpTransmissionSettings ResetToDefaults() {
            TimeoutInSeconds = 100;
            ProxyUrl = null;
            ProxyUserName = null;
            ProxyPassword = null;
            ProxyDomain = null;
            BypassProxyOnLocal = true;
            return this;
        }

        /// <summary>
        /// Gets the timeout in seconds.
        /// </summary>
        public int TimeoutInSeconds { get; internal set; }

        /// <summary>
        /// Gets the proxy url.  If not defined, falls back to default proxy
        /// settings as defined in the defaultProxy element of the app.config file.  If 
        /// defaultProxy is not defined, falls back to the proxy settings as configured
        /// in IE. 
        /// </summary>
        /// <remarks>ProxyUrl must be non-null for any of the other proxy settings
        /// to be used.</remarks>
        public string ProxyUrl { get; internal set; }

        /// <summary>
        /// Gets the user name for the proxy.
        /// </summary>
        public string ProxyUserName { get; internal set; }

        /// <summary>
        /// Gets the password for the proxy.
        /// </summary>
        public string ProxyPassword { get; internal set; }

        /// <summary>
        /// Gets the domain for the proxy.
        /// </summary>
        public string ProxyDomain { get; internal set; }

        /// <summary>
        /// Gets a flag that indicates whether the proxy should
        /// be bypassed for local requests.
        /// </summary>
        public bool BypassProxyOnLocal { get; internal set; }
    }
}
