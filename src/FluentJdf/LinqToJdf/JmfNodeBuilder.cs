using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Factory for creating intent nodes.
    /// </summary>
    public class JmfNodeBuilder : JmfNodeBuilderBase {
        internal JmfNodeBuilder(Message message) {
            ParameterCheck.ParameterRequired(message, "message");

            Element = new XElement(LinqToJdf.Element.JMF);
            message.Add(Element);
        }

        /// <summary>
        /// Add a command.
        /// </summary>
        /// <returns></returns>
        public JmfCommandTypeBuilder AddCommand() {
            return new JmfCommandTypeBuilder(this);
        }
    }
}