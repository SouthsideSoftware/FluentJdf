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
        /// Gets true if the element is a JF node.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsJmfElement(this XElement element)
        {
            ParameterCheck.ParameterRequired(element, "element");

            return element.Name == Element.JMF;
        }
    }
}
