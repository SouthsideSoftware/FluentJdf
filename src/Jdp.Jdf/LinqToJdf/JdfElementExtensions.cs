using System;
using System.Diagnostics.Contracts;
using System.Xml.Linq;
using Jdp.Jdf.Resources;

namespace Jdp.Jdf.LinqToJdf
{
    /// <summary>
    /// Extensions meant to operate on JDF elements
    /// </summary>
    public static class JdfElementExtensions
    {
        /// <summary>
        /// Add an intent JDF to the current JDF
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="jdfNodeCreationAttributes"></param>
        /// <returns></returns>
        public static XElement AddItentNode(this XContainer parent,
                                               JdfNodeCreationAttributes jdfNodeCreationAttributes = null)
        {
            Contract.Requires(parent != null);
            if (parent is XElement)
            {
                (parent as XElement).ThrowExceptionIfNotJdfNode();
            }

            if (jdfNodeCreationAttributes == null)
            {
                jdfNodeCreationAttributes = new JdfNodeCreationAttributes();
            }

            var jdfNode = new XElement(ElementNames.JDF);
            jdfNode.SetAttributeValue("JobID", jdfNodeCreationAttributes.JobId);
            jdfNode.SetAttributeValue("JobPartID", jdfNodeCreationAttributes.JobPartid);
            jdfNode.SetAttributeValue("DescriptiveName", jdfNodeCreationAttributes.DescriptiveName);
            jdfNode.MakeJdfNodeAnIntent();
            parent.Add(jdfNode);

            return jdfNode;
        }

        /// <summary>
        /// Gets the resource pool of the jdf node.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <returns></returns>
        /// <remarks>Creates the resource pool if it does not exist.</remarks>
        public static XElement ResourcePool(this XElement jdfNode) {
            Contract.Requires(jdfNode != null);
            jdfNode.ThrowExceptionIfNotJdfNode();

            var resourcePool = jdfNode.Element(ElementNames.ResourcePool);
            if (resourcePool == null) {
                resourcePool = new XElement(ElementNames.ResourcePool);
                jdfNode.Add(resourcePool);
            }

            return resourcePool;
        }

        /// <summary>
        /// Gets the resource link pool of the jdf node.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <returns></returns>
        /// <remarks>Creates the resource link pool if it does not exist.</remarks>
        public static XElement ResourceLinkPool(this XElement jdfNode)
        {
            Contract.Requires(jdfNode != null);
            jdfNode.ThrowExceptionIfNotJdfNode();

            var resourceLinkPool = jdfNode.Element(ElementNames.ResourceLinkPool);
            if (resourceLinkPool == null)
            {
                resourceLinkPool = new XElement(ElementNames.ResourceLinkPool);
                jdfNode.Add(resourceLinkPool);
            }

            return resourceLinkPool;
        }

        /// <summary>
        /// Link a resource with the given name and id as an output.  If the id is null or
        /// not provided, generate a unique id.  If
        /// the resource does not exist in the current jdf or its ancestors, 
        /// check descendants.  If it is found in the descendants, promote it.  If not in the 
        /// ancestors or descendants, create it.
        /// </summary>
        /// <remarks>If you do not pass an id (or you pass a null id), a new resource will
        /// always be created.</remarks>
        /// <returns></returns>
        public static XElement AddOutput(this XElement jdfNode, XName resourceName, string id = null)
        {
            Contract.Requires(jdfNode != null);

            return jdfNode.LinkResource(ResourceUsageType.Output, resourceName, id);
        }

        /// <summary>
        /// Link a resource with the given name and id as an input.  If the id is null or
        /// not provided, generate a unique id.  If
        /// the resource does not exist in the current jdf or its ancestors, 
        /// check descendants.  If it is found in the descendants, promote it.  If not in the 
        /// ancestors or descendants, create it.
        /// </summary>
        /// <remarks>If you do not pass an id (or you pass a null id), a new resource will
        /// always be created.</remarks>
        public static XElement AddInput(this XElement jdfNode, XName resourceName, string id = null)
        {
            Contract.Requires(jdfNode != null);

            return jdfNode.LinkResource(ResourceUsageType.Input, resourceName, id);
        }

