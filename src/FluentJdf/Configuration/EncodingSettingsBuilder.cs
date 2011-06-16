using System;
using System.Collections.Generic;
using FluentJdf.Encoding;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Settings for encoding.
    /// </summary>
    public class EncodingSettingsBuilder {
        EncodingSettings encodingSettings;
        Library library;

        internal EncodingSettingsBuilder(Library library, EncodingSettings encodingSettings) {
            ParameterCheck.ParameterRequired(library, "library");
            ParameterCheck.ParameterRequired(encodingSettings, "encodingSettings");

            this.library = library;
            this.encodingSettings = encodingSettings;
        }

        /// <summary>
        /// Gets the owning library settings.
        /// </summary>
        public Library Settings {get { return library; }}

        /// <summary>
        /// Register an encoding for a specific mime type.
        /// </summary>
        /// <param name="mimeType"></param>
        /// <param name="encodingType"></param>
        public EncodingSettingsBuilder RegisterEncoding(string mimeType, Type encodingType) {
            ParameterCheck.StringRequiredAndNotWhitespace(mimeType, "mimeType");
            ParameterCheck.ParameterRequired(encodingType, "encodingType");

            RegisterEncodingIfRequired(encodingType);
            encodingSettings.EncodingsByMimeType[mimeType] = encodingType.Name;
            return this;
        }

        void RegisterEncodingIfRequired(Type encodingType) {
            if (!Infrastructure.Core.Configuration.Settings.ServiceLocator.CanResolve(typeof(IEncoding), encodingType.Name)) {
                Infrastructure.Core.Configuration.Settings.ServiceLocator.Register(typeof (IEncoding), encodingType);
            }
        }

        /// <summary>
        /// Register a default encoding.
        /// </summary>
        /// <param name="encodingType"></param>
        /// <returns></returns>
        public EncodingSettingsBuilder RegisterDefaultEncoding(Type encodingType) {
            ParameterCheck.ParameterRequired(encodingType, "encodingType");

            RegisterEncodingIfRequired(encodingType);
            encodingSettings.DefaultEncoding = encodingType.Name;

            return this;
        }

    }
}