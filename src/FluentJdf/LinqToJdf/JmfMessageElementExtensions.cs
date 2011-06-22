using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Extensions for JMF messages (i.e. command, query, signal etc.).
    /// </summary>
    public static class JmfMessageElementExtensions
    {
        /// <summary>
        /// Gets the Type attribute.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetMessageType(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.GetAttributeValueOrNull("Type");
        }

        /// <summary>
        /// Sets the Type attribute.
        /// </summary>
        /// <returns></returns>
        public static XElement SetMessageType(this XElement element, string type)
        {
            ParameterCheck.ParameterRequired(element, "element");

            element.SetAttributeValue("Type", type);

            return element;
        }
    }
}
