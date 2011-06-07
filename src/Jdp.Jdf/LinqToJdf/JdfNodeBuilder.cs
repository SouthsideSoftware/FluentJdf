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
    public class JdfNodeBuilder : NodeBuilderBase {
        internal JdfNodeBuilder(XContainer initiator, params string [] types) {
            ParameterCheck.ParameterRequired(initiator, "initiator");

            Node = initiator.AddProcessJdfElement(types);
            
            if (Node.GetJdfParentOrNull() != null)
            {
                ParentJdf = new JdfNodeBuilder(Node.JdfParent());
            }
        }
        
        internal JdfNodeBuilder(XElement node) : base(node) {
        }

        /// <summary>
        /// Gets the attribute setter for this node.
        /// </summary>
        public JdfAttributeSetter With() { return new JdfAttributeSetter(this);}

        /// <summary>
        /// Create an input
        /// </summary>
        public ResourceNodeNameBuilder WithInput() { return new ResourceNodeNameBuilder(this, ResourceUsage.Input); }

        /// <summary>
        /// Creates an output.
        /// </summary>
        public ResourceNodeNameBuilder WithOutput() { return new ResourceNodeNameBuilder(this, ResourceUsage.Output); }
    }
}
