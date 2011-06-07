using System.Xml.Linq;
using Onpoint.Commons.Core.CodeContracts;

namespace Jdp.Jdf.LinqToJdf {
    /// <summary>
    /// Factory to create resources.
    /// </summary>
    public class ResourceNodeNameBuilder
    {
        internal JdfNodeBuilder ParentJdf;
        readonly ResourceUsage usage;

        internal ResourceNodeNameBuilder(JdfNodeBuilder jdfNodeBuilder, ResourceUsage usage) {
            ParameterCheck.ParameterRequired(jdfNodeBuilder, "jdfNodeBuilder");

            ParentJdf = jdfNodeBuilder;
            this.usage = usage;
        }

        /// <summary>
        /// Create a binding intent and return a factory to operate on it.
        /// </summary>
        public ResourceNodeBuilder BindingIntent() {
            return new ResourceNodeBuilder(ParentJdf, Resource.BindingIntent, usage); 
        }

        /// <summary>
        /// Create a resource with the given name and return a factory to operate in it.
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public ResourceNodeBuilder ResourceWithName(XName resourceName) {
            ParameterCheck.ParameterRequired(resourceName, "resourceName");

            return new ResourceNodeBuilder(ParentJdf, resourceName, usage);
        }
    }
}