using System.Xml.Linq;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
    /// <summary>
    /// Interface for the JMF node builder base.
    /// </summary>
    public interface IJmfNodeBuilderBase {
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
        JmfNodeBuilderBase ValidateJmf(bool addSchemaInfo = true);
    }
}