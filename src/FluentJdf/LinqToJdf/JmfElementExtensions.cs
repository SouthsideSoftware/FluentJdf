﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using FluentJdf.Configuration;
using FluentJdf.LinqToJdf.Builder.Jmf;
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

        /// <summary>
        /// Gets the sender ID of the JMF node.
        /// </summary>
        /// <param name="jmfNode"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If the node is not a JMF node.</exception>
        public static string GetSenderId(this XElement jmfNode) {
            ParameterCheck.ParameterRequired(jmfNode, "jmfNode");
            jmfNode.ThrowExceptionIfNotJmfElement();

            return jmfNode.GetAttributeValueOrNull("SenderID");
        }

        /// <summary>
        /// Sets the sender ID of the JMF node.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If the node is not a JMF node.</exception>
        public static XElement SetSenderId(this XElement jmfNode, string senderId = null)
        {
            ParameterCheck.ParameterRequired(jmfNode, "jmfNode");
            jmfNode.ThrowExceptionIfNotJmfElement();

            if (string.IsNullOrWhiteSpace(senderId)) {
                senderId = Configuration.FluentJdfLibrary.Settings.JdfAuthoringSettings.SenderId;
            }
            

            jmfNode.SetAttributeValue("SenderID", senderId);
            return jmfNode;
        }

        /// <summary>
        /// Create a message from a document.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If the document has
        /// a root element that is not a JMF element.</exception>
        public static Message ToMessage(this XDocument document) {
            ParameterCheck.ParameterRequired(document, "document");
            if (document.Root != null) {
                document.Root.ThrowExceptionIfNotJmfElement();
            }

            var message = new Message();
            if (document.Root != null) {
                message.Add(document.Root);
            }

            return message;
        }

        /// <summary>
        /// Gets the names (i.e. command, query etc.) of all messages in a JMF
        /// </summary>
        /// <param name="jmfElement"></param>
        /// <returns></returns>
        public static IEnumerable<XName> GetMessageNames(this XElement jmfElement) {
            ParameterCheck.ParameterRequired(jmfElement, "jmfElement");
            jmfElement.ThrowExceptionIfNotJmfElement();

            return (from message in jmfElement.Elements() select message.Name);

        }

        /// <summary>
        /// Gets all the message elements (i.e. command, query etc.) in the JMF.
        /// </summary>
        /// <param name="jmfElement"></param>
        /// <returns></returns>
        public static IEnumerable<XElement> GetMessageElements(this XElement jmfElement) {
            ParameterCheck.ParameterRequired(jmfElement, "jmfElement");
            jmfElement.ThrowExceptionIfNotJmfElement();

            return jmfElement.Elements();
        }
    }
}
