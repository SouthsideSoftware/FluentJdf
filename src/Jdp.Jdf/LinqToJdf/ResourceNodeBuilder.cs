using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Onpoint.Commons.Core.CodeContracts;

namespace Jdp.Jdf.LinqToJdf
{
    /// <summary>
    /// 
    /// </summary>
    public class ResourceNodeBuilder : NodeBuilderBase {
        internal  ResourceNodeBuilder(JdfNodeBuilder parent, XName resourceName, ResourceUsage usage) : base(parent) {
            ParameterCheck.ParameterRequired(resourceName, "resourceName");

            Element =  ParentJdfNode.Element.LinkResource(usage, resourceName);
        }

        /// <summary>
        /// Create an input
        /// </summary>
        public ResourceNodeNameBuilder WithInput() { return ParentJdfNode.WithInput(); }

        /// <summary>
        /// Creates an output.
        /// </summary>
        public ResourceNodeNameBuilder WithOutput() { return ParentJdfNode.WithOutput(); }
    }
}
