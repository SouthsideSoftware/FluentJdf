using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using FluentJdf.LinqToJdf;

namespace FluentJdf.Transmission {

    //TODO rename TransmissionConfigurationItem to FileTransmissionConfigurationItem

    /// <summary>
    /// Configuration of a transmission scheme
    /// </summary>
    public class TransmissionConfigurationItem : JdpTypeHoldingConfigurationItem {
        private string _scheme;
        private string _proxyUrl = null;
        private string _proxyUserName = null;
        private string _proxyPassword = null;
        private string _proxyDomain = null;
        private bool _bypassProxyOnLocal = true;
        private OutboundMessageConfigurationItem _outbound;
        private FileTransmitterEncoderConfigurationCollection _fileTransmitterEncoderConfigurationCollection;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="scheme">The scheme (e.g. http).</param>
        /// <param name="type">The class and assembly of a Transmitter descendant.</param>
        public TransmissionConfigurationItem(string scheme, string type)
            : this(scheme, type, null, null, null, null, false, null) {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="scheme">The scheme (e.g. http).</param>
        /// <param name="type">The class and assembly of a Transmitter descendant.</param>
        /// <param name="proxyUrl">Optional proxy URL.</param>
        /// <param name="proxyUserName">Optional proxy user name.</param>
        /// <param name="proxyPassword">Optional proxy password.</param>
        /// <param name="proxyDomain">Optional proxy domain for user validation.</param>
        /// <param name="bypassProxyOnLocal">True to bypass configured proxy for LAN addresses.  Default is true.  Note that this should 
        /// only be set if proxyUrl is also specified.</param>
        /// <param name="fileTransmitterEncoderConfigurationCollection">A collection of file transmitter encoder configuration items.  May be null.</param>
        public TransmissionConfigurationItem(string scheme, string type, string proxyUrl, string proxyUserName, string proxyPassword,
                                            string proxyDomain, bool bypassProxyOnLocal,
                                            FileTransmitterEncoderConfigurationCollection fileTransmitterEncoderConfigurationCollection)
            : base(type) {

            if (scheme == null || scheme.Length == 0) {
                throw new JdfException("Scheme must be non-null and must not be zero length.");
            }
            if (fileTransmitterEncoderConfigurationCollection == null) {
                _fileTransmitterEncoderConfigurationCollection = new FileTransmitterEncoderConfigurationCollection();
            }
            else {
                _fileTransmitterEncoderConfigurationCollection = fileTransmitterEncoderConfigurationCollection;
            }
            _scheme = scheme;
            _proxyUrl = proxyUrl;
            _proxyUserName = proxyUserName;
            _proxyPassword = proxyPassword;
            _proxyDomain = proxyDomain;
            _bypassProxyOnLocal = bypassProxyOnLocal;
        }

        /// <summary>
        /// Gets or sets the collection of FileTransmitterEncoderConfigurationItem objects associated with this
        /// transmitter.
        /// </summary>
        public FileTransmitterEncoderConfigurationCollection FileTransmitterEncoderConfiguration {
            get {
                return _fileTransmitterEncoderConfigurationCollection;
            }
            set {
                _fileTransmitterEncoderConfigurationCollection = value;
            }
        }

        /// <summary>
        /// The scheme.
        /// </summary>
        public string Scheme {
            get {
                return _scheme;
            }
        }

        /// <summary>
        /// Get the proxy Url
        /// </summary>
        public string ProxyUrl {
            get {
                return _proxyUrl;
            }
        }

        /// <summary>
        /// Get the proxy user name
        /// </summary>
        public string ProxyUserName {
            get {
                return _proxyUserName;
            }
        }

        /// <summary>
        /// Get the proxy password
        /// </summary>
        public string ProxyPassword {
            get {
                return _proxyPassword;
            }
        }

        /// <summary>
        /// Get the proxy domain
        /// </summary>
        public string ProxyDomain {
            get {
                return _proxyDomain;
            }
        }

        /// <summary>
        /// Bypass the Proxy if transmitting within local network.
        /// </summary>
        public bool BypassProxyOnLocal {
            get {
                return _bypassProxyOnLocal;
            }
        }

        /// <summary>
        /// Get the Outbound Message Configuration
        /// </summary>
        public OutboundMessageConfigurationItem Outbound {
            get {
                return _outbound;
            }
            set {
                _outbound = value;
            }
        }

        /// <summary>
        /// Returns a string representation of the object.
        /// </summary>
        public override string ToString() {
            string baseString = base.ToString();
            StringBuilder sb = new StringBuilder(baseString.Length + 50);
            sb.AppendFormat("{6} Scheme: {0} ProxyUrl: {1} ProxyUserName: {2} ProxyPassword: {3} ProxyDomain: {4} Bypass Proxy on Local: {5}",
                _scheme, (_proxyUrl != null ? _proxyUrl : "NULL"), (_proxyUserName != null ? _proxyUserName : "NULL"),
                (_proxyPassword != null ? _proxyPassword : "NULL"), (_proxyDomain != null ? _proxyDomain : "NULL"),
                _bypassProxyOnLocal, base.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Dump a string representation to the trace listeners.
        /// </summary>
        public override void Dump() {
            Trace.WriteLine(this.GetType().Name + " " + ToString());
            Trace.Indent();
            try {
                if (_outbound != null) {
                    _outbound.Dump();
                }
                _fileTransmitterEncoderConfigurationCollection.Dump();
            }
            finally {
                Trace.Unindent();
            }
        }
    }
}
