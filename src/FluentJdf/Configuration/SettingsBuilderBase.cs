using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Base class for settings builders.
    /// </summary>
    public class SettingsBuilderBase {
        private IFluentJdfLibrary fluentJdfLibrary;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="fluentJdfLibrary"></param>
        protected SettingsBuilderBase(IFluentJdfLibrary fluentJdfLibrary) {
            ParameterCheck.ParameterRequired(fluentJdfLibrary, "fluentJdfLibrary");

            this.fluentJdfLibrary = fluentJdfLibrary;
        }

        /// <summary>
        /// Gets the owning FluentJdfLibrary settings.
        /// </summary>
        public IFluentJdfLibrary Settings {get { return fluentJdfLibrary; }}
    }
}