using System;
using FluentJdf.Encoding;
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
        public TransmissionPartSettingsBuilder TransmissionPartForMimeType<T>(string mimeType) where T:ITransmissionPart {
            ParameterCheck.StringRequiredAndNotWhitespace(mimeType, "mimeType");

            transmissionPartSettings.RegisterTransmissionPartForMimeType<T>(mimeType);

            return this;
        }

        /// <summary>
        /// Register a default transmission part
        /// </summary>
        /// <returns></returns>
        public TransmissionPartSettingsBuilder DefaultTransmissionPart<T>() where T:ITransmissionPart {
            transmissionPartSettings.SetDefaultTransmissionPart<T>();

            return this;
        }
    }
}