using System.Xml.Linq;
using Onpoint.Commons.Core.CodeContracts;

namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Base class for attribute builders
    /// </summary>
    public class NodeAttributeBuilderBase {
        /// <summary>
        /// The node builder base that created this attribute builder.
        /// </summary>
        protected NodeBuilderBase NodeBuilderBase;

        internal NodeAttributeBuilderBase(NodeBuilderBase nodeBuilderBase) {
            ParameterCheck.ParameterRequired(nodeBuilderBase, "NodeBuilderBase");

            NodeBuilderBase = nodeBuilderBase;
        }

        /// <summary>
        /// Gets the intent node.
        /// </summary>
        /// <returns></returns>
        public XElement Element {
            get { return NodeBuilderBase.Element; }
        }

        /// <summary>
        /// Gets the parent JDF node of the current node.
        /// </summary>
        public JdfNodeBuilder ParentJdfNode { get { return NodeBuilderBase.ParentJdfNode; } }

        /// <summary>
        /// Sets any attribute value
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks>Use specific Set[attribute name] methods in preference to this method.
        /// Those setters may have side-effects that will not be honored by this method.  For example,
        /// setting the id of a resource via the SetId method will fixup references by default.</remarks>
        public NodeAttributeBuilderBase Attribute(XName name, string value) {
            ParameterCheck.ParameterRequired(name, "name");

            Element.SetAttributeValue(name, value);

            return this;
        }

        /// <summary>
        /// Sets the descriptive name.
        /// </summary>
        /// <param name="descriptiveName"></param>
        /// <returns></returns>
        public NodeAttributeBuilderBase DescriptiveName(string descriptiveName) {
            Element.SetDescriptiveName(descriptiveName);

            return this;
        }

        /// <summary>
        /// Allows a node to be added to this node.
        /// </summary>
        /// <returns></returns>
        public NodeBuilder AddNode()
        {
            return new NodeBuilder(Element);
        }

        /// <summary>
        /// Validate the JDF
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        public NodeAttributeBuilderBase ValidateJdf(bool addSchemaInfo = true)
        {
            Element.ValidateJdf(addSchemaInfo);
            return this;
        }

        /// <summary>
        /// Gets the ticket associated with this builder
        /// </summary>
        public Ticket Ticket { get { return Element.Document as Ticket; } }
    }
}