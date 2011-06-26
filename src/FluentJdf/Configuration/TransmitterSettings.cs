using System;
using System.Collections.Generic;
using FluentJdf.Resources;
using FluentJdf.Transmission;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Settings for transmission parts.
    /// </summary>
    public class TransmitterSettings {
        /// <summary>
        /// Constructor.
        /// </summary>
        public TransmitterSettings() {
            TransmittersByScheme = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets dictionary of transmitters by scheme.
        /// </summary>
        public Dictionary<string, string> TransmittersByScheme { get; private set; }

        void RegisterTransmitterFactoryIfRequired() {
            Type t = typeof (TransmitterFactory);
            if (!Infrastructure.Core.Configuration.Settings.ServiceLocator.CanResolve(typeof (ITransmitterFactory), t.FullName)) {
                Infrastructure.Core.Configuration.Settings.ServiceLocator.Register(typeof (ITransmitterFactory), t);
            }
        }

        /// <summary>
        /// Register a transmitter for a scheme
        /// </summary>
        public void RegisterTransmitterForScheme(string scheme, Type value) {
            ParameterCheck.StringRequiredAndNotWhitespace(scheme, "scheme");
            ParameterCheck.ParameterRequired(value, "value");
            ThrowExceptionIfTypeIsNotITransmitter(value);

            RegisterTransmitterIfRequired(value);
            TransmittersByScheme[scheme] = value.FullName;
        }

        void ThrowExceptionIfTypeIsNotITransmitter(Type value) {
            if (!typeof (ITransmitter).IsAssignableFrom(value)) {
                throw new ArgumentException(Messages.TransmissionSettings_ThrowExceptionIfTypeIsNotITransmitter);
            }
        }

        /// <summary>
        /// Reset to defaults.
        /// </summary>
        /// <returns></returns>
        public TransmitterSettings ResetToDefault() {
            TransmittersByScheme.Clear();
            RegisterTransmitterFactoryIfRequired();
            RegisterTransmitterForScheme("http", typeof(HttpTransmitter));
            return this;
        }

        void RegisterTransmitterIfRequired(Type transmitter) {
            if (!Infrastructure.Core.Configuration.Settings.ServiceLocator.CanResolve(typeof (ITransmitter), transmitter.FullName)) {
                Infrastructure.Core.Configuration.Settings.ServiceLocator.Register(typeof (ITransmitter), transmitter);
            }
        }
    }
}