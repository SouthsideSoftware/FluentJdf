using System;
using System.Diagnostics.Contracts;
using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf.Configuration;
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
        public static XElement AddIntentElement(this XContainer parent) {
            ParameterCheck.ParameterRequired(parent, "parent");

            return parent.AddJdfElement("Product");
        }

        /// <summary>
        /// Add a process JDF to the current JDF or document
        /// </summary>
        /// <returns>The newly created JDF node.</returns>
        /// <remarks>If no types are passed, a process group node is created.</remarks>
        public static XElement AddProcessJdfElement(this XContainer parent, params string[] types)
        {
            ParameterCheck.ParameterRequired(parent, "parent");

            return parent.AddJdfElement(types);
        }

        /// <summary>
        /// Add a process group JDF to the current JDF or document
        /// </summary>
        /// <returns>The newly created JDF node.</returns>
        public static XElement AddProcessGroupElement(this XContainer parent)
        {
            ParameterCheck.ParameterRequired(parent, "parent");

            return parent.AddJdfElement("ProcessGroup");
        }

        /// <summary>
        /// Add a JDF node to the current JDF or document
        /// </summary>
        /// <returns>The newly created JDF node.</returns>
        public static XElement AddJdfElement(this XContainer parent, params string [] types)
        {
            ParameterCheck.ParameterRequired(parent, "parent");

            if (parent is XElement)
            {
                parent = (parent as XElement).NearestJdf();
            }

            var jdfNode = new XElement(Element.JDF);
            jdfNode.MakeJdfElementAProcess(types);
            parent.Add(jdfNode);

            jdfNode.SetUniqueJobId();

            if (jdfNode.IsJdfRoot() && JdpLibrary.Settings.AddCreateAuditOnNewRootJdf) {
                jdfNode.AddAudit(Audit.Created);
            }

            return jdfNode;
        }

        /// <summary>
        /// Add an audit to the JDF's audit pool.
        /// </summary>
        /// <returns></returns>
        /// <remarks>Configured values for author, agent name and 
        /// agent version are used if they are not passed.</remarks>
        public static XElement AddAudit(this XElement jdfNode, XName auditName, string author = null, DateTime? eventDateTime = null, string agentName = null, string agentVersion = null) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            ParameterCheck.ParameterRequired(auditName, "auditName");
            jdfNode.ThrowExceptionIfNotJdfElement();

            if (agentName == null) {
                agentName = JdpLibrary.Settings.AgentName;
            }
            if (agentVersion == null)
            {
                agentVersion = JdpLibrary.Settings.AgentVersion;
            }
            if (author == null)
            {
                author = JdpLibrary.Settings.Author;
            }
            if (eventDateTime == null) {
                eventDateTime = DateTime.UtcNow;
            }

            var auditPool = jdfNode.AuditPoolElement();
            auditPool.Add(new XElement(auditName, 
                new XAttribute("AgentName", agentName),
                new XAttribute("AgentVersion", agentVersion),
                new XAttribute("Author", author),
                new XAttribute("TimeStamp", eventDateTime.Value.ToString("O"))));

            return jdfNode;
        }

        /// <summary>
        /// Modify an existing JDF node.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <returns></returns>
        public static JdfNodeBuilder ModifyJdfNode(this XElement jdfNode) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            jdfNode.ThrowExceptionIfNotJdfElement();

            return new JdfNodeBuilder(jdfNode);
        }

        /// <summary>
        /// Returns true if the JDF node is the root node.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <returns></returns>
        public static bool IsJdfRoot(this XElement jdfNode) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            jdfNode.ThrowExceptionIfNotJdfElement();
            return (jdfNode.Document == null || jdfNode.Document.Root == jdfNode);
        }

        /// <summary>
        /// Gets the resource pool of the jdf node.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <param name="additionalAction">Additional action to be performed on the resource pool.</param>
        /// <returns></returns>
        /// <remarks>Creates the resource pool if it does not exist.</remarks>
        public static XElement ResourcePoolElement(this XElement jdfNode, Action<XElement> additionalAction = null) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");

            jdfNode.ThrowExceptionIfNotJdfElement();

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
        /// Gets the audit pool of the jdf node.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <returns></returns>
        /// <remarks>Creates the resource link pool if it does not exist.</remarks>
        public static XElement AuditPoolElement(this XElement jdfNode)
        {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            jdfNode.ThrowExceptionIfNotJdfElement();

            var auditPoolElement = jdfNode.Element(Element.AuditPool);
            if (auditPoolElement == null)
            {
                auditPoolElement = new XElement(Element.AuditPool);
                jdfNode.Add(auditPoolElement);
            }

            return auditPoolElement;
        }

        /// <summary>
        /// Gets the resource link pool of the jdf node.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <returns></returns>
        /// <remarks>Creates the resource link pool if it does not exist.</remarks>
        public static XElement ResourceLinkPoolElement(this XElement jdfNode)
        {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");

            jdfNode.ThrowExceptionIfNotJdfElement();

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

            var resourcePool = nearestJdf.ResourcePoolElement();
            var resourceLinkPool = nearestJdf.ResourceLinkPoolElement();

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
                //todo: promote
                //PromoteResourceIfNeeded(resource);
            }

            resourceLinkPool.Add(
                new XElement(resource.Name.LinkName(),
                    new XAttribute("rRef", id),
                    new XAttribute("Usage", usage)));

            return resource;
        }

        static void PromoteResourceIfNeeded(XElement resource) {
            int leastDepth = int.MaxValue;
            XElement referenceClosestToRoot = null;
            foreach (var reference in resource.ReferencingElements()) {
                var depth = reference.Depth();
                if (depth < leastDepth) {
                    leastDepth = depth;
                    referenceClosestToRoot = reference;
                }
            }
            if (resource.Depth() >= leastDepth) {
                resource.Remove();
                referenceClosestToRoot.Parent.ResourcePoolElement().Add(resource);
            }
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
        public static bool IsJdfElement(this XElement element)
        {
            ParameterCheck.ParameterRequired(element, "element");

            return element.Name == Element.JDF;
        }

        /// <summary>
        /// Returns true if the node is a JDF intent node 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsJdfIntentElement(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.IsJdfElement() && element.GetJdfType() == "Product";
        }

        /// <summary>
        /// Returns true if the node is a JDF process group node 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsJdfProcessGroupElement(this XElement element)
        {
            ParameterCheck.ParameterRequired(element, "element");

            return element.IsJdfElement() && element.GetJdfType() == "ProcessGroup";
        }

        /// <summary>
        /// Returns true if the node is a JDF process node 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsJdfProcessElement(this XElement element)
        {
            ParameterCheck.ParameterRequired(element, "element");

            return element.IsJdfElement() && !element.IsJdfIntentElement() && !element.IsJdfProcessGroupElement();
        }

        /// <summary>
        /// Gets the type of the node.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetJdfType(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.GetAttributeFromJdfElement("Type");
        }

        /// <summary>
        /// Gets the types of the node.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string [] GetJdfTypes(this XElement element)
        {
            ParameterCheck.ParameterRequired(element, "element");

            var typesString = element.GetAttributeFromJdfElement("Types");

            if (string.IsNullOrWhiteSpace(typesString))
            {
                return null;
            }

            return typesString.Split(' ');
        }

        /// <summary>
        /// Gets the job id of the node.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetJobId(this XElement element)
        {
            ParameterCheck.ParameterRequired(element, "element");

            return element.GetAttributeFromJdfElement("JobID");
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
        /// Gets the element factory for this element so that elements can
        /// be added.
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static NodeBuilder AddNode(this XContainer container) {
            ParameterCheck.ParameterRequired(container, "element");

            return new NodeBuilder(container);
        }

        /// <summary>
        /// Sets the job id of the jdf node to the given value.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static XElement SetJobId(this XElement element, string id) {
            ParameterCheck.ParameterRequired(element, "element");

            element.ThrowExceptionIfNotJdfElement();

            element.SetAttributeValue("JobID", id);

            return element;
        }

        /// <summary>
        /// Sets the job part id of the jdf node to the given value.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="jobPartId"></param>
        /// <returns></returns>
        public static XElement SetJobPartId(this XElement element, string jobPartId)
        {
            ParameterCheck.ParameterRequired(element, "element");

            element.ThrowExceptionIfNotJdfElement();

            element.SetAttributeValue("JobPartID", jobPartId);

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

            return element.GetAttributeFromJdfElement("JobPartID");
        }

        static string GetAttributeFromJdfElement(this XElement element, string attributeName) {
            ParameterCheck.ParameterRequired(element, "element");
            ParameterCheck.StringRequiredAndNotWhitespace(attributeName, "attributeName");

            element.ThrowExceptionIfNotJdfElement();

            return element.GetAttributeValueOrNull(attributeName);
        }

        /// <summary>
        /// Make the JDF node an intent node.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <returns></returns>
        public static XElement MakeJdfElementAnIntent(this XElement jdfNode)
        {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            jdfNode.ThrowExceptionIfNotJdfElement();

            jdfNode.SetTypeAndTypes("Product");

            return jdfNode;
        }

        /// <summary>
        /// Make the JDF node a process group node
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <returns></returns>
        public static XElement MakeJdfElementAProcessGroup(this XElement jdfNode)
        {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            jdfNode.ThrowExceptionIfNotJdfElement();

            jdfNode.SetTypeAndTypes("ProcessGroup");

            return jdfNode;
        }

        /// <summary>
        /// Make the JDF node a process
        /// </summary>
        /// <returns></returns>
        public static XElement MakeJdfElementAProcess(this XElement jdfNode, params string [] types)
        {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            jdfNode.ThrowExceptionIfNotJdfElement();

            jdfNode.SetTypeAndTypes(types);

            return jdfNode;
        }

        /// <summary>
        /// Throws an ArgumentException if the given node is not a JDF node.
        /// </summary>
        /// <param name="jdfNode"></param>
        public static void ThrowExceptionIfNotJdfElement(this XElement jdfNode)
        {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");

            if (!jdfNode.IsJdfElement())
            {
                throw new ArgumentException(string.Format(Messages.CanOnlyOperateOnJdfNode,
                                                          jdfNode.Name));
            }
        }

        /// <summary>
        /// Set type and optionally types of a JDF node.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        public static XElement SetTypeAndTypes(this XElement jdfNode, params string [] types)
        {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            ThrowExceptionIfNotJdfElement(jdfNode);
            
            if (types == null || types.Length == 0) {
                jdfNode.SetAttributeValue("Type", "ProcessGroup");
            }
            if (types.Length == 1) {
                jdfNode.SetAttributeValue("Type", types[0]);
            }
            else {
                jdfNode.SetAttributeValue("Type", "Combined");
                jdfNode.SetAttributeValue("Types", string.Join(" ", types));
            }

            
            return jdfNode;
        }
    }
}