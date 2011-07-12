using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using FluentJdf.Resources;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jdf {

    /// <summary>
    /// Builder for generic JMF elements.
    /// </summary>
    public class GenericJdfBuilder : IJdfNodeBuilder {
        readonly XElement element;
        readonly JdfNodeBuilder jdfNodeBuilder;

        internal GenericJdfBuilder(JdfNodeBuilder parentJdfBuilder, XElement element) {
            ParameterCheck.ParameterRequired(parentJdfBuilder, "parentJdfBuilder");
            ParameterCheck.ParameterRequired(element, "element");

            jdfNodeBuilder = parentJdfBuilder;
            this.element = element;
        }

        /// <summary>
        /// Add any <see cref="XElement"/> to the Element.
        /// </summary>
        /// <param name="element">The element to add.</param>
        /// <returns></returns>
        public GenericJdfBuilder AddNode(XElement element) {
            ParameterCheck.ParameterRequired(element, "element");
            Element.Add(element);
            return new GenericJdfBuilder(jdfNodeBuilder, element);
        }

        /// <summary>
        /// Add any named element to the Element.
        /// </summary>
        /// <param name="name">The <see cref="XName"/> of the element to add.</param>
        /// <returns></returns>
        public GenericJdfBuilder AddNode(XName name) {
            ParameterCheck.ParameterRequired(name, "name");
            return AddNode(new XElement(name));
        }

        /// <summary>
        /// Return the JDFNodeBuilder
        /// </summary>
        /// <returns></returns>
        public JdfNodeBuilder Node() {
            return jdfNodeBuilder;
        }

        /// <summary>
        /// Get the attribute builder for the element.
        /// </summary>
        /// <returns></returns>
        public GenericJdfAttributeBuilder With() {
            return new GenericJdfAttributeBuilder(this);
        }

        /// <summary>
        /// Create an input
        /// </summary>
        public ResourceNodeNameBuilder WithInput() {
            return new ResourceNodeNameBuilder(jdfNodeBuilder, ResourceUsage.Input);
        }

        /// <summary>
        /// Creates an output.
        /// </summary>
        public ResourceNodeNameBuilder WithOutput() {
            return new ResourceNodeNameBuilder(jdfNodeBuilder, ResourceUsage.Output);
        }

        /// <summary>
        /// Adds a new intent JDF.
        /// </summary>
        /// <returns></returns>
        public JdfNodeBuilder AddIntent() {
            return new JdfNodeBuilder(jdfNodeBuilder.Element, ProcessType.Intent);
        }

        /// <summary>
        /// Adds a new intent JDF.
        /// </summary>
        /// <returns></returns>
        public JdfNodeBuilder AddProcessGroup() {
            return new JdfNodeBuilder(jdfNodeBuilder.Element, ProcessType.ProcessGroup);
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
            return new JdfNodeBuilder(jdfNodeBuilder.Element, types);
        }

        /// <summary>
        /// Validate the JDF
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        public JdfNodeBuilder ValidateJdf(bool addSchemaInfo = true) {
            jdfNodeBuilder.ValidateJdf(addSchemaInfo);
            return jdfNodeBuilder;
        }

        /// <summary>
        /// Gets the Element and allows set for inheritors
        /// </summary>
        public XElement Element {
            get {
                return element; //_jdfNodeBuilder.Element; //????
            }
        }

        /// <summary>
        /// Gets the container JDF builder.
        /// </summary>
        public JdfNodeBuilder ParentJdfNode {
            get {
                return jdfNodeBuilder;
            }
        }

        /// <summary>
        /// Gets the ticket associated with this builder
        /// </summary>
        public Ticket Ticket {
            get {
                return jdfNodeBuilder.Ticket;
            }
        }

        /// <summary>
        /// Gets the root JDF node.
        /// </summary>
        public JdfNodeBuilder RootJdfNode {
            get { return jdfNodeBuilder.RootJdfNode; }
        }
    }
}
