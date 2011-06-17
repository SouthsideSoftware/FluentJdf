using System;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Settings for transmitters.
    /// </summary>
    public class TransmitterSettingsBuilder {
        TransmitterSettings transmitterSettings;
        Library library;

        internal TransmitterSettingsBuilder(Library library, TransmitterSettings transmitterSettings)
        {
            ParameterCheck.ParameterRequired(library, "library");
            ParameterCheck.ParameterRequired(transmitterSettings, "transmitterSettings");

            this.library = library;
            this.transmitterSettings = transmitterSettings;
        }

        /// <summary>
        /// Gets the owning library settings.
        /// </summary>
        public Library Settings {get { return library; }}

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