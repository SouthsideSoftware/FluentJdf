using System;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// 
    /// </summary>
    public class ResourceNodeBuilder : JdfNodeBuilderBase, IResourceNodeBuilder, IJdfNodeBuilder {
        internal  ResourceNodeBuilder(JdfNodeBuilder parent, XName resourceName, ResourceUsage usage, string id = null) : base(parent) {
            ParameterCheck.ParameterRequired(resourceName, "resourceName");

            Element =  ParentJdfNode.Element.LinkResource(usage, resourceName, id);
        }

        /// <summary>
        /// Gets the attribute setter for this node.
        /// </summary>
        public ResourceNodeAttributeBuilder With() { return new ResourceNodeAttributeBuilder(this); }

        /// <summary>
        /// Create an input
        /// </summary>
        public ResourceNodeNameBuilder WithInput() { return ParentJdfNode.WithInput(); }

        /// <summary>
        /// Creates an output.
        /// </summary>
        public ResourceNodeNameBuilder WithOutput() { return ParentJdfNode.WithOutput(); }

        /// <summary>
        /// Adds a new intent JDF.
        /// </summary>
        /// <returns></returns>
        public JdfNodeBuilder AddIntent() {
            return ParentJdfNode.AddIntent();
        }

        /// <summary>
        /// Adds a new intent JDF.
        /// </summary>
        /// <returns></returns>
        public JdfNodeBuilder AddProcessGroup() {
            return ParentJdfNode.AddProcessGroup();
        }

        /// <summary>
        /// Adds a new process JDF
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public JdfNodeBuilder AddProcess(params string[] types) {
            return ParentJdfNode.AddProcess(types);
        }

        /// <summary>
        /// Validate the JDF
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        public JdfNodeBuilder ValidateJdf(bool addSchemaInfo = true) {
            return ParentJdfNode.ValidateJdf(addSchemaInfo);
        }
    }
}
