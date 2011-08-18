using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jdf {
    /// <summary>
    /// 
    /// </summary>
    public class ResourceNodeBuilder : JdfNodeBuilderBase, IJdfNodeBuilder {
        internal ResourceNodeBuilder(JdfNodeBuilder parent, XName resourceName, ResourceUsage usage, string id = null)
            : base(parent) {
            ParameterCheck.ParameterRequired(resourceName, "resourceName");

            Element = ParentJdfNode.Element.LinkResource(usage, resourceName, id);
        }

        /// <summary>
        /// Add any <see cref="XElement"/> to the JDFNode.
        /// </summary>
        /// <param name="element">The element to add.</param>
        /// <returns></returns>
        public GenericJdfBuilder AddNode(XElement element) {
            ParameterCheck.ParameterRequired(element, "element");
            Element.Add(element);
            return new GenericJdfBuilder(this.ParentJdfNode, element);
        }

        /// <summary>
        /// Add any named element to the JDFNode.
        /// </summary>
        /// <param name="name">The <see cref="XName"/> of the element to add.</param>
        /// <returns></returns>
        public GenericJdfBuilder AddNode(XName name) {
            ParameterCheck.ParameterRequired(name, "name");
            return AddNode(new XElement(name));
        }

        /// <summary>
        /// Gets the attribute setter for this node.
        /// </summary>
        public ResourceNodeAttributeBuilder With() {
            return new ResourceNodeAttributeBuilder(this);
        }

        /// <summary>
        /// Create an input
        /// </summary>
        public ResourceNodeNameBuilder WithInput() {
            return ParentJdfNode.WithInput();
        }

        /// <summary>
        /// Creates an output.
        /// </summary>
        public ResourceNodeNameBuilder WithOutput() {
            return ParentJdfNode.WithOutput();
        }

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
        /// Adds a new gray box (process group with types)
        /// </summary>
        /// <returns></returns>
        public JdfNodeBuilder AddGrayBox(params string[] types) {
            return ParentJdfNode.AddGrayBox(types);
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
