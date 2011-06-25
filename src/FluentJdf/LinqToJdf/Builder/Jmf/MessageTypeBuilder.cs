using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
    /// <summary>
    /// Base class for message type builders
    /// </summary>
    public class MessageTypeBuilder {
        /// <summary>
        /// Gets the parent JMF builder.
        /// </summary>
        protected JmfNodeBuilder ParentJmf { get; private set; }

        internal MessageTypeBuilder(JmfNodeBuilder jmfBuilder) {
            ParameterCheck.ParameterRequired(jmfBuilder, "JmfBuilder");

            ParentJmf = jmfBuilder;
        }
    }
}