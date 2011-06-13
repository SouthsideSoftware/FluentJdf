using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Core.CodeContracts;
using Microsoft.Win32;

namespace Infrastructure.Core.Helpers
{
    //todo: add hard-coded support for jdf and jmf mime types

    /// <summary>
    /// Helpers for looking up mime types of extensions and vice versa.
    /// The pdf, jdf, and jmf mime types are hard-coded.  The rest
    /// rely on the registry.
    /// </summary>
    public static class MimeTypeHelper
    {
        /// <summary>
        /// Gets the mime type of the given extension.
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        /// <remarks>Returns application/pdf for pdf files,
        /// goes to registry for other types and returns application/octet-stream
        /// if type cannot be found.
        /// </remarks>
        public static string MimeType(this string extension) {
            ParameterCheck.ParameterRequired(extension, "extension");

            var parsedExtension = string.Copy(extension);
            if (!parsedExtension.StartsWith(".")) {
                parsedExtension = "." + parsedExtension;
            }
            parsedExtension = parsedExtension.ToLower();

            switch (parsedExtension) {
                case ".pdf":
                    return "application/pdf";
            }
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(parsedExtension);
            if (key != null)
            {
                return (string)key.GetValue("Content Type");
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Gets the mime type of the given extension.
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        /// <remarks>Returns application/pdf for pdf files,
        /// goes to registry for other types and returns application/octet-stream
        /// if type cannot be found.
        /// </remarks>
        public static string MimeTypeOf(string extension) {
            ParameterCheck.ParameterRequired(extension, "extension");

            return extension.MimeType();
        }

        /// <summary>
        /// Gets the extension (including the '.') associated
        /// with the given mime type.
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        /// <remarks>If the mime type cannot be found, the 
        /// returned extension is '.unknown'.</remarks>
        public static string MimeTypeExtension(this string mimeType) {
            ParameterCheck.ParameterRequired(mimeType, "mimeType");

            var parsedMimeType = string.Copy(mimeType);
            parsedMimeType = parsedMimeType.ToLower();

            switch (parsedMimeType) {
                case "application/pdf":
                    return ".pdf";
            }

            RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\" + parsedMimeType);
            if (key != null)
            {
                return (string)key.GetValue("Extension");
            }

            return ".unkown";
        }

        /// <summary>
        /// Gets the extension (including the '.') associated
        /// with the given mime type.
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        /// <remarks>If the mime type cannot be found, the 
        /// returned extension is '.unknown'.</remarks>
        public static string MimeTypeExtensionOf(string mimeType) {
            ParameterCheck.ParameterRequired(mimeType, "mimeType");

            return mimeType.MimeTypeExtension();
        }
    }
}
