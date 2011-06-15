using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Helpers;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Extensions for working with xelements that may or 
    /// may not be jdf nodes.
    /// </summary>
    public static class XElementExtensions
    {
        /// <summary>
        /// Gets the mime type associated with the given node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static string MimeType(this XContainer node)
        {
            ParameterCheck.ParameterRequired(node, "node");

            XElement element;
            if (node is XDocument) {
                if (node.Document.Root != null) {
                    element = node.Document.Root;
                }
                else {
                    return MimeTypeHelper.XmlMimeType;
                }
            }
            else {
                element = node as XElement;
            }
            if (element.Name == Element.JDF) return MimeTypeHelper.JdfMimeType;
            if (element.Name == Element.JMF) return MimeTypeHelper.JmfMimeType;
            return MimeTypeHelper.XmlMimeType;
        }
    }
}
