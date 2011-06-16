﻿namespace FluentJdf.Configuration {
    /// <summary>
    /// Holds JDP settings.
    /// </summary>
    public class Library {
        static readonly Library settings = new Library();
        readonly JdfAuthoringSettings jdfAuthoringSettings;
        readonly EncodingSettings encodingSettings;
        readonly TransmissionPartSettings transmissionPartSettings;

        Library() {
            jdfAuthoringSettings = new JdfAuthoringSettings();
            encodingSettings = new EncodingSettings();
            transmissionPartSettings = new TransmissionPartSettings();
            ResetToDefaults();
        }

        /// <summary>
        /// The singleton settings instance (defaults)
        /// </summary>
        public static Library Settings {
            get { return settings; }
        }

        /// <summary>
        /// Gets the JDF authoring settings.
        /// </summary>
        public JdfAuthoringSettings JdfAuthoringSettings {
            get { return jdfAuthoringSettings; }
        }

        /// <summary>
        /// Gets the transmission part settings 
        /// </summary>
        public TransmissionPartSettings TransmissionPartSettings {
            get { return transmissionPartSettings; }
        }

        /// <summary>
        /// Gets the encoding settings.
        /// </summary>
        public EncodingSettings EncodingSettings { get { return encodingSettings; }} 

        /// <summary>
        /// Make all settings default.
        /// </summary>
        /// <returns></returns>
        public Library ResetToDefaults() {
            jdfAuthoringSettings.ResetToDefaults();
            encodingSettings.ResetToDefault();
            transmissionPartSettings.ResetToDefault();
            return this;
        }

        /// <summary>
        /// Gets the transmission part settings builder.
        /// </summary>
        /// <returns></returns>
        public TransmissionPartSettingsBuilder WithTransmissionPartSettings() {
            return new TransmissionPartSettingsBuilder(this, transmissionPartSettings);
        }

        /// <summary>
        /// Gets the authoring settings builder.
        /// </summary>
        /// <returns></returns>
        public JdfAuthoringSettingsBuilder WithJdfAuthoringSettings() {
            return new JdfAuthoringSettingsBuilder(this, jdfAuthoringSettings);
        }

        /// <summary>
        /// Gets the encoding settings builder.
        /// </summary>
        /// <returns></returns>
        public EncodingSettingsBuilder WithEncodingSettings() {
            return new EncodingSettingsBuilder(this, encodingSettings);
        }
    }
}