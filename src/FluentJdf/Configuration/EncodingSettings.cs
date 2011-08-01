using System;
using System.Linq;
using System.Collections.Generic;
using FluentJdf.Encoding;
using FluentJdf.Resources;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Helpers;
using FluentJdf.Transmission;
using System.IO;
using FluentJdf.LinqToJdf;
using Infrastructure.Core;

namespace FluentJdf.Configuration {

    /// <summary>
    /// Settings for encoding.
    /// </summary>
    public class EncodingSettings {
        Type defaultEncoding;
        Type defaultMultiPartEncoding;
        Type defaultSinglePartEncoding;
        readonly IDictionary<string, Type> encodingsByMimeType;
        readonly IDictionary<string, FileTransmitterEncoder> fileTransmitterEncoderList;

        /// <summary>
        /// Constructor.
        /// </summary>
        public EncodingSettings() {
            encodingsByMimeType = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
            EncodingsByMimeType = new ReadOnlyDictionary<string, Type>(encodingsByMimeType);
            fileTransmitterEncoderList = new Dictionary<string, FileTransmitterEncoder>(StringComparer.OrdinalIgnoreCase);
            FileTransmitterEncoders = new ReadOnlyDictionary<string, FileTransmitterEncoder>(fileTransmitterEncoderList);
        }

        /// <summary>
        /// Gets dictionary of encoding settings by mime type.
        /// </summary>
        public ReadOnlyDictionary<string, Type> EncodingsByMimeType {
            get;
            private set;
        }

        /// <summary>
        /// Gets dictionary of <see cref="FileTransmitterEncoder"/>s.
        /// </summary>
        public ReadOnlyDictionary<string, FileTransmitterEncoder> FileTransmitterEncoders {
            get;
            private set;
        }

        /// <summary>
        /// Gets the default encoding for transmission part collections containing a single part.
        /// </summary>
        public Type DefaultSinglePartEncoding {
            get {
                return defaultSinglePartEncoding;
            }
        }

        internal void SetDefaultSinglePartEncoding<T>() where T : IEncoding {
            RegisterEncodingIfRequired<T>();
            defaultSinglePartEncoding = typeof(T);
        }

        /// <summary>
        /// Gets the default encoding.
        /// </summary>
        public Type DefaultEncoding {
            get {
                return defaultEncoding;
            }
        }

        /// <summary>
        /// Add a <see cref="FileTransmitterEncoder"/>
        /// </summary>
        /// <param name="encoder"></param>
        public void AddFileTransmitterEncoders(FileTransmitterEncoder encoder) {
            string itemPath = encoder.LocalPath;
            if (FileTransmitterEncoders.ContainsKey(encoder.Id)) {
                throw new JdfException(string.Format("Collection already contains a " + typeof(FileTransmitterEncoder).Name + " with ID={0}", encoder.Id));
            }
            else if (FileTransmitterEncoders.Values.Any(item => item.LocalPath.Equals(encoder.LocalPath, StringComparison.OrdinalIgnoreCase))) {
                throw new JdfException(string.Format("Collection already contains a " + typeof(FileTransmitterEncoder).Name + " with BaseUrl={0}", encoder.UrlBase));
            }
            else {
                fileTransmitterEncoderList[encoder.Id] = encoder;
            }
        }

        internal void SetDefaultEncoding<T>() where T : IEncoding {
            RegisterEncodingIfRequired<T>();
            defaultEncoding = typeof(T);
        }

        /// <summary>
        /// Gets the default encoding for transmission part collections containing multiple parts.
        /// </summary>
        public Type DefaultMultiPartEncoding {
            get {
                return defaultMultiPartEncoding;
            }
        }

        internal void SetDefaultMultiPartEncoding<T>() where T : IEncoding {
            RegisterEncodingIfRequired<T>();
            defaultMultiPartEncoding = typeof(T);
        }

        /// <summary>
        /// Register an encoding for a mime type.
        /// </summary>
        /// <param name="mimeType"></param>
        public void RegisterEncodingForMimeType<T>(string mimeType) where T : IEncoding {
            ParameterCheck.StringRequiredAndNotWhitespace(mimeType, "mimeType");

            RegisterEncodingIfRequired<T>();
            encodingsByMimeType[mimeType] = typeof(T);
        }

        /// <summary>
        /// Reset to defaults.
        /// </summary>
        /// <returns></returns>
        public EncodingSettings ResetToDefaults() {
            encodingsByMimeType.Clear();
            fileTransmitterEncoderList.Clear();
            SetDefaultEncoding<PassThroughEncoding>();
            SetDefaultSinglePartEncoding<PassThroughEncoding>();
            SetDefaultMultiPartEncoding<MimeEncoding>();
            RegisterEncodingForMimeType<MimeEncoding>(MimeTypeHelper.MimeMultipartMimeType);
            return this;
        }

        void RegisterEncodingIfRequired<T>() where T : IEncoding {
            var encodingType = typeof(T);
            if (!Infrastructure.Core.Configuration.Settings.ServiceLocator.CanResolve(typeof(IEncoding), encodingType.FullName)) {
                Infrastructure.Core.Configuration.Settings.ServiceLocator.Register(typeof(IEncoding), encodingType);
            }
        }
    }
}