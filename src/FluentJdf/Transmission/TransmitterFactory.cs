using System;
using FluentJdf.Configuration;
using FluentJdf.Resources;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Transmission {
    /// <summary>
    /// Factory to get transmitters.
    /// </summary>
    public class TransmitterFactory : ITransmitterFactory {
        #region ITransmitterFactory Members

        /// <summary>
        /// Gets the transmitter for the given scheme.
        /// </summary>
        /// <param name="scheme"></param>
        /// <returns></returns>
        public ITransmitter GetTransmitterForScheme(string scheme) {
            ParameterCheck.StringRequiredAndNotWhitespace(scheme, "scheme");

            if (!Library.Settings.TransmitterSettings.TransmittersByScheme.ContainsKey(scheme)) {
                throw new ArgumentException(Messages.TransmitterFactory_GetTransmitterForScheme_SchemeNotConfigured, scheme);
            }

            return
                Infrastructure.Core.Configuration.Settings.ServiceLocator.Resolve<ITransmitter>(
                    Library.Settings.TransmitterSettings.TransmittersByScheme[scheme]);
        }

        /// <summary>
        /// Gets the transmitter for the given url.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public ITransmitter GetTransmitterForUrl(Uri url) {
            ParameterCheck.ParameterRequired(url, "url");

            return GetTransmitterForScheme(url.Scheme);
        }

        /// <summary>
        /// Gets the transmitter for the given url (string).
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public ITransmitter GetTransmitterForUrl(string url) {
            ParameterCheck.StringRequiredAndNotWhitespace(url, "url");

            var urlObject = new Uri(url);
            return GetTransmitterForScheme(urlObject.Scheme);
        }

        #endregion
    }
}