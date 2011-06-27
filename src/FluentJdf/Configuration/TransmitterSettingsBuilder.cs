using System;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Settings for transmitters.
    /// </summary>
    public class TransmitterSettingsBuilder {
        TransmitterSettings transmitterSettings;
        FluentJdfLibrary fluentJdfLibrary;

        internal TransmitterSettingsBuilder(FluentJdfLibrary fluentJdfLibrary, TransmitterSettings transmitterSettings)
        {
            ParameterCheck.ParameterRequired(fluentJdfLibrary, "FluentJdfLibrary");
            ParameterCheck.ParameterRequired(transmitterSettings, "transmitterSettings");

            this.fluentJdfLibrary = fluentJdfLibrary;
            this.transmitterSettings = transmitterSettings;
        }

        /// <summary>
        /// Gets the owning FluentJdfLibrary settings.
        /// </summary>
        public FluentJdfLibrary Settings {get { return fluentJdfLibrary; }}

        /// <summary>
        /// Register a transmitter for a scheme.
        /// </summary>
        public TransmitterSettingsBuilder TransmitterForScheme(string scheme, Type transmitterType) {
            ParameterCheck.StringRequiredAndNotWhitespace(scheme, "scheme");
            ParameterCheck.ParameterRequired(transmitterType, "transmitterType");

            transmitterSettings.RegisterTransmitterForScheme(scheme, transmitterType);

            return this;
        }
    }
}