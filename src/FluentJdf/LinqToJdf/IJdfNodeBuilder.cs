using System.Xml.Linq;

namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Interface for building JDF nodes.
    /// </summary>
    public interface IJdfNodeBuilder {
        /// <summary>
        /// Create an input
        /// </summary>
        ResourceNodeNameBuilder WithInput();

        /// <summary>
        /// Creates an output.
        /// </summary>
        ResourceNodeNameBuilder WithOutput();

        /// <summary>
        /// Adds a new intent JDF.
        /// </summary>
        /// <returns></returns>
        JdfNodeBuilder AddIntent();

        /// <summary>
        /// Adds a new intent JDF.
        /// </summary>
        /// <returns></returns>
        JdfNodeBuilder AddProcessGroup();

        /// <summary>
        /// Adds a new process JDF
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        JdfNodeBuilder AddProcess(params string [] types);

        /// <summary>
        /// Validate the JDF
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        JdfNodeBuilder ValidateJdf(bool addSchemaInfo = true);

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
    }
}