using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
    /// <summary>
    /// Base class for JMF element builders.
    /// </summary>
    public abstract class JmfBuilderBase : IJmfBuilderBase {
        internal JmfBuilderBase() {

        }

        internal JmfBuilderBase(JmfNodeBuilder parentJmfBuilder) {
            ParentJmfNode = parentJmfBuilder;
        }

        internal JmfBuilderBase(XElement element) {
            ParameterCheck.ParameterRequired(element, "element");
            element.ThrowExceptionIfNotInMessage();

            Element = element;
            ParentJmfNode = new JmfNodeBuilder(element.Document as Message);
        }

        /// <summary>
        /// Gets the Element and allows set for inheritors
        /// </summary>
        public XElement Element {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the container JMF builder.
        /// </summary>
        public JmfNodeBuilder ParentJmfNode {
            get;
            protected set;
        }


        /// <summary>
        /// Validate the JMF
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        public JmfBuilderBase ValidateJmf(bool addSchemaInfo = true) {
            Element.ValidateJmf(addSchemaInfo);
            return this;
        }

        /// <summary>
        /// Gets the messsage associated with this builder
        /// </summary>
        public Message Message {
            get {
                return Element.Document as Message;
            }
        }

        /// <summary>
        /// Add a command.
        /// </summary>
        /// <returns></returns>
        public CommandTypeBuilder AddCommand() {
            return new CommandTypeBuilder(ParentJmfNode);
        }

        /// <summary>
        /// Add a query.
        /// </summary>
        /// <returns></returns>
        public QueryTypeBuilder AddQuery() {
            return new QueryTypeBuilder(ParentJmfNode);
        }

        /// <summary>
        /// Add any <see cref="XElement"/> to the Command.
        /// </summary>
        /// <param name="element">The element to add.</param>
        /// <returns></returns>
        public GenericJmfBuilder AddNode(XElement element) {
            ParameterCheck.ParameterRequired(element, "element");
            Element.Add(element);
            return new GenericJmfBuilder(element);
        }

        /// <summary>
        /// Add any named element to the Command.
        /// </summary>
        /// <param name="name">The <see cref="XName"/> of the element to add.</param>
        /// <returns></returns>
        public GenericJmfBuilder AddNode(XName name) {
            ParameterCheck.ParameterRequired(name, "name");
            return AddNode(new XElement(name));
        }

    }
}