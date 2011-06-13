using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// 
    /// </summary>
    public class ResourceNodeBuilder : NodeBuilderBase {
        internal  ResourceNodeBuilder(JdfNodeBuilder parent, XName resourceName, ResourceUsage usage, string id = null) : base(parent) {
            ParameterCheck.ParameterRequired(resourceName, "resourceName");

            Element =  ParentJdfNode.Element.LinkResource(usage, resourceName, id);
        }

        /// <summary>
        /// Gets the attribute setter for this node.
        /// </summary>
        public new ResourceNodeAttributeBuilder With() { return new ResourceNodeAttributeBuilder(this); }

        /// <summary>
        /// Create an input
        /// </summary>
        public ResourceNodeNameBuilder WithInput() { return ParentJdfNode.WithInput(); }

        /// <summary>
        /// Creates an output.
        /// </summary>
        public ResourceNodeNameBuilder WithOutput() { return ParentJdfNode.WithOutput(); }

        /// <summary>
        /// Validate the JDF
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        public new ResourceNodeBuilder ValidateJdf(bool addSchemaInfo = true)
        {
            Element.ValidateJdf(addSchemaInfo);
            return this;
        }
    }
}
