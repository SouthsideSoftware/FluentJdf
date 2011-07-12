using System;
using System.Collections.Generic;
using System.Xml.Linq;
using FluentJdf.Resources;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Extensions for working with resources.
    /// </summary>
    public static class ResourceExtensions {
        /// <summary>
        /// Gets the id of an element.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetId(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.GetAttributeValueOrNull("ID");
        }

        /// <summary>
        /// Sets a unique id for the resource and optionally updates the references.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="updateReferences">True to update references.  Default is true.</param>
        public static XElement SetUniqueId(this XElement element, bool updateReferences = true) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.SetUniqueId("R_", updateReferences);
        }

        /// <summary>
        /// Sets a unique id for the resource and optionally updates the references.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="idPrefix">The prefix to use in front of the GUID ID.  Default is "R_".</param>
        /// <param name="updateReferences">True to update references.  Default is true.</param>
        public static XElement SetUniqueId(this XElement element, string idPrefix, bool updateReferences = true) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.SetId(Globals.CreateUniqueId(idPrefix), updateReferences);
        }

        /// <summary>
        /// Sets a unique id on this element if it has an id and any of its
        /// descendants that have an id.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="idPrefix"></param>
        /// <param name="updateReferences"></param>
        /// <returns></returns>
        public static XElement RecursiveSetUniqueId(this XElement element, string idPrefix = "R_", bool updateReferences = true) {
            ParameterCheck.ParameterRequired(element, "element");

            if (element.GetId() != null) {
                element.SetUniqueId(idPrefix, updateReferences);
            }
            foreach (var child in element.Elements()) {
                child.RecursiveSetUniqueId(idPrefix, updateReferences);
            }

            return element;
        }

        /// <summary>
        /// Sets the id of a resource and optionally updates the references.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="id"></param>
        /// <param name="updateReferences">True to update references.  Default is <see langword="true"/>.</param>
        public static XElement SetId(this XElement element, string id, bool updateReferences = true) {
            ParameterCheck.ParameterRequired(element, "element");
            ParameterCheck.StringRequiredAndNotWhitespace(id, "id");

            if (updateReferences) {
                foreach (var referencingElement in element.ReferencingElements()) {
                    referencingElement.SetRefId(id);
                }
            }
            element.SetAttributeValue("ID", id);

            return element;
        }

        /// <summary>
        /// Given a resource name and the input type, return the resolved resource that belongs to the resource link.
        /// </summary>
        /// <remarks>
        /// It is assumed that the element should stay untouched and not be normalized.
        /// </remarks>
        /// <param name="element">The element to process</param>
        /// <param name="resourceName">The resource name</param>
        /// <param name="usage">The <see cref="ResourceUsage"/></param>
        /// <returns></returns>
        public static XElement GetResourceLinkPoolResolvedItem(this XContainer element, string resourceName, ResourceUsage usage) {
            ParameterCheck.ParameterRequired(element, "element");
            ParameterCheck.StringRequiredAndNotWhitespace(resourceName, "resourceName");

            if (!resourceName.EndsWith("Link")) {
                resourceName += "Link";
            }
            var xpath = string.Format("//ResourceLinkPool/{0}[@Usage = '{1}']", resourceName, usage.ToString());
            var resourceLinkNode = element.JdfXPathSelectElement(xpath);
            if (resourceLinkNode != null) {
                var resourceLink = element.JdfXPathSelectElement(string.Format("//ResourcePool/*[@ID = '{0}']", resourceLinkNode.Attribute("rRef").Value));
                if (resourceLink != null) {
                    return resourceLink;
                }
            }
            return null;
        }

        /// <summary>
        /// Given a resource name and the input type, return the resolved resource that belongs to all resource links.
        /// </summary>
        /// <remarks>
        /// It is assumed that the element should stay untouched and not be normalized.
        /// </remarks>
        /// <param name="elements">The elements to process</param>
        /// <param name="usage">The <see cref="ResourceUsage"/></param>
        /// <returns></returns>
        public static IEnumerable<XElement> GetCurrentJDFResourceLinkPoolResolvedItemForUsage(this IEnumerable<XContainer> elements, ResourceUsage usage) {
            foreach (var element in elements) {
                foreach (var result in element.GetCurrentJDFResourceLinkPoolResolvedItemForUsage(usage)) {
                    yield return result;
                }
            }
        }

        /// <summary>
        /// Given a resource name and the input type, return the resolved resource that belongs to all resource links.
        /// </summary>
        /// <remarks>
        /// It is assumed that the element should stay untouched and not be normalized.
        /// </remarks>
        /// <param name="element">The element to process</param>
        /// <param name="usage">The <see cref="ResourceUsage"/></param>
        /// <returns></returns>
        public static IEnumerable<XElement> GetCurrentJDFResourceLinkPoolResolvedItemForUsage(this XContainer element, ResourceUsage usage) {
            ParameterCheck.ParameterRequired(element, "element");

            var xpath = string.Format("./ResourceLinkPool/*[@Usage = '{0}']", usage.ToString());
            var resourceLinkNodes = element.JdfXPathSelectElements(xpath);
            foreach (var resourceLinkNode in resourceLinkNodes) {
                var resourceLink = element.JdfXPathSelectElement(string.Format("//ResourcePool/*[@ID = '{0}']", resourceLinkNode.Attribute("rRef").Value));
                if (resourceLink != null) {
                    yield return resourceLink;
                }
            }
        }

        /// <summary>
        /// Gets all elements that reference the current element
        /// </summary>
        /// <param name="element"></param>
        /// <returns>An enumerable over the elements that reference the current element.</returns>
        /// <remarks><para>This method searches from the root of the tree so it finds legally and
        /// illegally linked elements.</para><para>If the element has no id, an empty enumerator is returned.</para></remarks>
        public static IEnumerable<XElement> ReferencingElements(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            string id = element.GetId();

            if (id == null)
                return new List<XElement>();

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
        public static string GetRefId(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

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
            ParameterCheck.ParameterRequired(element, "element");

            element.SetAttributeValue("rRef", refId);

            return element;
        }

        /// <summary>
        /// Gets the usage of the resource link.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static ResourceUsage GetUsage(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");
            element.ThrowExceptionIfNotResourceLink();

            var usage = ResourceUsage.Unknown;
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
            ParameterCheck.ParameterRequired(element, "element");

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
            ParameterCheck.ParameterRequired(element, "element");

            return ((element.Parent == null || element.Parent.IsResourceLinkPool()) && element.Name.LocalName.EndsWith("Link"));
        }

        /// <summary>
        /// Gets true if the element is a resource pool.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsResourcePool(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.Name == Element.ResourcePool;
        }

        /// <summary>
        /// Gets true if the element is a resource link pool
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsResourceLinkPool(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.Name == Element.ResourceLinkPool;
        }

        /// <summary>
        /// Returns the first element with the given id starting in the root JDF.
        /// Returns null if there is no JDF root or no element with the ID is found.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static XElement GetResourceOrNull(this XElement element, string id) {
            ParameterCheck.ParameterRequired(element, "element");
            ParameterCheck.StringRequiredAndNotWhitespace(id, "id");

            XElement resource = null;

            var root = element.GetJdfRootOrNull();
            if (root != null) {
                resource = root.JdfXPathSelectElement(string.Format("//*[@ID='{0}']", id));
            }

            return resource;

        }

        /// <summary>
        /// Returns the first element with the given id.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="JdfException">If no element with the given id is found anywhere in the tree.</exception>
        public static XElement Resource(this XElement element, string id) {
            ParameterCheck.ParameterRequired(element, "element");

            var resource = element.GetResourceOrNull(id);
            if (resource == null) {
                throw new JdfException(string.Format(Messages.ResourceExtensions_Resource_ResourceWithIdCannotBeFound, id));
            }

            return resource;
        }
    }
}
