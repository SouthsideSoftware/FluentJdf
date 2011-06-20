using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Base class for JMF element builders.
    /// </summary>
    public abstract class JmfNodeBuilderBase
    {
        internal JmfNodeBuilderBase(JmfNodeBuilder parentJmfBuilder)
        {
            ParentJmfNode = parentJmfBuilder;
        }

        //todo: not right yet
        internal JmfNodeBuilderBase(XElement element)
        {
            ParameterCheck.ParameterRequired(element, "element");

            Element = element;
        }

        internal JmfNodeBuilderBase()
        {
            
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