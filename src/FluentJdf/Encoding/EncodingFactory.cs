using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.Configuration;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Encoding
{
    /// <summary>
    /// Factory to get encodings.
    /// </summary>
    public class EncodingFactory : IEncodingFactory
    {
        /// <summary>
        /// Gets the encoding for the given mime type.
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns>The encoding for the mime type.  If there is no specific kind for the mime type, the default is returned.</returns>
        public IEncoding GetEncodingForMimeType(string mimeType) {
            ParameterCheck.StringRequiredAndNotWhitespace(mimeType, "mimeType");

            if (Library.Settings.EncodingSettings.EncodingsByMimeType.ContainsKey(mimeType)) {
                return Infrastructure.Core.Configuration.Settings.ServiceLocator.Resolve<IEncoding>(Library.Settings.EncodingSettings.EncodingsByMimeType[mimeType]);
            }

            return Infrastructure.Core.Configuration.Settings.ServiceLocator.Resolve<IEncoding>(Library.Settings.EncodingSettings.DefaultEncoding.FullName);
        }

        /// <summary>
        /// Gets the default encoding for transmission part collections
        /// containing a single part.
        /// </summary>
        /// <returns></returns>
        public IEncoding GetDefaultEncodingForSinglePart() {
            return Infrastructure.Core.Configuration.Settings.ServiceLocator.Resolve<IEncoding>(Library.Settings.EncodingSettings.DefaultSinglePartEncoding.FullName);
        }

        /// <summary>
        /// Gets the default encoding for transmission part collections
        /// containing multiple parts.
        /// </summary>
        /// <returns></returns>
        public IEncoding GetDefaultEncodingForMultiPart() {
            return Infrastructure.Core.Configuration.Settings.ServiceLocator.Resolve<IEncoding>(Library.Settings.EncodingSettings.DefaultMultiPartEncoding.FullName);
        }
    }
}
