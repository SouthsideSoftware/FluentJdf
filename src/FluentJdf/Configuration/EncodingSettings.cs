using System;
using System.Collections.Generic;
using FluentJdf.Encoding;
using FluentJdf.Resources;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Settings for encoding.
    /// </summary>
    public class EncodingSettings {
        Type defaultEncoding;
        Type defaultMultiPartEncoding;
        Type defaultSinglePartEncoding;

        /// <summary>
        /// Constructor.
        /// </summary>
        public EncodingSettings() {
            EncodingsByMimeType = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets dictionary of encoding settings by mime type.
        /// </summary>
        public Dictionary<string, string> EncodingsByMimeType { get; private set; }

        /// <summary>
        /// Gets the default encoding for transmission part collections containing a single part.
        /// </summary>
        public Type DefaultSinglePartEncoding {
            get { return defaultSinglePartEncoding; }
            internal set {
                ParameterCheck.ParameterRequired(value, "value");
                ThrowExceptionIfTypeIsNotIEncoding(value);
                RegisterEncodingIfRequired(value);
                defaultSinglePartEncoding = value;
            }
        }

        /// <summary>
        /// Gets the default encoding.
        /// </summary>
        public Type DefaultEncoding {
            get { return defaultEncoding; }
            internal set {
                ParameterCheck.ParameterRequired(value, "value");
                ThrowExceptionIfTypeIsNotIEncoding(value);
                RegisterEncodingIfRequired(value);
                defaultEncoding = value;
            }
        }

        /// <summary>
        /// Gets the default encoding for transmission part collections containing multiple parts.
        /// </summary>
        public Type DefaultMultiPartEncoding {
            get { return defaultMultiPartEncoding; }
            internal set {
                ParameterCheck.ParameterRequired(value, "value");
                ThrowExceptionIfTypeIsNotIEncoding(value);
                RegisterEncodingIfRequired(value);
                defaultMultiPartEncoding = value;
            }
        }

        /// <summary>
        /// Register an encoding for a mime type.
        /// </summary>
        /// <param name="mimeType"></param>
        /// <param name="value"></param>
        public void RegisterEncodingForMimeType(string mimeType, Type value) {
            ParameterCheck.StringRequiredAndNotWhitespace(mimeType, "mimeType");
            ParameterCheck.ParameterRequired(value, "value");
            ThrowExceptionIfTypeIsNotIEncoding(value);

            RegisterEncodingIfRequired(value);
            EncodingsByMimeType[mimeType] = value.FullName;
        }

        void ThrowExceptionIfTypeIsNotIEncoding(Type value) {
            if (!typeof (IEncoding).IsAssignableFrom(value)) {
                throw new ArgumentException(Messages.EncodingSettings_ThrowExceptionIfTypeIsNotIEncoding);
            }
        }

        /// <summary>
        /// Reset to defaults.
        /// </summary>
        /// <returns></returns>
        public EncodingSettings ResetToDefault() {
            EncodingsByMimeType.Clear();
            RegisterEncodingFactoryIfRequired();
            DefaultEncoding = typeof (PassThroughEncoding);
            DefaultSinglePartEncoding = typeof (PassThroughEncoding);
            DefaultMultiPartEncoding = typeof (PassThroughEncoding);
            return this;
        }

        void RegisterEncodingIfRequired(Type encodingType) {
            if (!Infrastructure.Core.Configuration.Settings.ServiceLocator.CanResolve(typeof (IEncoding), encodingType.FullName)) {
                Infrastructure.Core.Configuration.Settings.ServiceLocator.Register(typeof (IEncoding), encodingType);
            }
        }

        void RegisterEncodingFactoryIfRequired() {
            Type t = typeof (EncodingFactory);
            if (!Infrastructure.Core.Configuration.Settings.ServiceLocator.CanResolve(typeof (IEncodingFactory), t.FullName)) {
                Infrastructure.Core.Configuration.Settings.ServiceLocator.Register(typeof (IEncodingFactory), t);
            }
        }
    }
}