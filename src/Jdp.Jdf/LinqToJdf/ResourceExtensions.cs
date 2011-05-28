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
    /// Extensions for working with resources.
    /// </summary>
    public static class ResourceExtensions
    {
        /// <summary>
        /// Gets the id of an element.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetId(this XElement element)
        {
            Contract.Requires(element != null);

            return element.GetAttributeValueOrNull("ID");
        }

        /// <summary>
        /// Sets a unique id for the resource and optionally updates the references.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="updateReferences">True to update references.  Default is true.</param>
        public static XElement SetUniqueId(this XElement element, bool updateReferences = true)
        {
            Contract.Requires(element != null);

            return element.SetId(Globals.CreateUniqueId(), updateReferences);
        }

        /// <summary>
        /// Sets the id of a resource and optionally updates the references.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="id"></param>
        /// <param name="updateReferences">True to update references.  Default is <see langword="true"/>.</param>
        public static XElement SetId(this XElement element, string id, bool updateReferences = true) {
            Contract.Requires(element != null);

            if (updateReferences)
            {
                foreach (var referencingElement in element.ReferencingElements())
                {
                    referencingElement.SetRefId(id);
                }
            }
            element.SetAttributeValue("ID", id);

            return element;
        }

        /// <summary>
        /// Gets all elements that reference the current element
        /// </summary>
        /// <param name="element"></param>
        /// <returns>An enumerable over the elements that reference the current element.</returns>
        /// <remarks><para>This method searches from the root of the tree so it finds legally and
        /// illegally linked elements.</para><para>If the element has no id, an empty enumerator is returned.</para></remarks>
        public static IEnumerable<XElement> ReferencingElements(this XElement element) {
            Contract.Requires(element != null);

            string id = element.GetId();
            
            if (id == null) return new List<XElement>();

            var root = element;
            if (root.Document != null && root.Document.Root != null) {
                root = root.Document.Root;
            }

            return root.JdfXPathSelectElements(string.Format("//*[@rRef='{0}']", id));
        }

        /// <summary>
        /// Gets the rRef of an element.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetRefId(this XElement element)
        {
            Contract.Requires(element != null);

            return element.GetAttributeValueOrNull("rRef");
        }

        /// <summary>
        /// Sets the rRef of the element.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="refId"></param>
        /// <returns></returns>
        /// <remarks>This method will break the link to the referenced
        /// element.  Use SetId on the referenced element if you want
        /// to maintain all links.</remarks>
        public static XElement SetRefId(this XElement element, string refId) {
            Contract.Requires(element != null);
            Contract.Requires(!string.IsNullOrEmpty(refId));

            element.SetAttributeValue("rRef", refId);

            return element;
        }

        /// <summary>
        /// Gets the usage of the resource link.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static ResourceUsageType GetUsage(this XElement element) {
            Contract.Requires(element != null);
            element.ThrowExceptionIfNotResourceLink();

            var usage = ResourceUsageType.Unknown;
            var usageString = element.GetAttributeValueOrNull("Usage");
            if (!string.IsNullOrWhiteSpace(usageString)) {
                Enum.TryParse(usageString, true, out usage);
            }

            return usage;
        }

        /// <summary>
        /// Throw an ArgumentException if the element is not a resource link.
        /// </summary>
        /// <param name="element"></param>
        public static void ThrowExceptionIfNotResourceLink(this XElement element) {
            Contract.Requires(element != null);

            if (!IsResourceLink(element)) {
                throw new ArgumentException(string.Format(Messages.CanOnlyOperateOnResourceLink, element.Name));
            }
        }

        /// <summary>
        /// Gets true if the element is a resource link
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsResourceLink(this XElement element) {
            Contract.Requires(element != null);

            return ((element.Parent == null || element.Parent.IsResourceLinkPool()) && element.Name.LocalName.EndsWith("Link"));
        }

        /// <summary>
        /// Gets true if the element is a resource pool.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsResourcePool(this XElement element) {
            Contract.Requires(element != null);

            return element.Name == Element.ResourcePool;
        }

        /// <summary>
        /// Gets true if the element is a resource link pool
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsResourceLinkPool(this XElement element)
        {
            Contract.Requires(element != null);

            return element.Name == Element.ResourceLinkPool;
        }
    }
}
