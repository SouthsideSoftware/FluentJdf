using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Provides specific kinds of builders for creating working with specific kinds of elements.
    /// </summary>
    public class NodeBuilder {
        internal NodeBuilder(XContainer initiator) {
            ParameterCheck.ParameterRequired(initiator, "InitiatorNode");

            Initiator = initiator;
        }

        /// <summary>
        /// Gets the XContainer that initiated this action
        /// </summary>
        public XContainer Initiator { get; private set; }

        /// <summary>
        /// Gets a factory for creating JDF for intent
        /// </summary>
        /// <returns></returns>
        public JdfNodeBuilder Intent() {
            return new JdfNodeBuilder(Initiator, "Product");
        }

        /// <summary>
        /// Create a process group node factory
        /// </summary>
        public JdfNodeBuilder ProcessGroup() {
            return new JdfNodeBuilder(Initiator, "ProcessGroup");
        }

        /// <summary>
        /// Creates a process node factory.
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public JdfNodeBuilder Process(params string[] types) {
            return new JdfNodeBuilder(Initiator, types);
        }
    }
}