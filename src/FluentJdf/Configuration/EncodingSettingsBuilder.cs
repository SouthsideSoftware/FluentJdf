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
        public EncodingSettingsBuilder EncodingForMimeType(string mimeType, Type encodingType) {
            ParameterCheck.StringRequiredAndNotWhitespace(mimeType, "mimeType");
            ParameterCheck.ParameterRequired(encodingType, "encodingType");

            encodingSettings.RegisterEncodingForMimeType(mimeType, encodingType);

            return this;
        }

        /// <summary>
        /// Register a default encoding.
        /// </summary>
        /// <param name="encodingType"></param>
        /// <returns></returns>
        public EncodingSettingsBuilder DefaultEncoding(Type encodingType)
        {
            ParameterCheck.ParameterRequired(encodingType, "encodingType");

            encodingSettings.DefaultEncoding = encodingType;

            return this;
        }

        /// <summary>
        /// Register a default encoding for transmission part
        /// collection that contain a single part.
        /// </summary>
        /// <param name="encodingType"></param>
        /// <returns></returns>
        public EncodingSettingsBuilder DefaultSinglePartEncoding(Type encodingType) {
            ParameterCheck.ParameterRequired(encodingType, "encodingType");

            encodingSettings.DefaultSinglePartEncoding = encodingType;

            return this;
        }

        /// <summary>
        /// Register a default encoding for transmission part
        /// collection that contain multiple parts.
        /// </summary>
        /// <param name="encodingType"></param>
        /// <returns></returns>
        public EncodingSettingsBuilder DefaultMultiPartEncoding(Type encodingType)
        {
            ParameterCheck.ParameterRequired(encodingType, "encodingType");

            encodingSettings.DefaultMultiPartEncoding = encodingType;

            return this;
        }

    }
}