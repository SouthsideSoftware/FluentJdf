using Onpoint.Commons.Core.Helpers;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Holds JDP settings.
    /// </summary>
    public class Library {
        static readonly Library settings = new Library();
        /// <summary>
        /// The singleton settings instance (defaults)
        /// </summary>
        public static Library Settings { get { return settings;  } }

        JdfAuthoringSettings jdfAuthoringSettings;
        
        Library() {
            jdfAuthoringSettings = new JdfAuthoringSettings();
            ResetToDefaults();
        }
        
        /// <summary>
        /// Make all settings default.
        /// </summary>
        /// <returns></returns>
        public Library ResetToDefaults() {
            jdfAuthoringSettings.ResetToDefaults();
            return this;
        }

        /// <summary>
        /// Gets the JDF authoring settings.
        /// </summary>
        public JdfAuthoringSettings JdfAuthoringSettings { get { return jdfAuthoringSettings; } }

        /// <summary>
        /// Gets the authoring settings builder.
        /// </summary>
        /// <returns></returns>
        public JdfAuthoringSettingsBuilder WithJdfAuthoringSettings() {
            return new JdfAuthoringSettingsBuilder(this, jdfAuthoringSettings);
        }

    }
}