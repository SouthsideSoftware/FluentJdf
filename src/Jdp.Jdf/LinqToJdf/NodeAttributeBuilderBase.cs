using System.Xml.Linq;
using Onpoint.Commons.Core.CodeContracts;

namespace Jdp.Jdf.LinqToJdf {
    /// <summary>
    /// Base class for attribute builders
    /// </summary>
    public class NodeAttributeBuilderBase {
        readonly NodeBuilderBase _nodeBuilderBase;

        internal NodeAttributeBuilderBase(NodeBuilderBase _nodeBuilderBase) {
            ParameterCheck.ParameterRequired(_nodeBuilderBase, "NodeBuilderBase");

            this._nodeBuilderBase = _nodeBuilderBase;
        }

        /// <summary>
        /// Gets the intent node.
        /// </summary>
        /// <returns></returns>
        public XElement Element {
            get { return _nodeBuilderBase.Element; }
        }

        /// <summary>
        /// Sets any attribute value
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks>Use specific Set[attribute name] methods in preference to this method.
        /// Those setters may have side-effects that will not be honored by this method.  For example,
        /// setting the id of a resource via the SetId method will fixup references by default.</remarks>
        public NodeAttributeBuilderBase Attribute(XName name, string value) {
            ParameterCheck.ParameterRequired(name, "name");

            Element.SetAttributeValue(name, value);

            return this;
        }

        /// <summary>
        /// Sets the descriptive name.
        /// </summary>
        /// <param name="descriptiveName"></param>
        /// <returns></returns>
        public NodeAttributeBuilderBase DescriptiveName(string descriptiveName) {
            Element.SetDescriptiveName(descriptiveName);

            return this;
        }
    }
}