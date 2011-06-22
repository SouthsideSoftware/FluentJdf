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

        //note: the following method does not have a default specified for addSchemaInfo.  See additional info below note for more. 
        //The default will be taken from the interface.
        //If the default was put here, it would be ignored and a compiler warning would be issued.
        //see http://stackoverflow.com/questions/5683111/warning-from-explicitly-implementing-an-interface-with-optional-paramters 
        //for more information.

        /// <summary>
        /// Validate the JDF
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        JdfNodeBuilder IJdfNodeBuilder.ValidateJdf(bool addSchemaInfo) {
            return ParentJdfNode.ValidateJdf(addSchemaInfo);
        }

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
