using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Build attributes for JmfSubmitQueueEntryCommand
    /// </summary>
    public class JmfSubmitQueueEntryCommandAttributeBuilder : IJmfNodeBuilderBase {
        readonly JmfSubmitQueueEntryCommandBuilder builder;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="builder"></param>
        internal JmfSubmitQueueEntryCommandAttributeBuilder(JmfSubmitQueueEntryCommandBuilder builder) {
            ParameterCheck.ParameterRequired(builder, "builder");

            this.builder = builder;
        }

        /// <summary>
        /// Set the id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JmfSubmitQueueEntryCommandAttributeBuilder Id(string id)
        {

            builder.Element.SetAttributeValue("ID", id);
            return this;
        }

        /// <summary>
        /// Sets a unique id
        /// </summary>
        /// <returns></returns>
        public JmfSubmitQueueEntryCommandAttributeBuilder UniqueId()
        {
            return Id(Globals.CreateUniqueId(JmfSubmitQueueEntryCommandBuilder.IdPrefix));
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
    }
}
