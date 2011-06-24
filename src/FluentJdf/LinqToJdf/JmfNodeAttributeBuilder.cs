using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Builder for JMF attributes
    /// </summary>
    public class JmfNodeAttributeBuilder : IJmfNodeBuilder {
        JmfNodeBuilder jmfNodeBuilder;

        internal JmfNodeAttributeBuilder(JmfNodeBuilder jmfNodeBuilder) {
            ParameterCheck.ParameterRequired(jmfNodeBuilder, "jmfNodeBuilder");

            this.jmfNodeBuilder = jmfNodeBuilder;
        }
        /// <summary>
        /// Gets the Element and allows set for inheritors
        /// </summary>
        public XElement Element {
            get { return jmfNodeBuilder.Element; }
        }

        /// <summary>
        /// Gets the container JMF builder.
        /// </summary>
        public JmfNodeBuilder ParentJmfNode {
            get { return jmfNodeBuilder.ParentJmfNode; }
        }

        /// <summary>
        /// Gets the messsage associated with this builder
        /// </summary>
        public Message Message {
            get { return jmfNodeBuilder.Message; }
        }

        /// <summary>
        /// Validate the JMF
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        public JmfNodeBuilderBase ValidateJmf(bool addSchemaInfo = true) {
            return jmfNodeBuilder.ValidateJmf(addSchemaInfo);
        }

        /// <summary>
        /// Add a command.
        /// </summary>
        /// <returns></returns>
        public JmfCommandTypeBuilder AddCommand() {
            return jmfNodeBuilder.AddCommand();
        }


        /// <summary>
        /// Sets the sender id to the supplied value.
        /// If not value is provided, will use the
        /// setting in the global configuration.
        /// </summary>
        /// <param name="senderId"></param>
        /// <returns></returns>
        public JmfNodeAttributeBuilder SenderId(string senderId = null) {
            Element.SetSenderId(senderId);
            return this;
        }
    }
}
