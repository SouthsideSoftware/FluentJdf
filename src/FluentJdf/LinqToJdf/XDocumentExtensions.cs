using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Extensions to XDocument.
    /// </summary>
    public static class XDocumentExtensions
    {
        /// <summary>
        /// This saves the document to a stream
        /// using UTF8 encoding, no byte markers 
        /// formatted with indentation and each element
        /// on a newline.
        /// </summary>
        /// <remarks></remarks>
        public static void SaveHttpReady(this XDocument document, Stream stream)
        {
            ParameterCheck.ParameterRequired(document, "document");
            ParameterCheck.ParameterRequired(stream, "stream");

            if (stream.CanSeek)
            {
                stream.Seek(0, SeekOrigin.Begin);
            }

            var xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Encoding = new UTF8Encoding(false);
            xmlWriterSettings.Indent = true;
            using (var writer = XmlWriter.Create(stream, xmlWriterSettings))
            {
                document.Save(writer);
            }
        }
    }
}
