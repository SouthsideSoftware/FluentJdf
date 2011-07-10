using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using FluentJdf.Utility;
using Infrastructure.Core;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Helpers;

namespace FluentJdf.Transmission.Logging {
    /// <summary>
    /// Represents request or response data related
    /// to a web request.
    /// </summary>
    public class TransmissionData {
        string title = null;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="contentType">Optional mime type of the request.  Defaults
        /// to HTML (text/html).</param>
        /// <param name="title">If title is null, the default log entry title will be used.</param>
        public TransmissionData(Stream stream, string contentType = MimeTypeHelper.HtmlMimeType, string title = null)
            : this(new NameValueCollection {{"content-type", contentType}}, stream, title) {
            ParameterCheck.StringRequiredAndNotWhitespace(contentType, "contentType");
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="headers"></param>
        /// <param name="stream"></param>
        /// <param name="title">If title is null, the default log entry title will be used.</param>
        public TransmissionData(NameValueCollection headers, Stream stream, string title = null) {
            ParameterCheck.ParameterRequired(headers, "headers");
            ParameterCheck.ParameterRequired(stream, "stream");

            this.title = title;
            if (stream.CanSeek) {
                Stream = stream;
            }
            else {
                Stream = new TempFileStream();
                using (stream) {
                    stream.CopyTo(Stream);
                }
            }
            Stream.Seek(0, SeekOrigin.Begin);

            if (headers["content-type"] != null) {
                ContentType = headers["content-type"].NormalizeContentType();
            }
            else {
                ContentType = MimeTypeHelper.HtmlMimeType;
            }
            Headers = headers;
        }

        /// <summary>
        /// Gets the headers.
        /// </summary>
        public NameValueCollection Headers { get; private set; }

        /// <summary>
        /// Gets the stream.
        /// </summary>
        public Stream Stream { get; private set; }

        /// <summary>
        /// Gets the content type.
        /// </summary>
        /// <remarks>
        /// <para>Default is text/html.</para>
        /// <para>If content type header passed in constructor contains
        /// a char-encoding or other qualifiers, they are stripped off.</para>
        /// </remarks>
        public string ContentType { get; private set; }


        /// <summary>
        /// Gets the diagnostic logging string for this
        /// transmission data.  Stream is not included
        /// because it may be too large for conversion
        /// to a string.
        /// </summary>
        /// <returns></returns>
        public string ToLogString() {
            var sb = new StringBuilder();
            sb.AppendLine("*****************************");
            sb.AppendLine(title ?? LogEntryTitle);
            sb.AppendLine("-----------------------------");
            var nameValuePairs = new SortedDictionary<string, string>();
            AppendDataToLog(nameValuePairs);
            foreach (string key in nameValuePairs.Keys) {
                sb.AppendFormat("{0} = {1}\n", key, nameValuePairs[key]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Override this to add additional properties to the 
        /// diagnostic logging string.
        /// </summary>
        /// <param name="nameValuePairs"></param>
        protected virtual void AppendDataToLog(SortedDictionary<string, string> nameValuePairs) {
            nameValuePairs.Add("ContentType", ContentType);
            foreach (string key in Headers.Keys) {
                nameValuePairs.Add(string.Format("Header:{0}", key), Headers[key]);
            }    
        }


        /// <summary>
        /// Override this to put a title on the diagnostic logging string.
        /// </summary>
        protected virtual string LogEntryTitle { get { return "Transmission"; } }
    }
}