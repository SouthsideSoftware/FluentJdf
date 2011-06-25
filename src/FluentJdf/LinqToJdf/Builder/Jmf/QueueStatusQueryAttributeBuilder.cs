using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
    /// <summary>
    /// Build attributes for QueueStatusQueryBuilder.
    /// </summary>
    public class QueueStatusQueryAttributeBuilder : IJmfCommandBuilder {
        readonly QueueStatusQueryBuilder builder;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="builder"></param>
        internal QueueStatusQueryAttributeBuilder(QueueStatusQueryBuilder builder) {
            ParameterCheck.ParameterRequired(builder, "builder");

            this.builder = builder;
        }

        /// <summary>
        /// Set the id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public QueueStatusQueryAttributeBuilder Id(string id)
        {

            builder.Element.SetAttributeValue("ID", id);
            return this;
        }

        /// <summary>
        /// Sets a unique id
        /// </summary>
        /// <returns></returns>
        public QueueStatusQueryAttributeBuilder UniqueId()
        {
            return Id(Globals.CreateUniqueId(QueueStatusQueryBuilder.IdPrefix));
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
        public JmfNodeBuilderBase ValidateJmf(bool addSchemaInfo = true) {
            return builder.ValidateJmf(addSchemaInfo);
        }

        /// <summary>
        /// Add a command.
        /// </summary>
        /// <returns></returns>
        public CommandTypeBuilder AddCommand() {
            return ParentJmfNode.AddCommand();
        }
    }
}