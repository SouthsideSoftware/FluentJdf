using System;
using System.Diagnostics.Contracts;
using System.Xml.Linq;
using FluentJdf.Configuration;
using FluentJdf.Resources;
using FluentJdf.Utility;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Extensions useful for all kinds of JDF nodes
    /// </summary>
    public static class ElementExtensions {
        /// <summary>
        /// Gets the DescriptiveName.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetDescriptiveName(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.GetAttributeValueOrNull("DescriptiveName");
        }

        /// <summary>
        /// Gets true if the target node's jdf element shares a common parent with the given node's jdf parent.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="possibleSibling"></param>
        /// <returns></returns>
        public static bool IsInSiblingJdf(this XElement element, XElement possibleSibling) {
            ParameterCheck.ParameterRequired(element, "element");
            ParameterCheck.ParameterRequired(possibleSibling, "possibleSibling");

            return element.NearestJdf().HasJdfParent() && possibleSibling.NearestJdf().HasJdfParent() &&
                   element.NearestJdf() != possibleSibling.NearestJdf() &&
                   element.NearestJdf().JdfParent() == possibleSibling.NearestJdf().JdfParent();
        }

        /// <summary>
        /// Gets true if the given element has a JDF parent.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool HasJdfParent(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.GetJdfParentOrNull() != null;
        }

        /// <summary>
        /// Sets the DescriptiveName.
        /// </summary>
        /// <returns></returns>
        public static XElement SetDescriptiveName(this XElement element, string value) {
            ParameterCheck.ParameterRequired(element, "element");

            element.SetAttributeValue("DescriptiveName", value);

            return element;
        }

        /// <summary>
        /// Gets the depth of an element in the tree.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static int Depth(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.LocalElementXPath().CountChar('/') - 1;
        }

        /// <summary>
        /// Adds arbitrary content to the element.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static XElement AddContent(this XElement element, params Object[] content) {
            ParameterCheck.ParameterRequired(element, "element");
            ParameterCheck.ParameterRequired(content, "content");

            if (content.Length == 0) {
                throw new ArgumentException(Messages.ElementExtensions_AddContent_RequiresContentToAdd);
            }

            element.Add(content);
            return element;
        }

        /// <summary>
        /// Get this node if it is a JDF.  If it is not a JDF, get nearest JDF parent.  
        /// </summary>
        /// <param name="element"></param>
        /// <returns>The first JDF parent</returns>
        /// <exception cref="JdfException">If this node is not a JDF and there is no JDF parent.</exception>
        public static XElement NearestJdf(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            XElement firstJdf = element.GetNearestJdfOrNull();
            if (firstJdf == null) {
                throw new JdfException(string.Format(Messages.ElementExtensions_FirstJdf_NodeNotJdfAndNoJdfParent, element.Name));
            }

            return firstJdf;
        }

        /// <summary>
        /// Gets this node if it a JDF.  If this node is not a JDF, it gets
        /// the first JDF parent.  Returns <see langword="null"/> if neither case is true.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static XElement GetNearestJdfOrNull(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            if (element.IsJdfElement()) {
                return element;
            }

            return element.GetJdfParentOrNull();
        }

        /// <summary>
        /// Get the first parent of this element that is a JDF.  
        /// </summary>
        /// <param name="element"></param>
        /// <returns>The first JDF parent</returns>
        /// <exception cref="JdfException">If there is no JDF parent.</exception>
        public static XElement JdfParent(this XElement element) {
            Contract.Requires(element != null);

            XElement jdfParent = element.GetJdfParentOrNull();
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
            ParameterCheck.ParameterRequired(element, "element");

            if (element.Parent != null) {
                return element.Parent.IsJdfElement() ? element.Parent : element.Parent.GetJdfParentOrNull();
            }

            return null;
        }

        /// <summary>
        /// Gets the root JDF of the element.  If none is found, throws an exception.
        /// </summary>
        /// <param name="element"></param>
        /// <exception cref="JdfException">If no JDF root is found.</exception>
        /// <returns></returns>
        public static XElement JdfRoot(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            XElement jdfRoot = element.GetJdfRootOrNull();
            if (jdfRoot == null) {
                throw new JdfException(string.Format(Messages.ElementExtensions_JdfRoot_NoJdfRootFound, element.Name));
            }

            return jdfRoot;
        }

        /// <summary>
        /// Gets the root jdf associated with this element or null 
        /// if the element is not JDF and there is no JDF ancestor.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static XElement GetJdfRootOrNull(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            if (element.GetJdfParentOrNull() != null) {
                return element.GetJdfParentOrNull().GetJdfRootOrNull();
            }

            return element.IsJdfElement() ? element : null;
        }

        /// <summary>
        /// Sets the JDF version
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If the node is not JDF or JMF.</exception>
        /// <remarks>It is recommended that you only put a version attribute on
        /// the root JDF/JMF.</remarks>
        public static XElement SetVersion(this XElement jdfNode, string version = null)
        {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            jdfNode.ThrowExceptionIfNotJdfOrJmfElement();

            if (version == null) {
                version = Library.Settings.JdfAuthoringSettings.JdfVersion;
            }
            jdfNode.SetAttributeValue("Version", version);
            return jdfNode;
        }

        /// <summary>
        /// Gets the JDF version.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <returns></returns>
        //// <exception cref="ArgumentException">If the node is not JDF or JMF.</exception>
        public static string GetVersion(this XElement jdfNode)
        {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            jdfNode.ThrowExceptionIfNotJdfOrJmfElement();

            return jdfNode.GetAttributeValueOrNull("Version");
        }

        /// <summary>
        /// Throws an ArgumentException if the given node is not a JDF or JMF node.
        /// </summary>
        /// <param name="jdfNode"></param>
        public static void ThrowExceptionIfNotJdfOrJmfElement(this XElement jdfNode)
        {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");

            if (!jdfNode.IsJdfElement() && !jdfNode.IsJmfElement())
            {
                throw new ArgumentException(string.Format(Messages.ElementExtensions_ThrowExceptionIfNotJdfOrJmfElement, jdfNode.Name));
            }
        }

        /// <summary>
        /// Validate the jdf.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If the element does not belong to an XDocument of type Ticket.</exception>
        public static XElement ValidateJdf(this XElement element, bool addSchemaInfo = true) {
            ParameterCheck.ParameterRequired(element, "element");
            if (element.Document == null || !(element.Document is Ticket)) {
                throw new ArgumentException(Messages.ElementExtensions_ValidateJdf_ValidateJdfRequiresDocumentOfTypeTicket);
            }
            (element.Document as Ticket).ValidateJdf(addSchemaInfo);

            return element;
        }

        /// <summary>
        /// Validate the jmf.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If the element does not belong to an XDocument of type Ticket.</exception>
        public static XElement ValidateJmf(this XElement element, bool addSchemaInfo = true)
        {
            ParameterCheck.ParameterRequired(element, "element");
            if (element.Document == null || !(element.Document is Message))
            {
                throw new ArgumentException(Messages.ElementExtensions_ValidateJmf_MessageRequired);
            }
            (element.Document as Message).ValidateJmf(addSchemaInfo);

            return element;
        }

        /// <summary>
        /// Set the xsi:type attribute of the node.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="xsiType"></param>
        /// <returns></returns>
        public static XElement SetXsiType(this XElement element, XName xsiType) {
            ParameterCheck.ParameterRequired(element, "element");

            element.SetAttributeValue(Globals.XsiNamespace.GetName("type"), element.GetXsiTypeNameForType(xsiType));
            return element;
        }

        /// <summary>
        /// Gets the value for an xsi:type attribute for a fully qualified type name
        /// based on the namespace context of the element.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="xsiType"></param>
        /// <returns></returns>
        public static string GetXsiTypeNameForType(this XElement element, XName xsiType) {
            ParameterCheck.ParameterRequired(element, "element");
            ParameterCheck.ParameterRequired(xsiType, "xsiType");

            //todo: we need to handle prefixed namespaces here.  The problem is, we can't get namespace information on the element except when parsing xml data or loading from a file.
            return xsiType.LocalName;
        }

        /// <summary>
        /// Gets the xsi:type attribute.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetXsiTypeAttribute(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.GetAttributeValueOrNull(Globals.XsiNamespace.GetName("type"));
        }
    }
}