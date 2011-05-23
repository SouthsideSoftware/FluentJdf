using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Jdp.Jdf.Resources;

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
        /// Sets the DescriptiveName.
        /// </summary>
        /// <returns></returns>
        public static XElement SetDescriptiveName(this XElement element, string value)
        {
            Contract.Requires(element != null);

            element.SetAttributeValue("DescriptiveName", value);

            return element;
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

        /// <summary>
        /// Get the first parent of this element that is a JDF.  
        /// </summary>
        /// <param name="element"></param>
        /// <returns>The first JDF parent</returns>
        /// <exception cref="JdfException">If there is no JDF parent.</exception>
        public static XElement JdfParent(this XElement element) {
            Contract.Requires(element != null);

            var jdfParent = element.GetJdfParentOrNull();
            if (jdfParent == null) {
                throw new JdfException(string.Format(Messages.ElementExtensions_JdfParent_NoJdfParentFound, element.Name));
            }

            return jdfParent;
        }

        /// <summary>
        /// Gets the first jdf parent of this element or null.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static XElement GetJdfParentOrNull(this XElement element) {
            Contract.Requires(element != null);

            if (element.Parent != null) {
                return element.Parent.IsJdfNode() ? element.Parent : element.Parent.GetJdfParentOrNull();
            }

            return null;
        }
    }
}
