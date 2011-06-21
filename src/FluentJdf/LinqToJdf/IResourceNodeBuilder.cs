using System.Xml.Linq;

namespace FluentJdf.LinqToJdf {
    public interface IResourceNodeBuilder {
        /// <summary>
        /// Create an input
        /// </summary>
        ResourceNodeNameBuilder WithInput();

        /// <summary>
        /// Creates an output.
        /// </summary>
        ResourceNodeNameBuilder WithOutput();

        /// <summary>
        /// Validate the JDF
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        ResourceNodeBuilder ValidateJdf(bool addSchemaInfo = true);

        /// <summary>
        /// Gets the Element and allows set for inheritors
        /// </summary>
        XElement Element { get; }

        /// <summary>
        /// Gets the container JDF builder.
        /// </summary>
        JdfNodeBuilder ParentJdfNode { get; }

        /// <summary>
        /// Gets the ticket associated with this builder
        /// </summary>
        Ticket Ticket { get; }

        /// <summary>
        /// Validate the JDF
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        JdfNodeBuilderBase ValidateJdf(bool addSchemaInfo = true);
    }
}