using System.Collections.Generic;
using FluentJdf.Encoding;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Settings for encoding.
    /// </summary>
    public class EncodingSettings {
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
        /// Gets the default encoding.
        /// </summary>
        public string DefaultEncoding { get; internal set; }

        /// <summary>
        /// Reset to defaults.
        /// </summary>
        /// <returns></returns>
        public EncodingSettings ResetToDefault() {
            EncodingsByMimeType.Clear();
            DefaultEncoding = typeof (PassThroughEncoding).Name;
            return this;
        }
    }
}