using System;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Settings for transmitters.
    /// </summary>
    public class TransmitterSettingsBuilder : SettingsBuilderBase {
        TransmitterSettings transmitterSettings;

        internal TransmitterSettingsBuilder(FluentJdfLibrary fluentJdfLibrary, TransmitterSettings transmitterSettings) : base(fluentJdfLibrary)
        {
            ParameterCheck.ParameterRequired(transmitterSettings, "transmitterSettings");

            this.transmitterSettings = transmitterSettings;
        }

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