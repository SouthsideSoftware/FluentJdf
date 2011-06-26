namespace FluentJdf.Configuration {
    /// <summary>
    /// Holds JDP settings.
    /// </summary>
    public class Library {
        static readonly Library settings = new Library();
        readonly EncodingSettings encodingSettings;
        readonly HttpTransmissionSettings httpTransmissionSettings;
        readonly JdfAuthoringSettings jdfAuthoringSettings;
        readonly TransmissionPartSettings transmissionPartSettings;
        readonly TransmitterSettings transmitterSettings;

        Library() {
            jdfAuthoringSettings = new JdfAuthoringSettings();
            encodingSettings = new EncodingSettings();
            transmissionPartSettings = new TransmissionPartSettings();
            transmitterSettings = new TransmitterSettings();
            httpTransmissionSettings = new HttpTransmissionSettings();
            ResetToDefaults();
        }

        /// <summary>
        /// The singleton settings instance (defaults)
        /// </summary>
        public static Library Settings {
            get { return settings; }
        }

        /// <summary>
        /// Gets the http transmission settings.
        /// </summary>
        public HttpTransmissionSettings HttpTransmissionSettings {
            get { return httpTransmissionSettings; }
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
        /// Gets the transmitter settings.
        /// </summary>
        public TransmitterSettings TransmitterSettings {
            get { return transmitterSettings; }
        }

        /// <summary>
        /// Gets the encoding settings.
        /// </summary>
        public EncodingSettings EncodingSettings {
            get { return encodingSettings; }
        }

        /// <summary>
        /// Make all settings default.
        /// </summary>
        /// <returns></returns>
        public Library ResetToDefaults() {
            jdfAuthoringSettings.ResetToDefaults();
            encodingSettings.ResetToDefault();
            transmissionPartSettings.ResetToDefault();
            transmitterSettings.ResetToDefault();
            httpTransmissionSettings.ResetToDefaults();
            Infrastructure.Core.Configuration.Settings.ServiceLocator.RegisterRemainingInterfaceImplementations(GetType().Assembly);
            Infrastructure.Core.Configuration.Settings.ServiceLocator.LogRegisteredComponents();
            return this;
        }

        /// <summary>
        /// Gets the transmitter settings builder.
        /// </summary>
        /// <returns></returns>
        public TransmitterSettingsBuilder WithTransmitterSettings() {
            return new TransmitterSettingsBuilder(this, transmitterSettings);
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

        /// <summary>
        /// Gets the http transmission settings builder.
        /// </summary>
        /// <returns></returns>
        public HttpTransmissionSettingsBuilder WithHttpTransmissionSettings() {
            return new HttpTransmissionSettingsBuilder(this, httpTransmissionSettings);
        }
    }
}