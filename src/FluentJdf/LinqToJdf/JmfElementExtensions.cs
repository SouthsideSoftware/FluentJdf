using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using FluentJdf.Resources;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Extensions for JMF elements.
    /// </summary>
    public static class JmfElementExtensions
    {
        /// <summary>
        /// Throws an ArgumentException if the given node is not a JMF node.
        /// </summary>
        public static void ThrowExceptionIfNotJmfElement(this XElement jmfNode)
        {
            ParameterCheck.ParameterRequired(jmfNode, "jmfNode");

            if (!jmfNode.IsJmfElement())
            {
                throw new ArgumentException(string.Format(Messages.JmfElementExtensions_ThrowExceptionIfNotJmfElement_CanOnlyOperateOnJmfNodes,
                                                          jmfNode.Name));
            }
        }

        /// <summary>
        /// Throw an exception if the element is not in a Message.
        /// </summary>
        /// <param name="element"></param>
        public static void ThrowExceptionIfNotInMessage(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");
            if (element.Document == null || !(element.Document is Message)) {
                throw new ArgumentException(Messages.JmfElementExtensions_ThrowExceptionIfNotInMessage_CannotOperateOnElementUnlessItIsInMessage);
            }
        }

        /// <summary>
        /// Gets true if the element is a JF node.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsJmfElement(this XElement element)
        {
            ParameterCheck.ParameterRequired(element, "element");

            return element.Name == Element.JMF;
        }

        /// <summary>
        /// Gets the builder for an existing JMF node.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static JmfNodeBuilder ModifyJmfNode(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");
            element.ThrowExceptionIfNotJmfElement();

            return new JmfNodeBuilder(element);
        }
    }
}
