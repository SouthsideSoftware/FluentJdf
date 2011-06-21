using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Base class for element builders.
    /// </summary>
    public abstract class JdfNodeBuilderBase
    {
        internal JdfNodeBuilderBase(JdfNodeBuilder parentJdfBuilder)
        {
            ParentJdfNode = parentJdfBuilder;
        }

        internal JdfNodeBuilderBase(XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            InitializeFromElement(element);
        }

        /// <summary>
        /// Initialize from an element.
        /// </summary>
        /// <param name="element"></param>
        protected void InitializeFromElement(XElement element) {
            Element = element;

            if (element.GetJdfParentOrNull() != null)
            {
                ParentJdfNode = new JdfNodeBuilder(element.JdfParent());
            }
        }

        internal JdfNodeBuilderBase(){}

        /// <summary>
        /// Gets the Element and allows set for inheritors
        /// </summary>
        public XElement Element { get; protected set; }

        /// <summary>
        /// Gets the container JDF builder.
        /// </summary>
        public JdfNodeBuilder ParentJdfNode { get; protected set; }

        /// <summary>
        /// Validate the JDF
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        public JdfNodeBuilderBase ValidateJdf(bool addSchemaInfo = true)
        {
            Element.ValidateJdf(addSchemaInfo);
            return this;
        }

        /// <summary>
        /// Gets the ticket associated with this builder
        /// </summary>
        public Ticket Ticket { get { return Element.Document as Ticket; } }
    }
}