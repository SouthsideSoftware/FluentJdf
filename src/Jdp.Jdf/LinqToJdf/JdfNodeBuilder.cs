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

            Element = initiator.AddProcessJdfElement(types);
            
            if (Element.GetJdfParentOrNull() != null)
            {
                ParentJdfNode = new JdfNodeBuilder(Element.JdfParent());
            }
        }
        
        internal JdfNodeBuilder(XElement node) : base(node) {
            ParameterCheck.ParameterRequired(node, "node");
            node.ThrowExceptionIfNotJdfElement();
        }

        /// <summary>
        /// Gets the attribute setter for this node.
        /// </summary>
        public new JdfNodeAttributeBuilder With() { return new JdfNodeAttributeBuilder(this);}

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
