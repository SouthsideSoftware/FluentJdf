using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
    /// <summary>
    /// Builder for setting attributes on generic JMF element.
    /// </summary>
    public class GenericJmfAttributeBuilder : JmfAttributeBuilderBase {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="jmfBuilderBase"></param>
        internal GenericJmfAttributeBuilder(JmfBuilderBase jmfBuilderBase) : base(jmfBuilderBase) {
        }

        /// <summary>
        /// Sets an attribute value.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public GenericJmfAttributeBuilder Attribute(XName name, string value) {
            ParameterCheck.ParameterRequired(name, "name");

            Element.SetAttributeValue(name, value);
            return this;
        }
    }
}
