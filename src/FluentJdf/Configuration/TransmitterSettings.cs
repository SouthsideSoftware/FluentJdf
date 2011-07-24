using System;
using System.Collections.Generic;
using FluentJdf.Resources;
using FluentJdf.Transmission;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Settings for transmission parts.
    /// </summary>
    public class TransmitterSettings {

         IDictionary<string, string> transmittersByScheme;

        /// <summary>
        /// Constructor.
        /// </summary>
        public TransmitterSettings() {
             transmittersByScheme = new Dictionary<string, string>();
             TransmittersByScheme = new ReadOnlyDictionary<string, string>(transmittersByScheme);
        }

        /// <summary>
        /// Gets dictionary of transmitters by scheme.
        /// </summary>
        public ReadOnlyDictionary<string, string> TransmittersByScheme {
            get;
            private set;
        }

        /// <summary>
        /// Register a transmitter for a scheme
        /// </summary>
        public void RegisterTransmitterForScheme(string scheme, Type value) {
            ParameterCheck.StringRequiredAndNotWhitespace(scheme, "scheme");
            ParameterCheck.ParameterRequired(value, "value");
            ThrowExceptionIfTypeIsNotITransmitter(value);

            RegisterTransmitterIfRequired(value);
            transmittersByScheme[scheme] = value.FullName;
        }

        void ThrowExceptionIfTypeIsNotITransmitter(Type value) {
            if (!typeof(ITransmitter).IsAssignableFrom(value)) {
                throw new ArgumentException(Messages.TransmissionSettings_ThrowExceptionIfTypeIsNotITransmitter);
            }
        }

        /// <summary>
        /// Clear the transmitters but leave the schemes
        /// </summary>
        /// <returns></returns>
        public TransmitterSettings ClearTransmitters() {
            transmittersByScheme.Clear();
            return this;
        }

        /// <summary>
        /// Reset to defaults.
        /// </summary>
        /// <returns></returns>
        public TransmitterSettings ResetToDefaults() {
            transmittersByScheme.Clear();
            RegisterTransmitterForScheme("http", typeof(HttpTransmitter));
            RegisterTransmitterForScheme("file", typeof(FileTransmitter));
            return this;
        }

        void RegisterTransmitterIfRequired(Type transmitter) {
            if (!Infrastructure.Core.Configuration.Settings.ServiceLocator.CanResolve(typeof(ITransmitter), transmitter.FullName)) {
                Infrastructure.Core.Configuration.Settings.ServiceLocator.Register(typeof(ITransmitter), transmitter);
            }
        }
    }
}