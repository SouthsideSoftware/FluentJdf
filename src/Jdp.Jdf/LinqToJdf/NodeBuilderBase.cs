using System.Diagnostics.Contracts;
using System.Xml.Linq;
using Onpoint.Commons.Core.CodeContracts;

namespace Jdp.Jdf.LinqToJdf
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
    }
}