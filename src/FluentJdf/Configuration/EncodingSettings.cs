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
            EncodingsByMimeType = new Dictionary<string, Type>();
        }

        /// <summary>
        /// Gets dictionary of encoding settings by mime type.
        /// </summary>
        public Dictionary<string, Type> EncodingsByMimeType { get; private set; }

        /// <summary>
        /// Gets the default encoding for transmission part collections containing a single part.
        /// </summary>
        public Type DefaultSinglePartEncoding {
            get { return defaultSinglePartEncoding; }
        }

        internal void SetDefaultSinglePartEncoding<T>() where T:IEncoding {
            RegisterEncodingIfRequired<T>();
            defaultSinglePartEncoding = typeof (T);
        }

        /// <summary>
        /// Gets the default encoding.
        /// </summary>
        public Type DefaultEncoding {
            get { return defaultEncoding; }
        }

        internal void SetDefaultEncoding<T>() where T: IEncoding {
            RegisterEncodingIfRequired<T>();
            defaultEncoding = typeof (T);
        }

        /// <summary>
        /// Gets the default encoding for transmission part collections containing multiple parts.
        /// </summary>
        public Type DefaultMultiPartEncoding {
            get { return defaultMultiPartEncoding; }
        }

        internal void SetDefaultMultiPartEncoding<T>() where T:IEncoding {
           RegisterEncodingIfRequired<T>();
            defaultMultiPartEncoding = typeof (T);
        }

        /// <summary>
        /// Register an encoding for a mime type.
        /// </summary>
        /// <param name="mimeType"></param>
        public void RegisterEncodingForMimeType<T>(string mimeType) where T:IEncoding {
            ParameterCheck.StringRequiredAndNotWhitespace(mimeType, "mimeType");

            RegisterEncodingIfRequired<T>();
            EncodingsByMimeType[mimeType] = typeof(T);
        }

        /// <summary>
        /// Reset to defaults.
        /// </summary>
        /// <returns></returns>
        public EncodingSettings ResetToDefault() {
            EncodingsByMimeType.Clear();
            SetDefaultEncoding<PassThroughEncoding>();
            SetDefaultSinglePartEncoding<PassThroughEncoding>();
            SetDefaultMultiPartEncoding<PassThroughEncoding>();
            return this;
        }

        void RegisterEncodingIfRequired<T>() where T: IEncoding {
            var encodingType = typeof (T);
            if (!Infrastructure.Core.Configuration.Settings.ServiceLocator.CanResolve(typeof (IEncoding), encodingType.FullName)) {
                Infrastructure.Core.Configuration.Settings.ServiceLocator.Register(typeof (IEncoding), encodingType);
            }
        }
    }
}