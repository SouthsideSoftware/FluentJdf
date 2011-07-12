using System.Xml.Linq;
using FluentJdf.LinqToJdf.Builder.Jdf;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Node builder interface for resources.
    /// </summary>
    public interface IResourceNodeBuilder 
    {
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