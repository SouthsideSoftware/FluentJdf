using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Base class for JMF element builders.
    /// </summary>
    public abstract class JmfNodeBuilderBase : IJmfNodeBuilderBase {
        internal JmfNodeBuilderBase() {
            
        }

        internal JmfNodeBuilderBase(JmfNodeBuilder parentJmfBuilder)
        {
            ParentJmfNode = parentJmfBuilder;
        }

        internal JmfNodeBuilderBase(XElement element)
        {
            ParameterCheck.ParameterRequired(element, "element");
            element.ThrowExceptionIfNotInMessage();

            Element = element;
            ParentJmfNode = new JmfNodeBuilder(element.Document as Message);
        }

        /// <summary>
        /// Gets the Element and allows set for inheritors
        /// </summary>
        public XElement Element { get; protected set; }

        /// <summary>
        /// Gets the container JMF builder.
        /// </summary>
        public JmfNodeBuilder ParentJmfNode { get; protected set; }


        /// <summary>
        /// Validate the JMF
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        public JmfNodeBuilderBase ValidateJmf(bool addSchemaInfo = true)
        {
            Element.ValidateJdf(addSchemaInfo);
            return this;
        }

        /// <summary>
        /// Gets the messsage associated with this builder
        /// </summary>
        public Message Message { get { return Element.Document as Message; } }
    }
}