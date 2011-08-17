using System;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf
{
    /// <summary>
    /// Builder for JMF attributes
    /// </summary>
    public class JmfNodeAttributeBuilder : IJmfNodeBuilder {
        JmfNodeBuilder jmfBuilder;

        internal JmfNodeAttributeBuilder(JmfNodeBuilder jmfBuilder) {
            ParameterCheck.ParameterRequired(jmfBuilder, "JmfBuilder");

            this.jmfBuilder = jmfBuilder;
        }
        /// <summary>
        /// Gets the Element and allows set for inheritors
        /// </summary>
        public XElement Element {
            get { return jmfBuilder.Element; }
        }

        /// <summary>
        /// Gets the container JMF builder.
        /// </summary>
        public JmfNodeBuilder ParentJmfNode {
            get { return jmfBuilder.ParentJmfNode; }
        }

        /// <summary>
        /// Gets the messsage associated with this builder
        /// </summary>
        public Message Message {
            get { return jmfBuilder.Message; }
        }

        /// <summary>
        /// Validate the JMF
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        public JmfBuilderBase ValidateJmf(bool addSchemaInfo = true) {
            return jmfBuilder.ValidateJmf(addSchemaInfo);
        }

        /// <summary>
        /// Add a command.
        /// </summary>
        /// <returns></returns>
        public CommandTypeBuilder AddCommand() {
            return jmfBuilder.AddCommand();
        }

        /// <summary>
        /// Add a query.
        /// </summary>
        /// <returns></returns>
        public QueryTypeBuilder AddQuery() {
            return jmfBuilder.AddQuery();
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

        /// <summary>
        /// Sets the version of this JMF node.
        /// </summary>
        /// <param name="jdfVersion"></param>
        /// <returns></returns>
        public JmfNodeAttributeBuilder JdfVersion(string jdfVersion) {
            ParameterCheck.StringRequiredAndNotWhitespace(jdfVersion, "jdfVersion");

            Element.SetVersion(jdfVersion);
            return this;
        }

        /// <summary>
        /// Add any <see cref="XElement"/> to the Command.
        /// </summary>
        /// <param name="element">The element to add.</param>
        /// <returns></returns>
        public GenericJmfBuilder AddNode(XElement element)
        {
            ParameterCheck.ParameterRequired(element, "element");
            Element.Add(element);
            return new GenericJmfBuilder(element);
        }

        /// <summary>
        /// Add any named element to the Command.
        /// </summary>
        /// <param name="name">The XName of the element to add.</param>
        /// <returns></returns>
        public GenericJmfBuilder AddNode(XName name)
        {
            ParameterCheck.ParameterRequired(name, "name");
            return AddNode(new XElement(name));
        }

        /// <summary>
        /// Sets an attribute value.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public JmfNodeAttributeBuilder Attribute(XName name, string value) {
            ParameterCheck.ParameterRequired(name, "name");

            Element.SetAttributeValue(name, value);
            return this;
        }
    }
}
