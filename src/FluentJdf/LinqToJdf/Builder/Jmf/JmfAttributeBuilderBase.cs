using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
    /// <summary>
    /// Base class for JMF attribute builder
    /// </summary>
    public class JmfAttributeBuilderBase : IJmfCommandBuilder {
        private JmfBuilderBase builder;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="jmfBuilderBase"></param>
        protected JmfAttributeBuilderBase(JmfBuilderBase jmfBuilderBase) {
            ParameterCheck.ParameterRequired(jmfBuilderBase, "JmfBuilderBase");

            builder = jmfBuilderBase;
        }

        /// <summary>
        /// Gets the Element and allows set for inheritors
        /// </summary>
        public XElement Element {
            get { return builder.Element; }
        }

        /// <summary>
        /// Gets the container JMF builder.
        /// </summary>
        public JmfNodeBuilder ParentJmfNode {
            get { return builder.ParentJmfNode; }
        }

        /// <summary>
        /// Gets the messsage associated with this builder
        /// </summary>
        public Message Message {
            get { return builder.Message;  }
        }

        /// <summary>
        /// Validate the JMF
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        public JmfBuilderBase ValidateJmf(bool addSchemaInfo = true) {
            return builder.ValidateJmf(addSchemaInfo);
        }

        /// <summary>
        /// Add a command.
        /// </summary>
        /// <returns></returns>
        public CommandTypeBuilder AddCommand() {
            return ParentJmfNode.AddCommand();
        }

        /// <summary>
        /// Add a query.
        /// </summary>
        /// <returns></returns>
        public QueryTypeBuilder AddQuery() {
            return ParentJmfNode.AddQuery();
        }
    }
}