using System;
using System.Xml.Linq;
using FluentJdf.Resources;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jdf {

    /// <summary>
    /// Factory for creating intent nodes.
    /// </summary>
    public class JdfNodeBuilder : JdfNodeBuilderBase, IJdfNodeBuilder {
        internal JdfNodeBuilder(Ticket ticket, params string[] types) : this(ticket, false, types) {}

        internal JdfNodeBuilder(Ticket ticket, bool isGrayBox, params string[] types) {
            ParameterCheck.ParameterRequired(ticket, "ticket");
            Initalize(ticket, isGrayBox, types);
        }

        void Initalize(Ticket ticket, bool isGrayBox, string[] types) {
            if (ticket.Root != null) {
                ticket.Root.ThrowExceptionIfNotJdfElement();
            }

            if (ticket.Root == null) {
                if (isGrayBox) {
                    Element = ticket.AddGrayBoxJdfElement(types);
                } else {
                    Element = ticket.AddProcessJdfElement(types);
                }
            }
            else {
                Element = ticket.Root;
            }

            if (Element.GetJdfParentOrNull() != null) {
                ParentJdfNode = new JdfNodeBuilder(Element.JdfParent());
            }
        }

        internal JdfNodeBuilder(XElement node, params string[] types) : this(node, false, types) {}

        internal JdfNodeBuilder(XElement node, bool isGrayBox, params string[] types) {
            ParameterCheck.ParameterRequired(node, "node");
            node.ThrowExceptionIfNotJdfElement();

            if (types == null || types.Length == 0) {
                InitializeFromElement(node);
            }
            else {
                if (isGrayBox) {
                    InitializeFromElement(node.AddGrayBoxJdfElement(types));
                }
                else {
                    InitializeFromElement(node.AddProcessJdfElement(types));
                }
            }
        }

        /// <summary>
        /// Add any <see cref="XElement"/> to the JDFNode.
        /// </summary>
        /// <param name="element">The element to add.</param>
        /// <returns></returns>
        public GenericJdfBuilder AddNode(XElement element) {
            ParameterCheck.ParameterRequired(element, "element");
            Element.Add(element);
            return new GenericJdfBuilder(this, element);
        }

        /// <summary>
        /// Add any named element to the JDFNode.
        /// </summary>
        /// <param name="name">The <see cref="XName"/> of the element to add.</param>
        /// <returns></returns>
        public GenericJdfBuilder AddNode(XName name) {
            ParameterCheck.ParameterRequired(name, "name");
            return AddNode(new XElement(name));
        }

        /// <summary>
        /// Gets the attribute setter for this node.
        /// </summary>
        public JdfNodeAttributeBuilder With() {
            return new JdfNodeAttributeBuilder(this);
        }

        /// <summary>
        /// Create an input
        /// </summary>
        public ResourceNodeNameBuilder WithInput() {
            return new ResourceNodeNameBuilder(this, ResourceUsage.Input);
        }

        /// <summary>
        /// Creates an output.
        /// </summary>
        public ResourceNodeNameBuilder WithOutput() {
            return new ResourceNodeNameBuilder(this, ResourceUsage.Output);
        }

        /// <summary>
        /// Adds a new intent JDF.
        /// </summary>
        /// <returns></returns>
        public JdfNodeBuilder AddIntent() {
            return new JdfNodeBuilder(Element, ProcessType.Intent);
        }

        /// <summary>
        /// Adds a new intent JDF.
        /// </summary>
        /// <returns></returns>
        public JdfNodeBuilder AddProcessGroup() {
            return new JdfNodeBuilder(Element, ProcessType.ProcessGroup);
        }

        /// <summary>
        /// Adds a new process JDF
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public JdfNodeBuilder AddProcess(params string[] types) {
            if (types == null || types.Length == 0) {
                throw new ArgumentException(Messages.AtLeastOneProcessMustBeSpecified);
            }
            return new JdfNodeBuilder(Element, types);
        }

        /// <summary>
        /// Adds a new gray box (process group with types)
        /// </summary>
        /// <returns></returns>
        public JdfNodeBuilder AddGrayBox(params string[] types) {
            if (types == null || types.Length == 0) {
                throw new ArgumentException(Messages.AtLeastOneProcessMustBeSpecified);
            }
            return new JdfNodeBuilder(Element, true, types);
        }

        /// <summary>
        /// Validate the JDF
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        public JdfNodeBuilder ValidateJdf(bool addSchemaInfo = true) {
            Element.ValidateJdf(addSchemaInfo);
            return this;
        }
    }
}
