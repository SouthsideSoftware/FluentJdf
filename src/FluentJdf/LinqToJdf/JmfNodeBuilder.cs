using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Factory for creating intent nodes.
    /// </summary>
    public class JmfNodeBuilder : NodeBuilderBase {
        internal JmfNodeBuilder(XContainer initiator) {
            ParameterCheck.ParameterRequired(initiator, "initiator");

            Element = new XElement(LinqToJdf.Element.JMF);
            initiator.Add(Element);
            if (Element.GetJdfParentOrNull() != null)
            {
                ParentJdfNode = new JdfNodeBuilder(Element.JdfParent());
            }
        }
        
        internal JmfNodeBuilder(XElement node) : base(node) {
            ParameterCheck.ParameterRequired(node, "node");
            node.ThrowExceptionIfNotJmfElement();
        }

        /// <summary>
        /// Validate the JDF
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        public new JmfNodeBuilder ValidateJdf(bool addSchemaInfo = true) {
            Element.ValidateJdf(addSchemaInfo);
            return this;
        }
    }
}