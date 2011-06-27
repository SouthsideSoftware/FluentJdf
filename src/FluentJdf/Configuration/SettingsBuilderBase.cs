using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Base class for settings builders.
    /// </summary>
    public class SettingsBuilderBase {
        private FluentJdfLibrary fluentJdfLibrary;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="fluentJdfLibrary"></param>
        protected SettingsBuilderBase(FluentJdfLibrary fluentJdfLibrary) {
            ParameterCheck.ParameterRequired(fluentJdfLibrary, "fluentJdfLibrary");

            this.fluentJdfLibrary = fluentJdfLibrary;
        }

        /// <summary>
        /// Gets the owning FluentJdfLibrary settings.
        /// </summary>
        public FluentJdfLibrary Settings {get { return fluentJdfLibrary; }}
    }
}