        /// <summary>
        /// Link a resource with the given name and id with the given usage.  If the id is null or
        /// not provided, generate a unique id.  If
        /// the resource does not exist in the current jdf or its ancestors, 
        /// check descendants.  If it is found in the descendants, promote it.  If not in the 
        /// ancestors or descendants, create it.
        /// </summary>
        /// <remarks>If you do not pass an id (or you pass a null id), a new resource will
        /// always be created.</remarks>
        public static XElement LinkResource(this XElement jdfNode, ResourceUsageType usage, XName resourceName, string id = null) {
            Contract.Requires(jdfNode != null);
            Contract.Requires(resourceName != null);
            jdfNode.ThrowExceptionIfNotJdfNode();

            if (id == null) {
                id = Globals.CreateUniqueId();
            }

            var resourcePool = jdfNode.ResourcePool();
            var resourceLinkPool = jdfNode.ResourceLinkPool();

            resourcePool.Add(
                new XElement(resourceName,
                    new XAttribute("ID", id)));

            resourceLinkPool.Add(
                new XElement(resourceName.LinkName(),
                    new XAttribute("rRef", id),
                    new XAttribute("Usage", usage)));

            return jdfNode;
        }

        /// <summary>
        /// Gets true if the element is a JDF node.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsJdfNode(this XElement element)
        {
            Contract.Requires(element != null);

            return element.Name == ElementNames.JDF;
        }

        /// <summary>
        /// Returns true if the node is a JDF intent node 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsJdfIntentNode(this XElement element) {
            Contract.Requires(element != null);

            return element.IsJdfNode() && element.GetJdfType() == "Product";
        }

        /// <summary>
        /// Gets the type of the node.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetJdfType(this XElement element) {
            Contract.Requires(element != null);

            return element.GetAttributeFromJdfNode("Type");
        }

        /// <summary>
        /// Gets the types of the node.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetJdfTypes(this XElement element)
        {
            Contract.Requires(element != null);

            return element.GetAttributeFromJdfNode("Types");
        }

        /// <summary>
        /// Gets the job id of the node.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetJobId(this XElement element)
        {
            Contract.Requires(element != null);

            return element.GetAttributeFromJdfNode("JobID");
        }

        /// <summary>
        /// Gets the job part of the node.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetJobPartId(this XElement element)
        {
            Contract.Requires(element != null);

            return element.GetAttributeFromJdfNode("JobPartID");
        }

        static string GetAttributeFromJdfNode(this XElement element, string attributeName) {
            Contract.Requires(element != null);
            Contract.Requires(!string.IsNullOrEmpty(attributeName));

            element.ThrowExceptionIfNotJdfNode();

            return element.GetAttributeValueOrNull(attributeName);
        }

        /// <summary>
        /// Make the JDF node an intent node.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <returns></returns>
        public static XElement MakeJdfNodeAnIntent(this XElement jdfNode)
        {
            Contract.Requires(jdfNode != null);
            jdfNode.ThrowExceptionIfNotJdfNode();

            jdfNode.SetTypeAndTypes("Product");

            return jdfNode;
        }

        /// <summary>
        /// Throws an ArgumentException if the given node is not a JDF node.
        /// </summary>
        /// <param name="jdfNode"></param>
        public static void ThrowExceptionIfNotJdfNode(this XElement jdfNode)
        {
            Contract.Requires(jdfNode != null);

            if (!jdfNode.IsJdfNode())
            {
                throw new ArgumentException(string.Format(Messages.CanOnlyOperateOnJdfNode,
                                                          jdfNode.Name));
            }
        }

        /// <summary>
        /// Set type and optionally types of a JDF node.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <param name="type"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        public static XElement SetTypeAndTypes(this XElement jdfNode, string type, string types = null)
        {
            Contract.Requires(jdfNode != null);
            ThrowExceptionIfNotJdfNode(jdfNode);

            jdfNode.SetAttributeValue("Type", type);
            jdfNode.SetAttributeValue("Types", types);

            return jdfNode;
        }
    }
}