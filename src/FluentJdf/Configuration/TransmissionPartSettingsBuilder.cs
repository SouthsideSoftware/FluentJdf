using System;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Settings for transmission parts.
    /// </summary>
    public class TransmissionPartSettingsBuilder : SettingsBuilderBase {
        readonly TransmissionPartSettings transmissionPartSettings;

        internal TransmissionPartSettingsBuilder(FluentJdfLibrary fluentJdfLibrary, TransmissionPartSettings transmissionPartSettings)
            : base(fluentJdfLibrary) {
            ParameterCheck.ParameterRequired(transmissionPartSettings, "transmissionPartSettings");

            this.transmissionPartSettings = transmissionPartSettings;
        }

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
        public TransmissionPartSettingsBuilder DefaultTransmissionPart(Type transmissionPartType) {
            ParameterCheck.ParameterRequired(transmissionPartType, "transmissionPartType");

            transmissionPartSettings.DefaultTransmissionPart = transmissionPartType;

            return this;
        }
    }
}