using System;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jdf {
    /// <summary>
    /// Base class for element builders.
    /// </summary>
    public abstract class JdfNodeBuilderBase : IJdfNodeBuilderBase {
        internal JdfNodeBuilderBase(JdfNodeBuilder parentJdfBuilder) {
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

            if (element.GetJdfParentOrNull() != null) {
                ParentJdfNode = new JdfNodeBuilder(element.JdfParent());
            }
        }

        internal JdfNodeBuilderBase() {
        }

        /// <summary>
        /// Gets the Element and allows set for inheritors
        /// </summary>
        public XElement Element {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the container JDF builder.
        /// </summary>
        public JdfNodeBuilder ParentJdfNode {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the ticket associated with this builder
        /// </summary>
        public Ticket Ticket {
            get {
                return Element.Document as Ticket;
            }
        }

        /// <summary>
        /// Gets the root JDF node.
        /// </summary>
        public JdfNodeBuilder RootJdfNode {
            get { return new JdfNodeBuilder(Element.Document.Root); }
        }
    }
}