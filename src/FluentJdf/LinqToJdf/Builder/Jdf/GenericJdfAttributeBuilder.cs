using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Core.CodeContracts;
using System.Xml.Linq;

namespace FluentJdf.LinqToJdf.Builder.Jdf {

    /// <summary>
    /// Builder for setting attributes on generic JDF element.
    /// </summary>
    public class GenericJdfAttributeBuilder : IJdfNodeBuilder {

        GenericJdfBuilder _nodeBuilder;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="nodeBuilder"></param>
        internal GenericJdfAttributeBuilder(GenericJdfBuilder nodeBuilder) {
            ParameterCheck.ParameterRequired(nodeBuilder, "nodeBuilder");
            _nodeBuilder = nodeBuilder;
        }

        /// <summary>
        /// Sets an attribute value.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public GenericJdfAttributeBuilder Attribute(XName name, string value) {
            ParameterCheck.ParameterRequired(name, "name");

            Element.SetAttributeValue(name, value);
            return this;
        }

        /// <summary>
        /// Add any <see cref="XElement"/> to the Element.
        /// </summary>
        /// <param name="element">The element to add.</param>
        /// <returns></returns>
        public GenericJdfBuilder AddNode(XElement element) {
            ParameterCheck.ParameterRequired(element, "element");
            Element.Add(element);
            return new GenericJdfBuilder(_nodeBuilder.Node(), element);
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
        /// Create an input
        /// </summary>
        public ResourceNodeNameBuilder WithInput() {
            return _nodeBuilder.WithInput();
        }

        /// <summary>
        /// Creates an output.
        /// </summary>
        public ResourceNodeNameBuilder WithOutput() {
            return _nodeBuilder.WithOutput();
        }

        /// <summary>
        /// Adds a new intent JDF.
        /// </summary>
        /// <returns></returns>
        public JdfNodeBuilder AddIntent() {
            return _nodeBuilder.AddIntent();
        }

        /// <summary>
        /// Adds a new intent JDF.
        /// </summary>
        /// <returns></returns>
        public JdfNodeBuilder AddProcessGroup() {
            return _nodeBuilder.AddProcessGroup();
        }

        /// <summary>
        /// Adds a new process JDF
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public JdfNodeBuilder AddProcess(params string[] types) {
            return _nodeBuilder.AddProcess(types);
        }

        /// <summary>
        /// Validate the JDF
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        public JdfNodeBuilder ValidateJdf(bool addSchemaInfo = true) {
            return _nodeBuilder.ValidateJdf(addSchemaInfo);
        }

        /// <summary>
        /// Gets the Element and allows set for inheritors
        /// </summary>
        public XElement Element {
            get {
                return _nodeBuilder.Element;
            }
        }

        /// <summary>
        /// Gets the container JDF builder.
        /// </summary>
        public JdfNodeBuilder ParentJdfNode {
            get {
                return _nodeBuilder.ParentJdfNode;
            }
        }

        /// <summary>
        /// Gets the ticket associated with this builder
        /// </summary>
        public Ticket Ticket {
            get {
                return _nodeBuilder.Ticket;
            }
        }

    }
}
