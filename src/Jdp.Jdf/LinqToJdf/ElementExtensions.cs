using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Jdp.Jdf.LinqToJdf
{
    /// <summary>
    /// Extensions useful for all kinds of JDF nodes
    /// </summary>
    public static class ElementExtensions
    {
        /// <summary>
        /// Gets the DescriptiveName.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetDescriptiveName(this XElement element)
        {
            Contract.Requires(element != null);

            return element.GetAttributeValueOrNull("DescriptiveName");
        }

        /// <summary>
        /// Adds arbitrary content to the element.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static XElement AddContent(this XElement element, params Object[] content) {
            Contract.Requires(element != null);
            Contract.Requires(content != null);
            Contract.Requires(content.Length > 0);

            element.Add(content);
            return element;
        }
    }
}
