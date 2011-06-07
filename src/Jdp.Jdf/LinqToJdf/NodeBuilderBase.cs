using System.Diagnostics.Contracts;
using System.Xml.Linq;
using Onpoint.Commons.Core.CodeContracts;

namespace Jdp.Jdf.LinqToJdf
{
    /// <summary>
    /// Base class for node factories.
    /// </summary>
    public abstract class NodeBuilderBase
    {
        internal NodeBuilderBase(JdfNodeBuilder parentJdfBuilder)
        {
            ParentJdf = parentJdfBuilder;
        }

        internal NodeBuilderBase(XElement node)
        {
            ParameterCheck.ParameterRequired(node, "node");

            Node = node;

            if (ParentJdf != null && ParentJdf.Node.GetJdfParentOrNull() != null)
            {
                ParentJdf = new JdfNodeBuilder(ParentJdf.Node.JdfParent());
            }
        }

        internal NodeBuilderBase()
        {
            
        }

        /// <summary>
        /// Gets the Node and allows set for inheritors
        /// </summary>
        public XElement Node { get; protected set; }

        /// <summary>
        /// Gets the container JDF builder.
        /// </summary>
        public JdfNodeBuilder ParentJdf { get; protected set; }
    }
}