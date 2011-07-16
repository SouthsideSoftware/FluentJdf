namespace FluentJdf.Configuration {
    /// <summary>
    /// Holds JDP settings.
    /// </summary>
    public sealed class FluentJdfLibrary : IFluentJdfLibrary {
        static readonly FluentJdfLibrary settings = new FluentJdfLibrary();
        readonly EncodingSettings encodingSettings;
        readonly HttpTransmissionSettings httpTransmissionSettings;
        readonly JdfAuthoringSettings jdfAuthoringSettings;
        readonly ITemplateEngineSettings templateEngineSettings;
        readonly TransmissionPartSettings transmissionPartSettings;
        readonly TransmitterSettings transmitterSettings;

        /// <summary>Constructor.</summary>
        ///<remarks>
        /// Do not use this constructor to access global settings.
        /// The global settings are contained in FluentJdfLibrary.Settings.
        /// </remarks>
        public FluentJdfLibrary() {
            //TODO we need an interface for the HttpTransmissionSettings and a better way to resolve.
            Infrastructure.Core.Configuration.Settings.ServiceLocator.Register(typeof(HttpTransmissionSettings), typeof(HttpTransmissionSettings));
            jdfAuthoringSettings = new JdfAuthoringSettings();
            encodingSettings = new EncodingSettings();
            transmissionPartSettings = new TransmissionPartSettings();
            transmitterSettings = new TransmitterSettings();
            httpTransmissionSettings = Infrastructure.Core.Configuration.Settings.ServiceLocator.Resolve<HttpTransmissionSettings>();
            templateEngineSettings = new TemplateEngineSettings();
            ResetToDefaults();
        }

        /// <summary>
        /// The singleton settings instance (defaults)
        /// </summary>
        public static FluentJdfLibrary Settings {
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
        /// Gets the template engine settings.
        /// </summary>
        public ITemplateEngineSettings TemplateEngineSettings {
            get { return templateEngineSettings; }
        }

        /// <summary>
        /// Make all settings default.
        /// </summary>
        /// <returns></returns>
        public FluentJdfLibrary ResetToDefaults() {
            jdfAuthoringSettings.ResetToDefaults();
            encodingSettings.ResetToDefaults();
            transmissionPartSettings.ResetToDefaults();
            transmitterSettings.ResetToDefaults();
            httpTransmissionSettings.ResetToDefaults();
            templateEngineSettings.ResetToDefaults();
            Infrastructure.Core.Configuration.Settings.ServiceLocator.RegisterRemainingInterfaceImplementations(GetType().Assembly);
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

        /// <summary>
        /// Gets the template engine settings builder.
        /// </summary>
        /// <returns></returns>
        public TemplateEngineSettingsBuilder WithTemplateEngineSettings() {
            return new TemplateEngineSettingsBuilder(this, templateEngineSettings);
        }
    }
}