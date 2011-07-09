using System;
using System.Collections.Generic;
using FluentJdf.Encoding;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Settings for encoding.
    /// </summary>
    public class EncodingSettingsBuilder : SettingsBuilderBase {
        EncodingSettings encodingSettings;

        internal EncodingSettingsBuilder(FluentJdfLibrary fluentJdfLibrary, EncodingSettings encodingSettings)
            : base(fluentJdfLibrary) {
            ParameterCheck.ParameterRequired(encodingSettings, "encodingSettings");

            this.encodingSettings = encodingSettings;
        }

        /// <summary>
        /// Register an encoding for a specific mime type.
        /// </summary>
        /// <param name="mimeType"></param>
        public EncodingSettingsBuilder EncodingForMimeType<T>(string mimeType) where T : IEncoding {
            ParameterCheck.StringRequiredAndNotWhitespace(mimeType, "mimeType");

            encodingSettings.RegisterEncodingForMimeType<T>(mimeType);

            return this;
        }

        /// <summary>
        /// Register a default encoding.
        /// </summary>
        /// <returns></returns>
        public EncodingSettingsBuilder DefaultEncoding<T>() where T : IEncoding {
            encodingSettings.SetDefaultEncoding<T>();

            return this;
        }

        /// <summary>
        /// Register a default encoding for transmission part
        /// collection that contain a single part.
        /// </summary>
        /// <returns></returns>
        public EncodingSettingsBuilder DefaultSinglePartEncoding<T>() where T : IEncoding {
            encodingSettings.SetDefaultSinglePartEncoding<T>();

            return this;
        }

        /// <summary>
        /// Register a default encoding for transmission part
        /// collection that contain multiple parts.
        /// </summary>
        /// <returns></returns>
        public EncodingSettingsBuilder DefaultMultiPartEncoding<T>() where T : IEncoding {
            encodingSettings.SetDefaultMultiPartEncoding<T>();
            return this;
        }

    }
}