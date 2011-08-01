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
        /// The Stream Limit for logging before it becomes a separate file.
        /// </summary>
        public TransmitterSettingsBuilder InlineStreamLimit(int inlineStreamLimit) {
            ParameterCheck.IntParameterGreaterThanZero(inlineStreamLimit, "inlineStreamLimit");

            transmitterSettings.InlineStreamLimit = inlineStreamLimit;

            return this;
        }

        /// <summary>
        /// The path to the Stream Log Folder.
        /// </summary>
        public TransmitterSettingsBuilder StreamLogsFolder(string streamLogsFolder) {
            ParameterCheck.StringRequiredAndNotWhitespace(streamLogsFolder, "streamLogsFolder");

            transmitterSettings.StreamLogsFolder = streamLogsFolder;

            return this;
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