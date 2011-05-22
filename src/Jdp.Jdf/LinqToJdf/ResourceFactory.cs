using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Jdp.Jdf.LinqToJdf
{

    /// <summary>
    /// Placeholder class to make fluent interface for adding 
    /// resources work.
    /// </summary>
    public class ResourceFactory
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <param name="usageType"></param>
        internal ResourceFactory(XElement jdfNode, ResourceUsageType usageType) {
            Contract.Requires(jdfNode != null);
            jdfNode.ThrowExceptionIfNotJdfNode();

            JdfNode = jdfNode;
            UsageType = usageType;
        }

        /// <summary>
        /// Gets the JDF that will contain resources created by this factory.
        /// </summary>
        public XElement JdfNode { get; private set; }

        /// <summary>
        /// Gets the kind of link (input or output) for this factory
        /// </summary>
        public ResourceUsageType UsageType { get; private set; }

        /// <summary>
        /// Adds a resource with the given name to
        /// the factory's jdfNode linked 
        /// as indicated in usageType.
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public XElement Resource(XName resourceName) {
            return JdfNode;
        }
    }
}
