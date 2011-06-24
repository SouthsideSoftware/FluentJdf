using System.Xml.Linq;

namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Common interface for use in JDF tree node builders.
    /// </summary>
    public interface IJdfNodeBuilderBase {
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