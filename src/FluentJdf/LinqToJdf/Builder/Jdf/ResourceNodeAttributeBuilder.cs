using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jdf {
    /// <summary>
    /// Set attributes on a JDF node.
    /// </summary>
    public class ResourceNodeAttributeBuilder : IResourceNodeBuilder {
        ResourceNodeBuilder resourceNodeBuilder;

        internal ResourceNodeAttributeBuilder(ResourceNodeBuilder resourceNodeBuilder) {
            ParameterCheck.ParameterRequired(resourceNodeBuilder, "resourceNodeBuilder");

            this.resourceNodeBuilder = resourceNodeBuilder;
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
        /// Gets the resource node builder for this attribute builder.
        /// </summary>
        /// <returns></returns>
        public ResourceNodeBuilder Node() {
            return resourceNodeBuilder;
        }

        /// <summary>
        /// Sets the ID of the resource and optionally does not update references.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateReferences"></param>
        /// <returns></returns>
        /// <remarks>By default, references are updated.</remarks>
        public ResourceNodeAttributeBuilder Id(string id, bool updateReferences = true) {
            Element.SetId(id, updateReferences);
            return this;
        }

        /// <summary>
        /// Sets the ID of the resource to a unique value and optionally does not update the references.
        /// </summary>
        /// <param name="updateReferences"></param>
        /// <returns></returns>
        /// <remarks>By default, references are updated.</remarks>
        public ResourceNodeAttributeBuilder UniqueId(bool updateReferences = true) {
            Element.SetUniqueId(updateReferences);
            return this;
        }

        /// <summary>
        /// Create an input
        /// </summary>
        public ResourceNodeNameBuilder WithInput() {
            return new ResourceNodeNameBuilder(resourceNodeBuilder.ParentJdfNode, ResourceUsage.Input);
        }

        /// <summary>
        /// Creates an output.
        /// </summary>
        public ResourceNodeNameBuilder WithOutput() {
            return new ResourceNodeNameBuilder(resourceNodeBuilder.ParentJdfNode, ResourceUsage.Output);
        }

        /// <summary>
        /// Gets the ticket associated with this builder
        /// </summary>
        public Ticket Ticket {
            get {
                return resourceNodeBuilder.Ticket;
            }
        }

        /// <summary>
        /// Validate the JDF
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        public JdfNodeBuilder ValidateJdf(bool addSchemaInfo) {
            return resourceNodeBuilder.ValidateJdf(addSchemaInfo);
        }
        /// <summary>
        /// Gets the Element and allows set for inheritors
        /// </summary>
        public XElement Element {
            get {
                return resourceNodeBuilder.Element;
            }
        }

        /// <summary>
        /// Gets the container JDF builder.
        /// </summary>
        public JdfNodeBuilder ParentJdfNode {
            get {
                return resourceNodeBuilder.ParentJdfNode;
            }
        }
    }
}