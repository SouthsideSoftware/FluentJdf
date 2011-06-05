using System;
using System.Diagnostics.Contracts;
using System.Xml.Linq;
using Jdp.Jdf.Resources;
using Onpoint.Commons.Core.CodeContracts;

namespace Jdp.Jdf.LinqToJdf
{
    /// <summary>
    /// Extensions meant to operate on JDF elements
    /// </summary>
    public static class JdfElementExtensions
    {
        /// <summary>
        /// Add an intent JDF to the current JDF or document
        /// </summary>
        /// <param name="parent"></param>
        /// <returns>The newly created JDF node.</returns>
        public static XElement AddIntentNode(this XContainer parent)
        {
            ParameterCheck.ParameterRequired(parent, "parent");
            
            if (parent is XElement) {
                parent = (parent as XElement).NearestJdf();
            }

            var jdfNode = new XElement(Element.JDF);
            jdfNode.MakeJdfNodeAnIntent();
            parent.Add(jdfNode);

            jdfNode.SetUniqueJobId();

            return jdfNode;
        }

        /// <summary>
        /// Gets the resource pool of the jdf node.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <param name="additionalAction">Additional action to be performed on the resource pool.</param>
        /// <returns></returns>
        /// <remarks>Creates the resource pool if it does not exist.</remarks>
        public static XElement ResourcePool(this XElement jdfNode, Action<XElement> additionalAction = null) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");

            jdfNode.ThrowExceptionIfNotJdfNode();

            var resourcePool = jdfNode.Element(Element.ResourcePool);
            if (resourcePool == null) {
                resourcePool = new XElement(Element.ResourcePool);
                jdfNode.Add(resourcePool);
            }

            if (additionalAction != null) {
                additionalAction(resourcePool);
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
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");

            jdfNode.ThrowExceptionIfNotJdfNode();

            var resourceLinkPool = jdfNode.Element(Element.ResourceLinkPool);
            if (resourceLinkPool == null)
            {
                resourceLinkPool = new XElement(Element.ResourceLinkPool);
                jdfNode.Add(resourceLinkPool);
            }

            return resourceLinkPool;
        }

        /// <summary>
        /// Link an existing resource with the given id as an output.  Promote the resource if required.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <param name="id"></param>
        /// <exception cref="JdfException">If a resource with the given id cannot be found
        /// and promoted without breaking any existing references.</exception>
        /// <returns></returns>
        public static XElement AddOutput(this XElement jdfNode, string id) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            ParameterCheck.StringRequiredAndNotWhitespace(id, "id");

            return jdfNode.LinkResource(ResourceUsage.Input, null, id);
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
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");

            return jdfNode.LinkResource(ResourceUsage.Output, resourceName, id);
        }

        /// <summary>
        /// Link an existing resource with the given id as an input.  Promote the resource if required.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <param name="id"></param>
        /// <exception cref="JdfException">If a resource with the given id cannot be found
        /// and promoted without breaking any existing references.</exception>
        /// <returns></returns>
        public static XElement AddInput(this XElement jdfNode, string id)
        {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            ParameterCheck.StringRequiredAndNotWhitespace(id, "id");

            return jdfNode.LinkResource(ResourceUsage.Input, null, id);
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
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");

            return jdfNode.LinkResource(ResourceUsage.Input, resourceName, id);
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
        /// <returns>The newly linked resource.</returns>
        public static XElement LinkResource(this XElement jdfNode, ResourceUsage usage, XName resourceName = null, string id = null) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");

            var nearestJdf = jdfNode.NearestJdf();

            if (resourceName == null && id == null) {
                throw new ArgumentException(Messages.JdfElementExtensions_LinkResource_ResourceNameOrIdOrBothRequired);
            }

            var resourcePool = nearestJdf.ResourcePool();
            var resourceLinkPool = nearestJdf.ResourceLinkPool();

            XElement resource = null;
            if (id == null)
            {
                id = Globals.CreateUniqueId();
            }
            else {
                resource = jdfNode.GetResourceOrNull(id);
                if (resource == null) {
                    if (resourceName != null) {
                        resource = CreateResource(resourceName, id, resourcePool);
                    }
                    else {
                        throw new JdfException(
                            string.Format(Messages.JdfElementExtensions_LinkResource_CouldNotFindResourceWithGivenIdAndNameWasNotProvided, id));
                    }
                }
            }

            if (resource == null) {
                resource = CreateResource(resourceName, id, resourcePool);
            } else {
                //todo: promote if needed.
            }

            resourceLinkPool.Add(
                new XElement(resource.Name.LinkName(),
                    new XAttribute("rRef", id),
                    new XAttribute("Usage", usage)));

            return resource;
        }

        static XElement CreateResource(XName resourceName, string id, XElement resourcePool) {
            XElement resource;
            resource = new XElement(resourceName,
                                    new XAttribute("ID", id));
            resourcePool.Add(resource);
            return resource;
        }

        /// <summary>
        /// Gets true if the element is a JDF node.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsJdfNode(this XElement element)
        {
            ParameterCheck.ParameterRequired(element, "element");

            return element.Name == Element.JDF;
        }

        /// <summary>
        /// Returns true if the node is a JDF intent node 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsJdfIntentNode(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.IsJdfNode() && element.GetJdfType() == "Product";
        }

        /// <summary>
        /// Gets the type of the node.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetJdfType(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.GetAttributeFromJdfNode("Type");
        }

        /// <summary>
        /// Gets the types of the node.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetJdfTypes(this XElement element)
        {
            ParameterCheck.ParameterRequired(element, "element");

            return element.GetAttributeFromJdfNode("Types");
        }

        /// <summary>
        /// Gets the job id of the node.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetJobId(this XElement element)
        {
            ParameterCheck.ParameterRequired(element, "element");

            return element.GetAttributeFromJdfNode("JobID");
        }

        /// <summary>
        /// Gives the JDF node a unique job id.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static XElement SetUniqueJobId(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.SetJobId(Globals.CreateUniqueId("J"));
        }

        /// <summary>
        /// Sets the job id of the jdf node to the given value.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static XElement SetJobId(this XElement element, string id) {
            ParameterCheck.ParameterRequired(element, "element");

            element.ThrowExceptionIfNotJdfNode();

            element.SetAttributeValue("JobID", id);

            return element;
        }

        /// <summary>
        /// Gets the job part of the node.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetJobPartId(this XElement element)
        {
            ParameterCheck.ParameterRequired(element, "element");

            return element.GetAttributeFromJdfNode("JobPartID");
        }

        static string GetAttributeFromJdfNode(this XElement element, string attributeName) {
            ParameterCheck.ParameterRequired(element, "element");
            ParameterCheck.StringRequiredAndNotWhitespace(attributeName, "attributeName");

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
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
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
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");

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
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            ThrowExceptionIfNotJdfNode(jdfNode);

            jdfNode.SetAttributeValue("Type", type);
            jdfNode.SetAttributeValue("Types", types);

            return jdfNode;
        }
    }
}