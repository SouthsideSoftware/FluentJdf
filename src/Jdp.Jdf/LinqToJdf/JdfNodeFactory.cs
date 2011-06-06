using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Onpoint.Commons.Core.CodeContracts;

namespace Jdp.Jdf.LinqToJdf
{
    /// <summary>
    /// Factory for creating intent nodes.
    /// </summary>
    public class JdfNodeFactory : NodeFactoryBase {
        internal JdfNodeFactory(XContainer initiator, params string [] types) : base(initiator) {
            ParameterCheck.ParameterRequired(initiator, "initiator");

            Node = initiator.AddProcessNode(types);

            //If the intiiator is not an xelement, make the xelement the newly created JDF node.
            if (!(Initiator is XElement)) {
                Initiator = Node;
            }
        }
        
        internal JdfNodeFactory(XElement node) : base(node) {
            ParameterCheck.ParameterRequired(node, "node");

            Node = node;
        }

        /// <summary>
        /// Gets the attribute setter for this node.
        /// </summary>
        public JdfAttributeSetter With() { return new JdfAttributeSetter(this);}

        /// <summary>
        /// Create an input
        /// </summary>
        public ResourceNodeNameFactory WithInput() { return new ResourceNodeNameFactory(Node, ResourceUsage.Input); }

        /// <summary>
        /// Creates an output.
        /// </summary>
        public ResourceNodeNameFactory WithOutput() { return new ResourceNodeNameFactory(Node, ResourceUsage.Output); }
    }
}
