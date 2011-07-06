using System.Xml.Linq;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
    /// <summary>
    /// Interface for the JMF node builder base.
    /// </summary>
    public interface IJmfBuilderBase {
        /// <summary>
        /// Gets the Element and allows set for inheritors
        /// </summary>
        XElement Element { get; }

        /// <summary>
        /// Gets the container JMF builder.
        /// </summary>
        JmfNodeBuilder ParentJmfNode { get; }

        /// <summary>
        /// Gets the messsage associated with this builder
        /// </summary>
        Message Message { get; }

        /// <summary>
        /// Validate the JMF
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        JmfBuilderBase ValidateJmf(bool addSchemaInfo = true);

        /// <summary>
        /// Add a command.
        /// </summary>
        /// <returns></returns>
        CommandTypeBuilder AddCommand();

        /// <summary>
        /// Add a query.
        /// </summary>
        /// <returns></returns>
        QueryTypeBuilder AddQuery();

        /// <summary>
        /// Add any <see cref="XElement"/> to the Command.
        /// </summary>
        /// <param name="element">The element to add.</param>
        /// <returns></returns>
        GenericJmfBuilder AddNode(XElement element);

        /// <summary>
        /// Add any named element to the Command.
        /// </summary>
        /// <param name="name">The <see cref="XName"/> of the element to add.</param>
        /// <returns></returns>
        GenericJmfBuilder AddNode(XName name);
    }
}