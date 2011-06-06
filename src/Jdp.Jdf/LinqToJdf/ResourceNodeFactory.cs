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
    public class ResourceNodeFactory : NodeFactoryBase {
        XName resourceName;
        ResourceUsage usage;

        internal  ResourceNodeFactory(XContainer initiator, XName resourceName, ResourceUsage usage) : base(initiator) {
            ParameterCheck.ParameterRequired(resourceName, "resourceName");

            this.resourceName = resourceName;
            this.usage = usage;

            Node =  (initiator as XElement).LinkResource(usage, resourceName);
        }

        /// <summary>
        /// Create an input
        /// </summary>
        public ResourceNodeNameFactory WithInput() { return new ResourceNodeNameFactory(Initiator, ResourceUsage.Input); }

        /// <summary>
        /// Creates an output.
        /// </summary>
        public ResourceNodeNameFactory WithOutput() { return new ResourceNodeNameFactory(Initiator, ResourceUsage.Output); }
    }
}
