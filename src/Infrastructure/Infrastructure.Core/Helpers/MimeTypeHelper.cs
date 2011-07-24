using System;
using System.Collections.Generic;
using System.IO;
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
    public static class MimeTypeHelper {
        /// <summary>
        /// Gets the standard mime type for PDF
        /// </summary>
        public const string PdfMimeType = "application/pdf";

        /// <summary>
        /// Gets the standard mime type for JDF
        /// </summary>
        public const string JdfMimeType = "application/vnd.cip4-jdf+xml";

        /// <summary>
        /// Gets the standard mime type for JMF
        /// </summary>
        public const string JmfMimeType = "application/vnd.cip4-jmf+xml";

        /// <summary>
        /// Gets the standard mime type for mime multipart
        /// </summary>
        public const string MimeMultipartMimeType = "multipart/related";

        /// <summary>
        /// Gets the standard mime type for xml.
        /// </summary>
        public const string XmlMimeType = "text/xml";

        /// <summary>
        /// Gets the standard extension for JDF
        /// </summary>
        public const string JdfExtension = ".jdf";

        /// <summary>
        /// Gets the standard extension for JMF.
        /// </summary>
        public const string JmfExtension = ".jmf";

        /// <summary>
        /// Gets the standard extension for xml.
        /// </summary>
        public const string XmlExtension = ".xml";

        /// <summary>
        /// Extension for PNG files.
        /// </summary>
        public const string PngExtension = ".png";

        /// <summary>
        /// PNG mime type
        /// </summary>
        public const string PngMimeType = "image/png";

        /// <summary>
        /// JPEG extension
        /// </summary>
        public const string JpegExtension = ".jpg";

        /// <summary>
        /// JPEG mime type
        /// </summary>
        public const string JpegMimeType = "image/jpeg";

        /// <summary>
        /// GIF extension.
        /// </summary>
        public const string GifExtension = ".gif";

        /// <summary>
        /// GIF mime type.
        /// </summary>
        public const string GifMimeType = "image/gif";

        /// <summary>
        /// Gets the standard extension for mime where the first part if JDF
        /// </summary>
        public const string MimeJdfFirstPartExtension = ".mjd";

        /// <summary>
        /// Gets the standard extension for mime when the first part is JMF.
        /// </summary>
        public const string MimeJmfFirstPartExtension = ".mjm";

        /// <summary>
        /// Gets the standard extension for PDF.
        /// </summary>
        public const string PdfExtension = ".pdf";

        /// <summary>
        /// Gets the HTML mime type.
        /// </summary>
        public const string HtmlMimeType = "text/html";

        /// <summary>
        /// Gets the Text mime type.
        /// </summary>
        public const string TextMimeType = "text/plain";

        /// <summary>
        /// Gets the standard extension for html files.
        /// </summary>
        public const string HtmlMimeTypeExtension = ".htm";

        /// <summary>
        /// Gets the mime type of the given extension or file name.
        /// </summary>
        /// <param name="fileNameOrExtension"></param>
        /// <returns></returns>
        /// <remarks>Returns standard types for pdf. jdf, jmf, mjd (mime with JDF first), and mjm (mime with JMF first),
        /// goes to registry for other types and returns application/octet-stream
        /// if type cannot be found.
        /// </remarks>
        public static string MimeType(this string fileNameOrExtension) {
            ParameterCheck.ParameterRequired(fileNameOrExtension, "fileNameOrExtension");

            string normalizedExtension = GetNormalizedExtension(fileNameOrExtension);

            switch (normalizedExtension) {
                case PdfExtension:
                    return PdfMimeType;
                case JdfExtension:
                    return JdfMimeType;
                case JmfExtension:
                    return JmfMimeType;
                case MimeJdfFirstPartExtension:
                    return MimeMultipartMimeType;
                case MimeJmfFirstPartExtension:
                    return MimeMultipartMimeType;
                case XmlExtension:
                    return XmlMimeType;
            }
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(normalizedExtension);
            if (key != null)
            {
                return (string)key.GetValue("Content Type");
            }

            return "application/octet-stream";
        }

        static string GetNormalizedExtension(string fileNameOrExtension) {
            var normalizedExtension = string.Copy(fileNameOrExtension);
            normalizedExtension = Path.GetExtension(fileNameOrExtension);
            if (string.IsNullOrWhiteSpace(normalizedExtension) && !fileNameOrExtension.StartsWith(".")) {
                normalizedExtension = "." + string.Copy(fileNameOrExtension);
            }
            normalizedExtension = normalizedExtension.ToLower();
            return normalizedExtension;
        }

        /// <summary>
        /// Gets the mime type of the given extension or file name.
        /// </summary>
        /// <param name="fileNameOrExtension"></param>
        /// <returns></returns>
        /// <remarks>Returns standard types for pdf. jdf, jmf, mjd (mime with JDF first), and mjm (mime with JMF first),
        /// goes to registry for other types and returns application/octet-stream
        /// if type cannot be found.
        /// </remarks>
        public static string MimeTypeOf(string fileNameOrExtension) {
            ParameterCheck.ParameterRequired(fileNameOrExtension, "fileNameOrExtension");

            return fileNameOrExtension.MimeType();
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
                case PdfMimeType:
                    return PdfExtension;
                case XmlMimeType:
                    return XmlExtension;
                case JdfMimeType:
                    return JdfExtension;
                case JmfMimeType:
                    return JmfExtension;
                case MimeMultipartMimeType:
                    //todo: Can't tell from mime type so we just guess the most likely.  Is this OK?
                    return MimeJmfFirstPartExtension;
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
