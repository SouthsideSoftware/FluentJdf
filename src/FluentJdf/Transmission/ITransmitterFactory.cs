using System;

namespace FluentJdf.Transmission {
    /// <summary>
    /// Interface used to obtain transmitters.
    /// </summary>
    public interface ITransmitterFactory {
        /// <summary>
        /// Gets the transmitter for the given scheme.
        /// </summary>
        /// <param name="scheme"></param>
        /// <returns></returns>
        ITransmitter GetTransmitterForScheme(string scheme);

        /// <summary>
        /// Gets the transmitter for the given url.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        ITransmitter GetTransmitterForUrl(Uri url);

        /// <summary>
        /// Gets the transmitter for the given url (string).
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        ITransmitter GetTransmitterForUrl(string url);
    }
}