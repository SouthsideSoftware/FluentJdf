using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Base class for element builders.
    /// </summary>
    public abstract class NodeBuilderBase
    {
        internal NodeBuilderBase(JdfNodeBuilder parentJdfBuilder)
        {
            ParentJdfNode = parentJdfBuilder;
        }

        internal NodeBuilderBase(XElement element)
        {
            ParameterCheck.ParameterRequired(element, "element");

            Element = element;

            if (ParentJdfNode != null && ParentJdfNode.Element.GetJdfParentOrNull() != null)
            {
                ParentJdfNode = new JdfNodeBuilder(ParentJdfNode.Element.JdfParent());
            }
        }

        internal NodeBuilderBase()
        {
            
        }

        /// <summary>
        /// Gets the Element and allows set for inheritors
        /// </summary>
        public XElement Element { get; protected set; }

        /// <summary>
        /// Gets the container JDF builder.
        /// </summary>
        public JdfNodeBuilder ParentJdfNode { get; protected set; }

        /// <summary>
        /// Allows a node to be added to this node.
        /// </summary>
        /// <returns></returns>
        public NodeBuilder AddNode() {
            return new NodeBuilder(Element);
        }

        /// <summary>
        /// Gets the attribute builder that offers the most basic capabilities.
        /// </summary>
        /// <returns></returns>
        public NodeAttributeBuilderBase With() {
            return new NodeAttributeBuilderBase(this);
        }

        /// <summary>
        /// Validate the JDF
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        public NodeBuilderBase ValidateJdf(bool addSchemaInfo = true)
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