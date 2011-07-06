using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FluentJdf.LinqToJdf.Builder.Jmf
{
    /// <summary>
    /// Builder for generic JMF elements.
    /// </summary>
    public class GenericJmfBuilder : JmfBuilderBase
    {
        internal GenericJmfBuilder() {}
        internal GenericJmfBuilder(JmfNodeBuilder parentJmfBuilder) : base(parentJmfBuilder) {}
        internal GenericJmfBuilder(XElement element) : base(element) {}

        /// <summary>
        /// Get the attribute builder for the element.
        /// </summary>
        /// <returns></returns>
        public GenericJmfAttributeBuilder With() {
            return new GenericJmfAttributeBuilder(this);
        }
    }
}
