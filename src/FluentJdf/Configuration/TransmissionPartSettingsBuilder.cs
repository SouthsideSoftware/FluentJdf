using System;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Settings for transmission parts.
    /// </summary>
    public class TransmissionPartSettingsBuilder {
        TransmissionPartSettings transmissionPartSettings;
        Library library;

        internal TransmissionPartSettingsBuilder(Library library, TransmissionPartSettings transmissionPartSettings)
        {
            ParameterCheck.ParameterRequired(library, "library");
            ParameterCheck.ParameterRequired(transmissionPartSettings, "transmissionPartSettings");

            this.library = library;
            this.transmissionPartSettings = transmissionPartSettings;
        }

        /// <summary>
        /// Gets the owning library settings.
        /// </summary>
        public Library Settings {get { return library; }}

        /// <summary>
        /// Register an encoding for a specific transmission part.
        /// </summary>
        public TransmissionPartSettingsBuilder TransmissionPartForMimeType(string mimeType, Type transmissionPartType) {
            ParameterCheck.StringRequiredAndNotWhitespace(mimeType, "mimeType");
            ParameterCheck.ParameterRequired(transmissionPartType, "transmissionPartType");

            transmissionPartSettings.RegisterTransmissionPartForMimeType(mimeType, transmissionPartType);

            return this;
        }

        /// <summary>
        /// Register a default transmission part
        /// </summary>
        /// <param name="transmissionPartType"></param>
        /// <returns></returns>
        public TransmissionPartSettingsBuilder DefaultTransmissionPart(Type transmissionPartType)
        {
            ParameterCheck.ParameterRequired(transmissionPartType, "transmissionPartType");

            transmissionPartSettings.DefaultTransmissionPart = transmissionPartType;

            return this;
        }
    }
}