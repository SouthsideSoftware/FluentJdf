using System;
using System.Collections.Generic;
using FluentJdf.Encoding;
using Infrastructure.Core.CodeContracts;
using FluentJdf.Transmission;
using FluentJdf.LinqToJdf;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Settings for encoding.
    /// </summary>
    public class EncodingSettingsBuilder : SettingsBuilderBase {
        EncodingSettings encodingSettings;
        FluentJdfLibrary fluentJdfLibrary;
        internal EncodingSettingsBuilder(FluentJdfLibrary fluentJdfLibrary, EncodingSettings encodingSettings)
            : base(fluentJdfLibrary) {
            ParameterCheck.ParameterRequired(encodingSettings, "encodingSettings");

            this.fluentJdfLibrary = fluentJdfLibrary;
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

        /// <summary>
        /// Add a new FileTransmitterEncoder
        /// </summary>
        /// <param name="id">The id of the encoder</param>
        /// <param name="urlBase">The url base</param>
        /// <param name="useMime">UseMime</param>
        /// <param name="nameValues">Additional Parameters</param>
        /// <returns></returns>
        public FileTransmitterEncoderBuilder FileTransmitterEncoder(string id, string urlBase, bool useMime = false, IDictionary<string, string> nameValues = null) {
            ParameterCheck.StringRequiredAndNotWhitespace(id, "id");
            ParameterCheck.StringRequiredAndNotWhitespace(urlBase, "urlBase");

            if (encodingSettings.FileTransmitterEncoders.ContainsKey(id)) {
                throw new JdfException(string.Format("FileTransmitterEncoder Id already exists {0}", id));
            }

            var newEncoder = new FileTransmitterEncoder(id, urlBase, useMime, nameValues);
            encodingSettings.FileTransmitterEncoders[id] = newEncoder;
            return new FileTransmitterEncoderBuilder(fluentJdfLibrary, encodingSettings, newEncoder);
        }

        /// <summary>
        /// Add a new FileTransmitterEncoder
        /// </summary>
        /// <param name="id">The id of the encoder</param>
        /// <param name="urlBase">The url base</param>
        /// <param name="useMime">UseMime</param>
        /// <param name="nameValues">Additional Parameters</param>
        /// <returns></returns>
        public FileTransmitterEncoderBuilder FileTransmitterEncoder(string id, Uri urlBase, bool useMime = false, IDictionary<string, string> nameValues = null) {
            ParameterCheck.StringRequiredAndNotWhitespace(id, "id");
            ParameterCheck.ParameterRequired(urlBase, "urlBase");

            return this.FileTransmitterEncoder(id, urlBase.ToString(), useMime, nameValues);
        }

    }
}