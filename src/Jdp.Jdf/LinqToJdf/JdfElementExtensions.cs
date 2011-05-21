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
        public static XElement CreateItentNode(this XContainer parent,
                                               JdfNodeCreationAttributes jdfNodeCreationAttributes = null)
        {
            Contract.Requires(parent != null);
            if (parent is XElement)
            {
                ThrowExceptionIfNotJdfNode(parent as XElement);
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
        /// Make the JDF node an intent node.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <returns></returns>
        public static XElement MakeJdfNodeAnIntent(this XElement jdfNode)
        {
            Contract.Requires(jdfNode != null);
            ThrowExceptionIfNotJdfNode(jdfNode);

            jdfNode.SetTypeAndTypes("Product");

            return jdfNode;
        }

        static void ThrowExceptionIfNotJdfNode(XElement jdfNode)
        {
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