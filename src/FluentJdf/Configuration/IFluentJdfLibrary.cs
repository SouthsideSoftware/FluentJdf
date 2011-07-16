namespace FluentJdf.Configuration {
    /// <summary>
    /// Global settings interface.
    /// </summary>
    public interface IFluentJdfLibrary {
        /// <summary>
        /// Gets the http transmission settings.
        /// </summary>
        HttpTransmissionSettings HttpTransmissionSettings {
            get;
        }

        /// <summary>
        /// Gets the JDF authoring settings.
        /// </summary>
        JdfAuthoringSettings JdfAuthoringSettings {
            get;
        }

        /// <summary>
        /// Gets the transmission part settings 
        /// </summary>
        TransmissionPartSettings TransmissionPartSettings {
            get;
        }

        /// <summary>
        /// Gets the transmitter settings.
        /// </summary>
        TransmitterSettings TransmitterSettings {
            get;
        }

        /// <summary>
        /// Gets the encoding settings.
        /// </summary>
        EncodingSettings EncodingSettings {
            get;
        }

        /// <summary>
        /// Gets the template engine settings.
        /// </summary>
        ITemplateEngineSettings TemplateEngineSettings {
            get;
        }

        /// <summary>
        /// Make all settings default.
        /// </summary>
        /// <returns></returns>
        FluentJdfLibrary ResetToDefaults();

        /// <summary>
        /// Gets the transmitter settings builder.
        /// </summary>
        /// <returns></returns>
        TransmitterSettingsBuilder WithTransmitterSettings();

        /// <summary>
        /// Gets the transmission part settings builder.
        /// </summary>
        /// <returns></returns>
        TransmissionPartSettingsBuilder WithTransmissionPartSettings();

        /// <summary>
        /// Gets the authoring settings builder.
        /// </summary>
        /// <returns></returns>
        JdfAuthoringSettingsBuilder WithJdfAuthoringSettings();


        /// <summary>
        /// Gets the encoding settings builder.
        /// </summary>
        /// <returns></returns>
        EncodingSettingsBuilder WithEncodingSettings();

        /// <summary>
        /// Gets the http transmission settings builder.
        /// </summary>
        /// <returns></returns>
        HttpTransmissionSettingsBuilder WithHttpTransmissionSettings();

        /// <summary>
        /// Gets the template engine settings builder.
        /// </summary>
        /// <returns></returns>
        TemplateEngineSettingsBuilder WithTemplateEngineSettings();
    }
}